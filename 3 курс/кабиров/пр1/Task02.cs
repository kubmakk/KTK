using System;
using System.Drawing;
using System.Windows.Forms;

namespace Practical1_Task02
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form main = new Form();
            main.Text = "Практическая 1";
            main.StartPosition = FormStartPosition.CenterScreen;
            main.ClientSize = new Size(400, 180);

            Label text = new Label();
            text.Text = "Выберите задание";
            text.AutoSize = true;
            text.Left = 130;
            text.Top = 20;
            main.Controls.Add(text);

            for (int i = 1; i <= 2; i++)
            {
                int n = i;
                Button b = new Button();
                b.Text = "Задание " + i;
                b.Width = 140;
                b.Height = 32;
                b.Left = 130;
                b.Top = 55 + (i - 1) * 38;

                b.Click += (s, e) =>
                {
                    if (n == 1)
                    {
                        Form f = new Form();
                        f.Text = "Задание 1";
                        f.ClientSize = new Size(450, 180);
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.KeyPreview = true;

                        Label l = new Label();
                        l.Text = "Нажмите A, B, C или D";
                        l.Dock = DockStyle.Fill;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        f.Controls.Add(l);

                        f.KeyDown += (s1, e1) =>
                        {
                            if (e1.KeyCode == Keys.A) l.Text = "Нажата клавиша A";
                            if (e1.KeyCode == Keys.B) l.Text = "Нажата клавиша B";
                            if (e1.KeyCode == Keys.C) l.Text = "Нажата клавиша C";
                            if (e1.KeyCode == Keys.D) l.Text = "Нажата клавиша D";
                        };
                        f.Show();
                    }
                    if (n == 2)
                    {
                        Form f = new Form();
                        f.Text = "Задание 2";
                        f.ClientSize = new Size(500, 200);
                        f.StartPosition = FormStartPosition.CenterScreen;
                        f.KeyPreview = true;

                        Label l = new Label();
                        l.Text = "Количество нажатий пробела: 0";
                        l.Dock = DockStyle.Fill;
                        l.TextAlign = ContentAlignment.MiddleCenter;
                        f.Controls.Add(l);

                        int count = 0;
                        f.KeyDown += (s2, e2) =>
                        {
                            if (e2.KeyCode == Keys.Space) count++;
                            else if (e2.KeyCode == Keys.Back) count--;
                            else if (e2.KeyCode == Keys.Escape) count = 0;
                            l.Text = "Количество нажатий пробела: " + count;
                        };
                        f.Show();
                    }
                };

                main.Controls.Add(b);
            }

            Application.Run(main);
        }
    }
}
