using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;

namespace EluxcityWeb.DAO
{
    public class LinhaDAO : Conexao
    {


        public string rodandoScript(string script)
        {
            string result = "";

           

            SqlConnection con = null;
            try
            {
                con = getConexao();

                
                    SqlCommand comando = new SqlCommand(script, con);
                  
                    con.Open();
                    comando.ExecuteNonQuery();
             

            }
            catch (Exception e) { result = e.Message; }
            finally { con.Close(); }

            return result;
        }

        public string inserindoDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codPais, string tipoArvore)
        {
            string result = "";

           // if (codPais.Equals("0"))
           // {
              //  codPais = "2";
           // }

            codPais = "0";

            SqlConnection con = null;
            try
            {
                 con = getConexao();

                 if (codPais.Equals("0"))
                 {
                     string sql = "insert into linha (cod_linha, nome_linha_por, nome_linha_esp, nome_linha_ing, tipo_arvore) " +
                           " values (@codigo, @nomePor , @nomeEsp , @nomeIng, @tipoArvore) ";

                     SqlCommand comando = new SqlCommand(sql, con);
                     comando.Parameters.AddWithValue("@codigo", codigo);
                     comando.Parameters.AddWithValue("@nomePor", nomePor);
                     comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                     comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                     comando.Parameters.AddWithValue("@tipoArvore", tipoArvore);
                     con.Open();
                     comando.ExecuteNonQuery();
                    
                 }
                 else
                 {
                     string sql = "insert into linha (cod_linha, nome_linha_por, nome_linha_esp, nome_linha_ing, tipo_arvore, cod_pais) " +
                           " values (@codigo, @nomePor , @nomeEsp , @nomeIng, @tipoArvore, @codPais) ";

                     SqlCommand comando = new SqlCommand(sql, con);
                     comando.Parameters.AddWithValue("@codigo", codigo);
                     comando.Parameters.AddWithValue("@nomePor", nomePor);
                     comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                     comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                     comando.Parameters.AddWithValue("@tipoArvore", tipoArvore);
                     comando.Parameters.AddWithValue("@codPais", codPais);
                     con.Open();
                     comando.ExecuteNonQuery();
                 }
               

               
               
            }
            catch (Exception e) { result = e.StackTrace; }
            finally { con.Close(); }

            return result;
        }


