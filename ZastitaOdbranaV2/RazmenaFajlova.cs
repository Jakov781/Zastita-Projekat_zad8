using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZastitaInformacijaProjekat
{

    public partial class RazmenaFajlova : Form
    {
        private const int BufferSize = 65_536; 

        private Socket? _serverSocket;

        public RazmenaFajlova()
        {
            InitializeComponent();
        }


        public async Task SendFileAsync()
        {
            try
            {
                string originalFile = lblIzabranFajl.Text;
                if (!File.Exists(originalFile))
                    throw new Exception("Izabrani fajl ne postoji.");

                byte[] key = GetKey();

                string tempFolder = Path.Combine(Application.StartupPath, "Temp");
                Directory.CreateDirectory(tempFolder);

                lblStatusSlanja.Text = "Šifrovanje…";
                string encryptedPath = await new CodeFiles()
                    .EncodeFileWithHeaderAsync(originalFile, tempFolder, key);

                string host = txtPosaljiIP.Text.Trim();
                int port = int.Parse(txtPosaljiPort.Text.Trim());

                lblStatusSlanja.Text = $"Povezivanje na {host}:{port}…";

                using TcpClient client = new TcpClient();
                await client.ConnectAsync(host, port);

                lblStatusSlanja.Text = "Slanje…";

                using NetworkStream stream = client.GetStream();

                string fileName = Path.GetFileName(encryptedPath);
                long fileSize = new FileInfo(encryptedPath).Length;

                byte[] nameBytes = Encoding.UTF8.GetBytes(fileName);
                await stream.WriteAsync(BitConverter.GetBytes(nameBytes.Length));
                await stream.WriteAsync(nameBytes);

                await stream.WriteAsync(BitConverter.GetBytes(fileSize));

                byte[] buffer = new byte[BufferSize];
                long sent = 0;

                using (FileStream fs = new FileStream(encryptedPath,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    BufferSize, FileOptions.SequentialScan))
                {
                    int read;
                    while ((read = await fs.ReadAsync(buffer.AsMemory(0, BufferSize))) > 0)
                    {
                        await stream.WriteAsync(buffer.AsMemory(0, read));
                        sent += read;
                    }
                }

                await stream.FlushAsync();

                File.AppendAllText("Log.txt",
                    $"Poslat fajl {encryptedPath}    " + DateTime.Now + "\n");

                lblStatusSlanja.Text =
                    $"✓ Poslato: {fileName} ({sent:N0} bajta)";

                try { File.Delete(encryptedPath); } catch { /* ignore */ }
            }
            catch (Exception ex)
            {
                lblStatusSlanja.Text = $"Greška: {ex.Message}";
                File.AppendAllText("Log.txt",
                    $"Neuspešno slanje: {ex.Message}    " + DateTime.Now + "\n");
            }
        }


        public async Task StartListeningAsync()
        {
            _serverSocket = new Socket(
                AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                int port = int.Parse(txtPrimalacPort.Text.Trim());
                _serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                _serverSocket.Listen(5);

                lblStatusOsluskivanja.Text =
                    $"Osluškujem na portu {port}…";

                while (true)
                {
                    Socket clientSocket = await _serverSocket.AcceptAsync();
                    string remote = ((IPEndPoint?)clientSocket.RemoteEndPoint)
                                    ?.ToString() ?? "nepoznat";

                    File.AppendAllText("Log.txt",
                        $"Prihvaćena veza od {remote}    " + DateTime.Now + "\n");

                    _ = Task.Run(() => HandleClientAsync(clientSocket, remote));
                }
            }
            catch (Exception ex)
            {
                
                lblStatusOsluskivanja.Text = $"Greška: {ex.Message}";
            }
            finally
            {
                _serverSocket?.Close();
            }
        }

        private async Task HandleClientAsync(Socket clientSocket, string remote)
        {
            string? receivedPath = null;

            try
            {
                using (clientSocket)
                using (NetworkStream stream = new NetworkStream(clientSocket))
                {
                    // Read filename length + filename
                    byte[] lenBuf = new byte[4];
                    await stream.ReadExactlyAsync(lenBuf);
                    int nameLen = BitConverter.ToInt32(lenBuf, 0);

                    byte[] nameBuf = new byte[nameLen];
                    await stream.ReadExactlyAsync(nameBuf);
                    string fileName = Encoding.UTF8.GetString(nameBuf);

                    // Read file size (8-byte int64)
                    byte[] sizeBuf = new byte[8];
                    await stream.ReadExactlyAsync(sizeBuf);
                    long fileSize = BitConverter.ToInt64(sizeBuf, 0);


                    UpdateStatus(lblStatusOsluskivanja,
                        $"Prijem '{fileName}' ({fileSize:N0} bajta) od {remote}…");

                    // Save encrypted file to disk
                    string receiveFolder = Path.Combine(
                        Application.StartupPath, "Preuzeto");
                    Directory.CreateDirectory(receiveFolder);
                    receivedPath = Path.Combine(receiveFolder, $"recv_{fileName}");

                    byte[] buffer = new byte[BufferSize];
                    long received = 0;

                    using (FileStream fs = new FileStream(receivedPath,
                        FileMode.Create, FileAccess.Write, FileShare.None,
                        BufferSize, FileOptions.SequentialScan))
                    {
                        while (received < fileSize)
                        {
                            int toRead = (int)Math.Min(BufferSize, fileSize - received);
                            int read = await stream.ReadAsync(buffer.AsMemory(0, toRead));
                            if (read == 0)
                                throw new EndOfStreamException("Veza prekinuta pre kraja.");
                            await fs.WriteAsync(buffer.AsMemory(0, read));
                            received += read;
                        }
                    }
                    UpdateStatus(lblStatusOsluskivanja,
                        $"Primljeno {received:N0} bajta. Dešifrovanje…");

                    byte[] key = GetKey();
                    await new CodeFiles().DecodeFileWithHeaderAsync(
                        receivedPath, receiveFolder, key);

                }

                try { File.Delete(receivedPath); } catch { /* ignore */ }

                File.AppendAllText("Log.txt",
                    $"Primljen i dešifrovan fajl od {remote}    " + DateTime.Now + "\n");

                UpdateStatus(lblStatusOsluskivanja,
                    $"✓ Fajl primljen i verifikovan.");
            }
            catch (Exception ex)
            {
                File.AppendAllText("Log.txt",
                    $"Greška pri prijemu od {remote}: {ex.Message}    " + DateTime.Now + "\n");
                UpdateStatus(lblStatusOsluskivanja, $"Greška: {ex.Message}");
            }
        }


        private void UpdateStatus(Label label, string text)
        {
            if (label.InvokeRequired)
                label.Invoke(() => label.Text = text);
            else
                label.Text = text;
        }

        private byte[] GetKey() => KeyUtils.DeriveKey(txtKljuc.Text, 16);

        private void btnOdaberiFajl_Click(object sender, EventArgs e)
        {
            using OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
                lblIzabranFajl.Text = fd.FileName;
        }

        private async void btnPosalji_Click(object sender, EventArgs e)
        {
            btnPosalji.Enabled = false;
            try { await SendFileAsync(); }
            finally { btnPosalji.Enabled = true; }
        }

        private async void btnZapocniOsluskivanje_Click(object sender, EventArgs e)
        {
            await StartListeningAsync();
        }

        private void btnPrekiniOsluskivanje_Click(object sender, EventArgs e)
        {
            try
            {
                _serverSocket?.Close();
                lblStatusOsluskivanja.Text = "Osluskivanje je stopirano";
            }
            catch (Exception ex)
            {
                lblStatusOsluskivanja.Text = $"Greska pri stopiranje: {ex.Message}";
            }
        }

        private void RazmenaFajlova_Load(object sender, EventArgs e) { }
    }
}
