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
    public partial class AfficheHistorique : Form
    {
        SqlConnection cn = new SqlConnection("data source = . ; initial catalog=SAHAM ; integrated security=true");

        SqlDataAdapter da;
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        string nom, numcheque;

        public AfficheHistorique(string numcheque, string nom)
        {
            InitializeComponent();
             this.numcheque = numcheque;
            this.nom = nom;
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = cn;
                cmd.CommandText = "delete from historique where Num_Cheque=@a";
                cmd.Parameters.AddWithValue("@a", dataGridView1.CurrentRow.Cells[1].Value.ToString());
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

        private void label_numcheque_Click(object sender, EventArgs e)
        {

        }

        private void AfficheHistorique_Load(object sender, EventArgs e)
        {
              label_cin.Text = nom;
            label_numcheque.Text = numcheque;
            da = new SqlDataAdapter("select * from historique where Num_Cheque='"+numcheque+"'", cn);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            SqlCommand cmd = new SqlCommand("select * from Client", cn);
            cn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                if (label_cin.Text == dr[0].ToString())
                    label_nom.Text = dr[1].ToString();
            }dr.Close();
            cn.Close();
        }
    }
}
