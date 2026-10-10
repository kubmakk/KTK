namespace Practice3BookCatalog;

public partial class Form1 : Form
{
    private const int UserRole = 1;
    private const int ModeratorRole = 2;
    private const int AdministratorRole = 3;

    public Form1()
    {
        InitializeComponent();
    }

    private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
    {
        txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        string login = txtLogin.Text.Trim();
        string password = txtPassword.Text;
        int role;

        if (login == "user" && password == "user123")
        {
            role = UserRole;
        }
        else if (login == "moderator" && password == "mod123")
        {
            role = ModeratorRole;
        }
        else if (login == "admin" && password == "admin123")
        {
            role = AdministratorRole;
        }
        else
        {
            MessageBox.Show(
                "Неверный логин или пароль.",
                "Ошибка авторизации",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            txtPassword.SelectAll();
            txtPassword.Focus();
            return;
        }

        OpenWorkspace(login, role);
    }

    private void btnGuest_Click(object sender, EventArgs e)
    {
        const int guestRole = 0;
        OpenWorkspace("Гость", guestRole);
    }

    private void OpenWorkspace(string userName, int role)
    {
        Hide();

        using Form2 workspace = new(userName, role);
        workspace.ShowDialog();

        txtPassword.Clear();
        chkShowPassword.Checked = false;
        Show();
        Activate();
        txtLogin.Focus();
    }
}
