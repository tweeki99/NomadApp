using NomadAppWf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NomadAppWf
{
    public partial class FormAuthorization : Form
    {
        public FormMain StartedForm { get; set; }

        public FormAuthorization(FormMain form)
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

        private void ButtonAuthorizationClick(object sender, EventArgs e)
        {
            Authorization(TextBoxLogin.Text, TextBoxPassword.Text);
        }

        private void Authorization(string login, string password)
        {
            using (var context = new DataContext())
            {
                if (login.Length < 1)
                {
                    MessageBox.Show("Введите логин");
                    return;
                }
                var users = context.Users.Where(u => u.Login == login).ToList();
                
                if (users.Count == 0)
                {
                    MessageBox.Show("Пользователь не существует");
                    return;
                }

                User authorizationUser = users[0];

                if (authorizationUser.Password != EncodePassword(password))
                {
                    MessageBox.Show("Неверный пароль");
                    return;
                }

                ConfigurationManager.AppSettings["AuthorizationUserId"] = authorizationUser.Id.ToString();
                ConfigurationManager.AppSettings["AuthorizationUserName"] = authorizationUser.Name;

                Hide();
                FormAccount formAccount = new FormAccount();
                formAccount.Show();
            }
        }

        private string EncodePassword(string originalPassword)
        {
            byte[] originalBytes;

            byte[] encodedBytes;

            MD5 md5;

            md5 = new MD5CryptoServiceProvider();

            originalBytes = Encoding.Default.GetBytes(originalPassword);

            encodedBytes = md5.ComputeHash(originalBytes);

            return System.Text.RegularExpressions.Regex.Replace(BitConverter.ToString(encodedBytes), "-", "").ToLower();
        }
    }
}