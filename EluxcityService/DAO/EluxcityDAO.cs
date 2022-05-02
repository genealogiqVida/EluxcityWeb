using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EluxcityWeb.BD;
using System.Data.SqlClient;
using EluxcityWeb.DTO;
using System.Collections;

namespace EluxcityWeb.DAO
{
    public class EluxcityDAO : Conexao
    {

        public List<ConteudoDTO> carregandoLancamento(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type "+
                          "FROM content a "+
                          "inner join content_group b on b.id_content = a.id "+
                          "inner join user_group c on c.id_group = b.id_group "+
                          "where c.id_user = '" + username + "' " +
                          "order by updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) {  }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoCirculares(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT  a.id, a.name, a.created_by, a.url_video, a.type " +
                          "FROM content a " +
                          "inner join content_group b on b.id_content = a.id " +
                          "inner join user_group c on c.id_group = b.id_group " +
                          "where c.id_user = '" + username + "' and a.name_folder like 'Circular%' " +
                          "order by updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoBoletins(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type " +
                          "FROM content a " +
                          "inner join content_group b on b.id_content = a.id " +
                          "inner join user_group c on c.id_group = b.id_group " +
                          "where c.id_user = '" + username + "' and type = 'boletim' " +
                          "order by updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }

        public List<ConteudoDTO> carregandoManuais(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT  a.id, a.name, a.created_by, a.url_video, a.type " +
                          "FROM content a " +
                          "inner join content_group b on b.id_content = a.id " +
                          "inner join user_group c on c.id_group = b.id_group " +
                          "where c.id_user = '" + username + "' and type = 'manual' " +
                          "order by updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoManualServico(string tipo , string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
             

                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder " +
                          "FROM content a " +
                          "inner join content_group b on b.id_content = a.id " +
                          "inner join user_group c on c.id_group = b.id_group " +
                          "where c.id_user = '" + username + "' and a.name_folder like '%"+tipo+"%' and a.type = 'manual' " +
                          "order by a.updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoVideoServico(string tipo, string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
             
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder " +
                         "FROM content a " +
                         "inner join content_group b on b.id_content = a.id " +
                         "inner join user_group c on c.id_group = b.id_group " +
                         "where c.id_user = '" + username + "' and a.type = 'video' "+
                " and canal_video like '"+tipo+"%' " +
                         "order by a.updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoBoletimServico(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
            

                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder " +
                      "FROM content a " +
                      "inner join content_group b on b.id_content = a.id " +
                      "inner join user_group c on c.id_group = b.id_group " +
                      "where c.id_user = '" + username + "' and a.name_folder is not null and a.name_folder like 'Boleti%' and a.type in ('outros', 'boletim') " +
                      "order by a.updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoPopular(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type " +
                          "FROM content a " +
                          "inner join content_group b on b.id_content = a.id " +
                          "inner join user_group c on c.id_group = b.id_group " +
                          "where c.id_user = '" + username + "'  and a.type = 'video' " +
                          "order by a.view_count desc ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoProvasPraVoce(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " select  id, title, url_imagem, owner, update_on from courses where is_test = 1 order by update_on desc ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["title"].ToString());
                    dto.setUrlImagem(dr["url_imagem"].ToString());
                    dto.setProprietario(dr["owner"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoTreinamento(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " select  a.id_training, a.name_training, a.created_by from user_training a where id_usuario = '" + username + "' ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id_training"].ToString());
                    dto.setTitulo(dr["name_training"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }

        public List<ConteudoDTO> carregandoTreinamentoEquipeTecnica(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();
            if (username.Equals("")) username = "0";
            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " select  a.id_training, a.name_training, a.created_by from user_training a where id_usuario in (" + username + ") ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id_training"].ToString());
                    dto.setTitulo(dr["name_training"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }

        public List<ConteudoDTO> carregandoTreinamentoEquipeAdministrativa(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();
            if (username.Equals("")) username = "0";
            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " select  a.id_training, a.name_training, a.created_by from user_training a where id_usuario in (" + username + ") ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id_training"].ToString());
                    dto.setTitulo(dr["name_training"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }

        public List<ConteudoDTO> carregandoHabilidade(string username, string habilidade)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                if (habilidade.Equals("1"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  "+
                    "  inner join category_course b on b.id_course = a.id  "+
                       " where a.is_test = 0 and b.category like '%Adegas%'  "+
            " union select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on  " +
                  " from courses a  "+
                 " inner join category_course b on b.id_course = a.id  "+
                 "   where a.is_test = 0 and b.category like '%Cervejeiras%'  "+
            " union select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on  " +
                 "  from courses a  "+
                 " inner join category_course b on b.id_course = a.id  "+
                  "  where a.is_test = 0 and b.category like '%Freezers%'  "+
                  "  order by a.update_on desc ";
                }
                else if (habilidade.Equals("2"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Ar Condicionado%'  " +
                      " order by a.update_on desc ";
                }

                else if (habilidade.Equals("3"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Aspirador%'  " +
                      " order by a.update_on desc ";
                }

                else if (habilidade.Equals("4"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Conectados%'  " +
                      " order by a.update_on desc ";
                }

                else if (habilidade.Equals("5"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Eletroportáteis%'  " +
                      " order by a.update_on desc ";
                }
                else if (habilidade.Equals("6"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Fogões%'  " +
            " union select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on  " +
                  " from courses a  " +
                 " inner join category_course b on b.id_course = a.id  " +
                 "   where a.is_test = 0 and b.category like '%Fornos%'  " +
                 "  order by a.update_on desc ";
                }

                else if (habilidade.Equals("7"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Lavadora%'  " +
            " union select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on  " +
                  " from courses a  " +
                 " inner join category_course b on b.id_course = a.id  " +
                 "   where a.is_test = 0 and b.category like '%Secadora%'  " +
                 "  order by a.update_on desc ";
                }
                else if (habilidade.Equals("8"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Lavadora alta pressão%'  " +
                 "  order by a.update_on desc ";
                }

                else if (habilidade.Equals("9"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Lava-louças%'  " +

                          " union select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on  " +
                  " from courses a  " +
                 " inner join category_course b on b.id_course = a.id  " +
                 "   where a.is_test = 0 and b.category like '%Lava louças%'  " +

                 "  order by a.update_on desc ";
                }

                else if (habilidade.Equals("10"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Micro-ondas%'  " +
                 "  order by a.update_on desc ";
                }

                else if (habilidade.Equals("11"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Purificador%'  " +
            " union select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on  " +
                  " from courses a  " +
                 " inner join category_course b on b.id_course = a.id  " +
                 "   where a.is_test = 0 and b.category like '%Bebedouro%'  " +
                 "  order by a.update_on desc ";
                }

                else if (habilidade.Equals("12"))
                {
                    sql = " select distinct a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                     "  from courses a  " +
                    "  inner join category_course b on b.id_course = a.id  " +
                       " where a.is_test = 0 and b.category like '%Refrigeração%'  " +
                 "  order by a.update_on desc ";
                }

                else
                {
                    sql = " select top 35 a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                 " from courses a " +
                 " inner join category_course b on b.id_course = a.id " +
                 "  where a.is_test = 0 and b.category = '" + habilidade + "' order by a.update_on desc; ";

                }

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["title"].ToString());
                    dto.setUrlImagem(dr["url_imagem"].ToString());
                    dto.setProprietario(dr["owner"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public List<ConteudoDTO> carregandoSugestao(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " select  a.id, a.title, a.url_imagem, a.owner, a.update_on " +
                   " from courses a " +
                   " inner join category_course b on b.id_course = a.id " +
                   "  where a.is_test = 0 and b.category = 'Sugestão para você' order by a.update_on desc; ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["title"].ToString());
                    dto.setUrlImagem(dr["url_imagem"].ToString());
                    dto.setProprietario(dr["owner"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }

        public List<ConteudoDTO> carregandoRecente(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
             
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type " +
                        "FROM content a " +
                        "inner join content_group b on b.id_content = a.id " +
                        "inner join user_group c on c.id_group = b.id_group " +
                        "where c.id_user = '" + username + "' and type = 'video' " +
                        "order by updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            return list;
        }


        public string verificandoPerfil(string cargo)
        {
            SqlConnection con = null;
            string codigo = "";
            try
            {
                string sql = "";
                con = getConexao();
                sql = "select name_audiencetype as codigo from jobs_audienceType where job_title = '" + cargo + "'";


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

    }
}
