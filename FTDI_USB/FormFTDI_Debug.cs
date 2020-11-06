using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using FTD2XX_NET;
using FTDI_USB.ManagePLIS;
using FTDI_USB.Workers.PacketWorkers;
using FTDI_USB.Workers;
using DebugToolsLib;
using FTDI_USB.Properties;
using Timer = System.Windows.Forms.Timer;
using DebugToolsLib.WinFormControl;
using FTDI_USB.SPI;

namespace FTDI_USB
{
    public partial class FormFTDI_Debug : Form
    {
        FTDI_Manager FT245RDevice;
        EraseSectorWorker eraseSectorWorker = new EraseSectorWorker();
        SendFileWorker sendFileWorker = new SendFileWorker();
        ReadZUWorker readZUWorker = new ReadZUWorker();
        WriteOZUWorker writeOzuWorker = new WriteOZUWorker();
        TableManager tableManager = new TableManager();
        ManagerSPI managerSPI;

        FormErrorDialog formDialog;

        public FormFTDI_Debug()
        {
            try
            {
                FT245RDevice = new FTDI_Manager();
                managerSPI = new ManagerSPI(FT245RDevice);
                managerSPI.OutputMsgSent += (sender, args) => OutputRecvMessages(richTextBoxSendTestData, args.Data);
            }
            catch (FtdiException ex)
            {
                formDialog = new FormErrorDialog(ex.Message, "Ошибка загрузки драйвера FTD2XX.DLL");
                formDialog.FormClosing += FormErrorDialog_FormClosing;

                this.Hide();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;

                formDialog.Show();
                return;
            }

            InitializeComponent();

            InitForm();

            InitDataGridViewK1_K4();

            MessageCLI.Debug("--- Apllication start -- ");
        }

        private void InitDataGridViewK1_K4()
        {
            dataGridViewK1_K4.Rows.Add(true, true, true, true);
            dataGridViewK1_K4.Rows.Add(false, false, false, false);
            dataGridViewK1_K4.Rows[0].HeaderCell.Value = "Р";
            dataGridViewK1_K4.Rows[1].HeaderCell.Value = "П";
        }

        private void InitForm()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;

            buttonOpen.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            buttonClose.Enabled = false;
            numericUpDownBaudRate.Enabled = false;

            label1.Enabled = false;
            label2.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            labelBaud.Enabled = false;
            labelSpeed.Enabled = false;

            tabControlContentZU32.Enabled = false;

            initEventBindings();
            comboBoxSendFile.SelectedIndex = 2;
            SetBaudRate();

            setNameBtnSendFile();
            setNameBtnEraseSector();

            InitTab_OZU_D1x();
        }

        private void InitTab_OZU_D1x()
        {
            dataGridView_OZU_D12.CellParsing += tableManager.DataGrid_HexCellParsing;
            dataGridView_OZU_D21.CellParsing += tableManager.DataGrid_HexCellParsing;

            dataGridView_OZU_D12.CellFormatting += tableManager.DataGrid_HexCellFormattingDefault;
            dataGridView_OZU_D21.CellFormatting += tableManager.DataGrid_HexCellFormattingDefault;

            numericUpDownOZU_D12.ValueChanged += ValueChangedD12;
            numericUpDownFromD12.ValueChanged += ValueRangeChangedD12;
            numericUpDownFromD12.KeyUp += ValueRangeChangedD12;
            numericUpDownUntilD12.KeyUp += ValueRangeChangedD12;
            numericUpDownUntilD12.ValueChanged += ValueRangeChangedD12;

            numericUpDownOZU_D21.ValueChanged += ValueChangedD21;
            numericUpDownFromD21.KeyUp += ValueRangeChangedD21;
            numericUpDownFromD21.ValueChanged += ValueRangeChangedD21;
            numericUpDownUntilD21.KeyUp += ValueRangeChangedD21;
            numericUpDownUntilD21.ValueChanged += ValueRangeChangedD21;

            TableManager.DataGridFill(dataGridView_OZU_D12, progressBar_OZU_D12);
            TableManager.DataGridFill(dataGridView_OZU_D21, progressBar_OZU_D21);

            checkBox_D12Hex.CheckStateChanged += (sender, args) =>
                numericUpDownFromD12.Hexadecimal = numericUpDownUntilD12.Hexadecimal = ((CheckBox) sender).Checked;

            checkBox_D21Hex.CheckStateChanged += (sender, args) =>
                numericUpDownFromD21.Hexadecimal = numericUpDownUntilD21.Hexadecimal = ((CheckBox) sender).Checked;
            

            numericUpDownOZU_D12.Value = 0;
            numericUpDownOZU_D21.Value = 0;
        }

