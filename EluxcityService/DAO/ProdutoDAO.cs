using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;

namespace EluxcityWeb.DAO
{
    public class ProdutoDAO : Conexao
    {

        public string verificaExiste(string nomePor, string nomeEsp, string nomeIng, string tipoArvore, string codLinha, string codPais)
        {
            string codigo = "0"; SqlConnection con = null;
            try
            {
                string sql = "";
                  con = getConexao();

                if (nomePor == null) nomePor = "";
                if (nomeEsp == null) nomeEsp = "";
                if (nomeIng == null) nomeIng = "";

                sql = "select cod_produto from produto where cod_linha = "+codLinha+" and tipo_arvore = '" + tipoArvore + "' ";
                if (!nomeIng.Equals(""))
                {
                    sql = sql + " and nome_produto_ing =  '" + nomeIng + "'";
                }
                if (!nomeEsp.Equals(""))
                {
                    sql = sql + " and nome_produto_esp =  '" + nomeEsp + "'";
                }
                if (!nomePor.Equals(""))
                {
                    sql = sql + " and nome_produto_por =  '" + nomePor + "'";
                }

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_produto"].ToString();
                }

              


            }
            catch (Exception e) { codigo = e.Message; }
            finally { con.Close(); }


            return codigo;
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

        public string verificaConsistencia(string cod)
        {
            SqlConnection con = null;
            string codigo = "0";
            try
            {
                string sql = "";
                con = getConexao();
                sql = "select cod_modelo as codigo from modelo where cod_produto = " + cod;


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
        public string inserindoDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codLinha, string codPais,
            string tipoArvore)
        {
            string result = ""; SqlConnection con = null;
            if (codPais.Equals("0"))
            {
                codPais = "2";
            }
            try
            {
                  con = getConexao();
                string sql = "insert into produto (cod_produto, nome_produto_por, nome_produto_esp, nome_produto_ing, cod_linha, tipo_arvore) " +
                            " values (@codigo, @nomePor , @nomeEsp , @nomeIng, @codLinha, @tipoArvore) ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@nomePor", nomePor);
                comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                comando.Parameters.AddWithValue("@codLinha", codLinha);
                comando.Parameters.AddWithValue("@tipoArvore", tipoArvore);
                //comando.Parameters.AddWithValue("@codPais", codPais);

                con.Open();
                comando.ExecuteNonQuery();
              
            }
            catch (Exception e) { result = e.Message; }
            finally { con.Close(); }
            return result;
        }



        public bool excluindoDados(string codigo)
        {
            bool bExcluiu = true; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "delete from produto where cod_produto = @codigo ";

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
            string codigo = "0"; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "select max(cod_produto) + 1 as qtde from produto";
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

        public string verificaExiste(string nomePor, string codLinha, string tipoArvore, string codPais)
        {
            string codigo = "0"; SqlConnection con = null;
            string sql = "select cod_produto from produto where nome_produto_por = '" + nomePor + "' and cod_linha = " + codLinha + " and tipo_arvore = '" + tipoArvore + "'";

            try
            {
                  con = getConexao();
                 
                  con.Open();
                SqlCommand comando = new SqlCommand(sql, con);
               
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_produto"].ToString();
                }

                
            }
            catch (Exception e) {}
            finally { con.Close(); }


            return codigo;
        }


