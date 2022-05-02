using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;

namespace EluxcityWeb.DAO
{
    public class ComentarioDAO : Conexao
    {
        public string carregandoDados(string codigoUsuario, string dataInicial, string dataFinal, string limit, string offset, string total)
        {
            string dados = "";
            string virgula = "";
            string sql = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();

                int pagina = Int16.Parse(offset) - 1;
                /*if (pagina > 0)
                {
                    pagina = pagina * Int16.Parse(limit);
                }*/

                pagina = pagina + 1;

                if (!dataFinal.Equals("") && !dataInicial.Equals(""))
                {
                    dataInicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    dataFinal = dataFinal.Substring(6, 4) + "-" + dataFinal.Substring(3, 2) + "-" + dataFinal.Substring(0, 2);

                    sql = " SELECT * FROM ( " +
                           " SELECT ROW_NUMBER() OVER(ORDER BY comentario.data_e_hora) AS NUMBER, ";

                    sql = sql + "  comentario.redacao_comentario,pais.nome_pais, pesquisa.nome_usuario, comentario.data_e_hora, comentario.foi_util, comentario.cod_comentario , " +
                                 "linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing,   " +
                                                 "  produto.nome_produto_por, produto.nome_produto_esp, produto.nome_produto_ing,  " +
                                                 " modelo.nome_modelo_por, modelo.nome_modelo_esp, modelo.nome_modelo_ing,   " +
                                                " ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_esp, ocorrencia.descricao_ocorrencia_ing,   " +
                               " pergunta.redacao_pergunta_por,  pergunta.redacao_pergunta_esp,  pergunta.redacao_pergunta_ing " +
                               "from comentario   " +
                               "inner join pesquisa  on pesquisa.cod_pesquisa = comentario.cod_pesquisa  " +
                                " left join linha  on linha.cod_linha = pesquisa.cod_linha " +
                                 "   left join produto  on produto.cod_produto = pesquisa.cod_produto  " +
                                  "  left join modelo  on modelo.cod_modelo = pesquisa.cod_modelo  " +
                                  " left join ocorrencia  on ocorrencia.cod_ocorrencia = pesquisa.cod_ocorrencia  left join pais  on pais.cod_pais = ocorrencia.cod_pais " +
                                   " left join pergunta  on pergunta.cod_pergunta = comentario.cod_pergunta  " +
                   " where pesquisa.data_e_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'  ";

                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and pesquisa.nome_usuario = '" + codigoUsuario + "'  ";
                    }

                    sql = sql + " ) AS TBL " +
           "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
           "ORDER BY data_e_hora ";


                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {


                        sql = " SELECT * FROM ( " +
                           " SELECT ROW_NUMBER() OVER(ORDER BY comentario.data_e_hora) AS NUMBER, ";

                        sql = sql + "  comentario.redacao_comentario,pais.nome_pais, pesquisa.nome_usuario, comentario.data_e_hora, comentario.foi_util, comentario.cod_comentario , " +
                                     "linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing,   " +
                                                     "  produto.nome_produto_por, produto.nome_produto_esp, produto.nome_produto_ing,  " +
                                                     " modelo.nome_modelo_por, modelo.nome_modelo_esp, modelo.nome_modelo_ing,   " +
                                                    " ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_esp, ocorrencia.descricao_ocorrencia_ing,   " +
                                   " pergunta.redacao_pergunta_por,  pergunta.redacao_pergunta_esp,  pergunta.redacao_pergunta_ing " +
                                   "from comentario   " +
                                   "inner join pesquisa  on pesquisa.cod_pesquisa = comentario.cod_pesquisa  " +
                                    " left join linha  on linha.cod_linha = pesquisa.cod_linha " +
                                     "   left join produto  on produto.cod_produto = pesquisa.cod_produto  " +
                                      "  left join modelo  on modelo.cod_modelo = pesquisa.cod_modelo  " +
                                      " left join ocorrencia  on ocorrencia.cod_ocorrencia = pesquisa.cod_ocorrencia left join pais  on pais.cod_pais = ocorrencia.cod_pais " +
                                       " left join pergunta  on pergunta.cod_pergunta = comentario.cod_pergunta  ";

                        sql = sql + " ) AS TBL " +
       "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
       "ORDER BY data_e_hora ";



                    }
                    else
                    {


                        sql = " SELECT * FROM ( " +
                      " SELECT ROW_NUMBER() OVER(ORDER BY comentario.data_e_hora) AS NUMBER, ";

                        sql = sql + "  comentario.redacao_comentario,pais.nome_pais, pesquisa.nome_usuario, comentario.data_e_hora, comentario.foi_util, comentario.cod_comentario , " +
                                     "linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing,   " +
                                                     "  produto.nome_produto_por, produto.nome_produto_esp, produto.nome_produto_ing,  " +
                                                     " modelo.nome_modelo_por, modelo.nome_modelo_esp, modelo.nome_modelo_ing,   " +
                                                    " ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_esp, ocorrencia.descricao_ocorrencia_ing,   " +
                                   " pergunta.redacao_pergunta_por,  pergunta.redacao_pergunta_esp,  pergunta.redacao_pergunta_ing " +
                                   "from comentario   " +
                                   "inner join pesquisa  on pesquisa.cod_pesquisa = comentario.cod_pesquisa  " +
                                    " left join linha  on linha.cod_linha = pesquisa.cod_linha " +
                                     "   left join produto  on produto.cod_produto = pesquisa.cod_produto  " +
                                      "  left join modelo  on modelo.cod_modelo = pesquisa.cod_modelo  " +
                                      " left join ocorrencia  on ocorrencia.cod_ocorrencia = pesquisa.cod_ocorrencia left join pais  on pais.cod_pais = ocorrencia.cod_pais  " +
                                       " left join pergunta  on pergunta.cod_pergunta = comentario.cod_pergunta where pesquisa.nome_usuario = '" + codigoUsuario + "'  ";

                        sql = sql + " ) AS TBL " +
       "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
       "ORDER BY data_e_hora ";





                    }
                   
   
                }

