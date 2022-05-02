using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;

namespace EluxcityWeb.DAO
{
    public class PesquisaDAO : Conexao
    {

        public string carregandoComboUsuario()
        {
            string dados = "<option value=\"0\">Todos</option>"; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "select distinct cod_usuario, nome_usuario from pesquisa  "+
                 " union select distinct usuario as cod_usuario, usuario as nome_usuario from historico_importacao" +
                    " order by 2 ";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_usuario = dr["nome_usuario"].ToString();
                    string nome_usuario = dr["nome_usuario"].ToString();

                    string conteudo = "<option value=\"" + cod_usuario + "\">" + nome_usuario + "</option>";

                    dados = dados + conteudo;

                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }


        public string carregandoComboUsuarioDados()
        {
            string dados = "<option value=\"0\">Todos</option>"; SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = "select distinct usuario from historico_importacao" +
                    " order by usuario";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string nome_usuario = dr["usuario"].ToString();

                    string conteudo = "<option value=\"" + nome_usuario + "\">" + nome_usuario + "</option>";

                    dados = dados + conteudo;

                }


            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string carregandoDados(string codigoUsuario, string dataInicial, string dataFinal, string limit, string offset, string total)
        {
            string dados = ""; SqlConnection conPEr = null;
            string virgula = "";
            string sql = "";
            try
            {

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
                          " SELECT ROW_NUMBER() OVER(ORDER BY data_e_hora) AS NUMBER, ";


                    sql = sql + "    pesquisa.nome_usuario, pais.nome_pais, pesquisa.data_e_hora, pesquisa.cod_pesquisa , " +
                     "linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing,   " +
                     "produto.nome_produto_por, produto.nome_produto_esp, produto.nome_produto_ing,  " +
                     "modelo.nome_modelo_por, modelo.nome_modelo_esp, modelo.nome_modelo_ing,  " +
                     "ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_esp, ocorrencia.descricao_ocorrencia_ing, "+
                    " pergunta.redacao_pergunta_por, pergunta.redacao_pergunta_ing, pergunta.redacao_pergunta_esp " +
                    "from pesquisa  " +
                    "  left join linha  on linha.cod_linha = pesquisa.cod_linha " +
                     "  left join produto  on produto.cod_produto = pesquisa.cod_produto  " +
                     "   left join modelo  on modelo.cod_modelo = pesquisa.cod_modelo  " +
                     "    left join ocorrencia on ocorrencia.cod_ocorrencia = pesquisa.cod_ocorrencia  " +
                      "    left join pergunta on pergunta.cod_ocorrencia = ocorrencia.cod_ocorrencia  " +
                     "  left join pais  on pais.cod_pais = ocorrencia.cod_pais " +
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
                         " SELECT ROW_NUMBER() OVER(ORDER BY data_e_hora) AS NUMBER, ";


                        sql = sql + "    pesquisa.nome_usuario, pais.nome_pais, pesquisa.data_e_hora, pesquisa.cod_pesquisa , " +
                         "linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing,   " +
                         "produto.nome_produto_por, produto.nome_produto_esp, produto.nome_produto_ing,  " +
                         "modelo.nome_modelo_por, modelo.nome_modelo_esp, modelo.nome_modelo_ing,  " +
                         "ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_esp, ocorrencia.descricao_ocorrencia_ing " +
                        ",  pergunta.redacao_pergunta_por, pergunta.redacao_pergunta_ing, pergunta.redacao_pergunta_esp from pesquisa  " +
                        "  left join linha  on linha.cod_linha = pesquisa.cod_linha " +
                         "  left join produto  on produto.cod_produto = pesquisa.cod_produto  " +
                         "   left join modelo  on modelo.cod_modelo = pesquisa.cod_modelo  " +
                         "    left join ocorrencia ocorrencia on ocorrencia.cod_ocorrencia = pesquisa.cod_ocorrencia left join pais  on pais.cod_pais = ocorrencia.cod_pais left join pergunta on pergunta.cod_ocorrencia = ocorrencia.cod_ocorrencia ";
                     
                        

                        sql = sql + " ) AS TBL " +
               "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
               "ORDER BY data_e_hora ";


                    }
                    else
                    {
                        sql = " SELECT * FROM ( " +
                         " SELECT ROW_NUMBER() OVER(ORDER BY data_e_hora) AS NUMBER, ";


                        sql = sql + "    pesquisa.nome_usuario,pais.nome_pais, pesquisa.data_e_hora, pesquisa.cod_pesquisa , " +
                         "linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing,   " +
                         "produto.nome_produto_por, produto.nome_produto_esp, produto.nome_produto_ing,  " +
                         "modelo.nome_modelo_por, modelo.nome_modelo_esp, modelo.nome_modelo_ing,  " +
                         "ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_esp, ocorrencia.descricao_ocorrencia_ing " +
                        " , pergunta.redacao_pergunta_por, pergunta.redacao_pergunta_ing, pergunta.redacao_pergunta_esp from pesquisa  " +
                        "  left join linha  on linha.cod_linha = pesquisa.cod_linha " +
                         "  left join produto  on produto.cod_produto = pesquisa.cod_produto  " +
                         "   left join modelo  on modelo.cod_modelo = pesquisa.cod_modelo  " +
                         "    left join ocorrencia ocorrencia on ocorrencia.cod_ocorrencia = pesquisa.cod_ocorrencia left join pais  on pais.cod_pais = ocorrencia.cod_pais left join pergunta on pergunta.cod_ocorrencia = ocorrencia.cod_ocorrencia " +
                        "  ";

                       // if (!codigoUsuario.Equals("0"))
                     //   {
                            sql = sql + " where pesquisa.nome_usuario = '" + codigoUsuario + "'  ";
                       // }

                        sql = sql + " ) AS TBL " +
               "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
               "ORDER BY data_e_hora ";


                    }
              
                }

