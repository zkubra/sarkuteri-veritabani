using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sarkuteri2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string constring = ("Data Source=DESKTOP-IL5FGU6\\SQLEXPRESS01;Initial Catalog=sarkuteri2;Integrated Security=True");
        SqlConnection baglan = new SqlConnection(constring);
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void kayitlari_getir() 
        {
            string getir = "select * from URUNLER order by ID asc";
            SqlCommand komut = new SqlCommand(getir,baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        public void kayitlari_getir1()
        {
            string getir = "select * from URUNTURLERI order by ID asc";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
        }

        public void kayitlari_getir2()
        {
            string getir = "select * from TOPTANCILAR order by ID asc";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView3.DataSource = dt;
            baglan.Close();
        }

        public void kayitlari_getir3()
        {
            string getir = "select * from SATISLAR order by ID asc";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView4.DataSource = dt;
            baglan.Close();
        }

        public void kayitlari_getir4()
        {
            string getir = "select * from PERSONELLER order by ID asc";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView5.DataSource = dt;
            baglan.Close();
        }

        public void kayitlari_getir5()
        {
            string getir = "select * from MARKALAR order by ID asc";
            SqlCommand komut = new SqlCommand(getir, baglan);
            SqlDataAdapter ad = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView6.DataSource = dt;
            baglan.Close();
        }

        public void verisil(int id) 
        {
            string sil = "Delete From URUNLER where ID=@ID";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@ID", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        public void verisil1(int id)
        {
            string sil = "Delete From URUNTURLERI where ID=@ID";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@ID", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        public void verisil2(int id)
        {
            string sil = "Delete From TOPTANCILAR where ID=@ID";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@ID", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        public void verisil3(int id)
        {
            string sil = "Delete From SATISLAR where ID=@ID";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@ID", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        public void verisil4(int id)
        {
            string sil = "Delete From PERSONELLER where ID=@ID";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@ID", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }

        public void verisil5(int id)
        {
            string sil = "Delete From MARKALAR where ID=@ID";
            SqlCommand komut = new SqlCommand(sil, baglan);
            baglan.Open();
            komut.Parameters.AddWithValue("@ID", id);
            komut.ExecuteNonQuery();
            baglan.Close();
        }
        private void button_liste_Click(object sender, EventArgs e)
        {
            kayitlari_getir();
        }

        private void button_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if(baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into URUNLER (ID,UrunAdi,TurID,MarkaID) values (@ID,@UrunAdi,@TurID,@MarkaID)";
                    SqlCommand komut = new SqlCommand(kayit,baglan);
                    komut.Parameters.AddWithValue("@ID",textBox1.Text);
                    komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
                    komut.Parameters.AddWithValue("@TurID", textBox3.Text);
                    komut.Parameters.AddWithValue("@MarkaID", textBox4.Text);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata Var!"+ hata.Message);
            }
        }

        private void button_arama_Click(object sender, EventArgs e)
        {
            string kayit = "select * from URUNLER where ID=@ID";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@ID", textBox_ara.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglan.Close();
        }

        private void button_sil_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows) 
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil(id);
                kayitlari_getir();
            }
        }

        int i = 0;
        private void button_guncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Update URUNLER set ID=@ID, UrunAdi=@UrunAdi, TurID=@TurId, MarkaID=@MarkaID where ID=@ID ");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglan);
            komut.Parameters.AddWithValue("@ID", textBox1.Text);
            komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@TurID", textBox3.Text);
            komut.Parameters.AddWithValue("@MarkaID", textBox4.Text);
            komut.Parameters.AddWithValue("id", dataGridView1.Rows[i].Cells[0].Value);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar Başarıyla Güncellendi.");
            baglan.Close();
            kayitlari_getir();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox5.Text = dataGridView2.Rows[i].Cells[0].Value.ToString();
            textBox6.Text = dataGridView2.Rows[i].Cells[1].Value.ToString();
        }


        private void button_kaydet1_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into URUNTURLERI (ID,TurAdi) values (@ID,@TurAdi)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@ID", textBox5.Text);
                    komut.Parameters.AddWithValue("@TurAdi", textBox6.Text);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata Var!" + hata.Message);
            }
        }

        private void button_liste1_Click(object sender, EventArgs e)
        {
            kayitlari_getir1();
        }

        private void button_arama1_Click(object sender, EventArgs e)
        {
            string kayit = "select * from URUNTURLERI where ID=@ID";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@ID", textBox_ara1.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglan.Close();
        }

        private void button_sil1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView2.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil1(id);
                kayitlari_getir1();
            }
        }

        private void button_guncelle1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Update URUNTURLERI set ID=@ID,TurAdi=@TurAdi where ID=@ID ");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglan);
            komut.Parameters.AddWithValue("@ID", textBox5.Text);
            komut.Parameters.AddWithValue("@TurAdi", textBox6.Text);
            komut.Parameters.AddWithValue("id", dataGridView2.Rows[i].Cells[0].Value);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar Başarıyla Güncellendi.");
            baglan.Close();
            kayitlari_getir1();
        }

        private void button_kaydet2_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into TOPTANCILAR (ID,ToptanciAdi,UrunID) values (@ID,@ToptanciAdi,@UrunID)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@ID", textBox8.Text);
                    komut.Parameters.AddWithValue("@ToptanciAdi", textBox9.Text);
                    komut.Parameters.AddWithValue("@UrunID", textBox10.Text);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata Var!" + hata.Message);
            }
        }

        private void button_liste2_Click(object sender, EventArgs e)
        {
            kayitlari_getir2();
        }

        private void button_arama2_Click(object sender, EventArgs e)
        {
            string kayit = "select * from TOPTANCILAR where ID=@ID";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@ID", textBox_ara2.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            baglan.Close();
        }

        private void button_sil2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView3.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil2(id);
                kayitlari_getir2();
            }
        }

        private void button_guncelle2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Update TOPTANCILAR set ID=@ID,ToptanciAdi=@ToptanciAdi,UrunID=@UrunID where ID=@ID ");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglan);
            komut.Parameters.AddWithValue("@ID", textBox8.Text);
            komut.Parameters.AddWithValue("@ToptanciAdi", textBox9.Text);
            komut.Parameters.AddWithValue("@UrunID", textBox10.Text);
            komut.Parameters.AddWithValue("id", dataGridView3.Rows[i].Cells[0].Value);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar Başarıyla Güncellendi.");
            baglan.Close();
            kayitlari_getir2();
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox8.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
            textBox9.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
            textBox10.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
        }

        private void dataGridView4_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox11.Text = dataGridView4.Rows[i].Cells[0].Value.ToString();
            textBox12.Text = dataGridView4.Rows[i].Cells[1].Value.ToString();
            textBox13.Text = dataGridView4.Rows[i].Cells[2].Value.ToString();
            textBox14.Text = dataGridView4.Rows[i].Cells[3].Value.ToString();
        }

        private void button_kaydet3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into SATISLAR (ID,SatisTarihi,PersonelID,UrunID) values (@ID,@SatisTarihi,@PersonelID,@UrunID)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@ID", textBox11.Text);
                    komut.Parameters.AddWithValue("@SatisTarihi", textBox12.Text);
                    komut.Parameters.AddWithValue("@PersonelID", textBox13.Text);
                    komut.Parameters.AddWithValue("@UrunID", textBox14.Text);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata Var!" + hata.Message);
            }
        }

        private void button_liste3_Click(object sender, EventArgs e)
        {
            kayitlari_getir3();
        }

        private void button_arama3_Click(object sender, EventArgs e)
        {
            string kayit = "select * from SATISLAR where ID=@ID";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@ID", textBox_ara3.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            baglan.Close();
        }

        private void button_sil3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView4.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil3(id);
                kayitlari_getir3();
            }
        }

        private void button_guncelle3_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Update SATISLAR set ID=@ID,SatisTarihi=@SatisTarihi,PersonelID=@PersonelID,UrunID=@UrunID where ID=@ID ");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglan);
            komut.Parameters.AddWithValue("@ID", textBox11.Text);
            komut.Parameters.AddWithValue("@SatisTarihi", textBox12.Text);
            komut.Parameters.AddWithValue("@PersonelID", textBox13.Text);
            komut.Parameters.AddWithValue("@UrunID", textBox14.Text);
            komut.Parameters.AddWithValue("id", dataGridView4.Rows[i].Cells[0].Value);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar Başarıyla Güncellendi.");
            baglan.Close();
            kayitlari_getir3();
        }

        private void dataGridView5_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox15.Text = dataGridView5.Rows[i].Cells[0].Value.ToString();
            textBox16.Text = dataGridView5.Rows[i].Cells[1].Value.ToString();
            textBox17.Text = dataGridView5.Rows[i].Cells[2].Value.ToString();
            textBox18.Text = dataGridView5.Rows[i].Cells[3].Value.ToString();
            textBox19.Text = dataGridView5.Rows[i].Cells[3].Value.ToString();
        }

        private void button_kaydet4_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into PERSONELLER (ID,PersonelAdi,PersonelSoyadi,Tel,TC) values (@ID,@PersonelAdi,@PersonelSoyadi,@Tel,@TC)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@ID", textBox15.Text);
                    komut.Parameters.AddWithValue("@PersonelAdi", textBox16.Text);
                    komut.Parameters.AddWithValue("@PersonelSoyadi", textBox17.Text);
                    komut.Parameters.AddWithValue("@Tel", textBox18.Text);
                    komut.Parameters.AddWithValue("@TC", textBox19.Text);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata Var!" + hata.Message);
            }
        }

        private void button_liste4_Click(object sender, EventArgs e)
        {
            kayitlari_getir4();
        }

        private void button_arama4_Click(object sender, EventArgs e)
        {
            string kayit = "select * from PERSONELLER where ID=@ID";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@ID", textBox_ara4.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            baglan.Close();
        }

        private void button_sil4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView5.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil4(id);
                kayitlari_getir4();
            }
        }

        private void button_guncelle4_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Update PERSONELLER set ID=@ID,PersonelAdi=@PersonelAdi,PersonelSoyadi=@PersonelSoyadi,Tel=@Tel,TC=@TC where ID=@ID ");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglan);
            komut.Parameters.AddWithValue("@ID", textBox15.Text);
            komut.Parameters.AddWithValue("@PersonelAdi", textBox16.Text);
            komut.Parameters.AddWithValue("@PersonelSoyadi", textBox17.Text);
            komut.Parameters.AddWithValue("@Tel", textBox18.Text);
            komut.Parameters.AddWithValue("@TC", textBox19.Text);
            komut.Parameters.AddWithValue("id", dataGridView5.Rows[i].Cells[0].Value);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar Başarıyla Güncellendi.");
            baglan.Close();
            kayitlari_getir4();
        }

        private void dataGridView6_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            i = e.RowIndex;
            textBox20.Text = dataGridView6.Rows[i].Cells[0].Value.ToString();
            textBox21.Text = dataGridView6.Rows[i].Cells[1].Value.ToString();
        }

        private void button_kaydet5_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglan.State == ConnectionState.Closed)
                {
                    baglan.Open();
                    string kayit = "insert into MARKALAR (ID,MarkaAdi) values (@ID,@MarkaAdi)";
                    SqlCommand komut = new SqlCommand(kayit, baglan);
                    komut.Parameters.AddWithValue("@ID", textBox20.Text);
                    komut.Parameters.AddWithValue("@MarkaAdi", textBox21.Text);

                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı.");
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir Hata Var!" + hata.Message);
            }
        }

        private void button_liste5_Click(object sender, EventArgs e)
        {
            kayitlari_getir5();
        }

        private void button_arama5_Click(object sender, EventArgs e)
        {
            string kayit = "select * from MARKALAR where ID=@ID";
            SqlCommand komut = new SqlCommand(kayit, baglan);
            komut.Parameters.AddWithValue("@ID", textBox_ara5.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView6.DataSource = dt;
            baglan.Close();
        }

        private void button_sil5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView6.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                verisil5(id);
                kayitlari_getir5();
            }
        }

        private void button_guncelle5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            string kayitguncelle = ("Update MARKALAR set ID=@ID,MarkaAdi=@MarkaAdi where ID=@ID ");
            SqlCommand komut = new SqlCommand(kayitguncelle, baglan);
            komut.Parameters.AddWithValue("@ID", textBox20.Text);
            komut.Parameters.AddWithValue("@MarkaAdi", textBox21.Text);
            komut.Parameters.AddWithValue("id", dataGridView6.Rows[i].Cells[0].Value);
            komut.ExecuteNonQuery();
            MessageBox.Show("Kayıtlar Başarıyla Güncellendi.");
            baglan.Close();
            kayitlari_getir5();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
