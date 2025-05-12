using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace arduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static SerialPort serial = new SerialPort();
        public string zapis = "";
        public string mod = "";
        public string hodnota = "";
        private void tb_potvrdit_Click(object sender, EventArgs e)
        {
            tb_cmd.Text = "";
            if (cbox_1.SelectedIndex != -1)
                serial.PortName = cbox_1.SelectedItem.ToString();
            switch (cbox_zapis.SelectedIndex)
            {
                case 0:
                    zapis = "GET:";
                    tb_hodnota.Visible = false;
                    break;
                case 1:
                    zapis = "SET:";
                    break;
            }
            switch (cbox_mod.SelectedIndex)
            {
                case 0:
                    mod = "FREQ";
                    break;
                case 1:
                    mod = "DUTY";
                    break;
                case 2:
                    mod = "MODE";
                    break;
            }
            if (tb_hodnota.Visible == false)
            {
                switch (cbox_modevyber.SelectedIndex)
                {
                    case 0:
                        hodnota = ":SQR";
                        break;
                    case 1:
                        hodnota = ":PWM";
                        break;
                }
            }
            else
                hodnota = ":" + tb_hodnota.Text;
            serial.Open();
            serial.WriteLine(zapis + mod + hodnota);
            serial.ReadTimeout = 2000;
            serial.NewLine = String.Format("\n");
            if (zapis == "GET:")
                tb_cmd.Text = serial.ReadLine();
            serial.Close();
            hodnota = "";
            tb_hodnota.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            for (int i = 0; i < port.Length; i++)
                cbox_1.Items.Add(port[i]);
        }

        private void cbox_zapis_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_mod.Visible = true;
        }

        private void cbox_mod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbox_zapis.SelectedIndex == 1)
            {
                if (cbox_mod.SelectedIndex == 2)
                {
                    cbox_modevyber.Visible = true;
                    tb_hodnota.Visible = false;
                }
                else
                {
                    cbox_modevyber.Visible = false;
                    tb_hodnota.Visible = true;
                }
            }  
            else
            {
                tb_hodnota.Visible=false;
                cbox_modevyber.Visible = false;
            }

        }

        private void cbox_1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_zapis.Visible = true;
        }
    }
}
