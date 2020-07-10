using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace QuanLyDiem
{
    public partial class Form1 : Form
    {
        DataTable tblDiem;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            string sql = "select MaLop from Lop";
            DAO.FillDataToCombo(sql, cmbMaLop, "MaLop", "MaLop");
            sql = "select MaMon, TenMon from MonHoc";
            DAO.FillDataToCombo(sql, cmbMonHoc, "MaMon", "TenMon");
            Load_DataGridView();
            cmbMaLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbHocKy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbMonHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //GridViewDiem.Enabled = false;
            //GridViewDiem.Cells[0].Selected = false;
            /* string s1 = DAO.GetFieldValues("SELECT MaSV FROM SinhVien");
             MessageBox.Show(s1);
             string s2 = "select MaSV from Diem where MaSV='" + s1 + "'";
             MessageBox.Show(s2);
             if (DAO.CheckKeyExist(s2) == false)
             {
                 string s3 = "INSERT INTO Diem VALUES('" +s1+"', null,null, null,null,null)";
                 MessageBox.Show(s3);
                 DAO.RunSql(sql);
                 Load_DataGridView();
             }*/
           
            Load_DataGridView();
        }
        private void Load_DataGridView()
        {
            try
            {
                DAO.OpenConnection();
                string str;
                str = "select * from Diem";
                tblDiem = DAO.GetDataToTable(str);
                GridViewDiem.DataSource = tblDiem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DAO.CloseConnection();
            }

        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            DAO.OpenConnection();
            /*string s0 = "INSERT INTO Diem(MaSV) select MaSV from SinhVien";
            DAO.RunSql(s0);
            Load_DataGridView();*/
            string s1 = DAO.GetFieldValues("SELECT MaSV FROM SinhVien");
            MessageBox.Show(s1);
            string s2 = "select MaSV from Diem where MaSV='" + s1 + "'";
            MessageBox.Show(s2);
            if (DAO.CheckKeyExist(s2) == false)
            {
                string s3 = "INSERT INTO Diem VALUES('" + s1 + "', null,null, null,null,null)";
                MessageBox.Show(s3);
                DAO.RunSql(s3);
                Load_DataGridView();
            }
        }
    }
}