               // sql = sql + " order by a.data_e_hora desc OFFSET " + pagina + " ROWS FETCH NEXT " + limit + " ROWS ONLY ";

                conPEr = getConexao();

                SqlCommand comandoPer = new SqlCommand(sql, conPEr);
                conPEr.Open();
                SqlDataReader dr = comandoPer.ExecuteReader();
                while (dr.Read())
                {
                    string nome_usuario = dr["nome_usuario"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    string data_e_hora = dr["data_e_hora"].ToString();
                    string cod_pesquisa = dr["cod_pesquisa"].ToString();

                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

                    string nome_linha_esp = dr["nome_linha_esp"].ToString();
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();
                    string nome_modelo_esp = dr["nome_modelo_esp"].ToString();
                    string descricao_ocorrencia_esp = dr["descricao_ocorrencia_esp"].ToString();

                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                    string nome_modelo_ing = dr["nome_modelo_ing"].ToString();
                    string descricao_ocorrencia_ing = dr["descricao_ocorrencia_ing"].ToString();

                    string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
                    string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();
                    string redacao_pergunta_esp = dr["redacao_pergunta_esp"].ToString();

                    if (redacao_pergunta_por == null) redacao_pergunta_por = "";
                    if (redacao_pergunta_ing == null) redacao_pergunta_ing = "";
                    if (redacao_pergunta_esp == null) redacao_pergunta_esp = "";

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

                    string conteudo = "{pais:\"" + nome_pais + "\", redacao_pergunta_ing:`" + redacao_pergunta_ing + "` , redacao_pergunta_esp:`" + redacao_pergunta_esp + "` , redacao_pergunta_por:`" + redacao_pergunta_por + "`,  descricao_ocorrencia_ing:\"" + descricao_ocorrencia_ing + "\", nome_linha_ing:\"" + nome_linha_ing + "\", nome_produto_ing:\"" + nome_produto_ing + "\", nome_modelo_ing:\"" + nome_modelo_ing + "\",  nome_modelo_esp:\"" + nome_modelo_esp + "\", nome_produto_esp:\"" + nome_produto_esp + "\", nome_linha_esp:\"" + nome_linha_esp + "\", descricao_ocorrencia_esp:\"" + descricao_ocorrencia_esp + "\", descricao_ocorrencia_por:\"" + descricao_ocorrencia_por + "\", nome_linha_por:\"" + nome_linha_por + "\", nome_produto_por:\"" + nome_produto_por + "\", nome_modelo_por:\"" + nome_modelo_por + "\", nome_usuario:\"" + nome_usuario + "\", data_e_hora:\"" + data_e_hora + "\", cod_pesquisa:\"" + cod_pesquisa + "\"}";

                    dados = dados + virgula + conteudo;
                    virgula = ",";
                }

               
            }
            catch (Exception e) { dados = e.ToString(); }
            finally { conPEr.Close(); }
            dados = total + ",[" + dados + "]";

            return dados;
        }



