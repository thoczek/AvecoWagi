using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class UstawieniaPortow : Form
    {
        public UstawieniaPortow()
        {
            InitializeComponent();
        }
        
        public void Form2_Load(object sender, EventArgs e)
        {
            //Pobieranie portów w komuterze.
            string[] listaPortow=SerialPort.GetPortNames();

            foreach(string WykrytyPort in listaPortow)
            {
                cbPortSter.Items.Add(WykrytyPort);
                cbPortWaga1.Items.Add(WykrytyPort);
                cbPortWaga2.Items.Add(WykrytyPort);
                cbPortWaga3.Items.Add(WykrytyPort);
            }
            cbPortSter.Items.Add("Brak");
            cbPortWaga1.Items.Add("Brak");
            cbPortWaga2.Items.Add("Brak");
            cbPortWaga3.Items.Add("Brak");
            //Załadowanie zapisanych ustawień
            //Port sterownika
            try
            {
                StreamReader plikKonf = new StreamReader("awecowagi.cfg");
                cbPortSter.Text = plikKonf.ReadLine();
                cbPredkoscSter.Text = plikKonf.ReadLine();
                cbBityDanychSter.Text = plikKonf.ReadLine();
                cbParzystoscSter.Text = plikKonf.ReadLine();
                cbBityStopuSter.Text = plikKonf.ReadLine();
                //Port wagi 1
                cbPortWaga1.Text = plikKonf.ReadLine();
                cbPredkoscWaga1.Text = plikKonf.ReadLine();
                cbBityDanychWaga1.Text = plikKonf.ReadLine();
                cbParzystoscWaga1.Text = plikKonf.ReadLine();
                cbBityStopuWaga1.Text = plikKonf.ReadLine();
                //Port wagi 2
                cbPortWaga2.Text = plikKonf.ReadLine();
                cbPredkoscWaga2.Text = plikKonf.ReadLine();
                cbBityDanychWaga2.Text = plikKonf.ReadLine();
                cbParzystoscWaga2.Text = plikKonf.ReadLine();
                cbBityStopuWaga2.Text = plikKonf.ReadLine();
                //Port wagi 3
                cbPortWaga3.Text = plikKonf.ReadLine();
                cbPredkoscWaga3.Text = plikKonf.ReadLine();
                cbBityDanychWaga3.Text = plikKonf.ReadLine();
                cbParzystoscWaga3.Text = plikKonf.ReadLine();
                cbBityStopuWaga3.Text = plikKonf.ReadLine();
                //Zamkniecie pliku i zwolnienie zasobów.
                plikKonf.Close();
                plikKonf.Dispose();
            }
			catch
            {
                MessageBox.Show("Program nie znalazł pliku konfiguracyjnego \n Zostaną załadowane domyślne wartości.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                btDomyslne_Click(sender, e);
                btZapisz_Click(sender, e);
            }

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            btZapisz_Click(sender, e);
            this.Close();
        }

        private void btZapisz_Click(object sender, EventArgs e)
        {
            //Otwarcie pliku.
            StreamWriter plikKonf;
            plikKonf = new System.IO.StreamWriter("awecowagi.cfg");
            //Dane Sterownika
            plikKonf.Write(cbPortSter.Text+"\n");
            plikKonf.Write(cbPredkoscSter.Text+"\n");
            plikKonf.Write(cbBityDanychSter.Text+"\n");
            plikKonf.Write(cbParzystoscSter.Text + "\n");
            plikKonf.Write(cbBityStopuSter.Text + "\n");
            //Dane Wagi 1
            plikKonf.Write(cbPortWaga1.Text + "\n");
            plikKonf.Write(cbPredkoscWaga1.Text +"\n");
            plikKonf.Write(cbBityDanychWaga1.Text+"\n");
            plikKonf.Write(cbParzystoscWaga1.Text+"\n");
            plikKonf.Write(cbBityStopuWaga1.Text+"\n");
            //Dane waga 2
            plikKonf.Write(cbPortWaga2.Text+"\n");
            plikKonf.Write(cbPredkoscWaga2.Text+"\n");
            plikKonf.Write(cbBityDanychWaga2.Text+"\n");
            plikKonf.Write(cbParzystoscWaga2.Text+"\n");
            plikKonf.Write(cbBityStopuWaga2.Text+"\n");
            //Dane waga 3
            plikKonf.Write(cbPortWaga3.Text+"\n");
            plikKonf.Write(cbPredkoscWaga3.Text+"\n");
            plikKonf.Write(cbBityDanychWaga3.Text+"\n");
            plikKonf.Write(cbParzystoscWaga3.Text+"\n");
            plikKonf.Write(cbBityStopuWaga3.Text+"\n");
            //Zapis i  zamkniecie
            plikKonf.Flush();
            plikKonf.Dispose();
        }

        private void btDomyslne_Click(object sender, EventArgs e)
        {
            cbPortSter.Text = "Brak";
            cbPredkoscSter.Text = "57600";
            cbBityDanychSter.Text = "8";
            cbParzystoscSter.Text = "None";
            cbBityStopuSter.Text = "One";
            //Port wagi 1
            cbPortWaga1.Text = "Brak";
            cbPredkoscWaga1.Text = "9600";
            cbBityDanychWaga1.Text = "8";
            cbParzystoscWaga1.Text = "None";
            cbBityStopuWaga1.Text = "One";
            //Port wagi 2
            cbPortWaga2.Text = "Brak";
            cbPredkoscWaga2.Text = "9600";
            cbBityDanychWaga2.Text = "8";
            cbParzystoscWaga2.Text = "None";
            cbBityStopuWaga2.Text = "One";
            //Port wagi 3
            cbPortWaga3.Text = "Brak";
            cbPredkoscWaga3.Text = "9600";
            cbBityDanychWaga3.Text = "8";
            cbParzystoscWaga3.Text = "None";
            cbBityStopuWaga3.Text = "One";
        }

        private void btAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

		private void gbSterownik_Enter(object sender, EventArgs e)
		{

		}
    }
}
