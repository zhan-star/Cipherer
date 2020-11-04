using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Cipherer : Form
    {
       
        public Cipherer()
        {
            InitializeComponent();
        }
         
    private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Зашифровка текста
            if (textBox1.Text != "")
            {
                // Установка шага шифрования
                int num = Convert.ToInt32(textBox1.Text);

                string a;

                richTextBox2.Clear();
                if (num < 20 && num > 0)
                {
                    for (int i = 0; i < richTextBox1.Lines.Length; i++)
                    {
                        a = richTextBox1.Lines[i];
                        for (int j = 0; j < a.Length; j++)
                        {
                            int x = a[j];
                            x = x + num;
                            richTextBox2.AppendText(Convert.ToChar(x).ToString());

                        }
                        richTextBox2.AppendText("\n");
                    }
                    // Запись предыдущего шага
                    label3.Text = Convert.ToString(num);
                }
                else {
                    // Не допускаю шаг шифровки выше 20 для избежания ошибок
                    MessageBox.Show("Шаг должен быть в диапазоне от 0 до 20.");
                }
            }
            else {
                int num = 3;
                // Если оставить шаг пустым ...
                string a;

                richTextBox2.Clear();
                if (num < 20 && num > 0)
                {
                    for (int i = 0; i < richTextBox1.Lines.Length; i++)
                    {
                        a = richTextBox1.Lines[i];
                        for (int j = 0; j < a.Length; j++)
                        {
                            int x = a[j];
                            x = x + num;
                            richTextBox2.AppendText(Convert.ToChar(x).ToString());

                        }
                        richTextBox2.AppendText("\n");
                    }
                    label3.Text = Convert.ToString(3);
                }
                else {
                    MessageBox.Show("Шаг должен быть в диапазоне от 0 до 20.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Расшифровка текста.
            if (textBox1.Text != "")
            {
                int num = Convert.ToInt32(textBox1.Text);
                string a;
                richTextBox2.Clear();
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    a = richTextBox1.Lines[i];
                    for (int j = 0; j < a.Length; j++)
                    {
                        int x = a[j];
                        x = x - num;
                        richTextBox2.AppendText(Convert.ToChar(x).ToString());

                    }
                    richTextBox2.AppendText("\n");
                }
            }
            else {
                int num = 3;
                string a;
                richTextBox2.Clear();
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    a = richTextBox1.Lines[i];
                    for (int j = 0; j < a.Length; j++)
                    {
                        int x = a[j];
                        x = x - num;
                        richTextBox2.AppendText(Convert.ToChar(x).ToString());

                    }
                    richTextBox2.AppendText("\n");
                }
            }
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text=("Зашифровать: зашифровать сообщение в верхнем окне.");
        }

        private void button4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = ("Расшифровать: расшифровать сообщение в верхнем окне.");
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = ("Открыть: выбрать файл и открыть его.");
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = ("Сохранить: сохранить сообщение нижнего окна.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Замена текстов местами
            string upper = richTextBox1.Text;
            string lower = richTextBox2.Text;
            richTextBox1.Text = lower;
            richTextBox2.Text = upper;
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = ("Поменять: поменять сообщения местами.");
        }

        private void richTextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = ("Первое окно: окно шифрования.");
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = ("Второе окно: здесь находится зашифрованнный текст.");
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = ("Пред.шаг: последнее значение шага.");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Text = ("Шаг шифровки: шаг шифровки сообщения.");
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Шифрование данных v0.1. Разработчик: Есенжолов Жангир, SA14/2-152.  2017-2018");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ///Эта часть отвечает за невозможность ввода буквенных символов в строку.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
