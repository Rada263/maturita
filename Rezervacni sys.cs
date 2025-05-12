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

namespace Rezervacni_system
{
    public partial class Form1 : Form
    {
        public DataTable tabulka = new DataTable();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabulka.TableName = "Tabulka";
            DataGridView.DataSource = tabulka;
            tabulka.Columns.Add("Řada", typeof(string));
            tabulka.Columns.Add("Číslo", typeof(string));
            tabulka.Columns.Add("Jméno", typeof(string));
            tabulka.Columns.Add("Dostupnost", typeof(bool));
            tabulka.Columns.Add("VIP", typeof(bool));

            for (int y = 1; y <= 15; y++)
            {
                for (int z = 1; z <= 20; z++)
                {
                    tabulka.Rows.Add(y, z, "-", true, false);
                }
            }

        }

        private void btn_ulozit_Click(object sender, EventArgs e)
        {
            saveFileDialog1.DefaultExt = ".xml";
            saveFileDialog1.Filter = ".xml|";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName,false);
                tabulka.WriteXml(writer);
                writer.Close();
            }
        }

        private void btn_nacist_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".xml";
            openFileDialog1.Filter = ".xml|";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tabulka.Clear();
                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                tabulka.ReadXml(reader);
            }
            
        }
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            tb_jmeno.Text = "";
            if(tabulka.Rows.Count == 300)
            {
                int row = DataGridView.CurrentRow.Index;
                DataGridView.Rows[row].Selected = true;
                tb_rada.Text = DataGridView.Rows[row].Cells[0].Value.ToString();
                tb_cislo.Text = DataGridView.Rows[row].Cells[1].Value.ToString();
                if (DataGridView.Rows[row].Cells[2].Value.ToString() != "-")
                    tb_jmeno.Text = DataGridView.Rows[row].Cells[2].Value.ToString();
                chb_vip.Checked = (bool)DataGridView.Rows[row].Cells[4].Value;
            }
        }

        private void btn_nastavit_Click(object sender, EventArgs e)
        {
            string jmeno = tb_jmeno.Text;
            string rada = tb_rada.Text;
            string cislo = tb_cislo.Text;
            bool VIP = chb_vip.Checked;
            if (jmeno != "" || rada == "" || cislo == "")
            {
                DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[0].Value = tb_rada.Text;
                DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[1].Value = tb_cislo.Text;
                DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[2].Value = tb_jmeno.Text;
                DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[3].Value = false;
                DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[4].Value = VIP;
            }
            else
                MessageBox.Show("Chybné jméno.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[0].Value = tb_rada.Text;
            DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[1].Value = tb_cislo.Text;
            DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[2].Value = "-";
            DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[3].Value = true;
            DataGridView.Rows[DataGridView.CurrentRow.Index].Cells[4].Value = false;
            tb_jmeno.Text = "";
        }
    }
}
