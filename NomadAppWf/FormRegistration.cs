using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NomadAppWf
{
    public partial class FormRegistration : Form
    {
        public FormMain StartedForm { get; set; }

        public FormRegistration(FormMain form)
        {
            StartedForm = form;
            InitializeComponent();
            FormClosing += ShowStartedForm;
        }

        private void ShowStartedForm(object sender, EventArgs e)
        {
            if (!StartedForm.IsDisposed)
            {
                StartedForm.Show();
            }
        }

        private void ButtonRegClick(object sender, EventArgs e)
        {
            Registration(TextBoxName.Text, TextBoxLogin.Text, TextBoxFirstPassword.Text, TextBoxSecondPassword.Text);
        }

        private void Registration(string name,string login, string firstPassword, string secondPassword)
        {
            using (var context = new DataContext())
            {
                if (name.Length < 1)
                {
                    MessageBox.Show("Введите имя");
                    return;
                }

                var users = context.Users.Where(u => u.Login == login).ToList();
                if (users.Count > 0)
                {
                    MessageBox.Show("Пользователь уже существует");
                    return;
                }

                if (firstPassword.Length < 4)
                {
                    MessageBox.Show("Пароль должен содержать минимум 4 символа ");
                    return;
                }
                if (firstPassword != secondPassword)
                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }

                context.Users.Add(new Models.User { Name = name,Login = login, Password = EncodePassword(firstPassword) });
                context.SaveChanges();

                MessageBox.Show("Регистрация прошла успешно");

                Close();
            }
        }

        private string EncodePassword(string originalPassword)
        {
            byte[] originalBytes;
            byte[] encodedBytes;

            MD5 md5 = new MD5CryptoServiceProvider();

            originalBytes = Encoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);

            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes), "-", "").ToLower();
        }
    }
}
