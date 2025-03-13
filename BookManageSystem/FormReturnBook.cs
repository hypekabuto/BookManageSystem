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
    public partial class FormReturnBook: Form
    {
        public FormReturnBook()
        {
            InitializeComponent();
        }
        private void LoadBorrowBookInformation() {
            dgv.Rows.Clear();
            Dao dao = new Dao();
            dao.connect();
            string sql = $"SELECT * FROM T_Borrow WHERE Uid = {Form1.id}";
            SqlDataReader selectBorrowInformation = dao.read(sql);
            while (selectBorrowInformation.Read())
            {
                dgv.Rows.Add(selectBorrowInformation[0].ToString(), selectBorrowInformation[1].ToString(), selectBorrowInformation[2].ToString(), selectBorrowInformation[3].ToString(), selectBorrowInformation[4].ToString(),
                    selectBorrowInformation[5].ToString(), selectBorrowInformation[6].ToString());
            }
            selectBorrowInformation.Close();
            dao.DaoClose();
        }

        private void FormReturnBook_Load(object sender, EventArgs e)
        {
            this.LoadBorrowBookInformation();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow.Cells[0].Value == null)
            {
                MessageBox.Show("请选择要归还的书籍", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else {
                int keys = int.Parse(dgv.CurrentRow.Cells[0].Value.ToString());
                Dao dao = new Dao();
                dao.connect();
                string deleteSql = $"delete T_Borrow where [key] = {keys}";
                string updateSql = $"update T_Book set Num = Num + {int.Parse(dgv.CurrentRow.Cells[5].Value.ToString())} where Bid = {dgv.CurrentRow.Cells[6].Value.ToString()}"; 
                if(dao.Execute(deleteSql) + dao.Execute(updateSql) >= 2)
                {
                    MessageBox.Show("归还成功", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.LoadBorrowBookInformation();
                    dao.DaoClose();
                }
                else
                {
                    MessageBox.Show("归还失败", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dao.DaoClose();
                }
            }
        }
    }
}
