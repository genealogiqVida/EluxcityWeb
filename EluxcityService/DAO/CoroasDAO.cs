using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using EluxcityWeb.DTO;
using System.Data.SqlClient;
using System.Globalization;

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

        public List<CoroasEspeciaisDTO> carregandoCoroasEspeciais(string username)
        {
            List<CoroasEspeciaisDTO> list = new List<CoroasEspeciaisDTO>();
            string sql = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();

                sql = " select DISTINCT dc.idDebito_Credito, u2.nome as nomeAdministrador, dc.idUsuario, dc.dataHora, dc.justificativa, dc.valor  from Debito_Credito dc " +
                        " inner join Usuario u on dc.idUsuario = u.idUsuario " +
                        " inner join Usuario u2 on dc.idUsuarioAdministrador = u2.idUsuario " +
                        " where u.username = '" + username + "' order by dc.dataHora desc ";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string idUsuario = dr["idUsuario"].ToString();
                    string idDebito_Credito = dr["idDebito_Credito"].ToString();
                    string nomeAdministrador = dr["nomeAdministrador"].ToString();
                    string dataHora = dr["dataHora"].ToString();
                    string justificativa = dr["justificativa"].ToString();
                    string valor = dr["valor"].ToString();

                    CoroasEspeciaisDTO dto = new CoroasEspeciaisDTO();
                    dto.setIdUsuario(idUsuario);
                    dto.setIdDebitoCredito(idDebito_Credito);
                    dto.setNomeAdministrador(nomeAdministrador);
                    dto.setData(DateTime.Parse(dataHora).Date.ToString().Split(' ')[0]);
                    dto.setJustificativa(justificativa);
                    dto.setValor(valor);    

                    list.Add(dto);

                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

            return list;
        }

        public String carregandoDataAtualizacao(string username)
        {
            String dataAtualizacao = "";
            string sql = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();

                sql = " select data_atualizacao from Situacao_Atual sa " +
                        " inner join Usuario u on u.username = '" + username + "' " +
                        " where sa.idUsuario = u.idUsuario ";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    CultureInfo ptBR = new CultureInfo("pt-BR");
                    DateTime data = Convert.ToDateTime(dr["data_atualizacao"].ToString());
                    dataAtualizacao = data.ToString(ptBR);
                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dataAtualizacao;
        }

        public bool verificandoPerfilAdministrador(string username)
        {
            bool isAdmin = false;
            string sql = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();

                sql = " select admin from Usuario u where u.username  = '" + username + "' ";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string admin = dr["admin"].ToString();
                    if (admin.Equals("True"))
                    {
                        isAdmin = true;
                    }else
                    {
                        isAdmin = false;
                    }
                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

            return isAdmin;
        }


    }
}
