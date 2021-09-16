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
    public partial class Historique : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection cn = new SqlConnection("data source = . ; initial catalog=SAHAM ; integrated security=true");
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        string npolice;
        float montant;
        float reste;
        public Historique(string Npolice, float montant)
        {
            InitializeComponent();
            this.npolice = Npolice;
            this.montant = montant;
           // this.reste = reste;
        }

        private void Historique_Load(object sender, EventArgs e)
        {
            label_reste.Text = montant.ToString();
            label_Numcheque.Text = npolice;
           // label_montant.Text = reste.ToString();

            da = new SqlDataAdapter("select * from historique", cn);
            da.Fill(dt);
            textBox2.Text = "";
            label_reste.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                button4.Enabled = true;
            else
                button4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = cn;
                cmd.CommandText = "insert into historique values(@a,@b,@c,@d)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@a", label_Numcheque.Text);
                cmd.Parameters.AddWithValue("@b", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@c", float.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@d", label_reste.Text);
                cn.Open();
                if (cmd.ExecuteNonQuery() > 0)
                    cn.Close();

                cmd2.Connection = cn;
                cmd2.CommandText = "update cheque2 set reste=@b where num_cheque=@a";
                cmd2.Parameters.AddWithValue("@a", label_Numcheque.Text);
                cmd2.Parameters.AddWithValue("@b", label_reste.Text);
                cn.Open();
                if (cmd2.ExecuteNonQuery() > 0)
                    cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
                label_reste.Text = (float.Parse(label_montant.Text) - float.Parse(textBox2.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
