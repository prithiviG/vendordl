using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Vendor
{
    public class mflDataGrid : System.Windows.Forms.DataGridView
    {
        // controls whether or not the TenKeyDataGrid should remap the ENTER key
        // to the TAB key. 
        public bool ShouldRemapEnterKey;

        private System.Windows.Forms.Keys RemapEnterKey(System.Windows.Forms.Keys keyData)
        {
            // check whether or not we should do key reassignment. If we shouldn't
            // remap the enter key, return the original key data. 
            /*if (!ShouldRemapEnterkey)
            {
                return keyData;
            }*/
            System.Windows.Forms.Keys outputKeys = keyData;
            // determine if the enter key is in the key data. If not, no need to do anything.
            if ((keyData & System.Windows.Forms.Keys.Enter) == System.Windows.Forms.Keys.Enter)
            {
                // toggle the enter key off
                outputKeys = keyData ^ System.Windows.Forms.Keys.Enter;
                // turn the tab key on, regardless of whether or not it's already on.
                outputKeys = outputKeys | System.Windows.Forms.Keys.Tab;
            }
            return outputKeys;
        }
        protected override bool ProcessDialogKey(System.Windows.Forms.Keys keyData)
        {
            return base.ProcessDialogKey(RemapEnterKey(keyData));
        }
        protected override bool ProcessDataGridViewKey(System.Windows.Forms.KeyEventArgs e)
        {
            // for ProcessDataGridViewKey, which receives KeyEventArgs rather than Keys, 
            // create a temporary KeyEventArgs with the new key data bitflag. We'll need to  
            // set existing Handled or SuppressKeyPress values for the new event handler
            // and retain any changes made by ProcessDataGridViewKey. 
            System.Windows.Forms.KeyEventArgs ex = new System.Windows.Forms.KeyEventArgs(RemapEnterKey(e.KeyData));
            ex.Handled = e.Handled;
            ex.SuppressKeyPress = e.SuppressKeyPress;
            bool returnVal = base.ProcessDataGridViewKey(ex);
            e.Handled = ex.Handled;
            e.SuppressKeyPress = ex.SuppressKeyPress;
            return returnVal;
        }
    }
}
