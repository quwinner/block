using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace block
{
    public static class SQLClass
    {
        public static string db4free_server =
            "SslMode=none;" +
            "Server=db4free.net;" +
            "database=ingenerka;" +
            "port=3306;" +
            "uid=ingenerka;" +
            "pwd=Beavis1989;" +
            "old guids=true;";

        public static string new_server =
            "SslMode=none;" +
            "Server=37.230.116.173;" +
            "database=ingenerka;" +
            "port=3306;" +
            "uid=program;" +
            "pwd=ingenerka;" +
            "old guids=true;";

        public static MySqlConnection CONN;

        /// <summary>
        /// Открываем соединение
        /// </summary>
        public static void OpenConnection()
        {
            CONN = new MySqlConnection(new_server);
            try
            {
                CONN.Open();
            }
            catch (Exception)
            {
                OpenConnection();
            }
        }


        public static void CloseConnection()
        {
            CONN.Close();
        }

        public static void Insert(string cmdText)
        {
            using (MySqlCommand cmd = new MySqlCommand(cmdText, CONN))
            {
                if (CONN.State != ConnectionState.Open)
                {
                    CONN.Open();
                }
                using (MySqlDataReader rdr = cmd.ExecuteReader())
                {
                    rdr.Close();
                }
            }
        }

        /// <summary>
        /// Delete-запрос
        /// </summary>
        public static void Delete(string cmdText)
        {
            Insert(cmdText);
        }

        public static void Update(string cmdText)
        {
            Insert(cmdText);
        }

        /// <summary>
        /// Select-запрос
        /// </summary>
        /// <param name="query">Запрос</param>
        /// <returns>Результат в виде списка строк</returns>
        public static List<string> Select(string query)
        {
            List<string> res = new List<string>();
            using (MySqlCommand q = new MySqlCommand(query, CONN))
            {
                if (CONN.State != ConnectionState.Open)
                {
                    CONN.Open();
                }
                using (MySqlDataReader r = q.ExecuteReader())
                {
                    while (r.Read())
                    {
                        for (int inc = 0; inc < r.FieldCount; inc++)
                        {
                            res.Add(r[inc].ToString());
                        }
                    }
                    r.Close();
                }
                return res;
            }
        }

        public static List<String> Select(string query, Dictionary<String, String> ParamsDict)
        {
            List<String> res = new List<String>();
            MySqlCommand q = new MySqlCommand(query, CONN);
            if (CONN.State != ConnectionState.Open)
            {
                CONN.Open();
            }

            q.Parameters.Clear();
            foreach (KeyValuePair<string, string> Pair in ParamsDict)
            {
                q.Parameters.AddWithValue("@" + Pair.Key, Pair.Value);
            }
            MySqlDataReader r = q.ExecuteReader();

            while (r.Read())
            {
                for (int inc = 0; inc < r.FieldCount; inc++)
                {
                    res.Add(r[inc].ToString());
                }
            }
            r.Close();

            return res;
        }
    }
}