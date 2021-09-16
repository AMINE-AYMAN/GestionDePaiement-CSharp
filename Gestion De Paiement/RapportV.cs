using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application_saham
{
    public partial class RapportV : Form
    {
        string numcheque;
        public RapportV(string numcheque)
        {
            InitializeComponent();
            this.numcheque = numcheque;
        }

        private void RapportV_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'DataSet1.cheque2'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.cheque2TableAdapter.Fill(this.DataSet1.cheque2,numcheque);

            this.reportViewer1.RefreshReport();
        }
    }
}
