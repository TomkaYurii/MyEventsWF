﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyEventsAdoNetDB.Repositories.Interfaces;
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
        private readonly IServiceProvider serviceProvider;
        private readonly ILogger<CategoryForm> logger;

        public CategoryForm(IServiceProvider serviceProvider, ILogger<CategoryForm> logger)
        {
            InitializeComponent();
            this.serviceProvider = serviceProvider;
            this.logger = logger;
        }

        // ============================
        // Налаштування кольорової теми
        // ============================
        private void LoadTheme()
        {
            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Font = new System.Drawing.Font("Verdana", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.BackColor = ThemeColor.PrimaryColor;
                btn.ForeColor = Color.White;
                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
            }
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.Font = new System.Drawing.Font("Verdana", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbl.ForeColor = ThemeColor.PrimaryColor;
            }
            foreach (TextBox txtb in this.Controls.OfType<TextBox>())
            {
                txtb.Font = new System.Drawing.Font("Verdana", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                txtb.ForeColor = ThemeColor.PrimaryColor;
            }
        }
        // EVENTS
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            this.logger.LogInformation(DateTime.UtcNow + "=>" + "Запит до БД: отримання категорії по Id");
            using (IServiceScope serviceScope = this.serviceProvider.CreateScope())
            {
                IServiceProvider provider = serviceScope.ServiceProvider;
                var _unitOfWork = provider.GetRequiredService<IUnitOfWork>();
                try
                {
                    label3.BackColor = Color.Red;
                    label3.Hide();
                    label3.Text = "";
                    int id = Convert.ToInt32(textBox1.Text);
                    var product = await _unitOfWork._categoryRepository.GetAsync(id);
                    textBox2.Text = product.Name;
                    _unitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    label3.Show();
                    label3.Text = ex.Message;
                }
            }
        }
    }
}
