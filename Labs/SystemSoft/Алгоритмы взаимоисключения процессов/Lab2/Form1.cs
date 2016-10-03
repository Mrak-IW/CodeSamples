using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab2
{
	public partial class Form1 : Form
	{
		Method1 m1 = new Method1();
		Method2 m2 = new Method2();
        SemaphorProcess sr = new SemaphorProcess();
        SemaphorProcess sl = new SemaphorProcess();

		MethodPeterson mp1 = new MethodPeterson();
		MethodPeterson mp2 = new MethodPeterson();

		static Sema smf2 = new Sema();
		static Sema smf = new Sema();
		Producer prod = new Producer(smf, smf2);
		Consumer cons = new Consumer(smf, smf2);
		

		void renew1()
		{
			LB_1Left.SelectedIndex = m1.cntL;
			LB_1Right.SelectedIndex = m1.cntR; ;
			LBL_numProc.Text = "numProc = " + m1.numProc.ToString();
		}

		void renew2()
		{
			LB_2Left.SelectedIndex = m2.cnt[0];
			LB_2Right.SelectedIndex = m2.cnt[1];
			CB_2Left.Checked = m2.inProc[0];
			CB_2Right.Checked = m2.inProc[1];
		}

        void renewsem()
        {
            LB_SemLeft.SelectedIndex = sl.cnt;
            LB_SemRight.SelectedIndex = sr.cnt;
			Lbl_Semaphore.Text = "Семафор = " + SemaphorProcess.smf.ToString();
        }

		void renewpc()
		{
			LB_PCLeft.SelectedIndex = prod.cnt;
			LB_PCRight.SelectedIndex = cons.cnt;
			CB_PCsmf2.Checked = smf2.Value;
			CB_PCSmf.Checked = smf.Value;
			LBL_PCresCount.Text = "resCount = " + prod.resCount.ToString();
		}

		void renewpetersen()
		{
			LB_PLeft.SelectedIndex = mp1.cnt;
			LB_PRight.SelectedIndex = mp2.cnt;
			ChB_Pinproc0.Checked = MethodPeterson.inProc[0];
			ChB_Pinproc1.Checked = MethodPeterson.inProc[1];
			LBL_PnumProc.Text = MethodPeterson.numProc.ToString();
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			m1.reset();
			//Инициализация метода 1
			foreach (string s in m1.textL)
				LB_1Left.Items.Add(s);
			foreach (string s in m1.textR)
				LB_1Right.Items.Add(s);
			//Инициализация метода 2
			foreach (string s in m2.text0)
				LB_2Left.Items.Add(s);
			foreach (string s in m2.text1)
				LB_2Right.Items.Add(s);
			//Инициализация метода Петерсона
			foreach (string s in mp1.text)
				LB_PLeft.Items.Add(s);
			foreach (string s in mp2.text)
				LB_PRight.Items.Add(s);
            //Инициализация семафоров
            foreach (string s in sl.text)
                LB_SemLeft.Items.Add(s);
            foreach (string s in sr.text)
                LB_SemRight.Items.Add(s);
			//Инициализация потребитель - производитель
			foreach (string s in prod.text)
				LB_PCLeft.Items.Add(s);
			foreach (string s in cons.text)
				LB_PCRight.Items.Add(s);
			cons.prod = prod;
			smf.signal();
			smf2.reset();

			renew1();
			renew2();
            renewsem();
			renewpc();
			renewpetersen();
		}

		private void BTN_1Reset_Click(object sender, EventArgs e)
		{
			m1.reset();
			renew1();
		}

		private void BTN_1LeftProcess_Click(object sender, EventArgs e)
		{
			m1.nextLeft();
			renew1();
		}

		private void BTN_1RightProcess_Click(object sender, EventArgs e)
		{
			m1.nextRight();
			renew1();
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			label1.Text = (sender as ListBox).SelectedIndex.ToString();
		}

		private void BTN_2Left_Click(object sender, EventArgs e)
		{
			m2.next0();
			renew2();
		}

		private void BTN_2Right_Click(object sender, EventArgs e)
		{
			m2.next1();
			renew2();
		}

        private void BTN_2Reset_Click(object sender, EventArgs e)
        {
            m2.reset();
            renew2();
        }

        private void Btn_semLeft_Click(object sender, EventArgs e)
        {
            sl.next();
            renewsem();
            label4.Text = LB_SemLeft.SelectedIndex.ToString();
        }

        private void Btn_semRight_Click(object sender, EventArgs e)
        {
            sr.next();
            renewsem();
            label4.Text = LB_SemRight.SelectedIndex.ToString();
        }

        private void Btn_semReset_Click(object sender, EventArgs e)
        {
            sr.reset();
            sl.reset();
            renewsem();
        }

		private void BTN_PCLeft_Click(object sender, EventArgs e)
		{
			prod.next();
			renewpc();
			label5.Text = LB_PCLeft.SelectedIndex.ToString();
		}

		private void BTN_PCRight_Click(object sender, EventArgs e)
		{
			cons.next();
			renewpc();
			label5.Text = LB_PCRight.SelectedIndex.ToString();
		}

		private void BTN_PCReset_Click(object sender, EventArgs e)
		{
			cons.reset();
			prod.reset();
			renewpc();
		}

		private void BTN_PLeft_Click(object sender, EventArgs e)
		{
			mp1.next();
			renewpetersen();
			label2.Text = LB_PLeft.SelectedIndex.ToString();
		}

		private void BTN_PRight_Click(object sender, EventArgs e)
		{
			mp2.next();
			renewpetersen();
			label2.Text = LB_PRight.SelectedIndex.ToString();
		}

		private void BTN_ResetPeterson_Click(object sender, EventArgs e)
		{
			mp1.reset();
			mp2.reset();
			renewpetersen();
		}
	}
}
