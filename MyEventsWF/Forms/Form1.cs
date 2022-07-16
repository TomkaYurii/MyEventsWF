using MyEventsAdoNetDB.Repositories.Interfaces;
using MyEventsWF;

namespace WinFormsApp;

public partial class Form1 : Form
{
    private readonly IUnitOfWork _unitOfWork;

    public Form1(IUnitOfWork uow)
    {
        InitializeComponent();
        LoadTheme();
        _unitOfWork = uow;
    }

    private void LoadTheme()
    {
        foreach (Control btns in this.Controls)
        {
            if (btns.GetType() == typeof(Button))
            {
                Button btn = (Button)btns;
                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
        }
        label1.ForeColor = ThemeColor.SecondaryColor;
        label2.ForeColor = ThemeColor.SecondaryColor;
        label3.ForeColor = ThemeColor.SecondaryColor;
        label4.ForeColor = ThemeColor.SecondaryColor;
        label5.ForeColor = ThemeColor.SecondaryColor;
        label6.ForeColor = ThemeColor.PrimaryColor;
        label7.ForeColor = ThemeColor.PrimaryColor;
        label8.ForeColor = ThemeColor.PrimaryColor;
        label9.ForeColor = ThemeColor.PrimaryColor;
    }

    private async void button1_Click(object sender, EventArgs e)
    {
        try
        {
            label9.Hide();
            label9.Text = "";


            int id = Convert.ToInt32(textBox7.Text);
            var product = await _unitOfWork._productRepository.GetAsync(id);

            textBox1.Text = product.Name;
            textBox2.Text = product.Properties;
            textBox3.Text = product.Price.ToString();
            textBox4.Text = product.Seller;
            textBox5.Text = product.Brand;

            var category_of_product = await _unitOfWork._categoryRepository.GetAsync(product.Id);

            textBox6.Text = category_of_product.Name;
        }
        catch (Exception ex)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            label9.Show();
            label9.Text = ex.Message;
        }
    }

    private void button2_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}