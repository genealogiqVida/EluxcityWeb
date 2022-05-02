using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;
using System.Data.SqlClient;
using System.Configuration;

namespace EluxcityWeb.DAO
{
    public class PerguntaDAO : Conexao
    {

        private const string TABLE_NAME = "pergunta";
        private const string TABLE_NAME_COMENTARIO = "comentario";
        private const string PK_NAME = "cod_pergunta";
        private const string FK_NAME = "cod_ocorrencia";
        private const string PK_NAME_COMENTARIO = "cod_comentario";

        private const string INSERT_SQL_QUERY = "insert into " + TABLE_NAME + " (" + PK_NAME + ", cod_ocorrencia, tipo, ordem, ordem_prox_se_sim, ordem_prox_se_nao, redacao_pergunta_por, redacao_pergunta_esp, redacao_pergunta_ing, resposta_por, resposta_esp, resposta_ing, cod_pais, tipo_arvore) " +
                                 " values (@codigoPergunta, @codigoOcorrencia, @tipo, @ordem, @ordemProxSeSim, @ordemProxSeNao, @redacaoPerguntaPor, @redacaoPerguntaEsp, @redacaoPerguntaIng, @respostaPor, @respostaEsp, @respostaIng, @codPais, @tipoArvore) ";

        private const string UPDATE_PERGUNTA_ONLY_SQL_QUERY = "update " + TABLE_NAME +
                    " set ordem = @ordem, redacao_pergunta_por = @redacaoPerguntaPor , redacao_pergunta_esp = @redacaoPerguntaEsp , redacao_pergunta_ing = @redacaoPerguntaIng ," +
                    " where " + PK_NAME + " = @codigoPergunta";

        private const string UPDATE_RESPOSTA_ONLY_SQL_QUERY = "update " + TABLE_NAME +
                    " tipo = @tipo , ordem_prox_se_sim = @ordemProxSeSim , ordem_prox_se_nao = @ordemProxSeNao ," +
                    " resposta_por = @respostaPor, resposta_esp = @respostaEsp , resposta_ing = @respostaIng" +
                    " where " + PK_NAME + " = @codigoPergunta";



        private const string UPDATE_SQL_QUERY = "update " + TABLE_NAME +
                    " set cod_ocorrencia = @codigoOcorrencia ," +
                    " tipo = @tipo , ordem = @ordem, ordem_prox_se_sim = @ordemProxSeSim , ordem_prox_se_nao = @ordemProxSeNao ," +
                    " redacao_pergunta_por = @redacaoPerguntaPor , redacao_pergunta_esp = @redacaoPerguntaEsp , redacao_pergunta_ing = @redacaoPerguntaIng ," +
                    " resposta_por = @respostaPor, resposta_esp = @respostaEsp , resposta_ing = @respostaIng" +
                    " where " + PK_NAME + " = @codigoPergunta";



        private const string DELETE_SQL_QUERY = "delete from " + TABLE_NAME + " where " + PK_NAME + " = ";

        private const string DELETE_SQL_QUERY_MODELO = "delete from modelo_pergunta where " + PK_NAME + " = ";

        private const string NEXT_MARKER = "qtde";
        private const string GET_NEXT_SQL_QUERY = "select max(" + PK_NAME + ") + 1 as " + NEXT_MARKER + " from " + TABLE_NAME;

        private const string GET_NEXT_SQL_QUERY_COMENTARIO = "select max(" + PK_NAME_COMENTARIO + ") + 1 as " + NEXT_MARKER + " from " + TABLE_NAME_COMENTARIO;



        private const string SELECT_MANY_SQL_QUERY = "select " + PK_NAME + ", cod_ocorrencia, tipo, ordem, ordem_prox_se_sim, ordem_prox_se_nao, redacao_pergunta_por, redacao_pergunta_esp, redacao_pergunta_ing, resposta_por, resposta_esp, resposta_ing from " + TABLE_NAME +
                  "where " + FK_NAME + " = ";

        private const string SELECT_ONE_SQL_QUERY = "select " + PK_NAME + ", cod_ocorrencia, tipo, ordem, ordem_prox_se_sim, ordem_prox_se_nao, redacao_pergunta_por, redacao_pergunta_esp, redacao_pergunta_ing, resposta_por, resposta_esp, resposta_ing from " + TABLE_NAME +
                  "where " + PK_NAME + " = ";


        public string inserindoDados(string codigoPergunta, string codigoOcorrencia, string tipo, string ordem,
            string ordemProxSeSim, string ordemProxSeNao,
            string redacaoPerguntaPor, string redacaoPerguntaEsp, string redacaoPerguntaIng,
            string respostaPor, string respostaEsp, string respostaIng, string codPais, string tipoArvore, string idioma, string codModelo)
        {
            string result = "";
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = INSERT_SQL_QUERY;
                SqlCommand comando = getSqlAndChangeParameters(sql, con,
                                                               codigoPergunta, codigoOcorrencia, tipo, ordem,
                                                                ordemProxSeSim, ordemProxSeNao,
                                                                redacaoPerguntaPor, redacaoPerguntaEsp, redacaoPerguntaIng,
                                                                respostaPor, respostaEsp, respostaIng, codPais, tipoArvore, idioma);
                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            finally { con.Close(); }
            return result;
        }


