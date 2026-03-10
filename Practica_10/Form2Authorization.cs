using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Practica_10.FolderModel;

namespace Practica_10
{
    public partial class Form2Authorization : Form
    {
        public Form2Authorization()
        {
            InitializeComponent();
        }

        private void buttonSing_Click(object sender, EventArgs e)
        {
            ModelEF modelEF = new ModelEF();
            if (modelEF.UsersHash.ToList().Any(x =>
            x.Login == textBoxLogin.Text &&
            x.Password == SHA256Builder.ConvertToHash(textBoxPassword.Text)))
            {
                MessageBox.Show("Пользователь найден!");
                 return;
            }
            MessageBox.Show("Пользователь не найден :(");
        }
    }
}
