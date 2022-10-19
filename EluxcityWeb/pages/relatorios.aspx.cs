using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel; // para arquivos XLS
using System.IO;
using EluxcityWeb.Controller;

namespace EluxcityWeb.pages
{
    public partial class relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static string codUser = "0";
        private static string dtInicial = "";
        private static string dtFinal = "";
        private static string idioma = "";
        private static string tipoArvore = "";

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
            try
            {
                string datahora = "relatorio";
                
                string location = System.Web.HttpContext.Current.Server.MapPath("UploadFile") + "\\";
                location = location.Replace("pages\\", "");
                string nomearquivo = datahora+".xls";

                //carrega os dados
                PesquisaAction action = new PesquisaAction();
                string dados = action.carregaDadosExcel(codUser, dtInicial, dtFinal);
                //      string conteudo = descricao_ocorrencia_ing + "!#!"
               /* + nome_linha_ing + "!#!"
                    + nome_produto_ing + "!#!"
                    + nome_modelo_ing + "!#!" 
                    + nome_modelo_esp + "!#!"
                    + nome_produto_esp + "!#!"
                    + nome_linha_esp + "!#!"
                    + descricao_ocorrencia_esp + "!#!"
                    + descricao_ocorrencia_por + "!#!" 
                    + nome_linha_por + "!#!"
                    + nome_produto_por + "!#!"
                    + nome_modelo_por + "!#!"
                    + nome_usuario + "!#!"
                    + data_e_hora + "!#!" 
                    + cod_pesquisa;*/

                char[] delimiterChars = { '$' };
                char[] delimiterChars2 = { '#' };
                string[] aDados = dados.Split(delimiterChars);



                FileStream arquivoXLS = new FileStream(location + nomearquivo, FileMode.Create, FileAccess.ReadWrite);
                // recupera o Workbook do arquivo
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("relatorio");
                IRow row = sheet.CreateRow(0);
                row.CreateCell(3).SetCellValue("Relatório de Acesso à Árvore de Decisão");
                row = sheet.CreateRow(2);
                row.CreateCell(0).SetCellValue("Usuário");
                row.CreateCell(1).SetCellValue("Data e Hora");
                row.CreateCell(2).SetCellValue("Linha");
                row.CreateCell(3).SetCellValue("Produto");
                row.CreateCell(4).SetCellValue("Modelo");
                row.CreateCell(5).SetCellValue("Ocorrência");
                row.CreateCell(6).SetCellValue("País");
                
                int numeroProximaLinha = 3;

                for (int i = 0; i < aDados.Length; i++)
                {
                     row = sheet.CreateRow(numeroProximaLinha);
                     string[] aValores =  aDados[i].Split(delimiterChars2);
                    

                     if (idioma.Equals("en-US"))
                     {
                         row.CreateCell(0).SetCellValue(aValores[12]);
                         row.CreateCell(1).SetCellValue(aValores[13]);
                         row.CreateCell(2).SetCellValue(aValores[1]);
                         row.CreateCell(3).SetCellValue(aValores[2]);
                         row.CreateCell(4).SetCellValue(aValores[3]);
                         row.CreateCell(5).SetCellValue(aValores[0]);
                         row.CreateCell(6).SetCellValue(aValores[15]);
                        

                     }
                     else if (idioma.Equals("es-ES"))
                     {
                         row.CreateCell(0).SetCellValue(aValores[12]);
                         row.CreateCell(1).SetCellValue(aValores[13]);
                         row.CreateCell(2).SetCellValue(aValores[6]);
                         row.CreateCell(3).SetCellValue(aValores[5]);
                         row.CreateCell(4).SetCellValue(aValores[4]);
                         row.CreateCell(5).SetCellValue(aValores[7]);
                         row.CreateCell(6).SetCellValue(aValores[15]);
                     }
                     else
                     {
                         row.CreateCell(0).SetCellValue(aValores[12]);
                         row.CreateCell(1).SetCellValue(aValores[13]);
                         row.CreateCell(2).SetCellValue(aValores[9]);
                         row.CreateCell(3).SetCellValue(aValores[10]);
                         row.CreateCell(4).SetCellValue(aValores[11]);
                         row.CreateCell(5).SetCellValue(aValores[8]);
                         row.CreateCell(6).SetCellValue(aValores[15]);
                     }


                    



                    numeroProximaLinha++;
                }


               


                workbook.Write(arquivoXLS);
                arquivoXLS.Close();


                Response.AppendHeader("Content-Disposition", "attachment; filename=relatorio.xls");
                Response.TransmitFile(location + nomearquivo);
                Response.End();


                FileInfo myfileinf = new FileInfo(location + nomearquivo);
                myfileinf.Delete();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
        }



