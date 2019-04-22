using NomadAppWf.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NomadAppWf.Admin
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonAddEditionClick(object sender, EventArgs e)
        {
            FormAddEdition formAddEdition = new FormAddEdition();
            DialogResult result = formAddEdition.ShowDialog(this);

            if (result == DialogResult.Cancel)
                return;

            if (formAddEdition.TextBoxName.Text.Length < 1)
            {
                MessageBox.Show("Вы не ввели название");
                return;
            }

            using (var context = new DataContext())
            {
                Edition newEdition = new Edition { Name = formAddEdition.TextBoxName.Text };
                context.Editions.Add(newEdition);

                var subscriptions = context.Subscriptions.Where(s => s.ExpirationDate > DateTime.Now).ToList();

                foreach(var subscription in subscriptions)
                {
                    context.Getting.Add(new Getting
                    {
                        UserId = subscription.User.Id,
                        EditionId = newEdition.Id,
                        IsDelivered = false
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
