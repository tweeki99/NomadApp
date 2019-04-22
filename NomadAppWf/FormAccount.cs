using NomadAppWf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NomadAppWf
{
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
            LoadForm();
            FormClosing += ShowStartedForm;
        }

        public void LoadForm()
        {
            using (var context = new DataContext())
            {
                Guid authorizationUserId = new Guid(ConfigurationManager.AppSettings["AuthorizationUserId"]);

                var subscriptions = context.Subscriptions.Where(s => s.UserId == authorizationUserId).ToList();

                if (subscriptions.Count == 0)
                {
                    LabelSubscriptionStatus.Text = "У вас нет подписки";
                    ButtonSubscribe.Text = "Оформить подписку";
                }
                else if (subscriptions.FirstOrDefault().ExpirationDate < DateTime.Now)
                {
                    LabelSubscriptionStatus.Text = "Подписка закончилась";
                    ButtonSubscribe.Text = "Оформить подписку заново";
                }
                else
                {
                    LabelSubscriptionStatus.Text = "Подписка действует до:\n\t" + subscriptions.FirstOrDefault().ExpirationDate.ToLongDateString();
                    ButtonSubscribe.Text = "Продлить подписку";
                }

                var getting = context.Getting.Where(s => s.UserId == authorizationUserId && s.IsDelivered == false).ToList();

                if (getting.Count == 0)
                {
                    LabelDetails.Visible = false;
                    ButtonDetails.Visible = false;
                }
                else
                {
                    LabelDetails.Visible = true;
                    ButtonDetails.Visible = true;
                }
            }
        }

        private void ShowStartedForm(object sender, EventArgs e)
        {
            var form = Application.OpenForms["FormAuthorization"];
            form.Close();
        }

        private void ButtonSubscribeClick(object sender, EventArgs e)
        {
            FormSubscribe formSubscribe = new FormSubscribe();
            DialogResult result = formSubscribe.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            using (var context = new DataContext())
            {
                Guid authorizationUserId = new Guid(ConfigurationManager.AppSettings["AuthorizationUserId"]);

                var subscriptions = context.Subscriptions.Where(s => s.UserId == authorizationUserId).ToList();

                if (subscriptions.Count == 0)
                {
                    context.Subscriptions.Add(new Subscription
                    {
                        UserId = authorizationUserId,
                        ExpirationDate = AddYears(DateTime.Now, formSubscribe)
                    });
                }
                else if (subscriptions.FirstOrDefault().ExpirationDate < DateTime.Now)
                {
                    var subscription = context.Subscriptions.Where(s => s.UserId == authorizationUserId).FirstOrDefault();
                    
                    subscription.ExpirationDate = AddYears(DateTime.Now, formSubscribe);
                }
                else
                {
                    var subscription = context.Subscriptions.Where(s => s.UserId == authorizationUserId).FirstOrDefault();
                    
                    subscription.ExpirationDate = AddYears(subscription.ExpirationDate, formSubscribe);
                }
                context.SaveChanges();
                LoadForm();
            } 
        }

        private DateTime AddYears(DateTime date, FormSubscribe formSubscribe)
        {
            DateTime expirationDate = date;
            if (formSubscribe.RadioButton1.Checked) expirationDate = expirationDate.AddYears(1);
            else if (formSubscribe.RadioButton2.Checked) expirationDate = expirationDate.AddYears(2);
            else expirationDate = expirationDate.AddYears(3);

            return expirationDate;
        }

        private void ButtonDetailsClick(object sender, EventArgs e)
        {
            Hide();
            FormGetting formGetting = new FormGetting(this);
            formGetting.Show();
        }
    }
}

