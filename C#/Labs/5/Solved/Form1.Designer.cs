namespace Lab_5
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
      this.labelSearchTime = new System.Windows.Forms.Label();
      this.textBoxSearchTime = new System.Windows.Forms.TextBox();
      this.buttonExit = new System.Windows.Forms.Button();
      this.listBoxResult = new System.Windows.Forms.ListBox();
      this.buttonFuzzySearch = new System.Windows.Forms.Button();
      this.labelMaxLevensteinDistance = new System.Windows.Forms.Label();
      this.textBoxMaxLevensteinDistance = new System.Windows.Forms.TextBox();
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
      // labelSearchTime
      // 
      this.labelSearchTime.AutoSize = true;
      this.labelSearchTime.Location = new System.Drawing.Point(175, 149);
      this.labelSearchTime.Name = "labelSearchTime";
      this.labelSearchTime.Size = new System.Drawing.Size(82, 13);
      this.labelSearchTime.TabIndex = 9;
      this.labelSearchTime.Text = "Время поиска:";
      // 
      // textBoxSearchTime
      // 
      this.textBoxSearchTime.Location = new System.Drawing.Point(263, 146);
      this.textBoxSearchTime.Name = "textBoxSearchTime";
      this.textBoxSearchTime.ReadOnly = true;
      this.textBoxSearchTime.Size = new System.Drawing.Size(376, 20);
      this.textBoxSearchTime.TabIndex = 8;
      // 
      // buttonExit
      // 
      this.buttonExit.Location = new System.Drawing.Point(519, 559);
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
      this.listBoxResult.Location = new System.Drawing.Point(11, 228);
      this.listBoxResult.Name = "listBoxResult";
      this.listBoxResult.Size = new System.Drawing.Size(628, 316);
      this.listBoxResult.TabIndex = 13;
      // 
      // buttonFuzzySearch
      // 
      this.buttonFuzzySearch.Location = new System.Drawing.Point(13, 192);
      this.buttonFuzzySearch.Name = "buttonFuzzySearch";
      this.buttonFuzzySearch.Size = new System.Drawing.Size(122, 23);
      this.buttonFuzzySearch.TabIndex = 16;
      this.buttonFuzzySearch.Text = "Нечёткий поиск";
      this.buttonFuzzySearch.UseVisualStyleBackColor = true;
      this.buttonFuzzySearch.Click += new System.EventHandler(this.buttonFuzzySearch_Click);
      // 
      // labelMaxLevensteinDistance
      // 
      this.labelMaxLevensteinDistance.AutoSize = true;
      this.labelMaxLevensteinDistance.Location = new System.Drawing.Point(175, 197);
      this.labelMaxLevensteinDistance.Name = "labelMaxLevensteinDistance";
      this.labelMaxLevensteinDistance.Size = new System.Drawing.Size(278, 13);
      this.labelMaxLevensteinDistance.TabIndex = 17;
      this.labelMaxLevensteinDistance.Text = "Максимально допустимое расстояние Левенштейна:";
      // 
      // textBoxMaxLevensteinDistance
      // 
      this.textBoxMaxLevensteinDistance.Location = new System.Drawing.Point(459, 194);
      this.textBoxMaxLevensteinDistance.Name = "textBoxMaxLevensteinDistance";
      this.textBoxMaxLevensteinDistance.Size = new System.Drawing.Size(182, 20);
      this.textBoxMaxLevensteinDistance.TabIndex = 18;
      this.textBoxMaxLevensteinDistance.Text = "3";
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(659, 595);
      this.Controls.Add(this.textBoxMaxLevensteinDistance);
      this.Controls.Add(this.labelMaxLevensteinDistance);
      this.Controls.Add(this.buttonFuzzySearch);
      this.Controls.Add(this.listBoxResult);
      this.Controls.Add(this.buttonExit);
      this.Controls.Add(this.labelSearchTime);
      this.Controls.Add(this.textBoxSearchTime);
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
    private System.Windows.Forms.Label labelSearchTime;
    private System.Windows.Forms.TextBox textBoxSearchTime;
    private System.Windows.Forms.Button buttonExit;
    private System.Windows.Forms.ListBox listBoxResult;
    private System.Windows.Forms.Button buttonFuzzySearch;
    private System.Windows.Forms.Label labelMaxLevensteinDistance;
    private System.Windows.Forms.TextBox textBoxMaxLevensteinDistance;
  }
}