using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlTutorial.Class;
using System.Collections;
namespace SqlTutorial
{
    public partial class HomePage : Form
    {
        int id = 1;
        ListsTable listTable;
        ArrayList kolonIsimler;
        public string kolonIsimleri;
        public string tabloIsmi;
        string gelenCevap;
        public HomePage()
        {
            InitializeComponent();
            AciklamaModul modul = new AciklamaModul();
            aciklamaTxt.Text = modul.returnQuery(id);
            listTable = new ListsTable();
            for (int i = 0; i < listTable.tabloListele().Count; i++)
            {
                listBox1.Items.Add(listTable.tabloListele()[i]);
            }
            kolonIsimleri = modul.getKolon();
            tabloIsmi = modul.getTablo();
            gelenCevap = modul.getCevap();
            button1.Enabled = false;
            button1.BackColor = Color.LightGray;
            label1.Visible = false;

          
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            string gelenDeger;

            SelectClass select = new SelectClass();
            SimilarityClass similar = new SimilarityClass();
            QueryExecute execute = new QueryExecute();
            DbConnect con = new DbConnect();
            TableColControl control;

            select.regexContol(similar.editQuery(queryTxt.Text.Trim().ToLower()));
            gelenDeger = ResultClass.getResult();
            DataTable table = new DataTable();


            try
            {
                execute.executeAdapter(gelenDeger).Fill(table);
                dataGridView1.DataSource = table;
                ResultClass.setResult("");
                con.dbConnection().Close();
            }
            catch (Exception)
            {
                SimilarityClass similar2 = new SimilarityClass();
                control = new TableColControl();
                string sorgu = similar2.editQuery(queryTxt.Text.Trim().ToLower());

                //                MessageBox.Show(gelenDeger, "HATALI SORGU", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                label1.Text = gelenDeger;
                ResultClass.setResult("");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listTable = new ListsTable();
            kolonIsimler = new ArrayList();
            kolonIsimler = listTable.kolonListele(listBox1.SelectedItem.ToString());
            for (int i = 0; i < kolonIsimler.Count; i++)
            {
                listBox2.Items.Add(kolonIsimler[i]);
            }
        }

        private void monoFlat_ThemeContainer1_Click(object sender, EventArgs e)
        {

        }

        private void monoFlat_Button1_Click_1(object sender, EventArgs e)
        {
            string gelenDeger;
            DbConnect con = new DbConnect();
            SelectClass select = new SelectClass();
            SimilarityClass similar = new SimilarityClass();
            QueryExecute execute = new QueryExecute();
            TableColControl control;
            select.regexContol(similar.editQuery(queryTxt.Text.Trim().ToLower()));
            gelenDeger = ResultClass.getResult();
            DataTable table = new DataTable();
            DataTable sorguTable = new DataTable();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
          

            try
            {
                execute.executeAdapter(gelenDeger).Fill(table);
                execute.executeAdapter(gelenCevap).Fill(sorguTable);
                if (!execute.AreTablesTheSame(table,sorguTable))
                {
                    
                    dataGridView1.DataSource = table;
                    label1.Visible = true;
                    label1.Text = "Sorgu Yapısı Doğru; Fakat Sorgunuz Cevap Ile Uyuşmuyor !";
                    button1.Enabled = false;
                    button1.BackColor = Color.LightGray;
                    gelenDeger = "";
                    ResultClass.setResult("");
                }
                else
                {
                    dataGridView1.DataSource = table;
                    ResultClass.setResult("");
                    button1.Enabled = true;
                    button1.BackColor = Color.ForestGreen;
                    label1.Visible = false;
                }
             
               
                con.dbConnection().Close();
               
            }
            catch (Exception)
            {
                SimilarityClass similar2 = new SimilarityClass();
                control = new TableColControl();
                string sorgu = similar2.editQuery(queryTxt.Text.Trim().ToLower());
                // MessageBox.Show(gelenDeger, "HATALI SORGU", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                label1.Visible = true;
                label1.Text = gelenDeger;
                ResultClass.setResult("");
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listTable = new ListsTable();
            kolonIsimler = new ArrayList();
            kolonIsimler = listTable.kolonListele(listBox1.SelectedItem.ToString());
            for (int i = 0; i < kolonIsimler.Count; i++)
            {
                listBox2.Items.Add(kolonIsimler[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id++;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            queryTxt.Text = "";
            
            AciklamaModul modul = new AciklamaModul();
            aciklamaTxt.Text = modul.returnQuery(id);
            listTable = new ListsTable();
            for (int i = 0; i < listTable.tabloListele().Count; i++)
            {
                listBox1.Items.Add(listTable.tabloListele()[i]);
            }
            kolonIsimleri = modul.getKolon();
            tabloIsmi = modul.getTablo();
            gelenCevap = modul.getCevap();
            button1.Enabled = false;
            button1.BackColor = Color.LightGray;
            label1.Visible = false;
        }
    }
}
