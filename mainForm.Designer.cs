namespace MCS100_CPU_CODESYS
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripSerial = new System.Windows.Forms.ToolStrip();
            this.ClearConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataBits = new System.Windows.Forms.ToolStripDropDownButton();
            this.dataBits7 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBits8 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataBitsInfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.Parity = new System.Windows.Forms.ToolStripDropDownButton();
            this.ParityNone = new System.Windows.Forms.ToolStripMenuItem();
            this.ParityOdd = new System.Windows.Forms.ToolStripMenuItem();
            this.ParityEven = new System.Windows.Forms.ToolStripMenuItem();
            this.ParityMark = new System.Windows.Forms.ToolStripMenuItem();
            this.ParitySpace = new System.Windows.Forms.ToolStripMenuItem();
            this.ParityInfo = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.stopBits = new System.Windows.Forms.ToolStripDropDownButton();
            this.stopBits1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopBits2 = new System.Windows.Forms.ToolStripMenuItem();
            this.StopBitsInfo = new System.Windows.Forms.ToolStripLabel();
            this.GridClear = new System.Windows.Forms.ToolStripButton();
            this.SerUdpPages = new System.Windows.Forms.TabControl();
            this.RtuPage = new System.Windows.Forms.TabPage();
            this.comPort = new System.Windows.Forms.ComboBox();
            this.RefreshSerial = new System.Windows.Forms.Button();
            this.BaudRate = new System.Windows.Forms.ComboBox();
            this.OpenCom = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TcpPage = new System.Windows.Forms.TabPage();
            this.numericPort = new System.Windows.Forms.NumericUpDown();
            this.Connect = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.IPaddressBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.InfoStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.mbRtu = new System.IO.Ports.SerialPort(this.components);
            this.JustPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.timeoutMB = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.NumericUpDown();
            this.SyncTime = new System.Windows.Forms.Button();
            this.RegistersGrid = new System.Windows.Forms.DataGridView();
            this.EnabledColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadFieldColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadFieldColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateFromGrid = new System.Windows.Forms.Label();
            this.TimeFromGrid = new System.Windows.Forms.Label();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.autoRButton = new System.Windows.Forms.RadioButton();
            this.manualReadButton = new System.Windows.Forms.Button();
            this.manualRButton = new System.Windows.Forms.RadioButton();
            this.toolStripSerial.SuspendLayout();
            this.SerUdpPages.SuspendLayout();
            this.RtuPage.SuspendLayout();
            this.TcpPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.JustPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistersGrid)).BeginInit();
            this.SettingsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSerial
            // 
            this.toolStripSerial.AllowMerge = false;
            this.toolStripSerial.BackColor = System.Drawing.Color.White;
            this.toolStripSerial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripSerial.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripSerial.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearConfig,
            this.toolStripSeparator1,
            this.dataBits,
            this.dataBitsInfo,
            this.toolStripSeparator3,
            this.Parity,
            this.ParityInfo,
            this.toolStripSeparator5,
            this.stopBits,
            this.StopBitsInfo,
            this.GridClear});
            this.toolStripSerial.Location = new System.Drawing.Point(0, 0);
            this.toolStripSerial.Name = "toolStripSerial";
            this.toolStripSerial.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStripSerial.Size = new System.Drawing.Size(329, 25);
            this.toolStripSerial.TabIndex = 22;
            this.toolStripSerial.Text = "toolStrip1";
            // 
            // ClearConfig
            // 
            this.ClearConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ClearConfig.Image = global::MCS100_CPU_CODESYS.Properties.Resources.DeleteProperty;
            this.ClearConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearConfig.Name = "ClearConfig";
            this.ClearConfig.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ClearConfig.Size = new System.Drawing.Size(23, 22);
            this.ClearConfig.ToolTipText = "Back to default settings";
            this.ClearConfig.Click += new System.EventHandler(this.ClearConfig_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dataBits
            // 
            this.dataBits.AutoToolTip = false;
            this.dataBits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.dataBits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataBits7,
            this.dataBits8});
            this.dataBits.Image = ((System.Drawing.Image)(resources.GetObject("dataBits.Image")));
            this.dataBits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dataBits.Name = "dataBits";
            this.dataBits.ShowDropDownArrow = false;
            this.dataBits.Size = new System.Drawing.Size(57, 22);
            this.dataBits.Text = "Data Bits";
            // 
            // dataBits7
            // 
            this.dataBits7.Name = "dataBits7";
            this.dataBits7.Size = new System.Drawing.Size(80, 22);
            this.dataBits7.Text = "7";
            // 
            // dataBits8
            // 
            this.dataBits8.Name = "dataBits8";
            this.dataBits8.Size = new System.Drawing.Size(80, 22);
            this.dataBits8.Text = "8";
            // 
            // dataBitsInfo
            // 
            this.dataBitsInfo.Enabled = false;
            this.dataBitsInfo.Name = "dataBitsInfo";
            this.dataBitsInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // Parity
            // 
            this.Parity.AutoToolTip = false;
            this.Parity.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Parity.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParityNone,
            this.ParityOdd,
            this.ParityEven,
            this.ParityMark,
            this.ParitySpace});
            this.Parity.Image = ((System.Drawing.Image)(resources.GetObject("Parity.Image")));
            this.Parity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Parity.Name = "Parity";
            this.Parity.ShowDropDownArrow = false;
            this.Parity.Size = new System.Drawing.Size(41, 22);
            this.Parity.Text = "Parity";
            // 
            // ParityNone
            // 
            this.ParityNone.Name = "ParityNone";
            this.ParityNone.Size = new System.Drawing.Size(105, 22);
            this.ParityNone.Text = "None";
            // 
            // ParityOdd
            // 
            this.ParityOdd.Name = "ParityOdd";
            this.ParityOdd.Size = new System.Drawing.Size(105, 22);
            this.ParityOdd.Text = "Odd";
            // 
            // ParityEven
            // 
            this.ParityEven.Name = "ParityEven";
            this.ParityEven.Size = new System.Drawing.Size(105, 22);
            this.ParityEven.Text = "Even";
            // 
            // ParityMark
            // 
            this.ParityMark.Name = "ParityMark";
            this.ParityMark.Size = new System.Drawing.Size(105, 22);
            this.ParityMark.Text = "Mark";
            // 
            // ParitySpace
            // 
            this.ParitySpace.Name = "ParitySpace";
            this.ParitySpace.Size = new System.Drawing.Size(105, 22);
            this.ParitySpace.Text = "Space";
            // 
            // ParityInfo
            // 
            this.ParityInfo.Enabled = false;
            this.ParityInfo.Name = "ParityInfo";
            this.ParityInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // stopBits
            // 
            this.stopBits.AutoToolTip = false;
            this.stopBits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stopBits.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stopBits1,
            this.stopBits2});
            this.stopBits.Image = ((System.Drawing.Image)(resources.GetObject("stopBits.Image")));
            this.stopBits.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopBits.Name = "stopBits";
            this.stopBits.ShowDropDownArrow = false;
            this.stopBits.Size = new System.Drawing.Size(57, 22);
            this.stopBits.Text = "Stop Bits";
            // 
            // stopBits1
            // 
            this.stopBits1.Name = "stopBits1";
            this.stopBits1.Size = new System.Drawing.Size(80, 22);
            this.stopBits1.Text = "1";
            // 
            // stopBits2
            // 
            this.stopBits2.Name = "stopBits2";
            this.stopBits2.Size = new System.Drawing.Size(80, 22);
            this.stopBits2.Text = "2";
            // 
            // StopBitsInfo
            // 
            this.StopBitsInfo.Enabled = false;
            this.StopBitsInfo.Name = "StopBitsInfo";
            this.StopBitsInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // GridClear
            // 
            this.GridClear.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.GridClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GridClear.Image = global::MCS100_CPU_CODESYS.Properties.Resources.DeleteTable;
            this.GridClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GridClear.Name = "GridClear";
            this.GridClear.Size = new System.Drawing.Size(23, 22);
            this.GridClear.ToolTipText = "Data Clear";
            // 
            // SerUdpPages
            // 
            this.SerUdpPages.Controls.Add(this.RtuPage);
            this.SerUdpPages.Controls.Add(this.TcpPage);
            this.SerUdpPages.Location = new System.Drawing.Point(0, 25);
            this.SerUdpPages.Margin = new System.Windows.Forms.Padding(0);
            this.SerUdpPages.Multiline = true;
            this.SerUdpPages.Name = "SerUdpPages";
            this.SerUdpPages.SelectedIndex = 0;
            this.SerUdpPages.Size = new System.Drawing.Size(165, 148);
            this.SerUdpPages.TabIndex = 21;
            // 
            // RtuPage
            // 
            this.RtuPage.BackColor = System.Drawing.Color.White;
            this.RtuPage.Controls.Add(this.comPort);
            this.RtuPage.Controls.Add(this.RefreshSerial);
            this.RtuPage.Controls.Add(this.BaudRate);
            this.RtuPage.Controls.Add(this.OpenCom);
            this.RtuPage.Controls.Add(this.label10);
            this.RtuPage.Controls.Add(this.label11);
            this.RtuPage.Location = new System.Drawing.Point(4, 22);
            this.RtuPage.Name = "RtuPage";
            this.RtuPage.Padding = new System.Windows.Forms.Padding(3);
            this.RtuPage.Size = new System.Drawing.Size(157, 122);
            this.RtuPage.TabIndex = 0;
            this.RtuPage.Text = "RTU";
            // 
            // comPort
            // 
            this.comPort.FormattingEnabled = true;
            this.comPort.Location = new System.Drawing.Point(19, 26);
            this.comPort.Name = "comPort";
            this.comPort.Size = new System.Drawing.Size(121, 21);
            this.comPort.Sorted = true;
            this.comPort.TabIndex = 32;
            // 
            // RefreshSerial
            // 
            this.RefreshSerial.Location = new System.Drawing.Point(76, 7);
            this.RefreshSerial.Name = "RefreshSerial";
            this.RefreshSerial.Size = new System.Drawing.Size(65, 21);
            this.RefreshSerial.TabIndex = 43;
            this.RefreshSerial.Text = "Refresh";
            this.RefreshSerial.UseVisualStyleBackColor = true;
            // 
            // BaudRate
            // 
            this.BaudRate.FormattingEnabled = true;
            this.BaudRate.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.BaudRate.Location = new System.Drawing.Point(19, 66);
            this.BaudRate.MaxLength = 7;
            this.BaudRate.Name = "BaudRate";
            this.BaudRate.Size = new System.Drawing.Size(121, 21);
            this.BaudRate.TabIndex = 33;
            // 
            // OpenCom
            // 
            this.OpenCom.BackColor = System.Drawing.Color.Transparent;
            this.OpenCom.Location = new System.Drawing.Point(19, 93);
            this.OpenCom.Name = "OpenCom";
            this.OpenCom.Size = new System.Drawing.Size(121, 23);
            this.OpenCom.TabIndex = 42;
            this.OpenCom.Text = "Open";
            this.OpenCom.UseVisualStyleBackColor = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 36;
            this.label10.Text = "PortName";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 50);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "BaudRate";
            // 
            // TcpPage
            // 
            this.TcpPage.BackColor = System.Drawing.Color.White;
            this.TcpPage.Controls.Add(this.numericPort);
            this.TcpPage.Controls.Add(this.Connect);
            this.TcpPage.Controls.Add(this.label14);
            this.TcpPage.Controls.Add(this.label13);
            this.TcpPage.Controls.Add(this.IPaddressBox);
            this.TcpPage.Controls.Add(this.label16);
            this.TcpPage.Location = new System.Drawing.Point(4, 22);
            this.TcpPage.Name = "TcpPage";
            this.TcpPage.Padding = new System.Windows.Forms.Padding(3);
            this.TcpPage.Size = new System.Drawing.Size(157, 122);
            this.TcpPage.TabIndex = 1;
            this.TcpPage.Text = "TCP";
            // 
            // numericPort
            // 
            this.numericPort.Location = new System.Drawing.Point(102, 47);
            this.numericPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericPort.Name = "numericPort";
            this.numericPort.Size = new System.Drawing.Size(51, 20);
            this.numericPort.TabIndex = 29;
            this.numericPort.Value = new decimal(new int[] {
            502,
            0,
            0,
            0});
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(5, 69);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(149, 23);
            this.Connect.TabIndex = 29;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(26, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Port";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "IP address";
            // 
            // IPaddressBox
            // 
            this.IPaddressBox.Location = new System.Drawing.Point(6, 47);
            this.IPaddressBox.MaxLength = 15;
            this.IPaddressBox.Name = "IPaddressBox";
            this.IPaddressBox.Size = new System.Drawing.Size(88, 20);
            this.IPaddressBox.TabIndex = 0;
            this.IPaddressBox.Text = "192.168.1.50";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(94, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 31;
            this.label16.Text = ":";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.White;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.InfoStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 263);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(329, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 24;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel1.Text = "Info:";
            // 
            // InfoStatus
            // 
            this.InfoStatus.Name = "InfoStatus";
            this.InfoStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // JustPanel
            // 
            this.JustPanel.BackColor = System.Drawing.Color.White;
            this.JustPanel.Controls.Add(this.label2);
            this.JustPanel.Controls.Add(this.timeoutMB);
            this.JustPanel.Controls.Add(this.label1);
            this.JustPanel.Controls.Add(this.ID);
            this.JustPanel.Location = new System.Drawing.Point(0, 172);
            this.JustPanel.Name = "JustPanel";
            this.JustPanel.Size = new System.Drawing.Size(165, 45);
            this.JustPanel.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время опроса (мс):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timeoutMB
            // 
            this.timeoutMB.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.timeoutMB.Location = new System.Drawing.Point(118, 24);
            this.timeoutMB.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.timeoutMB.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.timeoutMB.Name = "timeoutMB";
            this.timeoutMB.Size = new System.Drawing.Size(45, 20);
            this.timeoutMB.TabIndex = 2;
            this.timeoutMB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.timeoutMB.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ID
            // 
            this.ID.Location = new System.Drawing.Point(118, 2);
            this.ID.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(45, 20);
            this.ID.TabIndex = 0;
            this.ID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SyncTime
            // 
            this.SyncTime.Location = new System.Drawing.Point(1, 23);
            this.SyncTime.Name = "SyncTime";
            this.SyncTime.Size = new System.Drawing.Size(163, 23);
            this.SyncTime.TabIndex = 4;
            this.SyncTime.Text = "Sync time";
            this.SyncTime.UseVisualStyleBackColor = true;
            // 
            // RegistersGrid
            // 
            this.RegistersGrid.AllowUserToAddRows = false;
            this.RegistersGrid.AllowUserToDeleteRows = false;
            this.RegistersGrid.AllowUserToResizeColumns = false;
            this.RegistersGrid.AllowUserToResizeRows = false;
            this.RegistersGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RegistersGrid.BackgroundColor = System.Drawing.Color.White;
            this.RegistersGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RegistersGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RegistersGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.RegistersGrid.ColumnHeadersHeight = 16;
            this.RegistersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EnabledColumn,
            this.FieldsColumn,
            this.LoadFieldColumn,
            this.UploadFieldColumn});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RegistersGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.RegistersGrid.Enabled = false;
            this.RegistersGrid.EnableHeadersVisualStyles = false;
            this.RegistersGrid.GridColor = System.Drawing.Color.Gray;
            this.RegistersGrid.Location = new System.Drawing.Point(166, 45);
            this.RegistersGrid.Margin = new System.Windows.Forms.Padding(0);
            this.RegistersGrid.MultiSelect = false;
            this.RegistersGrid.Name = "RegistersGrid";
            this.RegistersGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RegistersGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.RegistersGrid.RowHeadersVisible = false;
            this.RegistersGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.RegistersGrid.RowTemplate.Height = 19;
            this.RegistersGrid.Size = new System.Drawing.Size(162, 149);
            this.RegistersGrid.TabIndex = 26;
            this.RegistersGrid.TabStop = false;
            // 
            // EnabledColumn
            // 
            this.EnabledColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EnabledColumn.FillWeight = 20F;
            this.EnabledColumn.Frozen = true;
            this.EnabledColumn.HeaderText = "#";
            this.EnabledColumn.MinimumWidth = 20;
            this.EnabledColumn.Name = "EnabledColumn";
            this.EnabledColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EnabledColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.EnabledColumn.Width = 20;
            // 
            // FieldsColumn
            // 
            this.FieldsColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.FieldsColumn.Frozen = true;
            this.FieldsColumn.HeaderText = "Field";
            this.FieldsColumn.MaxInputLength = 16;
            this.FieldsColumn.Name = "FieldsColumn";
            this.FieldsColumn.ReadOnly = true;
            this.FieldsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FieldsColumn.Width = 34;
            // 
            // LoadFieldColumn
            // 
            this.LoadFieldColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LoadFieldColumn.Frozen = true;
            this.LoadFieldColumn.HeaderText = "Read";
            this.LoadFieldColumn.MaxInputLength = 16;
            this.LoadFieldColumn.Name = "LoadFieldColumn";
            this.LoadFieldColumn.ReadOnly = true;
            this.LoadFieldColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LoadFieldColumn.Width = 38;
            // 
            // UploadFieldColumn
            // 
            this.UploadFieldColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.UploadFieldColumn.HeaderText = "Write";
            this.UploadFieldColumn.MaxInputLength = 16;
            this.UploadFieldColumn.Name = "UploadFieldColumn";
            this.UploadFieldColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UploadFieldColumn.Width = 37;
            // 
            // DateFromGrid
            // 
            this.DateFromGrid.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DateFromGrid.Location = new System.Drawing.Point(168, 194);
            this.DateFromGrid.Margin = new System.Windows.Forms.Padding(0);
            this.DateFromGrid.Name = "DateFromGrid";
            this.DateFromGrid.Size = new System.Drawing.Size(132, 22);
            this.DateFromGrid.TabIndex = 27;
            this.DateFromGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TimeFromGrid
            // 
            this.TimeFromGrid.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeFromGrid.Location = new System.Drawing.Point(168, 216);
            this.TimeFromGrid.Margin = new System.Windows.Forms.Padding(0);
            this.TimeFromGrid.Name = "TimeFromGrid";
            this.TimeFromGrid.Size = new System.Drawing.Size(132, 22);
            this.TimeFromGrid.TabIndex = 28;
            this.TimeFromGrid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Controls.Add(this.SyncTime);
            this.SettingsPanel.Controls.Add(this.autoRButton);
            this.SettingsPanel.Controls.Add(this.manualReadButton);
            this.SettingsPanel.Controls.Add(this.manualRButton);
            this.SettingsPanel.Enabled = false;
            this.SettingsPanel.Location = new System.Drawing.Point(0, 217);
            this.SettingsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(165, 47);
            this.SettingsPanel.TabIndex = 30;
            // 
            // autoRButton
            // 
            this.autoRButton.AutoSize = true;
            this.autoRButton.Location = new System.Drawing.Point(4, 3);
            this.autoRButton.Name = "autoRButton";
            this.autoRButton.Size = new System.Drawing.Size(47, 17);
            this.autoRButton.TabIndex = 4;
            this.autoRButton.Text = "Auto";
            this.autoRButton.UseVisualStyleBackColor = true;
            // 
            // manualReadButton
            // 
            this.manualReadButton.Location = new System.Drawing.Point(117, 0);
            this.manualReadButton.Margin = new System.Windows.Forms.Padding(1);
            this.manualReadButton.Name = "manualReadButton";
            this.manualReadButton.Size = new System.Drawing.Size(47, 23);
            this.manualReadButton.TabIndex = 6;
            this.manualReadButton.Text = "Read";
            this.manualReadButton.UseVisualStyleBackColor = true;
            // 
            // manualRButton
            // 
            this.manualRButton.AutoSize = true;
            this.manualRButton.Checked = true;
            this.manualRButton.Location = new System.Drawing.Point(57, 3);
            this.manualRButton.Name = "manualRButton";
            this.manualRButton.Size = new System.Drawing.Size(60, 17);
            this.manualRButton.TabIndex = 5;
            this.manualRButton.TabStop = true;
            this.manualRButton.Text = "Manual";
            this.manualRButton.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(329, 285);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.TimeFromGrid);
            this.Controls.Add(this.DateFromGrid);
            this.Controls.Add(this.RegistersGrid);
            this.Controls.Add(this.JustPanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStripSerial);
            this.Controls.Add(this.SerUdpPages);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCS100-CPU";
            this.toolStripSerial.ResumeLayout(false);
            this.toolStripSerial.PerformLayout();
            this.SerUdpPages.ResumeLayout(false);
            this.RtuPage.ResumeLayout(false);
            this.RtuPage.PerformLayout();
            this.TcpPage.ResumeLayout(false);
            this.TcpPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericPort)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.JustPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.timeoutMB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegistersGrid)).EndInit();
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripSerial;
        private System.Windows.Forms.ToolStripDropDownButton dataBits;
        private System.Windows.Forms.ToolStripMenuItem dataBits7;
        private System.Windows.Forms.ToolStripMenuItem dataBits8;
        private System.Windows.Forms.ToolStripLabel dataBitsInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton Parity;
        private System.Windows.Forms.ToolStripMenuItem ParityNone;
        private System.Windows.Forms.ToolStripMenuItem ParityOdd;
        private System.Windows.Forms.ToolStripMenuItem ParityEven;
        private System.Windows.Forms.ToolStripMenuItem ParityMark;
        private System.Windows.Forms.ToolStripMenuItem ParitySpace;
        private System.Windows.Forms.ToolStripLabel ParityInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripDropDownButton stopBits;
        private System.Windows.Forms.ToolStripMenuItem stopBits1;
        private System.Windows.Forms.ToolStripMenuItem stopBits2;
        private System.Windows.Forms.ToolStripLabel StopBitsInfo;
        public System.Windows.Forms.TabControl SerUdpPages;
        private System.Windows.Forms.TabPage RtuPage;
        public System.Windows.Forms.ComboBox comPort;
        private System.Windows.Forms.Button RefreshSerial;
        public System.Windows.Forms.ComboBox BaudRate;
        private System.Windows.Forms.Button OpenCom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage TcpPage;
        public System.Windows.Forms.NumericUpDown numericPort;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox IPaddressBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel InfoStatus;
        private System.IO.Ports.SerialPort mbRtu;
        private System.Windows.Forms.Panel JustPanel;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown ID;
        private System.Windows.Forms.DataGridView RegistersGrid;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown timeoutMB;
        private System.Windows.Forms.Button SyncTime;
        private System.Windows.Forms.Label DateFromGrid;
        private System.Windows.Forms.Label TimeFromGrid;
        private System.Windows.Forms.ToolStripButton ClearConfig;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton GridClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn EnabledColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadFieldColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadFieldColumn;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.RadioButton autoRButton;
        private System.Windows.Forms.Button manualReadButton;
        private System.Windows.Forms.RadioButton manualRButton;
    }
}

