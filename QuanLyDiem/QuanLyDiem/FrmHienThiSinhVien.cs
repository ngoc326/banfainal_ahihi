using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows;
namespace QuanLyDiem
{
    public partial class FrmHienThiSinhVien : Form
    {
        DataTable tblSinhVien;
        public FrmHienThiSinhVien()
        {
            InitializeComponent();
        }

        private void FrmHienThiSinhVien_Load(object sender, EventArgs e)
        {  
            DAO.OpenConnection();           
            string sql = "select MaLop, TenLop from Lop";
            DAO.FillDataToCombo(sql, cmbMaLop, "MaLop", "TenLop");
            cmbMaLop.SelectedIndex = -1;
             //LoadDatatogriview();
        }
    
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(cmbMaLop.SelectedIndex==-1)
            {
                MessageBox.Show(" bạn chưa chọn  khoa");
                cmbMaLop.Focus();
                return;
            }
            try
            {
                DAO.OpenConnection();
                string sql = " select * from SinhVien where MaLop='" + cmbMaLop.SelectedValue.ToString() + "'";
                tblSinhVien = DAO.GetDataToTable(sql);
                GridViewSinhVien.DataSource = tblSinhVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO.CloseConnection();
            }
            cmbMaLop.SelectedIndex = -1;
            cmbMaLop.Focus();
            return;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            cmbMaLop.SelectedIndex = -1;
            btnHuy.Enabled = false;
            btnHuy.Enabled = true;                                   
        }
    }
}
