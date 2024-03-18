using MCS100_CPU_CODESYS.Properties;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.IO.Ports;
using System;

using MBus;
using Microsoft.Win32;

namespace MCS100_CPU_CODESYS
{
    public partial class mainForm : Form
    {
        private Socket mbTcp;
        public ModBusClass mbClass { get; set; } = null;
        SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1, 1);

        public mainForm()
        {
            InitializeComponent();
            this.Text += $" ver{Assembly.GetEntryAssembly().GetName().Version}";
            AddEvents();
        }
        private void AddEvents()
        {
            Load += FormLoad;
            FormClosed += FormClose;
            GridClear.Click += (s, e) => GridClearClick();
            comPort.SelectedIndexChanged += (s, e) => mbRtu.PortName = ((ComboBox)s).SelectedItem.ToString();
            BaudRate.SelectedIndexChanged += (s, e) => BaudRateSelectedIndexChanged();
            RefreshSerial.Click += (s, e) => AddPorts(comPort);
            foreach (ToolStripDropDownItem item in dataBits.DropDownItems) item.Click += DataBitsForSerial;
            foreach (ToolStripDropDownItem item in Parity.DropDownItems) item.Click += ParityForSerial;
            foreach (ToolStripDropDownItem item in stopBits.DropDownItems) item.Click += StopBitsForSerial;
            OpenCom.Click += OpenComClick;
            Connect.Click += ConnectClick;
            manualReadButton.Click += async (s, e) => await Task.Run(() => StartReading());
            RegistersGrid.CellEndEdit += async (s, e) => await Task.Run(() => CellSetRegisterValue(s, e));
            SyncTime.Click += async (s, e) => await Task.Run(() => SetRealTimeClick());
        }
        private void FormLoad(object sender, EventArgs e)
        {
            ComDefault();
            AddPorts(comPort);
            LoadConfig();
            FillGrid();
        }
        private void FormClose(object sender, EventArgs e) => SaveConfig();
        private void ComDefault()
        {
            mbRtu.WriteTimeout =
            mbRtu.ReadTimeout = 500;
            BaudRate.SelectedItem = "38400";
            DataBitsForSerial(dataBits8, null);
            ParityForSerial(ParityNone, null);
            StopBitsForSerial(stopBits1, null);
            BaudRateSelectedIndexChanged();
        }
        private void LoadConfig()
            => Invoke((MethodInvoker)(() => 
            {
                if (Settings.Default.comPort != string.Empty)
                    comPort.Text = Settings.Default.comPort;
                IPaddressBox.Text = Settings.Default.ipAddr;
                numericPort.Value = Settings.Default.port;
            }));
        private void SaveConfig()
        {
            Settings.Default.comPort = comPort.Text;
            Settings.Default.ipAddr = IPaddressBox.Text;
            Settings.Default.port = (ushort)numericPort.Value;
            Settings.Default.Save();
        }
        private void ClearConfig_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            LoadConfig();
            Settings.Default.Save();
        }
        private void ToInfoStatus(string msg) => BeginInvoke((MethodInvoker)(() => InfoStatus.Text = msg));
        private void AddPorts(ComboBox box)
        {
            box.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length > 0)
            {
                box.Items.AddRange(ports);
                box.SelectedItem = box.Items[0];
            }
            OpenCom.Enabled = ports.Length > 0;
        }
        private void DataBitsForSerial(object sender, EventArgs e)
        {
            ToolStripMenuItem databits = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in dataBits.DropDownItems) item.CheckState = CheckState.Unchecked;
            mbRtu.DataBits = Convert.ToInt32(databits.Text);
            databits.CheckState = CheckState.Checked;
            dataBitsInfo.Text = mbRtu.DataBits.ToString();
        }
        private void ParityForSerial(object sender, EventArgs e)
        {
            ToolStripMenuItem parity = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in Parity.DropDownItems) item.CheckState = CheckState.Unchecked;
            switch (parity.Text)
            {
                case "None":
                    mbRtu.Parity = System.IO.Ports.Parity.None;
                    break;
                case "Odd":
                    mbRtu.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "Even":
                    mbRtu.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "Mark":
                    mbRtu.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "Space":
                    mbRtu.Parity = System.IO.Ports.Parity.Space;
                    break;
            }
            parity.CheckState = CheckState.Checked;
            ParityInfo.Text = mbRtu.Parity.ToString();
        }
        private void StopBitsForSerial(object sender, EventArgs e)
        {
            ToolStripMenuItem stopbits = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in stopBits.DropDownItems) item.CheckState = CheckState.Unchecked;
            Enum.TryParse(Enum.GetName(typeof(StopBits), Convert.ToInt32(stopbits.Text)), out StopBits bits);
            mbRtu.StopBits = bits;
            stopbits.CheckState = CheckState.Checked;
            StopBitsInfo.Text = stopbits.Text;
        }
        private void BaudRateSelectedIndexChanged()
            => mbRtu.BaudRate = Convert.ToInt32(BaudRate.SelectedItem);
        private void FillGrid()
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                RegistersGrid.Rows.Clear();
                foreach (string enumName in Enum.GetNames(typeof(REnum))) {
                    Enum.TryParse(enumName, out REnum index);
                    RegistersGrid.Rows.Add((int)index, enumName);
                }
                DateFromGrid.Text = "";
                TimeFromGrid.Text = "";
            }));
        }
        private void GridClearClick() => FillGrid();
        private void AfterComEvent(bool sw)
        {
            comPort.Enabled =
                RefreshSerial.Enabled =
                TcpPage.Enabled = !sw;
            mbClass = sw ? new ModBusClass(mbRtu) : null;
        }
        private void AfterTcpEvent(bool sw)
        {
            IPaddressBox.Enabled =
                numericPort.Enabled =
                RtuPage.Enabled = !sw;
            mbClass = sw ? new ModBusClass(mbTcp) : null;
        }
        private void AfterAnyInterfaceEvent(bool sw)
        {
            RegistersGrid.Enabled =
                SettingsPanel.Enabled = sw;
        }
        private void AfterStartReading(bool sw)
            => manualReadButton.Enabled =
                        OpenCom.Enabled =
                        Connect.Enabled =
                       BaudRate.Enabled =
                toolStripSerial.Enabled = !sw;
        private void OpenComClick(object sender, EventArgs e)
        {
            if (OpenCom.Text == "Open")
            {
                try
                {
                    mbRtu.Open();
                    OpenCom.Text = "Close";
                }
                catch (Exception ex) { ToInfoStatus(ex.Message); }
            }
            else
            {
                mbRtu.Close();
                OpenCom.Text = "Open";
            }
            AfterComEvent(mbRtu.IsOpen);
            AfterAnyInterfaceEvent(mbRtu.IsOpen);
        }
        private void ConnectClick(object sender, EventArgs e)
        {
            try
            {
                if (Connect.Text == "Connect")
                {
                    mbTcp = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    this.Enabled = false;
                    Connect.Text = "Connecting...";
                    if (!mbTcp.ConnectAsync(IPaddressBox.Text, Convert.ToUInt16(numericPort.Value)).Wait(1500))
                        throw new SocketException(10060);
                    this.Enabled = true;
                    Connect.Text = "Close";
                }
                else
                {
                    if (!this.Enabled) this.Enabled = true;
                    mbTcp.Shutdown(SocketShutdown.Both);
                    Connect.Text = "Connect";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (!this.Enabled) this.Enabled = true;
                try { mbTcp.Shutdown(SocketShutdown.Both); } catch { }
                Connect.Text = "Connect";
            }
            AfterTcpEvent(mbTcp.Connected);
            AfterAnyInterfaceEvent(mbTcp.Connected);
        }
        async private Task<Reply> WriteRegister(REnum register, ushort value)
        {
            byte[] cmdOut = mbClass.FormatModBusCMD((byte)ID.Value, WriteMB.WriteAO, (ushort)register, value);
            Tuple<byte[], Reply> reply = mbClass.Handler(cmdOut);
            ToInfoStatus($"Отправлено на ID: {ID.Value} : {reply.Item2}");
            await Task.Delay(50);
            return reply.Item2;
        }
        async private Task<Reply> MWriteRegisters(REnum startRegister, ushort[] values)
        {
            byte[] cmdOut = mbClass.FormatMultiplyAO((byte)ID.Value, (ushort)startRegister, (ushort)values.Length, values);
            Tuple<byte[], Reply> reply = mbClass.Handler(cmdOut);
            ToInfoStatus($"Отправлено на ID: {ID.Value} : {reply.Item2}");
            await Task.Delay(50);
            return reply.Item2;
        }
        async private Task StartReading()
        {
            bool firstRead = true;
            AfterStartReading(autoRButton.Checked);
            do
            {
                await semaphoreSlim.WaitAsync();
                try
                {
                    byte[] cmdOut;
                    Tuple<byte[], Reply> reply;
                    if (firstRead)
                    {
                        cmdOut = mbClass.FormatModBusCMD((byte)ID.Value, ReadMB.ReadAO, 0, 7);
                        reply = mbClass.Handler(cmdOut);
                        ToInfoStatus(reply.Item2.ToString());
                        if (reply != null && reply.Item2 == Reply.Ok) DataToGrid(reply.Item1, (int)CEnum.ReadWriteAO);
                        firstRead = false;
                    }
                    cmdOut = mbClass.FormatModBusCMD((byte)ID.Value, ReadMB.ReadAI, 0, 7);
                    reply = mbClass.Handler(cmdOut);
                    if (reply != null && reply.Item2 == Reply.Ok) DataToGrid(reply.Item1, (int)CEnum.ReadAI);
                }
                catch { ToInfoStatus("Error receive"); }
                finally
                {
                    await Task.Delay(manualRButton.Checked ? 50 : (int)timeoutMB.Value);
                    semaphoreSlim.Release();
                }
            }
            while (autoRButton.Checked);
            AfterStartReading(autoRButton.Checked);
        }

        async private Task CellSetRegisterValue(object sender, DataGridViewCellEventArgs e)
        {
            Enum.TryParse(RegistersGrid[(int)CEnum.field, e.RowIndex].Value.ToString(), out REnum register);
            if (RegistersGrid[(int)CEnum.ReadWriteAO, e.RowIndex].Value is null) return;
            await semaphoreSlim.WaitAsync();
            try
            {
                if (UInt16.TryParse(RegistersGrid[(int)CEnum.ReadWriteAO, e.RowIndex].Value.ToString(), out ushort value)
                    && await WriteRegister(register, value) == Reply.Ok) return;
                throw new Exception();
            }
            catch { ToInfoStatus("Error transcieve"); RegistersGrid[(int)CEnum.ReadWriteAO, e.RowIndex].Value = ""; }
            finally { semaphoreSlim.Release(); }
        }
        private void DataToGrid(byte[] cmdIn, int column)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                for (int i = 3, j = 0; i < cmdIn.Length - 2; j++)
                {
                    RegistersGrid[column, j].Value = cmdIn[i] << 8 | cmdIn[i+1];
                    i += 2;
                }
                DateFromGrid.Text =
                $"{RegistersGrid[column, 0].Value}/{RegistersGrid[column, 1].Value}/{RegistersGrid[column, 2].Value}";
                TimeFromGrid.Text =
                $"{RegistersGrid[column, 3].Value}:{RegistersGrid[column, 4].Value}:{RegistersGrid[column, 5].Value}";
            }));
        }
        async private Task SetRealTimeClick()
        {
            ushort[] timeArray = new ushort[7]
                {
                    (ushort)DateTime.Now.Year,
                    (ushort)DateTime.Now.Month,
                    (ushort)DateTime.Now.Day,
                    (ushort)DateTime.Now.Hour,
                    (ushort)DateTime.Now.Minute,
                    (ushort)DateTime.Now.Second,
                    1
                };
            await semaphoreSlim.WaitAsync();
            try
            {
                await MWriteRegisters(REnum.Year, new ushort[7]);
                await MWriteRegisters(REnum.Year, timeArray);
            }
            catch { ToInfoStatus("Error transcieve"); }
            finally { semaphoreSlim.Release(); }
        }
    }
}
