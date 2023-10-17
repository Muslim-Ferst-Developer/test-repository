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
using System.Xml.Linq;

namespace barez_computer
{
    public partial class Game : Form
    {

        public Game()
        {
            InitializeComponent();
        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Username.Text = null;
            Password.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string Formbarezcomputer = "Data Source=MUSLIM\\SQLEXPRESS;Initial catalog=Form barez komputer;Integrated security=True";
            SqlConnection con = new SqlConnection(Formbarezcomputer);
            con.Open();
            
            SqlCommand cmd = new SqlCommand("select* from Loginn where name like '"+Username.Text+ "' and password like '"+Password.Text+"'", con);
            
            SqlDataReader reader1 = cmd.ExecuteReader();

            if (reader1.Read())
            {
                MessageBox.Show("this is for test:" + reader1["name"]);
            }
            con.Close();

        }

        private void Game_Load(object sender, EventArgs e)
        {
           
           


        }

        private void Regaster_Click(object sender, EventArgs e)
        {
            string Formbarezcomputer = "Data Source=MUSLIM\\SQLEXPRESS;Initial catalog=Form barez komputer;Integrated security=True";
            SqlConnection con = new SqlConnection(Formbarezcomputer);
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Loginn(name,Password) VALUES('" + Username.Text+"','" + Password.Text + "')",con);
            cmd.BeginExecuteNonQuery();
            
            if (Username.Text!=null|| Password.Text != null)
            {
                MessageBox.Show("sucsesfuly");
            }
            else  if (Password.Text == null)
            {
                    MessageBox.Show("password empty");
            } else if (Username.Text == null)
            {
                    MessageBox.Show("Username empty");
            }
            else 
            {
                    MessageBox.Show("eror");
            }
            

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Formbarezcomputer = "Data Source=MUSLIM\\SQLEXPRESS;Initial catalog=Form barez komputer;Integrated security=True";
            SqlConnection con = new SqlConnection(Formbarezcomputer);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Loginn where id=@id", con);
            cmd.Parameters.AddWithValue("id", textBox3.Text);
            SqlDataReader reader1;
            reader1= cmd.ExecuteReader();
            if (reader1.Read())
            {
                textBox1.Text = reader1["name"].ToString();
                textBox2.Text = reader1["password"].ToString();
            }
            else
            {
                MessageBox.Show("sory no data fouand");
            }

            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
