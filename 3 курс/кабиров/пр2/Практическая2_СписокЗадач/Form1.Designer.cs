namespace Practice2TaskList;

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
        lblInstruction = new Label();
        txtNote = new TextBox();
        lstNotes = new ListBox();
        btnAdd = new Button();
        btnDelete = new Button();
        btnSort = new Button();
        btnSave = new Button();
        btnOpenSecondForm = new Button();
        SuspendLayout();
        // 
        // lblInstruction
        // 
        lblInstruction.AutoSize = true;
        lblInstruction.Location = new Point(24, 22);
        lblInstruction.Name = "lblInstruction";
        lblInstruction.Size = new Size(238, 20);
        lblInstruction.TabIndex = 0;
        lblInstruction.Text = "Введите новую заметку и нажмите Enter";
        // 
        // txtNote
        // 
        txtNote.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtNote.Location = new Point(24, 50);
        txtNote.Name = "txtNote";
        txtNote.PlaceholderText = "Например: подготовить отчёт";
        txtNote.Size = new Size(466, 27);
        txtNote.TabIndex = 1;
        txtNote.KeyDown += txtNote_KeyDown;
        // 
        // lstNotes
        // 
        lstNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        lstNotes.FormattingEnabled = true;
        lstNotes.IntegralHeight = false;
        lstNotes.ItemHeight = 20;
        lstNotes.Location = new Point(24, 96);
        lstNotes.Name = "lstNotes";
        lstNotes.Size = new Size(466, 307);
        lstNotes.TabIndex = 2;
        lstNotes.KeyDown += lstNotes_KeyDown;
        // 
        // btnAdd
        // 
        btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAdd.Location = new Point(512, 50);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(170, 44);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Добавить";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnDelete
        // 
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDelete.Location = new Point(512, 104);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(170, 44);
        btnDelete.TabIndex = 4;
        btnDelete.Text = "Удалить";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnSort
        // 
        btnSort.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSort.Location = new Point(512, 158);
        btnSort.Name = "btnSort";
        btnSort.Size = new Size(170, 44);
        btnSort.TabIndex = 5;
        btnSort.Text = "Сортировать";
        btnSort.UseVisualStyleBackColor = true;
        btnSort.Click += btnSort_Click;
        // 
        // btnSave
        // 
        btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnSave.Location = new Point(512, 212);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(170, 44);
        btnSave.TabIndex = 6;
        btnSave.Text = "Сохранить в .txt";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnOpenSecondForm
        // 
        btnOpenSecondForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnOpenSecondForm.Location = new Point(512, 266);
        btnOpenSecondForm.Name = "btnOpenSecondForm";
        btnOpenSecondForm.Size = new Size(170, 60);
        btnOpenSecondForm.TabIndex = 7;
        btnOpenSecondForm.Text = "Открыть вторую форму";
        btnOpenSecondForm.UseVisualStyleBackColor = true;
        btnOpenSecondForm.Click += btnOpenSecondForm_Click;
        // 
        // Form1
        // 
        AcceptButton = btnAdd;
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(706, 430);
        Controls.Add(btnOpenSecondForm);
        Controls.Add(btnSave);
        Controls.Add(btnSort);
        Controls.Add(btnDelete);
        Controls.Add(btnAdd);
        Controls.Add(lstNotes);
        Controls.Add(txtNote);
        Controls.Add(lblInstruction);
        MinimumSize = new Size(724, 477);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Практическая 2 — список задач";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblInstruction = null!;
    private TextBox txtNote = null!;
    private ListBox lstNotes = null!;
    private Button btnAdd = null!;
    private Button btnDelete = null!;
    private Button btnSort = null!;
    private Button btnSave = null!;
    private Button btnOpenSecondForm = null!;
}
