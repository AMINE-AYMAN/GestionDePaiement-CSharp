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
    public partial class Assurance : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SAHAM;Integrated Security=True");

        SqlDataAdapter da2;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        BindingSource bs;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
                SqlCommandBuilder cmd = new SqlCommandBuilder(da2);
                da2.Update(dt);
                label_Ajou.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label_Ajou.Visible = false;
            label_Supp.Visible = false;
            bs.EndEdit();
            SqlCommandBuilder cmd = new SqlCommandBuilder(da2);
            da2.Update(dt);
            label_Modi.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label_Modi.Visible = false;
            label_Ajou.Visible = false;
            if (MessageBox.Show(this, "il faut d'abord supprimer tous les chèques ayant ce N°POLICE", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        bs.RemoveCurrent();
                        SqlCommandBuilder cmd = new SqlCommandBuilder(da2);
                        da2.Update(dt);
                        label_Supp.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error  : " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            label_Supp.Visible = false;
            label_Modi.Visible = false;
            label_Ajou.Visible = false;
            bs.AddNew();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Modi.Visible = false;
            label_Ajou.Visible = false;
            bs.MoveFirst();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Modi.Visible = false;
            label_Ajou.Visible = false;
            bs.MovePrevious();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Modi.Visible = false;
            label_Ajou.Visible = false;
            bs.MoveNext();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Modi.Visible = false;
            label_Ajou.Visible = false;
            bs.MoveLast();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label_njma.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Client", cn);
            cn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox1.Text == dr[0].ToString())
                    label5.Text = dr[1].ToString();
            }

            dr.Close();
            cn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public Assurance()
        {
            InitializeComponent();
        }

        private void Assurance_Load(object sender, EventArgs e)
        {
            da2 = new SqlDataAdapter("select * from assurance", cn);
            da2.Fill(dt);
            bs = new BindingSource();
            bs.DataSource = dt;
            textBox2.DataBindings.Add("Text", bs, "N_police", true);
            dateTimePicker1.DataBindings.Add("Value", bs, "DateAssurance", true);
            textBox1.DataBindings.Add("Text", bs, "CIN", true);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            //if(checkBox2.Checked)
            //button12.Visible = true;
            //else
            //    button12.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            Historique f = new Historique(textBox2.Text,float.Parse(textBox_Montant.Text));
            f.ShowDialog();
        }
    }
}
