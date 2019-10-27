using facerecognition.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace facerecognition
{
    public partial class MenuForm : Form
    {
        public MenuForm(User user)
        {
            InitializeComponent();
            lblUser.Text = user.Name;
            var accessLevels = RecognitionSingleton.Users.Where(_ => _.Name.ToLower() == user.Name.ToLower()).Select(_ => _.Access).Distinct();
            buttonAccess1.Visible = accessLevels.Any(_ => _ == AccessLevel.Governador);
            buttonAccess2.Visible = accessLevels.Any(_ => _ == AccessLevel.Prefeito);
            buttonAccess3.Visible = accessLevels.Any(_ => _ == AccessLevel.Presidente);
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
    }
}
