namespace ProcesoCRUD.Presentacion.Reportes
{
    partial class Frm_Rpt_Listado_pr
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dS_Reportes = new ProcesoCRUD.Presentacion.Reportes.DS_Reportes();
            this.dSReportesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dSReportesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.uSPLISTADOPRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.uSP_LISTADO_PRTableAdapter = new ProcesoCRUD.Presentacion.Reportes.DS_ReportesTableAdapters.USP_LISTADO_PRTableAdapter();
            this.txt01 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.uSPLISTADOPRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ProcesoCRUD.Presentacion.Reportes.Rpt_LIstado_PR.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1031, 491);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // dS_Reportes
            // 
            this.dS_Reportes.DataSetName = "DS_Reportes";
            this.dS_Reportes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dSReportesBindingSource
            // 
            this.dSReportesBindingSource.DataSource = this.dS_Reportes;
            this.dSReportesBindingSource.Position = 0;
            // 
            // dSReportesBindingSource1
            // 
            this.dSReportesBindingSource1.DataSource = this.dS_Reportes;
            this.dSReportesBindingSource1.Position = 0;
            // 
            // uSPLISTADOPRBindingSource
            // 
            this.uSPLISTADOPRBindingSource.DataMember = "USP_LISTADO_PR";
            this.uSPLISTADOPRBindingSource.DataSource = this.dS_Reportes;
            // 
            // uSP_LISTADO_PRTableAdapter
            // 
            this.uSP_LISTADO_PRTableAdapter.ClearBeforeFill = true;
            // 
            // txt01
            // 
            this.txt01.Location = new System.Drawing.Point(35, 62);
            this.txt01.Name = "txt01";
            this.txt01.Size = new System.Drawing.Size(100, 22);
            this.txt01.TabIndex = 1;
            this.txt01.Visible = false;
            // 
            // Frm_Rpt_Listado_pr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 491);
            this.Controls.Add(this.txt01);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Rpt_Listado_pr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Rpt_Listado_pr";
            this.Load += new System.EventHandler(this.Frm_Rpt_Listado_pr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS_Reportes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSReportesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uSPLISTADOPRBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource uSPLISTADOPRBindingSource;
        private DS_Reportes dS_Reportes;
        private System.Windows.Forms.BindingSource dSReportesBindingSource;
        private System.Windows.Forms.BindingSource dSReportesBindingSource1;
        private DS_ReportesTableAdapters.USP_LISTADO_PRTableAdapter uSP_LISTADO_PRTableAdapter;
        internal System.Windows.Forms.TextBox txt01;
    }
}