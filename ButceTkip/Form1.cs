using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Reflection.Emit;

namespace ButceTkip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider = Microsoft.Ace.Oledb.12.0; Data Source = Aylar Tablosu.accdb");
        void guncelle()
        {
            //RENKLENDİRME
            foreach (DataGridViewRow satır in dataGridView1.Rows)
            {
                if (Convert.ToInt32(satır.Cells[2].Value) < 0)
                {
                    satır.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (Convert.ToInt32(satır.Cells[2].Value) > 0)
                {
                    satır.DefaultCellStyle.BackColor = Color.LawnGreen;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            guncelle();
            label1.Text = "Kayıt Sayısı: " + dataGridView1.RowCount.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string[] ayTablolari = {
        "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
        "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"};

            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < ayTablolari.Length)
            {
                string tabloAdi = ayTablolari[comboBox1.SelectedIndex];

                try
                {
                    DataTable tablo = new DataTable();
                    string sorgu = "SELECT * FROM [" + tabloAdi + "]";

                    if (baglan.State == ConnectionState.Closed)
                        baglan.Open();

                    OleDbDataAdapter veriler = new OleDbDataAdapter(sorgu, baglan);
                    veriler.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    guncelle();
                    label1.Text = "Kayıt Sayısı: " + dataGridView1.RowCount.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
                finally
                {
                    if (baglan.State == ConnectionState.Open)
                        baglan.Close();
                }
            }

        }

        public string query = "";
        public string sql = "";
        void kayıt()
        {
            OleDbCommand kaydet = new OleDbCommand(query, baglan);
            kaydet.Parameters.AddWithValue("@A", textBox1.Text);
            kaydet.Parameters.AddWithValue("@G", textBox2.Text);
            kaydet.Parameters.AddWithValue("@B", textBox3.Text);
            kaydet.Parameters.AddWithValue("@T", DateTime.Now);
            baglan.Open();
            kaydet.ExecuteNonQuery();
            baglan.Close();
        }


        void getir()
        {
            DataTable tablo = new DataTable();
            OleDbDataAdapter veriler = new OleDbDataAdapter(sql, baglan);
            veriler.Fill(tablo);
            dataGridView1.DataSource = tablo;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            label1.Text = "Kayıt Sayısı: " + dataGridView1.RowCount.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1 || textBox1.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Geçerli ayı giriniz ve bilgileri eksiksiz giriniz");
            }

            else if (comboBox1.SelectedIndex == 0)
            {
                sql = "SELECT * FROM Ocak";
                query = "INSERT INTO Ocak (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                sql = "SELECT * FROM Şubat";
                query = "INSERT INTO Şubat (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                sql = "SELECT * FROM Mart";
                query = "INSERT INTO Mart (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                sql = "SELECT * FROM Nisan";
                query = "INSERT INTO Nisan (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                sql = "SELECT * FROM Mayıs";
                query = "INSERT INTO Mayıs (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 5)
            {
                sql = "SELECT * FROM Haziran";
                query = "INSERT INTO Haziran (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 6)
            {
                sql = "SELECT * FROM Temmuz";
                query = "INSERT INTO Temmuz (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 7)
            {
                sql = "SELECT * FROM Ağustos";
                query = "INSERT INTO Ağustos (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 8)
            {
                sql = "SELECT * FROM Eylül";
                query = "INSERT INTO Eylül (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 9)
            {
                sql = "SELECT * FROM Ekim";
                query = "INSERT INTO Ekim (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 10)
            {
                sql = "SELECT * FROM Kasım";
                query = "INSERT INTO Kasım (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
            else if (comboBox1.SelectedIndex == 11)
            {
                sql = "SELECT * FROM Aralık";
                query = "INSERT INTO Aralık (ADI, [GELIR/GIDER], BILGI, TARIH) VALUES (@A,@G,@B,@T)";
                kayıt(); getir(); guncelle();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isChecked = false;
                if (row.Cells["Column1"].Value != null)
                    isChecked = Convert.ToBoolean(row.Cells["Column1"].Value);

                if (isChecked)
                {
                    string ay = comboBox1.SelectedItem?.ToString() ?? "";
                    string sorgu = "DELETE FROM [" + ay + "] WHERE ADI = @A AND [GELIR/GIDER] = @G";

                    using (OleDbCommand cmd = new OleDbCommand(sorgu, baglan))
                    {
                        cmd.Parameters.AddWithValue("@A", row.Cells["Column2"].Value);
                        cmd.Parameters.AddWithValue("@G", row.Cells["Column3"].Value);

                        baglan.Open();
                        cmd.ExecuteNonQuery();
                        baglan.Close();
                    }
                    rowsToDelete.Add(row);
                }
            }
            foreach (var row in rowsToDelete)
            {
                dataGridView1.Rows.Remove(row);
            }
            label1.Text = "Kayıt Sayısı: " + dataGridView1.RowCount.ToString();
            guncelle(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            decimal gelir = 0;
            decimal gider = 0;

            foreach (DataGridViewRow sec in dataGridView1.Rows)
            {
                if (sec.IsNewRow) continue;

                bool secili = false;
                if (sec.Cells["Column1"].Value != null)
                    Boolean.TryParse(sec.Cells["Column1"].Value.ToString(), out secili);

                if (secili)
                {
                    if (sec.Cells[2].Value != null)
                    {
                        string degerStr = sec.Cells[2].Value.ToString();

                        // Virgül ve noktalı sayı destekli kültürle parse et
                        if (decimal.TryParse(degerStr,
                            System.Globalization.NumberStyles.Number,
                            System.Globalization.CultureInfo.CurrentCulture,
                            out decimal deger))
                        {
                            if (deger >= 0)
                                gelir += deger;
                            else
                                gider += Math.Abs(deger); // gideri pozitif topla
                        }
                    }
                }

                // Seçim sıfırlama
                sec.Cells[0].Value = false;
            }

            decimal fark = gelir - gider;

            // Label'lara yazdır
            label5.Text = "Gelir = " + gelir.ToString("C2");
            label6.Text = "Gider = " + gider.ToString("C2");
            label7.Text = "Kalan = " + fark.ToString("C2");

            dataGridView1.ClearSelection();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Tümünü Seç")
            {
                foreach (DataGridViewRow sec in dataGridView1.Rows)
                {
                    sec.Cells[0].Value = true;
                    button4.Text = "Tümünü Kaldır";
                }
            }
            else if (button4.Text == "Tümünü Kaldır")     //else if yerine sadece if yazınca çalışmıyor çünkü biri bitince diğeri çalışıyor tekrar eski haline dönüyor kapiş
            {
                foreach (DataGridViewRow sec in dataGridView1.Rows)
                {
                    sec.Cells[0].Value = false;
                    button4.Text = "Tümünü Seç";
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
    e.KeyChar != ',' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-' && ((sender as TextBox).SelectionStart != 0 || (sender as TextBox).Text.Contains("-")))
            {
                e.Handled = true;
            }
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }
    }
}

