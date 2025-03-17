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
    public partial class FormAdminFeedBack : Form
    {
        public FormAdminFeedBack()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAdminFeedBack_Load(object sender, EventArgs e)
        {
            Dao dao = new Dao();
            dao.connect();
            string sql = $"SELECT * FROM T_FeedBack";
            SqlDataReader dataReader = dao.read(sql);
            while (dataReader.Read() == true)
            {
                dgv.Rows.Add(dataReader[0].ToString(), dataReader[1].ToString(), dataReader[2].ToString());
            }
            dataReader.Close();
            dao.DaoClose();
        }
    }
}
