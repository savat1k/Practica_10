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
    public partial class Form1AddUsers : Form
    {
        public Form1AddUsers()
        {
            InitializeComponent();
        }

        ModelEF modelEF = new ModelEF();

        void StartLog()
        {
            dataGridView1.DataSource = modelEF.UsersHash.ToList();
        }

        private void Form1AddUsers_Load(object sender, EventArgs e)
        {
            StartLog();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" 
                || textBoxName.Text == ""
                || textBoxPassword.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            UsersHash usersHash = new UsersHash();
            usersHash.Login = textBoxLogin.Text;
            usersHash.Password = SHA256Builder.ConvertToHash(textBoxPassword.Text);
            usersHash.FirstName = textBoxName.Text;

            if (modelEF.UsersHash.ToList().Any(x =>
            x.Login == textBoxLogin.Text))
            {
                MessageBox.Show("Пользователь c таким логином уже есть");
                return;
            }

            try
            {
                modelEF.UsersHash.Add(usersHash);
                modelEF.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                StartLog();
            }

            textBoxLogin.Text = null;
            textBoxName.Text = null;
            textBoxPassword.Text = null;
            MessageBox.Show("Данные добавлены");
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            Form2Authorization form2 = new Form2Authorization();
            form2.ShowDialog();
        }
    }
}
