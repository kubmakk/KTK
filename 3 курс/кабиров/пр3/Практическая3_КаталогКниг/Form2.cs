namespace Practice3BookCatalog;

public partial class Form2 : Form
{
    private const int ModeratorRole = 2;
    private const int AdministratorRole = 3;

    private readonly int currentRole;

    public Form2(string userName, int role)
    {
        InitializeComponent();

        currentRole = role;
        lblCurrentUser.Text = $"Вы вошли как: {userName} ({GetRoleName(role)})";

        FillBookCatalog();
        ConfigureRoleAccess();
    }

    private static string GetRoleName(int role)
    {
        return role switch
        {
            1 => "пользователь",
            2 => "модератор",
            3 => "администратор",
            _ => "гость"
        };
    }

    private void FillBookCatalog()
    {
        lstBooks.Items.AddRange(
        [
            "Мастер и Маргарита — Михаил Булгаков",
            "Преступление и наказание — Фёдор Достоевский",
            "Евгений Онегин — Александр Пушкин",
            "Герой нашего времени — Михаил Лермонтов",
            "Отцы и дети — Иван Тургенев"
        ]);
    }

    private void ConfigureRoleAccess()
    {
        bool canSort = currentRole >= ModeratorRole;
        bool isAdministrator = currentRole == AdministratorRole;

        btnSort.Visible = canSort;

        lblNewBook.Visible = isAdministrator;
        txtNewBook.Visible = isAdministrator;
        btnAdd.Visible = isAdministrator;
        btnDelete.Visible = isAdministrator;
    }

    private void btnSort_Click(object sender, EventArgs e)
    {
        string[] sortedBooks = lstBooks.Items
            .Cast<object>()
            .Select(item => item.ToString() ?? string.Empty)
            .OrderBy(book => book, StringComparer.CurrentCultureIgnoreCase)
            .ToArray();

        lstBooks.BeginUpdate();
        lstBooks.Items.Clear();
        lstBooks.Items.AddRange(sortedBooks);
        lstBooks.EndUpdate();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        string newBook = txtNewBook.Text.Trim();

        if (string.IsNullOrWhiteSpace(newBook))
        {
            MessageBox.Show(
                "Введите название книги.",
                "Добавление книги",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            txtNewBook.Focus();
            return;
        }

        lstBooks.Items.Add(newBook);
        txtNewBook.Clear();
        txtNewBook.Focus();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (lstBooks.SelectedIndex < 0)
        {
            MessageBox.Show(
                "Выберите книгу, которую нужно удалить.",
                "Удаление книги",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        lstBooks.Items.RemoveAt(lstBooks.SelectedIndex);
    }

    private void btnLogout_Click(object sender, EventArgs e)
    {
        Close();
    }
}
