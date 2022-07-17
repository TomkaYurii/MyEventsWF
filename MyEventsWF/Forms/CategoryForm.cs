using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEventsWF.Forms
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }
        private void LoadTheme()
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.ForeColor = ThemeColor.PrimaryColor;
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
    }
}
