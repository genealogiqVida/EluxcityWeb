using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;

namespace EluxcityWeb.DAO
{
    public class ModeloDAO : Conexao
    {


        public string inserindoDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codProduto, string codPais,
            string username, string tipoArvore)
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
            if (username.Equals("")) username = null;
            if (tipoArvore.Equals("")) tipoArvore = null;

            if (nomeEsp.Equals("")) nomeEsp = " ";
            if (nomePor.Equals("")) nomePor = " ";
            if (nomeIng.Equals("")) nomeIng = " ";
            string sql = "";
            try
            {

               

                 con = getConexao();
                 sql = "insert into modelo (cod_modelo, nome_modelo_por, nome_modelo_esp, nome_modelo_ing, cod_produto, cod_pais, tipo_arvore) " +
                            " values (@codigo, @nomePor, @nomeEsp, @nomeIng, @codProduto, @codPais, @tipoArvore) ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@nomePor", nomePor);
                comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                comando.Parameters.AddWithValue("@codProduto", codProduto);
                comando.Parameters.AddWithValue("@codPais", codPais);
                comando.Parameters.AddWithValue("@tipoArvore", tipoArvore);
               

                con.Open();
                comando.ExecuteNonQuery();
              
            }
            catch (Exception e) { //result = e.StackTrace;
                result =  codigo+ " - "+nomePor + " - "+nomeEsp+ " - "+nomeIng + " - "+codProduto+" - "+codPais + " - "+ tipoArvore;
            
            }
            finally { con.Close(); }
            return result;
        }



        public string verificaExiste(string nomePor, string nomeEsp, string nomeIng, string idioma, string codProduto,
            string tipoArvore, string codPais)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                string sql = "";
                 con = getConexao();

                 if (codPais.Equals("")) codPais = "0";

                if (idioma.Equals("en-US"))
                {
                    sql = "select cod_modelo from modelo where nome_modelo_ing = '" + nomeIng + "' and tipo_arvore = '"+tipoArvore+"'";
                    if (!codProduto.Equals("0"))
                    {
                        sql = "select cod_modelo from modelo where nome_modelo_ing = '" + nomeIng + "'  and tipo_arvore = '"+tipoArvore+"' and cod_produto = "+codProduto;
                    }
                }
                else if (idioma.Equals("es-ES"))
                {
                    sql = "select cod_modelo from modelo where nome_modelo_esp = '" + nomeEsp + "' and tipo_arvore = '"+tipoArvore+"'";
                    if (!codProduto.Equals("0"))
                    {
                        sql = "select cod_modelo from modelo where nome_modelo_esp = '" + nomeEsp + "' and tipo_arvore = '"+tipoArvore+"' and cod_produto = " + codProduto;
                    }
                }
                else
                {
                    sql = "select cod_modelo from modelo where nome_modelo_por = '" + nomePor + "' and tipo_arvore = '"+tipoArvore+"'";
                    if (!codProduto.Equals("0"))
                    {
                        sql = "select cod_modelo from modelo where nome_modelo_por = '" + nomePor + "' and tipo_arvore = '"+tipoArvore+"' and cod_produto = " + codProduto;
                    }
                }

                if (!codPais.Equals("0"))
                {
                    sql = sql + " and cod_pais = " + codPais;
                }
                
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_modelo"].ToString();
                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }


            return codigo;
        }

        public string verificaConsistencia(string cod)
        {
            SqlConnection con = null;
            string codigo = "0";
            try
            {
                string sql = "";
                con = getConexao();
                sql = "select cod_ocorrencia as codigo from modelo_ocorrencia where cod_modelo = " + cod;


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["codigo"].ToString();
                }


            }
            catch (Exception e) { codigo = e.ToString(); }

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

        public bool excluindoDados(string codigo)
        {
            bool bExcluiu = true;
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "delete from modelo where cod_modelo = @codigo ";

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
                string sql = "select max(cod_modelo) + 1 as qtde from modelo";
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


        public string carregaTotal(string idioma, string pais, string codLinha, string codProduto, string tipoArvore)
        {
            string dados = "";
            string virgula = "";
            string sql = "";
            string qtde = "1";
            SqlConnection con = null;
            try
            {

                if (pais.Equals(""))
                    pais = "0";

                con = getConexao();

                if (codLinha.Equals("")) codLinha = "0";
                if (codProduto.Equals("")) codProduto = "0";

               // if (pais.Equals("0"))
               // {
                   // pais = "2";
               // }

                if (pais.Equals("2"))
                {
                    sql = "select count(m.cod_modelo) as qtde from modelo m " +
               "inner join produto p on p.cod_produto = m.cod_produto " +
               "inner join linha l on l.cod_linha = p.cod_linha" +
                " left join pais pa on pa.cod_pais = m.cod_pais " +
               " where m.tipo_arvore = '" + tipoArvore + "' and ( m.cod_pais = " + pais + " or m.cod_pais is null) ";

                    if (!codLinha.Equals("0"))
                    {
                        sql = sql + " and p.cod_linha = " + codLinha;
                    }
                    if (!codProduto.Equals("0"))
                    {
                        sql = sql + " and m.cod_produto = " + codProduto;
                    }


                }
                else
                {
                    sql = "select count(m.cod_modelo) as qtde from modelo m " +
                                  "inner join produto p on p.cod_produto = m.cod_produto " +
                                  "inner join linha l on l.cod_linha = p.cod_linha" +
                                  " left join pais pa on pa.cod_pais = m.cod_pais " +
                                  " where m.tipo_arvore = '" + tipoArvore + "' " ;

                    if (!pais.Equals("0"))
                    {
                        sql = sql + " and m.cod_pais = " + pais;
                    }

                    if (!codLinha.Equals("0"))
                    {
                        sql = sql + " and p.cod_linha = " + codLinha;
                    }
                    if (!codProduto.Equals("0"))
                    {
                        sql = sql + " and m.cod_produto = " + codProduto;
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
            catch (Exception e) { dados = e.Message; }
            finally { con.Close(); }
            // dados = "[" + dados + "]";

           // dados = total + ",[" + dados + "]";

            return qtde;
        }



        public string carregandoDados(string idioma, string pais, string codLinha, string codProduto, string tipoArvore,
            string limit, string offset, string total)
        {
            string dados = "";
            string virgula = "";
            string sql = "";
            SqlConnection con = null;
            if (pais != "0" && pais != "2")
            {
                pais = "1";
            }
            try
            {

                if (pais.Equals(""))
                    pais = "0";

                int pagina = Int16.Parse(offset) - 1;
               /* if (pagina > 0)
                {
                    pagina = pagina * Int16.Parse(limit);
                }*/

                pagina = pagina + 1;

                 con = getConexao();

                 if (codLinha.Equals("")) codLinha = "0";
                 if (codProduto.Equals("")) codProduto = "0";

                
                if (pais.Equals("2"))
                {
               

                     sql = " SELECT * FROM ( " +
                     " SELECT ROW_NUMBER() OVER(ORDER BY cod_modelo) AS NUMBER, ";

                  sql = sql +  "  linha.nome_linha_por,  pais.nome_pais,  linha.nome_linha_ing, linha.nome_linha_esp, produto.cod_produto, produto.nome_produto_por,  "+
                  " produto.nome_produto_esp, produto.nome_produto_ing, "+
                  "  modelo.cod_modelo, modelo.nome_modelo_por , modelo.nome_modelo_ing, modelo.nome_modelo_esp "+
                  "   FROM modelo  " +
                  "   inner join produto  on produto.cod_produto = modelo.cod_produto  "+
                  "   inner join linha  on linha.cod_linha = produto.cod_linha "+
                  "   left join pais on pais.cod_pais = modelo.cod_pais  "+
                  "   where modelo.tipo_arvore = '"+tipoArvore+"' and ( modelo.cod_pais = "+pais+" or modelo.cod_pais is null) ";

                  if (!codLinha.Equals("0"))
                  {
                      sql = sql + " and produto.cod_linha = " + codLinha;
                  }
                  if (!codProduto.Equals("0"))
                  {
                      sql = sql + " and modelo.cod_produto = " + codProduto;
                  }

                  sql = sql +  " ) AS TBL " +
                 "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
                 "ORDER BY cod_modelo ";



                     


                }
                else
                {
                   


                    sql = " SELECT * FROM ( " +
                    " SELECT ROW_NUMBER() OVER(ORDER BY cod_modelo) AS NUMBER, ";

                    sql = sql + "  linha.nome_linha_por,  pais.nome_pais,  linha.nome_linha_ing, linha.nome_linha_esp, produto.cod_produto, produto.nome_produto_por,  " +
                    " produto.nome_produto_esp, produto.nome_produto_ing, " +
                    "  modelo.cod_modelo, modelo.nome_modelo_por , modelo.nome_modelo_ing, modelo.nome_modelo_esp " +
                    "   FROM modelo  " +
                    "   inner join produto  on produto.cod_produto = modelo.cod_produto  " +
                    "   inner join linha  on linha.cod_linha = produto.cod_linha " +
                    "   left join pais on pais.cod_pais = modelo.cod_pais  " +
                    "   where modelo.tipo_arvore = '" + tipoArvore + "' ";

                    if (!pais.Equals("0"))
                    {
                        sql = sql + " and modelo.cod_pais = " + pais;
                    }

                    if (!codLinha.Equals("0"))
                    {
                        sql = sql + " and produto.cod_linha = " + codLinha;
                    }
                    if (!codProduto.Equals("0"))
                    {
                        sql = sql + " and modelo.cod_produto = " + codProduto;
                    }

                    sql = sql + " ) AS TBL " +
                   "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
                   "ORDER BY cod_modelo ";


                }

           
                SqlCommand comando = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_modelo = dr["cod_modelo"].ToString();
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    string nome_linha_esp = dr["nome_linha_esp"].ToString();
                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string nome_modelo_ing = dr["nome_modelo_ing"].ToString();
                    string nome_modelo_esp = dr["nome_modelo_esp"].ToString();

                    string alterar = "<img src='../includes/imagens/edit.png'  style='cursor:pointer; vertical-align:top;' onclick=alterarRegistro('" + cod_modelo + "')  >";
                    string excluir = "<img src='../includes/imagens/remove.png'   style='cursor:pointer; vertical-align:top;' onclick=excluirRegistro('" + cod_modelo + "')  >";

                    string conteudo = "{produto_ing:\"" + nome_produto_ing + "\",  pais:\"" + nome_pais + "\", produto_esp:\"" + nome_produto_esp + "\", linha_ing:\"" + nome_linha_ing + "\",  linha_esp:\"" + nome_linha_esp + "\",    nome_por:\"" + nome_modelo_por + "\", linha:\"" + nome_linha_por + "\", produto:\"" + nome_produto_por + "\", nome_ing:\"" + nome_modelo_ing + "\", nome_esp:\"" + nome_modelo_esp + "\", cod_modelo:\"" + cod_modelo + "\", alterar:\"" + alterar + "\", excluir:\"" + excluir + "\"}";

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

                    dados = "{nome_por:\"" + nomepor + "\", linha:\"\", nome_ing:\"" + nomeing + "\", nome_esp:\"" + nomeesp + "\", cod_produto:\"\", alterar:\"\", excluir:\"\"}";

                }
                

              
            }
            catch (Exception e) { dados = e.Message; }
            finally { con.Close(); }
           // dados = "[" + dados + "]";

            dados = total + ",[" + dados + "]";

            return dados;
        }


        public string carregaModelo(string codigo)
        {
            SqlConnection con = null;
            string dados = "";
            try
            {
                 con = getConexao();
                string sql = "select l.cod_linha, l.nome_linha_por, p.cod_produto, p.nome_produto_por, m.nome_modelo_por , b.cod_pais , b.nome_pais, m.nome_modelo_ing, m.nome_modelo_esp from modelo m " +
                            "inner join produto p on p.cod_produto = m.cod_produto " +
                            "inner join linha l on l.cod_linha = p.cod_linha  left join pais b on b.cod_pais = m.cod_pais   where m.cod_modelo =" + codigo;


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    string nome_modelo_por = dr["nome_modelo_por"].ToString();
                    string nome_modelo_ing = dr["nome_modelo_ing"].ToString();
                    string nome_modelo_esp = dr["nome_modelo_esp"].ToString();
                    string cod_pais = dr["cod_pais"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string cod_linha = dr["cod_linha"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string cod_produto = dr["cod_produto"].ToString();

                    if (cod_pais == null)
                    {
                        cod_pais = "0";
                        nome_pais = "";
                    }


                    dados = nome_modelo_por + ";" + nome_modelo_ing + ";" + nome_modelo_esp + ";" + nome_linha_por + ";" + cod_linha + ";" + nome_produto_por + ";" + cod_produto + ";" + cod_pais + ";" + nome_pais;


                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string alterandoDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codProduto, string codPais,
            string username, string tipoArvore)
        {
            string result = "";
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                string sql = "update modelo set nome_modelo_por = @nomePor , nome_modelo_esp = @nomeEsp " +
                    " , nome_modelo_ing = @nomeIng, cod_produto = @codProduto, cod_pais = @codPais  where cod_modelo = @codigo ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@nomePor", nomePor);
                comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@codProduto", codProduto);
                comando.Parameters.AddWithValue("@codPais", codPais);
              

                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e) { result = e.StackTrace; }
            finally { con.Close(); }
            return result;
        }


        public string carregandoComboProduto(string codigo, string idioma, string tipoArvore, string codPais)
        {
            string sql = "";
            string dados = "<option value=\"\"> </option>";
            if (codPais != "2")
            {
                codPais = "1";
            }
            SqlConnection con = null;
            try
            {
                 con = getConexao();
                 
                // if (codPais.Equals("")) codPais = "0";
                 if (codPais.Equals("admin"))
                 {
                      sql = "select nome_produto_por, nome_produto_ing, nome_produto_esp, cod_produto from produto where cod_linha = " + codigo +
                 "    and tipo_arvore = '" + tipoArvore + "'  and (cod_pais = " + codPais + " or cod_pais is null)   order by nome_produto_por ";

                 }
                 else
                 {
                     //codPais = "0"; // para produto nao tem cadastro de pais, somente para modelo
                      sql = "select nome_produto_por, nome_produto_ing, nome_produto_esp, cod_produto from produto where cod_linha = " + codigo +
                // "  and ( cod_pais = " + codPais + " or cod_pais is null)  and tipo_arvore = '" + tipoArvore + "' order by nome_produto_por ";
                 "    and tipo_arvore = '" + tipoArvore + "' and ( cod_pais = " + codPais + " or cod_pais is null) order by nome_produto_por ";

                 }

             
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_produto = dr["cod_produto"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                     string nome_produto_esp = dr["nome_produto_esp"].ToString();


                    if (idioma.Equals("en-US"))
                    {
                        nome_produto_por = nome_produto_ing;
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        nome_produto_por = nome_produto_esp;
                    }

                    string conteudo = "<option value=\"" + cod_produto + "\">" + nome_produto_por + "</option>";

                    dados = dados + conteudo;

                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }


            //dados = sql;
            return dados;
        }


        public string carregandoComboProdutoUsuario(string codigo, string idioma, string tipoArvore, string codPais)
        {
            string sql = "";
            string dados = "<option value=\"\"> </option>";
            if (codPais != "2")
            {
                codPais = "1";
            }
            SqlConnection con = null;
            try
            {
                con = getConexao();

                sql = "select distinct b.nome_produto_por, b.nome_produto_ing, b.nome_produto_esp, b.cod_produto from modelo a "+
                        "inner join produto b on b.cod_produto = a.cod_produto "+
                        "inner join linha c on c.cod_linha = b.cod_linha "+
                        " where a.cod_pais = " + codPais + " and c.cod_linha = " + codigo + " and a.tipo_arvore = '" + tipoArvore + "' ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_produto = dr["cod_produto"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();


                    if (idioma.Equals("en-US"))
                    {
                        nome_produto_por = nome_produto_ing;
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        nome_produto_por = nome_produto_esp;
                    }

                    string conteudo = "<option value=\"" + cod_produto + "\">" + nome_produto_por + "</option>";

                    dados = dados + conteudo;

                }


            }
            catch (Exception e) { }
            finally { con.Close(); }


            //dados = sql;
            return dados;
        }


        public string carregandoComboLinha(string idioma, string tipoArvore, string codPais)
        {
            SqlConnection con = null;
            string dados = "<option value=\"\"> </option>";
            if (codPais != "2")
            {
                codPais = "1";
            }
            try
            {
                 con = getConexao();
                string sql = "select nome_linha_por,  nome_linha_ing, nome_linha_esp, cod_linha from linha" +
                  " where tipo_arvore = '"+tipoArvore+"' and (cod_pais = "+codPais+" or cod_pais is null) order by nome_linha_por ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_linha = dr["cod_linha"].ToString();
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_linha_esp = dr["nome_linha_esp"].ToString();

                    if (idioma.Equals("en-US"))
                    {
                        nome_linha_por = nome_linha_ing;
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        nome_linha_por = nome_linha_esp;
                    }

                    string conteudo = "<option value=\"" + cod_linha + "\">" + nome_linha_por + "</option>";

                    dados = dados + conteudo;

                }

            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }


        public string carregandoComboLinhaUsuario(string idioma, string tipoArvore, string codPais)
        {
            SqlConnection con = null;
            string dados = "<option value=\"\"> </option>";
            if (codPais != "2")
            {
                codPais = "1";
            }
            try
            {
                con = getConexao();
                //string sql = "select nome_linha_por,  nome_linha_ing, nome_linha_esp, cod_linha from linha" +
                 // " where tipo_arvore = '" + tipoArvore + "' and (cod_pais = " + codPais + " or cod_pais is null) order by nome_linha_por ";


                string sql = "select distinct c.cod_linha, c.nome_linha_esp, c.nome_linha_ing, c.nome_linha_por from modelo a " +
               "inner join produto b on b.cod_produto = a.cod_produto " +
               "inner join linha c on c.cod_linha = b.cod_linha " +
                "where a.cod_pais = " + codPais + " and a.tipo_arvore = '" + tipoArvore + "' ";

                
                
                
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_linha = dr["cod_linha"].ToString();
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_linha_esp = dr["nome_linha_esp"].ToString();

                    if (idioma.Equals("en-US"))
                    {
                        nome_linha_por = nome_linha_ing;
                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        nome_linha_por = nome_linha_esp;
                    }

                    string conteudo = "<option value=\"" + cod_linha + "\">" + nome_linha_por + "</option>";

                    dados = dados + conteudo;

                }

            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }


    }
}
