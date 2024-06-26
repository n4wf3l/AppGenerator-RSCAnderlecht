﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayersGenerator2
{
    public partial class AddPlayer : Form
    {
        public AddPlayer()
        {
            InitializeComponent();
        }
                static string info = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\..\", "AllPlayers-Nawfel-AJR-2.mdf.mdf"));

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ajari\\source\\repos\\PlayersGenerator2\\PlayersGenerator2\\AllPlayers-Nawfel-AJR-2.mdf.mdf;Integrated Security=True;Connect Timeout=30");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("insert into AllPlayers values (@Id,@name,@age,@club,@position)", con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            con1.Close();

            if (textBox2.Text == String.Empty || textBox4.Text == String.Empty || comboBox1.Text == String.Empty || textBox1.Text == String.Empty || textBox3.Text == String.Empty)
            {
                MessageBox.Show("Gelieve alle vakken in te vullen.");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ajari\\source\\repos\\PlayersGenerator2\\PlayersGenerator2\\AllPlayers-Nawfel-AJR-2.mdf.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into AllPlayers values (@Id,@name,@age,@club,@position)", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@club", textBox4.Text);
                cmd.Parameters.AddWithValue("@position", comboBox1.Text);
                cmd.ExecuteNonQuery();


                con.Close();
                MessageBox.Show("Speler is toegevoegd.");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == String.Empty || textBox4.Text == String.Empty || comboBox1.Text == String.Empty || textBox1.Text == String.Empty || textBox3.Text == String.Empty)
            {
                MessageBox.Show("Gelieve alle vakken in te vullen.");
            }
            else
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ajari\\source\\repos\\PlayersGenerator2\\PlayersGenerator2\\AllPlayers-Nawfel-AJR-2.mdf.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update AllPlayers set name=@name, age= @age where Id = @Id", con);

                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@age", double.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@club", textBox4.Text);
                cmd.Parameters.AddWithValue("@position", comboBox1.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Speler is geüpdate.");
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VerwijderSpelers();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ajari\\source\\repos\\PlayersGenerator2\\PlayersGenerator2\\AllPlayers-Nawfel-AJR-2.mdf.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from AllPlayers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void VerwijderSpelers()
        {
            int tel = dataGridView1.Rows.Cast<DataGridViewRow>().Select(row => row.Cells["Id"].Value).Count(x => x != null);

            if (textBox1.Text == String.Empty)
            {
                MessageBox.Show("Gelieve het rugnummer in te geven.");
            }
            else if (tel == 0)
            {
                MessageBox.Show("Deze speler bestaat niet in ons systeem.");
            }

            else
            {
                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ajari\\source\\repos\\PlayersGenerator2\\PlayersGenerator2\\AllPlayers-Nawfel-AJR-2.mdf.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("Delete AllPlayers where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Speler is verwijderd.");
                this.Close();
            }
        }
        

        private void AddPlayer_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = true;
            }
        }



        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = true;
            }
            if (!char.IsNumber(e.KeyChar) || e.KeyChar == 8)
            {
                e.Handled = true;
            }
        }

        private void btn_Clear1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void btn_Clear2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void btn_Clear3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void btn_Clear4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
    }
}
