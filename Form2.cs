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
    public partial class Form2 : Form
    {
        int id=1;
        ListsTable listTable;
        ArrayList kolonIsimler;
       public string kolonIsimleri;
        public string tabloIsmi;
        public Form2()
        {
            InitializeComponent();
            AciklamaModul modul = new AciklamaModul();
            aciklamaTxt.Text = modul.returnQuery(1);
            listTable = new ListsTable();
            for (int i = 0; i < listTable.tabloListele().Count; i++)
            {
                listBox1.Items.Add(listTable.tabloListele()[i]);
            }
            kolonIsimleri = modul.getKolon();
            tabloIsmi = modul.getTablo();
            
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
                MessageBox.Show(gelenDeger, "HATALI SORGU", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                ResultClass.setResult("");
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listTable = new ListsTable();
            kolonIsimler = new ArrayList();
            kolonIsimler= listTable.kolonListele(listBox1.SelectedItem.ToString());
            for (int i = 0; i < kolonIsimler.Count; i++)
            {
                listBox2.Items.Add(kolonIsimler[i]);
            }
        }

        private void monoFlat_ThemeContainer1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void queryTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void aciklamaTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void monoFlat_ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