        protected void btnExportToExcelQualidade_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
            try
            {
                string datahora = "relatorio_qualidade";

                string location = System.Web.HttpContext.Current.Server.MapPath("UploadFile") + "\\";
                location = location.Replace("pages\\", "");
                string nomearquivo = datahora + ".xls";

                //carrega os dados
                ComentarioAction action = new ComentarioAction();
                string dados = action.carregaDadosExcel(codUser, dtInicial, dtFinal);
               

                char[] delimiterChars = { '$' };
                char[] delimiterChars2 = { '#' };
                string[] aDados = dados.Split(delimiterChars);



                FileStream arquivoXLS = new FileStream(location + nomearquivo, FileMode.Create, FileAccess.ReadWrite);
                // recupera o Workbook do arquivo
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("relatorio");
                IRow row = sheet.CreateRow(0);
                row.CreateCell(3).SetCellValue("Relatório de qualidade do uso da árvore de decisão");
                row = sheet.CreateRow(2);
                row.CreateCell(0).SetCellValue("Usuário");
                row.CreateCell(1).SetCellValue("Êxito");
                row.CreateCell(2).SetCellValue("Linha");
                row.CreateCell(3).SetCellValue("Produto");
                row.CreateCell(4).SetCellValue("Modelo");
                row.CreateCell(5).SetCellValue("Ocorrência");
                row.CreateCell(6).SetCellValue("Pergunta");
                row.CreateCell(7).SetCellValue("Comentário");
                row.CreateCell(8).SetCellValue("Data e Hora");
                row.CreateCell(9).SetCellValue("País");

                int numeroProximaLinha = 3;

                //  redacao_pergunta_esp + "#" + 
             /*   redacao_pergunta_por + "#" + 
                    redacao_pergunta_ing + "#" +
                    descricao_ocorrencia_ing + "#" +
                    nome_linha_ing + "#" +
                    nome_produto_ing + "#" +
                    nome_modelo_ing + "#" +
                    nome_modelo_esp + "#" +
                    nome_produto_esp + "#" +
                    nome_linha_esp + "#" +
                    descricao_ocorrencia_esp + "#" +
                    descricao_ocorrencia_por + "#" +
                    nome_linha_por + "#" + 
                    nome_produto_por + "#" + 
                    nome_modelo_por + "#" + 
                    nome_usuario + "#" +
                    data_e_hora + "#" +
                    foi_util + "#" +
                    visualizar;*/


                for (int i = 0; i < aDados.Length; i++)
                {
                    row = sheet.CreateRow(numeroProximaLinha);
                    string[] aValores = aDados[i].Split(delimiterChars2);


                    if (idioma.Equals("en-US"))
                    {
                        row.CreateCell(0).SetCellValue(aValores[15]);
                        row.CreateCell(1).SetCellValue(aValores[17]);
                        row.CreateCell(2).SetCellValue(aValores[4]);
                        row.CreateCell(3).SetCellValue(aValores[5]);
                        row.CreateCell(4).SetCellValue(aValores[6]);
                        row.CreateCell(5).SetCellValue(aValores[3]);
                        row.CreateCell(6).SetCellValue(aValores[2]);
                        row.CreateCell(7).SetCellValue(aValores[18]);
                        row.CreateCell(8).SetCellValue(aValores[16]);
                        row.CreateCell(9).SetCellValue(aValores[19]);


                    }
                    else if (idioma.Equals("es-ES"))
                    {
                        row.CreateCell(0).SetCellValue(aValores[15]);
                        row.CreateCell(1).SetCellValue(aValores[17]);
                        row.CreateCell(2).SetCellValue(aValores[9]);
                        row.CreateCell(3).SetCellValue(aValores[8]);
                        row.CreateCell(4).SetCellValue(aValores[7]);
                        row.CreateCell(5).SetCellValue(aValores[10]);
                        row.CreateCell(6).SetCellValue(aValores[0]);
                        row.CreateCell(7).SetCellValue(aValores[18]);
                        row.CreateCell(8).SetCellValue(aValores[16]);
                        row.CreateCell(9).SetCellValue(aValores[19]);
                    }
                    else
                    {
                        row.CreateCell(0).SetCellValue(aValores[15]);
                        row.CreateCell(1).SetCellValue(aValores[17]);
                        row.CreateCell(2).SetCellValue(aValores[12]);
                        row.CreateCell(3).SetCellValue(aValores[13]);
                        row.CreateCell(4).SetCellValue(aValores[14]);
                        row.CreateCell(5).SetCellValue(aValores[11]);
                        row.CreateCell(6).SetCellValue(aValores[1]);
                        row.CreateCell(7).SetCellValue(aValores[18]);
                        row.CreateCell(8).SetCellValue(aValores[16]);
                        row.CreateCell(9).SetCellValue(aValores[19]);
                    }






                    numeroProximaLinha++;
                }





                workbook.Write(arquivoXLS);
                arquivoXLS.Close();


                Response.AppendHeader("Content-Disposition", "attachment; filename=relatorio.xls");
                Response.TransmitFile(location + nomearquivo);
                Response.End();


                FileInfo myfileinf = new FileInfo(location + nomearquivo);
                myfileinf.Delete();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada
        }

