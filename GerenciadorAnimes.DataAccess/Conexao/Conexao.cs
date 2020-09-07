using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAnimes.DataAccess.Conexao
{
    public class Conexao
    {
        public string strConexao = ConfigurationManager.ConnectionStrings["AnimesConn"].ConnectionString;
    }
}
