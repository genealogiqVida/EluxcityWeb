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
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type, a.canal_video, a.name_folder, a.updated_on "+
                          "FROM content a "+
                          "inner join content_group b on b.id_content = a.id "+
                          "inner join user_group c on c.id_group = b.id_group "+
                          "where c.id_user = '" + username + "' and a.type not in('outros')" +
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
                    dto.setNameFolder(dr["name_folder"].ToString().ToUpper());
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    if (dr["type"].ToString() == "video")
                    {
                        if (dr["canal_video"].ToString() != "" && dr["canal_video"].ToString() != null)
                        {
                            if (dr["canal_video"].ToString().Contains("Ar condicionado"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                            }
                            else if (dr["canal_video"].ToString().Contains("Coifas e Depuradores"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Coifas.png");
                            }
                            else if (dr["canal_video"].ToString().Contains("Condicionadores de Ar"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                            }
                            else if (dr["canal_video"].ToString().Contains("Eletroportáteis"))
                            {
                                if (dto.getTitulo().Contains("Cafeteira"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Cafeteira.png");
                                }
                                else if (dto.getTitulo().Contains("Aspirador"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                                }
                                else if (dto.getTitulo().Contains("Liquidificador"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Liquidificador.png");
                                }
                                else if (dto.getTitulo().Contains("Panela"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Panela.png");
                                }
                                else if (dto.getTitulo().Contains("Ferro"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Ferro.png");
                                }
                                else if (dto.getTitulo().Contains("aspirador de pó"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                                }
                                else
                                {
                                    dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                                }
                            }
                            else if (dr["canal_video"].ToString().Contains("Fogões"))
                            {
                                if (dto.getTitulo().Contains("Fogão"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                                }
                                else if (dto.getTitulo().Contains("Cooktop"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Cooktop.png");
                                }
                                else if (dto.getTitulo().Contains("Forno"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                                }
                                else
                                {
                                    dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                                }
                            }
                            else if (dr["canal_video"].ToString().Contains("Fornos de Embutir"))
                            {
                                if (dto.getTitulo().Contains("Micro-ondas"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                                }
                                else
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                                }
                            }
                            else if (dr["canal_video"].ToString().Contains("Lava Louças"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                            }
                            else if (dr["canal_video"].ToString().Contains("Máquinas de lavar"))
                            {
                                if (dto.getTitulo().Contains("Caneta") || dto.getTitulo().Contains("Lavadora"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                                }
                                else if (dto.getTitulo().Contains("Secadora"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                                }
                                else if (dto.getTitulo().Contains("Lava Seca") || dto.getTitulo().Contains("Lava e Seca"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Lavaseca.png");
                                }
                                else if (dto.getTitulo().Contains("louça"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                                }
                                else if (dto.getTitulo().Contains("Alta pressão"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Altapressão.png");
                                }
                                else
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                                }
                            }
                            else if (dr["canal_video"].ToString().Contains("Micro-ondas"))
                            {
                                if (dto.getTitulo().Contains("fogao"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                                }
                                else
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                                }
                            }
                            else if (dr["canal_video"].ToString().Contains("Purificadores e Bebedouros"))
                            {
                                if (dto.getTitulo().Contains("Bebedouro"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Bebedouro.png");
                                }
                                else if (dto.getTitulo().Contains("Purificador"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                                }
                                else if (dto.getTitulo().Contains("ar"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                                }
                                else
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                                }
                            }
                            else if (dr["canal_video"].ToString().Contains("Refrigeradores"))
                            {
                                if (dto.getTitulo().Contains("Adega"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_adega.png");
                                }
                                else if (dto.getTitulo().Contains("Refrigerador"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                                }
                                else if (dto.getTitulo().Contains("Cervejeira"))
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Cervejeira.png");
                                }
                                else
                                {
                                    dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                                }
                            }
                            else if (dr["canal_video"].ToString().Contains("Secadoras"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                            }
                        }
                    }else if(dr["type"].ToString() == "manual")
                    {
                        if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                        {
                            if (dto.getNameFolder().Contains("ADEGA"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_adega.png");
                            }
                            else if (dto.getNameFolder().Contains("REFRIGERADO"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Geladeira.png");
                            }
                            else if (dto.getNameFolder().Contains("PREPARAÇÃO DE ALIMENTOS"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_AirFryer.png");
                            }
                            else if (dto.getNameFolder().Contains("ALTA PRESSÃO"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Altapressão.png");
                            }
                            else if (dto.getNameFolder().Contains("ASPIRADOR"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Aspirador.png");
                            }
                            else if (dto.getNameFolder().Contains("BEBEDOURO"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Bebedouro.png");
                            }
                            else if (dto.getNameFolder().Contains("BEBIDAS QUENTES"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Cafeteira.png");
                            }
                            else if (dto.getNameFolder().Contains("CERVEJEIRA"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Cervejeira.png");
                            }
                            else if (dto.getNameFolder().Contains("COIFAS"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Coifas.png");
                            }
                            else if (dto.getNameFolder().Contains("CONDICIONADO"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_condicionador.png");
                            }
                            else if (dto.getNameFolder().Contains("COOKTOP"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_cooktop.png");
                            }
                            else if (dto.getNameFolder().Contains("DEPURADOR"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_depurador.png");
                            }
                            else if (dto.getNameFolder().Contains("FOGÕES"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Fogao.png");
                            }
                            else if (dto.getNameFolder().Contains("FORNO"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Forno.png");
                            }
                            else if (dto.getNameFolder().Contains("FRIGOBAR"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Frigobar.png");
                            }
                            else if (dto.getNameFolder().Contains("LAVA E SECA"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Lavaseca.png");
                            }
                            else if (dto.getNameFolder().Contains("LIQUIDIFICADOR"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Liquidificador.png");
                            }
                            else if (dto.getNameFolder().Contains("LAVADORA"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Lavadora.png");
                            }
                            else if (dto.getNameFolder().Contains("LAVA-LOUÇAS"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_loucas.png");
                            }
                            else if (dto.getNameFolder().Contains("MICRO-ONDAS"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_micro.png");
                            }
                            else if (dto.getNameFolder().Contains("MIXER"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Mixer.png");
                            }
                            else if (dto.getNameFolder().Contains("COZIMENTO ELÉTRICO"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Panela.png");
                            }
                            else if (dto.getNameFolder().Contains("PURIFICADOR"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Purificador.png");
                            }
                            else if (dto.getNameFolder().Contains("PROCESSADOR DE ALIMENTOS"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Processador.png");
                            }
                            else if (dto.getNameFolder().Contains("SECADORA"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_secadora.png");
                            }
                            else if (dto.getNameFolder().Contains("TORRADEIRA"))
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual_Torradeira.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/manuais/Manual.png");
                            }
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual.png");
                        }
                    }else if(dr["type"].ToString() == "boletim")
                    {
                        if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                        {
                            if (dto.getNameFolder().Contains("REFRIGERADO"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Geladeira.png");
                            }
                            else if (dto.getNameFolder().Contains("ADEGA"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_adega.jpg");
                            }
                            else if (dto.getNameFolder().Contains("PREPARAÇÃO DE ALIMENTOS"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_AirFryer.png");
                            }
                            else if (dto.getNameFolder().Contains("ALTA PRESSÃO"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Altapressao.png");
                            }
                            else if (dto.getNameFolder().Contains("ASPIRADOR"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Aspirador.png");
                            }
                            else if (dto.getNameFolder().Contains("BEBEDOURO"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Bebedouro.png");
                            }
                            else if (dto.getNameFolder().Contains("BEBIDAS QUENTES"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Cafeteira.png");
                            }
                            else if (dto.getNameFolder().Contains("CERVEJEIRA"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Cervejeira.png");
                            }
                            else if (dto.getNameFolder().Contains("COIFAS"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Coifas.png");
                            }
                            else if (dto.getNameFolder().Contains("CONDICIONADO"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_condicionador.png");
                            }
                            else if (dto.getNameFolder().Contains("COOKTOP"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_cooktop.png");
                            }
                            else if (dto.getNameFolder().Contains("DEPURADOR"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_depurador.png");
                            }
                            else if (dto.getNameFolder().Contains("FOGÕES"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Fogao.png");
                            }
                            else if (dto.getNameFolder().Contains("FORNO"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Forno.png");
                            }
                            else if (dto.getNameFolder().Contains("FRIGOBAR"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Frigobar.png");
                            }
                            else if (dto.getNameFolder().Contains("LAVA E SECA"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_lavaseca.png");
                            }
                            else if (dto.getNameFolder().Contains("LAVADORA"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Lavadora.png");
                            }
                            else if (dto.getNameFolder().Contains("LAVA-LOUÇAS"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_loucas.png");
                            }
                            else if (dto.getNameFolder().Contains("MICRO-ONDAS"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_micro.png");
                            }
                            else if (dto.getNameFolder().Contains("COZIMENTO ELÉTRICO"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Panela.png");
                            }
                            else if (dto.getNameFolder().Contains("PURIFICADOR"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Purificador.png");
                            }
                            else if (dto.getNameFolder().Contains("SECADORA"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_secadora.png");
                            }
                            else if (dto.getNameFolder().Contains("TORRADEIRA"))
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT_Torradeira.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/boletins/BT.png");
                            }
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT.png");
                        }
                    }else if(dr["type"].ToString() == "circular")
                    {
                        if (dto.getNameFolder() != null && dto.getNameFolder() != "")
                        {
                            if (dto.getNameFolder().Contains("2005"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2005.png");
                            }
                            else if (dto.getNameFolder().Contains("2006"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2006.png");
                            }
                            else if (dto.getNameFolder().Contains("2007"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2007.png");
                            }
                            else if (dto.getNameFolder().Contains("2008"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2008.png");
                            }
                            else if (dto.getNameFolder().Contains("2009"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2009.png");
                            }
                            else if (dto.getNameFolder().Contains("2010"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2010.png");
                            }
                            else if (dto.getNameFolder().Contains("2011"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2011.png");
                            }
                            else if (dto.getNameFolder().Contains("2012"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2012.png");
                            }
                            else if (dto.getNameFolder().Contains("2013"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2013.png");
                            }
                            else if (dto.getNameFolder().Contains("2014"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2014.png");
                            }
                            else if (dto.getNameFolder().Contains("2015"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2015.png");
                            }
                            else if (dto.getNameFolder().Contains("2016"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2016.png");
                            }
                            else if (dto.getNameFolder().Contains("2017"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2017.png");
                            }
                            else if (dto.getNameFolder().Contains("2018"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2018.png");
                            }
                            else if (dto.getNameFolder().Contains("2019"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2019.png");
                            }
                            else if (dto.getNameFolder().Contains("2020"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2020.png");
                            }
                            else if (dto.getNameFolder().Contains("2021"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2021.png");
                            }
                            else if (dto.getNameFolder().Contains("2022"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2022.png");
                            }
                            else if (dto.getNameFolder().Contains("2023"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2023.png");
                            }
                            else if (dto.getNameFolder().Contains("2024"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2024.png");
                            }
                            else if (dto.getNameFolder().Contains("2025"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2025.png");
                            }
                            else if (dto.getNameFolder().Contains("2026"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2026.png");
                            }
                            else if (dto.getNameFolder().Contains("2027"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2027.png");
                            }
                            else if (dto.getNameFolder().Contains("2028"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2028.png");
                            }
                            else if (dto.getNameFolder().Contains("2029"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2029.png");
                            }
                            else if (dto.getNameFolder().Contains("2030"))
                            {
                                dto.setUrlImagem("../includes/images/circulares/2030.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/circulares/0.png");
                            }
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/circulares/0.png");
                        }
                    }
                    list.Add(dto);
                }


            }
            catch (Exception e) {  }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

            return list;
        }

        public List<ConteudoOrdenadoAnoDTO> carregandoCircularesOrdenadoAno(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            List<ConteudoOrdenadoAnoDTO> listOrdenadaAno = new List<ConteudoOrdenadoAnoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT  a.id, a.name, a.created_by, a.url_video, a.type, a.name_folder, a.updated_on " +
                          "FROM content a " +
                          "inner join content_group b on b.id_content = a.id " +
                          "inner join user_group c on c.id_group = b.id_group " +
                          "where c.id_user = '" + username + "' and a.name_folder like 'Circular%' " +
                          "order by updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                var encontrou = false;
                List<ConteudoDTO> novaLista = new List<ConteudoDTO>();
                ConteudoOrdenadoAnoDTO novoConteudo = new ConteudoOrdenadoAnoDTO();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    dto.setNameFolder(dr["name_folder"].ToString());
                    string updatedOn = dr["updated_on"].ToString();
                    DateTime dateTime = Convert.ToDateTime(updatedOn);
                    dto.setUpdated_On(dateTime);

                    if (dto.getNameFolder() != null && dto.getNameFolder() != "")
                    {
                        if (dto.getNameFolder().Contains("2005"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2005.png");
                            encontrou = false;
                            for(var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2005"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2005");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2006"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2006.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2006"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2006");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2007"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2007.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2007"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2007");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2008"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2008.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2008"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2008");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2009"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2009.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2009"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2009");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2010"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2010.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2010"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2010");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2011"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2011.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2011"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2011");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2012"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2012.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2012"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2012");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2013"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2013.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2013"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2013");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2014"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2014.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2014"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2014");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2015"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2015.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2015"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2015");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2016"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2016.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2016"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2016");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2017"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2017.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2017"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2017");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2018"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2018.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2018"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2018");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2019"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2019.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2019"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2019");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2020"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2020.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2020"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2020");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2021"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2021.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2021"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2021");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2022"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2022.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2022"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2022");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2023"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2023.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2023"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2023");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2024"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2024.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2024"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2024");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2025"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2025.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2025"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2025");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2026"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2026.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2026"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2026");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2027"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2027.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2027"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2027");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2028"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2028.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2028"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2028");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2029"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2029.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2029"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2029");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else if (dto.getNameFolder().Contains("2030"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2030.png");
                            encontrou = false;
                            for (var i = 0; i < listOrdenadaAno.Count; i++)
                            {
                                ConteudoOrdenadoAnoDTO conteudo = listOrdenadaAno[i];
                                if (conteudo.getAno().Contains("2030"))
                                {
                                    encontrou = true;
                                    listOrdenadaAno[i].getConteudos().Add(dto);
                                    break;
                                }
                            }
                            if (!encontrou)
                            {
                                novoConteudo = new ConteudoOrdenadoAnoDTO();
                                novoConteudo.setAno("2030");

                                novaLista = new List<ConteudoDTO>();
                                novaLista.Add(dto);
                                novoConteudo.setConteudos(novaLista);

                                listOrdenadaAno.Add(novoConteudo);
                            }
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/circulares/0.png");
                        }
                    }
                    else
                    {
                        dto.setUrlImagem("../includes/images/circulares/0.png");
                    }
                }
            }
            catch (Exception e) { }

            finally { con.Close(); }

            listOrdenadaAno = listOrdenadaAno.OrderByDescending(o => o.getAno()).ToList();

            return listOrdenadaAno;
        }

        public List<ConteudoDTO> carregandoCirculares(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT  a.id, a.name, a.created_by, a.url_video, a.type, a.name_folder, a.updated_on " +
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
                    dto.setNameFolder(dr["name_folder"].ToString());
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    if (dto.getNameFolder() != null && dto.getNameFolder() != "")
                    {
                        if (dto.getNameFolder().Contains("2005"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2005.png");
                        }
                        else if (dto.getNameFolder().Contains("2006"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2006.png");
                        }
                        else if (dto.getNameFolder().Contains("2007"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2007.png");
                        }
                        else if (dto.getNameFolder().Contains("2008"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2008.png");
                        }
                        else if (dto.getNameFolder().Contains("2009"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2009.png");
                        }
                        else if (dto.getNameFolder().Contains("2010"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2010.png");
                        }
                        else if (dto.getNameFolder().Contains("2011"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2011.png");
                        }
                        else if (dto.getNameFolder().Contains("2012"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2012.png");
                        }
                        else if (dto.getNameFolder().Contains("2013"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2013.png");
                        }
                        else if (dto.getNameFolder().Contains("2014"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2014.png");
                        }
                        else if (dto.getNameFolder().Contains("2015"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2015.png");
                        }
                        else if (dto.getNameFolder().Contains("2016"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2016.png");
                        }
                        else if (dto.getNameFolder().Contains("2017"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2017.png");
                        }
                        else if (dto.getNameFolder().Contains("2018"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2018.png");
                        }
                        else if (dto.getNameFolder().Contains("2019"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2019.png");
                        }
                        else if (dto.getNameFolder().Contains("2020"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2020.png");
                        }
                        else if (dto.getNameFolder().Contains("2021"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2021.png");
                        }
                        else if (dto.getNameFolder().Contains("2022"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2022.png");
                        }
                        else if (dto.getNameFolder().Contains("2023"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2023.png");
                        }
                        else if (dto.getNameFolder().Contains("2024"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2024.png");
                        }
                        else if (dto.getNameFolder().Contains("2025"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2025.png");
                        }
                        else if (dto.getNameFolder().Contains("2026"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2026.png");
                        }
                        else if (dto.getNameFolder().Contains("2027"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2027.png");
                        }
                        else if (dto.getNameFolder().Contains("2028"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2028.png");
                        }
                        else if (dto.getNameFolder().Contains("2029"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2029.png");
                        }
                        else if (dto.getNameFolder().Contains("2030"))
                        {
                            dto.setUrlImagem("../includes/images/circulares/2030.png");
                        }else
                        {
                            dto.setUrlImagem("../includes/images/circulares/0.png");
                        }
                    }else
                    {
                        dto.setUrlImagem("../includes/images/circulares/0.png");
                    }

                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

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
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type, a.name_folder, a.updated_on " +
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
                    dto.setNameFolder(dr["name_folder"].ToString().ToUpper());
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                    {
                        if (dto.getNameFolder().Contains("REFRIGERADO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Geladeira.png");
                        }
                        else if (dto.getNameFolder().Contains("ADEGA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_adega.jpg");
                        }
                        else if (dto.getNameFolder().Contains("PREPARAÇÃO DE ALIMENTOS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_AirFryer.png");
                        }
                        else if (dto.getNameFolder().Contains("ALTA PRESSÃO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Altapressao.png");
                        }
                        else if (dto.getNameFolder().Contains("ASPIRADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Aspirador.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBEDOURO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Bebedouro.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBIDAS QUENTES"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Cafeteira.png");
                        }
                        else if (dto.getNameFolder().Contains("CERVEJEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Cervejeira.png");
                        }
                        else if (dto.getNameFolder().Contains("COIFAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Coifas.png");
                        }
                        else if (dto.getNameFolder().Contains("CONDICIONADO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("COOKTOP"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_cooktop.png");
                        }
                        else if (dto.getNameFolder().Contains("DEPURADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_depurador.png");
                        }
                        else if (dto.getNameFolder().Contains("FOGÕES"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Fogao.png");
                        }
                        else if (dto.getNameFolder().Contains("FORNO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Forno.png");
                        }
                        else if (dto.getNameFolder().Contains("FRIGOBAR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Frigobar.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA E SECA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_lavaseca.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVADORA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Lavadora.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA-LOUÇAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_loucas.png");
                        }
                        else if (dto.getNameFolder().Contains("MICRO-ONDAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_micro.png");
                        }
                        else if (dto.getNameFolder().Contains("COZIMENTO ELÉTRICO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Panela.png");
                        }
                        else if (dto.getNameFolder().Contains("PURIFICADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Purificador.png");
                        }
                        else if (dto.getNameFolder().Contains("SECADORA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_secadora.png");
                        }
                        else if (dto.getNameFolder().Contains("TORRADEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Torradeira.png");
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT.png");
                        }
                    }
                    else
                    {
                        dto.setUrlImagem("../includes/images/boletins/BT.png");
                    }

                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

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
                sql = " SELECT  a.id, a.name, a.created_by, a.url_video, a.type, a.name_folder, a.updated_on " +
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
                    dto.setNameFolder(dr["name_folder"].ToString().ToUpper());
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                    {
                        if (dto.getNameFolder().Contains("ADEGA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_adega.png");
                        }
                        else if (dto.getNameFolder().Contains("REFRIGERADO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Geladeira.png");
                        }
                        else if (dto.getNameFolder().Contains("PREPARAÇÃO DE ALIMENTOS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_AirFryer.png");
                        }
                        else if (dto.getNameFolder().Contains("ALTA PRESSÃO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Altapressão.png");
                        }
                        else if (dto.getNameFolder().Contains("ASPIRADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Aspirador.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBEDOURO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Bebedouro.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBIDAS QUENTES"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Cafeteira.png");
                        }
                        else if (dto.getNameFolder().Contains("CERVEJEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Cervejeira.png");
                        }
                        else if (dto.getNameFolder().Contains("COIFAS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Coifas.png");
                        }
                        else if (dto.getNameFolder().Contains("CONDICIONADO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("COOKTOP"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_cooktop.png");
                        }
                        else if (dto.getNameFolder().Contains("DEPURADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_depurador.png");
                        }
                        else if (dto.getNameFolder().Contains("FOGÕES"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Fogao.png");
                        }
                        else if (dto.getNameFolder().Contains("FORNO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Forno.png");
                        }
                        else if (dto.getNameFolder().Contains("FRIGOBAR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Frigobar.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA E SECA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Lavaseca.png");
                        }
                        else if (dto.getNameFolder().Contains("LIQUIDIFICADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Liquidificador.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVADORA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Lavadora.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA-LOUÇAS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_loucas.png");
                        }
                        else if (dto.getNameFolder().Contains("MICRO-ONDAS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_micro.png");
                        }
                        else if (dto.getNameFolder().Contains("MIXER"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Mixer.png");
                        }
                        else if (dto.getNameFolder().Contains("COZIMENTO ELÉTRICO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Panela.png");
                        }
                        else if (dto.getNameFolder().Contains("PURIFICADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Purificador.png");
                        }
                        else if (dto.getNameFolder().Contains("PROCESSADOR DE ALIMENTOS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Processador.png");
                        }
                        else if (dto.getNameFolder().Contains("SECADORA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_secadora.png");
                        }
                        else if (dto.getNameFolder().Contains("TORRADEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Torradeira.png");
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual.png");
                        }
                    }
                    else
                    {
                        dto.setUrlImagem("../includes/images/manuais/Manual.png");
                    }

                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

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
             

                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder, a.updated_on " +
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
                    dto.setNameFolder(dr["name_folder"].ToString().ToUpper());
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                    {
                        if (dto.getNameFolder().Contains("ADEGA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_adega.png");
                        }
                        else if (dto.getNameFolder().Contains("REFRIGERADO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Geladeira.png");
                        }
                        else if (dto.getNameFolder().Contains("PREPARAÇÃO DE ALIMENTOS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_AirFryer.png");
                        }
                        else if (dto.getNameFolder().Contains("ALTA PRESSÃO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Altapressão.png");
                        }
                        else if (dto.getNameFolder().Contains("ASPIRADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Aspirador.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBEDOURO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Bebedouro.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBIDAS QUENTES"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Cafeteira.png");
                        }
                        else if (dto.getNameFolder().Contains("CERVEJEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Cervejeira.png");
                        }
                        else if (dto.getNameFolder().Contains("COIFAS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Coifas.png");
                        }
                        else if (dto.getNameFolder().Contains("CONDICIONADO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("COOKTOP"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_cooktop.png");
                        }
                        else if (dto.getNameFolder().Contains("DEPURADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_depurador.png");
                        }
                        else if (dto.getNameFolder().Contains("FOGÕES"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Fogao.png");
                        }
                        else if (dto.getNameFolder().Contains("FORNO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Forno.png");
                        }
                        else if (dto.getNameFolder().Contains("FRIGOBAR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Frigobar.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA E SECA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Lavaseca.png");
                        }
                        else if (dto.getNameFolder().Contains("LIQUIDIFICADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Liquidificador.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVADORA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Lavadora.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA-LOUÇAS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_loucas.png");
                        }
                        else if (dto.getNameFolder().Contains("MICRO-ONDAS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_micro.png");
                        }
                        else if (dto.getNameFolder().Contains("MIXER"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Mixer.png");
                        }
                        else if (dto.getNameFolder().Contains("COZIMENTO ELÉTRICO"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Panela.png");
                        }
                        else if (dto.getNameFolder().Contains("PURIFICADOR"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Purificador.png");
                        }
                        else if (dto.getNameFolder().Contains("PROCESSADOR DE ALIMENTOS"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Processador.png");
                        }
                        else if (dto.getNameFolder().Contains("SECADORA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_secadora.png");
                        }
                        else if (dto.getNameFolder().Contains("TORRADEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual_Torradeira.png");
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/manuais/Manual.png");
                        }
                    }
                    else
                    {
                        dto.setUrlImagem("../includes/images/manuais/Manual.png");
                    }

                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

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

                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder, a.canal_video, a.updated_on " +
                         "FROM content a " +
                         "inner join content_group b on b.id_content = a.id " +
                         "inner join user_group c on c.id_group = b.id_group " +
                         "where c.id_user = '" + username + "' and a.type = 'video' " +
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
                    dto.setNameFolder(dr["canal_video"].ToString());
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                    {
                        if (dto.getNameFolder().Contains("Ar condicionado"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("Coifas e Depuradores"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_Coifas.png");
                        }
                        else if (dto.getNameFolder().Contains("Condicionadores de Ar"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("Eletroportáteis"))
                        {
                            if (dto.getTitulo().Contains("Cafeteira"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cafeteira.png");
                            }
                            else if (dto.getTitulo().Contains("Aspirador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                            }
                            else if (dto.getTitulo().Contains("Liquidificador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Liquidificador.png");
                            }
                            else if (dto.getTitulo().Contains("Panela"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Panela.png");
                            }
                            else if (dto.getTitulo().Contains("Ferro"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Ferro.png");
                            }
                            else if (dto.getTitulo().Contains("aspirador de pó"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Fogões"))
                        {
                            if (dto.getTitulo().Contains("Fogão"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                            }
                            else if (dto.getTitulo().Contains("Cooktop"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cooktop.png");
                            }
                            else if (dto.getTitulo().Contains("Forno"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Fornos de Embutir"))
                        {
                            if (dto.getTitulo().Contains("Micro-ondas"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Lava Louças"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                        }
                        else if (dto.getNameFolder().Contains("Máquinas de lavar"))
                        {
                            if (dto.getTitulo().Contains("Caneta") || dto.getTitulo().Contains("Lavadora"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                            }
                            else if (dto.getTitulo().Contains("Secadora"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                            }
                            else if (dto.getTitulo().Contains("Lava Seca") || dto.getTitulo().Contains("Lava e Seca"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Lavaseca.png");
                            }
                            else if (dto.getTitulo().Contains("louça"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                            }
                            else if (dto.getTitulo().Contains("Alta pressão"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Altapressão.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Micro-ondas"))
                        {
                            if (dto.getTitulo().Contains("fogao"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Purificadores e Bebedouros"))
                        {
                            if (dto.getTitulo().Contains("Bebedouro"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Bebedouro.png");
                            }
                            else if (dto.getTitulo().Contains("Purificador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                            }
                            else if (dto.getTitulo().Contains("ar"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Refrigeradores"))
                        {
                            if (dto.getTitulo().Contains("Adega"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_adega.png");
                            }
                            else if (dto.getTitulo().Contains("Refrigerador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                            }
                            else if (dto.getTitulo().Contains("Cervejeira"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cervejeira.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Secadoras"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                        }
                    }

                    list.Add(dto);
                }
            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

            return list;
        }

        public List<ConteudoOrdenadoTipoProdutoDTO> carregandoBoletimServicoOrdenadoProduto(string username, string idioma)
        {
            if(idioma.Equals("") || idioma == null)
            {
                idioma = "pt-BR";
            }
            List<ConteudoDTO> list = new List<ConteudoDTO>();
            List<ConteudoOrdenadoTipoProdutoDTO> listOrdenadaProduto = new List<ConteudoOrdenadoTipoProdutoDTO>();
            ConteudoOrdenadoTipoProdutoDTO conteudoOrdenadoProdutoDTO = new ConteudoOrdenadoTipoProdutoDTO();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();

                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder, a.updated_on " +
                      "FROM content a " +
                      "inner join content_group b on b.id_content = a.id " +
                      "inner join user_group c on c.id_group = b.id_group " +
                      "where c.id_user = '" + username + "' and a.type in ('boletim') " +
                      "order by a.updated_on desc";

                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                string produtoCorrente = "";
                while (dr.Read())
                {
                    var count = dr.FieldCount;
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setNameFolder(dr["name_folder"].ToString().ToUpper());
                    dto.setProprietario(dr["created_by"].ToString());
                    string updatedOn = dr["updated_on"].ToString();
                    DateTime dateTime = Convert.ToDateTime(updatedOn);
                    dto.setUpdated_On(dateTime);

                    string tipoProduto = "";

                    if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                    {
                        if (dto.getNameFolder().Contains("REFRIGERADO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Geladeira.png");
                            if(idioma.Equals("en-US"))
                            {
                                tipoProduto = "Refrigerators";
                            }else
                            {
                                tipoProduto = "Refrigeradores";
                            }
                        }
                        else if (dto.getNameFolder().Contains("ADEGA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_adega.jpg");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Cellars";
                            }
                            else if(idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Bodegas";
                            }else
                            {
                                tipoProduto = "Adegas";
                            }
                        }
                        else if (dto.getNameFolder().Contains("PREPARAÇÃO DE ALIMENTOS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_AirFryer.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Food Preparation";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Preparación de comida";
                            }
                            else
                            {
                                tipoProduto = "Preparação de Alimentos";
                            }
                        }
                        else if (dto.getNameFolder().Contains("ALTA PRESSÃO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Altapressao.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "High pressure";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Alta presión";
                            }
                            else
                            {
                                tipoProduto = "Alta Pressão";
                            }
                        }
                        else if (dto.getNameFolder().Contains("ASPIRADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Aspirador.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Vacuum cleaners";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Aspiradoras";
                            }
                            else
                            {
                                tipoProduto = "Aspiradores";
                            }
                            
                        }
                        else if (dto.getNameFolder().Contains("BEBEDOURO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Bebedouro.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Drinking fountains";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Fuentes de agua potable";
                            }
                            else
                            {
                                tipoProduto = "Bebedouros";
                            }
                            
                        }
                        else if (dto.getNameFolder().Contains("BEBIDAS QUENTES"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Cafeteira.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Hot beverages";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Bebidas calientes";
                            }
                            else
                            {
                                tipoProduto = "Bebidas Quentes";
                            }
                            
                        }
                        else if (dto.getNameFolder().Contains("CERVEJEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Cervejeira.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Breweries";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Cervecerías";
                            }
                            else
                            {
                                tipoProduto = "Cervejeiras";
                            }
                            
                        }
                        else if (dto.getNameFolder().Contains("COIFAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Coifas.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Hoods";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Capuchas";
                            }
                            else
                            {
                                tipoProduto = "Coifas";
                            }
                            
                        }
                        else if (dto.getNameFolder().Contains("CONDICIONADO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_condicionador.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Conditioners";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Acondicionadores";
                            }
                            else
                            {
                                tipoProduto = "Condicionadores";
                            }
                            
                        }
                        else if (dto.getNameFolder().Contains("COOKTOP"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_cooktop.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Cooktops";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Cooktops";
                            }
                            else
                            {
                                tipoProduto = "Cooktops";
                            }
                        }
                        else if (dto.getNameFolder().Contains("DEPURADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_depurador.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Debuggers";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Depuradores";
                            }
                            else
                            {
                                tipoProduto = "Depuradores";
                            }
                        }
                        else if (dto.getNameFolder().Contains("FOGÕES"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Fogao.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Stoves";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Estufas";
                            }
                            else
                            {
                                tipoProduto = "Fogões";
                            }
                        }
                        else if (dto.getNameFolder().Contains("FORNO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Forno.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Ovens";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Hornos";
                            }
                            else
                            {
                                tipoProduto = "Fornos";
                            }
                        }
                        else if (dto.getNameFolder().Contains("FRIGOBAR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Frigobar.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Fridges";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Frigoríficos";
                            }
                            else
                            {
                                tipoProduto = "Frigobares";
                            }
                        }
                        else if (dto.getNameFolder().Contains("LAVA E SECA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_lavaseca.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Wash and dry";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Lavar y secar";
                            }
                            else
                            {
                                tipoProduto = "Lava e Seca";
                            }
                        }
                        else if (dto.getNameFolder().Contains("LAVADORA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Lavadora.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Washers";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Arandelas";
                            }
                            else
                            {
                                tipoProduto = "Lavadoras";
                            }
                        }
                        else if (dto.getNameFolder().Contains("LAVA-LOUÇAS") || dto.getNameFolder().Contains("LAVA-LOUÇA") || dto.getNameFolder().Contains("LAVA LOUÇA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_loucas.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Dishwasher";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Lava platos";
                            }
                            else
                            {
                                tipoProduto = "Lava-Louças";
                            }
                        }
                        else if (dto.getNameFolder().Contains("MICRO-ONDAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_micro.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Microwave";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Microonda";
                            }
                            else
                            {
                                tipoProduto = "Micro-Ondas";
                            }
                        }
                        else if (dto.getNameFolder().Contains("COZIMENTO ELÉTRICO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Panela.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Electric Cooking";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Cocina eléctrica";
                            }
                            else
                            {
                                tipoProduto = "Cozimento Elétrico";
                            }
                        }
                        else if (dto.getNameFolder().Contains("PURIFICADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Purificador.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Purifiers";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Purificadores";
                            }
                            else
                            {
                                tipoProduto = "Purificadores";
                            }
                        }
                        else if (dto.getNameFolder().Contains("SECADORA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_secadora.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Dryers";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Secadoras";
                            }
                            else
                            {
                                tipoProduto = "Secadoras";
                            }
                        }
                        else if (dto.getNameFolder().Contains("TORRADEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Torradeira.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Toasters";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Tostadoras";
                            }
                            else
                            {
                                tipoProduto = "Torradeiras";
                            }
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT.png");
                            if (idioma.Equals("en-US"))
                            {
                                tipoProduto = "Other products";
                            }
                            else if (idioma.Equals("es-ES"))
                            {
                                tipoProduto = "Otros productos";
                            }
                            else
                            {
                                tipoProduto = "Outros Produtos";
                            }
                        }
                    }
                    else
                    {
                        dto.setUrlImagem("../includes/images/boletins/BT.png");
                        if (idioma.Equals("en-US"))
                        {
                            tipoProduto = "Other products";
                        }
                        else if (idioma.Equals("es-ES"))
                        {
                            tipoProduto = "Otros productos";
                        }
                        else
                        {
                            tipoProduto = "Outros Produtos";
                        }
                    }

                    if(listOrdenadaProduto.Count() == 0)
                    {
                        conteudoOrdenadoProdutoDTO.setTipoProduto(tipoProduto);
                        list.Add(dto);
                        conteudoOrdenadoProdutoDTO.setConteudos(list);
                        listOrdenadaProduto.Add(conteudoOrdenadoProdutoDTO);
                    }else
                    {
                        int idxListaProdutoBuscado = -1;
                        for (var i = 0; i < listOrdenadaProduto.Count(); i++)
                        {
                            if(listOrdenadaProduto[i].getTipoProduto() == tipoProduto)
                            {
                                idxListaProdutoBuscado = i;
                                break;
                            }
                        }

                        if(idxListaProdutoBuscado >= 0)
                        {
                            listOrdenadaProduto[idxListaProdutoBuscado].getConteudos().Add(dto);
                        }else
                        {
                            conteudoOrdenadoProdutoDTO = new ConteudoOrdenadoTipoProdutoDTO();
                            list = new List<ConteudoDTO>();
                            conteudoOrdenadoProdutoDTO.setTipoProduto(tipoProduto);
                            list.Add(dto);
                            conteudoOrdenadoProdutoDTO.setConteudos(list);
                            listOrdenadaProduto.Add(conteudoOrdenadoProdutoDTO);
                        }
                    }
                }

                if (listOrdenadaProduto.Count > 0)
                {
                    listOrdenadaProduto.Sort((p, q) => p.getTipoProduto().CompareTo(q.getTipoProduto()));
                }
            }
            catch (Exception e)
            {

            }

            finally { con.Close(); }

            return listOrdenadaProduto;
        }


            public List<ConteudoOrdenadoAnoDTO> carregandoBoletimServico(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();
            List<ConteudoOrdenadoAnoDTO> listOrdenadaAno = new List<ConteudoOrdenadoAnoDTO>();
            ConteudoOrdenadoAnoDTO conteudoOrdenadoAnoDTO = new ConteudoOrdenadoAnoDTO();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();

                /*sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder " +
                      "FROM content a " +
                      "inner join content_group b on b.id_content = a.id " +
                      "inner join user_group c on c.id_group = b.id_group " +
                      "where c.id_user = '" + username + "' and a.name_folder is not null and a.name_folder like 'Boleti%' and a.type in ('outros', 'boletim') " +
                      "order by a.updated_on desc";*/

                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type , a.name_folder, a.updated_on " +
                      "FROM content a " +
                      "inner join content_group b on b.id_content = a.id " +
                      "inner join user_group c on c.id_group = b.id_group " +
                      "where c.id_user = '" + username + "' and a.type in ('boletim') " +
                      "order by a.updated_on desc";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                string anoCorrente = "";
                while (dr.Read())
                {
                    var count = dr.FieldCount;
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id"].ToString());
                    dto.setTitulo(dr["name"].ToString());
                    dto.setNameFolder(dr["name_folder"].ToString().ToUpper());
                    dto.setProprietario(dr["created_by"].ToString());
                    string updatedOn = dr["updated_on"].ToString();
                    DateTime dateTime = Convert.ToDateTime(updatedOn);
                    dto.setUpdated_On(dateTime);

                    if(dto.getNameFolder() != "" && dto.getNameFolder() != null) 
                    {
                        if (dto.getNameFolder().Contains("REFRIGERADO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Geladeira.png");
                        }else if (dto.getNameFolder().Contains("ADEGA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_adega.jpg");
                        }else if (dto.getNameFolder().Contains("PREPARAÇÃO DE ALIMENTOS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_AirFryer.png");
                        }else if (dto.getNameFolder().Contains("ALTA PRESSÃO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Altapressao.png");
                        }
                        else if (dto.getNameFolder().Contains("ASPIRADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Aspirador.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBEDOURO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Bebedouro.png");
                        }
                        else if (dto.getNameFolder().Contains("BEBIDAS QUENTES"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Cafeteira.png");
                        }
                        else if (dto.getNameFolder().Contains("CERVEJEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Cervejeira.png");
                        }
                        else if (dto.getNameFolder().Contains("COIFAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Coifas.png");
                        }
                        else if (dto.getNameFolder().Contains("CONDICIONADO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("COOKTOP"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_cooktop.png");
                        }
                        else if (dto.getNameFolder().Contains("DEPURADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_depurador.png");
                        }
                        else if (dto.getNameFolder().Contains("FOGÕES"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Fogao.png");
                        }
                        else if (dto.getNameFolder().Contains("FORNO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Forno.png");
                        }
                        else if (dto.getNameFolder().Contains("FRIGOBAR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Frigobar.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA E SECA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_lavaseca.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVADORA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Lavadora.png");
                        }
                        else if (dto.getNameFolder().Contains("LAVA-LOUÇAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_loucas.png");
                        }
                        else if (dto.getNameFolder().Contains("MICRO-ONDAS"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_micro.png");
                        }
                        else if (dto.getNameFolder().Contains("COZIMENTO ELÉTRICO"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Panela.png");
                        }
                        else if (dto.getNameFolder().Contains("PURIFICADOR"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Purificador.png");
                        }
                        else if (dto.getNameFolder().Contains("SECADORA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_secadora.png");
                        }
                        else if (dto.getNameFolder().Contains("TORRADEIRA"))
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT_Torradeira.png");
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/boletins/BT.png");
                        }
                    }else
                    {
                        dto.setUrlImagem("../includes/images/boletins/BT.png");
                    }

                    if (anoCorrente.Equals(""))
                    {
                        anoCorrente = dateTime.Year.ToString();
                    }
                    if (anoCorrente.Equals(dateTime.Year.ToString()))
                    {
                        list.Add(dto);
                        conteudoOrdenadoAnoDTO.setConteudos(list);
                        conteudoOrdenadoAnoDTO.setAno(anoCorrente);
                    }
                    else
                    {
                        //Adiciona os conteudos do ano que pegou para a listaOrdenada
                        listOrdenadaAno.Add(conteudoOrdenadoAnoDTO);
                        //Zera as variaveis de lista para uma nova lista de conteúdos do próximo ano
                        conteudoOrdenadoAnoDTO = new ConteudoOrdenadoAnoDTO();
                        list = new List<ConteudoDTO>();

                        //Define novo ano corrente
                        anoCorrente = dateTime.Year.ToString();
                        //Adiciona o primeiro registro desse novo ano corrente
                        list.Add(dto);
                        conteudoOrdenadoAnoDTO.setConteudos(list);
                        conteudoOrdenadoAnoDTO.setAno(anoCorrente);
                    }
                }

                //Adiciona a última lista de registro que não foi adicionada no final do loop
                if (dr.HasRows)
                {
                    listOrdenadaAno.Add(conteudoOrdenadoAnoDTO);
                }
             
            }
            catch (Exception e) { }

            finally { con.Close(); }

            return listOrdenadaAno;
        }


        public List<ConteudoDTO> carregandoPopular(string username)
        {
            List<ConteudoDTO> list = new List<ConteudoDTO>();

            SqlConnection con = null;
            try
            {
                string sql = "";
                con = getConexao();
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type, a.canal_video " +
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
                    dto.setNameFolder(dr["canal_video"].ToString());

                    if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                    {
                        if (dto.getNameFolder().Contains("Ar condicionado"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("Coifas e Depuradores"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_Coifas.png");
                        }
                        else if (dto.getNameFolder().Contains("Condicionadores de Ar"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("Eletroportáteis"))
                        {
                            if (dto.getTitulo().Contains("Cafeteira"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cafeteira.png");
                            }
                            else if (dto.getTitulo().Contains("Aspirador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                            }
                            else if (dto.getTitulo().Contains("Liquidificador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Liquidificador.png");
                            }
                            else if (dto.getTitulo().Contains("Panela"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Panela.png");
                            }
                            else if (dto.getTitulo().Contains("Ferro"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Ferro.png");
                            }
                            else if (dto.getTitulo().Contains("aspirador de pó"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Fogões"))
                        {
                            if (dto.getTitulo().Contains("Fogão"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                            }
                            else if (dto.getTitulo().Contains("Cooktop"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cooktop.png");
                            }
                            else if (dto.getTitulo().Contains("Forno"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Fornos de Embutir"))
                        {
                            if (dto.getTitulo().Contains("Micro-ondas"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Lava Louças"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                        }
                        else if (dto.getNameFolder().Contains("Máquinas de lavar"))
                        {
                            if (dto.getTitulo().Contains("Caneta") || dto.getTitulo().Contains("Lavadora"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                            }
                            else if (dto.getTitulo().Contains("Secadora"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                            }
                            else if (dto.getTitulo().Contains("Lava Seca") || dto.getTitulo().Contains("Lava e Seca"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Lavaseca.png");
                            }
                            else if (dto.getTitulo().Contains("louça"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                            }
                            else if (dto.getTitulo().Contains("Alta pressão"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Altapressão.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Micro-ondas"))
                        {
                            if (dto.getTitulo().Contains("fogao"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Purificadores e Bebedouros"))
                        {
                            if (dto.getTitulo().Contains("Bebedouro"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Bebedouro.png");
                            }
                            else if (dto.getTitulo().Contains("Purificador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                            }
                            else if (dto.getTitulo().Contains("ar"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Refrigeradores"))
                        {
                            if (dto.getTitulo().Contains("Adega"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_adega.png");
                            }
                            else if (dto.getTitulo().Contains("Refrigerador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                            }
                            else if (dto.getTitulo().Contains("Cervejeira"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cervejeira.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Secadoras"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                        }
                    }
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
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    var splitTitulo = dto.getTitulo().Split('.');
                    if (splitTitulo.Length > 1)
                    {
                        if (splitTitulo[1].Contains("AC"))
                        {
                            dto.setUrlImagem("../includes/images/provas/AC.png");
                        }
                        if (splitTitulo[1].Contains("ACF"))
                        {
                            dto.setUrlImagem("../includes/images/provas/ACF.png");
                        }
                        if (splitTitulo[1].Contains("ADM"))
                        {
                            dto.setUrlImagem("../includes/images/provas/ADM.png");
                        }
                        if (splitTitulo[1].Contains("DW"))
                        {
                            dto.setUrlImagem("../includes/images/provas/DW.png");
                        }
                        if (splitTitulo[1].Contains("EC"))
                        {
                            dto.setUrlImagem("../includes/images/provas/EC.png");
                        }
                        if (splitTitulo[1].Contains("FC"))
                        {
                            dto.setUrlImagem("../includes/images/provas/FC.png");
                        }
                        if (splitTitulo[1].Contains("FPP"))
                        {
                            dto.setUrlImagem("../includes/images/provas/FPP.png");
                        }
                        if (splitTitulo[1].Contains("FPS"))
                        {
                            dto.setUrlImagem("../includes/images/provas/FPS.png");
                        }
                        if (splitTitulo[1].Contains("HP"))
                        {
                            dto.setUrlImagem("../includes/images/provas/HP.png");
                        }
                        if (splitTitulo[1].Contains("IOT"))
                        {
                            dto.setUrlImagem("../includes/images/provas/IOT.png");
                        }
                        if (splitTitulo[1].Contains("LV"))
                        {
                            dto.setUrlImagem("../includes/images/provas/LV.png");
                        }
                        if (splitTitulo[1].Contains("MWO"))
                        {
                            dto.setUrlImagem("../includes/images/provas/MWO.png");
                        }
                        if (splitTitulo[1].Contains("RI"))
                        {
                            dto.setUrlImagem("../includes/images/provas/RI.png");
                        }
                        if (splitTitulo[1].Contains("SA"))
                        {
                            dto.setUrlImagem("../includes/images/provas/SA.png");
                        }
                        if (splitTitulo[1].Contains("WC"))
                        {
                            dto.setUrlImagem("../includes/images/provas/WC.png");
                        }
                    }

                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

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
                sql = " select  * from user_training a " +
                        "inner join courses c on a.id_training = c.id " +
                        "where a.id_usuario = '" + username + "' ";


                SqlCommand comando = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = comando.ExecuteReader();
                while (dr.Read())
                {
                    ConteudoDTO dto = new ConteudoDTO();
                    dto.setId(dr["id_training"].ToString());
                    dto.setTitulo(dr["name_training"].ToString());
                    dto.setProprietario(dr["created_by"].ToString());
                    dto.setUrlImagem(dr["url_imagem"].ToString());

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
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

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
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

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
             
                sql = " SELECT a.id, a.name, a.created_by, a.url_video, a.type, a.canal_video, a.updated_on " +
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
                    dto.setNameFolder(dr["canal_video"].ToString());
                    dto.setUpdated_On(Convert.ToDateTime(dr["updated_on"].ToString()));

                    if (dto.getNameFolder() != "" && dto.getNameFolder() != null)
                    {
                        if (dto.getNameFolder().Contains("Ar condicionado"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("Coifas e Depuradores"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_Coifas.png");
                        }
                        else if (dto.getNameFolder().Contains("Condicionadores de Ar"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                        }
                        else if (dto.getNameFolder().Contains("Eletroportáteis"))
                        {
                            if (dto.getTitulo().Contains("Cafeteira"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cafeteira.png");
                            }
                            else if (dto.getTitulo().Contains("Aspirador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                            }
                            else if (dto.getTitulo().Contains("Liquidificador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Liquidificador.png");
                            }
                            else if (dto.getTitulo().Contains("Panela"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Panela.png");
                            }
                            else if (dto.getTitulo().Contains("Ferro"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Ferro.png");
                            }
                            else if (dto.getTitulo().Contains("aspirador de pó"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Aspirador.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Fogões"))
                        {
                            if (dto.getTitulo().Contains("Fogão"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                            }
                            else if (dto.getTitulo().Contains("Cooktop"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cooktop.png");
                            }
                            else if (dto.getTitulo().Contains("Forno"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Fornos de Embutir"))
                        {
                            if (dto.getTitulo().Contains("Micro-ondas"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Forno.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Lava Louças"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                        }
                        else if (dto.getNameFolder().Contains("Máquinas de lavar"))
                        {
                            if (dto.getTitulo().Contains("Caneta") || dto.getTitulo().Contains("Lavadora"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                            }
                            else if (dto.getTitulo().Contains("Secadora"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                            }
                            else if (dto.getTitulo().Contains("Lava Seca") || dto.getTitulo().Contains("Lava e Seca"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Lavaseca.png");
                            }
                            else if (dto.getTitulo().Contains("louça"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_loucas.png");
                            }
                            else if (dto.getTitulo().Contains("Alta pressão"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Altapressão.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_lavadora.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Micro-ondas"))
                        {
                            if (dto.getTitulo().Contains("fogao"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Fogao.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_micro.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Purificadores e Bebedouros"))
                        {
                            if (dto.getTitulo().Contains("Bebedouro"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Bebedouro.png");
                            }
                            else if (dto.getTitulo().Contains("Purificador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                            }
                            else if (dto.getTitulo().Contains("ar"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_condicionador.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Purificador.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Refrigeradores"))
                        {
                            if (dto.getTitulo().Contains("Adega"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_adega.png");
                            }
                            else if (dto.getTitulo().Contains("Refrigerador"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                            }
                            else if (dto.getTitulo().Contains("Cervejeira"))
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Cervejeira.png");
                            }
                            else
                            {
                                dto.setUrlImagem("../includes/images/videos/Video_Geladeira.png");
                            }
                        }
                        else if (dto.getNameFolder().Contains("Secadoras"))
                        {
                            dto.setUrlImagem("../includes/images/videos/Video_secadora.png");
                        }
                        else
                        {
                            dto.setUrlImagem("../includes/images/videos/la_cards_icones_videos.png");
                        }
                    }
                    list.Add(dto);
                }


            }
            catch (Exception e) { }

            finally { con.Close(); }

            list.OrderByDescending(e => e.getUpdated_On());

            list.OrderByDescending(e => e.getUpdated_On());

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
