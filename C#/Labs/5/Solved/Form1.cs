using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;

using LevensteinDistance.WagnerFischerAlgorithm;

namespace Lab_5
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {

    }

    private void button1_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    /// <summary> 
    /// Список слов.
    /// </summary> 
    List<string> list = new List<string>();

    private void buttonReadFile_Click(object sender, EventArgs e)
    {
      // Открытие модального окна с выбором текстового файла в конкретном формате.
      OpenFileDialog fd = new OpenFileDialog();
      fd.Filter = "текстовые файлы|*.txt";

      if (fd.ShowDialog() == DialogResult.OK)
      {
        // Создание и старт таймера.
        Stopwatch t = new Stopwatch();
        t.Start();

        // Чтение файла в виде строки.
        string text = File.ReadAllText(fd.FileName);

        // Разделительные символы для чтения из файла. 
        char[] separators =
                new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n' };

        string[] textArray = text.Split(separators);

        foreach (string strTemp in textArray)
        {
          // Удаление пробелов в начале и конце строки.
          string str = strTemp.Trim();
          // Добавление строки в список, если строка не содержится в списке.
          if (!list.Contains(str)) list.Add(str);
        }

        t.Stop();

        this.textBoxReadTime.Text = t.Elapsed.ToString();
        this.textBoxNumOfWords.Text = list.Count.ToString();
      }
      else
      {
        MessageBox.Show("Необходимо выбрать файл", "Ошибка");
      }
    }

    private void textBoxWord_TextChanged(object sender, EventArgs e)
    {
    }

    private void OutputResults(List<string> result, Stopwatch t)
    {
      // Обновляем данные в поле-списке.
      listBoxResult.BeginUpdate();
      listBoxResult.Items.Clear(); // Удаление слов с предыдущего запроса.
      if (result.Count == 0)
      {
        MessageBox.Show("Файл не содержит такой подстроки");
      }
      else if (result.Count > 0)
      {
        foreach (string word in result)
        {
          listBoxResult.Items.Add(word);
        }
      }
      listBoxResult.EndUpdate();

      textBoxSearchTime.Text = t.Elapsed.ToString(); // Выводим время поиска.
    }

    private void buttonPreciseSearch_Click(object sender, EventArgs e)
    {
      string str = this.textBoxWord.Text.Trim().ToUpper();
      List<string> result = new List<string>();
     
      Stopwatch t = new Stopwatch();
      t.Start();
      foreach(string word in list)
      {
        if (word.ToUpper().Contains(str))
        {
          result.Add(word);
        }
      }
      t.Stop();

      OutputResults(result, t);
     
    }

    private void buttonSaveReport_Click(object sender, EventArgs e)
    {
    }

    private void textBox1_TextChanged_1(object sender, EventArgs e)
    {

    }

    private void labelLevensteinDistance_Click(object sender, EventArgs e)
    {

    }

    private void buttonFuzzySearch_Click(object sender, EventArgs e)
    {
      string str = this.textBoxWord.Text.Trim().ToUpper();
      List<string> result = new List<string>();

      if (String.IsNullOrEmpty(textBoxMaxLevensteinDistance.Text)) // Пользователь задал своё значение, причём неправильное.
      {
        MessageBox.Show("В поле максимального расстояния Левенштейна должно быть число", "Ошибка");
        return;
      }

      int maxLevensteinDistance = Convert.ToInt32(textBoxMaxLevensteinDistance.Text);
      
      Stopwatch t = new Stopwatch();
      t.Start();
      foreach (string word in list)
      {
        if (DamerauLevenstein.CalculateDistance(word, str) <= maxLevensteinDistance)
        {
          result.Add(word);
        }
      }
      t.Stop();

      OutputResults(result, t);
    }
  }
}