        protected void btnExportToExcelDados_Click(object sender, EventArgs e)
        {

#pragma warning disable CS0168 // A variável "ex" está declarada, mas nunca é usada
            try
            {
                string datahora = "relatorio_dados";

                string location = System.Web.HttpContext.Current.Server.MapPath("UploadFile") + "\\";
                location = location.Replace("pages\\", "");
                string nomearquivo = datahora + ".xls";

                //carrega os dados
                PesquisaAction action = new PesquisaAction();
                string dados = action.carregaRelatorioDadosExcel(codUser, dtInicial, dtFinal, idioma, tipoArvore);


                char[] delimiterChars = { '$' };
                char[] delimiterChars2 = { '#' };
                string[] aDados = dados.Split(delimiterChars);



                FileStream arquivoXLS = new FileStream(location + nomearquivo, FileMode.Create, FileAccess.ReadWrite);
                // recupera o Workbook do arquivo
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("relatorio");
                IRow row = sheet.CreateRow(0);
                row.CreateCell(3).SetCellValue("Relatório de dados");
                row = sheet.CreateRow(2);

                if (idioma.Equals("ing"))
                {
                    row.CreateCell(0).SetCellValue("Line");
                    row.CreateCell(1).SetCellValue("Category");
                    row.CreateCell(2).SetCellValue("Subcategory");
                    row.CreateCell(3).SetCellValue("Ocurrencia");
                    row.CreateCell(4).SetCellValue("Code");
                    row.CreateCell(5).SetCellValue("Question");
                    row.CreateCell(6).SetCellValue("Answer");
                    row.CreateCell(7).SetCellValue("Type question");
                    row.CreateCell(8).SetCellValue("Country");
                    row.CreateCell(9).SetCellValue("User");
                    row.CreateCell(10).SetCellValue("Date and time");
                }
                else if (idioma.Equals("esp"))
                {
                    row.CreateCell(0).SetCellValue("Línea");
                    row.CreateCell(1).SetCellValue("Categoría");
                    row.CreateCell(2).SetCellValue("SubCategoría");
                    row.CreateCell(3).SetCellValue("Ocurrencia");
                    row.CreateCell(4).SetCellValue("Codigo");
                    row.CreateCell(5).SetCellValue("Pregunta");
                    row.CreateCell(6).SetCellValue("Respuesta");
                    row.CreateCell(7).SetCellValue("Tipo pregunta");
                    row.CreateCell(8).SetCellValue("País");
                    row.CreateCell(9).SetCellValue("Usuario");
                    row.CreateCell(10).SetCellValue("Fecha y hora");
                }
                else
                {
                    row.CreateCell(0).SetCellValue("Linha (Português / Inglês / Espanhol)");
                    row.CreateCell(1).SetCellValue("Categoria (Português / Inglês / Espanhol)");
                    row.CreateCell(2).SetCellValue("Subcategoria (Português / Inglês / Espanhol)");
                    row.CreateCell(3).SetCellValue("Ocorrência (Português / Inglês / Espanhol)");
                    row.CreateCell(4).SetCellValue("Código");
                    row.CreateCell(5).SetCellValue("Pergunta (Português / Inglês / Espanhol)");
                    row.CreateCell(6).SetCellValue("Resposta (Português / Inglês / Espanhol)");
                    row.CreateCell(7).SetCellValue("Tipo pergunta");
                    row.CreateCell(8).SetCellValue("País");
                    row.CreateCell(9).SetCellValue("Usuário");
                    row.CreateCell(10).SetCellValue("Data e Hora");
                }

                

                int numeroProximaLinha = 3;

             

                for (int i = 0; i < aDados.Length; i++)
                {
                    row = sheet.CreateRow(numeroProximaLinha);
                    string[] aValores = aDados[i].Split(delimiterChars2);


                    if (idioma.Equals("ing"))
                    {
                        row.CreateCell(0).SetCellValue(aValores[0]);
                        row.CreateCell(1).SetCellValue(aValores[1]);
                        row.CreateCell(2).SetCellValue(aValores[2]);
                        row.CreateCell(3).SetCellValue(aValores[3]);
                        row.CreateCell(4).SetCellValue(aValores[4]);
                        row.CreateCell(5).SetCellValue(aValores[5]);
                        row.CreateCell(6).SetCellValue(aValores[6]);
                        row.CreateCell(7).SetCellValue(aValores[7]);
                        row.CreateCell(8).SetCellValue(aValores[8]);
                        row.CreateCell(9).SetCellValue(aValores[9]);
                        row.CreateCell(10).SetCellValue(aValores[10]);


                    }
                    else if (idioma.Equals("esp"))
                    {
                        row.CreateCell(0).SetCellValue(aValores[0]);
                        row.CreateCell(1).SetCellValue(aValores[1]);
                        row.CreateCell(2).SetCellValue(aValores[2]);
                        row.CreateCell(3).SetCellValue(aValores[3]);
                        row.CreateCell(4).SetCellValue(aValores[4]);
                        row.CreateCell(5).SetCellValue(aValores[5]);
                        row.CreateCell(6).SetCellValue(aValores[6]);
                        row.CreateCell(7).SetCellValue(aValores[7]);
                        row.CreateCell(8).SetCellValue(aValores[8]);
                        row.CreateCell(9).SetCellValue(aValores[9]);
                        row.CreateCell(10).SetCellValue(aValores[10]);
                    }
                    else
                    {
                        row.CreateCell(0).SetCellValue(aValores[0]);
                        row.CreateCell(1).SetCellValue(aValores[1]);
                        row.CreateCell(2).SetCellValue(aValores[2]);
                        row.CreateCell(3).SetCellValue(aValores[3]);
                        row.CreateCell(4).SetCellValue(aValores[4]);
                        row.CreateCell(5).SetCellValue(aValores[5]);
                        row.CreateCell(6).SetCellValue(aValores[6]);
                        row.CreateCell(7).SetCellValue(aValores[7]);
                        row.CreateCell(8).SetCellValue(aValores[8]);
                        row.CreateCell(9).SetCellValue(aValores[9]);
                        row.CreateCell(10).SetCellValue(aValores[10]);
                    }






                    numeroProximaLinha++;
                }





                workbook.Write(arquivoXLS);
                arquivoXLS.Close();


                Response.AppendHeader("Content-Disposition", "attachment; filename=relatorio.xls");
                Response.TransmitFile(location + nomearquivo);
                Response.End();


                FileInfo myfileinf = new FileInfo(location + nomearquivo);
                myfileinf.Delete();
            }
            catch (Exception ex) { }
#pragma warning restore CS0168 // A variável "ex" está declarada, mas nunca é usada

        }

