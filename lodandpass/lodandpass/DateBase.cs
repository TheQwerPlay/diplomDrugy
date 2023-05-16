using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lodandpass
{
    class DateBase
    {
        SqlConnection myConnection = new SqlConnection(@"Data Source = DESKTOP-R7BKC4T\SQLEXPRESS; Initial Catalog = магазин услуг; Integrated Security = True");
        public void openConnection()
        {
            if (myConnection.State == System.Data.ConnectionState.Closed)
            {
                myConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (myConnection.State == System.Data.ConnectionState.Open)
            {
                myConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return myConnection;
        }
    }
}
