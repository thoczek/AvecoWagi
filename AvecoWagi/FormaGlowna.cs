using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.IO.Ports;
using UnCmDrv1;

//Excel ustawienia arkuszy
public struct UstExel
{
	public string
		PlikSzablonu,
		WspolzedneX,
		WspolzedneY,
		T6WspolzedneX,
		T6WspolzedneY;
}
//#############################

//Ustawienia programów
public struct UstProgramow
{
	public decimal CzRozpPoziomyH,
		CzRozpPoziomyM,
		CzRozpPoziomyS,
		CzRozpPionowyH,
		CzRozpPionowyM,
		CzRozpPionowyS,
		CzImpDozH,
		CzImpDozM,
		CzImpDozS,
		CzPomImpDozH,
		CzPomImpDozM,
		CzPomImpDozS,
		IloscImpDozowania,
		IloscCykliPomiarowych;
}
//
namespace WindowsFormsApplication1
{
    public partial class FormaGlowna : Form
    {
        UnCmDrv1.clsCommDriverClass driverSter = new UnCmDrv1.clsCommDriverClass();
        UnCmDrv1.tPC_CommSettings comSettingsSter = new tPC_CommSettings();
        UnCmDrv1.enPortNumber comPortNumberSter;


		public bool
			ZnSTOP = false,
			ZnDoPozycji = false,
            ZmKomZSter = false,
            ZmWaga1Zajeta = false,
            ZmWaga2Zajeta = false,
            ZmWaga3Zajeta = false,
            ZmWaga1Odczytana = false,
            ZmWaga2Odczytana = false,
            ZmWaga3Odczytana = false;

        public string
            OdczytWagi1 = "0",
            OdczytWagi2 = "0",
            OdczytWagi3 = "0";

        //Deklarowanie domyślnych parametrów połączeń
        public string PortSter = "Brak",
            PredkoscSter = "",
            BityDanychSter = "",
            ParzystoscSter = "",
            BityStopuSter = "",
            PortWaga1 = "Brak",
            PredkoscWaga1 = "",
            BityDanychWaga1 = "",
            ParzystoscWaga1 = "",
            BityStopuWaga1 = "",
            PortWaga2 = "Brak",
            PredkoscWaga2 = "",
            BityDanychWaga2 = "",
            ParzystoscWaga2 = "",
            BityStopuWaga2 = "",
            PortWaga3 = "Brak",
            PredkoscWaga3 = "",
            BityDanychWaga3 = "",
            ParzystoscWaga3 = "",
            BityStopuWaga3 = "";
		//#############################

		//Ustawienia arkuszy exela
		UstExel
			UstExelP1,
			UstExelP2,
			UstExelP3,
			UstExelP4,
			UstExelP5,
			UstExelAktualne;
		//########################

		//Ustawienia programow
		UstProgramow
			UstProgP1,
			UstProgP2,
			UstProgP3,
			UstProgP4,
			UstProgP5;
		//########################

		//Zmienne do sprawdzenia obecnosci plików konfiguracyjnych
		bool ObecnoscPlikuKonfPortow = false;
		bool ObecnoscPlikuKonfArkuszy = false;
		bool ObecnoscPlikuKonfProgramy = false;
		//#############################


        public FormaGlowna()
        {
            InitializeComponent();
        }

		public void temp()
		{
			string[] row = {	"a", 
								"b", 
								"c" 
							};
			dataGridView1.Rows.Add(row);
		
		}

        private void Form1_Load(object sender, EventArgs e)
        {
			ObecnoscPlikuKonfPortow = false;
			ObecnoscPlikuKonfArkuszy = false;
			ObecnoscPlikuKonfProgramy = false;
			PortSter = "Brak";
			PortWaga1 = "Brak";
			PortWaga2 = "Brak";
			PortWaga3 = "Brak";

            //Ładowanie ustawień z pliku konfiguracyjnego
			CzytajPlikUstawienPortow();
            //--------------------------------------

            //Jeżeli istnieje plik konfiguracyjny to załaduj ustawienia:
            if (ObecnoscPlikuKonfPortow)
            {
				UstawPortSterownika();
				UstawPortWagi1();
				UstawPortWagi2();
				UstawPortWagi3();
            }
			//################################
			CzytajPlikUstawienArkuszy();

			CzytajUstawieniaProgramow();

			temp();
        }

		//Załaduj ustawienia portów z pliku konfiguracyjnego
		private void CzytajPlikUstawienPortow()
		{
			try
			{
				//Port sterownika
				StreamReader plikKonf = new StreamReader("awecowagi.cfg");
				PortSter = plikKonf.ReadLine();
				PredkoscSter = plikKonf.ReadLine();
				BityDanychSter = plikKonf.ReadLine();
				ParzystoscSter = plikKonf.ReadLine();
				BityStopuSter = plikKonf.ReadLine();
				//--------------------------------------
				//Port wagi 1
				PortWaga1 = plikKonf.ReadLine();
				PredkoscWaga1 = plikKonf.ReadLine();
				BityDanychWaga1 = plikKonf.ReadLine();
				ParzystoscWaga1 = plikKonf.ReadLine();
				BityStopuWaga1 = plikKonf.ReadLine();
				//--------------------------------------
				//Port wagi 2
				PortWaga2 = plikKonf.ReadLine();
				PredkoscWaga2 = plikKonf.ReadLine();
				BityDanychWaga2 = plikKonf.ReadLine();
				ParzystoscWaga2 = plikKonf.ReadLine();
				BityStopuWaga2 = plikKonf.ReadLine();
				//--------------------------------------
				//Port wagi 3
				PortWaga3 = plikKonf.ReadLine();
				PredkoscWaga3 = plikKonf.ReadLine();
				BityDanychWaga3 = plikKonf.ReadLine();
				ParzystoscWaga3 = plikKonf.ReadLine();
				BityStopuWaga3 = plikKonf.ReadLine();
				//--------------------------------------
				//Zamkniecie pliku i zwolnienie zasobów.
				plikKonf.Close();
				plikKonf.Dispose();
				ObecnoscPlikuKonfPortow = true;
				//--------------------------------------
			}
			catch { ObecnoscPlikuKonfPortow = false; }
		}
		//###########################################