        public void inserindoDadosComentario(string codigoPesquisa, string tipo, string codigoPergunta, 
            string codigoComentario, string redacao, string util)
        {
            SqlConnection con = null;
            try
            {

                if (util.Equals("S"))
                {
                    tipo = "1";
                }
                else
                {
                    tipo = "0";
                }
                  con = getConexao();
                string sql = "insert into comentario (cod_comentario, cod_pesquisa, cod_pergunta, foi_util, redacao_comentario, data_e_hora) " +
                            " values (@codigoComentario, @codigoPesquisa , @codigoPergunta , @tipo, @redacao, @dataHora) ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@codigoComentario", codigoComentario);
                comando.Parameters.AddWithValue("@codigoPesquisa", codigoPesquisa);
                comando.Parameters.AddWithValue("@codigoPergunta", codigoPergunta);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@redacao", redacao);
                comando.Parameters.AddWithValue("@dataHora", DateTime.Now);

                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e) {}
            finally { con.Close(); }
            
        }


        public void inserindoHistoricoImportacao(string cod_linha, string cod_produto, string cod_modelo, string cod_ocorrencia,
            string cod_pergunta, string cod_pais, string usuario, string tipo_arvore)
        {
            SqlConnection con = null;
            try
            {


                con = getConexao();
                string sql = "insert into historico_importacao (cod_linha, cod_produto, cod_modelo, cod_ocorrencia, cod_pergunta, cod_pais, usuario, data_hora, tipo_arvore) " +
                            " values (@cod_linha, @cod_produto, @cod_modelo, @cod_ocorrencia, @cod_pergunta, @cod_pais, @usuario, @data_hora, @tipo_arvore) ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@cod_linha", cod_linha);
                comando.Parameters.AddWithValue("@cod_produto", cod_produto);
                comando.Parameters.AddWithValue("@cod_modelo", cod_modelo);
                comando.Parameters.AddWithValue("@cod_ocorrencia", cod_ocorrencia);
                comando.Parameters.AddWithValue("@cod_pergunta", cod_pergunta);
                comando.Parameters.AddWithValue("@cod_pais", cod_pais);
                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@data_hora", DateTime.Now);
                comando.Parameters.AddWithValue("@tipo_arvore", tipo_arvore);

                con.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e) { }
            finally { con.Close(); }

        }



        public void inserindoDadosModelo(string cod_pergunta, string cod_modelo)
        {
            SqlConnection con = null;
            try
            {

                
                con = getConexao();
                string sql = "insert into modelo_pergunta (cod_pergunta, cod_modelo) " +
                            " values (@cod_pergunta, @cod_modelo) ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@cod_pergunta", cod_pergunta);
                comando.Parameters.AddWithValue("@cod_modelo", cod_modelo);
             

                con.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e) { }
            finally { con.Close(); }

        }


        public void alterandoDadosComentario(string codigoPesquisa, string tipo, string codigoPergunta,
           string codigoComentario, string redacao, string util)
        {
            SqlConnection con = null;
            try
            {
                if (util.Equals("S"))
                {
                    tipo = "1";
                }
                else
                {
                    tipo = "0";
                }
                  con = getConexao();
                if (tipo.Equals(""))
                {
                    string sql = "update comentario set redacao_comentario = @redacao  " +
                           "  where cod_comentario = @codigoComentario ";

                    SqlCommand comando = new SqlCommand(sql, con);
                    comando.Parameters.AddWithValue("@redacao", redacao);
                    comando.Parameters.AddWithValue("@codigoComentario", codigoComentario);
                    con.Open();
                    comando.ExecuteNonQuery();
                    con.Close();
                }

                else if (redacao.Equals(""))
                {
                    string sql = "update comentario set foi_util = @tipo  " +
                           "  where cod_comentario = @codigoComentario ";

                    SqlCommand comando = new SqlCommand(sql, con);
                    comando.Parameters.AddWithValue("@tipo", tipo);
                    comando.Parameters.AddWithValue("@codigoComentario", codigoComentario);
                    con.Open();
                    comando.ExecuteNonQuery();
                    
                }

               
                

                
            }
            catch (Exception e) { }
            finally { con.Close(); }

        }

        public string verificaExisteComentario(string codigoPesquisa, string codigoPergunta)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "select cod_comentario from comentario where cod_pesquisa = " + codigoPesquisa + " and cod_pergunta = " + codigoPergunta + " ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_comentario"].ToString();
                }

                
            }
            catch (Exception e) { }

            finally { con.Close(); }

            return codigo;
        }


        public string verificaExisteComentarioUsuario(string nome, string codigoPergunta)
        {
            string codigo = "0";
            String stringConnection = ConfigurationManager.ConnectionStrings["conexaoArvore"].ConnectionString;
            SqlConnection conUser = new SqlConnection(stringConnection);
            try
            {
               // conUser = getConexao();
                string sql = " select top 1 c.cod_comentario from pesquisa a "+
                    " inner join ocorrencia b on b.cod_ocorrencia = a.cod_ocorrencia  "+
                    " inner join pergunta d on d.cod_ocorrencia = b.cod_ocorrencia  "+
                    " inner join comentario c on c.cod_pergunta = d.cod_pergunta and  a.cod_pesquisa = c.cod_pesquisa   " +
                    " where rtrim(a.nome_usuario) = '" + nome.Trim() + "' and d.cod_pergunta =  " + codigoPergunta +
                     " AND c.redacao_comentario is not null ";
                SqlCommand comandoUser = new SqlCommand(sql, conUser);
                conUser.Open();
                SqlDataReader dr = comandoUser.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_comentario"].ToString();
                }


            }
            catch (Exception e) { codigo = e.Message; }

            finally { conUser.Close(); }

            return codigo;
        }


        public string verificaExiste(string nomePor, string cod_ocorrencia)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                  string sql = "select cod_pergunta from pergunta where redacao_pergunta_por = '" + nomePor + "' and cod_ocorrencia = " + cod_ocorrencia;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_pergunta"].ToString();
                }

                
            }
            catch (Exception e) { }

            finally { con.Close(); }

            return codigo;
        }


        public string carregaCondicional(string cod_ocorrencia)
        {
            string codigo = "";
            string virgula = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = " select ordem_prox_se_nao, ordem_prox_se_sim from pergunta where cod_ocorrencia = "+cod_ocorrencia +
		"  and ordem_prox_se_nao > 0 and ordem_prox_se_sim > 0 ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    string ordem_prox_se_nao = dr["ordem_prox_se_nao"].ToString();
                    string ordem_prox_se_sim = dr["ordem_prox_se_sim"].ToString();

                    codigo = codigo + virgula + ordem_prox_se_nao + "," + ordem_prox_se_sim;
                    virgula = ",";
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return codigo;
        }


        public string carregaCodigoPais(string nome)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "select cod_pais from pais where nome_pais = '" + nome + "' ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_pais"].ToString();
                }

              
            }
            catch (Exception e) { }

            finally { con.Close(); }

            return codigo;
        }

        public string alterandoDados(string codigoPergunta, string codigoOcorrencia, string tipo, string ordem,
            string ordemProxSeSim, string ordemProxSeNao,
            string redacaoPerguntaPor, string redacaoPerguntaEsp, string redacaoPerguntaIng,
            string respostaPor, string respostaEsp, string respostaIng, string codPais, string tipoArvore, string idioma)
        {
            string result = "";
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = UPDATE_SQL_QUERY;

                SqlCommand comando = getSqlAndChangeParameters(sql, con,
                                                                codigoPergunta, codigoOcorrencia, tipo, ordem,
                                                                ordemProxSeSim, ordemProxSeNao,
                                                                redacaoPerguntaPor, redacaoPerguntaEsp, redacaoPerguntaIng,
                                                                respostaPor, respostaEsp, respostaIng, codPais, tipoArvore, idioma);
                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e) { result = e.Message; }
            finally { con.Close(); }
            return result;
        }


        public bool alterandoPerguntaApenas(string codigoPergunta, string ordem,
            string redacaoPerguntaPor, string redacaoPerguntaEsp, string redacaoPerguntaIng)
        {
            bool bSalvou = true;
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = UPDATE_PERGUNTA_ONLY_SQL_QUERY;

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@codigoPergunta", codigoPergunta);
                comando.Parameters.AddWithValue("@ordem", ordem);
                comando.Parameters.AddWithValue("@redacaoPerguntaPor", redacaoPerguntaPor);
                comando.Parameters.AddWithValue("@redacaoPerguntaEsp", redacaoPerguntaEsp);
                comando.Parameters.AddWithValue("@redacaoPerguntaIng", redacaoPerguntaIng);

                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e) { bSalvou = false; }
            finally { con.Close(); }
            return bSalvou;
        }

        public bool alterandoRespostaApenas(string codigoPergunta, string tipo,
            string ordemProxSeSim, string ordemProxSeNao,
            string respostaPor, string respostaEsp, string respostaIng)
        {
            bool bSalvou = true;
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = UPDATE_RESPOSTA_ONLY_SQL_QUERY;
                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@codigoPergunta", codigoPergunta);
                comando.Parameters.AddWithValue("@tipo", tipo);
                comando.Parameters.AddWithValue("@ordemProxSeSim", ordemProxSeSim);
                comando.Parameters.AddWithValue("@ordemProxSeNao", ordemProxSeNao);
                comando.Parameters.AddWithValue("@respostaPor", respostaPor);
                comando.Parameters.AddWithValue("@respostaEsp", respostaEsp);
                comando.Parameters.AddWithValue("@respostaIng", respostaIng);

                con.Open();
                comando.ExecuteNonQuery();
                
            }
            catch (Exception e) { bSalvou = false; }
            finally { con.Close(); }
            return bSalvou;
        }




        private SqlCommand getSqlAndChangeParameters(string sql, SqlConnection con,
            string codigoPergunta, string codigoOcorrencia, string tipo, string ordem,
            string ordemProxSeSim, string ordemProxSeNao,
            string redacaoPerguntaPor, string redacaoPerguntaEsp, string redacaoPerguntaIng,
            string respostaPor, string respostaEsp, string respostaIng, string codPais, string tipoArvore, string idioma)
        {

            if (codPais.Equals("")) codPais = "0";

            if (codPais.Equals("0")) codPais = "2"; // Brasil como default
            SqlCommand comando = new SqlCommand(sql, con);
            comando.Parameters.AddWithValue("@codigoPergunta", codigoPergunta);
            comando.Parameters.AddWithValue("@codigoOcorrencia", codigoOcorrencia);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@ordem", ordem);
            comando.Parameters.AddWithValue("@ordemProxSeSim", ordemProxSeSim);
            comando.Parameters.AddWithValue("@ordemProxSeNao", ordemProxSeNao);
            comando.Parameters.AddWithValue("@redacaoPerguntaPor", redacaoPerguntaPor);
            comando.Parameters.AddWithValue("@redacaoPerguntaEsp", redacaoPerguntaEsp);
            comando.Parameters.AddWithValue("@redacaoPerguntaIng", redacaoPerguntaIng);
            comando.Parameters.AddWithValue("@respostaPor", respostaPor);
            comando.Parameters.AddWithValue("@respostaEsp", respostaEsp);
            comando.Parameters.AddWithValue("@respostaIng", respostaIng);
            comando.Parameters.AddWithValue("@codPais", codPais); // esta setando default 2 (Brasil), pegar dinamico depois
            comando.Parameters.AddWithValue("@tipoArvore", tipoArvore);
            return comando;
        }


        public bool excluindoDados(string codigoPergunta)
        {
            bool bExcluiu = true;
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = DELETE_SQL_QUERY + codigoPergunta;

                SqlCommand comando = new SqlCommand(sql, con);

                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e)
            {
                bExcluiu = false;
            }
            finally { con.Close(); }
            return bExcluiu;
        }


        public bool excluindoDadosModelo(string codigoPergunta, string codigoModelo)
        {
            bool bExcluiu = true;
            SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = "delete from modelo_pergunta where  cod_pergunta = "+codigoPergunta+" and cod_modelo = "+codigoModelo;

                SqlCommand comando = new SqlCommand(sql, con);

                con.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                bExcluiu = false;
            }
            finally { con.Close(); }
            return bExcluiu;
        }


        public string getProximoRegistro()
        {
            string codigoPergunta = "0";
            SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = GET_NEXT_SQL_QUERY;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigoPergunta = dr[NEXT_MARKER].ToString();
                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }
            if (codigoPergunta == null) codigoPergunta = "";
            if (codigoPergunta.Equals("")) codigoPergunta = "0";

            if (codigoPergunta.Equals("0"))
            {
                codigoPergunta = "1";
            }

            return codigoPergunta;
        }


        public string getProximoRegistroComentario()
        {
            string codigoPergunta = "0"; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = GET_NEXT_SQL_QUERY_COMENTARIO;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigoPergunta = dr[NEXT_MARKER].ToString();
                }

            }
            catch (Exception e) { }
            finally { con.Close(); }
            if (codigoPergunta == null) codigoPergunta = "";
            if (codigoPergunta.Equals("")) codigoPergunta = "0";

            if (codigoPergunta.Equals("0"))
            {
                codigoPergunta = "1";
            }

            return codigoPergunta;
        }

        private string readSqlDataReaderReturnJSONObj(SqlDataReader dr)
        {
            string cod_pergunta = dr["cod_pergunta"].ToString();
            string cod_ocorrencia = dr["cod_ocorrencia"].ToString();
            string tipo = dr["tipo"].ToString();
            string ordem = dr["ordem"].ToString();
            string ordem_prox_se_sim = dr["ordem_prox_se_sim"].ToString();
            string ordem_prox_se_nao = dr["ordem_prox_se_nao"].ToString();
            string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
            string redacao_pergunta_esp = dr["redacao_pegunta_esp"].ToString();
            string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();
            string resposta_por = dr["resposta_por"].ToString();
            string resposta_esp = dr["resposta_esp"].ToString();
            string resposta_ing = dr["resposta_ing"].ToString();

            string alterar = "<img src='../includes/imagens/edit.png'  title='Altera Registro' style='cursor:pointer; vertical-align:top;' onclick=alterarRegistro('" + cod_pergunta + "')  >";
            string excluir = "<img src='../includes/imagens/remove.png'  title='Exclui Registro' style='cursor:pointer; vertical-align:top;' onclick=excluirRegistro('" + cod_pergunta + "')  >";

            return "{cod_pergunta:\"" + cod_pergunta + "\", cod_ocorrencia:\"" + cod_ocorrencia + "\", tipo:\"" + tipo + "\", ordem:\"" + ordem + "\", ordem_prox_se_sim:\"" + ordem_prox_se_sim + "\", ordem_prox_se_nao:\"" + ordem_prox_se_nao + "\", redacao_pergunta_por:\"" + redacao_pergunta_por + "\", redacao_pergunta_esp:\"" + redacao_pergunta_esp + "\", redacao_pergunta_ing:\"" + redacao_pergunta_ing + "\", resposta_por:\"" + resposta_por + "\", resposta_esp:\"" + resposta_esp + "\", resposta_ing:\"" + resposta_ing + "\", alterar:\"" + alterar + "\", excluir:\"" + excluir + "\"}";

        }

        public string carregandoPerguntas(string codigoOcorrencia, string codigoPesquisa, string codPais,
            string tipoArvore, string idioma, string nome, string codigo, string codPergunta, string limit, string offset,
            string total, string codModelo)
        {
            string dados = "";
            string sql = "";
            string virgula = ""; SqlConnection conPEr = null;
            try
            {

                int pagina = Int16.Parse(offset) - 1;
                /*if (pagina > 0)
                {
                    pagina = pagina * Int16.Parse(limit);
                }*/

                pagina = pagina + 1;

                conPEr = getConexao();

                sql = " SELECT * FROM ( " +
             " SELECT ROW_NUMBER() OVER(ORDER BY ordem) AS NUMBER, ";


                sql = sql + "   p.ordem,  p.ordem_prox_se_nao, p.ordem_prox_se_sim, p.cod_pergunta, p.redacao_pergunta_por, p.redacao_pergunta_esp, p.redacao_pergunta_ing, p.resposta_por, p.resposta_ing, p.resposta_esp " +
                     "  FROM pergunta p left join modelo_pergunta mp on mp.cod_pergunta = p.cod_pergunta  " +

                     "  where p.tipo_arvore = '" + tipoArvore + "' and p.cod_ocorrencia = " + codigoOcorrencia+ " and (mp.cod_modelo is null or mp.cod_modelo = "+codModelo+") ";

                   sql = sql + " ) AS TBL " +
          "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
          "ORDER BY ordem ";
                 

                  /*if (!codPergunta.Equals("0"))
                  {
                      sql = sql + " and cod_pergunta = " + codPergunta + " ";
                  }else{
                      sql = sql + " and cod_pergunta not in (" + codigo + ") ";
                  }*/


              /*  if (!codPais.Equals("2"))
                {
                    sql = sql + " and cod_pais = " + codPais;
                }*/
                //sql = sql + " order by ordem ";

               // sql = sql + " order by ordem OFFSET " + pagina + " ROWS FETCH NEXT " + limit + " ROWS ONLY ";
                SqlCommand comandoPer = new SqlCommand(sql, conPEr);
                conPEr.Open();
                SqlDataReader dr = comandoPer.ExecuteReader();
                while (dr.Read())
                {
                    string cod_pergunta = dr["cod_pergunta"].ToString();
                    string ordem = dr["ordem"].ToString();
                    string ordem_prox_se_sim = dr["ordem_prox_se_sim"].ToString();
                    string ordem_prox_se_nao = dr["ordem_prox_se_nao"].ToString();
                    string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
                    string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();
                    string redacao_pergunta_esp = dr["redacao_pergunta_esp"].ToString();

                    if (ordem_prox_se_sim == null) ordem_prox_se_sim = "0";
                    if (ordem_prox_se_nao == null) ordem_prox_se_nao = "0";

                   

                    string alterar = "<img src='../includes/imagens/edit.png'   style='cursor:pointer; vertical-align:top;' onclick=alterarRegistro('" + cod_pergunta + "')  >";
                    string excluir = "<img src='../includes/imagens/remove.png' style='cursor:pointer; vertical-align:top;' onclick=excluirRegistro('" + cod_pergunta + "')  >";
                    string visualizar = "<img src='../includes/imagens/lupa.png'   style='cursor:pointer; vertical-align:top;' onclick=visualizarRegistro('" + cod_pergunta + "')  >";

                   // visualizar = "<img src='../includes/imagens/lupa.png'  style='cursor:pointer; vertical-align:top;' onclick=visualizarRegistro('" + cod_pergunta + "')  >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src='../includes/imagens/blank.png'  style='vertical-align:top;'  >&nbsp;&nbsp;&nbsp;&nbsp;";
               

                    string util = "<img src='../includes/imagens/util.png'   style='cursor:pointer; vertical-align:top;' onclick=validaPergunta('" + codigoPesquisa + ",0," + cod_pergunta + "')  >";
                    string naoutil = "<img src='../includes/imagens/naoutil.png'   style='cursor:pointer; vertical-align:top;' onclick=validaPergunta('" + codigoPesquisa + ",1," + cod_pergunta + "')  >";
                    string comentario = "<img src='../includes/imagens/avaliar.png'  style='cursor:pointer; vertical-align:top;' onclick=comentarioPergunta('" + codigoPesquisa + "," + cod_pergunta + "')  >";


                    string cod = this.verificaExisteComentarioUsuario(nome, cod_pergunta);

                    if (!cod.Equals("0"))
                    {
                        comentario = "<img src='../includes/imagens/util.png'  style='cursor:pointer; vertical-align:top;' onclick=comentarioPerguntaVisualiza('" + cod + "')  >";
                    }


                    if (!ordem_prox_se_nao.Equals("0") && !ordem_prox_se_sim.Equals("0"))
                    {
                        //comentario = "";
                       // util = "";
                       // naoutil = "";

                        visualizar = "<img src='../includes/imagens/sim.png'  style='cursor:pointer; vertical-align:top;' onclick=carregaPerguntaCondicional('" + ordem_prox_se_sim + "')  >&nbsp;Sim&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src='../includes/imagens/nao.png'  style='cursor:pointer; vertical-align:top;' onclick=carregaPerguntaCondicional('" + ordem_prox_se_nao + "')  >&nbsp;Não";
                    }


                    redacao_pergunta_por = redacao_pergunta_por.Replace("\"", "&#34;");
                   redacao_pergunta_esp = redacao_pergunta_esp.Replace("\"", "&#34;");
                   redacao_pergunta_ing = redacao_pergunta_ing.Replace("\"", "&#34;");

                    string conteudo = "{cod_pergunta:\"" + cod_pergunta + "\", ordem:\"" + ordem + "\", comentario:\"" + comentario + "\", util:\"" + util + "\", naoutil:\"" + naoutil + "\", redacao_pergunta_por:\"" + redacao_pergunta_por + "\", redacao_pergunta_esp:\"" + redacao_pergunta_esp + "\",  redacao_pergunta_ing:\"" + redacao_pergunta_ing + "\",  resposta_por:\"" + visualizar + "\",   resposta_ing:\"" + visualizar + "\",  resposta_esp:\"" + visualizar + "\", alterar:\"" + alterar + "\", excluir:\"" + excluir + "\"}";

                    dados = dados + virgula + conteudo;
                    virgula = ",";

                }
              

                if (dados.Equals(""))
                {
                    string nomepor = "<font color=red>Nenhum registro encontrado</font>";
                    string nomeing = "<font color=red>No records found</font>";
                    string nomeesp = "<font color=red>No se encontraron registros</font>";


                    if (idioma.Equals("pt-BR"))
                    {
                        nomeesp = "";
                        nomeing = "";
                    }
                    else if (idioma.Equals("en-US"))
                    {
                        nomeesp = "";
                        nomepor = "";
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        nomepor = "";
                        nomeing = "";
                    }

                    dados = "{redacao_pergunta_por:\"" + nomepor + "\", resposta_por:\"\",  resposta_ing:\"\",  resposta_esp:\"\", redacao_pergunta_ing:\"" + nomeing + "\", redacao_pergunta_esp:\"" + nomeesp + "\", alterar:\"\", excluir:\"\"}";

                }

              
            }
            catch (Exception e) { dados = e.ToString(); }
            finally {  }

            //if (!codPergunta.Equals("0"))
           // {
                //dados = "[" + sql + "]";
            //}
            //else
            //{
               // dados = "[" + dados + "]";
            //}

            dados = total + ",[" + dados + "]";

            return dados;
        }


        public string carregaTotal(string codigoOcorrencia, string codigoPesquisa, string codPais,
           string tipoArvore, string idioma, string nome, string codigo, string codPergunta, string codModelo)
        {
            string dados = "";
            string sql = "";
            string qtde = "1";
            string virgula = ""; SqlConnection con = null;
            try
            {
                con = getConexao();
                //sql = "select count(cod_pergunta) as qtde from pergunta where  tipo_arvore = '" + tipoArvore + "' and cod_ocorrencia = " + codigoOcorrencia;


                 sql = "select count (distinct p.cod_pergunta) as qtde "+
               " from pergunta p "+
               " left join modelo_pergunta mp on mp.cod_pergunta = p.cod_pergunta "+
               "  where  p.tipo_arvore = '" + tipoArvore + "' and p.cod_ocorrencia = " + codigoOcorrencia + " " +
               "  and (mp.cod_modelo is null or mp.cod_modelo = " + codModelo + ") ";



                /*if (!codPergunta.Equals("0"))
                {
                    sql = sql + " and cod_pergunta = " + codPergunta + " ";
                }else{
                    sql = sql + " and cod_pergunta not in (" + codigo + ") ";
                }*/


                /*  if (!codPais.Equals("2"))
                  {
                      sql = sql + " and cod_pais = " + codPais;
                  }*/
                //sql = sql + " order by ordem ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    qtde = dr["qtde"].ToString();
                   

                }


               


            }
            catch (Exception e) { }
            finally { con.Close(); }

            //if (!codPergunta.Equals("0"))
            // {
            //dados = "[" + sql + "]";
            //}
            //else
            //{
           // dados = "[" + dados + "]";
            //}



            return qtde;
        }

        public string carregaResposta(string codigo, string idioma, string tipoResposta)
        {
            string conteudo = ""; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "";

                if (tipoResposta.Equals("C"))
                {
                    if (idioma.Equals("pt-BR"))
                    {
                        sql = "select redacao_pergunta_por as resposta_por, '0' as tipo from pergunta where cod_pergunta = " + codigo;
                    }
                    else if (idioma.Equals("en-US"))
                    {
                        sql = "select redacao_pergunta_ing as resposta_por, '0' as tipo from pergunta where cod_pergunta = " + codigo;
                    }

                    else
                    {
                        sql = "select redacao_pergunta_esp as resposta_por, '0' as tipo from pergunta where cod_pergunta = " + codigo;
                    }
                }
                else
                {
                    if (idioma.Equals("pt-BR"))
                    {
                        sql = "select a.tipo, a.resposta_por, (select b.redacao_pergunta_por from pergunta b where b.cod_pergunta = a.ordem_prox_se_sim) as redacao_pegunta_por_se_sim, (select c.redacao_pergunta_por from pergunta c where c.cod_pergunta = a.ordem_prox_se_nao) as redacao_pegunta_por_se_nao from pergunta a " +
                        "where a.cod_pergunta = " + codigo;
                    }
                    else if (idioma.Equals("en-US"))
                    {
                        sql = "select a.tipo, a.resposta_ing as resposta_por, (select b.redacao_pergunta_ing from pergunta b where b.cod_pergunta = a.ordem_prox_se_sim) as redacao_pegunta_por_se_sim, (select c.redacao_pergunta_ing from pergunta c where c.cod_pergunta = a.ordem_prox_se_nao) as redacao_pegunta_por_se_nao from pergunta a " +
                       "where a.cod_pergunta = " + codigo;
                    }

                    else
                    {
                        sql = "select a.tipo, a.resposta_esp as resposta_por, (select b.redacao_pergunta_esp from pergunta b where b.cod_pergunta = a.ordem_prox_se_sim) as redacao_pegunta_por_se_sim, (select c.redacao_pergunta_esp from pergunta c where c.cod_pergunta = a.ordem_prox_se_nao) as redacao_pegunta_por_se_nao from pergunta a " +
                       "where a.cod_pergunta = " + codigo;
                    }
                }
                        
              

                SqlCommand comando = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                string ordemProxSeSim = "";
                string ordemProxSeNao = "";
                string tipo = "";
                string dados = "";

                if (dr.Read())
                {
                    tipo = dr["tipo"].ToString();

                    if (tipo == "1")
                    {
                        ordemProxSeSim = dr["redacao_pegunta_por_se_sim"].ToString();
                        ordemProxSeNao = dr["redacao_pegunta_por_se_nao"].ToString();

                        if (idioma.Equals("pt-BR"))
                        {
                            dados = "Condicional afirmativa aponta para a pergunta: " + ordemProxSeSim + "<br><br>" + "Condicional negativa aponta para a pergunta: " + ordemProxSeNao;

                        }
                        else if (idioma.Equals("es-ES"))
                        {
                            dados = "Condicionales puntos declaración a la pregunta: " + ordemProxSeSim + "<br><br>" + "Condicionales puntos negativos a la pregunta: " + ordemProxSeNao;

                        }

                        else
                        {
                            dados = "Conditional statement points to the question: " + ordemProxSeSim + "<br><br>" + "Conditional negative points to the question: " + ordemProxSeNao;

                        }

                     
                        conteudo = conteudo + dados;
                    }
                    else
                    {
                        dados = dr["resposta_por"].ToString();
                        conteudo = conteudo + dados;
                    }


                }

               
            }
            catch (Exception e) { conteudo = e.StackTrace; }
            finally { con.Close(); }
            return conteudo;
        }


        public string carregaComboOrdem(string codigoOcorrencia, string codPais, string tipoArvore, string idioma)
        {
            string dados = "<option value=\"\"> </option>"; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "select cod_pergunta, redacao_pergunta_por, redacao_pergunta_ing, redacao_pergunta_esp from pergunta where cod_pais = " + codPais + " and tipo_arvore = '" + tipoArvore + "' and cod_ocorrencia = " + codigoOcorrencia +
                    " order by redacao_pergunta_por ";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {

                    string cod_pergunta = dr["cod_pergunta"].ToString();
                    string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
                    string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();
                    string redacao_pergunta_esp = dr["redacao_pergunta_esp"].ToString();

                    if (idioma.Equals("en-US"))
                    {
                        redacao_pergunta_por = redacao_pergunta_ing;
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        redacao_pergunta_por = redacao_pergunta_esp;
                    }

                    string conteudo = "<option value=\"" + cod_pergunta + "\">" + redacao_pergunta_por + "</option>";

                    dados = dados + conteudo;


                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        /*public string carregandoPerguntas(string codigoOcorrencia)
        {
            string dados = "";
            string virgula = "";
            try
            {
                SqlConnection con = getConexao();
                string sql = SELECT_MANY_SQL_QUERY + codigoOcorrencia;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();

                SqlDataReader dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    string conteudo = readSqlDataReaderReturnJSONObj(dr);
                    dados = dados + virgula + conteudo;
                    virgula = ",";
                }
                con.Close();
            }
            catch (Exception e) { }

            dados = "[" + dados + "]";

            return dados;
        }
        */

        public string carregaPergunta(string codigoPergunta)
        {
            string dados = ""; SqlConnection con = null;
            string virgula = "";
            try
            {
                  con = getConexao();
                string sql = "select tipo, ordem, ordem_prox_se_sim, ordem_prox_se_nao, redacao_pergunta_por, redacao_pergunta_esp, redacao_pergunta_ing, resposta_por, resposta_esp, resposta_ing from pergunta where cod_pergunta = " + codigoPergunta;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                string tipo = "";
                string ordem = "";
                string ordemProxSeSim = "";
                string ordemProxSeNao = "";
                string redacaoPerguntaPor = "";
                string redacaoPerguntaEsp = "";
                string redacaoPerguntaIng = "";
                string respostaPor = "";
                string respostaEsp = "";
                string respostaIng = "";

                if (dr.Read())
                {

                    tipo = dr["tipo"].ToString();
                    ordem = dr["ordem"].ToString();
                    ordemProxSeSim = dr["ordem_prox_se_sim"].ToString();
                    ordemProxSeNao = dr["ordem_prox_se_nao"].ToString();
                    redacaoPerguntaPor = dr["redacao_pergunta_por"].ToString();
                    redacaoPerguntaEsp = dr["redacao_pergunta_ing"].ToString();
                    redacaoPerguntaIng = dr["redacao_pergunta_esp"].ToString();
                    respostaPor = dr["resposta_por"].ToString();
                    respostaIng = dr["resposta_ing"].ToString();
                    respostaEsp = dr["resposta_esp"].ToString();
                    virgula = ",";

                    if (redacaoPerguntaPor.Equals("")) redacaoPerguntaPor = "&nbsp;";
                    if (redacaoPerguntaEsp.Equals("")) redacaoPerguntaEsp = "&nbsp;";
                    if (redacaoPerguntaIng.Equals("")) redacaoPerguntaIng = "&nbsp;";

                    if (respostaPor.Equals("")) respostaPor = "&nbsp;";
                    if (respostaIng.Equals("")) respostaIng = "&nbsp;";
                    if (respostaEsp.Equals("")) respostaEsp = "&nbsp;";


                }

                string conteudo = tipo + "!#!" + ordem + "!#!" + ordemProxSeSim + "!#!" + ordemProxSeNao + "!#!" + redacaoPerguntaPor + "!#!" + redacaoPerguntaEsp + "!#!" + redacaoPerguntaIng + "!#!" + respostaPor + "!#!" + respostaIng + "!#!" + respostaEsp;

                dados = conteudo;


              
            }
            catch (Exception e) { }
            finally { con.Close(); }
            return dados;
        }

        public string carregaNomeOcorrencia(string codigo, string idioma)
        {
            string dados = ""; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "select descricao_ocorrencia_por from ocorrencia where cod_ocorrencia = " + codigo;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

                    dados = descricao_ocorrencia_por;

                }

              
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string carregaNomeProduto(string codigo, string idioma)
        {
            string dados = ""; SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = "select nome_produto_por from produto where cod_produto = " + codigo;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string descricao_ocorrencia_por = dr["nome_produto_por"].ToString();

                    dados = descricao_ocorrencia_por;

                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string carregaNomeLinha(string codigo, string idioma)
        {
            string dados = ""; SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = "select nome_linha_por from linha where cod_linha = " + codigo;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string descricao_ocorrencia_por = dr["nome_linha_por"].ToString();

                    dados = descricao_ocorrencia_por;

                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string carregaNomeModelo(string codigo, string idioma)
        {
            string dados = ""; SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = "select nome_modelo_por from modelo where cod_modelo = " + codigo;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string descricao_ocorrencia_por = dr["nome_modelo_por"].ToString();

                    dados = descricao_ocorrencia_por;

                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }


        public string carregaComentario(string codigoPesquisa, string codigoPergunta, string codComentario)
        {
            string comentario = ""; SqlConnection con = null;
            string foi_util = "";
            try
            {
                  con = getConexao();
                  string sql = "";

                if (!codComentario.Equals("0"))
                {

                    sql = "select redacao_comentario, foi_util from comentario where cod_comentario = " + codComentario;
                }
                else
                {
                    sql = "select redacao_comentario from comentario, foi_util where cod_pesquisa = " + codigoPesquisa + " and cod_pergunta = " + codigoPergunta;
                }
                
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();


                if (dr.Read())
                {

                    comentario = dr["redacao_comentario"].ToString();
                    foi_util = dr["foi_util"].ToString();
                  

                }

            


               
            }
            catch (Exception e) { }
            finally { con.Close(); }
            return comentario+";"+foi_util;
        }


    }
}
