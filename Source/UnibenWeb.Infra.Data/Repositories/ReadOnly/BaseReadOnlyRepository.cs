using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using UnibenWeb.Domain.Entities;
using UnibenWeb.Domain.Interfaces.Repository.ReadOnly;

namespace UnibenWeb.Infra.Data.Repositories.ReadOnly
{
    public class BaseReadOnlyRepository : IBaseReadOnlyRepository
    {
        public IDbConnection Connection => new SqlConnection(ConfigurationManager.ConnectionStrings["UnibenConnection"].ConnectionString);

        public IEnumerable<T> Pesquisar<T>(int offsetRows, int numRows, string pesquisa, string tabela)
        {
            using (var cn = Connection)
            {
                cn.Open();
                string sql;
                if (string.IsNullOrEmpty(pesquisa))
                {
                    sql = @"SELECT * FROM {0} tb
                    ORDER BY 1
                    OFFSET @pOffset ROWS
                    FETCH NEXT @pRows ROWS ONLY";
                    sql = string.Format(sql, tabela);
                }
                else
                {
                    sql = @"SELECT * FROM {0} tb
                    WHERE ({1}) ORDER BY 1";
                    sql = string.Format(sql, tabela, pesquisa);
                }

                var result = cn.Query<T>(sql, new { pPesquisa = pesquisa, pOffset = offsetRows, pRows = numRows });
                return result;
            }
        }

        public IEnumerable<T> PesquisarJoinWhere<T>(int offsetRows, int numRows, string pesquisa, string tabela, string join)
        {
            using (var cn = Connection)
            {
                cn.Open();
                string sql;
                if (string.IsNullOrEmpty(pesquisa))
                {
                    sql = @"SELECT tb.* FROM {0} tb {1}
                    ORDER BY 1
                    OFFSET @pOffset ROWS
                    FETCH NEXT @pRows ROWS ONLY";
                    sql = string.Format(sql, tabela, join);
                }
                else
                {
                    sql = @"SELECT tb.* FROM {0} tb {1}
                    WHERE ({2}) ORDER BY 1";
                    sql = string.Format(sql, tabela, join, pesquisa);
                }

                var result = cn.Query<T>(sql, new { pPesquisa = pesquisa, pOffset = offsetRows, pRows = numRows });
                return result;
            }
        }


    }
}
