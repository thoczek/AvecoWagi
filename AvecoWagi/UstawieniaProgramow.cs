using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

//Ustawienia programów

//#####################

namespace WindowsFormsApplication1
{
	public partial class UstawieniaProgramow : Form
	{
		//Ustawienia programow
		UstProgramow
			UstProgP1,
			UstProgP2,
			UstProgP3,
			UstProgP4,
			UstProgP5;
		//########################

		public UstawieniaProgramow()
		{
			InitializeComponent();
		}

		private void UstawieniaProgramow_Load(object sender, EventArgs e)
		{
			cbProgram.Items.Clear();
			cbProgram.Items.Add("Program 1");
			cbProgram.Items.Add("Program 2");
			cbProgram.Items.Add("Program 3");
			cbProgram.Items.Add("Program 4");
			cbProgram.Items.Add("Program 5");
			try
			{
				StreamReader plikKonf = new StreamReader("awecowagiprogramy.cfg");
				//Wczytanie ustawien programu 1
				UstProgP1.CzRozpPoziomyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzRozpPoziomyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzRozpPoziomyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzRozpPionowyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzRozpPionowyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzRozpPionowyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzPomImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzPomImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.CzPomImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.IloscImpDozowania = Decimal.Parse(plikKonf.ReadLine());
				UstProgP1.IloscCykliPomiarowych = Decimal.Parse(plikKonf.ReadLine());

				//Wczytanie ustawien programu 2
				UstProgP2.CzRozpPoziomyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzRozpPoziomyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzRozpPoziomyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzRozpPionowyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzRozpPionowyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzRozpPionowyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzPomImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzPomImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.CzPomImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.IloscImpDozowania = Decimal.Parse(plikKonf.ReadLine());
				UstProgP2.IloscCykliPomiarowych = Decimal.Parse(plikKonf.ReadLine());

				//Wczytanie ustawien programu 3
				UstProgP3.CzRozpPoziomyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzRozpPoziomyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzRozpPoziomyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzRozpPionowyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzRozpPionowyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzRozpPionowyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzPomImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzPomImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.CzPomImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.IloscImpDozowania = Decimal.Parse(plikKonf.ReadLine());
				UstProgP3.IloscCykliPomiarowych = Decimal.Parse(plikKonf.ReadLine());

				//Wczytanie ustawien programu 4
				UstProgP4.CzRozpPoziomyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzRozpPoziomyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzRozpPoziomyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzRozpPionowyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzRozpPionowyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzRozpPionowyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzPomImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzPomImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.CzPomImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.IloscImpDozowania = Decimal.Parse(plikKonf.ReadLine());
				UstProgP4.IloscCykliPomiarowych = Decimal.Parse(plikKonf.ReadLine());

				//Wczytanie ustawien programu 5
				UstProgP5.CzRozpPoziomyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzRozpPoziomyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzRozpPoziomyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzRozpPionowyH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzRozpPionowyM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzRozpPionowyS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzPomImpDozH = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzPomImpDozM = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.CzPomImpDozS = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.IloscImpDozowania = Decimal.Parse(plikKonf.ReadLine());
				UstProgP5.IloscCykliPomiarowych = Decimal.Parse(plikKonf.ReadLine());

				plikKonf.Close();
			}
			catch 
			{
				//Ustawienia domyślne
				//Program 1
				UstProgP1.CzRozpPoziomyH = new Decimal(0);
				UstProgP1.CzRozpPoziomyM = new Decimal(0);
				UstProgP1.CzRozpPoziomyS = new Decimal(0);
				UstProgP1.CzRozpPionowyH = new Decimal(0);
				UstProgP1.CzRozpPionowyM = new Decimal(0);
				UstProgP1.CzRozpPionowyS = new Decimal(0);
				UstProgP1.CzImpDozH = new Decimal(0);
				UstProgP1.CzImpDozM = new Decimal(0);
				UstProgP1.CzImpDozS = new Decimal(0);
				UstProgP1.CzPomImpDozH = new Decimal(0);
				UstProgP1.CzPomImpDozM = new Decimal(0);
				UstProgP1.CzPomImpDozS = new Decimal(0);
				UstProgP1.IloscImpDozowania = new Decimal(1);
				UstProgP1.IloscCykliPomiarowych = new Decimal(1);

				//Program 2
				UstProgP2.CzRozpPoziomyH = new Decimal(0);
				UstProgP2.CzRozpPoziomyM = new Decimal(0);
				UstProgP2.CzRozpPoziomyS = new Decimal(0);
				UstProgP2.CzRozpPionowyH = new Decimal(0);
				UstProgP2.CzRozpPionowyM = new Decimal(0);
				UstProgP2.CzRozpPionowyS = new Decimal(0);
				UstProgP2.CzImpDozH = new Decimal(0);
				UstProgP2.CzImpDozM = new Decimal(0);
				UstProgP2.CzImpDozS = new Decimal(0);
				UstProgP2.CzPomImpDozH = new Decimal(0);
				UstProgP2.CzPomImpDozM = new Decimal(0);
				UstProgP2.CzPomImpDozS = new Decimal(0);
				UstProgP2.IloscImpDozowania = new Decimal(1);
				UstProgP2.IloscCykliPomiarowych = new Decimal(1);

				//Program 3
				UstProgP3.CzRozpPoziomyH = new Decimal(0);
				UstProgP3.CzRozpPoziomyM = new Decimal(0);
				UstProgP3.CzRozpPoziomyS = new Decimal(0);
				UstProgP3.CzRozpPionowyH = new Decimal(0);
				UstProgP3.CzRozpPionowyM = new Decimal(0);
				UstProgP3.CzRozpPionowyS = new Decimal(0);
				UstProgP3.CzImpDozH = new Decimal(0);
				UstProgP3.CzImpDozM = new Decimal(0);
				UstProgP3.CzImpDozS = new Decimal(0);
				UstProgP3.CzPomImpDozH = new Decimal(0);
				UstProgP3.CzPomImpDozM = new Decimal(0);
				UstProgP3.CzPomImpDozS = new Decimal(0);
				UstProgP3.IloscImpDozowania = new Decimal(1);
				UstProgP3.IloscCykliPomiarowych = new Decimal(1);

				//Program 4
				UstProgP4.CzRozpPoziomyH = new Decimal(0);
				UstProgP4.CzRozpPoziomyM = new Decimal(0);
				UstProgP4.CzRozpPoziomyS = new Decimal(0);
				UstProgP4.CzRozpPionowyH = new Decimal(0);
				UstProgP4.CzRozpPionowyM = new Decimal(0);
				UstProgP4.CzRozpPionowyS = new Decimal(0);
				UstProgP4.CzImpDozH = new Decimal(0);
				UstProgP4.CzImpDozM = new Decimal(0);
				UstProgP4.CzImpDozS = new Decimal(0);
				UstProgP4.CzPomImpDozH = new Decimal(0);
				UstProgP4.CzPomImpDozM = new Decimal(0);
				UstProgP4.CzPomImpDozS = new Decimal(0);
				UstProgP4.IloscImpDozowania = new Decimal(1);
				UstProgP4.IloscCykliPomiarowych = new Decimal(1);

				//Program 5
				UstProgP5.CzRozpPoziomyH = new Decimal(0);
				UstProgP5.CzRozpPoziomyM = new Decimal(0);
				UstProgP5.CzRozpPoziomyS = new Decimal(0);
				UstProgP5.CzRozpPionowyH = new Decimal(0);
				UstProgP5.CzRozpPionowyM = new Decimal(0);
				UstProgP5.CzRozpPionowyS = new Decimal(0);
				UstProgP5.CzImpDozH = new Decimal(0);
				UstProgP5.CzImpDozM = new Decimal(0);
				UstProgP5.CzImpDozS = new Decimal(0);
				UstProgP5.CzPomImpDozH = new Decimal(0);
				UstProgP5.CzPomImpDozM = new Decimal(0);
				UstProgP5.CzPomImpDozS = new Decimal(0);
				UstProgP5.IloscImpDozowania = new Decimal(1);
				UstProgP5.IloscCykliPomiarowych = new Decimal(1);
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ 
				CzRozpPoziomH.Value = UstProgP1.CzRozpPoziomyH;
				CzRozpPoziomM.Value = UstProgP1.CzRozpPoziomyM;
				CzRozpPoziomS.Value = UstProgP1.CzRozpPoziomyS;
				CzRozpPionH.Value = UstProgP1.CzRozpPionowyH;
				CzRozpPionM.Value = UstProgP1.CzRozpPionowyM;
				CzRozpPionS.Value = UstProgP1.CzRozpPionowyS;
				CzImpulsuH.Value = UstProgP1.CzImpDozH;
				CzImpulsuM.Value = UstProgP1.CzImpDozM;
				CzImpulsuS.Value = UstProgP1.CzImpDozS;
				CzPomImpulsamiH.Value = UstProgP1.CzPomImpDozH;
				CzPomImpulsamiM.Value = UstProgP1.CzPomImpDozM;
				CzPomImpulsamiS.Value = UstProgP1.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP1.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP1.IloscCykliPomiarowych;
			}
			else if (cbProgram.Text == "Program 2")
			{
				CzRozpPoziomH.Value = UstProgP2.CzRozpPoziomyH;
				CzRozpPoziomM.Value = UstProgP2.CzRozpPoziomyM;
				CzRozpPoziomS.Value = UstProgP2.CzRozpPoziomyS;
				CzRozpPionH.Value = UstProgP2.CzRozpPionowyH;
				CzRozpPionM.Value = UstProgP2.CzRozpPionowyM;
				CzRozpPionS.Value = UstProgP2.CzRozpPionowyS;
				CzImpulsuH.Value = UstProgP2.CzImpDozH;
				CzImpulsuM.Value = UstProgP2.CzImpDozM;
				CzImpulsuS.Value = UstProgP2.CzImpDozS;
				CzPomImpulsamiH.Value = UstProgP2.CzPomImpDozH;
				CzPomImpulsamiM.Value = UstProgP2.CzPomImpDozM;
				CzPomImpulsamiS.Value = UstProgP2.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP2.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP2.IloscCykliPomiarowych;
			}
			else if (cbProgram.Text == "Program 3")
			{ 
				CzRozpPoziomH.Value = UstProgP3.CzRozpPoziomyH;
				CzRozpPoziomM.Value = UstProgP3.CzRozpPoziomyM;
				CzRozpPoziomS.Value = UstProgP3.CzRozpPoziomyS;
				CzRozpPionH.Value = UstProgP3.CzRozpPionowyH;
				CzRozpPionM.Value = UstProgP3.CzRozpPionowyM;
				CzRozpPionS.Value = UstProgP3.CzRozpPionowyS;
				CzImpulsuH.Value = UstProgP3.CzImpDozH;
				CzImpulsuM.Value = UstProgP3.CzImpDozM;
				CzImpulsuS.Value = UstProgP3.CzImpDozS;
				CzPomImpulsamiH.Value = UstProgP3.CzPomImpDozH;
				CzPomImpulsamiM.Value = UstProgP3.CzPomImpDozM;
				CzPomImpulsamiS.Value = UstProgP3.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP3.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP3.IloscCykliPomiarowych;
			}
			else if (cbProgram.Text == "Program 4")
			{ 
				CzRozpPoziomH.Value = UstProgP4.CzRozpPoziomyH;
				CzRozpPoziomM.Value = UstProgP4.CzRozpPoziomyM;
				CzRozpPoziomS.Value = UstProgP4.CzRozpPoziomyS;
				CzRozpPionH.Value = UstProgP4.CzRozpPionowyH;
				CzRozpPionM.Value = UstProgP4.CzRozpPionowyM;
				CzRozpPionS.Value = UstProgP4.CzRozpPionowyS;
				CzImpulsuH.Value = UstProgP4.CzImpDozH;
				CzImpulsuM.Value = UstProgP4.CzImpDozM;
				CzImpulsuS.Value = UstProgP4.CzImpDozS;
				CzPomImpulsamiH.Value = UstProgP4.CzPomImpDozH;
				CzPomImpulsamiM.Value = UstProgP4.CzPomImpDozM;
				CzPomImpulsamiS.Value = UstProgP4.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP4.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP4.IloscCykliPomiarowych;
			}
			else if (cbProgram.Text == "Program 5")
			{ 
				CzRozpPoziomH.Value = UstProgP5.CzRozpPoziomyH;
				CzRozpPoziomM.Value = UstProgP5.CzRozpPoziomyM;
				CzRozpPoziomS.Value = UstProgP5.CzRozpPoziomyS;
				CzRozpPionH.Value = UstProgP5.CzRozpPionowyH;
				CzRozpPionM.Value = UstProgP5.CzRozpPionowyM;
				CzRozpPionS.Value = UstProgP5.CzRozpPionowyS;
				CzImpulsuH.Value = UstProgP5.CzImpDozH;
				CzImpulsuM.Value = UstProgP5.CzImpDozM;
				CzImpulsuS.Value = UstProgP5.CzImpDozS;
				CzPomImpulsamiH.Value = UstProgP5.CzPomImpDozH;
				CzPomImpulsamiM.Value = UstProgP5.CzPomImpDozM;
				CzPomImpulsamiS.Value = UstProgP5.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP5.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP5.IloscCykliPomiarowych;
			}

		}

