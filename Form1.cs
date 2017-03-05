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


namespace SqlTutorial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                button1_Click(null, null);
                e.Handled = true;
            }
        }

        private void monoFlat_Button1_Click(object sender, EventArgs e)
        {
            
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string gelenDeger;

            SelectClass select = new SelectClass();
            SimilarityClass similar = new SimilarityClass();
            QueryExecute execute = new QueryExecute();
            DbConnect con = new DbConnect();
            TableColControl control;
            select.regexContol(similar.editQuery(textBox1.Text.Trim().ToLower()));
            gelenDeger = ResultClass.getResult();
            DataTable table = new DataTable();

            try
            {
                execute.executeAdapter(gelenDeger).Fill(table);
                dataGridView1.DataSource = table;
                ResultClass.setResult("");
                con.connect.Close();
            }
            catch (Exception)
            {
                SimilarityClass similar2 = new SimilarityClass();
                control = new TableColControl();
                string sorgu = similar2.editQuery(textBox1.Text.Trim().ToLower());
               
                
                    MessageBox.Show(gelenDeger, "HATALI SORGU", MessageBoxButtons.OK, MessageBoxIcon.Stop);
              

                ResultClass.setResult("");
            }


        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1.PerformClick();
                e.Handled = true;
            }
        }
    }
}
