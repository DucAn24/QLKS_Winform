﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiKhachSan.All_User_Control
{
    public partial class uc_CheckOut : UserControl
    {
        DBconnection db = new DBconnection();

        public uc_CheckOut()
        {
            InitializeComponent();
        }

        private void uc_CheckOut_Load(object sender, EventArgs e)
        {
            LoadInvoiceDetails();
        }

        private void LoadInvoiceDetails()
        {
            DataTable dtInvoice = db.GetInvoiceDetails();
            dataGridViewInvoice.DataSource = dtInvoice;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadInvoiceDetails();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                string sdt = txtSDTThanhToan.Text;
                int? maNV = string.IsNullOrWhiteSpace(txtMaNVXuatHoaDon.Text) ? (int?)null : int.Parse(txtMaNVXuatHoaDon.Text);

                db.ThanhToanHoaDon(sdt, maNV);
                MessageBox.Show("Payment successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInvoiceDetails(); // Refresh the invoice details
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing the payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
