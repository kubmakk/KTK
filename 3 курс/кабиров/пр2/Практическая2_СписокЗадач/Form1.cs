using System.Text;

namespace Practice2TaskList;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        AddNote();
    }

    private void txtNote_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Enter)
        {
            return;
        }

        AddNote();
        e.SuppressKeyPress = true;
    }

    private void AddNote()
    {
        string note = txtNote.Text.Trim();

        if (string.IsNullOrWhiteSpace(note))
        {
            MessageBox.Show(
                "Введите текст заметки.",
                "Пустая заметка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            txtNote.Focus();
            return;
        }

        lstNotes.Items.Add(note);
        txtNote.Clear();
        txtNote.Focus();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        DeleteSelectedNote();
    }

    private void lstNotes_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Delete)
        {
            return;
        }

        DeleteSelectedNote();
        e.SuppressKeyPress = true;
    }

    private void DeleteSelectedNote()
    {
        if (lstNotes.SelectedIndex < 0)
        {
            MessageBox.Show(
                "Сначала выберите заметку в списке.",
                "Удаление",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        int selectedIndex = lstNotes.SelectedIndex;
        lstNotes.Items.RemoveAt(selectedIndex);

        if (lstNotes.Items.Count > 0)
        {
            lstNotes.SelectedIndex = Math.Min(selectedIndex, lstNotes.Items.Count - 1);
        }
    }

    private void btnSort_Click(object sender, EventArgs e)
    {
        string[] sortedNotes = lstNotes.Items
            .Cast<object>()
            .Select(item => item.ToString() ?? string.Empty)
            .OrderBy(note => note, StringComparer.CurrentCultureIgnoreCase)
            .ToArray();

        lstNotes.BeginUpdate();
        lstNotes.Items.Clear();
        lstNotes.Items.AddRange(sortedNotes);
        lstNotes.EndUpdate();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        using SaveFileDialog dialog = new()
        {
            Title = "Сохранить заметки",
            Filter = "Текстовый файл (*.txt)|*.txt|Все файлы (*.*)|*.*",
            DefaultExt = "txt",
            AddExtension = true,
            FileName = "Заметки.txt"
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
        {
            return;
        }

        try
        {
            string[] notes = lstNotes.Items
                .Cast<object>()
                .Select(item => item.ToString() ?? string.Empty)
                .ToArray();

            File.WriteAllLines(dialog.FileName, notes, Encoding.UTF8);

            MessageBox.Show(
                "Заметки успешно сохранены.",
                "Сохранение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception exception)
        {
            MessageBox.Show(
                $"Не удалось сохранить файл.\n\n{exception.Message}",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }

    private void btnOpenSecondForm_Click(object sender, EventArgs e)
    {
        string[] notes = lstNotes.Items
            .Cast<object>()
            .Select(item => item.ToString() ?? string.Empty)
            .ToArray();

        using Form2 secondForm = new(notes);
        secondForm.ShowDialog(this);
    }
}
