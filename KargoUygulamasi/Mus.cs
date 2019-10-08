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
    public partial class Mus : Form
    {
        public Mus()
        {
            InitializeComponent();
        }

        private void Mus_Load(object sender, EventArgs e)
        {
            comboBox1.ValueMember = "SevkiyatID";
            comboBox1.DataSource = Müsteriler.Doldurr();

            comboBox3.ValueMember = "SubeID";
            comboBox3.DataSource = Müsteriler.Doldur();


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
            dataGridView1.DataSource = Müsteriler.Listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;

            textBox1.Tag = satir.Cells["MusteriID"].Value;
            comboBox1.Text = satir.Cells["SevkiyatID"].Value.ToString();
            textBox1.Text = satir.Cells["MAdSoyad"].Value.ToString();
            textBox2.Text = satir.Cells["Adres"].Value.ToString();
            maskedTextBox1.Text= satir.Cells["Telefon"].Value.ToString();
            textBox3.Text = satir.Cells["Mail"].Value.ToString();
           comboBox2.Text = satir.Cells["OdemeDurumu"].Value.ToString();

            comboBox3.Text = satir.Cells["SubeID"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Müsteri ekle = new Müsteri();
            ekle.SevkiyatID = Convert.ToInt32(comboBox1.SelectedValue);
            ekle.MAdSoyad = textBox1.Text;
            ekle.Adres = textBox2.Text;
            ekle.Telefon =maskedTextBox1.Text;
            ekle.Mail = textBox3.Text;
            ekle.OdemeDurumu = comboBox2.SelectedItem.ToString();
            ekle.SubeID = Convert.ToInt32(comboBox3.SelectedValue);

            if (!Müsteriler.Ekle(ekle))
                MessageBox.Show("Veriler Eklenmedi....");
            dataGridView1.DataSource = Müsteriler.Listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Müsteri sil = new Müsteri();
            sil.MusteriID = (int)textBox1.Tag;
            if (!Müsteriler.Sil(sil))
                MessageBox.Show("Veri Silinemedi..");
            dataGridView1.DataSource = Müsteriler.Listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Müsteri yenile = new Müsteri();
            yenile.MusteriID = (int)textBox1.Tag;
            yenile.SevkiyatID = Convert.ToInt32(comboBox1.SelectedValue);
            yenile.MAdSoyad = textBox1.Text;
            yenile.Adres = textBox2.Text;
            yenile.Telefon = maskedTextBox1.Text;
            yenile.Mail = textBox3.Text;
            yenile.OdemeDurumu = comboBox2.SelectedItem.ToString();
            yenile.SubeID = Convert.ToInt32(comboBox3.SelectedValue);



            if (!Müsteriler.Yenile(yenile))
                MessageBox.Show("Veriler Güncellenemedi....");
            dataGridView1.DataSource = Müsteriler.Listele();
        }
    }
}
