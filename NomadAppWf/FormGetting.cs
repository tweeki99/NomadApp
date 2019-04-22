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
    public partial class FormGetting : Form
    {
        public FormAccount FormAccount { get; set; }

        public FormGetting(FormAccount form)
        {
            FormAccount = form;
            InitializeComponent();
            LoadDataGridViewGetting();
            FormClosing += ShowFormAccount;
        }

        private void ShowFormAccount(object sender, EventArgs e)
        {
            if (!FormAccount.IsDisposed)
            {
                FormAccount.Show();
                FormAccount.LoadForm();
            }
        }

        private void ButtonAcceptClick(object sender, EventArgs e)
        {
            using (var context = new DataContext())
            {
                Guid gettingId = new Guid(DataGridViewGetting.SelectedRows[0].Cells["GettingId"].Value.ToString());

                var getting = context.Getting
                        .Where(g => g.Id == gettingId)
                        .FirstOrDefault();

                getting.IsDelivered = true;

                context.SaveChanges();

                LoadDataGridViewGetting();
            }
        }

        private void LoadDataGridViewGetting()
        {
            DataGridViewGetting.Rows.Clear();
            DataGridViewGetting.Columns.Clear();

            DataGridViewGetting.Columns.Add("GettingId", "GettingId");
            DataGridViewGetting.Columns[0].Visible = false;
            DataGridViewGetting.Columns.Add("EditionName", "Название издания");

            Guid authorizationUserId = new Guid(ConfigurationManager.AppSettings["AuthorizationUserId"]);

            using (var context = new DataContext())
            {
                var getting = context.Getting.Where(s => s.UserId == authorizationUserId && s.IsDelivered == false).ToList();

                for (int i = 0; i < getting.Count(); i++)
                {
                    List<string> data = new List<string>();

                    data.Add(getting[i].Id.ToString());
                    data.Add(getting[i].Edition.Name);

                    DataGridViewGetting.Rows.Add(data.ToArray());
                }
            }

            if(DataGridViewGetting.Rows.Count == 0)
            {
                ButtonAccept.Visible = false;
            }
            else ButtonAccept.Visible = true;
        }
    }
}
