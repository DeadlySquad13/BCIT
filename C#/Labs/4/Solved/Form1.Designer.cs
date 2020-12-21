namespace Lab_4
{
  partial class Form1
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
      this.textBoxReadTime = new System.Windows.Forms.TextBox();
      this.labelReadTime = new System.Windows.Forms.Label();
      this.labelNumOfWords = new System.Windows.Forms.Label();
      this.textBoxNumOfWords = new System.Windows.Forms.TextBox();
      this.labelWord = new System.Windows.Forms.Label();
      this.textBoxWord = new System.Windows.Forms.TextBox();
      this.buttonReadFile = new System.Windows.Forms.Button();
      this.buttonPreciseSearch = new System.Windows.Forms.Button();
      this.labelPreciseSearchTime = new System.Windows.Forms.Label();
      this.textBoxPreciseSearchTime = new System.Windows.Forms.TextBox();
      this.buttonExit = new System.Windows.Forms.Button();
      this.listBoxResult = new System.Windows.Forms.ListBox();
      this.SuspendLayout();
      // 
      // textBoxReadTime
      // 
      this.textBoxReadTime.Location = new System.Drawing.Point(323, 13);
      this.textBoxReadTime.Name = "textBoxReadTime";
      this.textBoxReadTime.ReadOnly = true;
      this.textBoxReadTime.Size = new System.Drawing.Size(316, 20);
      this.textBoxReadTime.TabIndex = 0;
      // 
      // labelReadTime
      // 
      this.labelReadTime.AutoSize = true;
      this.labelReadTime.Location = new System.Drawing.Point(187, 16);
      this.labelReadTime.Name = "labelReadTime";
      this.labelReadTime.Size = new System.Drawing.Size(130, 13);
      this.labelReadTime.TabIndex = 1;
      this.labelReadTime.Text = "Время чтения из файла:";
      // 
      // labelNumOfWords
      // 
      this.labelNumOfWords.AutoSize = true;
      this.labelNumOfWords.Location = new System.Drawing.Point(187, 55);
      this.labelNumOfWords.Name = "labelNumOfWords";
      this.labelNumOfWords.Size = new System.Drawing.Size(203, 13);
      this.labelNumOfWords.TabIndex = 3;
      this.labelNumOfWords.Text = "Количество уникальных слов в файле:";
      // 
      // textBoxNumOfWords
      // 
      this.textBoxNumOfWords.Location = new System.Drawing.Point(404, 52);
      this.textBoxNumOfWords.Name = "textBoxNumOfWords";
      this.textBoxNumOfWords.ReadOnly = true;
      this.textBoxNumOfWords.Size = new System.Drawing.Size(235, 20);
      this.textBoxNumOfWords.TabIndex = 2;
      // 
      // labelWord
      // 
      this.labelWord.AutoSize = true;
      this.labelWord.Location = new System.Drawing.Point(24, 94);
      this.labelWord.Name = "labelWord";
      this.labelWord.Size = new System.Drawing.Size(101, 13);
      this.labelWord.TabIndex = 5;
      this.labelWord.Text = "Слово для поиска:";
      // 
      // textBoxWord
      // 
      this.textBoxWord.Location = new System.Drawing.Point(145, 91);
      this.textBoxWord.Name = "textBoxWord";
      this.textBoxWord.Size = new System.Drawing.Size(494, 20);
      this.textBoxWord.TabIndex = 4;
      this.textBoxWord.TextChanged += new System.EventHandler(this.textBoxWord_TextChanged);
      // 
      // buttonReadFile
      // 
      this.buttonReadFile.Location = new System.Drawing.Point(12, 11);
      this.buttonReadFile.Name = "buttonReadFile";
      this.buttonReadFile.Size = new System.Drawing.Size(123, 23);
      this.buttonReadFile.TabIndex = 6;
      this.buttonReadFile.Text = "Чтение из файла";
      this.buttonReadFile.UseVisualStyleBackColor = true;
      this.buttonReadFile.Click += new System.EventHandler(this.buttonReadFile_Click);
      // 
      // buttonPreciseSearch
      // 
      this.buttonPreciseSearch.Location = new System.Drawing.Point(13, 144);
      this.buttonPreciseSearch.Name = "buttonPreciseSearch";
      this.buttonPreciseSearch.Size = new System.Drawing.Size(122, 23);
      this.buttonPreciseSearch.TabIndex = 7;
      this.buttonPreciseSearch.Text = "Чёткий поиск";
      this.buttonPreciseSearch.UseVisualStyleBackColor = true;
      this.buttonPreciseSearch.Click += new System.EventHandler(this.buttonPreciseSearch_Click);
      // 
      // labelPreciseSearchTime
      // 
      this.labelPreciseSearchTime.AutoSize = true;
      this.labelPreciseSearchTime.Location = new System.Drawing.Point(187, 149);
      this.labelPreciseSearchTime.Name = "labelPreciseSearchTime";
      this.labelPreciseSearchTime.Size = new System.Drawing.Size(124, 13);
      this.labelPreciseSearchTime.TabIndex = 9;
      this.labelPreciseSearchTime.Text = "Время чёткого поиска:";
      // 
      // textBoxPreciseSearchTime
      // 
      this.textBoxPreciseSearchTime.Location = new System.Drawing.Point(323, 146);
      this.textBoxPreciseSearchTime.Name = "textBoxPreciseSearchTime";
      this.textBoxPreciseSearchTime.Size = new System.Drawing.Size(316, 20);
      this.textBoxPreciseSearchTime.TabIndex = 8;
      // 
      // buttonExit
      // 
      this.buttonExit.Location = new System.Drawing.Point(517, 415);
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.Size = new System.Drawing.Size(122, 23);
      this.buttonExit.TabIndex = 12;
      this.buttonExit.Text = "Выход";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new System.EventHandler(this.button1_Click);
      // 
      // listBoxResult
      // 
      this.listBoxResult.FormattingEnabled = true;
      this.listBoxResult.Location = new System.Drawing.Point(13, 174);
      this.listBoxResult.Name = "listBoxResult";
      this.listBoxResult.Size = new System.Drawing.Size(628, 225);
      this.listBoxResult.TabIndex = 13;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(653, 450);
      this.Controls.Add(this.listBoxResult);
      this.Controls.Add(this.buttonExit);
      this.Controls.Add(this.labelPreciseSearchTime);
      this.Controls.Add(this.textBoxPreciseSearchTime);
      this.Controls.Add(this.buttonPreciseSearch);
      this.Controls.Add(this.buttonReadFile);
      this.Controls.Add(this.labelWord);
      this.Controls.Add(this.textBoxWord);
      this.Controls.Add(this.labelNumOfWords);
      this.Controls.Add(this.textBoxNumOfWords);
      this.Controls.Add(this.labelReadTime);
      this.Controls.Add(this.textBoxReadTime);
      this.Name = "Form1";
      this.Text = "Поиск в файле";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxReadTime;
    private System.Windows.Forms.Label labelReadTime;
    private System.Windows.Forms.Label labelNumOfWords;
    private System.Windows.Forms.TextBox textBoxNumOfWords;
    private System.Windows.Forms.Label labelWord;
    private System.Windows.Forms.TextBox textBoxWord;
    private System.Windows.Forms.Button buttonReadFile;
    private System.Windows.Forms.Button buttonPreciseSearch;
    private System.Windows.Forms.Label labelPreciseSearchTime;
    private System.Windows.Forms.TextBox textBoxPreciseSearchTime;
    private System.Windows.Forms.Button buttonExit;
    private System.Windows.Forms.ListBox listBoxResult;
  }
}