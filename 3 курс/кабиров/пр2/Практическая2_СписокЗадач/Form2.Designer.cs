namespace Practice2TaskList;

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
        lblInstruction = new Label();
        checkedNotes = new CheckedListBox();
        btnBack = new Button();
        SuspendLayout();
        // 
        // lblInstruction
        // 
        lblInstruction.AutoSize = true;
        lblInstruction.Location = new Point(22, 20);
        lblInstruction.Name = "lblInstruction";
        lblInstruction.Size = new Size(252, 20);
        lblInstruction.TabIndex = 0;
        lblInstruction.Text = "Отметьте выполненные заметки";
        // 
        // checkedNotes
        // 
        checkedNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        checkedNotes.CheckOnClick = true;
        checkedNotes.FormattingEnabled = true;
        checkedNotes.IntegralHeight = false;
        checkedNotes.Location = new Point(22, 52);
        checkedNotes.Name = "checkedNotes";
        checkedNotes.Size = new Size(488, 302);
        checkedNotes.TabIndex = 1;
        // 
        // btnBack
        // 
        btnBack.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        btnBack.Location = new Point(22, 370);
        btnBack.Name = "btnBack";
        btnBack.Size = new Size(488, 43);
        btnBack.TabIndex = 2;
        btnBack.Text = "Назад";
        btnBack.UseVisualStyleBackColor = true;
        btnBack.Click += btnBack_Click;
        // 
        // Form2
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnBack;
        ClientSize = new Size(532, 435);
        Controls.Add(btnBack);
        Controls.Add(checkedNotes);
        Controls.Add(lblInstruction);
        MinimumSize = new Size(550, 482);
        Name = "Form2";
        StartPosition = FormStartPosition.CenterParent;
        Text = "Практическая 2 — отмеченные задачи";
        ResumeLayout(false);
        PerformLayout();
    }

    private Label lblInstruction = null!;
    private CheckedListBox checkedNotes = null!;
    private Button btnBack = null!;
}
