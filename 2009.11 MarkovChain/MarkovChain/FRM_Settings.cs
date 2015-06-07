using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MarkovChain
{
	public partial class FRM_Settings : Form
	{
		public Form1 parent;

		public FRM_Settings()
		{
			InitializeComponent();
		}

		private void FRM_Settings_FormClosed(object sender, FormClosedEventArgs e)
		{
			parent.frmSettings = null;
		}

		private void NUD_DecimalPoints_ValueChanged(object sender, EventArgs e)
		{
			parent.format = "F" + NUD_DecimalPoints.Value;
		}

		private void BTN_OK_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void FRM_Settings_Enter(object sender, EventArgs e)
		{
			NUD_DecimalPoints.Value = int.Parse(parent.format.Remove(0, 1));
			CHB_Logging.Checked = parent.logging;
		}

		private void FRM_Settings_VisibleChanged(object sender, EventArgs e)
		{
			FRM_Settings_Enter(null, null);
		}

		private void CHB_Logging_CheckedChanged(object sender, EventArgs e)
		{
			parent.logging = CHB_Logging.Checked;
		}
	}
}
