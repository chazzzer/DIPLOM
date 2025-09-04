using DIPLOM_RAYKHERT.MyClass;
using DIPLOM_RAYKHERT.MyForm.Kurs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DIPLOM_RAYKHERT
{
    public partial class KursCard : UserControl
    {
        public string id_kursa;
        public string picture;
        public string kurs;
        public string hours;
        public string price;
        public string rubli;
        public string kop;
        string formattedNumber;
        public KursCard(string id, string pic, string name, string duration, string cena)
        {
            InitializeComponent();
            id_kursa = id;
            picture = pic; 
            kurs = name;
            hours = duration;
            price = cena;

            kursPb.ImageLocation = pic;
            kursTb.Text = name;
            hoursTb.Text = duration + " ч";

            double pricee = Convert.ToDouble(cena);
            int integerPart = (int)pricee;
            formattedNumber = integerPart.ToString("N0", CultureInfo.CreateSpecificCulture("ru-RU")).Replace(',', ' ');
            priceTb.Text = formattedNumber + " ₽";

            string[] parts = cena.Split(',');
            rubli = parts[0];
            kop = parts[1];
        }

        private void KursCard_Load(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            KursEditForm kef = new KursEditForm(Convert.ToInt32(id_kursa), picture, kurs, hours, formattedNumber, rubli, kop);
            kef.ShowDialog();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить курс?", "Подтверждение",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                KursiClass.DeleteKurs(Convert.ToInt32(id_kursa));
            }
        }
    }
}
