using System.Windows.Forms;

public static class Prompt
{
    public static string ShowDialog(string title, string label, string defaultValue = "")
    {
        Form prompt = new Form
        {
            Width = 400,
            Height = 200,
            Text = title,
            StartPosition = FormStartPosition.CenterScreen // Set the position to center
        };

        Label textLabel = new Label
        {
            Left = 20,
            Top = 20,
            Text = label
        };

        TextBox textBox = new TextBox
        {
            Left = 20,
            Top = 50,
            Width = 340,
            Text = defaultValue
        };

        Button confirmButton = new Button
        {
            Text = "OK",
            Left = 280,
            Width = 80,
            Top = 100,
            DialogResult = DialogResult.OK
        };

        // Add controls to the form
        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(textBox);
        prompt.Controls.Add(confirmButton);

        // Accept OK button as default action
        prompt.AcceptButton = confirmButton;

        // Show the dialog and return the input
        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : defaultValue;
    }
}