        public string carregandoRelatorioDados(string codigoUsuario, string dataInicial, string dataFinal, string limit,
            string offset, string total, string idioma, string tipoArvore)
        {
            string dados = ""; SqlConnection conPEr = null;
            string virgula = "";
            string sql = "";
            try
            {

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
                          " SELECT ROW_NUMBER() OVER(ORDER BY data_hora) AS NUMBER, ";

                    sql = sql + "   linha.nome_linha_por, linha.nome_linha_ing, linha.nome_linha_esp, "+
	                       "  produto.nome_produto_por, produto.nome_produto_ing, produto.nome_produto_esp, "+
	                       "  modelo.nome_modelo_por, modelo.nome_modelo_ing, modelo.nome_modelo_esp, "+
	                       "  ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_ing, ocorrencia.descricao_ocorrencia_esp, "+
	                       "  pergunta.ordem as codigo, pergunta.tipo as tipoPergunta, pergunta.redacao_pergunta_por , pergunta.redacao_pergunta_ing , pergunta.redacao_pergunta_esp, "+
	                       "  pergunta.resposta_por, pergunta.resposta_ing, pergunta.resposta_esp, "+
	                       "  pais.nome_pais, historico_importacao.usuario, "+
	                       "   historico_importacao.data_hora "+
	                       "  from historico_importacao "+
	                       "  inner join linha on linha.cod_linha = historico_importacao.cod_linha  "+
	                       "   and linha.tipo_arvore = historico_importacao.tipo_arvore "+
                           "  inner join produto on produto.cod_produto = historico_importacao.cod_produto "+
	                       "  and produto.cod_linha = historico_importacao.cod_linha and produto.tipo_arvore = historico_importacao.tipo_arvore "+
	                       "  inner join modelo on modelo.cod_modelo = historico_importacao.cod_modelo "+
	                       "  and modelo.cod_produto = historico_importacao.cod_produto and modelo.tipo_arvore = historico_importacao.tipo_arvore "+
	                       "  inner join ocorrencia on ocorrencia.cod_ocorrencia = historico_importacao.cod_ocorrencia and ocorrencia.tipo_arvore = historico_importacao.tipo_arvore "+
                          "   inner join pergunta on pergunta.cod_pergunta = historico_importacao.cod_pergunta and pergunta.tipo_arvore = historico_importacao.tipo_arvore " +
	                       "  inner join pais on pais.cod_pais = historico_importacao.cod_pais "+
                          " where  historico_importacao.tipo_arvore = '" + tipoArvore + "' and historico_importacao.data_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'  ";

                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and historico_importacao.usuario = '" + codigoUsuario + "'  ";
                    }

                    sql = sql + " ) AS TBL " +
           "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
           "ORDER BY data_hora ";


                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {
                        sql = " SELECT * FROM ( " +
                         " SELECT ROW_NUMBER() OVER(ORDER BY data_hora) AS NUMBER, ";

                        sql = sql + "   linha.nome_linha_por, linha.nome_linha_ing, linha.nome_linha_esp, " +
                               "  produto.nome_produto_por, produto.nome_produto_ing, produto.nome_produto_esp, " +
                               "  modelo.nome_modelo_por, modelo.nome_modelo_ing, modelo.nome_modelo_esp, " +
                               "  ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_ing, ocorrencia.descricao_ocorrencia_esp, " +
                               "  pergunta.ordem as codigo, pergunta.tipo as tipoPergunta, pergunta.redacao_pergunta_por , pergunta.redacao_pergunta_ing , pergunta.redacao_pergunta_esp, " +
                               "  pergunta.resposta_por, pergunta.resposta_ing, pergunta.resposta_esp, " +
                               "  pais.nome_pais, historico_importacao.usuario, " +
                               "   historico_importacao.data_hora " +
                               "  from historico_importacao " +
                               "  inner join linha on linha.cod_linha = historico_importacao.cod_linha  " +
                               "   and linha.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join produto on produto.cod_produto = historico_importacao.cod_produto " +
                               "  and produto.cod_linha = historico_importacao.cod_linha and produto.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join modelo on modelo.cod_modelo = historico_importacao.cod_modelo " +
                               "  and modelo.cod_produto = historico_importacao.cod_produto and modelo.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join ocorrencia on ocorrencia.cod_ocorrencia = historico_importacao.cod_ocorrencia and ocorrencia.tipo_arvore = historico_importacao.tipo_arvore " +
                              "   inner join pergunta on pergunta.cod_pergunta = historico_importacao.cod_pergunta and pergunta.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join pais on pais.cod_pais = historico_importacao.cod_pais where  historico_importacao.tipo_arvore = '" + tipoArvore + "'  ";
                        

                        sql = sql + " ) AS TBL " +
               "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
               "ORDER BY data_hora ";


                    }
                    else
                    {
                        sql = " SELECT * FROM ( " +
                          " SELECT ROW_NUMBER() OVER(ORDER BY data_hora) AS NUMBER, ";

                        sql = sql + "   linha.nome_linha_por, linha.nome_linha_ing, linha.nome_linha_esp, " +
                               "  produto.nome_produto_por, produto.nome_produto_ing, produto.nome_produto_esp, " +
                               "  modelo.nome_modelo_por, modelo.nome_modelo_ing, modelo.nome_modelo_esp, " +
                               "  ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_ing, ocorrencia.descricao_ocorrencia_esp, " +
                               "  pergunta.ordem as codigo, pergunta.tipo as tipoPergunta, pergunta.redacao_pergunta_por , pergunta.redacao_pergunta_ing , pergunta.redacao_pergunta_esp, " +
                               "  pergunta.resposta_por, pergunta.resposta_ing, pergunta.resposta_esp, " +
                               "  pais.nome_pais, historico_importacao.usuario, " +
                               "   historico_importacao.data_hora " +
                               "  from historico_importacao " +
                               "  inner join linha on linha.cod_linha = historico_importacao.cod_linha  " +
                               "   and linha.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join produto on produto.cod_produto = historico_importacao.cod_produto " +
                               "  and produto.cod_linha = historico_importacao.cod_linha and produto.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join modelo on modelo.cod_modelo = historico_importacao.cod_modelo " +
                               "  and modelo.cod_produto = historico_importacao.cod_produto and modelo.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join ocorrencia on ocorrencia.cod_ocorrencia = historico_importacao.cod_ocorrencia and ocorrencia.tipo_arvore = historico_importacao.tipo_arvore " +
                              "   inner join pergunta on pergunta.cod_pergunta = historico_importacao.cod_pergunta and pergunta.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join pais on pais.cod_pais = historico_importacao.cod_pais " +
                              " where  historico_importacao.tipo_arvore = '" + tipoArvore + "' and historico_importacao.usuario = '" + codigoUsuario + "'  ";


                        sql = sql + " ) AS TBL " +
               "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
               "ORDER BY data_hora ";


                    }

                }

