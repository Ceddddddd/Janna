using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Janna
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source=DESKTOP-2DKQGSL\\SQLEXPRESS;Initial Catalog=janna;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            displaymain();
            totalboarders();
            waterbill();
            electricbill(); 
            monthlybill();
            overallbill();
            displayboarders();
            ApplyDarkMode(dataGridView1);
            ApplyDarkMode(dataGridView2);
            ApplyDarkMode(dataGridView3);
            ApplyDarkMode(dataGridView4);
            ApplyDarkMode(dataGridView5);
            displaywaterbills();
            displayelectricbills();
            displaymonthlybills();
            Boarders.Hide();
            water.Hide();
            monthly.Hide();
            electric.Hide();
        
          
        }
        private void displaymonthlybills() {
            try
            {
                string query = "select * from  MonthlyLivingBills";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView5.DataSource = dataTable;
                        foreach (DataGridViewColumn column in dataGridView5.Columns)
                        {
                            column.Width = 108;
                        }
                        foreach (DataGridViewColumn column in dataGridView5.Columns)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displayelectricbills()
        {
            try
            {
                string query = "Select * from ElectricBills";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView4.DataSource = dataTable;
                        foreach (DataGridViewColumn column in dataGridView4.Columns)
                        {
                            column.Width = 108;
                        }
                        foreach (DataGridViewColumn column in dataGridView4.Columns)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displaywaterbills() {
            try
            {
                string query = "Select * from WaterBills";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView3.DataSource = dataTable;
                        foreach (DataGridViewColumn column in dataGridView3.Columns)
                        {
                            column.Width = 108;
                        }
                        foreach (DataGridViewColumn column in dataGridView3.Columns)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void displayboarders() {
            try
            {
                string query = "Select * from Boarders";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView2.DataSource = dataTable;
                        foreach (DataGridViewColumn column in dataGridView2.Columns)
                        {
                            column.Width = 100;
                        }
                        foreach (DataGridViewColumn column in dataGridView2.Columns)
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void overallbill() {
            try
            {
                string query = "SELECT (SELECT SUM(Amount) FROM WaterBills) + (SELECT SUM(Amount) FROM ElectricBills) + (SELECT SUM(Rent) FROM MonthlyLivingBills) AS OverallBill;";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null and convert it to integer
                        if (result != DBNull.Value)
                        {
                            int totalBorders = Convert.ToInt32(result);
                            label9.Text = totalBorders.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void monthlybill() {
            try
            {
                string query = "SELECT SUM(Rent) FROM MonthlyLivingBills";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null and convert it to integer
                        if (result != DBNull.Value)
                        {
                            int totalBorders = Convert.ToInt32(result);
                            label8.Text = totalBorders.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void electricbill() {
            try
            {
                string query = "SELECT SUM(Amount) FROM ElectricBills";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null and convert it to integer
                        if (result != DBNull.Value)
                        {
                            int totalBorders = Convert.ToInt32(result);
                            label12.Text = totalBorders.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void waterbill() {


            try
            {
                string query = "SELECT SUM(Amount) FROM WaterBills";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null and convert it to integer
                        if (result != DBNull.Value)
                        {
                            int totalBorders = Convert.ToInt32(result);
                            label11.Text = totalBorders.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void totalboarders() {
            

            try
            {
                string query = "SELECT Count(BoarderID) FROM Boarders";

                // Create and open connection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        // Execute the query and get the result
                        object result = command.ExecuteScalar();

                        // Check if the result is not null and convert it to integer
                        if (result != DBNull.Value)
                        {
                            int totalBorders = Convert.ToInt32(result);
                            label10.Text = totalBorders.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        public static void ApplyDarkMode(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.White; // Set grid color to black
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }
            dataGridView.RowTemplate.Height = 40;


        }
        private void displaymain()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                     SELECT 
    b.BoarderID,
    b.Name,
    b.MoveInDate,
    COALESCE(w.WaterBill, 0) AS WaterBill,
    COALESCE(e.ElectricBill, 0) AS ElectricBill,
    COALESCE(m.MonthlyBill, 0) AS MonthlyBill,
    COALESCE(w.WaterBill, 0) + COALESCE(e.ElectricBill, 0) + COALESCE(m.MonthlyBill, 0) AS TotalBills
FROM 
    Boarders b
LEFT JOIN 
    (SELECT BoarderID, SUM(Amount) AS WaterBill FROM WaterBills GROUP BY BoarderID) w ON b.BoarderID = w.BoarderID
LEFT JOIN 
    (SELECT BoarderID, SUM(Amount) AS ElectricBill FROM ElectricBills GROUP BY BoarderID) e ON b.BoarderID = e.BoarderID
LEFT JOIN 
    (SELECT BoarderID, SUM(Rent + OtherExpenses) AS MonthlyBill FROM MonthlyLivingBills GROUP BY BoarderID) m ON b.BoarderID = m.BoarderID

";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                        foreach (DataGridViewColumn column in dataGridView1.Columns)
                        {
                            column.Width = 100; 
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        
    }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int BoarderID = int.Parse(textBox1.Text);
            string Name = textBox2.Text;
            int Age = int.Parse(textBox3.Text);
            string Gender = textBox4.Text;
            string ContactNumber = textBox5.Text;
            string Email = textBox6.Text;
            DateTime dateTime = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                        string insertQuery = @"
                INSERT INTO Boarders (BoarderID, Name, Age, Gender, ContactNumber, Email, MoveInDate)
                VALUES (@BoarderID, @Name, @Age, @Gender, @ContactNumber, @Email, @MoveInDate)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@BoarderID", BoarderID);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Age", Age);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@MoveInDate", dateTime);
                command.ExecuteNonQuery();
                displaymain();
                totalboarders();
                waterbill();
                electricbill();
                monthlybill();
                overallbill();
                displayboarders();
                ApplyDarkMode(dataGridView1);
                ApplyDarkMode(dataGridView2);
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Check if a valid row is clicked
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];

                // Assuming textBox1 to textBox6 are the TextBox controls
                textBox1.Text = row.Cells["BoarderID"].Value.ToString();
                textBox2.Text = row.Cells["Name"].Value.ToString();
                textBox3.Text = row.Cells["Age"].Value.ToString();
                textBox4.Text = row.Cells["Gender"].Value.ToString();
                textBox5.Text = row.Cells["ContactNumber"].Value.ToString();
                textBox6.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
                int BoarderID = int.Parse(textBox1.Text);
                string Name = textBox2.Text;
                int Age = int.Parse(textBox3.Text);
                string Gender = textBox4.Text;
                string ContactNumber = textBox5.Text;
                string Email = textBox6.Text;
                string updateQuery = @"
            UPDATE Boarders 
            SET Name = @Name, Age = @Age, Gender = @Gender, ContactNumber = @ContactNumber, Email = @Email 
            WHERE BoarderID = @BoarderID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.Parameters.AddWithValue("@BoarderID", BoarderID);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@Age", Age);
                    command.Parameters.AddWithValue("@Gender", Gender);
                    command.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                    command.Parameters.AddWithValue("@Email", Email);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Record updated successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displayboarders();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);

                    }
                        else
                        {
                            MessageBox.Show("No rows were updated.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating record: " + ex.Message);
                    }
                }
            }

        private void button9_Click(object sender, EventArgs e)
        {
            int BoarderID = int.Parse(textBox1.Text);
            string deleteQuery = @"
            Delete from Boarders where BoarderID = @BoarderID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@BoarderID", BoarderID);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Record deleted successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displayboarders();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);

                    }
                    else
                    {
                        MessageBox.Show("No rows were deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error delet record: " + ex.Message);
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox12.Text);
            int boarderid = int.Parse(textBox11.Text);
            decimal amount = int.Parse(textBox10.Text);
            DateTime dateTime = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
        INSERT INTO WaterBills (BillID, BoarderID, BillDate, Amount)
        VALUES (@ID, @BoarderID, @BillDate, @Amount)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@BoarderID", boarderid);
                command.Parameters.AddWithValue("@BillDate", dateTime);
                command.Parameters.AddWithValue("@Amount", amount);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Water bill record inserted successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displaywaterbills(); 
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                    }
                    else
                    {
                        MessageBox.Show("No rows were inserted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting water bill record: " + ex.Message);
                }
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox12.Text);
            int boarderid = int.Parse(textBox11.Text);
            decimal amount = Decimal.Parse(textBox10.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = @"
            UPDATE WaterBills 
            SET BoarderID = @BoarderID, Amount = @Amount
            WHERE BillID = @ID";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@BoarderID", boarderid);
                command.Parameters.AddWithValue("@Amount", amount);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Water bill record updated successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displaywaterbills();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating water bill record: " + ex.Message);
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox12.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = @"
            DELETE FROM WaterBills 
            WHERE BillID = @ID";

                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@ID", id);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Water bill record deleted successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displaywaterbills();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                    }
                    else
                    {
                        MessageBox.Show("No rows were deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting water bill record: " + ex.Message);
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
        }

      

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check if a valid cell is clicked
            {
                DataGridViewRow row = dataGridView4.Rows[e.RowIndex];

                // Assuming the columns in your DataGridView correspond to the values you want to populate in textBox10, textBox11, and textBox12
                textBox9.Text = row.Cells["BillID"].Value.ToString(); // Replace "AmountColumnName" with the actual name of the column containing amount
                textBox8.Text = row.Cells["BoarderID"].Value.ToString(); // Replace "BoarderIDColumnName" with the actual name of the column containing boarder ID
                textBox7.Text = row.Cells["Amount"].Value.ToString(); // Replace "IDColumnName" with the actual name of the column containing ID
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox9.Text);
            int boarderid = int.Parse(textBox8.Text);
            decimal amount = int.Parse(textBox7.Text);
            DateTime dateTime = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
        INSERT INTO ElectricBills (BillID, BoarderID, BillDate, Amount)
        VALUES (@ID, @BoarderID, @BillDate, @Amount)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@BoarderID", boarderid);
                command.Parameters.AddWithValue("@BillDate", dateTime);
                command.Parameters.AddWithValue("@Amount", amount);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Electric bill record inserted successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displaywaterbills();
                        displayelectricbills();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                        ApplyDarkMode(dataGridView4);
                    }
                    else
                    {
                        MessageBox.Show("No rows were inserted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting water bill record: " + ex.Message);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox9.Text);
            int boarderid = int.Parse(textBox8.Text);
            decimal amount = Decimal.Parse(textBox7.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = @"
            UPDATE ElectricBills 
            SET BoarderID = @BoarderID, Amount = @Amount
            WHERE BillID = @ID";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@BoarderID", boarderid);
                command.Parameters.AddWithValue("@Amount", amount);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Water bill record updated successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displaywaterbills();
                        displayelectricbills();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                        ApplyDarkMode(dataGridView4);
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating water bill record: " + ex.Message);
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox9.Text);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = @"
            DELETE FROM ElectricBills 
            WHERE BillID = @ID";

                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@ID", id);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Water bill record deleted successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displaywaterbills();
                        displayelectricbills();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                        ApplyDarkMode(dataGridView4);
                    }
                    else
                    {
                        MessageBox.Show("No rows were deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting water bill record: " + ex.Message);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox9.Clear();
            textBox8.Clear();
            textBox7.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            electric.Hide();
            water.Hide();
            Boarders.Hide();
        }


        private void water_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            water.Hide();
            Boarders.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {   
            Home.Show();
            Boarders.Show();
            electric.Hide();
            water.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Home.Show();
            Boarders.Show();
            water.Show();
            electric.Show();
            monthly.Hide();
        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check if a valid cell is clicked
            {
                DataGridViewRow row = dataGridView3.Rows[e.RowIndex];

                // Assuming the columns in your DataGridView correspond to the values you want to populate in textBox10, textBox11, and textBox12
                textBox12.Text = row.Cells["BillID"].Value.ToString(); // Replace "AmountColumnName" with the actual name of the column containing amount
                textBox11.Text = row.Cells["BoarderID"].Value.ToString(); // Replace "BoarderIDColumnName" with the actual name of the column containing boarder ID
                textBox10.Text = row.Cells["Amount"].Value.ToString(); // Replace "IDColumnName" with the actual name of the column containing ID
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox15.Text);
            int boarderID = int.Parse(textBox14.Text);
            decimal rent = decimal.Parse(textBox13.Text); // Assuming the rent is in decimal format
            decimal otherExpenses = decimal.Parse(textBox16.Text); // Assuming other expenses are in decimal format
            DateTime billDate = DateTime.Now;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = @"
            INSERT INTO MonthlyLivingBills (BillID,BoarderID, BillDate, Rent, OtherExpenses)
            VALUES (@BillID,@BoarderID, @BillDate, @Rent, @OtherExpenses)";

                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@BillID", id);
                command.Parameters.AddWithValue("@BoarderID", boarderID);
                command.Parameters.AddWithValue("@BillDate", billDate);
                command.Parameters.AddWithValue("@Rent", rent);
                command.Parameters.AddWithValue("@OtherExpenses", otherExpenses);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Monthly living bill inserted successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displayboarders();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                        ApplyDarkMode(dataGridView4);
                        ApplyDarkMode(dataGridView5);
                        displaywaterbills();
                        displayelectricbills();
                        displaymonthlybills();
                    }
                    else
                    {
                        MessageBox.Show("No rows were inserted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting monthly living bill: " + ex.Message);
                }
            }


        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Check if a valid cell is clicked
            {
                DataGridViewRow row = dataGridView5.Rows[e.RowIndex];

                // Assuming the columns in your DataGridView correspond to the values you want to populate in textBox10, textBox11, and textBox12
                textBox15.Text = row.Cells["BillID"].Value.ToString(); // Replace "AmountColumnName" with the actual name of the column containing amount
                textBox14.Text = row.Cells["BoarderID"].Value.ToString(); // Replace "BoarderIDColumnName" with the actual name of the column containing boarder ID
                textBox13.Text = row.Cells["Rent"].Value.ToString();
                textBox16.Text = row.Cells["OtherExpenses"].Value.ToString();
                
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox15.Text);
            int boarderID = int.Parse(textBox14.Text);
            decimal rent = decimal.Parse(textBox13.Text); // Assuming the rent is in decimal format
            decimal otherExpenses = decimal.Parse(textBox16.Text); // Assuming other expenses are in decimal format
            DateTime billDate = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = @"
            UPDATE MonthlyLivingBills 
            SET BoarderID = @BoarderID, Rent = @Rent, OtherExpenses = @OtherExpenses
            WHERE BillID = @BillID";

                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@BillID", id);
                command.Parameters.AddWithValue("@BoarderID", boarderID);
                command.Parameters.AddWithValue("@Rent", rent);
                command.Parameters.AddWithValue("@OtherExpenses", otherExpenses);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Monthly living bill updated successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displayboarders();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                        ApplyDarkMode(dataGridView4);
                        ApplyDarkMode(dataGridView5);
                        displaywaterbills();
                        displayelectricbills();
                        displaymonthlybills();
                    }
                    else
                    {
                        MessageBox.Show("No rows were updated.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating monthly living bill: " + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox15.Clear();
            textBox14.Clear();
            textBox13.Clear();
            textBox16.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int id = int.Parse(textBox15.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteQuery = @"
            DELETE FROM MonthlyLivingBills 
            WHERE BillID = @BillID";

                SqlCommand command = new SqlCommand(deleteQuery, connection);
                command.Parameters.AddWithValue("@BillID", id);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Monthly living bill deleted successfully.");
                        displaymain();
                        totalboarders();
                        waterbill();
                        electricbill();
                        monthlybill();
                        overallbill();
                        displayboarders();
                        ApplyDarkMode(dataGridView1);
                        ApplyDarkMode(dataGridView2);
                        ApplyDarkMode(dataGridView3);
                        ApplyDarkMode(dataGridView4);
                        ApplyDarkMode(dataGridView5);
                        displaywaterbills();
                        displayelectricbills();
                        displaymonthlybills();
                    }
                    else
                    {
                        MessageBox.Show("No rows were deleted.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting monthly living bill: " + ex.Message);
                }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Home.Show();
            Boarders.Show();
            water.Show();
            electric.Show();
            monthly.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