        private void FormErrorDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            IsListenTestPacket = false;
            IsStartSendFile = false;
            IsStartSectorErase = false;
            this.Close();
        }

        private void ValueRangeChangedD12(object sender, EventArgs e)
        {
            TableManager.InitRangeCells(dataGridView_OZU_D12, (uint) numericUpDownFromD12.Value,
                (uint) numericUpDownUntilD12.Value);
        }

        private void ValueChangedD12(object sender, EventArgs e)
        {
            TableManager.InitCells(dataGridView_OZU_D12, (UInt16)numericUpDownOZU_D12.Value);
        }

        private void ValueRangeChangedD21(object sender, EventArgs e)
        {
            TableManager.InitRangeCells(dataGridView_OZU_D21, (uint) numericUpDownFromD21.Value,
                (uint) numericUpDownUntilD21.Value);
        }
        private void ValueChangedD21(object sender, EventArgs e)
        {
            TableManager.InitCells(dataGridView_OZU_D21, (UInt16)numericUpDownOZU_D21.Value);
        }

        private bool isOpenDevice = false;
        private bool IsOpenDevice
        {
            set
            {
                isOpenDevice = value;
                tabControlContentZU32.Enabled = value;
                buttonOpen.Enabled = !value;
                buttonClose.Enabled = value;
                numericUpDownBaudRate.Enabled = value;
                labelBaud.Enabled = value;
                labelSpeed.Enabled = value;
                if (!value)
                    IsListenTestPacket = false;
            }
            get { return isOpenDevice; }
        }


        public bool IsListenTestPacket
        {
            get { return _isListenTestPacket; }
            set
            {
                if (value)
                {
                    _isListenTestPacket = FT245RDevice.StartReadAsync(12);
                    StartDebugSend();
                }
                else
                {
                    _isListenTestPacket = !FT245RDevice.StopReadAsync();
                    StopDebugSend();
                }
            }
        }

        public bool IsStartSectorErase
        {
            get { return isStartSectorErase; }
            set
            {
                isStartSectorErase = value;
                if (isStartSectorErase)
                {
                    toolStripStatusLabel_MessageInfo.Text = "Подготовка к стиранию секторов ...";
                    if (!FT245RDevice.IsReadServerRunning)
                        // Start process erasing of sectors in background thread
                        if (eraseSectorWorker.RunWorkerAsync(FT245RDevice, radio_D12.Checked))
                        {
                            radio_D12.Enabled = radio_D21.Enabled = false;
                            EnabledGroupBox(tabPageDebugUSB, groupBoxErase, false);
                            setNameBtnEraseSector(false);
                        }
                }
                else
                {
                    if (eraseSectorWorker.IsBusy)
                        eraseSectorWorker.CancelAsync();
                    else
                    {
                        radio_D12.Enabled = radio_D21.Enabled = true;
                        EnabledGroupBox(tabPageDebugUSB, groupBoxErase, true);
                        progressBar_DebugUsb.Value = 0;
                        setNameBtnEraseSector();
                    }
                }
            }
        }

        private string getFileName(string pathFile)
        {
            var f = new FileInfo(pathFile);
            return f.Name;
        }

        private bool isStartSendFile = false;
        private bool isStartSectorErase = false;

        public bool IsStartSendFile
        {
            get { return isStartSendFile; }
            set
            {
                isStartSendFile = value;
                if (isStartSendFile)
                {
                    toolStripStatusLabel_MessageInfo.Text = "Подготовка к передаче файла ...";
                    if (!FT245RDevice.IsReadServerRunning)
                        // Start process erasing of sectors in background thread
                        using (BinaryReader reader = new BinaryReader(File.Open(textBoxLoadFileName.Text, FileMode.Open)))
                        {
                            int arrayLengs = (int)reader.BaseStream.Length;
                            reader.BaseStream.Position = 0;
                            byte[] fileToSend = reader.ReadBytes(arrayLengs);

                            if (sendFileWorker.RunWorkerAsync(FT245RDevice, fileToSend, radio_D12.Checked))
                            {
                                textBoxLoadFileName.Enabled = false;
                                EnabledGroupBox(tabPageDebugUSB, groupBoxRecord, false);
                                setNameBtnSendFile(false);
                                sendFileWorker.SetPriority();
                            }
                        }
                }
                else
                {
                    if (sendFileWorker.IsBusy)
                    {
                        sendFileWorker.CancelAsync();
                        IsAbortSendFile = true;
                    }
                    else
                    {
                        _timerWaitCancelSendFile.Stop();
                        EnabledGroupBox(tabPageDebugUSB, groupBoxRecord, true);
                        textBoxLoadFileName.Enabled = true;
                        progressBar_DebugUsb.Value = 0;
                        setNameBtnSendFile();
                        buttonSendFile.Enabled = true;
                    }
                }
            }
        }

        private Timer _timerWaitCancelSendFile = new Timer(); 
        private bool IsAbortSendFile
        {
            get { return _isForceCancelSendFile; }
            set
            {
                _isForceCancelSendFile = value;
                if (_isForceCancelSendFile)
                {
                    _timerWaitCancelSendFile.Interval = 2000;
                    buttonSendFile.Enabled = false;
                    _timerWaitCancelSendFile.Enabled = false;
                    _timerWaitCancelSendFile.Start();
                }
                else
                {
                    _timerWaitCancelSendFile.Stop();
                    if (sendFileWorker.IsBusy)
                        sendFileWorker.Abort();
                    buttonSendFile.Enabled = true;
                }
            }
        }

        private void setNameBtnSendFile(bool isSendTo = true)
        {
            string nameButton;
            string helpText;
            try
            {
                nameButton = string.Format("{0}: \"{1}\" ({2})",
                    isSendTo
                        ? Resources.FormTestFTDI_buttonSendFile_Click_Передать_файл
                        : Resources.FormTestFTDI_buttonSendFile_Click_Отмена_передачи,
                    getFileName(textBoxLoadFileName.Text), radio_D12.Checked ? "D12" : "D21");
            }
            catch (Exception)
            {
                nameButton = string.Format("{0} ({1})",
                    isSendTo
                        ? Resources.FormTestFTDI_buttonSendFile_Click_Передать_файл
                        : Resources.FormTestFTDI_buttonSendFile_Click_Отмена_передачи,
                    radio_D12.Checked ? "D12" : "D21");
            }
            finally
            {
                helpText = string.Format("{0}",
                    isSendTo ? "Начать  процесс записи файла" : "Отменить процесс передачи файла");
            }

            buttonSendFile.Text = nameButton;
            toolTipHelp.SetToolTip(buttonSendFile, helpText);
        }
        private void setNameBtnEraseSector(bool isSendTo = true)
        {
            var nameButton = string.Format("{0} ({1})",
                isSendTo
                    ? Resources.FormFTDI_Debug_IsStartSectorErase_Стереть_сектор
                    : Resources.FormFTDI_Debug_IsStartSectorErase_Отмена_стирания,
                radio_D12.Checked ? "D12" : "D21");
            buttonEraseSector.Text = nameButton;
        }

        private Timer _timerShowDebugSend = new Timer();
        private Stopwatch _stopwatchShowDebugSend = new Stopwatch();

        private void StartDebugSend()
        {
            _timerShowDebugSend.Interval = 500;
            _stopwatchShowDebugSend.Restart();
            _timerShowDebugSend.Start();
            _timerShowDebugSend_Tick(null, EventArgs.Empty);
        }

        private void StopDebugSend()
        {
            if(!_timerShowDebugSend.Enabled)
                return;
            
            _timerShowDebugSend.Stop();
            _stopwatchShowDebugSend.Stop();
        }

        private void EnabledGroupBox(TabPage containerGB, GroupBox exceptGB, bool isEnabled)
        {
            foreach (GroupBox groupBox in containerGB.Controls.OfType<GroupBox>())
            {
                if (!groupBox.Equals(exceptGB))
                    groupBox.Enabled = isEnabled;
            }
        }

        private bool _isListenTestPacket = false;
        private bool _isForceCancelSendFile;

        #region SendFile

        private long GetSizePartFile()
        {
            var sizePartFile = (long)numericUpDownSendFile.Value;
            for (int i = 0; i < comboBoxSendFile.SelectedIndex; i++)
                sizePartFile *= 1024;

            return sizePartFile;
        }

        private void SetSizePartFile()
        {
            sendFileWorker.LenBuffer = GetSizePartFile();
        }

        private void numericUpDownSendFile_ValueChanged(object sender, EventArgs e)
        {
            SetSizePartFile();
        }

        private void comboBoxSendFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSizePartFile();
        }

        #endregion

        private Packet OutputRecvMessages(RichTextBox rtb, byte[] dataBytes)
        {
            rtb.Clear();
            var packet = Packet.Parse(dataBytes);
            var indexCode = packet.IndexCode;
            var indexData = packet.IndexData;
            for (int i = 0; i < dataBytes.Length; ++i)
            {
                if (indexCode.Key <= i && i < indexCode.Key + indexCode.Value)
                    rtb.AppendText(" " + $"{dataBytes[i]:X2}", Color.Blue);
                else if (indexData.Key <= i && i < indexData.Key + indexData.Value)
                    rtb.AppendText(" " + $"{dataBytes[i]:X2}", Color.Red);
                else
                    rtb.AppendText(" " + $"{dataBytes[i]:X2}", Color.Black);
            }
            return packet;
        }

        private void buttonRecognize_Click(object sender, EventArgs e)
        {
            try
            {
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = FT245RDevice.DeviceList;
                textBox1.Text = ftdiDeviceList.Length.ToString();
                UInt32 index = 0;
                index = UInt32.Parse(textBox2.Text) - 1;
                if (UInt32.Parse(textBox1.Text) != 0)
                {
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    buttonOpen.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    label1.Enabled = true;
                    label2.Enabled = true;
                    label3.Enabled = true;
                    label4.Enabled = true;
                    label5.Enabled = true;

                    textBox3.Text = ftdiDeviceList[index].Description;
                    textBox4.Text = ftdiDeviceList[index].SerialNumber;
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel_MessageInfo.Text = ex.Message;
                MessageCLI.PrintInDialog("Невозможно определить список FTDI устройств. Возможно они не подключены.",
                    "Ошибка определения подключенного устройства");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var n = UInt32.Parse(textBox2.Text);
            if (n < UInt32.Parse(textBox1.Text))
            {
                ++n;
                textBox2.Text = n.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var n = UInt32.Parse(textBox2.Text);
            if (n > 1)
            {
                --n;
                textBox2.Text = n.ToString();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = FT245RDevice.DeviceList;
                UInt32 i = UInt32.Parse(textBox2.Text) - 1;

                textBox3.Text = ftdiDeviceList[i].Description;
                textBox4.Text = ftdiDeviceList[i].SerialNumber;
            }
            catch(Exception ex) { MessageCLI.PrintInDialog(ex.Message, "Ошибка определения списка устройств"); }
        }


        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = FT245RDevice.DeviceList;
                UInt32 i = UInt32.Parse(textBox2.Text) - 1;

                if (FT245RDevice.OpenBySerialNumber(ftdiDeviceList[i].SerialNumber, (uint) numericUpDownBaudRate.Value, 2000, 3000))
                {
                    textBox5.Text = "ОТКРЫТО";
                    textBox5.BackColor = Color.LightGreen;
                    buttonClose.Enabled = true;
                    IsOpenDevice = true;
                }
            }
            catch (Exception ex) { MessageCLI.PrintInDialog(ex.Message, "Ошибка открытия устройства"); }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (FT245RDevice.Close())
            {
                textBox5.Text = "ЗАКРЫТО";
                textBox5.BackColor = Color.White;
                IsOpenDevice = false;
            }
        }

        private bool CheckField(string text, out uint value, string errorStrField)
        {
            try
            {
                value = uint.Parse(text, System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                MessageBox.Show(this, "Неверный формат " + errorStrField, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                MessageCLI.Error("Неверный формат " + errorStrField);
                value = 0;
                return false;
            }
            return true;
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            uint packetCmd, packetData;
            MessageCLI.Debug("Send Test Packet");

            if (!CheckField(CommandBox.Text, out packetCmd, "команды")) return;
            if (!CheckField(DataBox.Text, out packetData, "данных")) return;
            
            try
            {
                richTextBoxRecvTestData.Clear();
                IsListenTestPacket = true;
                managerSPI.SendData(packetCmd, packetData);
            }
            catch (Exception ex)
            { MessageCLI.PrintInDialog(ex.Message, "Ошибка записи/чтения из устройства"); }
        }


        private void initEventBindings()
        {
            FT245RDevice.RecvBytes += FT245RDevice_RecvBytesAsync;
            FT245RDevice.ListenRecvStopped += FT245RDevice_ListenRecvStopped;
            _timerShowDebugSend.Tick += _timerShowDebugSend_Tick;
            _timerWaitCancelSendFile.Tick += TimerWaitCancelSendFile_Tick;

            eraseSectorWorker.RunWorkerCompleted += EraseSectorWorker_RunWorkerCompleted;
            eraseSectorWorker.ProgressChanged += EraseSectorWorker_ProgressChanged;

            sendFileWorker.RunWorkerCompleted += SendFileWorker_RunWorkerCompleted;
            sendFileWorker.ProgressChanged += SendFileWorker_ProgressChanged;

            readZUWorker.RunWorkerCompleted += ReadZUWorker_RunWorkerCompleted;
            readZUWorker.ProgressChanged += ReadZUWorker_ProgressChanged;

            writeOzuWorker.RunWorkerCompleted += WriteOzuWorker_RunWorkerCompleted;
            writeOzuWorker.ProgressChanged += WriteOzuWorker_ProgressChanged;
        }

        private void WriteOzuWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var stateWriteOzu = (WriteOZUWorker.StateWriteOZU)e.UserState;
            var progressBar = stateWriteOzu.IsD12? progressBar_OZU_D12: progressBar_OZU_D21;
            progressBar.Value = e.ProgressPercentage;
            toolStripStatusLabel_MessageInfo.Text = stateWriteOzu.Message;
            var grid = stateWriteOzu.IsD12 ? dataGridView_OZU_D12 : dataGridView_OZU_D21;
            TableManager.InitLoadsCells(grid, stateWriteOzu.IndexFrom, stateWriteOzu.IndexLoad);
            MessageCLI.Debug(stateWriteOzu.Message);
        }

        private void WriteOzuWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                var text = "Процесс записи в ОЗУ был отменен";
                toolStripStatusLabel_MessageInfo.Text = text;
                MessageCLI.Debug(text);
            }
            else if (e.Error != null)
            {
                // Ошибка была сгенерирована обработчиком события DoWork
                MessageCLI.PrintInDialog(e.Error.Message, "Произошла ошибка записи в ОЗУ");
            }
            var stateWriteOZU = (WriteOZUWorker.StateWriteOZU) e.Result;   
            toolStripStatusLabel_MessageInfo.Text = stateWriteOZU.Message;
            var progressbar = stateWriteOZU.IsD12? progressBar_OZU_D12:progressBar_OZU_D21;
            progressbar.Value = 0;

            if (stateWriteOZU.IsD12) ValueRangeChangedD12(sender, e);
            else ValueRangeChangedD21(sender, e);

            //EnabledGroupBox(tabPageSPI_ZU, groupBoxContentZU, true);
        }

        private uint _countLines = 0;
        private uint _countLines_32bit = 0;
        private UInt16 _dataLowZU = 0;
        private void ReadZUWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarContentZU.Value = e.ProgressPercentage;
            var stateReadingZu = (ReadZUWorker.StateReadingZU) e.UserState;
            toolStripStatusLabel_MessageInfo.Text = stateReadingZu.message;
            if (stateReadingZu.isDataExist)
            {
                dataGridView_ContentZU.Rows.Add(_countLines++, stateReadingZu.DataToHexStr(),
                    stateReadingZu.TranslateData());
                if (_countLines % 2 == 0)
                {
                    var data = ReadZUWorker.CastUnt16To32(_dataLowZU, stateReadingZu.data[0]);
                    dataGridView_ContentZU_32bit.Rows.Add(_countLines_32bit++,
                        $"{data:X8}", data.ToString());
                }
                else
                    _dataLowZU = stateReadingZu.data[0];
            }
            MessageCLI.Debug(stateReadingZu.message);
        }

        private void ReadZUWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                var text = "Процесс чтения ЗУ был отменен";
                toolStripStatusLabel_MessageInfo.Text = text;
                MessageCLI.Debug(text);
            }
            else if (e.Error != null)
            {
                // Ошибка была сгенерирована обработчиком события DoWork
                MessageCLI.PrintInDialog(e.Error.Message, "Произошла ошибка чтения ЗУ");
            }
            else
            {
                if (!(bool)e.Result)
//                    MessageCLI.PrintInDialog("Все данные успешно считаны", "Результат чтения ЗУ", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                else
                    MessageCLI.PrintInDialog("Произошла ошибка чтения ЗУ", "Результат чтения ЗУ");
            }
            EnabledGroupBox(tabPageSPI_ZU, groupBoxContentZU, true);
        }

        private void TimerWaitCancelSendFile_Tick(object sender, EventArgs e)
        {
            IsAbortSendFile = false;
        }

        private void FT245RDevice_ListenRecvStopped(object sender, EventArgs e)
        {
            if (IsStartSendFile)
                IsStartSendFile = true;
            else if (IsStartSectorErase)
                IsStartSectorErase = true;
            else
                startReadContentZU(isD12_On);
        }

        private void _timerShowDebugSend_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel_MessageInfo.Text = $"ожидание пакета = {ConvertUnit.TimeSpanToString(_stopwatchShowDebugSend.Elapsed)}";
        }

        private void SendFileWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_DebugUsb.Value = e.ProgressPercentage;
            toolStripStatusLabel_MessageInfo.Text = e.UserState.ToString();
            MessageCLI.Debug(e.UserState.ToString());
        }

        private void SendFileWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var fileName = getFileName(textBoxLoadFileName.Text);
            if (e.Cancelled)
            {
                var message = sendFileWorker.WasAbort
                    ? $"Процесс передачи файла \"{fileName}\" принудительно завершен!"
                    : $"Процесс записи файла \"{fileName}\" был успешно прерван пользователем!";

                IsStartSendFile = false;
                toolStripStatusLabel_MessageInfo.Text = message;
                MessageCLI.PrintInDialog(message);
            }
            else if (e.Error != null)
            {
                // Ошибка была сгенерирована обработчиком события DoWork
                MessageCLI.PrintInDialog(e.Error.Message, "Произошла ошибка при записи файла " + fileName);
            }
            else
            {
                var result = (KeyValuePair<bool, string>) e.Result;
                if (result.Key)
                    MessageCLI.PrintInDialog(string.Format("Передача файла \"{0}\" завершена ({1})",fileName, result.Value),
                        "Результат записи в файл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageCLI.PrintInDialog(string.Format("Произошла ошибка при записи файла: {0} ({1})", fileName, result.Value));

                toolStripStatusLabel_MessageInfo.Text = "";
            }

            IsStartSendFile = false;           
        }

        private delegate void Callback_FTDIBytesRecieved(object sender, FTDI_Manager.ReadRecvBytesEventArgs e);

        private void FT245RDevice_RecvBytesAsync(object sender, FTDI_Manager.ReadRecvBytesEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Callback_FTDIBytesRecieved d = FT245RDevice_RecvBytesAsync;
                    this.Invoke(d, this, e);
                }
                else
                {
                    var dataBytes = e.RecvBytes;
                    StopDebugSend();
                    var packet = OutputRecvMessages(richTextBoxRecvTestData, dataBytes);
                    toolStripStatusLabel_MessageInfo.Text = String.Format("{3} - Принято {0} байт. Распознано: {1} (t={2})",
                        dataBytes.Length, packet, ConvertUnit.TimeSpanToString(_stopwatchShowDebugSend.Elapsed),
                        DateTime.Now.ToString("hh:mm:ss.fff"));
                    _stopwatchShowDebugSend.Reset();
                }
            }
            catch (Exception ex)
            {
                // ignored
            }
        }

        private void EraseSectorWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_DebugUsb.Value = e.ProgressPercentage;
            toolStripStatusLabel_MessageInfo.Text = e.UserState.ToString();
            MessageCLI.Debug(e.UserState.ToString());
        }

        private void EraseSectorWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                toolStripStatusLabel_MessageInfo.Text = Resources.FormTestFTDI_EraseSectorWorker_RunWorkerCompleted_Процесс_стирания_сектора_был_прерван_пользователем_;
                MessageCLI.Debug(Resources.FormTestFTDI_EraseSectorWorker_RunWorkerCompleted_Процесс_стирания_сектора_был_прерван_пользователем_);
            }
            else if (e.Error != null)
            {
                // Ошибка была сгенерирована обработчиком события DoWork
                MessageCLI.PrintInDialog(e.Error.Message, "Произошла ошибка стирания сектора");
            }
            else
            {
                if ((bool)e.Result)
                    MessageCLI.PrintInDialog("Все сектора успешно стёрты", "Результат стирания", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageCLI.PrintInDialog("Произошла ошибка стирания секторов", "Результат стирания");
            }
            IsStartSectorErase = false;
        }

        private void buttonEraseSector_Click(object sender, EventArgs e)
        {
            if (!IsStartSectorErase)
            {
                IsListenTestPacket = false;
                IsStartSectorErase = true;
            }
            else
                IsStartSectorErase = false;
        }

        private void buttonSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsStartSendFile)
                {
                    var fileName = textBoxLoadFileName.Text;
                    if (fileName == string.Empty)
                    {
                        MessageCLI.PrintInDialog("Выберите путь к файлу для записи", "Ошибка открытия файла");
                        buttonLoadFileName_Click(sender, e);
                    }
                    else if (File.Exists(fileName))
                    {
                        IsListenTestPacket = false;
                        IsStartSendFile = true;
                    }
                    else
                        MessageCLI.PrintInDialog($"Файл \"{fileName}\" не существует", "Ошибка открытия файла");
                }
                else
                    IsStartSendFile = false;
            }
            catch(Exception ex)
            {
                MessageCLI.PrintInDialog(ex.Message, "Ошибка при инициализации передачи файла");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsOpenDevice)
                buttonClose_Click(sender, e);
        }

        private void buttonLoadFileName_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel_MessageInfo.Text = "_";
            var fileName = "";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
                fileName = openFileDialog1.SafeFileName;
            toolStripStatusLabel_MessageInfo.Text = "Файл для передачи выбран !";
            textBoxLoadFileName.Text = openFileDialog1.FileName;
        }

        private void textBoxLoadFileName_TextChanged(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxLoadFileName.Text))
                textBoxLoadFileName.BackColor = Color.Red;
            else
            {
                textBoxLoadFileName.BackColor = Color.White;
            }
            setNameBtnSendFile();
        }

        private void textBoxLoadFileName_DoubleClick(object sender, EventArgs e)
        {
            buttonLoadFileName_Click(sender, e);
        }

        private void textBoxLoadFileName_Click(object sender, EventArgs e)
        {
            if (textBoxLoadFileName.Text.Equals(""))
                buttonLoadFileName_Click(sender, e);
        }

        private void CommandBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txtBox = sender as TextBox;
            if (!char.IsControl(e.KeyChar) && Regex.IsMatch(e.KeyChar.ToString(), "[^0-9A-Fa-f]"))
            {
                e.Handled = true;
            }
            else if (e.KeyChar == (int) Keys.Enter)
            {
                SendBtn_Click(sender, e);
            }
            else
                e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void DataBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            CommandBox_KeyPress(sender, e);
        }

        private void numericUpDownBaudRate_ValueChanged(object sender, EventArgs e)
        {
            SetBaudRate();
        }

        private void SetBaudRate()
        {
            sendFileWorker.BaudRate = (long)numericUpDownBaudRate.Value;
        }

        private void radio_D12_CheckedChanged(object sender, EventArgs e)
        {
            setNameBtnSendFile();
            setNameBtnEraseSector();
        }

        private void radio_D21_CheckedChanged(object sender, EventArgs e)
        {
            setNameBtnSendFile();
            setNameBtnEraseSector();
        }

        private void buttonSend_SPI_D12_Click(object sender, EventArgs e)
        {
            IsListenTestPacket = false;
            uint data, address;
            if (!CheckField(textBoxAddress_SPI_D12.Text, out address, "адреса")) return;
            if (!CheckField(textBoxData_SPI_D12.Text, out data, "данных")) return;
            managerSPI.SendToSPI_D12(address, data);
        }

        private void buttonSend_techMode_Click(object sender, EventArgs e)
        {
            IsListenTestPacket = false;
            uint data;
            if (!CheckField(textBoxData_TechMode_ACP.Text, out data, "данных")) return;
            managerSPI.SendData(0x0, data);
        }

        private void buttonSend_SPI_D21_Click(object sender, EventArgs e)
        {
            IsListenTestPacket = false;
            uint data, address;
            if (!CheckField(textBoxAddress_SPI_D21.Text, out address, "адреса")) return;
            if (!CheckField(textBoxData_SPI_D21.Text, out data, "данных")) return;
            managerSPI.SendToSPI_D21(address, data);
        }

        private void dataGridViewK1_K4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //We make DataGridCheckBoxColumn commit changes with single click
            if (e.RowIndex >= 0)
                dataGridViewK1_K4.CommitEdit(DataGridViewDataErrorContexts.Commit);

            int rowIndex = dataGridViewK1_K4.CurrentCell.RowIndex == 0 ? 1 : 0;
            dataGridViewK1_K4.Rows[rowIndex].Cells[dataGridViewK1_K4.CurrentCell.ColumnIndex].Value =
                !(bool)dataGridViewK1_K4.CurrentCell.Value;
        }

        private void buttonK1_K4_Set_Click(object sender, EventArgs e)
        {
            IsListenTestPacket = false;
            uint k1 = (uint) ( ((bool) dataGridViewK1_K4.Rows[1].Cells[0].Value) ? 1 : 0);
            uint k2 = (uint) ( ((bool) dataGridViewK1_K4.Rows[1].Cells[1].Value) ? 1 : 0);
            uint k3 = (uint) ( ((bool) dataGridViewK1_K4.Rows[1].Cells[2].Value) ? 1 : 0);
            uint k4 = (uint) ( ((bool) dataGridViewK1_K4.Rows[1].Cells[3].Value) ? 1 : 0);

            uint data = k1 | k2 << 1 | k3 << 2 | k4 << 3;

            managerSPI.SendData(0x0, data);
        }

        private bool isD12_On = true;

        private void startReadContentZU(bool isD12 = true)
        {
            toolStripStatusLabel_MessageInfo.Text = string.Format("Подготовка к чтению содержимого ЗУ {0} ...", isD12 ? "D12" : "D21");
            if (!FT245RDevice.IsReadServerRunning)
            {
                // Start process of reading content ZU in background thread
                dataGridView_ContentZU.Rows.Clear();
                dataGridView_ContentZU_32bit.Rows.Clear();
                _countLines = 0;
                _countLines_32bit = 0;
                if (readZUWorker.RunWorkerAsync(FT245RDevice, (uint) numericUpDownDeepReading.Value, isD12))
                {
                    EnabledGroupBox(tabPageSPI_ZU, groupBoxContentZU, false);
                }
            }
        }

        private void buttonRead_ZU_D12_Click(object sender, EventArgs e)
        {
            isD12_On = true;
            reqStartReadContentZU();
        }

        private void reqStartReadContentZU()
        {
            if (FT245RDevice.IsReadServerRunning)
            {
                IsListenTestPacket = false;
            }
            else
                startReadContentZU(isD12_On);
        }

        private void buttonRead_ZU_D21_Click(object sender, EventArgs e)
        {
            isD12_On = false;
            reqStartReadContentZU();
        }

        private void startWriteOZU(bool isD12 = true)
        {
            toolStripStatusLabel_MessageInfo.Text = string.Format("Подготовка к записи содержимого ОЗУ {0} ...", isD12 ? "D12" : "D21");
            if (!FT245RDevice.IsReadServerRunning)
            {
                var grid = (isD12) ? dataGridView_OZU_D12 : dataGridView_OZU_D21;
                var _from = isD12 ? numericUpDownFromD12.Value : numericUpDownFromD21.Value;
                var until = isD12 ? numericUpDownUntilD12.Value : numericUpDownUntilD21.Value;
                // Start process of reading content ZU in background thread
                if (writeOzuWorker.RunWorkerAsync(FT245RDevice, TableManager.GetSeriesCellValues(grid), (uint) _from, (uint) until, isD12))
                {
                    //EnabledGroupBox(tabPageSPI_ZU, groupBoxContentZU, false);
                }
            }
        }

        private void buttonWriteToOZU_D12_Click(object sender, EventArgs e)
        {
            if (FT245RDevice.IsReadServerRunning)
            {
                //IsListenTestPacket = false;
            }
            else
                startWriteOZU();
        }

        private void buttonWriteToOZU_D21_Click(object sender, EventArgs e)
        {
            if (FT245RDevice.IsReadServerRunning)
            {
                //IsListenTestPacket = false;
            }
            else
                startWriteOZU(false);
        }

        private void buttonAssignEndAddressD12_Click(object sender, EventArgs e)
        {
            managerSPI.SendToSPI_EndAddress((uint)numericUpDownDeepReadingD12.Value, true);
        }

        private void buttonAssignEndAddressD21_Click(object sender, EventArgs e)
        {
            managerSPI.SendToSPI_EndAddress((uint)numericUpDownDeepReadingD21.Value, false);
        }

        private void FormFTDI_Debug_Load(object sender, EventArgs e)
        {

        }
    }
}




