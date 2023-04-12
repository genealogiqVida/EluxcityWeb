using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;

namespace EluxcityWeb.DAO
{
    public class OcorrenciaDAO : Conexao
    {


        public string verificaExiste(string nomePor)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "select cod_ocorrencia from ocorrencia where descricao_ocorrencia_por = '" + nomePor + "' ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_ocorrencia"].ToString();
                }

              
            }
            catch (Exception e) { }
            finally { con.Close(); }


            return codigo;
        }


        public string verificaExiste(string cod_ocorrencia, string cod_modelo)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = "select cod_ocorrencia from modelo_ocorrencia where cod_modelo = " + cod_modelo + " and cod_ocorrencia = "+cod_ocorrencia;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_ocorrencia"].ToString();
                }


            }
            catch (Exception e) { }
            finally { con.Close(); }


            return codigo;
        }


        public string verificaExiste(string nomePor, string tipoArvore, string cod_pais)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                con = getConexao();
                string sql = " select cod_ocorrencia from ocorrencia where descricao_ocorrencia_por = '" + nomePor + "' and tipo_arvore = '" + tipoArvore + "' and cod_pais = " + cod_pais;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_ocorrencia"].ToString();
                }


            }
            catch (Exception e) { }
            finally { con.Close(); }


            return codigo;
        }

        public void excluiOcorrencia()
        {
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "DELETE FROM ocorrencia WHERE NOT EXISTS (SELECT * FROM modelo_ocorrencia WHERE ocorrencia.cod_ocorrencia = modelo_ocorrencia.cod_ocorrencia) ";

                SqlCommand comando = new SqlCommand(sql, con);

                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e) { }
            finally { con.Close(); }

        }

        public string inserindoDados(string codigo, string descricaoPor, string descricaoIng, string descricaoEsp, string[] codModelos,
            string codPais, string tipoArvore, string idioma)
        {
            string result = "";
            SqlConnection con = null;

            if (codPais.Equals("0"))
            {
                codPais = null;
            }
            if (codPais.Equals(""))
            {
                codPais = null;
            }
            if (descricaoEsp.Equals("")) descricaoEsp = " ";
            if (descricaoPor.Equals("")) descricaoPor = " ";
            if (descricaoIng.Equals("")) descricaoIng = " ";

            try
            {
                con = getConexao();
             
                string sql = "insert into ocorrencia (cod_ocorrencia, descricao_ocorrencia_por, descricao_ocorrencia_ing, descricao_ocorrencia_esp, cod_pais, tipo_arvore) " +
                            " values (@codigo, @descricaoPor , @descricaoIng , @descricaoEsp, @codPais, @tipoArvore) ";

                string sql2 = "insert into modelo_ocorrencia (cod_ocorrencia, cod_modelo)" +
                            " values (@codigo, @codModelo)";

                SqlCommand comando1 = new SqlCommand(sql, con);
                comando1.Parameters.AddWithValue("@codigo", codigo);
                comando1.Parameters.AddWithValue("@descricaoPor", descricaoPor);
                comando1.Parameters.AddWithValue("@descricaoIng", descricaoIng);
                comando1.Parameters.AddWithValue("@descricaoEsp", descricaoEsp);
                comando1.Parameters.AddWithValue("@codPais", codPais);
                comando1.Parameters.AddWithValue("@tipoArvore", tipoArvore);

                con.Open();
                comando1.ExecuteNonQuery();




                for (int i = 0; i < codModelos.Length; i++)
                {

                    SqlCommand comando2 = new SqlCommand(sql2, con);

                    comando2.Parameters.AddWithValue("@codigo", codigo);
                    comando2.Parameters.AddWithValue("@codModelo", codModelos[i]);
                    comando2.ExecuteNonQuery();

                }


               
            }
            catch (Exception e) { result = e.Message; }

            finally
            {
                con.Close();
            }

            return result;
        }


        public void inserindoDadosPesquisa(string codigo, string codOcorrencia, string codUsuario, string nomeUsuario,
            string codModelo, string codLinha,string codProduto)
        {
            SqlConnection con = null;

            try
            {
                 con = getConexao();
                string sql = "insert into pesquisa (cod_pesquisa, cod_ocorrencia, cod_usuario, nome_usuario, data_e_hora, cod_modelo, cod_linha, cod_produto) " +
                            " values (@codigo, @codOcorrencia , @codUsuario , @nomeUsuario, @dataHora , @codModelo, @codLinha, @codProduto) ";

             
                SqlCommand comando1 = new SqlCommand(sql, con);
                comando1.Parameters.AddWithValue("@codigo", codigo);
                comando1.Parameters.AddWithValue("@codOcorrencia", codOcorrencia);
                comando1.Parameters.AddWithValue("@codUsuario", codUsuario);
                comando1.Parameters.AddWithValue("@nomeUsuario", nomeUsuario);
                comando1.Parameters.AddWithValue("@dataHora", DateTime.Now);
                comando1.Parameters.AddWithValue("@codModelo", codModelo);
                comando1.Parameters.AddWithValue("@codLinha", codLinha);
                comando1.Parameters.AddWithValue("@codProduto", codProduto);

                con.Open();
                comando1.ExecuteNonQuery();




                
              
            }
            catch (Exception e) {  }
            finally { con.Close(); }
        }


        public bool insereModeloOcorrencia(string codigo, string[] codModelos)
        {
            bool bSalvou = true;

            SqlConnection con = null;
            try
            {
                 con = getConexao();

                string sql2 = "insert into modelo_ocorrencia (cod_ocorrencia, cod_modelo)" +
                            " values (@codigo, @codModelo)";


                con.Open();

                for (int i = 0; i < codModelos.Length; i++)
                {
                    try
                    {

                        SqlCommand comando2 = new SqlCommand(sql2, con);

                        comando2.Parameters.AddWithValue("@codigo", codigo);
                        comando2.Parameters.AddWithValue("@codModelo", codModelos[i]);
                        comando2.ExecuteNonQuery();
                    }
                    catch (Exception e) { bSalvou = false; }

                }


               
            }
            catch (Exception e) { bSalvou = false; }
            finally { con.Close(); }
            return bSalvou;
        }


        public bool insereOcorrencia(string codigo, string descricaoPor, string descricaoEsp, string descricaoIng, string codPais, string tipoArvore)
        {
            bool bSalvou = true;
            SqlConnection con = null;

            try
            {
                 con = getConexao();
                string sql = "insert into ocorrencia (cod_ocorrencia, descricao_ocorrencia_por, descricao_ocorrencia_ing, descricao_ocorrencia_esp, cod_pais, tipo_arvore) " +
                            " values (@codigo, @descricaoPor , @descricaoIng , @descricaoEsp, @codPais, @tipoArvore) ";


                SqlCommand comando1 = new SqlCommand(sql, con);
                comando1.Parameters.AddWithValue("@codigo", codigo);
                comando1.Parameters.AddWithValue("@descricaoPor", descricaoPor);
                comando1.Parameters.AddWithValue("@descricaoIng", descricaoIng);
                comando1.Parameters.AddWithValue("@descricaoEsp", descricaoEsp);
                comando1.Parameters.AddWithValue("@codPais", codPais);
                comando1.Parameters.AddWithValue("@tipoArvore", tipoArvore);

                con.Open();
                comando1.ExecuteNonQuery();


            }
            catch (Exception e) { bSalvou = false; }
            finally { con.Close(); }
            return bSalvou;
        }


        public bool excluindoDados(string codigo)
        {
            SqlConnection con = null;
            bool bExcluiu = true;
            try
            {
                 con = getConexao();
                string sql = "delete from ocorrencia where cod_ocorrencia = @codigo ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@codigo", codigo);


                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e) { bExcluiu = false; }
            finally { con.Close(); }
            return bExcluiu;
        }


        public bool excluindoDadosModelo(string codigo)
        {
            SqlConnection con = null;
            bool bExcluiu = true;
            try
            {
                con = getConexao();
                string sql = "delete from modelo_ocorrencia where cod_ocorrencia = @codigo ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@codigo", codigo);


                con.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e) { bExcluiu = false; }
            finally { con.Close(); }
            return bExcluiu;
        }


        public string getProximoRegistro()
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "select max(cod_ocorrencia) + 1 as qtde from ocorrencia";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["qtde"].ToString();
                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }
            if (codigo == null) codigo = "";
            if (codigo.Equals("")) codigo = "0";

            if (codigo.Equals("0"))
            {
                codigo = "1";
            }

            return codigo;
        }


        public string getProximoRegistroPesquisa()
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "select max(cod_pesquisa) + 1 as qtde from pesquisa";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["qtde"].ToString();
                }

              
            }
            catch (Exception e) { }
            finally { con.Close(); }
            if (codigo == null) codigo = "";
            if (codigo.Equals("")) codigo = "0";

            if (codigo.Equals("0"))
            {
                codigo = "1";
            }

            return codigo;
        }


        public string carregandoDados(string tipo, string[] codModelos, string idioma, string pais, string tipoArvore,
            string codLinha, string codProduto, string limit, string offset, string total, string descOcorrencia)
        {
            string dados = "";
            
            SqlConnection con = null;
            string virgula = "";
            string sql = "";
            if (codLinha.Equals("")) codLinha = "0";
            if (codProduto.Equals("")) codProduto = "0";
            if (codProduto.Trim().Equals("")) codProduto = "0";
            if(pais != "2")
            {
                pais = "1";
            }
            try
            {

                if (pais.Equals(""))
                    pais = "0";


                if (tipo.Equals("usuario"))
                {
                    if (pais.Equals("0"))
                        pais = "2"; //seta Brasil

                }

                string codMod = "";
                string separador = "";
                for (int i = 0; i < codModelos.Length; i++)
                {
                    codMod = codMod + separador + codModelos[i];
                    separador = ",";
                }

                if (codMod.Equals(""))
                {
                    codMod = "0";

                }

                int pagina = Int16.Parse(offset) - 1;
                /*if (pagina > 0)
                {
                    pagina = pagina * Int16.Parse(limit);
                }*/
                pagina = pagina + 1;

                 con = getConexao();

                 sql = " SELECT * FROM ( " +
                    " SELECT ROW_NUMBER() OVER(ORDER BY ocorrencia.cod_ocorrencia) AS NUMBER, ";

              sql = sql +   "  modelo.cod_modelo , linha.cod_linha, produto.cod_produto, pais.nome_pais, linha.nome_linha_por, produto.nome_produto_por, " +
                   "   modelo.nome_modelo_por,  " +
                    "  linha.nome_linha_ing, produto.nome_produto_ing,  modelo.nome_modelo_ing, linha.nome_linha_esp, produto.nome_produto_esp, modelo.nome_modelo_esp,  " +
                      "  ocorrencia.cod_ocorrencia, ocorrencia.descricao_ocorrencia_por,  ocorrencia.descricao_ocorrencia_ing, ocorrencia.descricao_ocorrencia_esp " +
                      "  FROM ocorrencia  " +
                     "  inner join modelo_ocorrencia  on modelo_ocorrencia.cod_ocorrencia = ocorrencia.cod_ocorrencia " +
                     "     inner join modelo  on modelo.cod_modelo = modelo_ocorrencia.cod_modelo " +
                              "  inner join produto  on produto.cod_produto = modelo.cod_produto " +
                                " left join pais on pais.cod_pais = ocorrencia.cod_pais " +
                              "  inner join linha  on linha.cod_linha = produto.cod_linha   " +
                      "  where ocorrencia.tipo_arvore = '"+tipoArvore+"'  ";

               
                if (!pais.Equals("0"))
                {
                    sql = sql + " and ocorrencia.cod_pais = " + pais;
                }

                if (!codLinha.Equals("0"))
                {
                    sql = sql + " and linha.cod_linha = " + codLinha;
                }
                if (!codProduto.Equals("0"))
                {
                    sql = sql + " and produto.cod_produto = " + codProduto;
                }

                if (!codMod.Equals("0"))
                {
                    sql = sql + " and modelo.cod_modelo in (" + codMod + ") ";
                }

                if (!descOcorrencia.Equals(""))
                {
                    sql = sql + " and  (ocorrencia.descricao_ocorrencia_por like '%" + descOcorrencia + "%'  or ocorrencia.descricao_ocorrencia_ing like '%" + descOcorrencia + "%' or ocorrencia.descricao_ocorrencia_esp like '%" + descOcorrencia + "%')  ";
                }



                sql = sql + " ) AS TBL " +
              "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
              "ORDER BY cod_ocorrencia ";

             
                            

                if (tipo.Equals("usuario"))
                {
                     codMod = "";
                     separador= "";
                    for (int i = 0; i < codModelos.Length; i++)
                    {
                        codMod = codMod + separador + codModelos[i];
                        separador = ",";
                    }

                    if (codMod.Equals(""))
                    {
                        codMod = "0";
                    }


                    sql = " SELECT * FROM ( " +
                  " SELECT ROW_NUMBER() OVER(ORDER BY ocorrencia.cod_ocorrencia) AS NUMBER, ";

                    sql = sql + "  modelo.cod_modelo, linha.cod_linha,  produto.cod_produto,  pais.nome_pais, ocorrencia.cod_ocorrencia, " +
                  " ocorrencia.descricao_ocorrencia_por ,ocorrencia.descricao_ocorrencia_ing, " +
                  "  ocorrencia.descricao_ocorrencia_esp, modelo.nome_modelo_por, modelo.nome_modelo_esp, modelo.nome_modelo_ing, " +
                  "   linha.nome_linha_por, produto.nome_produto_por , linha.nome_linha_esp, produto.nome_produto_esp, " +
                  "    linha.nome_linha_ing, produto.nome_produto_ing " +
                      "  FROM ocorrencia  " +
                     "  inner join modelo_ocorrencia  on modelo_ocorrencia.cod_ocorrencia = ocorrencia.cod_ocorrencia " +
                     "     inner join modelo  on modelo.cod_modelo = modelo_ocorrencia.cod_modelo " +
                              "  inner join produto  on produto.cod_produto = modelo.cod_produto " +
                                " left join pais on pais.cod_pais = ocorrencia.cod_pais " +
                              "  inner join linha  on linha.cod_linha = produto.cod_linha   " +
                      "  where ocorrencia.tipo_arvore = '" + tipoArvore + "'  ";
                   

                    if (!codMod.Equals("0"))
                    {
                        sql = sql + " and modelo_ocorrencia.cod_modelo in (" + codMod + ") ";
                    }

                    if (!pais.Equals("0"))
                    {
                        sql = sql + " and ocorrencia.cod_pais = " + pais;
                    }

                    if (!codLinha.Equals("0"))
                    {
                        sql = sql + " and linha.cod_linha = " + codLinha;
                    }
                    if (!codProduto.Equals("0"))
                    {
                        sql = sql + " and produto.cod_produto = " + codProduto;
                    }

                    if (!descOcorrencia.Equals(""))
                    {
                        sql = sql + " and  (ocorrencia.descricao_ocorrencia_por like '%" + descOcorrencia + "%'  or ocorrencia.descricao_ocorrencia_ing like '%" + descOcorrencia + "%' or ocorrencia.descricao_ocorrencia_esp like '%" + descOcorrencia + "%')  ";
                    }

                    sql = sql + " ) AS TBL " +
           "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
           "ORDER BY cod_ocorrencia ";
                
             
                
                }

               
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {

                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();
                    string descricao_ocorrencia_ing = dr["descricao_ocorrencia_ing"].ToString();
                    string descricao_ocorrencia_esp = dr["descricao_ocorrencia_esp"].ToString();
                    string cod_ocorrencia = dr["cod_ocorrencia"].ToString();
                    string cod_modelo = dr["cod_modelo"].ToString();
                    string cod_linha = dr["cod_linha"].ToString();
                    string cod_produto = dr["cod_produto"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    if (nome_pais == null)
                    {
                        nome_pais = "";
                    }
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();

                    string nome_linha_esp = dr["nome_linha_esp"].ToString();
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();
                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();

                    string nome_modelo_esp = dr["nome_modelo_esp"].ToString();
                    string nome_modelo_ing = dr["nome_modelo_ing"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();

                  

                    string modelo = "";
                    if (tipo.Equals("usuario"))
                    {
                         nome_modelo_esp = dr["nome_modelo_esp"].ToString();
                         nome_modelo_ing = dr["nome_modelo_ing"].ToString();
                         nome_modelo_por = dr["nome_modelo_por"].ToString();

                        modelo = nome_modelo_por;
                    }

                    string alterar = "<img src='../includes/imagens/edit.png'   style='cursor:pointer; vertical-align:top;' onclick=alterarRegistro('" + cod_ocorrencia + "')  >";
                    string excluir = "<img src='../includes/imagens/remove.png'  style='cursor:pointer; vertical-align:top;' onclick=excluirRegistro('" + cod_ocorrencia + "')  >";

                    string perguntas = "<img src='../includes/imagens/pergunta.png'  style='cursor:pointer; vertical-align:top;' onclick=carregaPerguntas('"+cod_ocorrencia+","+cod_modelo+","+cod_linha+","+cod_produto+"')   >";


                    descricao_ocorrencia_esp = descricao_ocorrencia_esp.Replace("\"", "&#34;");
                    descricao_ocorrencia_ing = descricao_ocorrencia_ing.Replace("\"", "&#34;");
                    descricao_ocorrencia_por = descricao_ocorrencia_por.Replace("\"", "&#34;");

                    nome_modelo_por = nome_modelo_por.Replace("\"", "&#34;");
                    nome_modelo_esp = nome_modelo_esp.Replace("\"", "&#34;");
                    nome_modelo_ing = nome_modelo_ing.Replace("\"", "&#34;");

                    nome_produto_esp = nome_produto_esp.Replace("\"", "&#34;");
                    nome_produto_ing = nome_produto_ing.Replace("\"", "&#34;");
                    nome_produto_por = nome_produto_por.Replace("\"", "&#34;");



                    string conteudo = "{perguntas:\"" + perguntas + "\",  pais:\"" + nome_pais + "\",  nome_linha_ing:\"" + nome_linha_ing + "\", nome_produto_ing:\"" + nome_produto_ing + "\", nome_modelo_ing:\"" + nome_modelo_ing + "\",  nome_linha_esp:\"" + nome_linha_esp + "\", nome_produto_esp:\"" + nome_produto_esp + "\", nome_modelo_esp:\"" + nome_modelo_esp + "\",    nome_linha_por:\"" + nome_linha_por + "\", nome_produto_por:\"" + nome_produto_por + "\", nome_modelo_por:\"" + nome_modelo_por + "\", descricao_ocorrencia_por:\"" + descricao_ocorrencia_por + "\", descricao_ocorrencia_ing:\"" + descricao_ocorrencia_ing + "\", descricao_ocorrencia_esp:\"" + descricao_ocorrencia_esp + "\", cod_ocorrencia:\"" + cod_ocorrencia + "\", alterar:\"" + alterar + "\", excluir:\"" + excluir + "\"}";

                    dados = dados + virgula + conteudo;
                    virgula = ",";
                }

               

                if (dados.Equals(""))
                {
                    string msg = "<font color=red>Nenhum registro encontrado</font>";
                    string msging = "<font color=red>No records found</font>";
                    string msgesp = "<font color=red>No se encontraron registros</font>";


                    if (idioma.Equals("pt-BR"))
                    {
                        msgesp = "";
                        msging = "";
                    }
                    else if (idioma.Equals("en-US"))
                    {
                        msgesp = "";
                        msg = "";
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        msg = "";
                        msging = "";
                    }

                    dados = "{perguntas:'', nome_linha_ing:'',   pais:'', nome_linha_esp:'', nome_linha_por:'', nome_produto_por:'',  nome_produto_ing:'',  nome_modelo_ing:'', nome_modelo_esp:'', nome_produto_esp:'', modelo:'', descricao_ocorrencia_por:'" + msg + "', descricao_ocorrencia_ing:'" + msging + "', descricao_ocorrencia_esp:'" + msgesp + "', cod_ocorrencia:'', alterar:'', excluir:''}";

                }
            }
            catch (Exception e) { dados = e.Message; }
            finally { con.Close(); }



            dados = total + ",[" + dados + "]";

            return dados;
        }


        public string carregaTotal(string tipo, string[] codModelos, string idioma, string pais, string tipoArvore,
          string codLinha, string codProduto, string descOcorrencia)
        {
            string qtde = "1";

            SqlConnection con = null;
            string virgula = "";
            string sql = "";
            if (codLinha.Equals("")) codLinha = "0";
            if (codProduto.Equals("")) codProduto = "0";
            if (codProduto.Trim().Equals("")) codProduto = "0";
            try
            {

                if (pais.Equals(""))
                    pais = "0";


                if (tipo.Equals("usuario"))
                {
                    if (pais.Equals("0"))
                        pais = "2"; //seta Brasil

                }


                string codMod = "";
                string separador = "";
                for (int i = 0; i < codModelos.Length; i++)
                {
                    codMod = codMod + separador + codModelos[i];
                    separador = ",";
                }

                if (codMod.Equals(""))
                {
                    codMod = "0";
                }

              
              
  

                con = getConexao();
                sql = " SELECT  count(o.cod_ocorrencia) as qtde    " +
                            " FROM ocorrencia o  inner join modelo_ocorrencia mo on mo.cod_ocorrencia = o.cod_ocorrencia " +
                            "inner join modelo m on m.cod_modelo = mo.cod_modelo " +
                            "inner join produto p on p.cod_produto = m.cod_produto " +
                             "left join pais pa on pa.cod_pais = o.cod_pais " +
                            "inner join linha l on l.cod_linha = p.cod_linha  ";


                sql = sql + " where o.tipo_arvore = '" + tipoArvore + "'";

                if (!pais.Equals("0"))
                {
                    sql = sql + " and o.cod_pais = " + pais;
                }

                if (!codLinha.Equals("0"))
                {
                    sql = sql + " and l.cod_linha = " + codLinha;
                }
                if (!codProduto.Equals("0"))
                {
                    sql = sql + " and p.cod_produto = " + codProduto;
                }

                if (!codMod.Equals("0"))
                {
                    sql = sql + " and m.cod_modelo in (" + codMod + ") ";
                }

                if (!descOcorrencia.Equals(""))
                {
                    sql = sql + " and  (o.descricao_ocorrencia_por like '%" + descOcorrencia + "%'  or o.descricao_ocorrencia_ing like '%" + descOcorrencia + "%' or o.descricao_ocorrencia_esp like '%" + descOcorrencia + "%')  ";
                }

              


                if (tipo.Equals("usuario"))
                {
                    codMod = "";
                    separador = "";
                    for (int i = 0; i < codModelos.Length; i++)
                    {
                        codMod = codMod + separador + codModelos[i];
                        separador = ",";
                    }

                    if (codMod.Equals(""))
                    {
                        codMod = "0";
                    }

                    sql = "select  count(a.cod_ocorrencia) as qtde   from ocorrencia a " +
                     "inner join modelo_ocorrencia b on b.cod_ocorrencia = a.cod_ocorrencia " +
                     "  " +
                     "inner join modelo c on c.cod_modelo = b.cod_modelo " +
                     "inner join produto p on p.cod_produto = c.cod_produto " +
                      "left join pais pa on pa.cod_pais = a.cod_pais " +
                     "inner join linha l on l.cod_linha = p.cod_linha ";


                    sql = sql + " where a.tipo_arvore = '" + tipoArvore + "'";

                    if (!codMod.Equals("0"))
                    {
                        sql = sql + " and b.cod_modelo in (" + codMod + ") ";
                    }

                    if (!pais.Equals("0"))
                    {
                        sql = sql + " and a.cod_pais = " + pais;
                    }

                    if (!codLinha.Equals("0"))
                    {
                        sql = sql + " and l.cod_linha = " + codLinha;
                    }
                    if (!codProduto.Equals("0"))
                    {
                        sql = sql + " and p.cod_produto = " + codProduto;
                    }

                    if (!descOcorrencia.Equals(""))
                    {
                        sql = sql + " and  (a.descricao_ocorrencia_por like '%" + descOcorrencia + "%'  or a.descricao_ocorrencia_ing like '%" + descOcorrencia + "%' or a.descricao_ocorrencia_esp like '%" + descOcorrencia + "%')  ";
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





            return qtde;
        }


        public string carregaOcorrencia(string codigo)
        {
            string dados = "";
            string virgula = "";
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "SELECT o.cod_pais, l.cod_linha, p.cod_produto, m.cod_modelo, o.cod_ocorrencia, o.descricao_ocorrencia_por, o.descricao_ocorrencia_ing, o.descricao_ocorrencia_esp FROM ocorrencia o " +
                             "inner join modelo_ocorrencia mo on mo.cod_ocorrencia = o.cod_ocorrencia " +
                             "inner join modelo m on m.cod_modelo = mo.cod_modelo " +
                             "inner join produto p on p.cod_produto = m.cod_produto " +
                             "inner join linha l on l.cod_linha = p.cod_linha " +
                             "WHERE o.cod_ocorrencia = " + codigo;

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();

                string cod_ocorrencia = "";
                string descricao_ocorrencia_por = "";
                string descricao_ocorrencia_ing = "";
                string descricao_ocorrencia_esp = "";
                string cod_linha = "";
                string cod_produto = "";
                string ids_modelos = "";
                string cod_pais = "";


                while (dr.Read())
                {
                    cod_pais = dr["cod_pais"].ToString();
                     cod_ocorrencia = dr["cod_ocorrencia"].ToString();
                    descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();
                    descricao_ocorrencia_ing = dr["descricao_ocorrencia_ing"].ToString();
                    descricao_ocorrencia_esp = dr["descricao_ocorrencia_esp"].ToString();
                    cod_linha = dr["cod_linha"].ToString();
                    cod_produto = dr["cod_produto"].ToString();
                    string cod_modelo = dr["cod_modelo"].ToString();
                    ids_modelos = ids_modelos + virgula + cod_modelo;
                    virgula = ",";
                }

                if(cod_pais == null){
                    cod_pais = "";
                }
                if(cod_pais.Equals("")) cod_pais = "0";

                string conteudo = descricao_ocorrencia_por + ";" + descricao_ocorrencia_ing + ";" + descricao_ocorrencia_esp + ";" + cod_ocorrencia + ";" + cod_linha + ";" + cod_produto + ";" + ids_modelos + ";" + cod_pais;
                dados = conteudo;

              
            }
            catch (Exception e) { dados = e.ToString(); }

            finally { con.Close(); }
            return dados;
        }



        public string carregandoComboOcorrencia()
        {
            SqlConnection con = null;
            string dados = "<option value=\"\">  </option>";
            try
            {
                 con = getConexao();
                string sql = "select descricao_ocorrencia_por, cod_ocorrencia from ocorrencia  " +
                  " order by descricao_ocorrencia_por ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_ocorrencia = dr["cod_ocorrencia"].ToString();
                    string descricao_ocorrencia_por = dr["descricao_ocorrencia_por"].ToString();

                    string conteudo = "<option value=\"" + cod_ocorrencia + "\">" + descricao_ocorrencia_por + "</option>";

                    dados = dados + conteudo;

                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string carregandoComboLinha()
        {
            SqlConnection con = null;
            string dados = "<option value=\"\">  </option>";
            try
            {
                 con = getConexao();
                string sql = "select nome_linha_por, cod_linha from linha  " +
                  " order by nome_linha_por ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_linha = dr["cod_linha"].ToString();
                    string nome_linha_por = dr["nome_linha_por"].ToString();

                    string conteudo = "<option value=\"" + cod_linha + "\">" + nome_linha_por + "</option>";

                    dados = dados + conteudo;

                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string carregandoComboProduto(string codigo)
        {
            SqlConnection con = null;
            string dados = "<option value=\"0\"> </option>";
            try
            {
                 con = getConexao();
                string sql = "select nome_produto_por, cod_produto from produto where cod_linha = " + codigo +
                    " order by nome_produto_por ";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_produto = dr["cod_produto"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();

                    string conteudo = "<option value=\"" + cod_produto + "\">" + nome_produto_por + "</option>";

                    dados = dados + conteudo;

                }

              
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }


        public string carregaCodigoPais(string nome)
        {
            SqlConnection con = null;
            string codigo = "0";
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


        public string verificaExiste(string nomePor, string nomeEsp, string nomeIng, string idioma,
            string tipoArvore, string[] codModelos, string codPais, string codLinha, string codProduto)
        {
            SqlConnection con = null;
            string codigo = "0";
            string codigoModelos = "";
            string virgula = "";
            try
            {
                if (codModelos != null)
                {
                    for (int i = 0; i < codModelos.Length; i++)
                    {
                        codigoModelos = codigoModelos + virgula + codModelos[i];
                        virgula = ",";
                    }
                }


                string sql = "";
                 con = getConexao();
                if (idioma.Equals("en-US"))
                {
                   // sql = "select cod_ocorrencia from ocorrencia where descricao_ocorrencia_eng = '" + nomeIng + "' and cod_pais = "+codPais+" and tipo_arvore = '" + tipoArvore + "'";

                    sql = " select a.cod_ocorrencia from ocorrencia a " +
                "inner join modelo_ocorrencia b on b.cod_ocorrencia = a.cod_ocorrencia  " +
                "inner join modelo d on d.cod_modelo = b.cod_modelo  " +
                "inner join produto c on c.cod_produto = d.cod_produto  " +
                "inner join linha e on e.cod_linha = c.cod_linha  " +
                "where a.descricao_ocorrencia_ing =  '" + nomePor + "' and a.cod_pais =  " + codPais + "   " +
                "and a.tipo_arvore = '" + tipoArvore + "' and d.cod_modelo in (" + codigoModelos + ")  " +
                "and e.cod_linha = " + codLinha + "  and c.cod_produto = " + codProduto;
                    
                }
                else if (idioma.Equals("es-ES"))
                {
                   // sql = "select cod_ocorrencia from ocorrencia where descricao_ocorrencia_esp = '" + nomeEsp + "' and cod_pais = " + codPais + " and tipo_arvore = '" + tipoArvore + "'";


                    sql = " select a.cod_ocorrencia from ocorrencia a " +
                   "inner join modelo_ocorrencia b on b.cod_ocorrencia = a.cod_ocorrencia  " +
                   "inner join modelo d on d.cod_modelo = b.cod_modelo  " +
                   "inner join produto c on c.cod_produto = d.cod_produto  " +
                   "inner join linha e on e.cod_linha = c.cod_linha  " +
                   "where a.descricao_ocorrencia_esp =  '" + nomePor + "' and a.cod_pais =  " + codPais + "   " +
                   "and a.tipo_arvore = '" + tipoArvore + "' and d.cod_modelo in (" + codigoModelos + ")  " +
                   "and e.cod_linha = " + codLinha + "  and c.cod_produto = " + codProduto;
                    
                }
                else
                {
                   // sql = "select cod_ocorrencia from ocorrencia where descricao_ocorrencia_por = '" + nomePor + "' and cod_pais = " + codPais + " and tipo_arvore = '" + tipoArvore + "'";
                    


                    sql = " select a.cod_ocorrencia from ocorrencia a "+
                    "inner join modelo_ocorrencia b on b.cod_ocorrencia = a.cod_ocorrencia  "+
                    "inner join modelo d on d.cod_modelo = b.cod_modelo  "+
                    "inner join produto c on c.cod_produto = d.cod_produto  "+
                    "inner join linha e on e.cod_linha = c.cod_linha  "+
                    "where a.descricao_ocorrencia_por =  '" + nomePor + "' and a.cod_pais =  " + codPais + "   " +
                    "and a.tipo_arvore = '" + tipoArvore + "' and d.cod_modelo in ("+codigoModelos+")  "+
                    "and e.cod_linha = "+codLinha+"  and c.cod_produto = "+codProduto;


                }

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_ocorrencia"].ToString();
                }

               
            }
            catch (Exception e) { }

            finally { con.Close(); }


            return codigo;
        }

        public string verificaConsistencia(string cod, string tipoArvore)
        {
            SqlConnection con = null;
            string codigo = "0";
            try
            {
                string sql = "";
                con = getConexao();
                sql = "select cod_pergunta as codigo from pergunta where cod_ocorrencia = " + cod + " and tipo_arvore = '" + tipoArvore + "'";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["codigo"].ToString();
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }


            return codigo;
        }


        public string carregandoComboModelo(string codigo, string idioma, string tipoArvore, string pais)
        {
            SqlConnection con = null;
            string dados = "";
            if (pais.Equals(""))
            {
                pais = "0";
            }

            if (pais.Equals("0"))
            {
                pais = "2";
            }
            try
            {
                 con = getConexao();
                string sql = "select nome_modelo_por, nome_modelo_ing, nome_modelo_esp ,cod_modelo from modelo where tipo_arvore = '"+tipoArvore+"' and cod_produto = " + codigo;

                if (!pais.Equals("0"))
                {
                    sql = sql + " and cod_pais = " + pais;
                }

                    if (idioma.Equals("en-US"))
                    {
                        sql = sql + "  order by nome_modelo_ing ";
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        sql = sql + "  order by nome_modelo_esp ";
                    }
                    else
                    {
                        sql = sql + "  order by nome_modelo_por ";
                    }


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_modelo = dr["cod_modelo"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string nome_modelo_esp = dr["nome_modelo_esp"].ToString();
                    string nome_modelo_ing = dr["nome_modelo_ing"].ToString();

                    if (idioma.Equals("en-US"))
                    {
                        nome_modelo_por = nome_modelo_ing;
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        nome_modelo_por = nome_modelo_esp;
                    }


                    if (!nome_modelo_por.Equals(""))
                    {
                        string conteudo = "<option value=\"" + cod_modelo + "\">" + nome_modelo_por + "</option>";

                        dados = dados + conteudo;
                    }

                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }


        public string alterandoDados(string codigo, string descricaoPor, string descricaoIng, string descricaoEsp, string[] codModelos)
        {
            string result = "";
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "update ocorrencia set descricao_ocorrencia_por = @descricaoPor , descricao_ocorrencia_ing = @descricaoIng " +
                    " , descricao_ocorrencia_esp = @descricaoEsp where cod_ocorrencia = @codigo ";

                string sql2 = "delete from modelo_ocorrencia where cod_ocorrencia = " + codigo;

                string sql3 = "insert into modelo_ocorrencia (cod_ocorrencia, cod_modelo)" +
                            " values (@codigo, @codModelo)";

                SqlCommand comando1 = new SqlCommand(sql, con);
                comando1.Parameters.AddWithValue("@descricaoPor", descricaoPor);
                comando1.Parameters.AddWithValue("@descricaoIng", descricaoIng);
                comando1.Parameters.AddWithValue("@descricaoEsp", descricaoEsp);
                comando1.Parameters.AddWithValue("@codigo", codigo);

                SqlCommand comando2 = new SqlCommand(sql2, con);
                con.Open();
                comando1.ExecuteNonQuery();
                comando2.ExecuteNonQuery();

                for (int i = 0; i < codModelos.Length; i++)
                {

                    SqlCommand comando3 = new SqlCommand(sql3, con);

                    comando3.Parameters.AddWithValue("@codigo", codigo);
                    comando3.Parameters.AddWithValue("@codModelo", codModelos[i]);
                    comando3.ExecuteNonQuery();

                }


               
            }
            catch (Exception e) { result = e.Message; }
            finally { con.Close(); }
            return result;
        }

    }
}
