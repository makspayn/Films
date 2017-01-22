namespace Films.Forms
{
  partial class CalcForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.label1 = new System.Windows.Forms.Label();
			this.dtDuration = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.tbWidth = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbHeight = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbFPS = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbQualityVideo = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.tbQualityAudio = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.tbChannels = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tbVideoKbps = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tbAudioKbps = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tbTotalKbps = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.btnCalc = new System.Windows.Forms.Button();
			this.dgRips = new System.Windows.Forms.DataGridView();
			this.ColumnQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnVideo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnAudio = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.pbFrame = new System.Windows.Forms.PictureBox();
			this.label14 = new System.Windows.Forms.Label();
			this.numLeft = new System.Windows.Forms.NumericUpDown();
			this.numUp = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.numRight = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.numDown = new System.Windows.Forms.NumericUpDown();
			this.label17 = new System.Windows.Forms.Label();
			this.btnAnalyse = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.tbAdress = new System.Windows.Forms.TextBox();
			this.btnLoad = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.numSensitivity = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.dgRips)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbFrame)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numUp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numRight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numSensitivity)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(125, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Длительность:";
			// 
			// dtDuration
			// 
			this.dtDuration.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtDuration.Location = new System.Drawing.Point(139, 9);
			this.dtDuration.Name = "dtDuration";
			this.dtDuration.ShowUpDown = true;
			this.dtDuration.Size = new System.Drawing.Size(67, 20);
			this.dtDuration.TabIndex = 1;
			this.dtDuration.Value = new System.DateTime(2016, 7, 6, 2, 0, 0, 0);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(208, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(107, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Разрешение:";
			// 
			// tbWidth
			// 
			this.tbWidth.Location = new System.Drawing.Point(317, 8);
			this.tbWidth.Name = "tbWidth";
			this.tbWidth.Size = new System.Drawing.Size(34, 20);
			this.tbWidth.TabIndex = 3;
			this.tbWidth.Text = "1920";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(353, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(16, 20);
			this.label3.TabIndex = 4;
			this.label3.Text = "x";
			// 
			// tbHeight
			// 
			this.tbHeight.Location = new System.Drawing.Point(371, 8);
			this.tbHeight.Name = "tbHeight";
			this.tbHeight.Size = new System.Drawing.Size(35, 20);
			this.tbHeight.TabIndex = 5;
			this.tbHeight.Text = "800";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(408, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 20);
			this.label4.TabIndex = 6;
			this.label4.Text = "FPS:";
			// 
			// tbFPS
			// 
			this.tbFPS.Location = new System.Drawing.Point(454, 9);
			this.tbFPS.Name = "tbFPS";
			this.tbFPS.Size = new System.Drawing.Size(46, 20);
			this.tbFPS.TabIndex = 7;
			this.tbFPS.Text = "23,976";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(502, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 20);
			this.label5.TabIndex = 8;
			this.label5.Text = "Качество видео:";
			// 
			// tbQualityVideo
			// 
			this.tbQualityVideo.Location = new System.Drawing.Point(640, 9);
			this.tbQualityVideo.Name = "tbQualityVideo";
			this.tbQualityVideo.Size = new System.Drawing.Size(45, 20);
			this.tbQualityVideo.TabIndex = 9;
			this.tbQualityVideo.Text = "0,100";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label6.Location = new System.Drawing.Point(687, 9);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(134, 20);
			this.label6.TabIndex = 10;
			this.label6.Text = "Качество аудио:";
			// 
			// tbQualityAudio
			// 
			this.tbQualityAudio.Location = new System.Drawing.Point(823, 9);
			this.tbQualityAudio.Name = "tbQualityAudio";
			this.tbQualityAudio.Size = new System.Drawing.Size(29, 20);
			this.tbQualityAudio.TabIndex = 11;
			this.tbQualityAudio.Text = "64";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label7.Location = new System.Drawing.Point(854, 8);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 20);
			this.label7.TabIndex = 12;
			this.label7.Text = "Каналов:";
			// 
			// tbChannels
			// 
			this.tbChannels.Location = new System.Drawing.Point(934, 9);
			this.tbChannels.Name = "tbChannels";
			this.tbChannels.Size = new System.Drawing.Size(29, 20);
			this.tbChannels.TabIndex = 13;
			this.tbChannels.Text = "6";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label8.Location = new System.Drawing.Point(12, 28);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(129, 20);
			this.label8.TabIndex = 14;
			this.label8.Text = "Видео битрейт:";
			// 
			// tbVideoKbps
			// 
			this.tbVideoKbps.Location = new System.Drawing.Point(139, 28);
			this.tbVideoKbps.Name = "tbVideoKbps";
			this.tbVideoKbps.ReadOnly = true;
			this.tbVideoKbps.Size = new System.Drawing.Size(67, 20);
			this.tbVideoKbps.TabIndex = 15;
			this.tbVideoKbps.Text = "3683";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label9.Location = new System.Drawing.Point(208, 28);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(45, 20);
			this.label9.TabIndex = 16;
			this.label9.Text = "Kbps";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(441, 29);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(45, 20);
			this.label10.TabIndex = 19;
			this.label10.Text = "Kbps";
			// 
			// tbAudioKbps
			// 
			this.tbAudioKbps.Location = new System.Drawing.Point(379, 27);
			this.tbAudioKbps.Name = "tbAudioKbps";
			this.tbAudioKbps.ReadOnly = true;
			this.tbAudioKbps.Size = new System.Drawing.Size(60, 20);
			this.tbAudioKbps.TabIndex = 18;
			this.tbAudioKbps.Text = "384";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label11.Location = new System.Drawing.Point(252, 28);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(127, 20);
			this.label11.TabIndex = 17;
			this.label11.Text = "Аудио битрейт:";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label12.Location = new System.Drawing.Point(687, 29);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(45, 20);
			this.label12.TabIndex = 22;
			this.label12.Text = "Kbps";
			// 
			// tbTotalKbps
			// 
			this.tbTotalKbps.Location = new System.Drawing.Point(625, 28);
			this.tbTotalKbps.Name = "tbTotalKbps";
			this.tbTotalKbps.ReadOnly = true;
			this.tbTotalKbps.Size = new System.Drawing.Size(60, 20);
			this.tbTotalKbps.TabIndex = 21;
			this.tbTotalKbps.Text = "4067";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label13.Location = new System.Drawing.Point(492, 29);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(132, 20);
			this.label13.TabIndex = 20;
			this.label13.Text = "Общий битрейт:";
			// 
			// btnCalc
			// 
			this.btnCalc.Location = new System.Drawing.Point(822, 28);
			this.btnCalc.Name = "btnCalc";
			this.btnCalc.Size = new System.Drawing.Size(75, 23);
			this.btnCalc.TabIndex = 23;
			this.btnCalc.Text = "Вычислить";
			this.btnCalc.UseVisualStyleBackColor = true;
			this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
			// 
			// dgRips
			// 
			this.dgRips.AllowUserToAddRows = false;
			this.dgRips.AllowUserToDeleteRows = false;
			this.dgRips.AllowUserToResizeColumns = false;
			this.dgRips.AllowUserToResizeRows = false;
			this.dgRips.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgRips.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgRips.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgRips.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgRips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgRips.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnQuality,
            this.ColumnVideo,
            this.ColumnAudio,
            this.ColumnSize});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Khaki;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgRips.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgRips.Enabled = false;
			this.dgRips.EnableHeadersVisualStyles = false;
			this.dgRips.Location = new System.Drawing.Point(16, 54);
			this.dgRips.MultiSelect = false;
			this.dgRips.Name = "dgRips";
			this.dgRips.ReadOnly = true;
			this.dgRips.RowHeadersVisible = false;
			this.dgRips.ShowCellErrors = false;
			this.dgRips.ShowCellToolTips = false;
			this.dgRips.ShowEditingIcon = false;
			this.dgRips.ShowRowErrors = false;
			this.dgRips.Size = new System.Drawing.Size(289, 31);
			this.dgRips.TabIndex = 31;
			// 
			// ColumnQuality
			// 
			this.ColumnQuality.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnQuality.HeaderText = "Качество";
			this.ColumnQuality.Name = "ColumnQuality";
			this.ColumnQuality.ReadOnly = true;
			this.ColumnQuality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ColumnQuality.Width = 87;
			// 
			// ColumnVideo
			// 
			this.ColumnVideo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnVideo.HeaderText = "Видео";
			this.ColumnVideo.Name = "ColumnVideo";
			this.ColumnVideo.ReadOnly = true;
			this.ColumnVideo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ColumnVideo.Width = 64;
			// 
			// ColumnAudio
			// 
			this.ColumnAudio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnAudio.HeaderText = "Аудио";
			this.ColumnAudio.Name = "ColumnAudio";
			this.ColumnAudio.ReadOnly = true;
			this.ColumnAudio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ColumnAudio.Width = 62;
			// 
			// ColumnSize
			// 
			this.ColumnSize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.ColumnSize.HeaderText = "Размер";
			this.ColumnSize.Name = "ColumnSize";
			this.ColumnSize.ReadOnly = true;
			this.ColumnSize.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ColumnSize.Width = 71;
			// 
			// pbFrame
			// 
			this.pbFrame.BackColor = System.Drawing.Color.White;
			this.pbFrame.Location = new System.Drawing.Point(16, 115);
			this.pbFrame.Name = "pbFrame";
			this.pbFrame.Size = new System.Drawing.Size(96, 54);
			this.pbFrame.TabIndex = 32;
			this.pbFrame.TabStop = false;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label14.Location = new System.Drawing.Point(16, 172);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(61, 20);
			this.label14.TabIndex = 33;
			this.label14.Text = "Слева:";
			// 
			// numLeft
			// 
			this.numLeft.Location = new System.Drawing.Point(79, 172);
			this.numLeft.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
			this.numLeft.Name = "numLeft";
			this.numLeft.Size = new System.Drawing.Size(48, 20);
			this.numLeft.TabIndex = 34;
			this.numLeft.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// numUp
			// 
			this.numUp.Location = new System.Drawing.Point(204, 172);
			this.numUp.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
			this.numUp.Name = "numUp";
			this.numUp.Size = new System.Drawing.Size(48, 20);
			this.numUp.TabIndex = 36;
			this.numUp.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label15.Location = new System.Drawing.Point(133, 172);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(65, 20);
			this.label15.TabIndex = 35;
			this.label15.Text = "Сверху:";
			// 
			// numRight
			// 
			this.numRight.Location = new System.Drawing.Point(331, 172);
			this.numRight.Maximum = new decimal(new int[] {
            3840,
            0,
            0,
            0});
			this.numRight.Name = "numRight";
			this.numRight.Size = new System.Drawing.Size(48, 20);
			this.numRight.TabIndex = 38;
			this.numRight.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label16.Location = new System.Drawing.Point(258, 172);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(69, 20);
			this.label16.TabIndex = 37;
			this.label16.Text = "Справа:";
			// 
			// numDown
			// 
			this.numDown.Location = new System.Drawing.Point(445, 172);
			this.numDown.Maximum = new decimal(new int[] {
            2160,
            0,
            0,
            0});
			this.numDown.Name = "numDown";
			this.numDown.Size = new System.Drawing.Size(48, 20);
			this.numDown.TabIndex = 40;
			this.numDown.ValueChanged += new System.EventHandler(this.num_ValueChanged);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label17.Location = new System.Drawing.Point(385, 172);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(57, 20);
			this.label17.TabIndex = 39;
			this.label17.Text = "Снизу:";
			// 
			// btnAnalyse
			// 
			this.btnAnalyse.Location = new System.Drawing.Point(509, 170);
			this.btnAnalyse.Name = "btnAnalyse";
			this.btnAnalyse.Size = new System.Drawing.Size(98, 23);
			this.btnAnalyse.TabIndex = 41;
			this.btnAnalyse.Text = "Анализировать";
			this.btnAnalyse.UseVisualStyleBackColor = true;
			this.btnAnalyse.Click += new System.EventHandler(this.btnAnalyse_Click);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label18.Location = new System.Drawing.Point(621, 171);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(180, 20);
			this.label18.TabIndex = 42;
			this.label18.Text = "1920x1080 -> 1920x800";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label21.Location = new System.Drawing.Point(12, 88);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(61, 20);
			this.label21.TabIndex = 45;
			this.label21.Text = "Адрес:";
			// 
			// tbAdress
			// 
			this.tbAdress.Location = new System.Drawing.Point(79, 88);
			this.tbAdress.Name = "tbAdress";
			this.tbAdress.Size = new System.Drawing.Size(464, 20);
			this.tbAdress.TabIndex = 46;
			this.tbAdress.Text = "http://s019.radikal.ru/i606/1605/4f/53b41ffc9763.png";
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(549, 86);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(75, 23);
			this.btnLoad.TabIndex = 47;
			this.btnLoad.Text = "Загрузить";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label19.Location = new System.Drawing.Point(16, 195);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(157, 20);
			this.label19.TabIndex = 48;
			this.label19.Text = "Чувствительность:";
			// 
			// numSensitivity
			// 
			this.numSensitivity.Location = new System.Drawing.Point(179, 195);
			this.numSensitivity.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
			this.numSensitivity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numSensitivity.Name = "numSensitivity";
			this.numSensitivity.Size = new System.Drawing.Size(48, 20);
			this.numSensitivity.TabIndex = 49;
			this.numSensitivity.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
			// 
			// CalcForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(995, 537);
			this.Controls.Add(this.numSensitivity);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.tbAdress);
			this.Controls.Add(this.label21);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.btnAnalyse);
			this.Controls.Add(this.numDown);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.numRight);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.numUp);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.numLeft);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.pbFrame);
			this.Controls.Add(this.dgRips);
			this.Controls.Add(this.btnCalc);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.tbTotalKbps);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.tbAudioKbps);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.tbVideoKbps);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.tbChannels);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbQualityAudio);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbQualityVideo);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbFPS);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbHeight);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbWidth);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dtDuration);
			this.Controls.Add(this.label1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CalcForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Битрейт калькулятор";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CalcForm_FormClosing);
			this.Shown += new System.EventHandler(this.CalcForm_Shown);
			((System.ComponentModel.ISupportInitialize)(this.dgRips)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbFrame)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numLeft)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numUp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numRight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numSensitivity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker dtDuration;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox tbWidth;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox tbHeight;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox tbFPS;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbQualityVideo;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox tbQualityAudio;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox tbChannels;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.TextBox tbVideoKbps;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox tbAudioKbps;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox tbTotalKbps;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.Button btnCalc;
    private System.Windows.Forms.DataGridView dgRips;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuality;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnVideo;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAudio;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSize;
    private System.Windows.Forms.PictureBox pbFrame;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.NumericUpDown numLeft;
    private System.Windows.Forms.NumericUpDown numUp;
    private System.Windows.Forms.Label label15;
    private System.Windows.Forms.NumericUpDown numRight;
    private System.Windows.Forms.Label label16;
    private System.Windows.Forms.NumericUpDown numDown;
    private System.Windows.Forms.Label label17;
    private System.Windows.Forms.Button btnAnalyse;
    private System.Windows.Forms.Label label18;
    private System.Windows.Forms.Label label21;
    private System.Windows.Forms.TextBox tbAdress;
    private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.NumericUpDown numSensitivity;
	}
}