        [WebMethod()]
        public static string carregaComboUsuario()
        {

            PesquisaAction action = new PesquisaAction();
            string dados = action.carregaComboUsuario();
            return dados;

        }

        [WebMethod()]
        public static string carregaComboUsuarioDados()
        {

            PesquisaAction action = new PesquisaAction();
            string dados = action.carregaComboUsuarioDados();
            return dados;

        }

        [WebMethod()]
        public static string visualizarComentario(string codigo)
        {

            ComentarioAction action = new ComentarioAction();
            string dados = action.carregaComentario(codigo);
            return dados;

        }

        [WebMethod()]
        public static string retornaRelatorioDeAcesso(string codigoUsuario, string dataInicial, string dataFinal, string idio,
           string limit, string offset)
        {

            codUser = codigoUsuario;
            dtInicial = dataInicial;
            dtFinal = dataFinal;
            idioma = idio;

            PesquisaAction action = new PesquisaAction();
            string dados = action.carregaDados(codigoUsuario,dataInicial,dataFinal, limit, offset);
            return dados;

        }


        [WebMethod()]
        public static string exportExcelAcesso()
        {

            string json = "";

           

            json = "Exportado com sucesso.";
            return json;

        }

        [WebMethod()]
        public static string retornaRelatorioDeUso(string codigoUsuario, string dataInicial, string dataFinal, string idio,
            string limit, string offset)
        {

            codUser = codigoUsuario;
            dtInicial = dataInicial;
            dtFinal = dataFinal;
            idioma = idio;

            ComentarioAction action = new ComentarioAction();
            string dados = action.carregaDados(codigoUsuario, dataInicial, dataFinal, limit, offset);
            return dados;

        }


        [WebMethod()]
        public static string retornaRelatorioDados(string limit, string offset,
             string codigoUsuario, string dataInicial, string dataFinal, string idio, string tipoArv)
        {

            codUser = codigoUsuario;
            dtInicial = dataInicial;
            dtFinal = dataFinal;
            idioma = idio;
            tipoArvore = tipoArv;

            PesquisaAction action = new PesquisaAction();
            string dados = action.carregaRelatorioDados(codigoUsuario, dataInicial, dataFinal, limit, offset, idioma, tipoArvore);
            return dados;

        }

    }
}