		//Ustaw port sterownika
		private void UstawPortSterownika()
		{
			if (ObecnoscPlikuKonfPortow)
			{
				//Ładowanie numeru portu sterownika.
				if (PortSter == "COM1")
				{ comPortNumberSter = enPortNumber.eCOM1; }
				else if (PortSter == "COM2")
				{ comPortNumberSter = enPortNumber.eCOM2; }
				else if (PortSter == "COM3")
				{ comPortNumberSter = enPortNumber.eCOM3; }
				else if (PortSter == "COM4")
				{ comPortNumberSter = enPortNumber.eCOM4; }
				else if (PortSter == "COM5")
				{ comPortNumberSter = enPortNumber.eCOM5; }
				else if (PortSter == "COM6")
				{ comPortNumberSter = enPortNumber.eCOM6; }
				else if (PortSter == "COM7")
				{ comPortNumberSter = enPortNumber.eCOM7; }
				else if (PortSter == "COM8")
				{ comPortNumberSter = enPortNumber.eCOM8; }
				else if (PortSter == "COM9")
				{ comPortNumberSter = enPortNumber.eCOM9; }
				else if (PortSter == "COM10")
				{ comPortNumberSter = enPortNumber.eCOM10; }
				else if (PortSter == "COM11")
				{ comPortNumberSter = enPortNumber.eCOM11; }
				else if (PortSter == "COM12")
				{ comPortNumberSter = enPortNumber.eCOM12; }
				else if (PortSter == "COM13")
				{ comPortNumberSter = enPortNumber.eCOM13; }
				else if (PortSter == "COM14")
				{ comPortNumberSter = enPortNumber.eCOM14; }
				else if (PortSter == "COM15")
				{ comPortNumberSter = enPortNumber.eCOM15; }
				else if (PortSter == "COM16")
				{ comPortNumberSter = enPortNumber.eCOM16; }
				//--------------------------------------

				//Ładowanie predkości połaczenia sterownika
				if (PredkoscSter == "300")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_300; }
				else if (PredkoscSter == "600")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_600; }
				else if (PredkoscSter == "1200")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_1200; }
				else if (PredkoscSter == "2400")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_2400; }
				else if (PredkoscSter == "4800")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_4800; }
				else if (PredkoscSter == "9600")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_9600; }
				else if (PredkoscSter == "19200")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_19200; }
				else if (PredkoscSter == "38400")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_38400; }
				else if (PredkoscSter == "57600")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_57600; }
				else if (PredkoscSter == "115200")
				{ comSettingsSter.Baudrate = enBaudRate.eBR_115200; }
				//--------------------------------------

				//Ładowanie ilości bitów danych dla sterowanika
				if (BityDanychSter == "7")
				{ comSettingsSter.DataBits = enDataBits.eDB_7; }
				else if (BityDanychSter == "8")
				{ comSettingsSter.DataBits = enDataBits.eDB_8; }
				//--------------------------------------

				//Ładowanie ustawień parzystości dla portu sterownika
				if (ParzystoscSter == "Even")
				{ comSettingsSter.Parity = enParity.eP_Even; }
				else if (ParzystoscSter == "None")
				{ comSettingsSter.Parity = enParity.eP_None; }
				else if (ParzystoscSter == "Odd")
				{ comSettingsSter.Parity = enParity.eP_Odd; }
				//--------------------------------------

				//Ładowanie ilości bitów stopu dla portu sterownika
				if (BityStopuSter == "One")
				{ comSettingsSter.StopBits = enStopBits.eSB_1; }
				else if (BityStopuSter == "Two")
				{ comSettingsSter.StopBits = enStopBits.eSB_2; }
				//--------------------------------------

				//Pozostałe ustawienia portu sterownika
				comSettingsSter.Retries = 3;
				comSettingsSter.TimeOut = 50;
				//--------------------------------------
			}
		}
		//################################

		//Ustawianie portów wag
		private void UstawPortWagi1()
		{
			if (ObecnoscPlikuKonfPortow)
			{
				//Ładowanie ustawień wagi 1
				if (PortWaga1 != "Brak")
				{
					serialPort1.PortName = PortWaga1;
					serialPort1.BaudRate = Int32.Parse(PredkoscWaga1);
					if (ParzystoscWaga1 == "Even")
					{ serialPort1.Parity = Parity.Even; }
					else if (ParzystoscWaga1 == "Mark")
					{ serialPort1.Parity = Parity.Mark; }
					else if (ParzystoscWaga1 == "None")
					{ serialPort1.Parity = Parity.None; }
					else if (ParzystoscWaga1 == "Odd")
					{ serialPort1.Parity = Parity.Odd; }
					else if (ParzystoscWaga1 == "Space")
					{ serialPort1.Parity = Parity.Space; }
					serialPort1.DataBits = Int32.Parse(BityDanychWaga1);
					if (BityStopuWaga1 == "None")
					{ serialPort1.StopBits = StopBits.None; }
					else if (BityStopuWaga1 == "One")
					{ serialPort1.StopBits = StopBits.One; }
					else if (BityStopuWaga1 == "OnePointFive")
					{ serialPort1.StopBits = StopBits.OnePointFive; }
					else if (BityStopuWaga1 == "Two")
					{ serialPort1.StopBits = StopBits.Two; }
					serialPort1.ReadTimeout = 50;
					serialPort1.WriteTimeout = 50;
					serialPort1.Handshake = Handshake.None;
					serialPort1.NewLine = "" + (char)13 + (char)10;
				}
			}
		}
		private void UstawPortWagi2()
		{
			if (ObecnoscPlikuKonfPortow)
			{
				//Ładowanie ustawień wagi 2
				if (PortWaga2 != "Brak")
				{
					serialPort2.PortName = PortWaga2;
					serialPort2.BaudRate = Int32.Parse(PredkoscWaga2);
					if (ParzystoscWaga2 == "Even")
					{ serialPort2.Parity = Parity.Even; }
					else if (ParzystoscWaga2 == "Mark")
					{ serialPort2.Parity = Parity.Mark; }
					else if (ParzystoscWaga2 == "None")
					{ serialPort2.Parity = Parity.None; }
					else if (ParzystoscWaga2 == "Odd")
					{ serialPort2.Parity = Parity.Odd; }
					else if (ParzystoscWaga2 == "Space")
					{ serialPort2.Parity = Parity.Space; }
					serialPort2.DataBits = Int32.Parse(BityDanychWaga2);
					if (BityStopuWaga2 == "None")
					{ serialPort2.StopBits = StopBits.None; }
					else if (BityStopuWaga2 == "One")
					{ serialPort2.StopBits = StopBits.One; }
					else if (BityStopuWaga2 == "OnePointFive")
					{ serialPort2.StopBits = StopBits.OnePointFive; }
					else if (BityStopuWaga2 == "Two")
					{ serialPort2.StopBits = StopBits.Two; }
					serialPort2.ReadTimeout = 50;
					serialPort2.WriteTimeout = 50;
					serialPort2.Handshake = Handshake.None;
					serialPort2.NewLine = "" + (char)13 + (char)10;
				}
			}
			//--------------------------------------
		}
		private void UstawPortWagi3()
		{
			if (ObecnoscPlikuKonfPortow)
			{
				//Ładowanie ustawień wagi 3
				if (PortWaga3 != "Brak")
				{
					serialPort3.PortName = PortWaga3;
					serialPort3.BaudRate = Int32.Parse(PredkoscWaga3);
					if (ParzystoscWaga3 == "Even")
					{ serialPort3.Parity = Parity.Even; }
					else if (ParzystoscWaga3 == "Mark")
					{ serialPort3.Parity = Parity.Mark; }
					else if (ParzystoscWaga3 == "None")
					{ serialPort3.Parity = Parity.None; }
					else if (ParzystoscWaga3 == "Odd")
					{ serialPort3.Parity = Parity.Odd; }
					else if (ParzystoscWaga3 == "Space")
					{ serialPort3.Parity = Parity.Space; }
					serialPort3.DataBits = Int32.Parse(BityDanychWaga3);
					if (BityStopuWaga3 == "None")
					{ serialPort3.StopBits = StopBits.None; }
					else if (BityStopuWaga3 == "One")
					{ serialPort3.StopBits = StopBits.One; }
					else if (BityStopuWaga3 == "OnePointFive")
					{ serialPort3.StopBits = StopBits.OnePointFive; }
					else if (BityStopuWaga3 == "Two")
					{ serialPort3.StopBits = StopBits.Two; }
					serialPort3.ReadTimeout = 50;
					serialPort3.WriteTimeout = 50;
					serialPort3.Handshake = Handshake.None;
					serialPort3.NewLine = "" + (char)13 + (char)10;
				}
			}
			//--------------------------------------
		}
		//################################

		//Czytaj plik ustawien arkuszy
		private void CzytajPlikUstawienArkuszy()
		{
			try
			{
				StreamReader plikKonf = new StreamReader("awecowagiarkusze.cfg");
				UstExelP1.PlikSzablonu = plikKonf.ReadLine();
				UstExelP1.WspolzedneX = plikKonf.ReadLine();
				UstExelP1.WspolzedneY = plikKonf.ReadLine();
				UstExelP1.T6WspolzedneX = plikKonf.ReadLine();
				UstExelP1.T6WspolzedneY = plikKonf.ReadLine();

				UstExelP2.PlikSzablonu = plikKonf.ReadLine();
				UstExelP2.WspolzedneX = plikKonf.ReadLine();
				UstExelP2.WspolzedneY = plikKonf.ReadLine();
				UstExelP2.T6WspolzedneX = plikKonf.ReadLine();
				UstExelP2.T6WspolzedneY = plikKonf.ReadLine();

				UstExelP3.PlikSzablonu = plikKonf.ReadLine();
				UstExelP3.WspolzedneX = plikKonf.ReadLine();
				UstExelP3.WspolzedneY = plikKonf.ReadLine();
				UstExelP3.T6WspolzedneX = plikKonf.ReadLine();
				UstExelP3.T6WspolzedneY = plikKonf.ReadLine();

				UstExelP4.PlikSzablonu = plikKonf.ReadLine();
				UstExelP4.WspolzedneX = plikKonf.ReadLine();
				UstExelP4.WspolzedneY = plikKonf.ReadLine();
				UstExelP4.T6WspolzedneX = plikKonf.ReadLine();
				UstExelP4.T6WspolzedneY = plikKonf.ReadLine();

				UstExelP5.PlikSzablonu = plikKonf.ReadLine();
				UstExelP5.WspolzedneX = plikKonf.ReadLine();
				UstExelP5.WspolzedneY = plikKonf.ReadLine();
				UstExelP5.T6WspolzedneX = plikKonf.ReadLine();
				UstExelP5.T6WspolzedneY = plikKonf.ReadLine();
				
				plikKonf.Close();
				plikKonf.Dispose();
				ObecnoscPlikuKonfArkuszy = true;
			}
			catch { ObecnoscPlikuKonfArkuszy = false; }
			
		}
		//############################

		//UstawAktualnyArkusz
		private void UstawAktualnyArkusz()
		{
			if (ObecnoscPlikuKonfArkuszy)
			{
				if (radioButton1.Checked)
				{ UstExelAktualne = UstExelP1; }
				else if (radioButton2.Checked)
				{ UstExelAktualne = UstExelP2; }
				else if (radioButton3.Checked)
				{ UstExelAktualne = UstExelP3; }
				else if (radioButton4.Checked)
				{ UstExelAktualne = UstExelP4; }
				else if (radioButton5.Checked)
				{ UstExelAktualne = UstExelP5; }
				else { UstExelAktualne.PlikSzablonu = "Brak"; }
			}
			else { UstExelAktualne.PlikSzablonu = "Brak"; }
			
		}
		//############################

		//Wczytanie Ustawien programów
		private void CzytajUstawieniaProgramow()
		{
			try
			{
				StreamReader plikKonf = new StreamReader("awecowagiprogramy.cfg");
				//Wczytanie ustawien programu 1
				UstProgP1.CzRozpPoziomyH= Decimal.Parse(plikKonf.ReadLine());
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
				ObecnoscPlikuKonfProgramy = true;
			}
			catch 
			{ 
				ObecnoscPlikuKonfProgramy = false;

				//Załadowanie wartości domyślnych
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

				//Program2
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
		//############################

		//Ustawianie danych po wybraniu programu
		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton1.Checked)
			{
				UstawAktualnyArkusz();
				numCzRozpPoziomH.Enabled = false;
				numCzRozpPoziomM.Enabled = false;
				numCzRozpPoziomS.Enabled = false;
				numCzRozpPionH.Enabled = false;
				numCzRozpPionM.Enabled = false;
				numCzRozpPionS.Enabled = false;
				numCzImpDozowaniaH.Enabled = false;
				numCzImpDozowaniaM.Enabled = false;
				numCzImpDozowaniaS.Enabled = false;
				numCzPrzerwyImpDozH.Enabled = false;
				numCzPrzerwyImpDozM.Enabled = false;
				numCzPrzerwyImpDozS.Enabled = false;
				numIlImpDozowania.Enabled = false;
				numIlCykliPom.Enabled = false;

				numCzRozpPoziomH.Value = UstProgP1.CzRozpPoziomyH;
				numCzRozpPoziomM.Value = UstProgP1.CzRozpPoziomyM;
				numCzRozpPoziomS.Value = UstProgP1.CzRozpPoziomyS;
				numCzRozpPionH.Value = UstProgP1.CzRozpPionowyH;
				numCzRozpPionM.Value = UstProgP1.CzRozpPionowyM;
				numCzRozpPionS.Value = UstProgP1.CzRozpPionowyS;
				numCzImpDozowaniaH.Value = UstProgP1.CzImpDozH;
				numCzImpDozowaniaM.Value = UstProgP1.CzImpDozM;
				numCzImpDozowaniaS.Value = UstProgP1.CzImpDozS;
				numCzPrzerwyImpDozH.Value = UstProgP1.CzPomImpDozH;
				numCzPrzerwyImpDozM.Value = UstProgP1.CzPomImpDozM;
				numCzPrzerwyImpDozS.Value = UstProgP1.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP1.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP1.IloscCykliPomiarowych;
				btStart.Enabled = true;
				btZapiszWage1.Enabled = true;
				btZapiszWage2.Enabled = true;
				btZapiszWage3.Enabled = true;
			}

		}
		private void radioButton2_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton2.Checked)
			{
				UstawAktualnyArkusz();
				numCzRozpPoziomH.Enabled = false;
				numCzRozpPoziomM.Enabled = false;
				numCzRozpPoziomS.Enabled = false;
				numCzRozpPionH.Enabled = false;
				numCzRozpPionM.Enabled = false;
				numCzRozpPionS.Enabled = false;
				numCzImpDozowaniaH.Enabled = false;
				numCzImpDozowaniaM.Enabled = false;
				numCzImpDozowaniaS.Enabled = false;
				numCzPrzerwyImpDozH.Enabled = false;
				numCzPrzerwyImpDozM.Enabled = false;
				numCzPrzerwyImpDozS.Enabled = false;
				numIlImpDozowania.Enabled = false;
				numIlCykliPom.Enabled = false;

				numCzRozpPoziomH.Value = UstProgP2.CzRozpPoziomyH;
				numCzRozpPoziomM.Value = UstProgP2.CzRozpPoziomyM;
				numCzRozpPoziomS.Value = UstProgP2.CzRozpPoziomyS;
				numCzRozpPionH.Value = UstProgP2.CzRozpPionowyH;
				numCzRozpPionM.Value = UstProgP2.CzRozpPionowyM;
				numCzRozpPionS.Value = UstProgP2.CzRozpPionowyS;
				numCzImpDozowaniaH.Value = UstProgP2.CzImpDozH;
				numCzImpDozowaniaM.Value = UstProgP2.CzImpDozM;
				numCzImpDozowaniaS.Value = UstProgP2.CzImpDozS;
				numCzPrzerwyImpDozH.Value = UstProgP2.CzPomImpDozH;
				numCzPrzerwyImpDozM.Value = UstProgP2.CzPomImpDozM;
				numCzPrzerwyImpDozS.Value = UstProgP2.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP2.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP2.IloscCykliPomiarowych;
				btStart.Enabled = true;
				btZapiszWage1.Enabled = true;
				btZapiszWage2.Enabled = true;
				btZapiszWage3.Enabled = true;
			}

		}
		private void radioButton3_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton3.Checked)
			{
				UstawAktualnyArkusz();
				numCzRozpPoziomH.Enabled = false;
				numCzRozpPoziomM.Enabled = false;
				numCzRozpPoziomS.Enabled = false;
				numCzRozpPionH.Enabled = false;
				numCzRozpPionM.Enabled = false;
				numCzRozpPionS.Enabled = false;
				numCzImpDozowaniaH.Enabled = false;
				numCzImpDozowaniaM.Enabled = false;
				numCzImpDozowaniaS.Enabled = false;
				numCzPrzerwyImpDozH.Enabled = false;
				numCzPrzerwyImpDozM.Enabled = false;
				numCzPrzerwyImpDozS.Enabled = false;
				numIlImpDozowania.Enabled = false;
				numIlCykliPom.Enabled = false;

				numCzRozpPoziomH.Value = UstProgP3.CzRozpPoziomyH;
				numCzRozpPoziomM.Value = UstProgP3.CzRozpPoziomyM;
				numCzRozpPoziomS.Value = UstProgP3.CzRozpPoziomyS;
				numCzRozpPionH.Value = UstProgP3.CzRozpPionowyH;
				numCzRozpPionM.Value = UstProgP3.CzRozpPionowyM;
				numCzRozpPionS.Value = UstProgP3.CzRozpPionowyS;
				numCzImpDozowaniaH.Value = UstProgP3.CzImpDozH;
				numCzImpDozowaniaM.Value = UstProgP3.CzImpDozM;
				numCzImpDozowaniaS.Value = UstProgP3.CzImpDozS;
				numCzPrzerwyImpDozH.Value = UstProgP3.CzPomImpDozH;
				numCzPrzerwyImpDozM.Value = UstProgP3.CzPomImpDozM;
				numCzPrzerwyImpDozS.Value = UstProgP3.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP3.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP3.IloscCykliPomiarowych;
				btStart.Enabled = true;
				btZapiszWage1.Enabled = true;
				btZapiszWage2.Enabled = true;
				btZapiszWage3.Enabled = true;
			}

		}
		private void radioButton4_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton4.Checked)
			{
				UstawAktualnyArkusz();
				numCzRozpPoziomH.Enabled = false;
				numCzRozpPoziomM.Enabled = false;
				numCzRozpPoziomS.Enabled = false;
				numCzRozpPionH.Enabled = false;
				numCzRozpPionM.Enabled = false;
				numCzRozpPionS.Enabled = false;
				numCzImpDozowaniaH.Enabled = false;
				numCzImpDozowaniaM.Enabled = false;
				numCzImpDozowaniaS.Enabled = false;
				numCzPrzerwyImpDozH.Enabled = false;
				numCzPrzerwyImpDozM.Enabled = false;
				numCzPrzerwyImpDozS.Enabled = false;
				numIlImpDozowania.Enabled = false;
				numIlCykliPom.Enabled = false;

				numCzRozpPoziomH.Value = UstProgP4.CzRozpPoziomyH;
				numCzRozpPoziomM.Value = UstProgP4.CzRozpPoziomyM;
				numCzRozpPoziomS.Value = UstProgP4.CzRozpPoziomyS;
				numCzRozpPionH.Value = UstProgP4.CzRozpPionowyH;
				numCzRozpPionM.Value = UstProgP4.CzRozpPionowyM;
				numCzRozpPionS.Value = UstProgP4.CzRozpPionowyS;
				numCzImpDozowaniaH.Value = UstProgP4.CzImpDozH;
				numCzImpDozowaniaM.Value = UstProgP4.CzImpDozM;
				numCzImpDozowaniaS.Value = UstProgP4.CzImpDozS;
				numCzPrzerwyImpDozH.Value = UstProgP4.CzPomImpDozH;
				numCzPrzerwyImpDozM.Value = UstProgP4.CzPomImpDozM;
				numCzPrzerwyImpDozS.Value = UstProgP4.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP4.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP4.IloscCykliPomiarowych;
				btStart.Enabled = true;
				btZapiszWage1.Enabled = true;
				btZapiszWage2.Enabled = true;
				btZapiszWage3.Enabled = true;
			}
		}
		private void radioButton5_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton5.Checked)
			{
				UstawAktualnyArkusz();
				numCzRozpPoziomH.Enabled = false;
				numCzRozpPoziomM.Enabled = false;
				numCzRozpPoziomS.Enabled = false;
				numCzRozpPionH.Enabled = false;
				numCzRozpPionM.Enabled = false;
				numCzRozpPionS.Enabled = false;
				numCzImpDozowaniaH.Enabled = false;
				numCzImpDozowaniaM.Enabled = false;
				numCzImpDozowaniaS.Enabled = false;
				numCzPrzerwyImpDozH.Enabled = false;
				numCzPrzerwyImpDozM.Enabled = false;
				numCzPrzerwyImpDozS.Enabled = false;
				numIlImpDozowania.Enabled = false;
				numIlCykliPom.Enabled = false;

				numCzRozpPoziomH.Value = UstProgP5.CzRozpPoziomyH;
				numCzRozpPoziomM.Value = UstProgP5.CzRozpPoziomyM;
				numCzRozpPoziomS.Value = UstProgP5.CzRozpPoziomyS;
				numCzRozpPionH.Value = UstProgP5.CzRozpPionowyH;
				numCzRozpPionM.Value = UstProgP5.CzRozpPionowyM;
				numCzRozpPionS.Value = UstProgP5.CzRozpPionowyS;
				numCzImpDozowaniaH.Value = UstProgP5.CzImpDozH;
				numCzImpDozowaniaM.Value = UstProgP5.CzImpDozM;
				numCzImpDozowaniaS.Value = UstProgP5.CzImpDozS;
				numCzPrzerwyImpDozH.Value = UstProgP5.CzPomImpDozH;
				numCzPrzerwyImpDozM.Value = UstProgP5.CzPomImpDozM;
				numCzPrzerwyImpDozS.Value = UstProgP5.CzPomImpDozS;
				numIlImpDozowania.Value = UstProgP5.IloscImpDozowania;
				numIlCykliPom.Value = UstProgP5.IloscCykliPomiarowych;
				btStart.Enabled = true;
				btZapiszWage1.Enabled = true;
				btZapiszWage2.Enabled = true;
				btZapiszWage3.Enabled = true;
			}
		}
		private void radioButton6_CheckedChanged(object sender, EventArgs e)
		{
			if (radioButton6.Checked)
			{
				UstExelAktualne.PlikSzablonu = "Brak";
				numCzRozpPoziomH.Enabled = true;
				numCzRozpPoziomM.Enabled = true;
				numCzRozpPoziomS.Enabled = true;
				numCzRozpPionH.Enabled = true;
				numCzRozpPionM.Enabled = true;
				numCzRozpPionS.Enabled = true;
				numCzImpDozowaniaH.Enabled = true;
				numCzImpDozowaniaM.Enabled = true;
				numCzImpDozowaniaS.Enabled = true;
				numCzPrzerwyImpDozH.Enabled = true;
				numCzPrzerwyImpDozM.Enabled = true;
				numCzPrzerwyImpDozS.Enabled = true;
				numIlImpDozowania.Enabled = true;
				numIlCykliPom.Enabled = true;
				btStart.Enabled = true;
				btZapiszWage1.Enabled = true;
				btZapiszWage2.Enabled = true;
				btZapiszWage3.Enabled = true;
			}
		}
		//#############################

		//Przycisk start cyklu
		private void btStart_Click(object sender, EventArgs e)
        {
			try
			{
				byte a = 0;
				driverSter.z_RaiseRealError = false;
				driverSter.Comm_Open(ref comPortNumberSter, ref  comSettingsSter);

				//######################################
				//Czyszczenie tabelki przed nastepnymi pomiarami.
				dataGridView1.Rows.Clear();
				//Ustawianie czasu timerow
				UstawCzasyTimerow();
				//Ustawienie napiecia  cewki
				UstawNapiecieCewki();
				//Wpisanie ktore wagi są obecne
				UstawObecnoscWag();
				//Wpisanie numeru programu do sterownika
				UstawNumerProgramu();

				//##############################################
				//wpisanie znacznika start cyklu
				Array znStart = Array.CreateInstance(typeof(byte), 1);
				znStart.SetValue((byte)1, 0);
				driverSter.Write_MemBits(0, 1, ref znStart, ref a);

				//##############################################
				//Wylaczenie przycisku przycisku na czas pomiarów
				btStart.Enabled = false;
				ZnSTOP = false;
				ZnDoPozycji = false;
				timer1.Enabled = true;
			}
			catch 
			{
				MessageBox.Show("Błąd połączenia ze sterownikiem.\nSprawdź ustawienia połączenia sterownika w\nMenu -> Konfiguracja -> Ustawienia", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			driverSter.Comm_Close();
			driverSter.z_RaiseRealError = false;
			//----------------------------------
		}
		//#############################

		//Wpisanie numeru programu do sterownika
		private void UstawNumerProgramu()
		{
				Int16 NumerProgramu = 0;
				byte a = 0;
				if (radioButton1.Checked == true)
				{ NumerProgramu = 1; }
				else if (radioButton2.Checked == true)
				{ NumerProgramu = 2; }
				else if (radioButton3.Checked == true)
				{ NumerProgramu = 3; }
				else if (radioButton4.Checked == true)
				{ NumerProgramu = 4; }
				else if (radioButton5.Checked == true)
				{ NumerProgramu = 5; }
				else
				{ NumerProgramu = 6; }

				Array myIntArr = Array.CreateInstance(typeof(Int16), 1);
				myIntArr.SetValue(NumerProgramu, 0);
				driverSter.Write_MemIntegers(2, 1, ref myIntArr, ref a);
		}

		//Wpisanie do sterownika które wagi są obecne
		private void UstawObecnoscWag()
		{
			try
			{
				byte a = 0;
				Array myArr = Array.CreateInstance(typeof(byte), 3);
				myArr.SetValue((byte)0, 0);
				myArr.SetValue((byte)0, 1);
				myArr.SetValue((byte)0, 2);
				if (PortWaga1 != "Brak")
				{ myArr.SetValue((byte)1, 0); }
				else if (PortWaga2 != "Brak")
				{ myArr.SetValue((byte)1, 1); }
				else if (PortWaga3 != "Brak")
				{ myArr.SetValue((byte)1, 2); }
				driverSter.Write_MemBits(30, 3, ref myArr, ref a);
			}
			catch { }
		}
		//#############################

		//Wpisanie Do Sterownika Czasów Timerów i ilości impulsów dozowania.
		private void UstawCzasyTimerow()
		{
			byte a = 0;
			driverSter.z_RaiseRealError = true;
			//----------------------------------------------
			//Zapis ilosci impulsów dozowania
			Array myArr = Array.CreateInstance(typeof(Int16), 2);
			myArr.SetValue((Int16)numIlCykliPom.Value, 0);
			myArr.SetValue((Int16)numIlImpDozowania.Value, 1);
			driverSter.Write_MemIntegers(0, 2, ref myArr, ref a);
			//---------------------------------------------------
			//Timer0
			myArr = Array.CreateInstance(typeof(Decimal), 1);
			Decimal czasTimera;
			czasTimera = numCzRozpPoziomS.Value * 100;
			czasTimera = czasTimera + numCzRozpPoziomM.Value * 6000;
			czasTimera = czasTimera + numCzRozpPoziomH.Value * 60 * 60 * 100;
			myArr.SetValue(czasTimera, 0);
			driverSter.Write_TimersPreset(0, 1, ref myArr, ref a);
			//Timer1
			czasTimera = numCzRozpPionS.Value * 100;
			czasTimera = czasTimera + numCzRozpPionM.Value * 6000;
			czasTimera = czasTimera + numCzRozpPionH.Value * 60 * 60 * 100;
			myArr.SetValue(czasTimera, 0);
			driverSter.Write_TimersPreset(1, 1, ref myArr, ref a);
			//Timer2
			czasTimera = numCzImpDozowaniaS.Value * 100;
			czasTimera = czasTimera + numCzImpDozowaniaM.Value * 6000;
			czasTimera = czasTimera + numCzImpDozowaniaH.Value * 60 * 60 * 100;
			myArr.SetValue(czasTimera, 0);
			driverSter.Write_TimersPreset(2, 1, ref myArr, ref a);
			timer1.Enabled = true;
			//Timer3
			czasTimera = numCzPrzerwyImpDozS.Value * 100;
			czasTimera = czasTimera + numCzPrzerwyImpDozM.Value * 6000;
			czasTimera = czasTimera + numCzPrzerwyImpDozH.Value * 60 * 60 * 100;
			myArr.SetValue(czasTimera, 0);
			driverSter.Write_TimersPreset(3, 1, ref myArr, ref a);
			timer1.Enabled = true;

			driverSter.z_RaiseRealError = false;

            //----------------------------------------------------
        }
		//#############################

		//Wpisanie do sterownika napiecia cewki
		private void UstawNapiecieCewki()
		{

			driverSter.z_RaiseRealError = true;
			byte a = 0;
            Array myArr = Array.CreateInstance(typeof(byte), 4);
            myArr.SetValue((byte)0, 0);
			myArr.SetValue((byte)0, 1);
			myArr.SetValue((byte)0, 2);
			myArr.SetValue((byte)0, 3);
			if (radioButton7.Checked)//220VAC
			{
				myArr.SetValue((byte)1, 0);
				myArr.SetValue((byte)0, 1);
				myArr.SetValue((byte)0, 2);
				myArr.SetValue((byte)0, 3);
			}
			else if (radioButton8.Checked) //200VAC
			{
				myArr.SetValue((byte)0, 0);
				myArr.SetValue((byte)1, 1);
				myArr.SetValue((byte)0, 2);
				myArr.SetValue((byte)0, 3);
			}
			else if (radioButton9.Checked) //110VAC
			{
				myArr.SetValue((byte)0, 0);
				myArr.SetValue((byte)0, 1);
				myArr.SetValue((byte)1, 2);
				myArr.SetValue((byte)0, 3);
			}
			else                           //24VDC
			{
				myArr.SetValue((byte)0, 0);
				myArr.SetValue((byte)0, 1);
				myArr.SetValue((byte)0, 2);
				myArr.SetValue((byte)1, 3);
			}
			driverSter.Write_MemBits(25, 4, ref myArr, ref a);

			driverSter.z_RaiseRealError = false;
		}
		//#############################

		//Uruchomienie procedury powrotu do pozycji
		private void btDoPozycji_Click(object sender, EventArgs e)
		{
			ZnSTOP = true;
			ZnDoPozycji = true;
			btStart.Enabled = false;
			timer1.Enabled = true;
		}
		//#############################

		//Uruchomienie procedury stopu
		private void btStop_Click(object sender, EventArgs e)
		{
			ZnSTOP = true;
			btStart.Enabled = false;
			timer1.Enabled = true;
		}
		//#############################

		//Wczytywanie danych do komputera podczas cyklu
        private void timer1_Tick(object sender, EventArgs e)
        {
			timer1.Enabled = false;
			byte a = 0;
			Array myArr = Array.CreateInstance(typeof(byte), 1);
			myArr.SetValue((byte)0, 0);
			driverSter.z_RaiseRealError = true;

			//Połączenie ze sterownikiem
			try
			{
				
				driverSter.Comm_Open(ref comPortNumberSter, ref  comSettingsSter);
			}
			catch { ZnSTOP = true; }

			//Jeżeli nie wlaczone jest zatrzymanie cyklu wykonaj: 
			if (ZnSTOP == false)
			{
				//Sparawdzenie czy cykl jest zalaczony
				try
				{
					driverSter.Read_MemBits(0, 1, ref myArr, ref a);
				}
				catch { }

				//Jeżeli jest zalaczony.
				if (myArr.GetValue(0).ToString() == "1")
				{
					myArr.SetValue((byte)0, 0);
					try
					{

						//Sprawdz ustawienie bitu odczytu wag.
						myArr.SetValue((byte)0, 0);
						driverSter.Read_MemBits(1, 1, ref myArr, ref a);
					}
					catch { }
					//Jeżeli bit jest ustawiony czytaj wagi
					if (myArr.GetValue(0).ToString() == "1")
					{
						
						//Odczyt danych z wagi 1 jeżeli jest skonfigurowna
						//W innym wypadku przypisz wartości domyślne
						if (ZmWaga1Zajeta == false &&
							PortWaga1 != "Brak")
						{
							serialPort1.Open();
							serialPort1.WriteLine("S");
						}
						else if (PortWaga1 == "Brak")
						{
							ZmWaga1Zajeta = true;
							ZmWaga1Odczytana = true;
							OdczytWagi1 = "Brak";
						}
						//---------------------------------------------

						//Odczyt danych z wagi 2 jeżeli jest skonfigurowna
						//W innym wypadku przypisz wartości domyślne
						if (ZmWaga2Zajeta == false &&
							PortWaga2 != "Brak")
						{
							serialPort2.Open();
							serialPort2.WriteLine("S");
						}
						else if (PortWaga2 == "Brak")
						{
							ZmWaga2Zajeta = true;
							ZmWaga2Odczytana = true;
							OdczytWagi2 = "Brak";
						}
						//---------------------------------------------

						//Odczyt danych z wagi 3 jeżeli jest skonfigurowna
						//W innym wypadku przypisz wartości domyślne
						if (ZmWaga3Zajeta == false &&
							PortWaga3 != "Brak")
						{
							serialPort3.Open();
							serialPort3.WriteLine("S");
						}
						else if (PortWaga3 == "Brak")
						{
							ZmWaga3Zajeta = true;
							ZmWaga3Odczytana = true;
							OdczytWagi3 = "Brak";
						}
						//---------------------------------------------


						//Zakonczenie procedury odczytu wskazan wag 
						//wyswietlenie danych i powrot do cyklu
						if (ZmWaga1Odczytana == true &&
							ZmWaga1Odczytana == true &&
							ZmWaga1Odczytana == true)
						{
							string[] row = {   OdczytWagi1, 
										   OdczytWagi2, 
										   OdczytWagi3 
									   };
							dataGridView1.Rows.Add(row);

							myArr.SetValue((byte)1, 0);
							driverSter.Write_MemBits(2, 1, ref myArr, ref a);
							ZmWaga1Zajeta = false;
							ZmWaga1Odczytana = false;
							ZmWaga2Zajeta = false;
							ZmWaga2Odczytana = false;
							ZmWaga3Zajeta = false;
							ZmWaga3Odczytana = false;
							
						}
						//---------------------------------------------------
					}
					timer1.Enabled = true;
				}
				else { btStart.Enabled = true; }
			}
			else 
			{
				try
				{
					myArr = Array.CreateInstance(typeof(byte), 1);
					myArr.SetValue((byte)0, 0);
					driverSter.Write_MemBits(0, 1, ref myArr, ref a);
					driverSter.Write_MemBits(3, 1, ref myArr, ref a);
				}
				catch { MessageBox.Show("Błąd połączenia ze sterownikiem.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); }
				finally { }
				if (ZnDoPozycji == true)
				{
					try
					{
						myArr = Array.CreateInstance(typeof(byte), 1);
						myArr.SetValue((byte)1, 0);
						driverSter.Write_MemBits(3, 1, ref myArr, ref a);
					}
					catch { }
					finally
					{
						ZnDoPozycji = false;
					}
				}
				btStart.Enabled = true;
				ZnSTOP = false;
			}
            driverSter.Comm_Close();
			driverSter.z_RaiseRealError = false;
            //----------------------------------------
        }
		//#############################

        //Zapisywanie odpowiedzi wag
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
			try
			{
				OdczytWagi1 = serialPort1.ReadLine();
				OdczytWagi1 = OdczytWagi1.Substring(3);
				OdczytWagi1 = OdczytWagi1.Trim();
				ZmWaga1Odczytana = true;
			}
			catch
			{
				PortWaga1 = "Brak";
				MessageBox.Show("Błąd odczytu wagi 1", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			finally { serialPort1.Close(); }
        }
        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
			try
			{
				OdczytWagi2 = serialPort2.ReadLine();
				OdczytWagi2 = OdczytWagi2.Substring(3);
				OdczytWagi2 = OdczytWagi2.Trim();
				ZmWaga2Odczytana = true;
			}
			catch
			{
				PortWaga2 = "Brak";
				MessageBox.Show("Błąd odczytu wagi 2", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			finally { serialPort2.Close(); }
        }
        private void serialPort3_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
			try
			{
				OdczytWagi3 = serialPort3.ReadLine();
				OdczytWagi3 = OdczytWagi3.Substring(3);
				OdczytWagi3 = OdczytWagi3.Trim();
				ZmWaga3Odczytana = true;
			}
			catch
			{
				PortWaga3 = "Brak";
				MessageBox.Show("Błąd odczytu wagi 1", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			finally { serialPort3.Close(); }
        }
        //#############################

		//Zapis danych pomiarów
		private void btZapiszWage1_Click(object sender, EventArgs e)
		{
			
			btZapiszWage1.Enabled = false;

			string Sciezka, NazwaPliku, CalaNazwa;
			int IndexNazwy, IndexKropki;
			IndexNazwy = UstExelAktualne.PlikSzablonu.LastIndexOf('\\');
			IndexKropki = UstExelAktualne.PlikSzablonu.LastIndexOf('.');
			Sciezka = UstExelAktualne.PlikSzablonu.Substring(0, IndexNazwy);
			NazwaPliku = UstExelAktualne.PlikSzablonu.Substring(IndexNazwy, (IndexKropki - IndexNazwy));
			
			DateTime czas = System.DateTime.Now;
			
			int zmiana = 0;
			if (czas.Hour >= 6 && czas.Hour < 14)
			{ zmiana = 1; }
			else if (czas.Hour >= 22 || czas.Hour < 6)
			{ zmiana = 3; }
			else if (czas.Hour >= 14 && czas.Hour < 22)
			{ zmiana = 2; }
			CalaNazwa = Sciezka +  "\\Audit("+tbNrLini.Text+")-"+czas.Year.ToString() + "-" + czas.Month.ToString()+ ".xls";

			Excel.Application ExcelObj = null;
			ExcelObj = new Excel.Application();
			if (ExcelObj == null)
			{
				MessageBox.Show("Exel nie może zostać uruchomiony \n Sprawdz swoją instalację MS Office.", "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
			else
			{
				ExcelObj.Visible = false;
				ExcelObj.AlertBeforeOverwriting = true;

				//Otwarcie pliku szablonu oraz pliku audutu i zapisanie danych

				if (File.Exists(UstExelAktualne.PlikSzablonu))
				{
					ExcelObj.Workbooks.Open(UstExelAktualne.PlikSzablonu, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
					Excel.Worksheet templateSheet = (Excel.Worksheet)ExcelObj.ActiveSheet ;
					try
					{
						if (File.Exists(CalaNazwa))
						{
							ExcelObj.Workbooks.Open(CalaNazwa, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
						}
						else
						{
							ExcelObj.Workbooks.Add(System.Type.Missing);
							ExcelObj.Workbooks[2].SaveAs(CalaNazwa, Excel.XlFileFormat.xlWorkbookNormal, System.Type.Missing, System.Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlNoChange, System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
							//ExcelObj.Workbooks.Open(CalaNazwa, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
						}
						int a = ExcelObj.Workbooks.Count;
						templateSheet.Copy(ExcelObj.Workbooks[2].Worksheets[1], Type.Missing);
						try
						{
							Excel.Worksheet ZapisNazwy = (Excel.Worksheet)ExcelObj.Workbooks[2].Worksheets.get_Item(1);
							ZapisNazwy.Name = tbNrLini.Text + "-" + czas.Month.ToString() + "." + czas.Day.ToString() + "-Zmiana_" + zmiana;

							for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
							{
								if (!chBTest6Godzinny.Checked)
								{ 
									ExcelObj.Cells[Int32.Parse(UstExelAktualne.WspolzedneY) + i, Int32.Parse(UstExelAktualne.WspolzedneX)] = dataGridView1.Rows[i].Cells[0].Value.ToString();
									ExcelObj.Cells[Int32.Parse(UstExelAktualne.WspolzedneY) + i, Int32.Parse(UstExelAktualne.WspolzedneX)+2] = dataGridView1.Rows[i].Cells[1].Value.ToString();
									ExcelObj.Cells[Int32.Parse(UstExelAktualne.WspolzedneY) + i, Int32.Parse(UstExelAktualne.WspolzedneX)+4] = dataGridView1.Rows[i].Cells[2].Value.ToString(); 
								}
								else
								{ 
									ExcelObj.Cells[Int32.Parse(UstExelAktualne.T6WspolzedneY) + i, Int32.Parse(UstExelAktualne.T6WspolzedneX)] = dataGridView1.Rows[i].Cells[0].Value.ToString();
									ExcelObj.Cells[Int32.Parse(UstExelAktualne.T6WspolzedneY) + i, Int32.Parse(UstExelAktualne.T6WspolzedneX)+2] = dataGridView1.Rows[i].Cells[1].Value.ToString();
									ExcelObj.Cells[Int32.Parse(UstExelAktualne.T6WspolzedneY) + i, Int32.Parse(UstExelAktualne.T6WspolzedneX)+4] = dataGridView1.Rows[i].Cells[2].Value.ToString(); 
								}
							}

							ExcelObj.Workbooks[2].Save();
							MessageBox.Show("Dane zapisano pomyślnie","Zapisywanie wyników",MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
						}
						catch
						{
							MessageBox.Show("Zakładka o takiej samej nazwie już istnieje. \n Dane nie zostaną zapisane.", "Error.",MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
						}
					}
					catch
					{ MessageBox.Show("Plik audytu nie może zostać otwarty. \n Zamknij wszystkie okienka Excela.", "Error.",MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1); }

					ExcelObj.Workbooks.Close();
					ExcelObj.Quit();


					//ExcelObj.Quit();
					ExcelObj = null;
				}
				else
				{
					ExcelObj.Quit();
					ExcelObj = null;
					MessageBox.Show("Brak pliku szablonu.","Error.", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				}
			}
			btZapiszWage1.Enabled = true;
		}
		private void btZapiszWage2_Click(object sender, EventArgs e)
		{
			btZapiszWage1.Enabled = false;
			btZapiszWage2.Enabled = false;
			btZapiszWage3.Enabled = false;

			Excel.Application ExcelObj = null;
			try
			{
				// Initialize the Windows Components
				//InitializeComponent();
				ExcelObj = new Excel.Application();
				// See if the Excel Application Object was successfully constructed
				if (ExcelObj == null)
				{
					MessageBox.Show("ERROR: EXCEL couldn't be started!");
					System.Windows.Forms.Application.Exit();
				}
				// Make the Application Visible
				ExcelObj.Visible = false;
				Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(UstExelAktualne.PlikSzablonu, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
				for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
				{
					if (!chBTest6Godzinny.Checked)
					{ ExcelObj.Cells[Int32.Parse(UstExelAktualne.WspolzedneY) + i, Int32.Parse(UstExelAktualne.WspolzedneX)] = dataGridView1.Rows[i].Cells[1].Value.ToString(); }
					else
					{ ExcelObj.Cells[Int32.Parse(UstExelAktualne.T6WspolzedneY) + i, Int32.Parse(UstExelAktualne.T6WspolzedneX)] = dataGridView1.Rows[i].Cells[1].Value.ToString(); }
				}

				ExcelObj.Quit();
				string Sciezka, NazwaPliku,CalaNazwa;
				int IndexNazwy, IndexKropki;
				IndexNazwy = UstExelAktualne.PlikSzablonu.LastIndexOf('\\');
				IndexKropki = UstExelAktualne.PlikSzablonu.LastIndexOf('.');
				Sciezka = UstExelAktualne.PlikSzablonu.Substring(0, IndexNazwy);
				NazwaPliku = UstExelAktualne.PlikSzablonu.Substring(IndexNazwy, (IndexKropki - IndexNazwy));
				DateTime czas = System.DateTime.Now;
				int zmiana = 0;
				if (czas.Hour >= 6 && czas.Hour < 14)
				{ zmiana = 1; }
				else if (czas.Hour >= 22 || czas.Hour < 6)
				{ zmiana = 3; }
				else if (czas.Hour >= 14 && czas.Hour < 22)
				{ zmiana = 2; }
				CalaNazwa = Sciezka + NazwaPliku + "_" + czas.Year.ToString() + "-" + czas.Month.ToString() + "-" + czas.Day.ToString() + "_Zmiana-" + zmiana.ToString() + ".xls";
				ExcelObj.Save(CalaNazwa);
				ExcelObj.Quit();
				ExcelObj = null;
			}
			catch
			{
				ExcelObj.Quit();
				ExcelObj = null;
				MessageBox.Show("Sprawdz ustawienia arkuszy.");
			}
			btZapiszWage1.Enabled = true;
			btZapiszWage2.Enabled = true;
			btZapiszWage3.Enabled = true;
		}
		private void btZapiszWage3_Click(object sender, EventArgs e)
		{
			btZapiszWage1.Enabled = false;
			btZapiszWage2.Enabled = false;
			btZapiszWage3.Enabled = false;

			Excel.Application ExcelObj = null;
			try
			{
				// Initialize the Windows Components
				//InitializeComponent();
				ExcelObj = new Excel.Application();
				// See if the Excel Application Object was successfully constructed
				if (ExcelObj == null)
				{
					MessageBox.Show("ERROR: EXCEL couldn't be started!");
					System.Windows.Forms.Application.Exit();
				}
				// Make the Application Visible
				ExcelObj.Visible = false;
				Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(UstExelAktualne.PlikSzablonu, 0, false, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true);
				for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
				{
					if (!chBTest6Godzinny.Checked)
					{ ExcelObj.Cells[Int32.Parse(UstExelAktualne.WspolzedneY) + i, Int32.Parse(UstExelAktualne.WspolzedneX)] = dataGridView1.Rows[i].Cells[2].Value.ToString(); }
					else
					{ ExcelObj.Cells[Int32.Parse(UstExelAktualne.T6WspolzedneY) + i, Int32.Parse(UstExelAktualne.T6WspolzedneX)] = dataGridView1.Rows[i].Cells[2].Value.ToString(); }
				}

				ExcelObj.Quit();
				string Sciezka, NazwaPliku,CalaNazwa;
				int IndexNazwy, IndexKropki;
				IndexNazwy = UstExelAktualne.PlikSzablonu.LastIndexOf('\\');
				IndexKropki = UstExelAktualne.PlikSzablonu.LastIndexOf('.');
				Sciezka = UstExelAktualne.PlikSzablonu.Substring(0, IndexNazwy);
				NazwaPliku = UstExelAktualne.PlikSzablonu.Substring(IndexNazwy, (IndexKropki - IndexNazwy));
				DateTime czas = System.DateTime.Now;
				int zmiana = 0;
				if (czas.Hour >= 6 && czas.Hour < 14)
				{ zmiana = 1; }
				else if (czas.Hour >= 22 || czas.Hour < 6)
				{ zmiana = 3; }
				else if (czas.Hour >= 14 && czas.Hour < 22)
				{ zmiana = 2; }
				CalaNazwa = Sciezka + NazwaPliku + "_" + czas.Year.ToString() + "-" + czas.Month.ToString() + "-" + czas.Day.ToString() + "_Zmiana-" + zmiana.ToString() + ".xls";
				ExcelObj.Save(CalaNazwa);
				ExcelObj.Quit();
				ExcelObj = null;
			}
			catch
			{
				ExcelObj.Quit();
				ExcelObj = null;
				MessageBox.Show("Sprawdz ustawienia arkuszy.");
			}
			btZapiszWage1.Enabled = true;
			btZapiszWage2.Enabled = true;
			btZapiszWage3.Enabled = true;
		}
		//#############################

		//Przepisywanie wartosci komórek do schowka
		private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			//Zapis wartości komórki do schowka
			try
			{
				Clipboard.Clear();
				Clipboard.ContainsText();
				Clipboard.SetText(dataGridView1.SelectedCells[0].Value.ToString());
			}
			catch { }
			finally { }
			//----------------------------------------------
		}
		//#############################

		//Wyswietlenie formu ustawien programow
		private void ustawieniaProgramówToolStripMenuItem_Click(object sender, EventArgs e)
		{
			UstawieniaProgramow formaUst = new UstawieniaProgramow();
			formaUst.Show(null);
		}
		//#############################

		//Wyswietlenie formy ustawień arkuszy
		private void ustawieniaArkuszyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Wyświetlenie formy z ustawieniami
			UstawieniaArkuszy formaUst = new UstawieniaArkuszy();
			formaUst.Show(null);
			//Form1_Load(sender, e);
		}
		//#############################

		//Wyświetlenie formatki o programie
		private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(" Program sterujący stanowiska testowego dozowników.\n\n Remtech Sp. z o.o. \n\n Bielsko-Biała \n\n Ul.Tadeusza Regera 30 ", "O programie.", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
		}
		//#############################

		//Wyswietlenie formy ustawień portu
		private void ustawieniaToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Wyświetlenie formy z ustawieniami
			UstawieniaPortow formaUst = new UstawieniaPortow();
			formaUst.Show(null);
			//Form1_Load(sender, e);
			//----------------------------------
		}
		//#############################

		//Przeładowanie ustawień podczas aktywacji formatki
		private void FormaGlowna_Activated(object sender, EventArgs e)
		{
			this.Form1_Load(sender, e);
		}
		//###############################

		//Zamkniecie formy i wylaczenie sterownika.
		private void FormaGlowna_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				timer1.Enabled = false;
				driverSter.Comm_Open(ref comPortNumberSter, ref  comSettingsSter);
				byte a = 0;
				Array myArr = Array.CreateInstance(typeof(byte), 4);
				myArr.SetValue((byte)0, 0);
				myArr.SetValue((byte)0, 1);
				myArr.SetValue((byte)0, 2);
				myArr.SetValue((byte)0, 3);
				driverSter.Write_MemBits(0, 4, ref myArr, ref a);
				driverSter.Comm_Close();
			}
			catch { }
		}
		//#############################
    }
}
