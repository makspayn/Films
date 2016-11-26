namespace Films
{
  partial class SearchForm
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
      this.label1 = new System.Windows.Forms.Label();
      this.tbTitle = new System.Windows.Forms.TextBox();
      this.btnSearch = new System.Windows.Forms.Button();
      this.lbResults = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(154, 20);
      this.label1.TabIndex = 0;
      this.label1.Text = "Название фильма:";
      // 
      // tbTitle
      // 
      this.tbTitle.Location = new System.Drawing.Point(172, 9);
      this.tbTitle.Name = "tbTitle";
      this.tbTitle.Size = new System.Drawing.Size(227, 20);
      this.tbTitle.TabIndex = 1;
      // 
      // btnSearch
      // 
      this.btnSearch.Location = new System.Drawing.Point(420, 6);
      this.btnSearch.Name = "btnSearch";
      this.btnSearch.Size = new System.Drawing.Size(75, 23);
      this.btnSearch.TabIndex = 2;
      this.btnSearch.Text = "Поиск";
      this.btnSearch.UseVisualStyleBackColor = true;
      this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
      // 
      // lbResults
      // 
      this.lbResults.FormattingEnabled = true;
      this.lbResults.Location = new System.Drawing.Point(16, 44);
      this.lbResults.Name = "lbResults";
      this.lbResults.Size = new System.Drawing.Size(479, 316);
      this.lbResults.TabIndex = 3;
      this.lbResults.DoubleClick += new System.EventHandler(this.lbResults_DoubleClick);
      // 
      // SearchForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(507, 371);
      this.Controls.Add(this.lbResults);
      this.Controls.Add(this.btnSearch);
      this.Controls.Add(this.tbTitle);
      this.Controls.Add(this.label1);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchForm";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Поиск";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox tbTitle;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.ListBox lbResults;
  }
}