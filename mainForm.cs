using MCS100_CPU_CODESYS.Properties;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.IO.Ports;
using System;

using Modbus.Protocol;
using StaticSettings;
using ProtocolEnums;

namespace MCS100_CPU_CODESYS
{
    public partial class mainForm : Form
    {

        private Socket mbTcp;
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
            comPort.SelectedIndexChanged += (s, e) => mainPort.PortName = ((ComboBox)s).SelectedItem.ToString();
            BaudRate.SelectedIndexChanged += (s, e) => BaudRateSelectedIndexChanged();
            RefreshSerial.Click += (s, e) => AddPorts(comPort);
            foreach (ToolStripDropDownItem item in dataBits.DropDownItems) item.Click += DataBitsForSerial;
            foreach (ToolStripDropDownItem item in Parity.DropDownItems) item.Click += ParityForSerial;
            foreach (ToolStripDropDownItem item in stopBits.DropDownItems) item.Click += StopBitsForSerial;
            OpenCom.Click += OpenComClick;
            Connect.Click += ConnectClick;

            ReadButton.Click += (s, e) => StartReading();
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
        private void ToMessageStatus(string msg) => BeginInvoke((MethodInvoker)(() => MessageStatus.Text = msg));
        private void ToReplyStatus(string msg) => BeginInvoke((MethodInvoker)(() => ReplyStatus.Text = msg));
        private void ComDefault()
        {
            mainPort.WriteTimeout =
            mainPort.ReadTimeout = 500;
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
            mainPort.DataBits = Convert.ToInt32(databits.Text);
            databits.CheckState = CheckState.Checked;
            dataBitsInfo.Text = mainPort.DataBits.ToString();
        }
        private void ParityForSerial(object sender, EventArgs e)
        {
            ToolStripMenuItem parity = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in Parity.DropDownItems) item.CheckState = CheckState.Unchecked;
            switch (parity.Text)
            {
                case "None":
                    mainPort.Parity = System.IO.Ports.Parity.None;
                    break;
                case "Odd":
                    mainPort.Parity = System.IO.Ports.Parity.Odd;
                    break;
                case "Even":
                    mainPort.Parity = System.IO.Ports.Parity.Even;
                    break;
                case "Mark":
                    mainPort.Parity = System.IO.Ports.Parity.Mark;
                    break;
                case "Space":
                    mainPort.Parity = System.IO.Ports.Parity.Space;
                    break;
            }
            parity.CheckState = CheckState.Checked;
            ParityInfo.Text = mainPort.Parity.ToString();
        }
        private void StopBitsForSerial(object sender, EventArgs e)
        {
            ToolStripMenuItem stopbits = (ToolStripMenuItem)sender;
            foreach (ToolStripMenuItem item in stopBits.DropDownItems) item.CheckState = CheckState.Unchecked;
            Enum.TryParse(Enum.GetName(typeof(StopBits), Convert.ToInt32(stopbits.Text)), out StopBits bits);
            mainPort.StopBits = bits;
            stopbits.CheckState = CheckState.Checked;
            StopBitsInfo.Text = stopbits.Text;
        }
        private void BaudRateSelectedIndexChanged()
            => mainPort.BaudRate = Convert.ToInt32(BaudRate.SelectedItem);
        private void FillGrid()
        {
            RegistersGrid.Rows.Clear();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            foreach (string enumName in Enum.GetNames(typeof(REnum)))
            {
                Enum.TryParse(enumName, out REnum index);
                rows.Add(new DataGridViewRow());
                rows[rows.Count - 1].CreateCells(RegistersGrid, (int)index, enumName);
                rows[rows.Count - 1].Height = 17;
            }
            RegistersGrid.Rows.AddRange(rows.ToArray());
            DateFromGrid.Text = "";
            TimeFromGrid.Text = "";
        }
        private void GridClearClick() => FillGrid();
        private void AfterAnyInterfaceEvent(bool sw)
        {
            RegistersGrid.Enabled =
                ReadButton.Enabled = 
                SettingsPanel.Enabled = sw;
        }
        private void OpenComClick(object sender, EventArgs e)
        {
            void AfterInterfaceEvent(bool sw)
            {
                comPort.Enabled =
                    RefreshSerial.Enabled =
                    TcpPage.Enabled = !sw;
                Options.mainInterface = sw ? mainPort : null;
            }
            if (OpenCom.Text == "Open")
            {
                try { mainPort.Open(); }
                catch (Exception ex) { ToMessageStatus(ex.Message); }
            }
            else
                mainPort.Close();
            OpenCom.Text = mainPort.IsOpen ? "Close" : "Open";
            AfterInterfaceEvent(mainPort.IsOpen);
            AfterAnyInterfaceEvent(mainPort.IsOpen);
        }
        private void ConnectClick(object sender, EventArgs e)
        {
            void AfterInterfaceEvent(bool sw)
            {
                IPaddressBox.Enabled =
                    numericPort.Enabled =
                    RtuPage.Enabled = !sw;
                Options.mainInterface = sw ? mbTcp : null;
            }
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
            AfterInterfaceEvent(mbTcp.Connected);
            AfterAnyInterfaceEvent(mbTcp.Connected);
        }