             //   sql = sql + " order by c.data_e_hora desc OFFSET " + pagina + " ROWS FETCH NEXT " + limit + " ROWS ONLY ";
                
                
              
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string nome_usuario = dr["nome_usuario"].ToString();
                    string pais = dr["nome_pais"].ToString();
                    string redacao_comentario = dr["redacao_comentario"].ToString();
                    string data_e_hora = dr["data_e_hora"].ToString();
                    string foi_util = dr["foi_util"].ToString();
                    string cod_comentario = dr["cod_comentario"].ToString();


                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

                    string redacao_pergunta_esp = dr["redacao_pergunta_esp"].ToString();
                    string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
                    string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();

                    if (redacao_pergunta_esp == null) redacao_pergunta_esp = "";
                    if (redacao_pergunta_ing == null) redacao_pergunta_ing = "";
                    if (redacao_pergunta_por == null) redacao_pergunta_por = "";

                    string nome_linha_esp = dr["nome_linha_esp"].ToString();
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();
                    string nome_modelo_esp = dr["nome_modelo_esp"].ToString();
                    string descricao_ocorrencia_esp = dr["descricao_ocorrencia_esp"].ToString();

                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                    string nome_modelo_ing = dr["nome_modelo_ing"].ToString();
                    string descricao_ocorrencia_ing = dr["descricao_ocorrencia_ing"].ToString();

                    if (descricao_ocorrencia_por == null) descricao_ocorrencia_por = "";
                    if (nome_linha_por == null) nome_linha_por = "";
                    if (nome_produto_por == null) nome_produto_por = "";
                    if (nome_modelo_por == null) nome_modelo_por = "";

                    if (descricao_ocorrencia_esp == null) descricao_ocorrencia_esp = "";
                    if (nome_linha_esp == null) nome_linha_esp = "";
                    if (nome_produto_esp == null) nome_produto_esp = "";
                    if (nome_modelo_esp == null) nome_modelo_esp = "";

                    if (descricao_ocorrencia_ing == null) descricao_ocorrencia_ing = "";
                    if (nome_linha_ing == null) nome_linha_ing = "";
                    if (nome_produto_ing == null) nome_produto_ing = "";
                    if (nome_modelo_ing == null) nome_modelo_ing = "";

                    string visualizar = "<img src='../includes/imagens/lupa.png'  title='Ver Comentário' style='cursor:pointer; vertical-align:top;' onclick=visualizarComentario('" + cod_comentario + "')  >";

                    if (redacao_comentario == null)
                    {
                        redacao_comentario = "";
                    }

                    redacao_comentario = redacao_comentario.Replace("'", "");
                    redacao_comentario = redacao_comentario.Replace("\"", "");
                    redacao_comentario = redacao_comentario.Replace("\n", "");
                    redacao_comentario = redacao_comentario.Replace("\r", "");

                    visualizar = redacao_comentario;

