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

namespace application_saham
{
    public partial class Client : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SAHAM;Integrated Security=True");

        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingSource bs;
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Client_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from Client", cn);
            da.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            textBox1.DataBindings.Add("Text", bs, "CIN", true);
            textBox2.DataBindings.Add("Text", bs, "NomPrenom", true);
            //dateTimePicker1.DataBindings.Add("Value", bs, "DateNaissance", true);
            comboBox1.DataBindings.Add("Text", bs, "Sexe", true);
            //textBox3.DataBindings.Add("Text", bs, "Age", true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            label_Supp.Visible = false;
            bs.AddNew();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label_Modi.Visible = false;
            label_Supp.Visible = false;
            if (textBox1.Text == "")
            {
                label_njma.Visible = true;
            }
            else
            {
                bs.EndEdit();
                SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                da.Update(dt);
                label_Ajou.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label_Ajou.Visible = false;
            label_Supp.Visible = false;
            bs.EndEdit();
            SqlCommandBuilder cmd = new SqlCommandBuilder(da);
            da.Update(dt);
            label_Modi.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label_Modi.Visible = false;
            label_Ajou.Visible = false;
            if (MessageBox.Show(this, "il faut d'abord supprimer sa assurance et tous les chèques de ce client", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {

            
            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                try
                {
                    bs.RemoveCurrent();
                    SqlCommandBuilder cmd = new SqlCommandBuilder(da);
                    da.Update(dt);
                    label_Supp.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }

            }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            label_Supp.Visible = false;
            bs.MoveFirst();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            label_Supp.Visible = false;
            bs.MovePrevious();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            label_Supp.Visible = false;
            bs.MoveNext();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            label_Supp.Visible = false;
            bs.MoveLast();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label_njma.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
