using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Vendor
{
    public partial class frmReport : Form
    {
        //#region Objects
        //BsfGlobal DO;
        //#endregion 
        #region Constructors
        public frmReport()
        {
            InitializeComponent();
            //DO = new BsfGlobal();     
        }
        #endregion
        public void ReportConvert(CrystalDecisions.CrystalReports.Engine.ReportDocument argObjectReport, string[] argDatafiles)
        {
            try
            {
                int icnt = 0;
                {
                    BsfGlobal.GetDBString();
                    CrystalDecisions.Shared.TableLogOnInfo ConInfo = new CrystalDecisions.Shared.TableLogOnInfo();
                    string ardata;
                    ardata = Convert.ToString(argDatafiles[0]);
                    ConInfo.ConnectionInfo.UserID = BsfGlobal.g_sUserId;
                    ConInfo.ConnectionInfo.Password = "admin";
                    ConInfo.ConnectionInfo.ServerName = BsfGlobal.g_sServerName;
                    for (; icnt <= argObjectReport.Database.Tables.Count - 1; icnt++)
                    {
                        ConInfo.ConnectionInfo.DatabaseName = argDatafiles[icnt];
                        argObjectReport.Database.Tables[icnt].ApplyLogOnInfo(ConInfo);
                    }
                }
            }
            catch
            {
                //Interaction.MsgBox("Error: " + Except.Message);
            }
        }
    }
}