                    string conteudo = "{pais:\"" + pais + "\", redacao_pergunta_esp:\"" + redacao_pergunta_esp + "\", redacao_pergunta_por:\"" + redacao_pergunta_por + "\", redacao_pergunta_ing:\"" + redacao_pergunta_ing + "\",    descricao_ocorrencia_ing:\"" + descricao_ocorrencia_ing + "\", nome_linha_ing:\"" + nome_linha_ing + "\", nome_produto_ing:\"" + nome_produto_ing + "\", nome_modelo_ing:\"" + nome_modelo_ing + "\",  nome_modelo_esp:\"" + nome_modelo_esp + "\", nome_produto_esp:\"" + nome_produto_esp + "\", nome_linha_esp:\"" + nome_linha_esp + "\", descricao_ocorrencia_esp:\"" + descricao_ocorrencia_esp + "\", descricao_ocorrencia_por:\"" + descricao_ocorrencia_por + "\", nome_linha_por:\"" + nome_linha_por + "\", nome_produto_por:\"" + nome_produto_por + "\", nome_modelo_por:\"" + nome_modelo_por + "\", nome_usuario:\"" + nome_usuario + "\", data_e_hora:\"" + data_e_hora + "\", foi_util:\"" + foi_util + "\", redacao_comentario:\"" + visualizar + "\"}";