		private void btZapisz_Click(object sender, EventArgs e)
		{
			try
			{
				StreamWriter plikKonf = new StreamWriter("awecowagiprogramy.cfg");

				plikKonf.Write(UstProgP1.CzRozpPoziomyH.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzRozpPoziomyM.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzRozpPoziomyS.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzRozpPionowyH.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzRozpPionowyM.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzRozpPionowyS.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzPomImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzPomImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP1.CzPomImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP1.IloscImpDozowania.ToString()+"\n");
				plikKonf.Write(UstProgP1.IloscCykliPomiarowych.ToString()+"\n");

				plikKonf.Write(UstProgP2.CzRozpPoziomyH.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzRozpPoziomyM.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzRozpPoziomyS.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzRozpPionowyH.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzRozpPionowyM.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzRozpPionowyS.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzPomImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzPomImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP2.CzPomImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP2.IloscImpDozowania.ToString()+"\n");
				plikKonf.Write(UstProgP2.IloscCykliPomiarowych.ToString()+"\n");

				plikKonf.Write(UstProgP3.CzRozpPoziomyH.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzRozpPoziomyM.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzRozpPoziomyS.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzRozpPionowyH.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzRozpPionowyM.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzRozpPionowyS.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzPomImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzPomImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP3.CzPomImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP3.IloscImpDozowania.ToString()+"\n");
				plikKonf.Write(UstProgP3.IloscCykliPomiarowych.ToString()+"\n");

				plikKonf.Write(UstProgP4.CzRozpPoziomyH.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzRozpPoziomyM.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzRozpPoziomyS.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzRozpPionowyH.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzRozpPionowyM.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzRozpPionowyS.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzPomImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzPomImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP4.CzPomImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP4.IloscImpDozowania.ToString()+"\n");
				plikKonf.Write(UstProgP4.IloscCykliPomiarowych.ToString()+"\n");

				plikKonf.Write(UstProgP5.CzRozpPoziomyH.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzRozpPoziomyM.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzRozpPoziomyS.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzRozpPionowyH.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzRozpPionowyM.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzRozpPionowyS.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzPomImpDozH.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzPomImpDozM.ToString()+"\n");
				plikKonf.Write(UstProgP5.CzPomImpDozS.ToString()+"\n");
				plikKonf.Write(UstProgP5.IloscImpDozowania.ToString()+"\n");
				plikKonf.Write(UstProgP5.IloscCykliPomiarowych.ToString()+"\n");
				plikKonf.Close();
			}
			catch { MessageBox.Show("Błąd zapisu pliku konfiguracjnego"); }
		}