        public string verificaConsistencia(string cod)
        {
            SqlConnection con = null;
            string codigo = "0";
            try
            {
                string sql = "";
                con = getConexao();
                sql = "select cod_produto as codigo from produto where cod_linha = " + cod;


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

        public string verificaExiste(string nomePor, string nomeEsp, string nomeIng, string tipoArvore, string codPais)
        {
            string codigo = "0";
            SqlConnection con = null;
            try
            {
                string sql = "";
                 con = getConexao();

                if (nomePor == null) nomePor = "";
                if (nomeEsp == null) nomeEsp = "";
                if (nomeIng == null) nomeIng = "";

                if (codPais.Equals("0"))
                {
                    sql = "select cod_linha from linha where tipo_arvore = '" + tipoArvore + "' and cod_pais is null ";
                }else{
                    sql = "select cod_linha from linha where tipo_arvore = '" + tipoArvore + "' and cod_pais = " + codPais;
                }
                
                if (!nomeIng.Equals(""))
                {
                    sql =  sql + " and nome_linha_ing =  '"+nomeIng+"'";
                }
                if (!nomeEsp.Equals(""))
                {
                    sql = sql + " and nome_linha_esp =  '" + nomeEsp + "'";
                }
                if (!nomePor.Equals(""))
                {
                    sql = sql + " and nome_linha_por =  '" + nomePor + "'";
                }
                  
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_linha"].ToString();
                }

              

              
            }
            catch (Exception e) { codigo = e.Message; }

            finally { con.Close(); }

            return codigo;
        }



        public string carregaComboPais()
        {
            SqlConnection con = null;
            string dados = "<option value=\"\"> </option>";
            try
            {
                 con = getConexao();
                string sql = "select nome_pais, cod_pais from pais  " +
                  " order by nome_pais ";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_pais = dr["cod_pais"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();

                    string conteudo = "<option value=\"" + cod_pais + "\">" + nome_pais + "</option>";

                    dados = dados + conteudo;

                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }


        public bool excluindoDados(string codigo)
        {
            SqlConnection con = null;
            bool bExcluiu = true;
            try
            {
                 con = getConexao();
                string sql = "delete from linha where cod_linha = @codigo ";

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
            SqlConnection con = null;
            string codigo = "0";
            try
            {
                 con = getConexao();
                string sql = "select max(cod_linha) + 1 as qtde from linha";
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

        public string verificaExiste(string nomePor, string tipoArvore, string codPais)
        {
            SqlConnection con = null;
            string codigo = "0";
            try
            {
                 con = getConexao();
                 string sql = "select cod_linha from linha where nome_linha_por = '" + nomePor + "' and tipo_arvore = '" + tipoArvore + "'";
                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    codigo = dr["cod_linha"].ToString();
                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }


            return codigo;
        }


        public string carregaTotal(string tipoArvore, string idioma, string codPais)
        {
            SqlConnection con = null;
            string dados = "";
            string qtde = "1";
            string virgula = "";
            try
            {

               

                con = getConexao();
                string sql = "select count(a.cod_linha) as qtde from linha a where  (a.cod_pais = " + codPais + " or a.cod_pais is null) and a.tipo_arvore = '" + tipoArvore + "'";

                //sql = sql + " order by a.cod_linha OFFSET " + pagina + " ROWS FETCH NEXT " + limit + " ROWS ONLY ";
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

            //dados = total + ",[" + dados + "]";

            return qtde;
        }


        public string carregandoDados(string tipoArvore, string idioma, string limit, string offset, string total,
            string codPais)
        {
            SqlConnection con = null;
            string dados = "";
            string virgula = "";
            if(codPais != "2")
            {
                codPais = "1";
            }
            try
            {

                int pagina = Int16.Parse(offset) - 1;
                /*if (pagina > 0)
                {
                    pagina = pagina * Int16.Parse(limit);
                }*/

                pagina = pagina + 1;


                 con = getConexao();
             
               string sql = " SELECT * FROM ( "+
            " SELECT ROW_NUMBER() OVER(ORDER BY cod_linha) AS NUMBER, "+
             "       linha.cod_linha, linha.nome_linha_por , linha.nome_linha_ing,linha.nome_linha_esp, pais.nome_pais " +
              "       FROM linha   left join pais on pais.cod_pais = linha.cod_pais  where (linha.cod_pais = " + codPais + " or linha.cod_pais is null) and linha.tipo_arvore = '" + tipoArvore + "' " +
              " ) AS TBL "+
                    "WHERE NUMBER BETWEEN ((" + pagina + " - 1) * " + limit + " + 1) AND (" + pagina + " * " + limit + ") " +
                    "ORDER BY cod_linha ";



                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    string cod_linha = dr["cod_linha"].ToString();
                    
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_linha_esp = dr["nome_linha_esp"].ToString();

                    string alterar = "<img src='../includes/imagens/edit.png'  style='cursor:pointer; vertical-align:top;' onclick=alterarRegistro('" + cod_linha + "')  >";
                    string excluir = "<img src='../includes/imagens/remove.png'  style='cursor:pointer; vertical-align:top;' onclick=excluirRegistro('" + cod_linha + "')  >";

                    if (nome_pais == null)
                    {
                        nome_pais = "";
                    }

                    if (nome_pais.Equals(""))
                    {
                        nome_pais = "Todos";
                    }

                    string conteudo = "{nome_por:\"" + nome_linha_por + "\", pais:\"" + nome_pais + "\", nome_ing:\"" + nome_linha_ing + "\", nome_esp:\"" + nome_linha_esp + "\", cod_linha:\"" + cod_linha + "\", alterar:\"" + alterar + "\", excluir:\"" + excluir + "\"}";

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

                    dados = "{nome_por:\"" + nomepor + "\", nome_ing:\"" + nomeing + "\", nome_esp:\"" + nomeesp + "\", cod_linha:\"\", alterar:\"\", excluir:\"\"}";

                }

             
            }
            catch (Exception e) { dados = e.ToString(); }
            finally { con.Close(); }
           // dados = "[" + dados + "]";

            dados = total + ",[" + dados + "]";

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


        public string carregaLinha(string codigo)
        {
            string dados = "";
            SqlConnection con = null;
            try
            {
                 con = getConexao();

                 string sql = "select a.cod_linha, a.cod_pais, b.nome_pais, a.nome_linha_por , a.nome_linha_ing, a.nome_linha_esp from linha a  left join pais b on b.cod_pais = a.cod_pais  " +
               "  where a.cod_linha = " + codigo;

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                if (dr.Read())
                {
                    string nome_linha_por = dr["nome_linha_por"].ToString();
                    string nome_pais = dr["nome_pais"].ToString();
                    string cod_pais = dr["cod_pais"].ToString();
                
                    string nome_linha_ing = dr["nome_linha_ing"].ToString();
                    string nome_linha_esp = dr["nome_linha_esp"].ToString();

                    if (cod_pais == null) cod_pais = "0";


                    dados = nome_linha_por + ";" + nome_linha_ing + ";" + nome_linha_esp + ";" + cod_pais;


                }

               
            }
            catch (Exception e) { }
            finally { con.Close(); }

            return dados;
        }



        public string carregandoComboLinha()
        {
            string dados = "<option value=\"0\">  </option>";
            SqlConnection con = null;
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

        public string alterandoDados(string codigo, string nomePor, string nomeEsp, string nomeIng, string codPais, string tipoArvore)
        {
            string result = "";
            SqlConnection con = null;
            codPais = "0";
            try
            {
                 con = getConexao();

                 if (codPais.Equals("0"))
                 {
                     string sql = "update linha set nome_linha_por = @nomePor , nome_linha_esp = @nomeEsp " +
                    " , nome_linha_ing = @nomeIng, cod_pais = null where cod_linha = @codigo ";

                     SqlCommand comando = new SqlCommand(sql, con);
                     comando.Parameters.AddWithValue("@nomePor", nomePor);
                     comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                     comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                     comando.Parameters.AddWithValue("@codigo", codigo);


                     con.Open();
                     comando.ExecuteNonQuery();
                 }
                 else
                 {
                     string sql = "update linha set nome_linha_por = @nomePor , nome_linha_esp = @nomeEsp " +
                    " , nome_linha_ing = @nomeIng ,cod_pais = @codPais where cod_linha = @codigo ";

                     SqlCommand comando = new SqlCommand(sql, con);
                     comando.Parameters.AddWithValue("@nomePor", nomePor);
                     comando.Parameters.AddWithValue("@nomeEsp", nomeEsp);
                     comando.Parameters.AddWithValue("@nomeIng", nomeIng);
                     comando.Parameters.AddWithValue("@codPais", codPais);
                     comando.Parameters.AddWithValue("@codigo", codigo);


                     con.Open();
                     comando.ExecuteNonQuery();
                 }

                
                
            }
            catch (Exception e) { result = e.Message; }
            finally { con.Close(); }
            return result;
        }

    }
}
