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
using kKargo.ORM.Entity;
using kKargo.ORM.Facade;

namespace KargoUygulamasi
{
    public partial class Sevk : Form
    {
        public Sevk()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 git = new Form1();
            git.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Sevkiyatlar.Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sevkiyat ekle = new Sevkiyat();
            ekle.SAdi = textBox1.Text;
            ekle.SAlinanNokta = textBox2.Text;
            ekle.SUlasilacakNokta = textBox3.Text;
            ekle.Mesafe=Convert.ToInt32(textBox4.Text);
            ekle.MesafeTutari = Convert.ToDecimal(textBox5.Text);
            ekle.AracID= Convert.ToInt32(comboBox1.SelectedValue);

            if (!Sevkiyatlar.Ekle(ekle))
                MessageBox.Show("Veriler Eklenmedi....");
            dataGridView1.DataSource = Sevkiyatlar.Listele();
        }

        private void Sevk_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "AracID";
            comboBox1.DataSource = Sevkiyatlar.Doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
          
            textBox1.Tag = satir.Cells["SevkiyatID"].Value;
            textBox1.Text = satir.Cells["SAdi"].Value.ToString();
            textBox2.Text = satir.Cells["SAlinanNokta"].Value.ToString();
            textBox3.Text = satir.Cells["SUlasilacakNokta"].Value.ToString();
            textBox4.Text = satir.Cells["Mesafe"].Value.ToString();
            textBox5.Text = satir.Cells["MesafeTutari"].Value.ToString();

            comboBox1.Text = satir.Cells["AracID"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sevkiyat sil = new Sevkiyat();
            sil.SevkiyatID = (int)textBox1.Tag;
            if (!Sevkiyatlar.Sil(sil))
                MessageBox.Show("Veri Silinemedi..");
            dataGridView1.DataSource = Sevkiyatlar.Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sevkiyat yenile = new Sevkiyat();
            yenile.SevkiyatID = (int)textBox1.Tag;
            yenile.SAdi = textBox1.Text;
            yenile.SAlinanNokta = textBox2.Text;
            yenile.SUlasilacakNokta = textBox3.Text;
            yenile.Mesafe = Convert.ToInt32(textBox4.Text);
            yenile.MesafeTutari = Convert.ToDecimal(textBox5.Text);
            yenile.AracID = Convert.ToInt32(comboBox1.SelectedValue);



            if (!Sevkiyatlar.Yenile(yenile))
                MessageBox.Show("Veriler Güncellenemedi....");
            dataGridView1.DataSource = Sevkiyatlar.Listele();
        }
    }
}
