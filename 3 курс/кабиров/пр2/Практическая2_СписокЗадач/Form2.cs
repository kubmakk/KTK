namespace Practice2TaskList;

public partial class Form2 : Form
{
    public Form2(IEnumerable<string> notes)
    {
        InitializeComponent();

        foreach (string note in notes)
        {
            checkedNotes.Items.Add(note, false);
        }
    }

    private void btnBack_Click(object sender, EventArgs e)
    {
        Close();
    }
}