                // sql = sql + " order by a.data_e_hora desc OFFSET " + pagina + " ROWS FETCH NEXT " + limit + " ROWS ONLY ";

                conPEr = getConexao();

                SqlCommand comandoPer = new SqlCommand(sql, conPEr);
                conPEr.Open();
                SqlDataReader dr = comandoPer.ExecuteReader();
                while (dr.Read())
                {
               
                    string codigo = dr["codigo"].ToString();
                    string tipoPergunta = dr["tipoPergunta"].ToString();
                    string tipo_pergunta = "";
                    if (tipoPergunta.Equals("1"))
                    {
                        tipo_pergunta = "Verdadeiro/Falso";
                        if (idioma.Equals("ing"))
                        {
                            tipo_pergunta = "True/False";
                        }
                        else if (idioma.Equals("esp"))
                        {
                            tipo_pergunta = "Real/Falso";
                        }
                    

                    }
                    else if (tipoPergunta.Equals("2"))
                    {
                        tipo_pergunta = "Redação";
                        if (idioma.Equals("ing"))
                        {
                            tipo_pergunta = "Essay";
                        }
                        else if (idioma.Equals("esp"))
                        {
                            tipo_pergunta = "Fraseología";
                        }
                    }
                    string nome_pais = dr["nome_pais"].ToString();
                    string usuario = dr["usuario"].ToString();
                    string data_hora = dr["data_hora"].ToString();

                     string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
                     string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();
                     string redacao_pergunta_esp = dr["redacao_pergunta_esp"].ToString();
                     string resposta_por = dr["resposta_por"].ToString();
                     string resposta_ing = dr["resposta_ing"].ToString();
                     string resposta_esp = dr["resposta_esp"].ToString();

                     if (redacao_pergunta_por == null) redacao_pergunta_por = "";
                     if (redacao_pergunta_ing == null) redacao_pergunta_ing = "";
                     if (redacao_pergunta_esp == null) redacao_pergunta_esp = "";
                     if (resposta_por == null) resposta_por = "";
                     if (resposta_ing == null) resposta_ing = "";
                     if (resposta_esp == null) resposta_esp = "";

                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

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

                    if (idioma.Equals("ing"))
                    {
                        resposta_por = resposta_ing;
                        descricao_ocorrencia_por = descricao_ocorrencia_ing;
                        redacao_pergunta_por = redacao_pergunta_ing;
                        nome_linha_por = nome_linha_ing;
                        nome_produto_por = nome_produto_ing;
                        nome_modelo_por = nome_modelo_ing;
                    }
                    else if (idioma.Equals("esp"))
                    {
                        resposta_por = resposta_esp;
                        descricao_ocorrencia_por = descricao_ocorrencia_esp;
                        redacao_pergunta_por = redacao_pergunta_esp;
                        nome_linha_por = nome_linha_esp;
                        nome_produto_por = nome_produto_esp;
                        nome_modelo_por = nome_modelo_esp;

                    }

                    if (!resposta_por.Equals(""))
                    {
                        if (resposta_por.Length > 35)
                        {
                            resposta_por = "<span title='"+resposta_por+"'>" + resposta_por.Substring(0, 34) + "...<span>";
                        }
                    }

                    if (!descricao_ocorrencia_por.Equals(""))
                    {
                        if (descricao_ocorrencia_por.Length > 35)
                        {
                            descricao_ocorrencia_por = "<span title='" + descricao_ocorrencia_por + "'>" + descricao_ocorrencia_por.Substring(0, 34) + "...<span>";
                        }
                    }

                    if (!redacao_pergunta_por.Equals(""))
                    {
                        if (redacao_pergunta_por.Length > 35)
                        {
                            redacao_pergunta_por = "<span title='" + redacao_pergunta_por + "'>" + redacao_pergunta_por.Substring(0, 34) + "...<span>";
                        }
                    }

                    string conteudo = "{linha:\"" + nome_linha_por + "\", categoria:\"" + nome_produto_por + "\", subcategoria:\"" + nome_modelo_por + "\", ocorrencia:\"" + descricao_ocorrencia_por + "\", codigo:\"" + codigo + "\",  pergunta:\"" + redacao_pergunta_por + "\", resposta:`" + resposta_por + "`, tipo_pergunta:\"" + tipo_pergunta + "\", pais:\"" + nome_pais + "\", usuario:\"" + usuario + "\", data_e_hora:\"" + data_hora + "\"}";

                    dados = dados + virgula + conteudo;
                    virgula = ",";
                }


            }
            catch (Exception e) { dados = e.ToString(); }
            finally { conPEr.Close(); }
            dados = total + ",[" + dados + "]";

            return dados;
        }


        public string carregandoRelatorioDadosExcel(string codigoUsuario, string dataInicial, string dataFinal, string idioma, string tipoArvore)
        {
            string dados = ""; SqlConnection con = null;
            string virgula = "";
            string sql = "";
            try
            {
                if (!dataFinal.Equals("") && !dataInicial.Equals(""))
                {
                    dataInicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    dataFinal = dataFinal.Substring(6, 4) + "-" + dataFinal.Substring(3, 2) + "-" + dataFinal.Substring(0, 2);

                    sql = " SELECT ";

                    sql = sql + "   linha.nome_linha_por, linha.nome_linha_ing, linha.nome_linha_esp, " +
                           "  produto.nome_produto_por, produto.nome_produto_ing, produto.nome_produto_esp, " +
                           "  modelo.nome_modelo_por, modelo.nome_modelo_ing, modelo.nome_modelo_esp, " +
                           "  ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_ing, ocorrencia.descricao_ocorrencia_esp, " +
                           "  pergunta.ordem as codigo, pergunta.tipo as tipoPergunta, pergunta.redacao_pergunta_por , pergunta.redacao_pergunta_ing , pergunta.redacao_pergunta_esp, " +
                           "  pergunta.resposta_por, pergunta.resposta_ing, pergunta.resposta_esp, " +
                           "  pais.nome_pais, historico_importacao.usuario, " +
                           "   historico_importacao.data_hora " +
                           "  from historico_importacao " +
                           "  inner join linha on linha.cod_linha = historico_importacao.cod_linha  " +
                           "   and linha.tipo_arvore = historico_importacao.tipo_arvore " +
                           "  inner join produto on produto.cod_produto = historico_importacao.cod_produto " +
                           "  and produto.cod_linha = historico_importacao.cod_linha and produto.tipo_arvore = historico_importacao.tipo_arvore " +
                           "  inner join modelo on modelo.cod_modelo = historico_importacao.cod_modelo " +
                           "  and modelo.cod_produto = historico_importacao.cod_produto and modelo.tipo_arvore = historico_importacao.tipo_arvore " +
                           "  inner join ocorrencia on ocorrencia.cod_ocorrencia = historico_importacao.cod_ocorrencia and ocorrencia.tipo_arvore = historico_importacao.tipo_arvore " +
                          "   inner join pergunta on pergunta.cod_pergunta = historico_importacao.cod_pergunta and pergunta.tipo_arvore = historico_importacao.tipo_arvore " +
                           "  inner join pais on pais.cod_pais = historico_importacao.cod_pais " +
                          " where  historico_importacao.tipo_arvore = '" + tipoArvore + "' and historico_importacao.data_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'  ";

                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and historico_importacao.usuario = '" + codigoUsuario + "'  ";
                    }

                    sql = sql + " ORDER BY historico_importacao.data_hora ";


                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {
                        sql = " SELECT  ";

                        sql = sql + "   linha.nome_linha_por, linha.nome_linha_ing, linha.nome_linha_esp, " +
                               "  produto.nome_produto_por, produto.nome_produto_ing, produto.nome_produto_esp, " +
                               "  modelo.nome_modelo_por, modelo.nome_modelo_ing, modelo.nome_modelo_esp, " +
                               "  ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_ing, ocorrencia.descricao_ocorrencia_esp, " +
                               "  pergunta.ordem as codigo, pergunta.tipo as tipoPergunta, pergunta.redacao_pergunta_por , pergunta.redacao_pergunta_ing , pergunta.redacao_pergunta_esp, " +
                               "  pergunta.resposta_por, pergunta.resposta_ing, pergunta.resposta_esp, " +
                               "  pais.nome_pais, historico_importacao.usuario, " +
                               "   historico_importacao.data_hora " +
                               "  from historico_importacao " +
                               "  inner join linha on linha.cod_linha = historico_importacao.cod_linha  " +
                               "   and linha.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join produto on produto.cod_produto = historico_importacao.cod_produto " +
                               "  and produto.cod_linha = historico_importacao.cod_linha and produto.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join modelo on modelo.cod_modelo = historico_importacao.cod_modelo " +
                               "  and modelo.cod_produto = historico_importacao.cod_produto and modelo.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join ocorrencia on ocorrencia.cod_ocorrencia = historico_importacao.cod_ocorrencia and ocorrencia.tipo_arvore = historico_importacao.tipo_arvore " +
                              "   inner join pergunta on pergunta.cod_pergunta = historico_importacao.cod_pergunta and pergunta.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join pais on pais.cod_pais = historico_importacao.cod_pais where historico_importacao.tipo_arvore = '" + tipoArvore + "'  ";


                        sql = sql + " ORDER BY historico_importacao.data_hora ";


                    }
                    else
                    {
                        sql = " SELECT  ";

                        sql = sql + "   linha.nome_linha_por, linha.nome_linha_ing, linha.nome_linha_esp, " +
                               "  produto.nome_produto_por, produto.nome_produto_ing, produto.nome_produto_esp, " +
                               "  modelo.nome_modelo_por, modelo.nome_modelo_ing, modelo.nome_modelo_esp, " +
                               "  ocorrencia.descricao_ocorrencia_por, ocorrencia.descricao_ocorrencia_ing, ocorrencia.descricao_ocorrencia_esp, " +
                               "  pergunta.ordem as codigo, pergunta.tipo as tipoPergunta, pergunta.redacao_pergunta_por , pergunta.redacao_pergunta_ing , pergunta.redacao_pergunta_esp, " +
                               "  pergunta.resposta_por, pergunta.resposta_ing, pergunta.resposta_esp, " +
                               "  pais.nome_pais, historico_importacao.usuario, " +
                               "   historico_importacao.data_hora " +
                               "  from historico_importacao " +
                               "  inner join linha on linha.cod_linha = historico_importacao.cod_linha  " +
                               "   and linha.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join produto on produto.cod_produto = historico_importacao.cod_produto " +
                               "  and produto.cod_linha = historico_importacao.cod_linha and produto.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join modelo on modelo.cod_modelo = historico_importacao.cod_modelo " +
                               "  and modelo.cod_produto = historico_importacao.cod_produto and modelo.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join ocorrencia on ocorrencia.cod_ocorrencia = historico_importacao.cod_ocorrencia and ocorrencia.tipo_arvore = historico_importacao.tipo_arvore " +
                              "   inner join pergunta on pergunta.cod_pergunta = historico_importacao.cod_pergunta and pergunta.tipo_arvore = historico_importacao.tipo_arvore " +
                               "  inner join pais on pais.cod_pais = historico_importacao.cod_pais " +
                              " where historico_importacao.tipo_arvore = '" + tipoArvore + "' and historico_importacao.usuario = '" + codigoUsuario + "'  ";


                        sql = sql + "  ORDER BY historico_importacao.data_hora ";


                    }

                }

                con = getConexao();

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string codigo = dr["codigo"].ToString();
                    string tipoPergunta = dr["tipoPergunta"].ToString();
                    string tipo_pergunta = "";
                    if (tipoPergunta.Equals("1"))
                    {
                        tipo_pergunta = "Verdadeiro/Falso";
                        if (idioma.Equals("ing"))
                        {
                            tipo_pergunta = "True/False";
                        }
                        else if (idioma.Equals("esp"))
                        {
                            tipo_pergunta = "Real/Falso";
                        }


                    }
                    else if (tipoPergunta.Equals("2"))
                    {
                        tipo_pergunta = "Redação";
                        if (idioma.Equals("ing"))
                        {
                            tipo_pergunta = "Essay";
                        }
                        else if (idioma.Equals("esp"))
                        {
                            tipo_pergunta = "Fraseología";
                        }
                    }
                    string nome_pais = dr["nome_pais"].ToString();
                    string usuario = dr["usuario"].ToString();
                    string data_hora = dr["data_hora"].ToString();

                    string redacao_pergunta_por = dr["redacao_pergunta_por"].ToString();
                    string redacao_pergunta_ing = dr["redacao_pergunta_ing"].ToString();
                    string redacao_pergunta_esp = dr["redacao_pergunta_esp"].ToString();
                    string resposta_por = dr["resposta_por"].ToString();
                    string resposta_ing = dr["resposta_ing"].ToString();
                    string resposta_esp = dr["resposta_esp"].ToString();

                    if (redacao_pergunta_por == null) redacao_pergunta_por = "";
                    if (redacao_pergunta_ing == null) redacao_pergunta_ing = "";
                    if (redacao_pergunta_esp == null) redacao_pergunta_esp = "";
                    if (resposta_por == null) resposta_por = "";
                    if (resposta_ing == null) resposta_ing = "";
                    if (resposta_esp == null) resposta_esp = "";

                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

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

                    if (idioma.Equals("ing"))
                    {
                        resposta_por = resposta_ing;
                        descricao_ocorrencia_por = descricao_ocorrencia_ing;
                        redacao_pergunta_por = redacao_pergunta_ing;
                        nome_linha_por = nome_linha_ing;
                        nome_produto_por = nome_produto_ing;
                        nome_modelo_por = nome_modelo_ing;
                    }
                    else if (idioma.Equals("esp"))
                    {
                        resposta_por = resposta_esp;
                        descricao_ocorrencia_por = descricao_ocorrencia_esp;
                        redacao_pergunta_por = redacao_pergunta_esp;
                        nome_linha_por = nome_linha_esp;
                        nome_produto_por = nome_produto_esp;
                        nome_modelo_por = nome_modelo_esp;

                    }
                    else
                    {
                        if (!resposta_ing.Equals(""))
                        {
                            resposta_por = resposta_por + " / " + resposta_ing;
                        }
                        if (!resposta_esp.Equals(""))
                        {
                            resposta_por = resposta_por + " / " + resposta_esp;
                        }


                        if (!descricao_ocorrencia_ing.Equals(""))
                        {
                            descricao_ocorrencia_por = descricao_ocorrencia_por + " / " + descricao_ocorrencia_ing;
                        }
                        if (!resposta_esp.Equals(""))
                        {
                            descricao_ocorrencia_por = descricao_ocorrencia_por + " / " + descricao_ocorrencia_esp;
                        }

                        if (!redacao_pergunta_ing.Equals(""))
                        {
                            redacao_pergunta_por = redacao_pergunta_por + " / " + redacao_pergunta_ing;
                        }
                        if (!redacao_pergunta_esp.Equals(""))
                        {
                            redacao_pergunta_por = redacao_pergunta_por + " / " + redacao_pergunta_esp;
                        }

                        if (!nome_modelo_ing.Equals(""))
                        {
                            nome_modelo_por = nome_modelo_por + " / " + nome_modelo_ing;
                        }
                        if (!nome_modelo_esp.Equals(""))
                        {
                            nome_modelo_por = nome_modelo_por + " / " + nome_modelo_esp;
                        }

                        if (!nome_produto_ing.Equals(""))
                        {
                            nome_produto_por = nome_produto_por + " / " + nome_produto_ing;
                        }
                        if (!nome_produto_esp.Equals(""))
                        {
                            nome_produto_por = nome_produto_por + " / " + nome_produto_esp;
                        }

                        if (!nome_linha_ing.Equals(""))
                        {
                            nome_linha_por = nome_linha_por + " / " + nome_linha_ing;
                        }
                        if (!nome_linha_esp.Equals(""))
                        {
                            nome_linha_por = nome_linha_por + " / " + nome_linha_esp;
                        }
                      
                      /*  nome_linha_por = nome_linha_por + " / " + nome_linha_ing + " / " + nome_linha_esp;
                        nome_produto_por = nome_produto_por + " / " + nome_produto_ing + " / " + nome_produto_esp;
                        nome_modelo_por = nome_modelo_por + " / " + nome_modelo_ing + " / " + nome_modelo_esp;*/
                    }

                    string conteudo = nome_linha_por + "#" + nome_produto_por + "#" + nome_modelo_por + "#" + descricao_ocorrencia_por + "#" + codigo + "#" + redacao_pergunta_por + "#" + resposta_por + "#" + tipo_pergunta + "#" + nome_pais + "#" + usuario + "#" + data_hora;

                    dados = dados + virgula + conteudo;
                    virgula = "$";
                }


            }
            catch (Exception e) { }
            finally { con.Close(); }


            return dados;
        }


        public string carregaTotal(string codigoUsuario, string dataInicial, string dataFinal)
        {
            string dados = ""; SqlConnection con = null;
            string virgula = "";
            string sql = "";
            string qtde = "1";
            try
            {
                if (!dataFinal.Equals("") && !dataInicial.Equals(""))
                {
                    dataInicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    dataFinal = dataFinal.Substring(6, 4) + "-" + dataFinal.Substring(3, 2) + "-" + dataFinal.Substring(0, 2);

                    sql = "select count(a.cod_pesquisa) as qtde  " +
                    " from pesquisa a " +
                    "  left join linha b on b.cod_linha = a.cod_linha " +
                     "  left join produto c on c.cod_produto = a.cod_produto " +
                      "  left join modelo d on d.cod_modelo = a.cod_modelo " +
                       "  left join ocorrencia e on e.cod_ocorrencia = a.cod_ocorrencia " +
                    "  " +
                   " where a.data_e_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'";

                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and a.nome_usuario = '" + codigoUsuario + "'  ";
                    }

                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {
                        sql = "select count(a.cod_pesquisa) as qtde  " +

                              " from pesquisa a  left join linha b on b.cod_linha = a.cod_linha " +
                     "  left join produto c on c.cod_produto = a.cod_produto " +
                      "  left join modelo d on d.cod_modelo = a.cod_modelo " +
                       "  left join ocorrencia e on e.cod_ocorrencia = a.cod_ocorrencia ";

                    }
                    else
                    {
                        sql = "select count(a.cod_pesquisa) as qtde  " +
                          " from pesquisa a  left join linha b on b.cod_linha = a.cod_linha " +
                     "  left join produto c on c.cod_produto = a.cod_produto " +
                      "  left join modelo d on d.cod_modelo = a.cod_modelo " +
                       "  left join ocorrencia e on e.cod_ocorrencia = a.cod_ocorrencia " +
                     "   where a.nome_usuario = '" + codigoUsuario + "' ";

                    }

                }

                con = getConexao();

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


        public string carregaTotalRelatorioDados(string codigoUsuario, string dataInicial, string dataFinal, string tipoArvore)
        {
            string dados = ""; SqlConnection con = null;
            string virgula = "";
            string sql = "";
            string qtde = "1";
            try
            {
                if (!dataFinal.Equals("") && !dataInicial.Equals(""))
                {
                    dataInicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    dataFinal = dataFinal.Substring(6, 4) + "-" + dataFinal.Substring(3, 2) + "-" + dataFinal.Substring(0, 2);

                    sql = "  select count(*) as qtde from historico_importacao " +
                     " where tipo_arvore = '"+tipoArvore+"' and data_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'";

                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and usuario = '" + codigoUsuario + "'  ";
                    }

                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {
                        sql = " select count(*) as qtde from historico_importacao where tipo_arvore = '" + tipoArvore + "' ";

                    }
                    else
                    {
                        sql = "  select count(*) as qtde from historico_importacao  " +
                     "   where tipo_arvore = '" + tipoArvore + "' and usuario = '" + codigoUsuario + "' ";

                    }

                }

                con = getConexao();

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
            string dados = ""; SqlConnection con = null;
            string virgula = "";
            string sql = "";
            try
            {
                if (!dataFinal.Equals("") && !dataInicial.Equals(""))
                {
                    dataInicial = dataInicial.Substring(6, 4) + "-" + dataInicial.Substring(3, 2) + "-" + dataInicial.Substring(0, 2);
                    dataFinal = dataFinal.Substring(6, 4) + "-" + dataFinal.Substring(3, 2) + "-" + dataFinal.Substring(0, 2);

                    sql = "select a.nome_usuario,  pais.nome_pais, a.data_e_hora, a.cod_pesquisa , " +
                    " b.nome_linha_por, b.nome_linha_esp, b.nome_linha_ing,  " +
                    " c.nome_produto_por, c.nome_produto_esp, c.nome_produto_ing,  " +
                    " d.nome_modelo_por, d.nome_modelo_esp, d.nome_modelo_ing,  " +
                    " e.descricao_ocorrencia_por, e.descricao_ocorrencia_esp, e.descricao_ocorrencia_ing  " +
                    " from pesquisa a " +
                    "  left join linha b on b.cod_linha = a.cod_linha " +
                     "  left join produto c on c.cod_produto = a.cod_produto " +
                      "  left join modelo d on d.cod_modelo = a.cod_modelo " +
                       "  left join ocorrencia e on e.cod_ocorrencia = a.cod_ocorrencia  left join pais  on pais.cod_pais = e.cod_pais " +
                    "  " +
                   " where a.data_e_hora between '" + dataInicial + " 00:00:00' and '" + dataFinal + " 23:59:59'";

                    if (!codigoUsuario.Equals("0"))
                    {
                        sql = sql + " and a.nome_usuario = '" + codigoUsuario + "'  ";
                    }

                }
                else
                {
                    if (codigoUsuario.Equals("0"))
                    {
                        sql = "select a.nome_usuario,  pais.nome_pais, a.data_e_hora, a.cod_pesquisa,   " +

                             " b.nome_linha_por, b.nome_linha_esp, b.nome_linha_ing,  " +
                    " c.nome_produto_por, c.nome_produto_esp, c.nome_produto_ing,  " +
                    " d.nome_modelo_por, d.nome_modelo_esp, d.nome_modelo_ing,  " +
                    " e.descricao_ocorrencia_por, e.descricao_ocorrencia_esp, e.descricao_ocorrencia_ing  " +

                              " from pesquisa a  left join linha b on b.cod_linha = a.cod_linha " +
                     "  left join produto c on c.cod_produto = a.cod_produto " +
                      "  left join modelo d on d.cod_modelo = a.cod_modelo " +
                       "  left join ocorrencia e on e.cod_ocorrencia = a.cod_ocorrencia  left join pais  on pais.cod_pais = e.cod_pais ";

                    }
                    else
                    {
                        sql = "select a.nome_usuario, pais.nome_pais, a.data_e_hora, a.cod_pesquisa , " +
                               " b.nome_linha_por, b.nome_linha_esp, b.nome_linha_ing,  " +
                    " c.nome_produto_por, c.nome_produto_esp, c.nome_produto_ing,  " +
                    " d.nome_modelo_por, d.nome_modelo_esp, d.nome_modelo_ing,  " +
                    " e.descricao_ocorrencia_por, e.descricao_ocorrencia_esp, e.descricao_ocorrencia_ing  " +
                          " from pesquisa a  left join linha b on b.cod_linha = a.cod_linha " +
                     "  left join produto c on c.cod_produto = a.cod_produto " +
                      "  left join modelo d on d.cod_modelo = a.cod_modelo " +
                       "  left join ocorrencia e on e.cod_ocorrencia = a.cod_ocorrencia  left join pais  on pais.cod_pais = e.cod_pais " +
                     "   where a.nome_usuario = '" + codigoUsuario + "' ";

                    }

                }

                con = getConexao();

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string nome_usuario = dr["nome_usuario"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    string data_e_hora = dr["data_e_hora"].ToString();
                    string cod_pesquisa = dr["cod_pesquisa"].ToString();

                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

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

                    string conteudo = descricao_ocorrencia_ing + "#" + nome_linha_ing + "#" + nome_produto_ing + "#" + nome_modelo_ing + "#" + nome_modelo_esp + "#" + nome_produto_esp + "#" + nome_linha_esp + "#" + descricao_ocorrencia_esp + "#" + descricao_ocorrencia_por + "#" + nome_linha_por + "#" + nome_produto_por + "#" + nome_modelo_por + "#" + nome_usuario + "#" + data_e_hora + "#" + cod_pesquisa + "#" + nome_pais;

                    dados = dados + virgula + conteudo;
                    virgula = "$";
                }


            }
            catch (Exception e) { }
            finally { con.Close(); }
           

            return dados;
        }

    }
}
