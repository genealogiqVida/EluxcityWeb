using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using EluxcityWeb.DTO;
using System.Data.SqlClient;

namespace EluxcityWeb.DAO
{
    public class CoroasDAO : Conexao
    {
        public List<CoroasDTO> carregandoCoroas(string username)
        {
            List<CoroasDTO> list = new List<CoroasDTO>();
            string sql = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();

                sql = " select a.descricaoAcao, sum(ar.qtdeAcoes) as qtdeAcoes, sum((ar.qtdeAcoes * a.qtd_coroas)) as coroas from Acao_Realizada ar "+
                        " inner join Usuario u on ar.idUsuario = u.idUsuario "+
                        " inner join Acao a on a.idAcao = ar.idAcao " +
                        " where u.username = '" + username + "' group by a.descricaoAcao  order by a.descricaoAcao";
          
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string descricaoAcao = dr["descricaoAcao"].ToString();
                    string qtdeAcoes = dr["qtdeAcoes"].ToString();
                    string coroas = dr["coroas"].ToString();


                    if (coroas == null) coroas = "";
                    if (qtdeAcoes == null) qtdeAcoes = "";
                    if (descricaoAcao == null) descricaoAcao = "";

                    CoroasDTO dto = new CoroasDTO();
                    dto.setDescricao(descricaoAcao);
                    dto.setcoroas(coroas);
                    dto.setQuantidade(qtdeAcoes);

                    list.Add(dto);

                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return list;
        }


        
    }
}
