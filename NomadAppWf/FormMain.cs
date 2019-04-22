using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NomadAppWf
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void ButtonUpClick(object sender, EventArgs e)
        {
            Hide();
            FormRegistration formRegistration = new FormRegistration(this);
            formRegistration.Show();
        }

        private void ButtonInClick(object sender, EventArgs e)
        {
            Hide();
            FormAuthorization formAuthorization = new FormAuthorization(this);
            formAuthorization.Show();
        }
    }
}
