namespace Practice3BookCatalog;

partial class Form2
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
        lblCurrentUser = new Label();
        lstBooks = new ListBox();
        btnSort = new Button();
        lblNewBook = new Label();
        txtNewBook = new TextBox();
        btnAdd = new Button();
        btnDelete = new Button();
        btnLogout = new Button();
        SuspendLayout();
        // 
        // lblCurrentUser
        // 
        lblCurrentUser.AutoSize = true;
        lblCurrentUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCurrentUser.Location = new Point(24, 22);
        lblCurrentUser.Name = "lblCurrentUser";
        lblCurrentUser.Size = new Size(143, 23);
        lblCurrentUser.TabIndex = 0;
        lblCurrentUser.Text = "Вы вошли как: ...";
        // 
        // lstBooks
        // 
        lstBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstBooks.FormattingEnabled = true;
        lstBooks.IntegralHeight = false;
        lstBooks.ItemHeight = 20;
        lstBooks.Location = new Point(24, 60);
        lstBooks.Name = "lstBooks";
        lstBooks.Size = new Size(482, 364);
        lstBooks.TabIndex = 1;
        // 
        // btnSort
        // 
        btnSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSort.Location = new Point(528, 60);
        btnSort.Name = "btnSort";
        btnSort.Size = new Size(230, 43);
        btnSort.TabIndex = 2;
        btnSort.Text = "Сортировать по алфавиту";
        btnSort.UseVisualStyleBackColor = true;
        btnSort.Click += btnSort_Click;
        // 
        // lblNewBook
        // 
        lblNewBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblNewBook.AutoSize = true;
        lblNewBook.Location = new Point(528, 127);
        lblNewBook.Name = "lblNewBook";
        lblNewBook.Size = new Size(105, 20);
        lblNewBook.TabIndex = 3;
        lblNewBook.Text = "Новая книга:";
        // 
        // txtNewBook
        // 
        txtNewBook.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        txtNewBook.Location = new Point(528, 155);
        txtNewBook.Name = "txtNewBook";
        txtNewBook.PlaceholderText = "Название — автор";
        txtNewBook.Size = new Size(230, 27);
        txtNewBook.TabIndex = 4;
        // 
        // btnAdd
        // 
        btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAdd.Location = new Point(528, 194);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(230, 43);
        btnAdd.TabIndex = 5;
        btnAdd.Text = "Добавить книгу";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnDelete
        // 
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDelete.Location = new Point(528, 247);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(230, 43);
        btnDelete.TabIndex = 6;
        btnDelete.Text = "Удалить выбранную книгу";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnLogout
        // 
        btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnLogout.Location = new Point(528, 381);
        btnLogout.Name = "btnLogout";
        btnLogout.Size = new Size(230, 43);
        btnLogout.TabIndex = 7;
        btnLogout.Text = "Выйти";
        btnLogout.UseVisualStyleBackColor = true;
        btnLogout.Click += btnLogout_Click;
        // 
        // Form2
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(782, 450);
        Controls.Add(btnLogout);
        Controls.Add(btnDelete);
        Controls.Add(btnAdd);
        Controls.Add(txtNewBook);
        Controls.Add(lblNewBook);
        Controls.Add(btnSort);
        Controls.Add(lstBooks);
        Controls.Add(lblCurrentUser);
        MinimumSize = new Size(800, 497);
        Name = "Form2";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Практическая 3 — каталог книг";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblCurrentUser = null!;
    private ListBox lstBooks = null!;
    private Button btnSort = null!;
    private Label lblNewBook = null!;
    private TextBox txtNewBook = null!;
    private Button btnAdd = null!;
    private Button btnDelete = null!;
    private Button btnLogout = null!;
}