		private void btOk_Click(object sender, EventArgs e)
		{
			btZapisz_Click(sender, e);
			this.Close();
		}

		private void btAnuluj_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void CzRozpPoziomH_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzRozpPoziomyH = CzRozpPoziomH.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzRozpPoziomyH = CzRozpPoziomH.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzRozpPoziomyH = CzRozpPoziomH.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzRozpPoziomyH = CzRozpPoziomH.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzRozpPoziomyH = CzRozpPoziomH.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }

		}

		private void CzRozpPoziomM_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzRozpPoziomyM = CzRozpPoziomM.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzRozpPoziomyM = CzRozpPoziomM.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzRozpPoziomyM = CzRozpPoziomM.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzRozpPoziomyM = CzRozpPoziomM.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzRozpPoziomyM = CzRozpPoziomM.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzRozpPoziomS_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzRozpPoziomyS = CzRozpPoziomS.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzRozpPoziomyS = CzRozpPoziomS.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzRozpPoziomyS = CzRozpPoziomS.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzRozpPoziomyS = CzRozpPoziomS.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzRozpPoziomyS = CzRozpPoziomS.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzRozpPionH_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzRozpPionowyH = CzRozpPionH.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzRozpPionowyH = CzRozpPionH.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzRozpPionowyH = CzRozpPionH.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzRozpPionowyH = CzRozpPionH.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzRozpPionowyH = CzRozpPionH.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzRozpPionM_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzRozpPionowyM = CzRozpPionM.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzRozpPionowyM = CzRozpPionM.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzRozpPionowyM = CzRozpPionM.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzRozpPionowyM = CzRozpPionM.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzRozpPionowyM = CzRozpPionM.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzRozpPionS_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzRozpPionowyS = CzRozpPionS.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzRozpPionowyS = CzRozpPionS.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzRozpPionowyS = CzRozpPionS.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzRozpPionowyS = CzRozpPionS.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzRozpPionowyS = CzRozpPionS.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzImpulsuH_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzImpDozH = CzImpulsuH.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzImpDozH = CzImpulsuH.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzImpDozH = CzImpulsuH.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzImpDozH = CzImpulsuH.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzImpDozH = CzImpulsuH.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzImpulsuM_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzImpDozM = CzImpulsuM.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzImpDozM = CzImpulsuM.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzImpDozM = CzImpulsuM.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzImpDozM = CzImpulsuM.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzImpDozM = CzImpulsuM.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzImpulsuS_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzImpDozS = CzImpulsuS.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzImpDozS = CzImpulsuS.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzImpDozS = CzImpulsuS.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzImpDozS = CzImpulsuS.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzImpDozS = CzImpulsuS.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzPomImpulsamiH_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzPomImpDozH = CzPomImpulsamiH.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzPomImpDozH = CzPomImpulsamiH.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzPomImpDozH = CzPomImpulsamiH.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzPomImpDozH = CzPomImpulsamiH.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzPomImpDozH = CzPomImpulsamiH.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzPomImpulsamiM_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzPomImpDozM = CzPomImpulsamiM.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzPomImpDozM = CzPomImpulsamiM.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzPomImpDozM = CzPomImpulsamiM.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzPomImpDozM = CzPomImpulsamiM.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzPomImpDozM = CzPomImpulsamiM.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void CzPomImpulsamiS_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.CzPomImpDozS = CzPomImpulsamiS.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.CzPomImpDozS = CzPomImpulsamiS.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.CzPomImpDozS = CzPomImpulsamiS.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.CzPomImpDozS = CzPomImpulsamiS.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.CzPomImpDozS = CzPomImpulsamiS.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void numIlImpDozowania_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.IloscImpDozowania = numIlImpDozowania.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.IloscImpDozowania = numIlImpDozowania.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.IloscImpDozowania = numIlImpDozowania.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.IloscImpDozowania = numIlImpDozowania.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.IloscImpDozowania = numIlImpDozowania.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		private void numIlCykliPom_ValueChanged(object sender, EventArgs e)
		{
			if (cbProgram.Text == "Program 1")
			{ UstProgP1.IloscCykliPomiarowych = numIlCykliPom.Value; }
			else if (cbProgram.Text == "Program 2")
			{ UstProgP2.IloscCykliPomiarowych = numIlCykliPom.Value; }
			else if (cbProgram.Text == "Program 3")
			{ UstProgP3.IloscCykliPomiarowych = numIlCykliPom.Value; }
			else if (cbProgram.Text == "Program 4")
			{ UstProgP4.IloscCykliPomiarowych = numIlCykliPom.Value; }
			else if (cbProgram.Text == "Program 5")
			{ UstProgP5.IloscCykliPomiarowych = numIlCykliPom.Value; }
			else { MessageBox.Show("Wybierz Program do konfiguracji"); }
		}

		
	}
}