        async private Task<Reply> WriteRegister(REnum register, ushort value)
        {
            using (ModbusProtocol modbus = new ModbusProtocol(Options.mainInterface))
            {
                modbus.ToReply += ToReplyStatus; 
                byte[] cmdOut = modbus.FormatModBusCMD((byte)ID.Value, WriteMB.WriteAO, (ushort)register, value);
                Tuple<byte[], Reply> reply = await modbus.GetData(cmdOut);
                ToMessageStatus($"Отправлено на ID: {ID.Value} : {reply.Item2}");
                await Task.Delay((int)timeoutMB.Value);
                return reply.Item2;
            }
        }
        async private Task<Reply> MWriteRegisters(REnum startRegister, ushort[] values)
        {
            using (ModbusProtocol modbus = new ModbusProtocol(Options.mainInterface))
            {
                modbus.ToReply += ToReplyStatus;
                byte[] cmdOut = modbus.FormatMultiplyAO((byte)ID.Value, (ushort)startRegister, (ushort)values.Length, values);
                Tuple<byte[], Reply> reply = await modbus.GetData(cmdOut);
                ToMessageStatus($"Отправлено на ID: {ID.Value} : {reply.Item2}");
                await Task.Delay((int)timeoutMB.Value);
                return reply.Item2;
            }
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
                TimeFromReg.Text = 
                $"{RegistersGrid[2, 0].Value}.{RegistersGrid[2, 1].Value:00}.{RegistersGrid[2, 2].Value:00} " +
                $"{RegistersGrid[2, 3].Value:00}:{RegistersGrid[2, 4].Value:00}:{RegistersGrid[2, 5].Value:00}";
            }));
        }
        async private void StartReading()
        {
            void AfterStartReading(bool sw)
            {
                OpenCom.Enabled =
                        Connect.Enabled =
                       BaudRate.Enabled =
                toolStripSerial.Enabled = sw;

                Options.active = !sw;
                ReadButton.Text = !sw ? "Stop" : "Read";
            }
            if (Options.active) { Options.Token?.Cancel(); return; }
            Options.Token = new CancellationTokenSource();

            AfterStartReading(false);
            try { await Task.Run(() => StartReadingAsync()); } catch { }
            AfterStartReading(true);
        }
        private void GetSocketException(string message)
            => Invoke((MethodInvoker)(() => {
            ConnectClick(null, null);
            MessageBox.Show(message); 
            }));
        async private Task CellSetRegisterValue(object sender, DataGridViewCellEventArgs e)
        {
            Enum.TryParse(RegistersGrid[(int)CEnum.field, e.RowIndex].Value.ToString(), out REnum register);
            if (RegistersGrid[(int)CEnum.ReadWriteAO, e.RowIndex].Value is null) return;
            await semaphoreSlim.WaitAsync(Options.Token.Token);
            try
            {
                if (UInt16.TryParse(RegistersGrid[(int)CEnum.ReadWriteAO, e.RowIndex].Value.ToString(), out ushort value)
                    && await WriteRegister(register, value) == Reply.Ok) return;
                throw new Exception();
            }
            catch (SocketException ex) { GetSocketException(ex.Message); }
            catch { ToMessageStatus("Error transcieve"); RegistersGrid[(int)CEnum.ReadWriteAO, e.RowIndex].Value = ""; }
            finally { semaphoreSlim.Release(); }
        }
        async private Task StartReadingAsync()
        {
            using (ModbusProtocol modbus = new ModbusProtocol(Options.mainInterface)) 
            {
                modbus.ToReply += ToReplyStatus;
                do
                {
                    await semaphoreSlim.WaitAsync(Options.Token.Token);
                    try
                    {
                        byte[] cmdOut;
                        Tuple<byte[], Reply> reply;
                        if (x03ToolStrip.Checked && !Options.Token.IsCancellationRequested)
                        {
                            cmdOut = modbus.FormatModBusCMD((byte)ID.Value, ReadMB.ReadAO, 0, 7);
                            reply = await modbus.GetData(cmdOut);
                            ToMessageStatus($"ID:{ID.Value}, Command 0x03:");
                            if (reply != null && reply.Item2 == Reply.Ok) DataToGrid(reply.Item1, (int)CEnum.ReadWriteAO);
                        }
                        if (x04ToolStrip.Checked && !Options.Token.IsCancellationRequested)
                        {
                            cmdOut = modbus.FormatModBusCMD((byte)ID.Value, ReadMB.ReadAI, 0, 7);
                            reply = await modbus.GetData(cmdOut);
                            ToMessageStatus($"ID:{ID.Value}, Command 0x04:");
                            if (reply != null && reply.Item2 == Reply.Ok) DataToGrid(reply.Item1, (int)CEnum.ReadAI);
                        }
                    }
                    catch (SocketException ex) { GetSocketException(ex.Message); break; }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    finally { semaphoreSlim.Release(); }
                    await Task.Delay(repeatToolStrip.Checked ? (int)timeoutMB.Value : 10, Options.Token.Token);
                }
                while (!Options.Token.IsCancellationRequested && repeatToolStrip.Checked);
            }
            
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
            await semaphoreSlim.WaitAsync(Options.Token.Token);
            try
            {
                await MWriteRegisters(REnum.Year, new ushort[7]);
                await MWriteRegisters(REnum.Year, timeArray);
            }
            catch (SocketException ex) { GetSocketException(ex.Message); }
            catch { ToMessageStatus("Error transcieve"); }
            finally { semaphoreSlim.Release(); }
        }
    }
}
