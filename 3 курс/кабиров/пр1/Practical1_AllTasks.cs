using System;
using System.Drawing;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace Practical1_AllTasks
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Apфplication.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new MainForm());

Application.EnableVisualStyles();
    Form f = new Form();
     f.text = "zadanie";
     f.Clientsize = new Size(400, 300);
     f.KeyPrewiew = true;

     Label a = new Label();
     a.text = "aafsgs";
     a.Dock = DockStyle.Fill;

     
    }

    public class MainForm : Form
    {
        public MainForm()
        {
            Text = "Практическая 1 — все задания";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(420, 500);

            var title = new Label
            {
                Text = "Выберите задание",
                AutoSize = true,
                Font = new Font(Font.FontFamily, 14, FontStyle.Bold),
                Location = new Point(120, 20)
            };
            Controls.Add(title);

            for (int i = 1; i <= 10; i++)
            {
                int taskNumber = i;

                var button = new Button
                {
                    Text = $"Задание {i}",
                    Width = 150,
                    Height = 35,
                    Left = 135,
                    Top = 60 + (i - 1) * 40
                };

                button.Click += (sender, e) => OpenTask(taskNumber);
                Controls.Add(button);
            }
        }

        private void OpenTask(int number)
        {
            Form form = number switch
            {
                1 => new Task1Form(),
                2 => new Task2Form(),
                3 => new Task3Form(),
                4 => new Task4Form(),
                5 => new Task5Form(),
                6 => new Task6Form(),
                7 => new Task7Form(),
                8 => new Task8Form(),
                9 => new Task9Form(),
                10 => new Task10Form(),
                _ => null
            };

            form?.Show();
        }
    }

    // ------------------------------------------------------------
    // Задание 1
    // A, B, C, D — показать последнюю нажатую клавишу.
    // ------------------------------------------------------------
    public class Task1Form : Form
    {
        private readonly Label label1;

        public Task1Form()
        {
            Text = "Задание 1";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(450, 180);
            KeyPreview = true;

            label1 = CreateMainLabel("Нажмите A, B, C или D");
            Controls.Add(label1);

            KeyDown += Task1Form_KeyDown;
        }

        private void Task1Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    label1.Text = "Нажата клавиша A";
                    break;
                case Keys.B:
                    label1.Text = "Нажата клавиша B";
                    break;
                case Keys.C:
                    label1.Text = "Нажата клавиша C";
                    break;
                case Keys.D:
                    label1.Text = "Нажата клавиша D";
                    break;
            }
        }

        private Label CreateMainLabel(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Font = new Font(Font.FontFamily, 15, FontStyle.Bold)
            };
        }
    }

    // ------------------------------------------------------------
    // Задание 2
    // Space +1, Backspace -1, Escape = 0.
    // ------------------------------------------------------------
    public class Task2Form : Form
    {
        private readonly Label label1;
        private int count = 0;

        public Task2Form()
        {
            Text = "Задание 2";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(500, 200);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "Количество нажатий пробела: 0",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 14, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyDown += Task2Form_KeyDown;
        }

        private void Task2Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                count++;
            }
            else if (e.KeyCode == Keys.Back)
            {
                count--;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                count = 0;
            }

            label1.Text = "Количество нажатий пробела: " + count;
        }
    }

    // ------------------------------------------------------------
    // Задание 3
    // Определить цифру или букву через KeyPress.
    // ------------------------------------------------------------
    public class Task3Form : Form
    {
        private readonly Label label1;

        public Task3Form()
        {
            Text = "Задание 3";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(450, 180);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "Нажмите цифру или букву",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 15, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyPress += Task3Form_KeyPress;
        }

        private void Task3Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                label1.Text = "Нажата цифра";
            }
            else if (char.IsLetter(e.KeyChar))
            {
                label1.Text = "Нажата буква";
            }
        }
    }

    // ------------------------------------------------------------
    // Задание 4
    // Считать количество введённых цифр.
    // ------------------------------------------------------------
    public class Task4Form : Form
    {
        private readonly Label label1;
        private int digitCount = 0;

        public Task4Form()
        {
            Text = "Задание 4";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(450, 180);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "Количество введённых цифр: 0",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 14, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyPress += Task4Form_KeyPress;
        }

        private void Task4Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                digitCount++;
            }

            label1.Text = "Количество введённых цифр: " + digitCount;
        }
    }

    // ------------------------------------------------------------
    // Задание 5
    // F1/F2/F3 — режимы, Escape — выключить.
    // ------------------------------------------------------------
    public class Task5Form : Form
    {
        private readonly Label label1;

        public Task5Form()
        {
            Text = "Задание 5";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(450, 180);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "Режим выключен",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 15, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyDown += Task5Form_KeyDown;
        }

        private void Task5Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    label1.Text = "Режим 1";
                    break;
                case Keys.F2:
                    label1.Text = "Режим 2";
                    break;
                case Keys.F3:
                    label1.Text = "Режим 3";
                    break;
                case Keys.Escape:
                    label1.Text = "Режим выключен";
                    break;
            }
        }
    }

    // ------------------------------------------------------------
    // Задание 6
    // Up +1, Down -1, Home = 0, End = 100.
    // ------------------------------------------------------------
    public class Task6Form : Form
    {
        private readonly Label label1;
        private int value = 0;

        public Task6Form()
        {
            Text = "Задание 6";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(450, 180);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "0",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 22, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyDown += Task6Form_KeyDown;
        }

        private void Task6Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    value++;
                    break;
                case Keys.Down:
                    value--;
                    break;
                case Keys.Home:
                    value = 0;
                    break;
                case Keys.End:
                    value = 100;
                    break;
            }

            label1.Text = value.ToString();
        }
    }

    // ------------------------------------------------------------
    // Задание 7
    // Ctrl+S, Ctrl+C, Ctrl+V, Ctrl+Z.
    // ------------------------------------------------------------
    public class Task7Form : Form
    {
        private readonly Label label1;

        public Task7Form()
        {
            Text = "Задание 7";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(500, 200);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "Используйте Ctrl+S, Ctrl+C, Ctrl+V, Ctrl+Z",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 13, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyDown += Task7Form_KeyDown;
        }

        private void Task7Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                label1.Text = "Сохранение";
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                label1.Text = "Копирование";
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                label1.Text = "Вставка";
            }
            else if (e.Control && e.KeyCode == Keys.Z)
            {
                label1.Text = "Отмена действия";
            }
        }
    }

    // ------------------------------------------------------------
    // Задание 8
    // Ctrl+S, Ctrl+Shift+S, Alt+S.
    // ------------------------------------------------------------
    public class Task8Form : Form
    {
        private readonly Label label1;

        public Task8Form()
        {
            Text = "Задание 8";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(520, 200);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "Ctrl+S / Ctrl+Shift+S / Alt+S",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 14, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyDown += Task8Form_KeyDown;
        }

        private void Task8Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.S)
            {
                label1.Text = "Сохранение как";
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                label1.Text = "Сохранение";
            }
            else if (e.Alt && e.KeyCode == Keys.S)
            {
                label1.Text = "Специальное сохранение";
            }
        }
    }

    // ------------------------------------------------------------
    // Задание 9
    // Ctrl+L включает/выключает блокировку.
    // ------------------------------------------------------------
    public class Task9Form : Form
    {
        private readonly Label label1;
        private bool locked = false;

        public Task9Form()
        {
            Text = "Задание 9";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(500, 200);
            KeyPreview = true;

            label1 = new Label
            {
                Text = "Ctrl+L — включить блокировку",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 14, FontStyle.Bold)
            };

            Controls.Add(label1);
            KeyDown += Task9Form_KeyDown;
        }

        private void Task9Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.L)
            {
                locked = !locked;

                label1.Text = locked
                    ? "Клавиатура заблокирована"
                    : "Клавиатура разблокирована";

                return;
            }

            if (locked &&
                (e.KeyCode == Keys.A ||
                 e.KeyCode == Keys.B ||
                 e.KeyCode == Keys.C))
            {
                return;
            }

            if (e.KeyCode == Keys.A)
                label1.Text = "Нажата A";
            else if (e.KeyCode == Keys.B)
                label1.Text = "Нажата B";
            else if (e.KeyCode == Keys.C)
                label1.Text = "Нажата C";
        }
    }

    // ------------------------------------------------------------
    // Задание 10
    // Клавиатурный тренажёр.
    // ------------------------------------------------------------
    public class Task10Form : Form
    {
        private readonly Label labelCorrect;
        private readonly Label labelWrong;
        private readonly Label labelTask;

        private int correct = 0;
        private int wrong = 0;

        private readonly Keys[] keys =
        {
            Keys.A,
            Keys.B,
            Keys.C,
            Keys.D
        };

        private int currentIndex = 0;

        public Task10Form()
        {
            Text = "Задание 10 — клавиатурный тренажёр";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(520, 260);
            KeyPreview = true;

            labelTask = new Label
            {
                AutoSize = false,
                Width = 500,
                Height = 80,
                Left = 10,
                Top = 30,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font(Font.FontFamily, 20, FontStyle.Bold)
            };

            labelCorrect = new Label
            {
                AutoSize = true,
                Left = 70,
                Top = 150,
                Font = new Font(Font.FontFamily, 13, FontStyle.Regular)
            };

            labelWrong = new Label
            {
                AutoSize = true,
                Left = 300,
                Top = 150,
                Font = new Font(Font.FontFamily, 13, FontStyle.Regular)
            };

            Controls.Add(labelTask);
            Controls.Add(labelCorrect);
            Controls.Add(labelWrong);

            KeyDown += Task10Form_KeyDown;

            ShowTask();
        }

        private void ShowTask()
        {
            labelCorrect.Text = "Правильно: " + correct;
            labelWrong.Text = "Неправильно: " + wrong;
            labelTask.Text = "Нажмите " + keys[currentIndex];
        }

        private void Task10Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == keys[currentIndex])
            {
                correct++;

                currentIndex++;

                if (currentIndex >= keys.Length)
                {
                    currentIndex = 0;
                }
            }
            else
            {
                wrong++;
            }

            ShowTask();
        }
    }
}
