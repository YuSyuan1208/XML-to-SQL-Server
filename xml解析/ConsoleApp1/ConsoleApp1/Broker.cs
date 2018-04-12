using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Broker
    {
        SqlConnection conn;
        SqlConnectionStringBuilder connstringbuilder;
        void ConnectTo()
        {
            connstringbuilder = new SqlConnectionStringBuilder();
            connstringbuilder.DataSource = "DESKTOP-6THANQL";
            connstringbuilder.InitialCatalog = "1104105303";
            connstringbuilder.IntegratedSecurity = true;
            conn = new SqlConnection(connstringbuilder.ToString());
        }
        public Broker()
        {
            ConnectTo();
        }
        public void insert(OpenData p)
        {

                string cmdtext = "INSERT INTO dbo.藥局資訊(機構名稱,機構狀態,地址,電話) VALUES(@機構名稱,@機構狀態,@地址,@電話)";
                SqlCommand cmd = new SqlCommand(cmdtext, conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@機構名稱", p.機構名稱);
                cmd.Parameters.AddWithValue("@機構狀態", p.機構狀態);
                cmd.Parameters.AddWithValue("@地址", p.地址);
                cmd.Parameters.AddWithValue("@電話", p.電話);
                cmd.ExecuteNonQuery();
                conn.Close();
            
        }
    }
}
