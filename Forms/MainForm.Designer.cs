namespace Films.Forms
{
  partial class MainForm
  {
    private System.ComponentModel.IContainer components = null;
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgFilms = new System.Windows.Forms.DataGridView();
			this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDatePremiere = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnDateDisc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ColumnQuality = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnInsert = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnFind = new System.Windows.Forms.Button();
			this.btnUp = new System.Windows.Forms.Button();
			this.btnDown = new System.Windows.Forms.Button();
			this.btnCalc = new System.Windows.Forms.Button();
			this.lblFilms = new System.Windows.Forms.Label();
			this.btnLog = new System.Windows.Forms.Button();
			this.lblFilm = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgFilms)).BeginInit();
			this.SuspendLayout();
			// 
			// dgFilms
			// 
			this.dgFilms.AllowUserToAddRows = false;
			this.dgFilms.AllowUserToDeleteRows = false;
			this.dgFilms.AllowUserToResizeRows = false;
			this.dgFilms.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
			this.dgFilms.BackgroundColor = System.Drawing.SystemColors.Control;
			this.dgFilms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgFilms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnTitle,
            this.ColumnDatePremiere,
            this.ColumnDateDisc,
            this.ColumnQuality});
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgFilms.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgFilms.Location = new System.Drawing.Point(0, 0);
			this.dgFilms.MultiSelect = false;
			this.dgFilms.Name = "dgFilms";
			this.dgFilms.ReadOnly = true;
			this.dgFilms.RowHeadersVisible = false;
			this.dgFilms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgFilms.ShowCellErrors = false;
			this.dgFilms.ShowCellToolTips = false;
			this.dgFilms.ShowEditingIcon = false;
			this.dgFilms.ShowRowErrors = false;
			this.dgFilms.Size = new System.Drawing.Size(1007, 471);
			this.dgFilms.TabIndex = 0;
			this.dgFilms.DoubleClick += new System.EventHandler(this.dgFilms_DoubleClick);
			this.dgFilms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgFilms_KeyDown);
			// 
			// ColumnTitle
			// 
			this.ColumnTitle.HeaderText = "Название";
			this.ColumnTitle.Name = "ColumnTitle";
			this.ColumnTitle.ReadOnly = true;
			this.ColumnTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ColumnTitle.Width = 350;
			// 
			// ColumnDatePremiere
			// 
			this.ColumnDatePremiere.HeaderText = "Дата выхода";
			this.ColumnDatePremiere.Name = "ColumnDatePremiere";
			this.ColumnDatePremiere.ReadOnly = true;
			this.ColumnDatePremiere.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ColumnDateDisc
			// 
			this.ColumnDateDisc.HeaderText = "Дата выхода на диске";
			this.ColumnDateDisc.Name = "ColumnDateDisc";
			this.ColumnDateDisc.ReadOnly = true;
			this.ColumnDateDisc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// ColumnQuality
			// 
			this.ColumnQuality.HeaderText = "Доступное качество";
			this.ColumnQuality.Name = "ColumnQuality";
			this.ColumnQuality.ReadOnly = true;
			this.ColumnQuality.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.ColumnQuality.Width = 430;
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(12, 482);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(97, 23);
			this.btnAdd.TabIndex = 23;
			this.btnAdd.Text = "Добавить";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnInsert
			// 
			this.btnInsert.Location = new System.Drawing.Point(115, 482);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(97, 23);
			this.btnInsert.TabIndex = 24;
			this.btnInsert.Text = "Вставить";
			this.btnInsert.UseVisualStyleBackColor = true;
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(218, 482);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(97, 23);
			this.btnEdit.TabIndex = 25;
			this.btnEdit.Text = "Редактировать";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(321, 482);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(97, 23);
			this.btnDelete.TabIndex = 26;
			this.btnDelete.Text = "Удалить";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(899, 482);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(97, 23);
			this.btnSave.TabIndex = 27;
			this.btnSave.Text = "Сохранить";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(796, 482);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(97, 23);
			this.btnOpen.TabIndex = 45;
			this.btnOpen.Text = "Открыть";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnFind
			// 
			this.btnFind.Location = new System.Drawing.Point(693, 482);
			this.btnFind.Name = "btnFind";
			this.btnFind.Size = new System.Drawing.Size(97, 23);
			this.btnFind.TabIndex = 48;
			this.btnFind.Text = "Найти";
			this.btnFind.UseVisualStyleBackColor = true;
			this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
			// 
			// btnUp
			// 
			this.btnUp.Location = new System.Drawing.Point(438, 482);
			this.btnUp.Name = "btnUp";
			this.btnUp.Size = new System.Drawing.Size(48, 23);
			this.btnUp.TabIndex = 49;
			this.btnUp.Text = "Вверх";
			this.btnUp.UseVisualStyleBackColor = true;
			this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// btnDown
			// 
			this.btnDown.Location = new System.Drawing.Point(492, 482);
			this.btnDown.Name = "btnDown";
			this.btnDown.Size = new System.Drawing.Size(48, 23);
			this.btnDown.TabIndex = 50;
			this.btnDown.Text = "Вниз";
			this.btnDown.UseVisualStyleBackColor = true;
			this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnCalc
			// 
			this.btnCalc.Location = new System.Drawing.Point(590, 482);
			this.btnCalc.Name = "btnCalc";
			this.btnCalc.Size = new System.Drawing.Size(97, 23);
			this.btnCalc.TabIndex = 51;
			this.btnCalc.Text = "Калькулятор";
			this.btnCalc.UseVisualStyleBackColor = true;
			this.btnCalc.Click += new System.EventHandler(this.btnCoding_Click);
			// 
			// lblFilms
			// 
			this.lblFilms.AutoSize = true;
			this.lblFilms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblFilms.Location = new System.Drawing.Point(690, 512);
			this.lblFilms.Name = "lblFilms";
			this.lblFilms.Size = new System.Drawing.Size(215, 20);
			this.lblFilms.TabIndex = 53;
			this.lblFilms.Text = "Проверено: 0 Изменения: 0";
			// 
			// btnLog
			// 
			this.btnLog.Location = new System.Drawing.Point(931, 509);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(65, 23);
			this.btnLog.TabIndex = 54;
			this.btnLog.Text = "Лог";
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
			// 
			// lblFilm
			// 
			this.lblFilm.AutoSize = true;
			this.lblFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblFilm.Location = new System.Drawing.Point(12, 512);
			this.lblFilm.MaximumSize = new System.Drawing.Size(300, 0);
			this.lblFilm.Name = "lblFilm";
			this.lblFilm.Size = new System.Drawing.Size(80, 13);
			this.lblFilm.TabIndex = 55;
			this.lblFilm.Text = "Проверяется: ";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1008, 537);
			this.Controls.Add(this.lblFilm);
			this.Controls.Add(this.btnLog);
			this.Controls.Add(this.lblFilms);
			this.Controls.Add(this.btnCalc);
			this.Controls.Add(this.btnDown);
			this.Controls.Add(this.btnUp);
			this.Controls.Add(this.btnFind);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnInsert);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgFilms);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Фильмы";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frMain_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.dgFilms)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

    }

		#endregion

	private System.Windows.Forms.DataGridView dgFilms;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnInsert;
    private System.Windows.Forms.Button btnEdit;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Button btnFind;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuality;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateDisc;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDatePremiere;
    private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
    private System.Windows.Forms.Button btnUp;
    private System.Windows.Forms.Button btnDown;
    private System.Windows.Forms.Button btnCalc;
    private System.Windows.Forms.Label lblFilms;
    private System.Windows.Forms.Button btnLog;
    private System.Windows.Forms.Label lblFilm;
  }
}