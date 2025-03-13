using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookManageSystem
{
    public partial class FormLookBorrow: Form
    {
        public FormLookBorrow()
        {
            InitializeComponent();
        }
        private void LoadBorrowBookInformation()
        {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"SELECT * FROM T_Borrow";
            SqlDataReader selectBorrowInformation = dao.read(sql);
            while (selectBorrowInformation.Read())
            {
                dgv.Rows.Add(selectBorrowInformation[0].ToString(), selectBorrowInformation[1].ToString(), selectBorrowInformation[2].ToString(), selectBorrowInformation[3].ToString(), selectBorrowInformation[4].ToString(),
                    selectBorrowInformation[5].ToString(), selectBorrowInformation[6].ToString());
            }
            selectBorrowInformation.Close();
            dao.DaoClose();
        }

        private void 用户租借情况_Load(object sender, EventArgs e)
        {
            this.LoadBorrowBookInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dgv.Rows.Clear();
            string key = this.txtInputKey.Text.ToString();
            Dao dao = new Dao();
            dao.connect();
            string selectSql = $"select * from T_Borrow where Bname like '%{key}%' or Uname like '%{key}%'";
            SqlDataReader selectBorrowInformation = dao.read(selectSql);
            while (selectBorrowInformation.Read())
            {
                dgv.Rows.Add(selectBorrowInformation[0].ToString(), selectBorrowInformation[1].ToString(), selectBorrowInformation[2].ToString(), selectBorrowInformation[3].ToString(), selectBorrowInformation[4].ToString(),
                    selectBorrowInformation[5].ToString(), selectBorrowInformation[6].ToString());
            }
            selectBorrowInformation.Close();
            dao.DaoClose();
        }
    }
}
