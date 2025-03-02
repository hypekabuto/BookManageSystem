using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManageSystem
{
    class Dao
    {
        SqlConnection con;
        public SqlConnection connect()
        {
            //  连接数据库
            string MySqlCon = "Data Source=127.0.0.1;Initial Catalog=BookManageSystem;User ID=sa;Encrypt=False";
            con = new SqlConnection(MySqlCon);
            con.Open();
            return con;
        }

        public SqlCommand command(string sql)
        {
            //请求命令
            SqlCommand cmd = new SqlCommand(sql, connect());
            return cmd;
        }

        public int Execute(string sql)
        {
            // 检测数据数目
            return command(sql).ExecuteNonQuery();
        }

        public SqlDataReader read(String sql)
        {
            // 读取数据
            return command(sql).ExecuteReader();
        }
        public void DaoClose() {
            con.Close();
        }
    }
}
