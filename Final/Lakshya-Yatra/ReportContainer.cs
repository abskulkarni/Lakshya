using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lakshya_Yatra
{
    public partial class ReportContainer : Form
    {
        public ReportContainer()
        {
            InitializeComponent();
        }

        private void ReportContainer_Load(object sender, EventArgs e)
        {

        }


        public void ShowReport(DataSet ds, string reportPath, ParameterFields reportParameters = null)
        {
            using (ds)
            {
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);
                rptDoc.SetDataSource(ds.Tables[0]);
                crystalReportViewer1.ReportSource = rptDoc;
                if (reportParameters != null)
                {
                    crystalReportViewer1.ParameterFieldInfo = reportParameters;
                }
                crystalReportViewer1.Zoom(120);
            }
        }

        public void ShowReport(DataSet ds, string reportPath, string tableName, ParameterFields reportParameters = null)
        {
            using (ds)
            {
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);

                foreach (Table t in rptDoc.Database.Tables)
                {
                    if (t.Name == tableName)
                    {
                        rptDoc.SetDataSource(ds.Tables[0]);
                        break;
                    }
                }
                if (reportParameters != null)
                {
                    crystalReportViewer1.ParameterFieldInfo = reportParameters;
                }
                crystalReportViewer1.ReportSource = rptDoc;
                crystalReportViewer1.Zoom(120);
            }
        }

        public void ShowMultipleReports(DataSet ds, string reportPath, ParameterFields reportParameters = null)
        {
            using (ds)
            {
                ReportDocument rptDoc = new ReportDocument();
                rptDoc.Load(reportPath);
                foreach (Table t in rptDoc.Database.Tables)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        if (dt.TableName == t.Name)
                        {
                            t.SetDataSource(dt);
                            break;
                        }
                    }
                }
                if (reportParameters != null)
                {
                    crystalReportViewer1.ParameterFieldInfo = reportParameters;
                }
                crystalReportViewer1.ReportSource = rptDoc;
                crystalReportViewer1.Zoom(120);
            }
        }
    }
}
