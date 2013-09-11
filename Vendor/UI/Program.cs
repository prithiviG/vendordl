using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.IO;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Text.RegularExpressions;

namespace Vendor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BsfGlobal.g_lUserId = 1;
            BsfGlobal.GetDBString();
            BsfGlobal.GetPassString();
            BsfGlobal.CheckPowerUser(BsfGlobal.g_lUserId);
            BsfGlobal.CheckDB();
            BsfGlobal.GetPermission(BsfGlobal.g_lUserId);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.OfficeSkins).Assembly);
            DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.BonusSkins).Assembly);
            Application.Run(new frmVendorMain()); 

            //BsfGlobal.g_sUserId = string.Empty;
            //GetDBString();
            //GetPassString();
            //CheckMenu();
            //OpenDB();
            //SetCustomColor(g_lUserId);
            //if (sStr == "1")
            //{
            //    //frmNewProj.Execute("");
            //}
            //else if (sStr == "2")
            //{
            //    //frmOpenProj.ShowDialog();
            //}
            //else
            //{
            //    //frmMDIMain.ShowDialog();
            //}

            //try
            //{
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //BsfGlobal.GetDBString();
                //string script = File.ReadAllText(Application.StartupPath + "\\SQLQuery1.sql");

                //BsfGlobal.OpenVendorAnalDB();

                //SqlCommand cmd;
                //cmd = new SqlCommand("DeleteAllProcedures", BsfGlobal.g_VendorDB);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //cmd.ExecuteNonQuery();
                
                //string[] splitter = new string[] { "\r\nGO\r\n" };

                //string[] commandTexts = script.Split(splitter,
                //  StringSplitOptions.RemoveEmptyEntries);
                //foreach (string commandText in commandTexts)
                //{
                //   cmd = new SqlCommand(commandText, BsfGlobal.g_VendorDB);
                //    cmd.CommandType = System.Data.CommandType.Text;
                //    try
                //    {
                //        cmd.ExecuteNonQuery();
                //    }
                //    catch (Exception e)
                //    {
                //        MessageBox.Show(e.ToString());
                //    }
                
            //    Server server = new Server(new ServerConnection(BsfGlobal.OpenVendorAnalDB()));
            //    server.ConnectionContext.ExecuteNonQuery(script);
            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            //    Application.Run(new frmVendor());
        }
    }
}