                    dados = dados + virgula + conteudo;
                    virgula = ",";
                }

               
            }
            catch (Exception e) { dados = e.ToString(); }
            finally { con.Close(); }

            dados = total + ",[" + dados + "]";

            return dados;
        }


        public string carregaTotal(string codigoUsuario, string dataInicial, string dataFinal)
        {
            string dados = "";
            string virgula = "";
            string sql = "";
            string qtde = "1";
            SqlConnection con = null;
            try
            {
                con = getConexao();


                if (!dataFinal.Equals("") && !dataInicial.Equals(""))
                {
                    dataInicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    dataFinal = dataFinal.Substring(6, 4) + "-" + dataFinal.Substring(3, 2) + "-" + dataFinal.Substring(0, 2);

                    /*   sql = "select p.nome_usuario, c.data_e_hora, c.foi_util, c.cod_comentario from comentario c " +
                     "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa " +
                     "where p.nome_usuario = '" + codigoUsuario + "' and c.data_e_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'";
     */

                    sql = " select count(c.cod_comentario) as qtde " +
                               "from comentario c  " +
                               "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa  " +
                                " left join linha b on b.cod_linha = p.cod_linha " +
                                 "   left join produto f on f.cod_produto = p.cod_produto  " +
                                  "  left join modelo d on d.cod_modelo = p.cod_modelo  " +
                                  " left join ocorrencia e on e.cod_ocorrencia = p.cod_ocorrencia  " +
                                   " left join pergunta h on h.cod_pergunta = c.cod_pergunta  where c.data_e_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'  ";


                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and a.nome_usuario = '" + codigoUsuario + "'  ";
                    }

                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {


                        sql = " select count(c.cod_comentario) as qtde " +
                                "from comentario c  " +
                                "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa  " +
                                 " left join linha b on b.cod_linha = p.cod_linha " +
                                  "   left join produto f on f.cod_produto = p.cod_produto  " +
                                   "  left join modelo d on d.cod_modelo = p.cod_modelo  " +
                                   " left join ocorrencia e on e.cod_ocorrencia = p.cod_ocorrencia  " +
                                    " left join pergunta h on h.cod_pergunta = c.cod_pergunta  ";





                    }
                    else
                    {
                        /*    sql = "select p.nome_usuario, c.data_e_hora, c.foi_util, c.cod_comentario from comentario c " +
                        "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa " +
                        "where p.nome_usuario = '" + codigoUsuario + "' ";*/


                        sql = " select count(c.cod_comentario) as qtde " +
                               "from comentario c  " +
                               "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa  " +
                                " left join linha b on b.cod_linha = p.cod_linha " +
                                 "   left join produto f on f.cod_produto = p.cod_produto  " +
                                  "  left join modelo d on d.cod_modelo = p.cod_modelo  " +
                                  " left join ocorrencia e on e.cod_ocorrencia = p.cod_ocorrencia  " +
                                   " left join pergunta h on h.cod_pergunta = c.cod_pergunta  where p.nome_usuario = '" + codigoUsuario + "' ";



                    }


                }



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

           // dados = "[" + dados + "]";

            return qtde;
        }


        public string carregandoDadosExcel(string codigoUsuario, string dataInicial, string dataFinal)
        {
            string dados = "";
            string virgula = "";
            string sql = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();


                if (!dataFinal.Equals("") && !dataInicial.Equals(""))
                {
                    dataInicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    dataFinal = dataFinal.Substring(6, 4) + "-" + dataFinal.Substring(3, 2) + "-" + dataFinal.Substring(0, 2);

                    /*   sql = "select p.nome_usuario, c.data_e_hora, c.foi_util, c.cod_comentario from comentario c " +
                     "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa " +
                     "where p.nome_usuario = '" + codigoUsuario + "' and c.data_e_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'";
     */

                    sql = " select c.redacao_comentario, p.nome_usuario, pais.nome_pais, c.data_e_hora, c.foi_util, c.cod_comentario , " +
                                 "b.nome_linha_por, b.nome_linha_esp, b.nome_linha_ing,   " +
                                                 "  f.nome_produto_por, f.nome_produto_esp, f.nome_produto_ing,  " +
                                                 " d.nome_modelo_por, d.nome_modelo_esp, d.nome_modelo_ing,   " +
                                                " e.descricao_ocorrencia_por, e.descricao_ocorrencia_esp, e.descricao_ocorrencia_ing,   " +
                               " h.redacao_pergunta_por,  h.redacao_pergunta_esp,  h.redacao_pergunta_ing " +
                               "from comentario c  " +
                               "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa  " +
                                " left join linha b on b.cod_linha = p.cod_linha " +
                                 "   left join produto f on f.cod_produto = p.cod_produto  " +
                                  "  left join modelo d on d.cod_modelo = p.cod_modelo  " +
                                  " left join ocorrencia e on e.cod_ocorrencia = p.cod_ocorrencia   left join pais  on pais.cod_pais = e.cod_pais " +
                                   " left join pergunta h on h.cod_pergunta = c.cod_pergunta where c.data_e_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'  ";

                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and a.nome_usuario = '" + codigoUsuario + "'  ";
                    }

                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {


                        sql = " select c.redacao_comentario, pais.nome_pais, p.nome_usuario, c.data_e_hora, c.foi_util, c.cod_comentario , " +
                                   "b.nome_linha_por, b.nome_linha_esp, b.nome_linha_ing,   " +
                                                   "  f.nome_produto_por, f.nome_produto_esp, f.nome_produto_ing,  " +
                                                   " d.nome_modelo_por, d.nome_modelo_esp, d.nome_modelo_ing,   " +
                                                  " e.descricao_ocorrencia_por, e.descricao_ocorrencia_esp, e.descricao_ocorrencia_ing,   " +
                                 " h.redacao_pergunta_por,  h.redacao_pergunta_esp,  h.redacao_pergunta_ing " +
                                 "from comentario c  " +
                                 "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa  " +
                                  " left join linha b on b.cod_linha = p.cod_linha " +
                                   "   left join produto f on f.cod_produto = p.cod_produto  " +
                                    "  left join modelo d on d.cod_modelo = p.cod_modelo  " +
                                    " left join ocorrencia e on e.cod_ocorrencia = p.cod_ocorrencia  left join pais  on pais.cod_pais = e.cod_pais " +
                                     " left join pergunta h on h.cod_pergunta = c.cod_pergunta  ";





                    }
                    else
                    {
                        /*    sql = "select p.nome_usuario, c.data_e_hora, c.foi_util, c.cod_comentario from comentario c " +
                        "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa " +
                        "where p.nome_usuario = '" + codigoUsuario + "' ";*/


                        sql = " select c.redacao_comentario, pais.nome_pais, p.nome_usuario, c.data_e_hora, c.foi_util, c.cod_comentario , " +
                                 "b.nome_linha_por, b.nome_linha_esp, b.nome_linha_ing,   " +
                                                 "  f.nome_produto_por, f.nome_produto_esp, f.nome_produto_ing,  " +
                                                 " d.nome_modelo_por, d.nome_modelo_esp, d.nome_modelo_ing,   " +
                                                " e.descricao_ocorrencia_por, e.descricao_ocorrencia_esp, e.descricao_ocorrencia_ing,   " +
                               " h.redacao_pergunta_por,  h.redacao_pergunta_esp,  h.redacao_pergunta_ing " +
                               "from comentario c  " +
                               "inner join pesquisa p on p.cod_pesquisa = c.cod_pesquisa  " +
                                " left join linha b on b.cod_linha = p.cod_linha " +
                                 "   left join produto f on f.cod_produto = p.cod_produto  " +
                                  "  left join modelo d on d.cod_modelo = p.cod_modelo  " +
                                  " left join ocorrencia e on e.cod_ocorrencia = p.cod_ocorrencia  left join pais  on pais.cod_pais = e.cod_pais " +
                                   " left join pergunta h on h.cod_pergunta = c.cod_pergunta  where p.nome_usuario = '" + codigoUsuario + "' ";



                    }


                }



                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string nome_usuario = dr["nome_usuario"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    string data_e_hora = dr["data_e_hora"].ToString();
                    string foi_util = dr["foi_util"].ToString();
                    string cod_comentario = dr["cod_comentario"].ToString();


                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

                    string redacao_pergunta_esp = dr["redacao_pergunta_esp"].ToString();
                    string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
                    string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();

                    if (redacao_pergunta_esp == null) redacao_pergunta_esp = "";
                    if (redacao_pergunta_ing == null) redacao_pergunta_ing = "";
                    if (redacao_pergunta_por == null) redacao_pergunta_por = "";

                    string nome_linha_esp = dr["nome_linha_esp"].ToString();
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();
                    string nome_modelo_esp = dr["nome_modelo_esp"].ToString();
                    string descricao_ocorrencia_esp = dr["descricao_ocorrencia_esp"].ToString();

                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                    string nome_modelo_ing = dr["nome_modelo_ing"].ToString();
                    string descricao_ocorrencia_ing = dr["descricao_ocorrencia_ing"].ToString();

                    if (descricao_ocorrencia_por == null) descricao_ocorrencia_por = "";
                    if (nome_linha_por == null) nome_linha_por = "";
                    if (nome_produto_por == null) nome_produto_por = "";
                    if (nome_modelo_por == null) nome_modelo_por = "";

                    if (descricao_ocorrencia_esp == null) descricao_ocorrencia_esp = "";
                    if (nome_linha_esp == null) nome_linha_esp = "";
                    if (nome_produto_esp == null) nome_produto_esp = "";
                    if (nome_modelo_esp == null) nome_modelo_esp = "";

                    if (descricao_ocorrencia_ing == null) descricao_ocorrencia_ing = "";
                    if (nome_linha_ing == null) nome_linha_ing = "";
                    if (nome_produto_ing == null) nome_produto_ing = "";
                    if (nome_modelo_ing == null) nome_modelo_ing = "";

                    string visualizar = "<img src='../includes/imagens/lupa.png'  title='Ver Comentário' style='cursor:pointer; vertical-align:top;' onclick=visualizarComentario('" + cod_comentario + "')  >";
                    string redacao_comentario = dr["redacao_comentario"].ToString();

                    if (redacao_comentario == null)
                    {
                        redacao_comentario = "";
                    }


                    redacao_comentario = redacao_comentario.Replace("'", "");
                    redacao_comentario = redacao_comentario.Replace("\"", "");
                    redacao_comentario = redacao_comentario.Replace("\n", "");
                    redacao_comentario = redacao_comentario.Replace("\r", "");

                    visualizar = redacao_comentario;


                    string conteudo = redacao_pergunta_esp + "#" + redacao_pergunta_por + "#" + redacao_pergunta_ing + "#" + descricao_ocorrencia_ing + "#" + nome_linha_ing + "#" + nome_produto_ing + "#" + nome_modelo_ing + "#" + nome_modelo_esp + "#" + nome_produto_esp + "#" + nome_linha_esp + "#" + descricao_ocorrencia_esp + "#" + descricao_ocorrencia_por + "#" + nome_linha_por + "#" + nome_produto_por + "#" + nome_modelo_por + "#" + nome_usuario + "#" + data_e_hora + "#" + foi_util + "#" + visualizar + "#" + nome_pais;

                    dados = dados + virgula + conteudo;
                    virgula = "$";
                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

           // dados = "[" + dados + "]";

            return dados;
        }

        public string carregaComentario(string codigo)
        {
            string conteudo = "";
            SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = "select redacao_comentario from comentario where cod_comentario = " + codigo;

                SqlCommand comando = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                string redacao_comentario = "";

                if (dr.Read())
                {

                    redacao_comentario = dr["redacao_comentario"].ToString();
                    conteudo = conteudo + redacao_comentario;
                }

               
            }
            catch (Exception e) { conteudo = e.StackTrace; }
            finally { con.Close(); }

            return conteudo;
        }

    }
}
