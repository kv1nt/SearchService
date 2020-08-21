using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DBSearchLib
{
    public class SerachService
    {
        /// <summary>
        /// Search in Db
        /// </summary>
        /// <typeparam name="T">Model Data Transter</typeparam>
        /// <param name="ps">Model Data Transter</param>
        /// <param name="tableName">Database Table Name</param>
        /// <param name="connectionString">Database Connection string</param>
        public void Search<T>(T ps, string tableName, string connectionString) where T : class
        {
            Type tModelType = ps.GetType();
            PropertyInfo[] propInfos1 = tModelType.GetProperties();
            var props = propInfos1;
            var selectQuery = new StringBuilder($"SELECT * FROM {tableName}");
            selectQuery.Append($" WHERE");
            string typeVariant = string.Empty;
            var val = string.Empty;
            decimal res = 0;
            foreach (var item in props)
            {
                if(item.PropertyType.Name == "Decimal")
                {
                  
                }
                if (item.GetValue(ps) != null)
                {
                    typeVariant = item.PropertyType.Name == "String" ? $" [{item.Name}] = '{item.GetValue(ps)}' AND" :
                                $" [{item.Name}] = {item.GetValue(ps)} AND";
                    selectQuery.Append(typeVariant);
                }

            }
            selectQuery.Remove(selectQuery.Length - 3, 3);
            Console.Write(selectQuery);
            using (var conn = new SqlConnection(connectionString))
                try
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = selectQuery.ToString();
                    command.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(selectQuery.ToString(), conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    SqlDataReader reader = command.ExecuteReader();
                    //adapter.Fill(ds);

                    while (reader.Read())
                    {

                        foreach (var item in props)
                        {
                            var name = item.Name;
                            var val = reader[item.Name].ToString();
                        }
                    }



                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
        }
    }
}
