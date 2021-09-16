namespace application_saham
{
    partial class RapportV
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RapportV));
            this.cheque2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new application_saham.DataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cheque2TableAdapter = new application_saham.DataSet1TableAdapters.cheque2TableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.cheque2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cheque2BindingSource
            // 
            this.cheque2BindingSource.DataMember = "cheque2";
            this.cheque2BindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.cheque2BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "application_saham.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(106, 82);
            this.reportViewer1.Name = "reportViewer1";
          //  this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(584, 246);
            this.reportViewer1.TabIndex = 0;
            // 
            // cheque2TableAdapter
            // 
            this.cheque2TableAdapter.ClearBeforeFill = true;
            // 
            // RapportV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RapportV";
            this.Text = "RapportV";
            this.Load += new System.EventHandler(this.RapportV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cheque2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource cheque2BindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.cheque2TableAdapter cheque2TableAdapter;
    }
}