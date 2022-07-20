﻿using MyEventsAdoNetDB.Repositories.Interfaces;
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
    public partial class ForumForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;

        public ForumForm(IUnitOfWork uow)
        {
            InitializeComponent();
            _unitOfWork = uow;
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
        private void ForumForm_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                label3.BackColor = Color.Red;
                label3.Hide();
                label3.Text = "";
                int id = Convert.ToInt32(textBox1.Text);
                var mymessage = await _unitOfWork._messageRepository.GetAsync(id);
                listBox1.Items.Add(mymessage.Message);
            }
            catch (Exception ex)
            {
                label3.Show();
                label3.Text = ex.Message;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox2.Text == null)
            {
                try
                {
                    var mymessage = await _unitOfWork._messageRepository.AllMessagesByEventName(textBox1.Text);
                    listBox1.Items.Add(mymessage.Message);
                }
                catch (Exception ex)
                {
                    label3.Show();
                    label3.Text = ex.Message;
                }
            }
            if (textBox1.Text == null && textBox2.Text != null)
            {
                try
                {
                    var mymessage = await _unitOfWork._messageRepository.AllMessagesByEventId(Convert.ToInt32(textBox2.Text));
                    listBox1.Items.Add(mymessage.Message);
                }
                catch (Exception ex)
                {
                    label3.Show();
                    label3.Text = ex.Message;
                }
            }
            if (textBox1.Text != null && textBox2.Text != null)
            {
                try
                {
                    var mymessage = await _unitOfWork._messageRepository.AllMessagesByEventIdAndName(Convert.ToInt32(textBox2.Text), textBox1.Text);
                    listBox1.Items.Add(mymessage.Message);
                }
                catch (Exception ex)
                {
                    label3.Show();
                    label3.Text = ex.Message;
                }
            }
            if (textBox1.Text == null && textBox2.Text == null)
            {
                MessageBox.Show("Ви нічого не ввели!");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Функція ще допрацьовується!");
        }
    }
}
