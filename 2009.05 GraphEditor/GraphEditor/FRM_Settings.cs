using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraphEditor
{
	public partial class TFRM_Settings : Form
	{
		public TFRM_Settings()
		{
			InitializeComponent();
		}

		private void TFRM_Settings_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Visible = false;
		}

		private void BTN_Apply_Click(object sender, EventArgs e)
		{
			
			FRM_MainForm.graph.stepX = Convert.ToInt32(NUD_StepX.Value);
			FRM_MainForm.graph.stepY = Convert.ToInt32(NUD_StepY.Value);

			FRM_MainForm.graph.DrawDescr = RB_Descr.Checked;

			FRM_MainForm.graph.Width = Convert.ToInt32(NUD_Width.Value);
			FRM_MainForm.graph.Height = Convert.ToInt32(NUD_Height.Value);

			FRM_MainForm.PB_Graph.Height = FRM_MainForm.graph.SizeInPixels.Y;
			FRM_MainForm.PB_Graph.Width = FRM_MainForm.graph.SizeInPixels.X;
            FRM_MainForm.graph.FormatString = TB_Format.Text;
			//FRM_MainForm.PB_Graph.Refresh();
			FRM_MainForm.PB_Graph.Refresh();
		}

		private void TFRM_Settings_VisibleChanged(object sender, EventArgs e)
		{
			TFRM_Settings_Activated(null, null);
		}

		private void BTN_OK_Click(object sender, EventArgs e)
		{
			BTN_Apply_Click(null, null);
			BTN_Cancel_Click(null, null);
		}

		private void BTN_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void CHB_DebugMode_CheckedChanged(object sender, EventArgs e)
		{
			FRM_MainForm.DebugMode = CHB_DebugMode.Checked;
		}

		private void TFRM_Settings_Activated(object sender, EventArgs e)
		{
			NUD_Height.Minimum = FRM_MainForm.graph.HeightMin;
			NUD_Height.Value = FRM_MainForm.graph.Height;
			NUD_Width.Minimum = FRM_MainForm.graph.WidthMin;
			NUD_Width.Value = FRM_MainForm.graph.Width;
			NUD_StepX.Value = FRM_MainForm.graph.stepX;
			NUD_StepY.Value = FRM_MainForm.graph.stepY;
			RB_Descr.Checked = FRM_MainForm.graph.DrawDescr;
			RB_Value.Checked = !FRM_MainForm.graph.DrawDescr;
			//NUD_Height.Increment = NUD_StepY.Value;
			//NUD_Width.Increment = NUD_StepX.Value;
			CHB_DebugMode.Checked = FRM_MainForm.DebugMode;
		}

	}
}
