namespace Practice3BookCatalog;

partial class Form1
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            components?.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitle = new Label();
        lblLogin = new Label();
        txtLogin = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        chkShowPassword = new CheckBox();
        btnLogin = new Button();
        btnGuest = new Button();
        SuspendLayout();
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.Location = new Point(89, 27);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(259, 37);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Вход в библиотеку";
        // 
        // lblLogin
        // 
        lblLogin.AutoSize = true;
        lblLogin.Location = new Point(47, 99);
        lblLogin.Name = "lblLogin";
        lblLogin.Size = new Size(55, 20);
        lblLogin.TabIndex = 1;
        lblLogin.Text = "Логин:";
        // 
        // txtLogin
        // 
        txtLogin.Location = new Point(145, 96);
        txtLogin.Name = "txtLogin";
        txtLogin.PlaceholderText = "Введите логин";
        txtLogin.Size = new Size(245, 27);
        txtLogin.TabIndex = 2;
        // 
        // lblPassword
        // 
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(47, 146);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(65, 20);
        lblPassword.TabIndex = 3;
        lblPassword.Text = "Пароль:";
        // 
        // txtPassword
        // 
        txtPassword.Location = new Point(145, 143);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '*';
        txtPassword.PlaceholderText = "Введите пароль";
        txtPassword.Size = new Size(245, 27);
        txtPassword.TabIndex = 4;
        // 
        // chkShowPassword
        // 
        chkShowPassword.AutoSize = true;
        chkShowPassword.Location = new Point(145, 181);
        chkShowPassword.Name = "chkShowPassword";
        chkShowPassword.Size = new Size(154, 24);
        chkShowPassword.TabIndex = 5;
        chkShowPassword.Text = "Показать пароль";
        chkShowPassword.UseVisualStyleBackColor = true;
        chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
        // 
        // btnLogin
        // 
        btnLogin.Location = new Point(47, 229);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(343, 43);
        btnLogin.TabIndex = 6;
        btnLogin.Text = "Войти";
        btnLogin.UseVisualStyleBackColor = true;
        btnLogin.Click += btnLogin_Click;
        // 
        // btnGuest
        // 
        btnGuest.Location = new Point(47, 283);
        btnGuest.Name = "btnGuest";
        btnGuest.Size = new Size(343, 43);
        btnGuest.TabIndex = 7;
        btnGuest.Text = "Войти как гость";
        btnGuest.UseVisualStyleBackColor = true;
        btnGuest.Click += btnGuest_Click;
        // 
        // Form1
        // 
        AcceptButton = btnLogin;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(438, 365);
        Controls.Add(btnGuest);
        Controls.Add(btnLogin);
        Controls.Add(chkShowPassword);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtLogin);
        Controls.Add(lblLogin);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Практическая 3 — авторизация";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblTitle = null!;
    private Label lblLogin = null!;
    private TextBox txtLogin = null!;
    private Label lblPassword = null!;
    private TextBox txtPassword = null!;
    private CheckBox chkShowPassword = null!;
    private Button btnLogin = null!;
    private Button btnGuest = null!;
}
