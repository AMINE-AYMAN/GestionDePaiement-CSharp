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
using System.Threading;

namespace application_saham
{
    public partial class Form1 : Form
    {
         SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SAHAM;Integrated Security=True");
       // SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aymane.mdf;Integrated Security=True");
        Thread th;
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                label4.Visible = true;
               // label5.Visible = false;

            }
            if (textBox2.Text == "")
            {
               // label4.Visible = false;
                label5.Visible = true;

            }

            else
           if (textBox1.Text != "" && textBox2.Text != "")
            {
                label4.Visible = false;
                label5.Visible = false;

                try
                {
                    cmd.Connection = cn;
                    cmd.CommandText = "select * from utilisateur";
                    cn.Open();
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr[0].ToString() == textBox1.Text && dr[1].ToString() == textBox2.Text)
                        {
                            this.Close();
                            th = new Thread(opennewform);
                            th.SetApartmentState(ApartmentState.STA);
                            th.Start();
                        }
                        else
                            if (dr[0].ToString() != textBox1.Text || dr[1].ToString() != textBox2.Text)
                        {
                            label6.Text = "username ou password incorrect";
                            label6.Visible = true;
                        }

                    }
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }
        }

        private void opennewform()
        {
           Application.Run(new Acceuil());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }
    }
}
