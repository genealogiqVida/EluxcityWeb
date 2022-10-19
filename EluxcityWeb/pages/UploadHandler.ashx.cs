using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel; // para arquivos XLS
using System.Collections;
using EluxcityWeb.DAO;

namespace EluxcityWeb.pages
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          
#pragma warning disable CS0168 // A variável "e" está declarada, mas nunca é usada
            try
            {
                    LinhaDAO linhaDAO = new LinhaDAO();
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    ModeloDAO modeloDAO = new ModeloDAO();
                    OcorrenciaDAO ocorrenciaDAO = new OcorrenciaDAO();
                    PerguntaDAO perguntaDAO = new PerguntaDAO();

                    string tipoArvore = "";
                    HttpCookie cookie = context.Request.Cookies["tipoArvore"];
                    if (cookie != null)
                    {
                        tipoArvore = cookie.Value.ToString();
                        tipoArvore = tipoArvore.Replace("%20", " ");
                    }

                    string username = "";
                    cookie = context.Request.Cookies["nome"];
                    if (cookie != null)
                    {
                        username = cookie.Value.ToString();
                        username = username.Replace("%20", " ");
                    }

                   // tipoArvore = context.Request["tipoArvore"];
                   // tipoArvore = tipoArvore.Replace("%20", " ");
                
                    string fileName = Path.GetFileName(context.Request.Files[0].FileName);
                    string location = System.Web.HttpContext.Current.Server.MapPath("UploadFile") + "\\" + context.Request.Files[0].FileName;
                    location = location.Replace("pages\\", "");
                    context.Request.Files[0].SaveAs(location);

                    if (fileName.IndexOf(".xlsx") == -1)
                    {


                        FileStream arquivoXLS = new FileStream(location, FileMode.Open, FileAccess.Read);
                        // recupera o Workbook do arquivo
                        HSSFWorkbook workbook = new HSSFWorkbook(arquivoXLS);

                        ISheet sheet = workbook.GetSheet("Check List");
                        for (int row = 1; row <= sheet.LastRowNum; row++)
                        {
                            if (sheet.GetRow(row) != null) //null is when the row only contains empty cells 
                            {


                                string linha = sheet.GetRow(row).GetCell(0).StringCellValue;
                                string linha_esp = sheet.GetRow(row).GetCell(1).StringCellValue;
                                string linha_ing = sheet.GetRow(row).GetCell(2).StringCellValue;
                             if(!linha.Equals("")){   
                                
                                string produto = sheet.GetRow(row).GetCell(3).StringCellValue;
                                string produto_esp = sheet.GetRow(row).GetCell(4).StringCellValue;
                                string produto_ing = sheet.GetRow(row).GetCell(5).StringCellValue;
                                string modelo = sheet.GetRow(row).GetCell(6).StringCellValue;
                                string modelo_esp = sheet.GetRow(row).GetCell(7).StringCellValue;
                                string modelo_ing = sheet.GetRow(row).GetCell(8).StringCellValue;
                                string ocorrencia = sheet.GetRow(row).GetCell(9).StringCellValue;
                                string ocorrencia_esp = sheet.GetRow(row).GetCell(10).StringCellValue;
                                string ocorrencia_ing = sheet.GetRow(row).GetCell(11).StringCellValue;

                                ocorrencia = ocorrencia.Replace("\n", "<br>");
                                ocorrencia_esp = ocorrencia_esp.Replace("\n", "<br>");
                                ocorrencia_ing = ocorrencia_ing.Replace("\n", "<br>");

                                modelo = modelo.Replace("\n", "<br>");
                                modelo_ing = modelo_ing.Replace("\n", "<br>");
                                modelo_esp = modelo_esp.Replace("\n", "<br>");

                                produto_ing = produto_ing.Replace("\n", "<br>");
                                produto_esp = produto_esp.Replace("\n", "<br>");
                                produto = produto.Replace("\n", "<br>");

                                linha = linha.Replace("\n", "<br>");
                                linha_esp = linha_esp.Replace("\n", "<br>");
                                linha_ing = linha_ing.Replace("\n", "<br>");
                                
                                int codigo = (int)sheet.GetRow(row).GetCell(12).NumericCellValue;
                                string pergunta = sheet.GetRow(row).GetCell(13).StringCellValue;
                                string pergunta_esp = sheet.GetRow(row).GetCell(14).StringCellValue;
                                string pergunta_ing = sheet.GetRow(row).GetCell(15).StringCellValue;
                                string resposta = sheet.GetRow(row).GetCell(16).StringCellValue;
                                string resposta_esp = sheet.GetRow(row).GetCell(17).StringCellValue;
                                string resposta_ing = sheet.GetRow(row).GetCell(18).StringCellValue;


                                pergunta = pergunta.Replace("\n", "<br>");
                                pergunta_esp = pergunta_esp.Replace("\n", "<br>");
                                pergunta_ing = pergunta_ing.Replace("\n", "<br>"); ;

                                resposta = resposta.Replace("\n", "<br>");
                                resposta_esp = resposta_esp.Replace("\n", "<br>");
                                resposta_ing = resposta_ing.Replace("\n", "<br>");


                                int sim = 0; int nao = 0;
#pragma warning disable CS0168 // A variável "e" está declarada, mas nunca é usada
                                try
                                {
                                    sim = (int)sheet.GetRow(row).GetCell(19).NumericCellValue;
                                    nao = (int)sheet.GetRow(row).GetCell(20).NumericCellValue;
                                }
                                catch (Exception e) { }
#pragma warning restore CS0168 // A variável "e" está declarada, mas nunca é usada
                                string tipo = "2";
                                if (sim > 0 && nao > 0)
                                {
                                    tipo = "1";
                                }

                                string codPais = "2";
#pragma warning disable CS0168 // A variável "e" está declarada, mas nunca é usada
                                try
                                {
                                    string pais = sheet.GetRow(row).GetCell(21).StringCellValue;
                                    codPais = modeloDAO.carregaCodigoPais(pais.Trim());
                                }
                                catch (Exception e)
                                {

                                }
#pragma warning restore CS0168 // A variável "e" está declarada, mas nunca é usada

                                // insere a linha 
                                string cod_linha = linhaDAO.verificaExiste(linha, tipoArvore, codPais);
                                if (cod_linha.Equals("0"))
                                {

                                    cod_linha = linhaDAO.getProximoRegistro();
                                    linhaDAO.inserindoDados(cod_linha, linha, linha_esp, linha_ing, codPais, tipoArvore);

                                }


                                //insere o produto 
                                string cod_produto = produtoDAO.verificaExiste(produto, cod_linha, tipoArvore, codPais);
                                if (cod_produto.Equals("0"))
                                {

                                    cod_produto = produtoDAO.getProximoRegistro();
                                    produtoDAO.inserindoDados(cod_produto, produto, produto_esp, produto_ing, cod_linha, codPais, tipoArvore);

                                }

                                //context.Response.Write("Verificando modelo : " + modelo);

                                //insere o modelo 
                                string cod_modelo = modeloDAO.verificaExiste(modelo, modelo, modelo, "pt-BR", cod_produto, tipoArvore, codPais);
                              //  context.Response.Write(" - Retorno cod_modelo : " + cod_modelo);
                                
                                if (cod_modelo.Equals("0"))
                                {

                                    cod_modelo = modeloDAO.getProximoRegistro();
                                    string retorno = modeloDAO.inserindoDados(cod_modelo, modelo, modelo_esp, modelo_ing, cod_produto, codPais, "", tipoArvore);
                                }

                                //context.Response.Write(" - Verificando ocorrencia : " + ocorrencia);
                                //insere a ocorrencia 
                                string cod_ocorrencia = ocorrenciaDAO.verificaExiste(ocorrencia, tipoArvore, codPais);

                               // context.Response.Write(" - Retorno cod_ocorrencia : " + cod_ocorrencia);
                                if (!cod_ocorrencia.Equals("0"))
                                {
                                    //context.Response.Write("cod_modelo : " + cod_modelo + " - cod_ocorrencia : " + cod_ocorrencia);
                                    //cod_ocorrencia = ocorrenciaDAO.verificaExiste(cod_ocorrencia, cod_modelo);
                                   // context.Response.Write("retorno - cod_ocorrencia : " + cod_ocorrencia);


                                    //context.Response.Write("Verifica atrelado modelo (cod_ocorrencia) : " + cod_ocorrencia);
                                
                                }


                                if (cod_ocorrencia.Equals("0"))
                                {

                                    cod_ocorrencia = ocorrenciaDAO.getProximoRegistro();
                                    String[] mod = new String[1];
                                    mod[0] = cod_modelo;
                                    ocorrenciaDAO.insereOcorrencia(cod_ocorrencia, ocorrencia, ocorrencia_esp, ocorrencia_ing, codPais, tipoArvore);

                                    ocorrenciaDAO.insereModeloOcorrencia(cod_ocorrencia, mod);

                                }
                                else
                                {
                                    String[] mod = new String[1];
                                    mod[0] = cod_modelo;

                                   if(ocorrenciaDAO.insereModeloOcorrencia(cod_ocorrencia, mod))
                                        ocorrenciaDAO.insereOcorrencia(cod_ocorrencia, ocorrencia, ocorrencia_esp, ocorrencia_ing, codPais, tipoArvore);


                                }


                                // insere as perguntas
                                string cod_pergunta = perguntaDAO.verificaExiste(pergunta, cod_ocorrencia);
                                if (cod_pergunta.Equals("0"))
                                {
                                    pergunta = pergunta.Replace("'", "");
                                    pergunta = pergunta.Replace("'", "");
                                    pergunta = pergunta.Replace("'", "");
                                    pergunta = pergunta.Replace("'", "");
                                    pergunta = pergunta.Replace("'", "");
                                    pergunta = pergunta.Replace("'", "");
                                    pergunta = pergunta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");
                                    resposta = resposta.Replace("'", "");


                                    cod_pergunta = perguntaDAO.getProximoRegistro();
                                    perguntaDAO.inserindoDados(cod_pergunta, cod_ocorrencia, tipo, codigo.ToString(),
                                        sim.ToString(), nao.ToString(), pergunta, pergunta, pergunta,
                                       resposta, resposta_esp, resposta_ing, codPais, tipoArvore, "", "");

#pragma warning disable CS0168 // A variável "e" está declarada, mas nunca é usada
                                    try
                                    {
                                        perguntaDAO.inserindoDadosModelo(cod_pergunta, cod_modelo);
                                    }
                                    catch (Exception e)
                                    {
                                        //context.Response.Write(e.StackTrace);
                                    }
#pragma warning restore CS0168 // A variável "e" está declarada, mas nunca é usada


                                }
                                else
                                {

#pragma warning disable CS0168 // A variável "e" está declarada, mas nunca é usada
                                    try
                                    {
                                        perguntaDAO.inserindoDadosModelo(cod_pergunta, cod_modelo);
                                    }
                                    catch (Exception e)
                                    {
                                        //context.Response.Write(e.StackTrace);
                                    }
#pragma warning restore CS0168 // A variável "e" está declarada, mas nunca é usada
                                }


                                 //grava o historico de importacao
                                perguntaDAO.inserindoHistoricoImportacao(cod_linha, cod_produto, cod_modelo, cod_ocorrencia,
                                    cod_pergunta, codPais, username, tipoArvore);

                              }
                            }
                        }



                        // fecha o arquivo XLS
                        arquivoXLS.Close();

                        //no final deleta o arquivo
                        if (File.Exists(location))
                        {
                            File.Delete(location);
                        }

                        context.Response.Write("Importação finalizada com sucesso.");

                    }
                    else
                    {
                        context.Response.Write("Extensão do arquivo é invalída. Só é permitido arquivo(s) com extensão .xls");
                    }

                
            }
            catch(Exception e)
            {
                //context.Response.Write(e.StackTrace);
            }
#pragma warning restore CS0168 // A variável "e" está declarada, mas nunca é usada
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}