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
    public partial class Cheque : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SAHAM;Integrated Security=True");

        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public Cheque()
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

        private void Cheque_Load(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("select * from cheque2", cn);
            da.Fill(dt);
            bs.DataSource = dt;

            textBox_Numcheque.DataBindings.Add("Text", bs, "num_cheque", true);
            comboBox_NomB.DataBindings.Add("Text", bs, "nom_banque", true);
            dateTimePicker1.DataBindings.Add("Value", bs, "date_de_versement", true);
            comboBox1.DataBindings.Add("Text", bs, "etat", true);
            label_Npolice.DataBindings.Add("Text", bs, "N_police", true);
            textBox_Cin.DataBindings.Add("Text", bs, "CIN", true);
            textBox_Nomp.DataBindings.Add("Text", bs, "nom", true);
            pictureBox1.DataBindings.Add("image", bs, "chequepdf", true);
            textBox_Montant.DataBindings.Add("Text", bs, "Montant", true);
            label_Reste.DataBindings.Add("Text", bs, "reste", true);
           // comboBox_etat.Items.Add("Impayé");
           // comboBox_etat.Items.Add("payé");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Modi.Visible = false;

            label_Reste.Text = textBox_Montant.Text;
            if (textBox_Numcheque.Text == "")
            {
                label_njma.Visible = true;
            }
            else
            {
                bs.EndEdit();
                SqlCommandBuilder cmr = new SqlCommandBuilder(da);
                da.Update(dt);
                label_Ajou.Visible = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label_Ajou.Visible = false;
            label_Supp.Visible = false;
            bs.EndEdit();
            SqlCommandBuilder cmr = new SqlCommandBuilder(da);
            da.Update(dt);
            label_Modi.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label_Modi.Visible = false;
            label_Ajou.Visible = false;

            if (MessageBox.Show(this, "Etes-vous sûr ?", "ATTENTION !!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                bs.RemoveCurrent();
                SqlCommandBuilder cmr = new SqlCommandBuilder(da);
                da.Update(dt);
                label_Supp.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            button7.Enabled = true;
            button5.Enabled = true;
            bs.AddNew();
            label_Supp.Visible = false;
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel_Nom.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel_Nom.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            pictureBox1.Image = Image.FromFile(op.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label_njma.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            bs.MoveFirst();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            bs.MovePrevious();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            bs.MoveNext();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            label_Supp.Visible = false;
            label_Ajou.Visible = false;
            label_Modi.Visible = false;
            bs.MoveLast();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from assurance", cn);
            cn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (textBox_Cin.Text == dr[2].ToString())
                    label_Npolice.Text = dr[0].ToString();
            }

            dr.Close();
            cn.Close();
            SqlCommand cmd2 = new SqlCommand("select * from Client", cn);
            cn.Open();
            SqlDataReader dr2;
            dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                if (textBox_Cin.Text == dr2[0].ToString())
                    label_NomC.Text = dr2[1].ToString();
            }

            dr2.Close();
            cn.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox_Montant.Text == "")
            {
                label_njma.Visible = true;
            }
            else
            {
                //Historique f = new Historique(textBox_Numcheque.Text, float.Parse(textBox_Montant.Text), float.Parse(label_Reste.Text));
                //f.Show();
            }
        }

        private void textBox_Montant_TextChanged(object sender, EventArgs e)
        {
            label_njma.Visible = false;
            label_Reste.Text = textBox_Montant.Text;
        }
    }
}
