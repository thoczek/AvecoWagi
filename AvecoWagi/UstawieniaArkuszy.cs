using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
	public partial class UstawieniaArkuszy : Form
	{
		OpenFileDialog openFileDial = new OpenFileDialog();

		public UstawieniaArkuszy()
		{
			InitializeComponent();
		}
		private void UstawieniaArkuszy_Load(object sender, EventArgs e)
		{
			openFileDial.Filter = "Exel files|*.xls";

			try
			{
				StreamReader plik = new StreamReader("awecowagiarkusze.cfg");
				tbSciezkaP1.Text = plik.ReadLine();
				tbPozX1.Text = plik.ReadLine();
				tbPozY1.Text = plik.ReadLine();
				tbT6PozX1.Text = plik.ReadLine();
				tbT6PozY1.Text = plik.ReadLine();

				tbSciezkaP2.Text = plik.ReadLine();
				tbPozX2.Text = plik.ReadLine();
				tbPozY2.Text = plik.ReadLine();
				tbT6PozX2.Text = plik.ReadLine();
				tbT6PozY2.Text = plik.ReadLine();

				tbSciezkaP3.Text = plik.ReadLine();
				tbPozX3.Text = plik.ReadLine();
				tbPozY3.Text = plik.ReadLine();
				tbT6PozX3.Text = plik.ReadLine();
				tbT6PozY3.Text = plik.ReadLine();

				tbSciezkaP4.Text = plik.ReadLine();
				tbPozX4.Text = plik.ReadLine();
				tbPozY4.Text = plik.ReadLine();
				tbT6PozX4.Text = plik.ReadLine();
				tbT6PozY4.Text = plik.ReadLine();

				tbSciezkaP5.Text = plik.ReadLine();
				tbPozX5.Text = plik.ReadLine();
				tbPozY5.Text = plik.ReadLine();
				tbT6PozX5.Text = plik.ReadLine();
				tbT6PozY5.Text = plik.ReadLine();

				plik.Close();
				plik.Dispose();
			}
			catch { }
		}
		private void button1_Click(object sender, EventArgs e)
		{
			string tempPath;
			tempPath = System.Environment.CurrentDirectory;
			//openFileDial.Filter = "Exel files|*.txt";
			openFileDial.ShowDialog();
			System.Environment.CurrentDirectory = tempPath;
			tbSciezkaP1.Text = openFileDial.FileName;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			string tempPath;
			tempPath = System.Environment.CurrentDirectory;
			//openFileDial.Filter = "Exel files|*.txt";
			openFileDial.ShowDialog();
			System.Environment.CurrentDirectory = tempPath;
			tbSciezkaP2.Text = openFileDial.FileName;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			string tempPath;
			tempPath = System.Environment.CurrentDirectory;
			//openFileDial.Filter = "Exel files|*.txt";
			openFileDial.ShowDialog();
			System.Environment.CurrentDirectory = tempPath;
			tbSciezkaP3.Text = openFileDial.FileName;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			string tempPath;
			tempPath = System.Environment.CurrentDirectory;
			//openFileDial.Filter = "Exel files|*.txt";
			openFileDial.ShowDialog();
			System.Environment.CurrentDirectory = tempPath;
			tbSciezkaP4.Text = openFileDial.FileName;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			string tempPath;
			tempPath = System.Environment.CurrentDirectory;
			//openFileDial.Filter = "Exel files|*.txt";
			openFileDial.ShowDialog();
			System.Environment.CurrentDirectory = tempPath;
			tbSciezkaP5.Text = openFileDial.FileName;
		}

		private void btAnuluj_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btOK_Click(object sender, EventArgs e)
		{
			btZapisz_Click(sender, e);
			this.Close();
		}

		private void btZapisz_Click(object sender, EventArgs e)
		{
			StreamWriter plik;
			plik = new StreamWriter("awecowagiarkusze.cfg");
			plik.Write(tbSciezkaP1.Text + "\n");
			plik.Write(tbPozX1.Text + "\n");
			plik.Write(tbPozY1.Text+ "\n");
			plik.Write(tbT6PozX1.Text+"\n");
			plik.Write(tbT6PozY1.Text+"\n");

			plik.Write(tbSciezkaP2.Text + "\n");
			plik.Write(tbPozX2.Text + "\n");
			plik.Write(tbPozY2.Text + "\n");
			plik.Write(tbT6PozX2.Text + "\n");
			plik.Write(tbT6PozY2.Text + "\n");

			plik.Write(tbSciezkaP3.Text + "\n");
			plik.Write(tbPozX3.Text + "\n");
			plik.Write(tbPozY3.Text + "\n");
			plik.Write(tbT6PozX3.Text + "\n");
			plik.Write(tbT6PozY3.Text + "\n");

			plik.Write(tbSciezkaP4.Text + "\n");
			plik.Write(tbPozX4.Text + "\n");
			plik.Write(tbPozY4.Text + "\n");
			plik.Write(tbT6PozX4.Text + "\n");
			plik.Write(tbT6PozY4.Text + "\n");

			plik.Write(tbSciezkaP5.Text + "\n");
			plik.Write(tbPozX5.Text + "\n");
			plik.Write(tbPozY5.Text + "\n");
			plik.Write(tbT6PozX5.Text + "\n");
			plik.Write(tbT6PozY5.Text + "\n");

			plik.Close();
			plik.Dispose();
		}	
	}
}
