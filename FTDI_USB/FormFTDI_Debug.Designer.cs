using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

using FTD2XX_NET;






namespace FTDI_USB
{
    partial class FormFTDI_Debug
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
                this.FT245RDevice.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFTDI_Debug));
            this.buttonRecognize = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownBaudRate = new System.Windows.Forms.NumericUpDown();
            this.buttonClose = new System.Windows.Forms.Button();
            this.labelBaud = new System.Windows.Forms.Label();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_MessageInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControlContentZU32 = new System.Windows.Forms.TabControl();
            this.tabPageDebugUSB = new System.Windows.Forms.TabPage();
            this.progressBar_DebugUsb = new System.Windows.Forms.ProgressBar();
            this.groupBoxRecord = new System.Windows.Forms.GroupBox();
            this.comboBoxSendFile = new System.Windows.Forms.ComboBox();
            this.numericUpDownSendFile = new System.Windows.Forms.NumericUpDown();
            this.textBoxLoadFileName = new System.Windows.Forms.TextBox();
            this.buttonSendFile = new System.Windows.Forms.Button();
            this.groupBoxErase = new System.Windows.Forms.GroupBox();
            this.buttonEraseSector = new System.Windows.Forms.Button();
            this.radio_D12 = new System.Windows.Forms.RadioButton();
            this.radio_D21 = new System.Windows.Forms.RadioButton();
            this.groupBoxWork = new System.Windows.Forms.GroupBox();
            this.richTextBoxSendTestData = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRecvTestData = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.buttonDebugSend = new System.Windows.Forms.Button();
            this.DataBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CommandBox = new System.Windows.Forms.TextBox();
            this.tabPageSPI_ZU = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridViewK1_K4 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonK1_K4_Set = new System.Windows.Forms.Button();
            this.groupBoxContentZU = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_16bit = new System.Windows.Forms.TabPage();
            this.dataGridView_ContentZU = new System.Windows.Forms.DataGridView();
            this.ColumnNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTranslate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_32bit = new System.Windows.Forms.TabPage();
            this.dataGridView_ContentZU_32bit = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBarContentZU = new System.Windows.Forms.ProgressBar();
            this.numericUpDownDeepReading = new System.Windows.Forms.NumericUpDown();
            this.buttonRead_ZU_D21 = new System.Windows.Forms.Button();
            this.buttonRead_ZU_D12 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonSend_techMode = new System.Windows.Forms.Button();
            this.textBoxData_TechMode_ACP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSend_SPI_D21 = new System.Windows.Forms.Button();
            this.textBoxData_SPI_D21 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAddress_SPI_D21 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSend_SPI_D12 = new System.Windows.Forms.Button();
            this.textBoxData_SPI_D12 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAddress_SPI_D12 = new System.Windows.Forms.TextBox();
            this.tabPageOZU_D12 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonWriteToOZU_D12 = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonAssignEndAddressD12 = new System.Windows.Forms.Button();
            this.numericUpDownOZU_D12 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDeepReadingD12 = new System.Windows.Forms.NumericUpDown();
            this.progressBar_OZU_D12 = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_D12Hex = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownUntilD12 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFromD12 = new System.Windows.Forms.NumericUpDown();
            this.dataGridView_OZU_D12 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageOZU_D21 = new System.Windows.Forms.TabPage();
            this.dataGridView_OZU_D21 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_D21Hex = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.numericUpDownUntilD21 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownFromD21 = new System.Windows.Forms.NumericUpDown();
            this.buttonWriteToOZU_D21 = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.buttonAssignEndAddressD21 = new System.Windows.Forms.Button();
            this.numericUpDownOZU_D21 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDeepReadingD21 = new System.Windows.Forms.NumericUpDown();
            this.progressBar_OZU_D21 = new System.Windows.Forms.ProgressBar();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaudRate)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControlContentZU32.SuspendLayout();
            this.tabPageDebugUSB.SuspendLayout();
            this.groupBoxRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendFile)).BeginInit();
            this.groupBoxErase.SuspendLayout();
            this.groupBoxWork.SuspendLayout();
            this.tabPageSPI_ZU.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewK1_K4)).BeginInit();
            this.groupBoxContentZU.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_16bit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ContentZU)).BeginInit();
            this.tabPage_32bit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ContentZU_32bit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeepReading)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPageOZU_D12.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOZU_D12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeepReadingD12)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUntilD12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFromD12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OZU_D12)).BeginInit();
            this.tabPageOZU_D21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OZU_D21)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUntilD21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFromD21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOZU_D21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeepReadingD21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRecognize
            // 
            this.buttonRecognize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRecognize.Location = new System.Drawing.Point(18, 32);
            this.buttonRecognize.Name = "buttonRecognize";
            this.buttonRecognize.Size = new System.Drawing.Size(123, 33);
            this.buttonRecognize.TabIndex = 0;
            this.buttonRecognize.Text = "ОПРЕДЕЛИТЬ";
            this.toolTipHelp.SetToolTip(this.buttonRecognize, "Найти подключенные устройства FTDI");
            this.buttonRecognize.UseVisualStyleBackColor = true;
            this.buttonRecognize.Click += new System.EventHandler(this.buttonRecognize_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(266, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(40, 29);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(18, 215);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(100, 36);
            this.buttonOpen.TabIndex = 2;
            this.buttonOpen.Text = "ОТКРЫТЬ";
            this.toolTipHelp.SetToolTip(this.buttonOpen, "Открыть устройство для работы с ним");
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(237, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 29);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "1";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.numericUpDownBaudRate);
            this.groupBox1.Controls.Add(this.buttonClose);
            this.groupBox1.Controls.Add(this.labelBaud);
            this.groupBox1.Controls.Add(this.labelSpeed);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.buttonOpen);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.buttonRecognize);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 476);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ПОДКЛЮЧЕННЫЕ УСТРОЙСТВА FTDI";
            // 
            // numericUpDownBaudRate
            // 
            this.numericUpDownBaudRate.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownBaudRate.Location = new System.Drawing.Point(197, 257);
            this.numericUpDownBaudRate.Maximum = new decimal(new int[] {
            3000000,
            0,
            0,
            0});
            this.numericUpDownBaudRate.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numericUpDownBaudRate.Name = "numericUpDownBaudRate";
            this.numericUpDownBaudRate.Size = new System.Drawing.Size(87, 23);
            this.numericUpDownBaudRate.TabIndex = 13;
            this.numericUpDownBaudRate.ThousandsSeparator = true;
            this.numericUpDownBaudRate.Value = new decimal(new int[] {
            115200,
            0,
            0,
            0});
            this.numericUpDownBaudRate.ValueChanged += new System.EventHandler(this.numericUpDownBaudRate_ValueChanged);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(18, 257);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 36);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "ЗАКРЫТЬ";
            this.toolTipHelp.SetToolTip(this.buttonClose, "Закрыть подключенное устройство FTDI");
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // labelBaud
            // 
            this.labelBaud.AutoSize = true;
            this.labelBaud.Location = new System.Drawing.Point(283, 259);
            this.labelBaud.Name = "labelBaud";
            this.labelBaud.Size = new System.Drawing.Size(35, 17);
            this.labelBaud.TabIndex = 11;
            this.labelBaud.Text = "бод";
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(119, 259);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(82, 17);
            this.labelSpeed.TabIndex = 11;
            this.labelSpeed.Text = "Скорость:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "СТАТУС:";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Location = new System.Drawing.Point(207, 215);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 10;
            this.textBox5.Text = "ЗАКРЫТО";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button4
            // 
            this.button4.Image = global::FTDI_USB.Properties.Resources.DawnArrow;
            this.button4.Location = new System.Drawing.Point(281, 97);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(26, 23);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::FTDI_USB.Properties.Resources.UpArrow;
            this.button3.Location = new System.Drawing.Point(281, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(26, 23);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "СЕРИЙНЫЙ НОМЕР:";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.White;
            this.textBox4.Location = new System.Drawing.Point(185, 169);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(121, 23);
            this.textBox4.TabIndex = 4;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "ОПИСАНИЕ:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(123, 133);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(183, 23);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "ВЫБРАТЬ УСТРОЙСТВО:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(145, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "КОЛИЧЕСТВО:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CreatePrompt = true;
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_MessageInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 476);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(962, 22);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_MessageInfo
            // 
            this.toolStripStatusLabel_MessageInfo.Name = "toolStripStatusLabel_MessageInfo";
            this.toolStripStatusLabel_MessageInfo.Size = new System.Drawing.Size(12, 17);
            this.toolStripStatusLabel_MessageInfo.Text = "_";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1MinSize = 1;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlContentZU32);
            this.splitContainer1.Panel2MinSize = 400;
            this.splitContainer1.Size = new System.Drawing.Size(962, 476);
            this.splitContainer1.SplitterDistance = 316;
            this.splitContainer1.SplitterIncrement = 10;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 31;
            // 
            // tabControlContentZU32
            // 
            this.tabControlContentZU32.Controls.Add(this.tabPageDebugUSB);
            this.tabControlContentZU32.Controls.Add(this.tabPageSPI_ZU);
            this.tabControlContentZU32.Controls.Add(this.tabPageOZU_D12);
            this.tabControlContentZU32.Controls.Add(this.tabPageOZU_D21);
            this.tabControlContentZU32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlContentZU32.Location = new System.Drawing.Point(0, 0);
            this.tabControlContentZU32.Name = "tabControlContentZU32";
            this.tabControlContentZU32.SelectedIndex = 0;
            this.tabControlContentZU32.Size = new System.Drawing.Size(638, 476);
            this.tabControlContentZU32.TabIndex = 0;
            // 
            // tabPageDebugUSB
            // 
            this.tabPageDebugUSB.Controls.Add(this.progressBar_DebugUsb);
            this.tabPageDebugUSB.Controls.Add(this.groupBoxRecord);
            this.tabPageDebugUSB.Controls.Add(this.groupBoxErase);
            this.tabPageDebugUSB.Controls.Add(this.groupBoxWork);
            this.tabPageDebugUSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageDebugUSB.Location = new System.Drawing.Point(4, 22);
            this.tabPageDebugUSB.Name = "tabPageDebugUSB";
            this.tabPageDebugUSB.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDebugUSB.Size = new System.Drawing.Size(630, 450);
            this.tabPageDebugUSB.TabIndex = 0;
            this.tabPageDebugUSB.Text = "Отладка USB порта";
            this.tabPageDebugUSB.UseVisualStyleBackColor = true;
            // 
            // progressBar_DebugUsb
            // 
            this.progressBar_DebugUsb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar_DebugUsb.Location = new System.Drawing.Point(3, 424);
            this.progressBar_DebugUsb.Name = "progressBar_DebugUsb";
            this.progressBar_DebugUsb.Size = new System.Drawing.Size(624, 23);
            this.progressBar_DebugUsb.TabIndex = 46;
            // 
            // groupBoxRecord
            // 
            this.groupBoxRecord.Controls.Add(this.comboBoxSendFile);
            this.groupBoxRecord.Controls.Add(this.numericUpDownSendFile);
            this.groupBoxRecord.Controls.Add(this.textBoxLoadFileName);
            this.groupBoxRecord.Controls.Add(this.buttonSendFile);
            this.groupBoxRecord.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxRecord.Location = new System.Drawing.Point(3, 197);
            this.groupBoxRecord.Name = "groupBoxRecord";
            this.groupBoxRecord.Size = new System.Drawing.Size(624, 84);
            this.groupBoxRecord.TabIndex = 44;
            this.groupBoxRecord.TabStop = false;
            this.groupBoxRecord.Text = "Загрузка";
            // 
            // comboBoxSendFile
            // 
            this.comboBoxSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSendFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSendFile.FormattingEnabled = true;
            this.comboBoxSendFile.Items.AddRange(new object[] {
            "Б",
            "Кб",
            "Мб"});
            this.comboBoxSendFile.Location = new System.Drawing.Point(573, 51);
            this.comboBoxSendFile.Name = "comboBoxSendFile";
            this.comboBoxSendFile.Size = new System.Drawing.Size(47, 24);
            this.comboBoxSendFile.TabIndex = 36;
            this.toolTipHelp.SetToolTip(this.comboBoxSendFile, "Установить размер части передаваемого файла");
            this.comboBoxSendFile.SelectedIndexChanged += new System.EventHandler(this.comboBoxSendFile_SelectedIndexChanged);
            // 
            // numericUpDownSendFile
            // 
            this.numericUpDownSendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownSendFile.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSendFile.Location = new System.Drawing.Point(524, 52);
            this.numericUpDownSendFile.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownSendFile.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSendFile.Name = "numericUpDownSendFile";
            this.numericUpDownSendFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numericUpDownSendFile.Size = new System.Drawing.Size(43, 23);
            this.numericUpDownSendFile.TabIndex = 35;
            this.numericUpDownSendFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipHelp.SetToolTip(this.numericUpDownSendFile, "Установить размер части передаваемого файла");
            this.numericUpDownSendFile.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSendFile.ValueChanged += new System.EventHandler(this.numericUpDownSendFile_ValueChanged);
            // 
            // textBoxLoadFileName
            // 
            this.textBoxLoadFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLoadFileName.Location = new System.Drawing.Point(9, 52);
            this.textBoxLoadFileName.Name = "textBoxLoadFileName";
            this.textBoxLoadFileName.Size = new System.Drawing.Size(508, 23);
            this.textBoxLoadFileName.TabIndex = 33;
            this.toolTipHelp.SetToolTip(this.textBoxLoadFileName, "Выбрать файл или написать путь к нему для записи");
            this.textBoxLoadFileName.Click += new System.EventHandler(this.textBoxLoadFileName_Click);
            this.textBoxLoadFileName.TextChanged += new System.EventHandler(this.textBoxLoadFileName_TextChanged);
            this.textBoxLoadFileName.DoubleClick += new System.EventHandler(this.textBoxLoadFileName_DoubleClick);
            // 
            // buttonSendFile
            // 
            this.buttonSendFile.AutoSize = true;
            this.buttonSendFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonSendFile.Location = new System.Drawing.Point(9, 21);
            this.buttonSendFile.Name = "buttonSendFile";
            this.buttonSendFile.Size = new System.Drawing.Size(121, 27);
            this.buttonSendFile.TabIndex = 6;
            this.buttonSendFile.Text = "Передать файл";
            this.toolTipHelp.SetToolTip(this.buttonSendFile, "Начать  процесс записи файла");
            this.buttonSendFile.UseVisualStyleBackColor = true;
            this.buttonSendFile.Click += new System.EventHandler(this.buttonSendFile_Click);
            // 
            // groupBoxErase
            // 
            this.groupBoxErase.Controls.Add(this.buttonEraseSector);
            this.groupBoxErase.Controls.Add(this.radio_D12);
            this.groupBoxErase.Controls.Add(this.radio_D21);
            this.groupBoxErase.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxErase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxErase.Location = new System.Drawing.Point(3, 140);
            this.groupBoxErase.Name = "groupBoxErase";
            this.groupBoxErase.Size = new System.Drawing.Size(624, 57);
            this.groupBoxErase.TabIndex = 45;
            this.groupBoxErase.TabStop = false;
            this.groupBoxErase.Text = "Стирание";
            // 
            // buttonEraseSector
            // 
            this.buttonEraseSector.AutoSize = true;
            this.buttonEraseSector.Location = new System.Drawing.Point(9, 22);
            this.buttonEraseSector.Name = "buttonEraseSector";
            this.buttonEraseSector.Size = new System.Drawing.Size(137, 27);
            this.buttonEraseSector.TabIndex = 3;
            this.buttonEraseSector.Text = "Стереть сектор";
            this.toolTipHelp.SetToolTip(this.buttonEraseSector, "Запустить процесс стирания секторов на D12 или D21");
            this.buttonEraseSector.UseVisualStyleBackColor = true;
            this.buttonEraseSector.Click += new System.EventHandler(this.buttonEraseSector_Click);
            // 
            // radio_D12
            // 
            this.radio_D12.AutoSize = true;
            this.radio_D12.Checked = true;
            this.radio_D12.Location = new System.Drawing.Point(234, 25);
            this.radio_D12.Name = "radio_D12";
            this.radio_D12.Size = new System.Drawing.Size(52, 21);
            this.radio_D12.TabIndex = 4;
            this.radio_D12.TabStop = true;
            this.radio_D12.Text = "D12";
            this.radio_D12.UseVisualStyleBackColor = true;
            this.radio_D12.CheckedChanged += new System.EventHandler(this.radio_D12_CheckedChanged);
            // 
            // radio_D21
            // 
            this.radio_D21.AutoSize = true;
            this.radio_D21.Location = new System.Drawing.Point(290, 25);
            this.radio_D21.Name = "radio_D21";
            this.radio_D21.Size = new System.Drawing.Size(52, 21);
            this.radio_D21.TabIndex = 7;
            this.radio_D21.Text = "D21";
            this.radio_D21.UseVisualStyleBackColor = true;
            this.radio_D21.CheckedChanged += new System.EventHandler(this.radio_D21_CheckedChanged);
            // 
            // groupBoxWork
            // 
            this.groupBoxWork.Controls.Add(this.richTextBoxSendTestData);
            this.groupBoxWork.Controls.Add(this.richTextBoxRecvTestData);
            this.groupBoxWork.Controls.Add(this.label15);
            this.groupBoxWork.Controls.Add(this.label14);
            this.groupBoxWork.Controls.Add(this.buttonDebugSend);
            this.groupBoxWork.Controls.Add(this.DataBox);
            this.groupBoxWork.Controls.Add(this.label13);
            this.groupBoxWork.Controls.Add(this.label12);
            this.groupBoxWork.Controls.Add(this.CommandBox);
            this.groupBoxWork.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxWork.Location = new System.Drawing.Point(3, 3);
            this.groupBoxWork.Name = "groupBoxWork";
            this.groupBoxWork.Size = new System.Drawing.Size(624, 137);
            this.groupBoxWork.TabIndex = 43;
            this.groupBoxWork.TabStop = false;
            this.groupBoxWork.Text = "Отладка";
            // 
            // richTextBoxSendTestData
            // 
            this.richTextBoxSendTestData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxSendTestData.BackColor = System.Drawing.Color.White;
            this.richTextBoxSendTestData.Location = new System.Drawing.Point(34, 74);
            this.richTextBoxSendTestData.Multiline = false;
            this.richTextBoxSendTestData.Name = "richTextBoxSendTestData";
            this.richTextBoxSendTestData.ReadOnly = true;
            this.richTextBoxSendTestData.Size = new System.Drawing.Size(587, 21);
            this.richTextBoxSendTestData.TabIndex = 13;
            this.richTextBoxSendTestData.Text = "";
            // 
            // richTextBoxRecvTestData
            // 
            this.richTextBoxRecvTestData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxRecvTestData.BackColor = System.Drawing.Color.White;
            this.richTextBoxRecvTestData.Location = new System.Drawing.Point(34, 102);
            this.richTextBoxRecvTestData.Multiline = false;
            this.richTextBoxRecvTestData.Name = "richTextBoxRecvTestData";
            this.richTextBoxRecvTestData.ReadOnly = true;
            this.richTextBoxRecvTestData.Size = new System.Drawing.Size(830, 21);
            this.richTextBoxRecvTestData.TabIndex = 13;
            this.richTextBoxRecvTestData.Text = "";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Image = global::FTDI_USB.Properties.Resources.OK2;
            this.label15.Location = new System.Drawing.Point(5, 103);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 16);
            this.label15.TabIndex = 27;
            this.label15.Text = "     ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Image = global::FTDI_USB.Properties.Resources.comand;
            this.label14.Location = new System.Drawing.Point(5, 77);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 16);
            this.label14.TabIndex = 26;
            this.label14.Text = "     ";
            // 
            // buttonDebugSend
            // 
            this.buttonDebugSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDebugSend.AutoSize = true;
            this.buttonDebugSend.Location = new System.Drawing.Point(432, 21);
            this.buttonDebugSend.Name = "buttonDebugSend";
            this.buttonDebugSend.Size = new System.Drawing.Size(173, 39);
            this.buttonDebugSend.TabIndex = 10;
            this.buttonDebugSend.Text = "Послать";
            this.toolTipHelp.SetToolTip(this.buttonDebugSend, "Послать пакет, собранный из полей команды и данных");
            this.buttonDebugSend.UseVisualStyleBackColor = true;
            this.buttonDebugSend.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // DataBox
            // 
            this.DataBox.Location = new System.Drawing.Point(132, 38);
            this.DataBox.MaxLength = 4;
            this.DataBox.Name = "DataBox";
            this.DataBox.Size = new System.Drawing.Size(85, 22);
            this.DataBox.TabIndex = 9;
            this.DataBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(132, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "Данные";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "Команда";
            // 
            // CommandBox
            // 
            this.CommandBox.Location = new System.Drawing.Point(34, 38);
            this.CommandBox.MaxLength = 4;
            this.CommandBox.Name = "CommandBox";
            this.CommandBox.Size = new System.Drawing.Size(85, 22);
            this.CommandBox.TabIndex = 8;
            this.CommandBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipHelp.SetToolTip(this.CommandBox, "ввести код команды для тестовой отправки");
            // 
            // tabPageSPI_ZU
            // 
            this.tabPageSPI_ZU.Controls.Add(this.groupBox5);
            this.tabPageSPI_ZU.Controls.Add(this.groupBoxContentZU);
            this.tabPageSPI_ZU.Controls.Add(this.groupBox4);
            this.tabPageSPI_ZU.Controls.Add(this.groupBox3);
            this.tabPageSPI_ZU.Controls.Add(this.groupBox2);
            this.tabPageSPI_ZU.Location = new System.Drawing.Point(4, 22);
            this.tabPageSPI_ZU.Name = "tabPageSPI_ZU";
            this.tabPageSPI_ZU.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSPI_ZU.Size = new System.Drawing.Size(630, 450);
            this.tabPageSPI_ZU.TabIndex = 1;
            this.tabPageSPI_ZU.Text = "SPI - ЗУ";
            this.tabPageSPI_ZU.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewK1_K4);
            this.groupBox5.Controls.Add(this.buttonK1_K4_Set);
            this.groupBox5.Location = new System.Drawing.Point(285, 81);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(269, 100);
            this.groupBox5.TabIndex = 40;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "K1-K4";
            // 
            // dataGridViewK1_K4
            // 
            this.dataGridViewK1_K4.AllowUserToAddRows = false;
            this.dataGridViewK1_K4.AllowUserToDeleteRows = false;
            this.dataGridViewK1_K4.AllowUserToResizeColumns = false;
            this.dataGridViewK1_K4.AllowUserToResizeRows = false;
            this.dataGridViewK1_K4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewK1_K4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridViewK1_K4.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewK1_K4.Location = new System.Drawing.Point(10, 21);
            this.dataGridViewK1_K4.MultiSelect = false;
            this.dataGridViewK1_K4.Name = "dataGridViewK1_K4";
            this.dataGridViewK1_K4.RowHeadersWidth = 45;
            this.dataGridViewK1_K4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewK1_K4.Size = new System.Drawing.Size(165, 68);
            this.dataGridViewK1_K4.TabIndex = 11;
            this.dataGridViewK1_K4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewK1_K4_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "K1";
            this.Column1.Name = "Column1";
            this.Column1.Width = 26;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "K2";
            this.Column2.Name = "Column2";
            this.Column2.Width = 26;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.HeaderText = "K3";
            this.Column3.Name = "Column3";
            this.Column3.Width = 26;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.HeaderText = "K4";
            this.Column4.Name = "Column4";
            // 
            // buttonK1_K4_Set
            // 
            this.buttonK1_K4_Set.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonK1_K4_Set.AutoSize = true;
            this.buttonK1_K4_Set.Location = new System.Drawing.Point(181, 21);
            this.buttonK1_K4_Set.Name = "buttonK1_K4_Set";
            this.buttonK1_K4_Set.Size = new System.Drawing.Size(73, 39);
            this.buttonK1_K4_Set.TabIndex = 10;
            this.buttonK1_K4_Set.Text = "Уст.";
            this.buttonK1_K4_Set.UseVisualStyleBackColor = true;
            this.buttonK1_K4_Set.Click += new System.EventHandler(this.buttonK1_K4_Set_Click);
            // 
            // groupBoxContentZU
            // 
            this.groupBoxContentZU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxContentZU.Controls.Add(this.tabControl1);
            this.groupBoxContentZU.Controls.Add(this.progressBarContentZU);
            this.groupBoxContentZU.Controls.Add(this.numericUpDownDeepReading);
            this.groupBoxContentZU.Controls.Add(this.buttonRead_ZU_D21);
            this.groupBoxContentZU.Controls.Add(this.buttonRead_ZU_D12);
            this.groupBoxContentZU.Controls.Add(this.label11);
            this.groupBoxContentZU.Location = new System.Drawing.Point(3, 187);
            this.groupBoxContentZU.Name = "groupBoxContentZU";
            this.groupBoxContentZU.Size = new System.Drawing.Size(621, 256);
            this.groupBoxContentZU.TabIndex = 40;
            this.groupBoxContentZU.TabStop = false;
            this.groupBoxContentZU.Text = "Содержимое ЗУ";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage_16bit);
            this.tabControl1.Controls.Add(this.tabPage_32bit);
            this.tabControl1.Location = new System.Drawing.Point(6, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(413, 221);
            this.tabControl1.TabIndex = 41;
            // 
            // tabPage_16bit
            // 
            this.tabPage_16bit.Controls.Add(this.dataGridView_ContentZU);
            this.tabPage_16bit.Location = new System.Drawing.Point(4, 22);
            this.tabPage_16bit.Name = "tabPage_16bit";
            this.tabPage_16bit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_16bit.Size = new System.Drawing.Size(405, 195);
            this.tabPage_16bit.TabIndex = 0;
            this.tabPage_16bit.Text = "16 bit";
            this.tabPage_16bit.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ContentZU
            // 
            this.dataGridView_ContentZU.AllowUserToAddRows = false;
            this.dataGridView_ContentZU.AllowUserToDeleteRows = false;
            this.dataGridView_ContentZU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_ContentZU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ContentZU.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNumber,
            this.ColumnData,
            this.ColumnTranslate});
            this.dataGridView_ContentZU.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_ContentZU.Name = "dataGridView_ContentZU";
            this.dataGridView_ContentZU.ReadOnly = true;
            this.dataGridView_ContentZU.RowHeadersVisible = false;
            this.dataGridView_ContentZU.Size = new System.Drawing.Size(399, 189);
            this.dataGridView_ContentZU.TabIndex = 11;
            // 
            // ColumnNumber
            // 
            this.ColumnNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnNumber.HeaderText = "№";
            this.ColumnNumber.Name = "ColumnNumber";
            this.ColumnNumber.ReadOnly = true;
            this.ColumnNumber.Width = 43;
            // 
            // ColumnData
            // 
            this.ColumnData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnData.HeaderText = "Данные";
            this.ColumnData.MinimumWidth = 100;
            this.ColumnData.Name = "ColumnData";
            this.ColumnData.ReadOnly = true;
            // 
            // ColumnTranslate
            // 
            this.ColumnTranslate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ColumnTranslate.HeaderText = "Перевод";
            this.ColumnTranslate.Name = "ColumnTranslate";
            this.ColumnTranslate.ReadOnly = true;
            this.ColumnTranslate.Width = 76;
            // 
            // tabPage_32bit
            // 
            this.tabPage_32bit.Controls.Add(this.dataGridView_ContentZU_32bit);
            this.tabPage_32bit.Location = new System.Drawing.Point(4, 22);
            this.tabPage_32bit.Name = "tabPage_32bit";
            this.tabPage_32bit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_32bit.Size = new System.Drawing.Size(390, 198);
            this.tabPage_32bit.TabIndex = 1;
            this.tabPage_32bit.Text = "32 bit";
            this.tabPage_32bit.UseVisualStyleBackColor = true;
            // 
            // dataGridView_ContentZU_32bit
            // 
            this.dataGridView_ContentZU_32bit.AllowUserToAddRows = false;
            this.dataGridView_ContentZU_32bit.AllowUserToDeleteRows = false;
            this.dataGridView_ContentZU_32bit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ContentZU_32bit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView_ContentZU_32bit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ContentZU_32bit.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_ContentZU_32bit.Name = "dataGridView_ContentZU_32bit";
            this.dataGridView_ContentZU_32bit.ReadOnly = true;
            this.dataGridView_ContentZU_32bit.RowHeadersVisible = false;
            this.dataGridView_ContentZU_32bit.Size = new System.Drawing.Size(384, 192);
            this.dataGridView_ContentZU_32bit.TabIndex = 12;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.HeaderText = "Данные (32 - hex)";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Данные (32)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // progressBarContentZU
            // 
            this.progressBarContentZU.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarContentZU.Location = new System.Drawing.Point(446, 215);
            this.progressBarContentZU.Name = "progressBarContentZU";
            this.progressBarContentZU.Size = new System.Drawing.Size(169, 25);
            this.progressBarContentZU.TabIndex = 13;
            // 
            // numericUpDownDeepReading
            // 
            this.numericUpDownDeepReading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownDeepReading.Location = new System.Drawing.Point(552, 13);
            this.numericUpDownDeepReading.Maximum = new decimal(new int[] {
            4500,
            0,
            0,
            0});
            this.numericUpDownDeepReading.Name = "numericUpDownDeepReading";
            this.numericUpDownDeepReading.Size = new System.Drawing.Size(63, 20);
            this.numericUpDownDeepReading.TabIndex = 12;
            this.toolTipHelp.SetToolTip(this.numericUpDownDeepReading, "Установите глубину чтения содержимого ЗУ");
            this.numericUpDownDeepReading.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // buttonRead_ZU_D21
            // 
            this.buttonRead_ZU_D21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRead_ZU_D21.AutoSize = true;
            this.buttonRead_ZU_D21.Location = new System.Drawing.Point(478, 100);
            this.buttonRead_ZU_D21.Name = "buttonRead_ZU_D21";
            this.buttonRead_ZU_D21.Size = new System.Drawing.Size(137, 49);
            this.buttonRead_ZU_D21.TabIndex = 10;
            this.buttonRead_ZU_D21.Text = "Прочитать содержимое\r\nЗУ - D21";
            this.buttonRead_ZU_D21.UseVisualStyleBackColor = true;
            this.buttonRead_ZU_D21.Click += new System.EventHandler(this.buttonRead_ZU_D21_Click);
            // 
            // buttonRead_ZU_D12
            // 
            this.buttonRead_ZU_D12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRead_ZU_D12.AutoSize = true;
            this.buttonRead_ZU_D12.Location = new System.Drawing.Point(478, 45);
            this.buttonRead_ZU_D12.Name = "buttonRead_ZU_D12";
            this.buttonRead_ZU_D12.Size = new System.Drawing.Size(137, 49);
            this.buttonRead_ZU_D12.TabIndex = 10;
            this.buttonRead_ZU_D12.Text = "Прочитать содержимое\r\nЗУ - D12";
            this.buttonRead_ZU_D12.UseVisualStyleBackColor = true;
            this.buttonRead_ZU_D12.Click += new System.EventHandler(this.buttonRead_ZU_D12_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(453, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Глубина чтения";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonSend_techMode);
            this.groupBox4.Controls.Add(this.textBoxData_TechMode_ACP);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(285, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 71);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Тех. режим АЦП";
            // 
            // buttonSend_techMode
            // 
            this.buttonSend_techMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend_techMode.AutoSize = true;
            this.buttonSend_techMode.Location = new System.Drawing.Point(159, 21);
            this.buttonSend_techMode.Name = "buttonSend_techMode";
            this.buttonSend_techMode.Size = new System.Drawing.Size(95, 39);
            this.buttonSend_techMode.TabIndex = 10;
            this.buttonSend_techMode.Text = "Послать";
            this.buttonSend_techMode.UseVisualStyleBackColor = true;
            this.buttonSend_techMode.Click += new System.EventHandler(this.buttonSend_techMode_Click);
            // 
            // textBoxData_TechMode_ACP
            // 
            this.textBoxData_TechMode_ACP.Location = new System.Drawing.Point(24, 39);
            this.textBoxData_TechMode_ACP.MaxLength = 4;
            this.textBoxData_TechMode_ACP.Name = "textBoxData_TechMode_ACP";
            this.textBoxData_TechMode_ACP.Size = new System.Drawing.Size(119, 20);
            this.textBoxData_TechMode_ACP.TabIndex = 9;
            this.textBoxData_TechMode_ACP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipHelp.SetToolTip(this.textBoxData_TechMode_ACP, "ввести данные для отправки");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Данные";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSend_SPI_D21);
            this.groupBox3.Controls.Add(this.textBoxData_SPI_D21);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxAddress_SPI_D21);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(3, 95);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(276, 86);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SPI D1-D21";
            // 
            // buttonSend_SPI_D21
            // 
            this.buttonSend_SPI_D21.AutoSize = true;
            this.buttonSend_SPI_D21.Location = new System.Drawing.Point(194, 21);
            this.buttonSend_SPI_D21.Name = "buttonSend_SPI_D21";
            this.buttonSend_SPI_D21.Size = new System.Drawing.Size(73, 39);
            this.buttonSend_SPI_D21.TabIndex = 10;
            this.buttonSend_SPI_D21.Text = "Послать";
            this.toolTipHelp.SetToolTip(this.buttonSend_SPI_D21, "Послать пакет, собранный из полей команды и данных");
            this.buttonSend_SPI_D21.UseVisualStyleBackColor = true;
            this.buttonSend_SPI_D21.Click += new System.EventHandler(this.buttonSend_SPI_D21_Click);
            // 
            // textBoxData_SPI_D21
            // 
            this.textBoxData_SPI_D21.Location = new System.Drawing.Point(103, 38);
            this.textBoxData_SPI_D21.MaxLength = 4;
            this.textBoxData_SPI_D21.Name = "textBoxData_SPI_D21";
            this.textBoxData_SPI_D21.Size = new System.Drawing.Size(85, 22);
            this.textBoxData_SPI_D21.TabIndex = 9;
            this.textBoxData_SPI_D21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipHelp.SetToolTip(this.textBoxData_SPI_D21, "ввести данные для отправки");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Данные";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Адрес";
            // 
            // textBoxAddress_SPI_D21
            // 
            this.textBoxAddress_SPI_D21.Location = new System.Drawing.Point(9, 38);
            this.textBoxAddress_SPI_D21.MaxLength = 4;
            this.textBoxAddress_SPI_D21.Name = "textBoxAddress_SPI_D21";
            this.textBoxAddress_SPI_D21.Size = new System.Drawing.Size(85, 22);
            this.textBoxAddress_SPI_D21.TabIndex = 8;
            this.textBoxAddress_SPI_D21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipHelp.SetToolTip(this.textBoxAddress_SPI_D21, "ввести адрес для отправки");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSend_SPI_D12);
            this.groupBox2.Controls.Add(this.textBoxData_SPI_D12);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textBoxAddress_SPI_D12);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(276, 86);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SPI D1-D12";
            // 
            // buttonSend_SPI_D12
            // 
            this.buttonSend_SPI_D12.AutoSize = true;
            this.buttonSend_SPI_D12.Location = new System.Drawing.Point(194, 21);
            this.buttonSend_SPI_D12.Name = "buttonSend_SPI_D12";
            this.buttonSend_SPI_D12.Size = new System.Drawing.Size(73, 39);
            this.buttonSend_SPI_D12.TabIndex = 10;
            this.buttonSend_SPI_D12.Text = "Послать";
            this.toolTipHelp.SetToolTip(this.buttonSend_SPI_D12, "Послать пакет, собранный из полей команды и данных");
            this.buttonSend_SPI_D12.UseVisualStyleBackColor = true;
            this.buttonSend_SPI_D12.Click += new System.EventHandler(this.buttonSend_SPI_D12_Click);
            // 
            // textBoxData_SPI_D12
            // 
            this.textBoxData_SPI_D12.Location = new System.Drawing.Point(103, 38);
            this.textBoxData_SPI_D12.MaxLength = 4;
            this.textBoxData_SPI_D12.Name = "textBoxData_SPI_D12";
            this.textBoxData_SPI_D12.Size = new System.Drawing.Size(85, 22);
            this.textBoxData_SPI_D12.TabIndex = 9;
            this.textBoxData_SPI_D12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipHelp.SetToolTip(this.textBoxData_SPI_D12, "ввести данные для отправки");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(103, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Данные";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 9;
            this.label9.Text = "Адрес";
            // 
            // textBoxAddress_SPI_D12
            // 
            this.textBoxAddress_SPI_D12.Location = new System.Drawing.Point(9, 38);
            this.textBoxAddress_SPI_D12.MaxLength = 4;
            this.textBoxAddress_SPI_D12.Name = "textBoxAddress_SPI_D12";
            this.textBoxAddress_SPI_D12.Size = new System.Drawing.Size(85, 22);
            this.textBoxAddress_SPI_D12.TabIndex = 8;
            this.textBoxAddress_SPI_D12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTipHelp.SetToolTip(this.textBoxAddress_SPI_D12, "ввести адрес для отправки");
            // 
            // tabPageOZU_D12
            // 
            this.tabPageOZU_D12.Controls.Add(this.tableLayoutPanel1);
            this.tabPageOZU_D12.Controls.Add(this.dataGridView_OZU_D12);
            this.tabPageOZU_D12.Location = new System.Drawing.Point(4, 22);
            this.tabPageOZU_D12.Name = "tabPageOZU_D12";
            this.tabPageOZU_D12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOZU_D12.Size = new System.Drawing.Size(630, 450);
            this.tabPageOZU_D12.TabIndex = 4;
            this.tabPageOZU_D12.Text = "ОЗУ D12";
            this.tabPageOZU_D12.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.buttonWriteToOZU_D12, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAssignEndAddressD12, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownOZU_D12, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDownDeepReadingD12, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_OZU_D12, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 370);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 77);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // buttonWriteToOZU_D12
            // 
            this.buttonWriteToOZU_D12.Location = new System.Drawing.Point(185, 3);
            this.buttonWriteToOZU_D12.Name = "buttonWriteToOZU_D12";
            this.buttonWriteToOZU_D12.Size = new System.Drawing.Size(132, 23);
            this.buttonWriteToOZU_D12.TabIndex = 12;
            this.buttonWriteToOZU_D12.Text = "Записать в ОЗУ D12";
            this.buttonWriteToOZU_D12.UseVisualStyleBackColor = true;
            this.buttonWriteToOZU_D12.Click += new System.EventHandler(this.buttonWriteToOZU_D12_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label16.Size = new System.Drawing.Size(106, 21);
            this.label16.TabIndex = 10;
            this.label16.Text = "Значение по умолч.";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 38);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label17.Size = new System.Drawing.Size(85, 21);
            this.label17.TabIndex = 10;
            this.label17.Text = "Глубина чтения";
            // 
            // buttonAssignEndAddressD12
            // 
            this.buttonAssignEndAddressD12.Location = new System.Drawing.Point(185, 41);
            this.buttonAssignEndAddressD12.Name = "buttonAssignEndAddressD12";
            this.buttonAssignEndAddressD12.Size = new System.Drawing.Size(89, 23);
            this.buttonAssignEndAddressD12.TabIndex = 12;
            this.buttonAssignEndAddressD12.Text = "Задать";
            this.buttonAssignEndAddressD12.UseVisualStyleBackColor = true;
            this.buttonAssignEndAddressD12.Click += new System.EventHandler(this.buttonAssignEndAddressD12_Click);
            // 
            // numericUpDownOZU_D12
            // 
            this.numericUpDownOZU_D12.Hexadecimal = true;
            this.numericUpDownOZU_D12.Location = new System.Drawing.Point(115, 3);
            this.numericUpDownOZU_D12.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownOZU_D12.Name = "numericUpDownOZU_D12";
            this.numericUpDownOZU_D12.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownOZU_D12.TabIndex = 13;
            this.numericUpDownOZU_D12.Value = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            // 
            // numericUpDownDeepReadingD12
            // 
            this.numericUpDownDeepReadingD12.Location = new System.Drawing.Point(115, 41);
            this.numericUpDownDeepReadingD12.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownDeepReadingD12.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDeepReadingD12.Name = "numericUpDownDeepReadingD12";
            this.numericUpDownDeepReadingD12.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownDeepReadingD12.TabIndex = 14;
            this.numericUpDownDeepReadingD12.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // progressBar_OZU_D12
            // 
            this.progressBar_OZU_D12.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_OZU_D12.Location = new System.Drawing.Point(324, 3);
            this.progressBar_OZU_D12.Name = "progressBar_OZU_D12";
            this.progressBar_OZU_D12.Size = new System.Drawing.Size(297, 23);
            this.progressBar_OZU_D12.TabIndex = 15;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox_D12Hex);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.numericUpDownUntilD12);
            this.panel1.Controls.Add(this.numericUpDownFromD12);
            this.panel1.Location = new System.Drawing.Point(324, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 33);
            this.panel1.TabIndex = 16;
            // 
            // checkBox_D12Hex
            // 
            this.checkBox_D12Hex.AutoSize = true;
            this.checkBox_D12Hex.Checked = true;
            this.checkBox_D12Hex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_D12Hex.Location = new System.Drawing.Point(219, 2);
            this.checkBox_D12Hex.Name = "checkBox_D12Hex";
            this.checkBox_D12Hex.Size = new System.Drawing.Size(45, 17);
            this.checkBox_D12Hex.TabIndex = 16;
            this.checkBox_D12Hex.Text = "Hex";
            this.checkBox_D12Hex.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(115, 3);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(25, 13);
            this.label22.TabIndex = 10;
            this.label22.Text = "До:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(3, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 13);
            this.label18.TabIndex = 10;
            this.label18.Text = "От:";
            // 
            // numericUpDownUntilD12
            // 
            this.numericUpDownUntilD12.Hexadecimal = true;
            this.numericUpDownUntilD12.Location = new System.Drawing.Point(146, 0);
            this.numericUpDownUntilD12.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.numericUpDownUntilD12.Name = "numericUpDownUntilD12";
            this.numericUpDownUntilD12.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownUntilD12.TabIndex = 14;
            this.numericUpDownUntilD12.Value = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            // 
            // numericUpDownFromD12
            // 
            this.numericUpDownFromD12.Hexadecimal = true;
            this.numericUpDownFromD12.Location = new System.Drawing.Point(32, 0);
            this.numericUpDownFromD12.Maximum = new decimal(new int[] {
            2046,
            0,
            0,
            0});
            this.numericUpDownFromD12.Name = "numericUpDownFromD12";
            this.numericUpDownFromD12.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownFromD12.TabIndex = 14;
            // 
            // dataGridView_OZU_D12
            // 
            this.dataGridView_OZU_D12.AllowUserToAddRows = false;
            this.dataGridView_OZU_D12.AllowUserToResizeColumns = false;
            this.dataGridView_OZU_D12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_OZU_D12.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_OZU_D12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_OZU_D12.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_OZU_D12.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_OZU_D12.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn24,
            this.dataGridViewTextBoxColumn25,
            this.dataGridViewTextBoxColumn26,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35});
            this.dataGridView_OZU_D12.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView_OZU_D12.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_OZU_D12.MultiSelect = false;
            this.dataGridView_OZU_D12.Name = "dataGridView_OZU_D12";
            this.dataGridView_OZU_D12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_OZU_D12.RowHeadersWidth = 58;
            this.dataGridView_OZU_D12.RowTemplate.Height = 24;
            this.dataGridView_OZU_D12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_OZU_D12.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_OZU_D12.Size = new System.Drawing.Size(634, 362);
            this.dataGridView_OZU_D12.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "00";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "01";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "02";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "03";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.HeaderText = "04";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.HeaderText = "05";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.HeaderText = "06";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.HeaderText = "07";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.HeaderText = "08";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.HeaderText = "09";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.HeaderText = "0A";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.HeaderText = "0B";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.HeaderText = "0C";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.HeaderText = "0D";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.HeaderText = "0E";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.HeaderText = "0F";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPageOZU_D21
            // 
            this.tabPageOZU_D21.Controls.Add(this.dataGridView_OZU_D21);
            this.tabPageOZU_D21.Controls.Add(this.tableLayoutPanel3);
            this.tabPageOZU_D21.Location = new System.Drawing.Point(4, 22);
            this.tabPageOZU_D21.Name = "tabPageOZU_D21";
            this.tabPageOZU_D21.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOZU_D21.Size = new System.Drawing.Size(630, 450);
            this.tabPageOZU_D21.TabIndex = 5;
            this.tabPageOZU_D21.Text = "ОЗУ D21";
            this.tabPageOZU_D21.UseVisualStyleBackColor = true;
            // 
            // dataGridView_OZU_D21
            // 
            this.dataGridView_OZU_D21.AllowUserToAddRows = false;
            this.dataGridView_OZU_D21.AllowUserToResizeColumns = false;
            this.dataGridView_OZU_D21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_OZU_D21.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_OZU_D21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_OZU_D21.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView_OZU_D21.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView_OZU_D21.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39,
            this.dataGridViewTextBoxColumn40,
            this.dataGridViewTextBoxColumn41,
            this.dataGridViewTextBoxColumn42,
            this.dataGridViewTextBoxColumn43,
            this.dataGridViewTextBoxColumn44,
            this.dataGridViewTextBoxColumn45,
            this.dataGridViewTextBoxColumn46,
            this.dataGridViewTextBoxColumn47,
            this.dataGridViewTextBoxColumn48,
            this.dataGridViewTextBoxColumn49,
            this.dataGridViewTextBoxColumn50,
            this.dataGridViewTextBoxColumn51});
            this.dataGridView_OZU_D21.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridView_OZU_D21.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView_OZU_D21.MultiSelect = false;
            this.dataGridView_OZU_D21.Name = "dataGridView_OZU_D21";
            this.dataGridView_OZU_D21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView_OZU_D21.RowHeadersWidth = 58;
            this.dataGridView_OZU_D21.RowTemplate.Height = 24;
            this.dataGridView_OZU_D21.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_OZU_D21.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_OZU_D21.Size = new System.Drawing.Size(635, 362);
            this.dataGridView_OZU_D21.TabIndex = 14;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.HeaderText = "00";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.HeaderText = "01";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.HeaderText = "02";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.HeaderText = "03";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.HeaderText = "04";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.HeaderText = "05";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.HeaderText = "06";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.HeaderText = "07";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.HeaderText = "08";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.HeaderText = "09";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.HeaderText = "0A";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.HeaderText = "0B";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.HeaderText = "0C";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.HeaderText = "0D";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.HeaderText = "0E";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.HeaderText = "0F";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonWriteToOZU_D21, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label20, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label21, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.buttonAssignEndAddressD21, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownOZU_D21, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.numericUpDownDeepReadingD21, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.progressBar_OZU_D21, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 370);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(624, 77);
            this.tableLayoutPanel3.TabIndex = 13;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox_D21Hex);
            this.panel2.Controls.Add(this.label19);
            this.panel2.Controls.Add(this.label23);
            this.panel2.Controls.Add(this.numericUpDownUntilD21);
            this.panel2.Controls.Add(this.numericUpDownFromD21);
            this.panel2.Location = new System.Drawing.Point(324, 41);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 33);
            this.panel2.TabIndex = 17;
            // 
            // checkBox_D21Hex
            // 
            this.checkBox_D21Hex.AutoSize = true;
            this.checkBox_D21Hex.Checked = true;
            this.checkBox_D21Hex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_D21Hex.Location = new System.Drawing.Point(219, 2);
            this.checkBox_D21Hex.Name = "checkBox_D21Hex";
            this.checkBox_D21Hex.Size = new System.Drawing.Size(45, 17);
            this.checkBox_D21Hex.TabIndex = 15;
            this.checkBox_D21Hex.Text = "Hex";
            this.checkBox_D21Hex.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(115, 3);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "До:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 13);
            this.label23.TabIndex = 10;
            this.label23.Text = "От:";
            // 
            // numericUpDownUntilD21
            // 
            this.numericUpDownUntilD21.Hexadecimal = true;
            this.numericUpDownUntilD21.Location = new System.Drawing.Point(146, 0);
            this.numericUpDownUntilD21.Maximum = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            this.numericUpDownUntilD21.Name = "numericUpDownUntilD21";
            this.numericUpDownUntilD21.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownUntilD21.TabIndex = 14;
            this.numericUpDownUntilD21.Value = new decimal(new int[] {
            2047,
            0,
            0,
            0});
            // 
            // numericUpDownFromD21
            // 
            this.numericUpDownFromD21.Hexadecimal = true;
            this.numericUpDownFromD21.Location = new System.Drawing.Point(32, 0);
            this.numericUpDownFromD21.Maximum = new decimal(new int[] {
            2046,
            0,
            0,
            0});
            this.numericUpDownFromD21.Name = "numericUpDownFromD21";
            this.numericUpDownFromD21.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownFromD21.TabIndex = 14;
            // 
            // buttonWriteToOZU_D21
            // 
            this.buttonWriteToOZU_D21.Location = new System.Drawing.Point(185, 3);
            this.buttonWriteToOZU_D21.Name = "buttonWriteToOZU_D21";
            this.buttonWriteToOZU_D21.Size = new System.Drawing.Size(132, 23);
            this.buttonWriteToOZU_D21.TabIndex = 12;
            this.buttonWriteToOZU_D21.Text = "Записать в ОЗУ D21";
            this.buttonWriteToOZU_D21.UseVisualStyleBackColor = true;
            this.buttonWriteToOZU_D21.Click += new System.EventHandler(this.buttonWriteToOZU_D21_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 0);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label20.Size = new System.Drawing.Size(106, 21);
            this.label20.TabIndex = 10;
            this.label20.Text = "Значение по умолч.";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(3, 38);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.label21.Size = new System.Drawing.Size(85, 21);
            this.label21.TabIndex = 10;
            this.label21.Text = "Глубина чтения";
            // 
            // buttonAssignEndAddressD21
            // 
            this.buttonAssignEndAddressD21.Location = new System.Drawing.Point(185, 41);
            this.buttonAssignEndAddressD21.Name = "buttonAssignEndAddressD21";
            this.buttonAssignEndAddressD21.Size = new System.Drawing.Size(89, 23);
            this.buttonAssignEndAddressD21.TabIndex = 12;
            this.buttonAssignEndAddressD21.Text = "Задать";
            this.buttonAssignEndAddressD21.UseVisualStyleBackColor = true;
            this.buttonAssignEndAddressD21.Click += new System.EventHandler(this.buttonAssignEndAddressD21_Click);
            // 
            // numericUpDownOZU_D21
            // 
            this.numericUpDownOZU_D21.Hexadecimal = true;
            this.numericUpDownOZU_D21.Location = new System.Drawing.Point(115, 3);
            this.numericUpDownOZU_D21.Maximum = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            this.numericUpDownOZU_D21.Name = "numericUpDownOZU_D21";
            this.numericUpDownOZU_D21.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownOZU_D21.TabIndex = 13;
            this.numericUpDownOZU_D21.Value = new decimal(new int[] {
            16383,
            0,
            0,
            0});
            // 
            // numericUpDownDeepReadingD21
            // 
            this.numericUpDownDeepReadingD21.Location = new System.Drawing.Point(115, 41);
            this.numericUpDownDeepReadingD21.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownDeepReadingD21.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownDeepReadingD21.Name = "numericUpDownDeepReadingD21";
            this.numericUpDownDeepReadingD21.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownDeepReadingD21.TabIndex = 14;
            this.numericUpDownDeepReadingD21.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // progressBar_OZU_D21
            // 
            this.progressBar_OZU_D21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar_OZU_D21.Location = new System.Drawing.Point(324, 3);
            this.progressBar_OZU_D21.Name = "progressBar_OZU_D21";
            this.progressBar_OZU_D21.Size = new System.Drawing.Size(297, 23);
            this.progressBar_OZU_D21.TabIndex = 15;
            // 
            // toolTipHelp
            // 
            this.toolTipHelp.AutomaticDelay = 0;
            this.toolTipHelp.IsBalloon = true;
            this.toolTipHelp.UseAnimation = false;
            this.toolTipHelp.UseFading = false;
            // 
            // FormFTDI_Debug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 498);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(756, 387);
            this.Name = "FormFTDI_Debug";
            this.Text = "Управление МЦЗВР v2.2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.FormFTDI_Debug_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBaudRate)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControlContentZU32.ResumeLayout(false);
            this.tabPageDebugUSB.ResumeLayout(false);
            this.groupBoxRecord.ResumeLayout(false);
            this.groupBoxRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSendFile)).EndInit();
            this.groupBoxErase.ResumeLayout(false);
            this.groupBoxErase.PerformLayout();
            this.groupBoxWork.ResumeLayout(false);
            this.groupBoxWork.PerformLayout();
            this.tabPageSPI_ZU.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewK1_K4)).EndInit();
            this.groupBoxContentZU.ResumeLayout(false);
            this.groupBoxContentZU.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_16bit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ContentZU)).EndInit();
            this.tabPage_32bit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ContentZU_32bit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeepReading)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPageOZU_D12.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOZU_D12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeepReadingD12)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUntilD12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFromD12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OZU_D12)).EndInit();
            this.tabPageOZU_D21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_OZU_D21)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUntilD21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFromD21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOZU_D21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeepReadingD21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonRecognize;
        private TextBox textBox1;
        private Button buttonOpen;
        private TextBox textBox2;
        private GroupBox groupBox1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button4;
        private Button button3;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label5;
        private TextBox textBox5;
        private Button buttonClose;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        private SplitContainer splitContainer1;
        private ToolStripStatusLabel toolStripStatusLabel_MessageInfo;
        private StatusStrip statusStrip1;
        private ToolTip toolTipHelp;
        private NumericUpDown numericUpDownBaudRate;
        private Label labelBaud;
        private Label labelSpeed;
        private TabControl tabControlContentZU32;
        private TabPage tabPageDebugUSB;
        private TabPage tabPageSPI_ZU;
        private GroupBox groupBox2;
        private Button buttonSend_SPI_D12;
        private TextBox textBoxData_SPI_D12;
        private Label label8;
        private Label label9;
        private TextBox textBoxAddress_SPI_D12;
        private GroupBox groupBox5;
        private Button buttonK1_K4_Set;
        private GroupBox groupBox4;
        private Button buttonSend_techMode;
        private TextBox textBoxData_TechMode_ACP;
        private GroupBox groupBox3;
        private Button buttonSend_SPI_D21;
        private TextBox textBoxData_SPI_D21;
        private Label label6;
        private Label label7;
        private TextBox textBoxAddress_SPI_D21;
        private GroupBox groupBoxContentZU;
        private NumericUpDown numericUpDownDeepReading;
        private DataGridView dataGridView_ContentZU;
        private DataGridViewTextBoxColumn ColumnNumber;
        private DataGridViewTextBoxColumn ColumnData;
        private DataGridViewTextBoxColumn ColumnTranslate;
        private Button buttonRead_ZU_D21;
        private Button buttonRead_ZU_D12;
        private Label label11;
        private DataGridView dataGridViewK1_K4;
        private DataGridViewCheckBoxColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewCheckBoxColumn Column3;
        private DataGridViewCheckBoxColumn Column4;
        private ProgressBar progressBar_DebugUsb;
        private GroupBox groupBoxRecord;
        private ComboBox comboBoxSendFile;
        private NumericUpDown numericUpDownSendFile;
        private TextBox textBoxLoadFileName;
        private Button buttonSendFile;
        private GroupBox groupBoxErase;
        private Button buttonEraseSector;
        private RadioButton radio_D12;
        private RadioButton radio_D21;
        private GroupBox groupBoxWork;
        private RichTextBox richTextBoxSendTestData;
        private RichTextBox richTextBoxRecvTestData;
        private Label label15;
        private Label label14;
        private Button buttonDebugSend;
        private TextBox DataBox;
        private Label label13;
        private Label label12;
        private TextBox CommandBox;
        private Label label10;
        private ProgressBar progressBarContentZU;
        private BindingSource bindingSource1;
        private TabControl tabControl1;
        private TabPage tabPage_16bit;
        private TabPage tabPage_32bit;
        private DataGridView dataGridView_ContentZU_32bit;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private TabPage tabPageOZU_D12;
        private DataGridView dataGridView_OZU_D12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private TabPage tabPageOZU_D21;
        private DataGridView dataGridView_OZU_D21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private TableLayoutPanel tableLayoutPanel3;
        private Button buttonWriteToOZU_D21;
        private Label label20;
        private Label label21;
        private Button buttonAssignEndAddressD21;
        private NumericUpDown numericUpDownOZU_D21;
        private NumericUpDown numericUpDownDeepReadingD21;
        private ProgressBar progressBar_OZU_D21;
        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonWriteToOZU_D12;
        private Label label16;
        private Label label17;
        private Button buttonAssignEndAddressD12;
        private NumericUpDown numericUpDownOZU_D12;
        private NumericUpDown numericUpDownDeepReadingD12;
        private ProgressBar progressBar_OZU_D12;
        private Panel panel1;
        private Label label22;
        private Label label18;
        private NumericUpDown numericUpDownUntilD12;
        private NumericUpDown numericUpDownFromD12;
        private Panel panel2;
        private Label label19;
        private Label label23;
        private NumericUpDown numericUpDownUntilD21;
        private NumericUpDown numericUpDownFromD21;
        private CheckBox checkBox_D21Hex;
        private CheckBox checkBox_D12Hex;
    }
}

