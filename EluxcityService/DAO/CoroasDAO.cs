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

                /*sql = " select a.descricaoAcao, sum(ar.qtdeAcoes) as qtdeAcoes, sum((ar.qtdeAcoes * a.qtd_coroas)) as coroas from Acao_Realizada ar "+
                        " inner join Usuario u on ar.idUsuario = u.idUsuario "+
                        " inner join Acao a on a.idAcao = ar.idAcao " +
                        " where u.username = '" + username + "' group by a.descricaoAcao  order by a.descricaoAcao";*/

                sql = " SELECT nome, data_atualizacao, numero_total_cursos, curso_online, baseado_web, sala_aula_virtual, presencial, numero_curriculos_concluidos, numero_curriculos_concluidos_antes_prazo, avaliacao_exito, avaliacao_exito_coroas FROM Situacao_Atual sa " +
                      "  INNER JOIN Usuario u on sa.idUsuario = u.idUsuario "+
                      "  WHERE u.username = '" + username + "' ";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cursoOnline = dr["curso_online"].ToString();
                    string baseadoWeb = dr["baseado_web"].ToString();
                    string salaVirtual = dr["sala_aula_virtual"].ToString();
                    string presencial = dr["presencial"].ToString();
                    string avaliacaoExito = dr["avaliacao_exito"].ToString();
                    string avaliacaoExitoCoroas = dr["avaliacao_exito_coroas"].ToString();

                    string curriculosConcluidos = dr["numero_curriculos_concluidos"].ToString();
                    string curriculosAntesPrazo = dr["numero_curriculos_concluidos_antes_prazo"].ToString();

                    if(cursoOnline != "0")
                    {
                        int acoesCursoOnline = int.Parse(cursoOnline);
                        int coroasCursoOnline = int.Parse(cursoOnline) * 50;
                        if(baseadoWeb != "0")
                        {
                            acoesCursoOnline += int.Parse(baseadoWeb);
                            coroasCursoOnline += int.Parse(baseadoWeb) * 50;
                        }
                        CoroasDTO cursoOnlineDTO = new CoroasDTO();
                        cursoOnlineDTO.setDescricao("Curso Online");
                        cursoOnlineDTO.setcoroas(coroasCursoOnline.ToString());
                        cursoOnlineDTO.setQuantidade(acoesCursoOnline.ToString());
                        list.Add(cursoOnlineDTO);
                    }
                    if(salaVirtual != "0")
                    {
                        int coroasSalaVirtual = int.Parse(salaVirtual) * 100;
                        CoroasDTO salaVirtualDTO = new CoroasDTO();
                        salaVirtualDTO.setDescricao("Sala de Aula Virtual");
                        salaVirtualDTO.setcoroas(coroasSalaVirtual.ToString());
                        salaVirtualDTO.setQuantidade(salaVirtual);
                        list.Add(salaVirtualDTO);
                    }
                    if (presencial != "0")
                    {
                        int coroasPresencial = int.Parse(salaVirtual) * 100;
                        CoroasDTO presencialDTO = new CoroasDTO();
                        presencialDTO.setDescricao("Presencial");
                        presencialDTO.setcoroas(coroasPresencial.ToString());
                        presencialDTO.setQuantidade(presencial);
                        list.Add(presencialDTO);
                    }
                    if (curriculosConcluidos != "0")
                    {
                        int coroasCurriculos = int.Parse(curriculosConcluidos) * 300;
                        CoroasDTO curriculosDTO = new CoroasDTO();
                        curriculosDTO.setDescricao("Trilhas Adquiridas");
                        curriculosDTO.setcoroas(coroasCurriculos.ToString());
                        curriculosDTO.setQuantidade(curriculosConcluidos);
                        list.Add(curriculosDTO);
                    }
                    if(avaliacaoExito != "0")
                    {
                        CoroasDTO avaliacoesExitoDTO = new CoroasDTO();
                        avaliacoesExitoDTO.setDescricao("Avaliações com Êxito");
                        avaliacoesExitoDTO.setcoroas(avaliacaoExitoCoroas);
                        avaliacoesExitoDTO.setQuantidade(avaliacaoExito);
                        list.Add(avaliacoesExitoDTO);
                    }

                   // string coroasCurriculosAntesPrazo = (Int64.Parse(cursoOnline) * 50).ToString();



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