        public string carregaTotal(string tipoArvore, string idioma, string codLinha, string codPais)
        {
            string dados = ""; SqlConnection con = null;
            string virgula = "";
            string qtde = "1";
            try
            {

                if (codLinha.Equals("")) codLinha = "0";
                con = getConexao();
                string sql = "select count(l.cod_linha) as qtde from produto p " +
                "inner join linha l on l.cod_linha = p.cod_linha where  (p.cod_pais = " + codPais + " or p.cod_pais is null) and p.tipo_arvore = '" + tipoArvore + "'";

                if (!codLinha.Equals("0"))
                {
                    sql = "select count(l.cod_linha) as qtde  from produto p " +
                                      "inner join linha l on l.cod_linha = p.cod_linha where  (p.cod_pais = " + codPais + " or p.cod_pais is null) and p.tipo_arvore = '" + tipoArvore + "' and l.cod_linha = " + codLinha;
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

        public string carregandoDados(string tipoArvore, string idioma, string codLinha, string limit, string offset,
            string total, string codPais)
        {
            string dados = ""; SqlConnection con = null;
            string virgula = "";
            try
            {

                int pagina = Int16.Parse(offset) - 1;
               /* if (pagina > 0)
                {
                    pagina = pagina * Int16.Parse(limit);
                }*/

                pagina = pagina + 1;


                if (codLinha.Equals("")) codLinha = "0";
                  con = getConexao();
                

                string sql = " SELECT * FROM ( " +
         " SELECT ROW_NUMBER() OVER(ORDER BY cod_produto) AS NUMBER, " +
        " linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing, produto.cod_produto, produto.nome_produto_por , " +
                    " produto.nome_produto_ing, produto.nome_produto_esp " +
                   "  FROM produto  " +
                    " inner join linha  on linha.cod_linha = produto.cod_linha  where  (produto.cod_pais = " + codPais + " or produto.cod_pais is null) and produto.tipo_arvore = '" + tipoArvore + "' " +
                   
           " ) AS TBL " +
                 "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
                 "ORDER BY cod_produto ";


                if (!codLinha.Equals("0"))
                {
                    sql = " SELECT * FROM ( " +
                             " SELECT ROW_NUMBER() OVER(ORDER BY cod_produto) AS NUMBER, " +
                            " linha.nome_linha_por, linha.nome_linha_esp, linha.nome_linha_ing, produto.cod_produto, produto.nome_produto_por , " +
                                        " produto.nome_produto_ing, produto.nome_produto_esp " +
                                       "  FROM produto  " +
                                        " inner join linha  on linha.cod_linha = produto.cod_linha  where (produto.cod_pais = " + codPais + " or produto.cod_pais is null) and produto.tipo_arvore = '" + tipoArvore + "' and linha.cod_linha = " + codLinha +

                               " ) AS TBL " +
                                     "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
                                     "ORDER BY cod_produto ";

                }

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_produto = dr["cod_produto"].ToString();
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_linha_esp = dr["nome_linha_esp"].ToString();
                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();

                    string alterar = "<img src='../includes/imagens/edit.png'  title='Altera Registro' style='cursor:pointer; vertical-align:top;' onclick=alterarRegistro('" + cod_produto + "')  >";
                    string excluir = "<img src='../includes/imagens/remove.png'  title='Exclui Registro' style='cursor:pointer; vertical-align:top;' onclick=excluirRegistro('" + cod_produto + "')  >";

                    string conteudo = "{nome_por:\"" + nome_produto_por + "\", linha_ing:\"" + nome_linha_ing + "\",  linha_esp:\"" + nome_linha_esp + "\",  linha:\"" + nome_linha_por + "\", nome_ing:\"" + nome_produto_ing + "\", nome_esp:\"" + nome_produto_esp + "\", cod_produto:\"" + cod_produto + "\", alterar:\"" + alterar + "\", excluir:\"" + excluir + "\"}";

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
            catch (Exception e) { }
            finally { con.Close(); }
           // dados = "[" + dados + "]";

            dados = total + ",[" + dados + "]";

            return dados;
        }


        public string carregaProduto(string codigo)
        {
            string dados = ""; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "select l.nome_linha_por, p.cod_linha, p.cod_produto,  p.nome_produto_por , p.nome_produto_ing, p.nome_produto_esp from produto p " +
                  "inner join linha l on l.cod_linha = p.cod_linha  where p.cod_produto = " + codigo;
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string cod_linha = dr["cod_linha"].ToString();
                    string nome_produto_por = dr["nome_produto_por"].ToString();
                    string nome_produto_ing = dr["nome_produto_ing"].ToString();
                  
                    string nome_produto_esp = dr["nome_produto_esp"].ToString();

                  

                    dados = nome_produto_por + ";" + nome_produto_ing + ";" + nome_produto_esp + ";" + nome_linha_por + ";" + cod_linha ;


                }

                
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }

        public string alterandoDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codLinha, string codPais)
        {
            string result = ""; SqlConnection con = null;
            try
            {
                  con = getConexao();
                string sql = "update produto set nome_produto_por = @nomePor , nome_produto_esp = @nomeEsp " +
                    " , nome_produto_ing = @nomeIng, cod_linha = @codLinha  where cod_produto = @codigo ";

                SqlCommand comando = new SqlCommand(sql, con);
                comando.Parameters.AddWithValue("@nomePor", nomePor);
                comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                comando.Parameters.AddWithValue("@codigo", codigo);
                comando.Parameters.AddWithValue("@codLinha", codLinha);
                

                con.Open();
                comando.ExecuteNonQuery();
               
            }
            catch (Exception e) { result = e.Message; }
            finally { con.Close(); }
            return result;
        }


        public string carregandoComboLinha()
        {
            string dados = "<option value=\"\"> </option>"; SqlConnection con = null;
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

    }
}
