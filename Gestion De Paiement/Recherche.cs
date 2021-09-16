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
    public partial class Recherche : Form
    {
        Thread th, th2;
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=SAHAM;Integrated Security=True");

        SqlDataAdapter da, da2,da6;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt6 = new DataTable();
        BindingSource bs = new BindingSource();
        SqlCommand cmd = new SqlCommand();
        public Recherche()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(opennewform);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void comboBox_choix_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_etat.Visible = false;
            comboBox_Nom.Visible = false;
            comboBox_Npolice.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label3.Visible = false;
            label1.Visible = false;
            if (comboBox_choix.Text == "N°Police")
            {
                comboBox_Npolice.Visible = true;
                button4.Visible = false;
            }

            else
                if (comboBox_choix.Text == "NomClient")
            {
                comboBox_Nom.Visible = true;
                button4.Visible = false;
            }
            else
                if (comboBox_choix.Text == "Etat")
            {
                comboBox_etat.Visible = true;
                button4.Visible = false;
            }

            else
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label3.Visible = true;
                label1.Visible = true;
                button4.Visible = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = cn;
                cmd.CommandText = "update cheque2 set etat='terminé' where num_cheque=@a";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                cn.Open();
                cmd.ExecuteNonQuery();

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

        private void comboBox_Npolice_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.Filter = "N_police='" + comboBox_Npolice.Text + "'";
            dataGridView1.DataSource = bs;
        }

        private void comboBox_Nom_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.Filter = "CIN='" + comboBox_Nom.SelectedValue + "'";
            dataGridView1.DataSource = bs;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            th2 = new Thread(opennewform2);
            th2.SetApartmentState(ApartmentState.STA);
            th2.Start();
        }

        private void opennewform2()
        {
            Application.Run(new Recherche());
        }

        private void opennewform()
        {
            Application.Run(new Acceuil());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bs.Filter = "date_de_versement>='" + dateTimePicker2.Value + "' and date_de_versement<='" + dateTimePicker1.Value + "'";
            dataGridView1.DataSource = bs;
        }

        private void comboBox_etat_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.Filter = "etat='" + comboBox_etat.Text + "'";
            dataGridView1.DataSource = bs;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Historique f = new Historique(dataGridView1.CurrentRow.Cells[0].Value.ToString(), float.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString()), float.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString()));
            //f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AfficheHistorique f = new AfficheHistorique(dataGridView1.CurrentRow.Cells[0].Value.ToString(), dataGridView1.CurrentRow.Cells[5].Value.ToString());
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            RapportV f = new RapportV(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            f.ShowDialog();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = "";
            da6 = new SqlDataAdapter("select * from cheque2 where date_de_versement='"+dateTimePicker3.Value+"'",cn);
            da6.Fill(dt6);
            dataGridView1.DataSource = dt6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Recherche_Load(object sender, EventArgs e)
        {
            comboBox_etat.Items.Add("avance");
            comboBox_etat.Items.Add("terminé");
            da = new SqlDataAdapter("select * from Client ; select * from assurance ; select * from cheque2", cn);
            da.Fill(ds, "client");
            comboBox_Nom.DataSource = ds.Tables[0];
            comboBox_Nom.DisplayMember = "NomPrenom";
            comboBox_Nom.ValueMember = "CIN";
            ////////////////////////////////////////////////////////
            ds.Tables[1].TableName = "assurance";
            comboBox_Npolice.DataSource = ds.Tables[1];
            comboBox_Npolice.DisplayMember = "N_police";
            ////////////////////////////////////////////////////////
            ds.Tables[2].TableName = "cheque";
            bs.DataSource = ds.Tables[2];
            //dataGridView1.DataSource = bs;
            da2 = new SqlDataAdapter("select * from cheque2", cn);
            da2.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }
    }
}
