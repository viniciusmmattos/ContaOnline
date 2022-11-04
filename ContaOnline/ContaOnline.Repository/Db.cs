using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

namespace ContaOnline.Repository
{
    public static class Db
    {
        private static string _conexao= "server=localhost; persistsecurityinfo=True; database=ContaDB; user=root; password=fernandoadm";

        private static MySqlConnection ObterConnection()
        {
            var cn = new MySqlConnection();
            cn.ConnectionString = _conexao;
            return cn;
        }
        
        public static T QueryEntidade<T>(string storedProcedure, object param)
        {
            T retorno;
            
            using (var cn = ObterConnection())
            {

                retorno=cn.QueryFirstOrDefault<T>(storedProcedure, param, commandType:CommandType.StoredProcedure);
            }
            
            return retorno;
        }

        public static IEnumerable<T> QueryColecao<T>(string storedProcedure, object param)
        {
            IEnumerable<T> retorno;

            using (var cn = ObterConnection())
            {

                retorno = cn.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
            }

            return retorno;
        }
        public static int Execute(string storedProcedure, object param)
        {
            int total;

            using (var cn = ObterConnection())
            {

                total = cn.Execute(storedProcedure, param, commandType: CommandType.StoredProcedure);
            }

            return total;
        }
    }
}
