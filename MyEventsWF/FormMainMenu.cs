namespace MyEventsWF
{
    public partial class FormMainMenu : Form
    {
        //Fields
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public FormMainMenu()
        {
            InitializeComponent();
            random = new Random();        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);

        }

        // ==== Õ¿À¿ÿ“”¬¿ÕÕﬂ  ŒÀ‹Œ–” Ã≈Õﬁ ====
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Segoe UI", 12.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    //panelTitleBar.BackColor = color;
                    //panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //ThemeColor.PrimaryColor = color;
                    //ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    //btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 99);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        // ==== œŒƒ≤Ø ====
        private void button1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);        
        }

        private void btnAllEvents_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnMyEvents_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnGallery_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void btnForum_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }

        private void dtnExit_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            Application.Exit();
        }

        private void FormMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}