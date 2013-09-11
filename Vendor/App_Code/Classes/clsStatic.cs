using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;
using System.Globalization;
using System.Data.SqlClient;
using Telerik.WinControls.UI.Docking;
using Telerik.WinControls.UI;
using Microsoft.VisualBasic;
using DevExpress.Utils.Paint;

    class clsStatic

    {
        //public static Telerik.WinControls.UI.Docking.DocumentWindow DW1;
        //public static Telerik.WinControls.UI.Docking.DocumentWindow DW2;
        public static int g_iCurrencyDigit = 2;
        public static bool g_bTypeSelection = true ;
        //public static int g_iUserId;
        //public static string g_sUserName;
        //public static string g_sFunction = "";
        public enum datatypes
        {
            vartypenumeric = 0,
            VarTypeDate,
            vartypestring,
            varTypeBoolean
        }
        public static void AutoComplete(ComboBox cbo, System.Windows.Forms.KeyEventArgs e)
        {
            // Call this from your form passing in the name
            // of your combobox and the event arg:
            // AutoComplete(cboState, e)
            int iIndex = 0;
            string sActual = null;
            string sFound = null;
            bool bMatchFound = false;

            //check if the text is blank or not, if not then only proceed

            //if the text is not blank then only proceed
            if (!string.IsNullOrEmpty(cbo.Text))
            {


                // If backspace then remove the last character

                // that was typed in and try to find

                // a match. note that the selected text from the

                // last character typed in to the

                // end of the combo text field will also be deleted.

                if (e.KeyCode == Keys.Back)
                {

                    cbo.Text = cbo.Text.Substring(1, cbo.Text.Length - 1);
                }

                // Do nothing for some keys such as navigation keys...

                if (((e.KeyCode == Keys.Left) | (e.KeyCode == Keys.Right) | (e.KeyCode == Keys.Up) | (e.KeyCode == Keys.Down) | (e.KeyCode == Keys.PageUp) | (e.KeyCode == Keys.PageDown) | (e.KeyCode == Keys.Home) | (e.KeyCode == Keys.End)))
                {
                    return;
                }

                do
                {
                    // Store the actual text that has been typed.

                    sActual = cbo.Text;
                    // Find the first match for the typed value.

                    iIndex = cbo.FindString(sActual);
                    // Get the text of the first match.

                    // if index > -1 then a match was found.


                    //** FOUND SECTION **
                    if ((iIndex > -1))
                    {

                        sFound = cbo.Items[iIndex].ToString();
                        // Select this item from the list.

                        cbo.SelectedIndex = iIndex;
                        // Select the portion of the text that was automatically

                        // added so that additional typing will replace it.

                        cbo.SelectionStart = sActual.Length;
                        cbo.SelectionLength = sFound.Length;
                        bMatchFound = true;
                        //** NOT FOUND SECTION **
                    }
                    else
                    {


                        //if there isn't a match and the text typed in is only 1 character

                        //or nothing then just select the first entry in the combo box.


                        if (sActual.Length == 1 | sActual.Length == 0)
                        {
                            cbo.SelectedIndex = 0;
                            cbo.SelectionStart = 0;
                            cbo.SelectionLength = cbo.Text.Length;
                            bMatchFound = true;


                        }
                        else
                        {
                            //if there isn't a match for the text typed in then

                            //remove the last character of the text typed in

                            //and try to find a match.


                            //************************** NOTE **************************

                            //COMMENT THE FOLLOWING THREE LINES AND UNCOMMENT

                            //THE (bMatchFound = True) LINE

                            //INCASE YOU WANT TO ALLOW TEXTS TO BE TYPED IN

                            // WHICH ARE NOT IN THE LIST. ELSE IF

                            //YOU WANT TO RESTRICT THE USER TO TYPE TEXTS WHICH ARE

                            //NOT IN THE LIST THEN LEAVE THE FOLLOWING THREE LINES AS IT IS

                            //AND COMMENT THE (bMatchFound = True) LINE.

                            //***********************************************************

                            ///////// THREE LINES SECTION STARTS HERE ///////////

                            cbo.SelectionStart = sActual.Length - 1;
                            cbo.SelectionLength = sActual.Length - 1;
                            cbo.Text = cbo.Text.Substring(1, cbo.Text.Length - 1);
                            ///////// THREE LINES SECTION ENDS HERE /////////////

                            //bMatchFound = True


                        }

                    }
                } while (!(bMatchFound));
            }
        }

        public static string FormatNum(object argValue, int argDigit)
        {
            decimal dValue = argValue.ToString() == string.Empty ? 0 : Convert.ToDecimal(argValue);
            string sFormat = "N" + Convert.ToString(argDigit).Trim();
            return dValue.ToString(sFormat, CultureInfo.GetCultureInfo(1094).NumberFormat);
        }

        public static void PopulateAutoComplete(TextBox argObject, DataTable argTable, string argField)
        {
            argObject.AutoCompleteCustomSource.Clear();
            for (int lCount = 0; lCount <= argTable.Rows.Count - 1; lCount++)
            {
                argObject.AutoCompleteCustomSource.Add(argTable.Rows[lCount][argField].ToString());
            }
         }

        public static DataTable AddSelectToDataTable(DataTable dt)
        {
            if (dt != null)
            {
                DataRow newRow = dt.NewRow();
                newRow[0] = -1;
                newRow[1] = "All";
                dt.Rows.InsertAt(newRow, 0);
            }
            return dt;
        }

        public static object IsNullCheck(object obj, datatypes ObjectType = datatypes.vartypestring)
        {
            object objReturn = null;
            objReturn = obj;
            if (ObjectType == datatypes.vartypestring & Information.IsDBNull(obj))
            {
                objReturn = "";
            }
            else if (ObjectType == datatypes.vartypenumeric)
            {
                if (Information.IsDBNull(obj) == true)
                {
                    objReturn = 0;
                }
                else if (Information.IsNumeric(obj) == false)
                {
                    objReturn = 0;
                }
            }
            else if (ObjectType == datatypes.VarTypeDate)
            {
                if (Information.IsDBNull(obj) == true)
                {
                    objReturn = DateTime.Now;
                }
                else if (Information.IsDate(obj) == false)
                {
                    objReturn = DateTime.Now;
                }
            }
            else if (ObjectType == datatypes.varTypeBoolean & Information.IsDBNull(obj))
            {
                objReturn = false;
            }
            return objReturn;
        }

        public static string Insert_SingleQuot(string strString)
        {
            string functionReturnValue = null;
            // ERROR: Not supported in C#: OnErrorStatement

            int lngTmp = 0;
            string strTmp = null;
            lngTmp = Strings.InStr(1, strString, "'", Constants.vbBinaryCompare);

            if (lngTmp <= 0)
            {
                functionReturnValue = strString;
                return functionReturnValue;
            }

            while (lngTmp > 0)
            {
                strTmp = Strings.Mid(strString, 1, lngTmp);
                strTmp = strTmp + "'";
                strTmp = strTmp + Strings.Mid(strString, lngTmp + 1);
                strString = strTmp;
                lngTmp = Strings.InStr(lngTmp + 2, strTmp, "'", Constants.vbBinaryCompare);
            }
            functionReturnValue = strString;
            return functionReturnValue;
        }
   }
