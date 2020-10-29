private void Inicio()
{
    string connect = "datasource=localhost;port=3306;username=root;password=;database=sistema";
    string query = "select * from principal where user = '" + textBox1.Text + "' AND password =SHA1 ('" + textBox2.Text + "')";
    MySqlConnection databaseConnection = new MySqlConnection(connect);
    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
    commandDatabase.CommandTimeout = 60;
    MySqlDataReader reader;

    try
    {
        databaseConnection.Open();
        reader = commandDatabase.ExecuteReader();

        if (reader.Read())
        {
            Welcome registra = new Welcome();
            registra.Visible = true;
            this.Dispose(false);
            databaseConnection.Close();
        }
        else
        {
            MessageBox.Show("Failed to Login");
        }

    }
    catch (Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
}