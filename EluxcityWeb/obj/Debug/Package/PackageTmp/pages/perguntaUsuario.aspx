<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="perguntaUsuario.aspx.cs" Inherits="EluxcityWeb.pages.perguntaUsuario" %>
<%
    string tipoAcesso = "administrador";
    string nome = "";
    string pais = "";
    string lblUtil = "Foi Útil:";
    string idioma = "";
    string tipoArvore = "";
    string username = "";
    HttpCookie cookie = Request.Cookies["tipoAcesso"];
    if (cookie != null)
        tipoAcesso = cookie.Value.ToString();

    cookie = Request.Cookies["nome"];
    if (cookie != null)
    {
        nome = cookie.Value.ToString();
        nome = nome.Replace("%20", " ");
    }

    tipoAcesso = Request.Params.Get("tipoAcesso");
    if (tipoAcesso.IndexOf(',') != -1)
    {
        tipoAcesso = tipoAcesso.Split(',')[0];
    }

    tipoAcesso = "usuario";


    cookie = Request.Cookies["pais"];
    if (cookie != null)
    {
        pais = cookie.Value.ToString();
        pais = pais.Replace("%20", " ");
    }else
    {
        pais = "Brazil";
    }

    string urlVolta = "";
    //try
   // {
      //  urlVolta = Session["urlVolta"].ToString();
    //}
  //  catch (Exception ex)
   // {

        cookie = Request.Cookies["urlVolta"];
        if (cookie != null)
        {
            urlVolta = cookie.Value.ToString();
            urlVolta = urlVolta.Replace("%3A", ":");
        }

  //  }

    cookie = Request.Cookies["idioma"];
    if (cookie != null)
    {
        idioma = cookie.Value.ToString();
        idioma = idioma.Replace("%20", " ");
    }else
    {
        idioma = "pt-BR";
    }


    cookie = Request.Cookies["usuario"];
    if (cookie != null)
    {
        username = cookie.Value.ToString();
        username = username.Replace("%20", " ");
    }

    cookie = Request.Cookies["tipoArvore"];
    if (cookie != null)
    {
        tipoArvore = cookie.Value.ToString();
        tipoArvore = tipoArvore.Replace("%20", " ");
    }else
    {
        tipoArvore = "Arvore Produtos";
    }

   // try { tipoArvore = Session["tipoArvore"].ToString(); }
   // catch (Exception ex) { }
    tipoArvore = tipoArvore.Replace("%20", " ");
    string lblUsuario = "Usuário";
    string lblTitulo = "Cadastro de Perguntas/Respostas";
    string lblLista = "Listagem de Perguntas";
    string lblCancelar = "Cancelar";
    string lblSalvar = "Salvar";
    string lblMenu1 = "Modelo";
    string lblLinha = "Linha";
    string lblProduto = "Produto";
    string lblVoltar = "Voltar";
    string lblMenu2 = "Ocorrência";
    string lblCadastro = "Cadastro";
    string lblSim = "Sim";
    string lblNao = "Não";
    string lblListagem = "Listagem";
    string lblNova = "Nova Pergunta";
    string lblArvore = "Arvore de Decisão";
    string lblComentario = "Comentário";
    string lblFechar = "Fechar";
    string proxima = "Vai para a próxima pergunta: ";

    string lblEnvio = "Dados enviados com sucesso.";


    if (idioma.Equals("en-US"))
    {
        proxima = "Go to the next question: ";
        lblUsuario = "User";
        lblNova = "New Question";
        lblTitulo = "Register of Questions / Answers";
        lblLista = "List of Questions";
        lblCancelar = "Cancel";
        lblSalvar = "Save";
        lblLinha = "Line";
        lblProduto = "Product";
        lblMenu1 = "Model";
        lblUtil = "Was useful:";
        lblMenu2 = "Ocurrencia";
        lblSim = "Yes";
        lblNao = "No";
        lblCadastro = "Register";
        lblListagem = "List";
        lblVoltar = "Back";
        lblEnvio = "Data sent successfully.";
        lblArvore = "Decision tree";
        lblComentario = "Comment";
        lblFechar = "Close";
    }
    else if (idioma.Equals("es-ES"))
    {
        proxima = "Ir a la siguiente pregunta: ";
        lblUsuario = "Usuario";
        lblTitulo = "Register de Preguntas / Respuestas";
        lblLista = "Lista de Preguntas";
        lblCancelar = "Cancel";
        lblSalvar = "Guardar";
        lblMenu1 = "Model";
        lblLinha = "Línea";
        lblProduto = "Producto";
        lblUtil = "Fue util:";
        lblSim = "Sí";
        lblNao = "No";
        lblMenu2 = "Ocurrencia";
        lblCadastro = "Register";
        lblListagem = "Lista";
        lblNova = "Nueva Pregunta";
        lblVoltar = "Retorno";
        lblComentario = "Comentario";
        lblEnvio = "Los datos enviados con éxito.";
        lblArvore = "Árbol de decisión";
        lblFechar = "Cierra";
    }


    string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";
    if (pais.Equals("Brazil"))
    {

        if (tipoArvore.Equals("Arvore Solution Center"))
        {
            tipoMenu1 = "Produto";
            tipoMenu2 = "Modelo";
        }
    }


    string idUser = Request.Params.Get("idUser");
    string user = Request.Params.Get("usuario");
    if(idUser != "" && idUser != null)
    {
        if (idUser.IndexOf(',') != -1)
        {
            idUser = idUser.Split(',')[0];
        }
        if (user.IndexOf(',') != -1)
        {
            user = user.Split(',')[0];
        }
    }else
    {
        idUser = "";
    }
    
    urlVolta = "index.aspx?idUser=" + idUser + "&username=" + user + "&tipoAcesso=" + tipoAcesso;


%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
   

       <script src="../includes/arvore/js/jquery-1.10.2.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery-ui-1.10.4.custom.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery.alerts.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap.js"  type="text/javascript"></script>
   <% if (idioma.Equals("en-US")){ %>
              <script src="../includes/arvore/js/bootstrap-table-ing.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect-ing.js"></script>
     <% }else if (idioma.Equals("es-ES")){ %>
                 <script src="../includes/arvore/js/bootstrap-table-esp.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect-esp.js"></script>
     <% }else{ %>
                <script src="../includes/arvore/js/bootstrap-table.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect.js"></script>
      <% } %>
    <script src="../includes/arvore/js/bootstrap-tagsinput.js"  type="text/javascript"></script>

    <script src="../includes/arvore/tinymce/js/tinymce/tinymce.min.js"></script>
    <script src="../includes/arvore/tinymce/js/tinymce/jquery.tinymce.min.js"></script>
    <script src="../includes/arvore/js/bootstrap.min.js"></script>

  

    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/> 


</head>
    <script>
        var sUtil = "N";
        var $j = jQuery.noConflict();

        telaAtual = "perguntas";
        var tipo;
        var ordemProxSeSim;
        var ordemProxSeNao;
        var codigoPergunta = '0';
        var codigoOcorrencia = location.search.substring(18);

      

        codigoOcorrencia = codigoOcorrencia.replace('&codPesquisa=', ',');
        codigoOcorrencia = codigoOcorrencia.replace('&codModelo=', ',');
        codigoOcorrencia = codigoOcorrencia.replace('&codLinha=', ',');
        codigoOcorrencia = codigoOcorrencia.replace('&codProduto=', ',');

        //alert(codigoOcorrencia);
      
        var aDados = codigoOcorrencia.split(",");
        codigoOcorrencia = aDados[0];
        var codigoPesquisa = aDados[1];
        var codModelo = aDados[2];
        var codLinha = aDados[3];
        var codProduto = aDados[4];

      

        var codigoPesquisaComentario = "0";
        var codigoPerguntaComentario = "0";
        var cod_pergunta = "0";
        var nomeOcorrencia = "";
        var nomeModelo = "";
        var nomeProduto = "";
        var nomeLinha = "";

        $j.ajax({
            type: "POST",
            url: "pergunta.aspx/carregaNomeOcorrencia",
            data: "{codigo:'" + codigoOcorrencia + "',  idioma:'<%=idioma %>'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {

                var aDados = jasonResult.d;
                nomeOcorrencia = aDados;

                $j.ajax({
                    type: "POST",
                    url: "pergunta.aspx/carregaNomeModelo",
                    data: "{codigo:'" + codModelo + "',  idioma:'<%=idioma %>'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (jasonResult) {
                        var aDados = jasonResult.d;
                        nomeModelo = aDados;

                        $j.ajax({
                            type: "POST",
                            url: "pergunta.aspx/carregaNomeProduto",
                            data: "{codigo:'" + codProduto + "',  idioma:'<%=idioma %>'}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (jasonResult) {
                                var aDados = jasonResult.d;
                                nomeProduto = aDados;

                                $j.ajax({
                                    type: "POST",
                                    url: "pergunta.aspx/carregaNomeLinha",
                                    data: "{codigo:'" + codLinha + "',  idioma:'<%=idioma %>'}",
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    success: function (jasonResult) {
                                        var aDados = jasonResult.d;
                                        nomeLinha = aDados;

                                        document.getElementById('nome').innerHTML = nomeLinha + " / " + nomeProduto + " / " + nomeModelo + " / " + nomeOcorrencia;
                                        //$j("#nome").text(aDados);
                                    }
                                });

                            }
                        });

                    }
                });









              


            }
        });
       

        var codPais = "<%=pais %>";

        var usuario = "<%=nome%>";
      
       
        tinymce.init({
            selector: '#respostaPor',
            height: 50,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools textcolor"
            ],
            toolbar: "undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        tinymce.init({
            selector: '#respostaIng',
            height: 50,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor textcolor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools"
            ],
            toolbar: "undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        tinymce.init({
            selector: '#respostaEsp',
            height: 50,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor textcolor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools"
            ],
            toolbar: "undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        carregaDadosTabela();

        function carregaDadosTabela() {

           

            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/carregaPerguntas",
                data: "{limit: " + limit + ", offset: " + paginaAtual + " , usuario:'" + usuario + "', codPergunta:'0', codigoOcorrencia:'" + codigoOcorrencia + "', codigoPesquisa:'" + codigoPesquisa + "', codPais:'" + codPais + "' , tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>' , codModelo:'" + codModelo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    $j('#table-pergunta').bootstrapTable('destroy');
                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);

                    <% if (idioma.Equals("en-US")){ %>

                    $j('#table-pergunta').bootstrapTable({
                        data: obj,
                        cache: false,
                        height: 550,
                        pagination: true,
                        pageSize: limit,
                        totalRows: total,
                        pageNumber: paginaAtual,
                        search: true,
                        showColumns: false,
                        showRefresh: false,
                        sidePagination: 'server',
                        minimumCountColumns: 2,
                        clickToSelect: true,
                        columns: [{
                            field: 'cod_pergunta',
                            width: 1
                        }, {
                            field: 'redacao_pergunta_ing',
                            title: 'Question',
                           // width: 'auto !important',
                            // align: 'left',
                            // valign: 'middle',
                            sortable: true
                        }, {
                            field: 'resposta_ing',
                            title: 'Answer',
                           // width: 'auto !important',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'comentario',
                            title: 'Evaluation',
                           // width: 'auto !important',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }]
                    });
                    $j('#table-pergunta').bootstrapTable('hideColumn', 'cod_pergunta');

                    <% }else if (idioma.Equals("es-ES")){ %>

                    $j('#table-pergunta').bootstrapTable({
                        data: obj,
                        cache: false,
                        height: 550,
                        pagination: true,
                        pageSize: limit,
                        totalRows: total,
                        pageNumber: paginaAtual,
                        search: true,
                        showColumns: false,
                        showRefresh: false,
                        sidePagination: 'server',
                        minimumCountColumns: 2,
                        clickToSelect: true,
                        columns: [{
                            field: 'cod_pergunta',
                            width: 1
                        }, {
                            field: 'redacao_pergunta_esp',
                            title: 'Pregunta',
                          //  width: 'auto !important',
                            // align: 'left',
                            // valign: 'middle',
                            sortable: true
                        }, {
                            field: 'resposta_esp',
                            title: 'Respuesta',
                          //  width: 'auto !important',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'comentario',
                            title: 'Evaluación',
                           // width: 'auto !important',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }]
                    });
                    $j('#table-pergunta').bootstrapTable('hideColumn', 'cod_pergunta');

                    <% } else { %>

                    $j('#table-pergunta').bootstrapTable({
                        data: obj,
                        cache: false,
                        height: 550,
                        pagination: true,
                        pageSize: limit,
                        totalRows: total,
                        pageNumber: paginaAtual,
                        search: true,
                        showColumns: false,
                        showRefresh: false,
                        sidePagination: 'server',
                        minimumCountColumns: 2,
                        clickToSelect: true,
                        columns: [{
                            field: 'cod_pergunta',
                            width: 1
                        }, {
                            field: 'redacao_pergunta_por',
                            title: 'Pergunta',
                          //  width: 'auto !important',
                            // align: 'left',
                            // valign: 'middle',
                            sortable: true
                        }, {
                            field: 'resposta_por',
                            title: 'Resposta',
                           // width: 'auto !important',
                            align: 'center',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'comentario',
                            title: 'Avaliação',
                           // width: 'auto !important',
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }]
                    });
                    $j('#table-pergunta').bootstrapTable('hideColumn', 'cod_pergunta');


                    <% } %>




                }
            });

        }

        function carregaPerguntaCondicional(codPergunta) {
            //cod_pergunta = codPergunta;
            // carregaDadosTabela(codPergunta);


            // esse trecho carrega a resposta da pergunta para ser exibida na tela
            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/carregaResposta",
                data: "{codigo:'" + codPergunta + "',  idioma:'<%=idioma %>', tipo:'C'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;
                    dados = '<%=proxima%>' + dados;
                    $j('#myModalResposta .modal-body').html(dados);
                    $j('#myModalResposta').modal('show');
                }

            });

        }

        function cancelar() {
            location.reload();
        }

        function loadingTable(divID) {

            var html = " <div class='table-loading-overlay'>"
                + " <div class='table-loading-inner'>"
                + "<div class=\"col-xs-4 col-xs-offset-4\">"
                + "<div class=\"progress\"> "
                + "<div class=\"progress-bar progress-bar-striped progress-bar-streit active\" role=\"progressbar\" aria-valuenow=\"100\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: 100%\">"
                + "        <span class=\"sr-only\">Loading...</span>"
                + "    </div>"
                + "    </div>"
                + " </div>"
                + " </div>"
                + " </div>";
            $('#' + divID).append(html);
        }

        function carregaComboOrdem() {

            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/carregaComboOrdem",
                data: "{codigoOcorrencia:'" + codigoOcorrencia + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    document.getElementById('ordemProxSeSim').innerHTML = dados;
                    document.getElementById('ordemProxSeNao').innerHTML = dados;



                }
            });
        }

       

        function visualizarRegistro(codigo) {



            // esse trecho carrega a resposta da pergunta para ser exibida na tela
            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/carregaResposta",
                data: "{codigo:'" + codigo + "',  idioma:'<%=idioma %>', tipo:'A'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;
                    $j('#myModalResposta .modal-body').html(dados);
                    $j('#myModalResposta').modal('show');
                }

            });


        }

      

        function retornaTipo() {

            tipo = $j("#tipo option:selected").val();

            if (tipo == '1') {
                document.getElementById('labelOrdem').style.display = "";
                document.getElementById('ordem').style.display = "";
                document.getElementById('labelOrdemProxSeSim').style.display = "";
                document.getElementById('ordemProxSeSim').style.display = "";
                document.getElementById('labelOrdemProxSeNao').style.display = "";
                document.getElementById('ordemProxSeNao').style.display = "";
                document.getElementById('labelRespostaPor').style.display = "none";
                tinymce.editors['respostaPor'].hide();
                document.getElementById('labelRespostaIng').style.display = "none";
                tinymce.editors['respostaIng'].hide();
                document.getElementById('labelRespostaEsp').style.display = "none";
                tinymce.editors['respostaEsp'].hide();
                carregaComboOrdem();
            } else if (tipo == '2') {
                document.getElementById('labelOrdemProxSeSim').style.display = "none";
                document.getElementById('ordemProxSeSim').style.display = "none";
                document.getElementById('labelOrdemProxSeNao').style.display = "none";
                document.getElementById('ordemProxSeNao').style.display = "none";
                document.getElementById('labelOrdem').style.display = "";
                document.getElementById('ordem').style.display = "";
                document.getElementById('labelRespostaPor').style.display = "";
                tinymce.editors['respostaPor'].show();
                document.getElementById('labelRespostaIng').style.display = "";
                tinymce.editors['respostaIng'].show();
                document.getElementById('labelRespostaEsp').style.display = "";
                tinymce.editors['respostaEsp'].show();
                ordemProxSeSim = '';
                ordemProxSeNao = '';
            } else if (tipo == '0') {
                document.getElementById('labelOrdemProxSeSim').style.display = "none";
                document.getElementById('ordemProxSeSim').style.display = "none";
                document.getElementById('labelOrdemProxSeNao').style.display = "none";
                document.getElementById('ordemProxSeNao').style.display = "none";
                document.getElementById('labelOrdem').style.display = "none";
                document.getElementById('ordem').style.display = "none";
                document.getElementById('labelRespostaPor').style.display = "none";
                tinymce.editors['respostaPor'].hide();
                document.getElementById('labelRespostaIng').style.display = "none";
                tinymce.editors['respostaIng'].hide();
                document.getElementById('labelRespostaEsp').style.display = "none";
                tinymce.editors['respostaEsp'].hide();

            }
        }


        function retornaOrdemProxSeSim() {
            ordemProxSeSim = $j("#ordemProxSeSim option:selected").val();
        }

        function retornaOrdemProxSeNao() {
            ordemProxSeNao = $j("#ordemProxSeNao option:selected").val();
        }

        function voltar() {
            /*if (cod_pergunta != '0') {
                cod_pergunta = '0';
                carregaDadosTabela(cod_pergunta);
            } else {*/
                // ver depois pra passar os parametros
                document.location.href = "ocorrenciaUsuario.aspx?tipoAcesso=usuario&idUser=&usuario=<%=username%>&pais=<%=pais%>&tipoArvore=<%=tipoArvore%>";
           // }
          
           
        }

        function setUtil(util) {
            sUtil = util;
        }

        function validaPergunta(dados) {
            var adados = dados.split(",");
            var codigoPesquisa = adados[0];
            var tipo = adados[1];
            var codigoPergunta = adados[2];

            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/salvaValidacao",
                data: "{usuario:'" + usuario + "', codigoPesquisa:'" + codigoPesquisa + "', tipo:'" + tipo + "', util:'" + sUtil + "', codigoPergunta:'" + codigoPergunta + "', redacao:''}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    alert("<%=lblEnvio%>");

                }
            });
        }

        function comentarioPergunta(dados) {
            var adados = dados.split(",");
            codigoPesquisaComentario = adados[0];
            codigoPerguntaComentario = adados[1];


            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/carregaComentario",
                data: "{codigoPesquisa:'" + codigoPesquisaComentario + "',codigoPergunta:'" + codigoPerguntaComentario + "', codComentario:'0'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    $j('#myModal').modal('show');
                    document.getElementById('comment').value = "";

                    //if (util == 'True')
                        document.getElementById('checksimc').checked = false;
                   // else {
                        document.getElementById('checknaoc').checked = false;
                   // }

                    /*var aDados = jasonResult.d.split(";");
                    var coment = aDados[0];
                    var util = aDados[1];
                    alert(util);
                    document.getElementById('comment').value = coment;
                    */

                }
            });


          


        }


        function comentarioPerguntaVisualiza(dados) {
           // var adados = dados.split(",");
           // codigoPesquisaComentario = adados[0];
           // codigoPerguntaComentario = adados[1];


            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/carregaComentario",
                data: "{codigoPesquisa:'0',codigoPergunta:'0', codComentario:'"+dados+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    $j('#myModalVisualiza').modal('show');

                    var aDados = jasonResult.d.split(";");
                    var coment = aDados[0];
                    var util = aDados[1];
                   // alert(coment);
                   // alert(util);
                    document.getElementById('commentVisualiza').value = coment;

                    if (util == 'True')
                        document.getElementById('checksim').checked = true;
                    else {
                        document.getElementById('checknao').checked = true;
                    }

                    //document.getElementById('comment').value = jasonResult.d;


                }
            });





        }

        function salvaComentario() {

            var redacao = document.getElementById('comment').value;

            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/salvaValidacao",
                data: "{usuario:'" + usuario + "', codigoPesquisa:'" + codigoPesquisaComentario + "', tipo:'', util:'" + sUtil + "', codigoPergunta:'" + codigoPerguntaComentario + "', redacao:'" + redacao + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {
                    $j('#myModal').modal('hide');
                    alert("<%=lblEnvio%>");

                    carregaDadosTabela();

                }
            });
        }

    </script>
<body>
     <div class="container-fluid">


         <br />
   <% if(tipoAcesso.Equals("usuario")){  %>
     <ul>
            <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2 %></a></li>
        </ul>    

         <%}else{ %>
              <% if(pais.Equals("Brazil")){  %>
                         <ul>
                              <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                            <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>"  >Linha</a></li>
                           <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Ocorr&ecirc;ncias</a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Importa&ccedil;&atilde;o de Dados</a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Relat&oacute;rios de uso do Sistema</a></li>
                        </ul>    

              
              <%}else{ %>
                   <% if(tipoArvore.Equals("Arvore Solution Center")){ %>

                          <ul>
                               <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu1 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2 %></a></li>
                           
                        </ul>    

                   <%}else{ %>

                         <ul>
                              <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=lblMenu2 %></a></li>
                           
                        </ul>    

                   <%}%>

              <%}%>

  
         <%} %>
   



    <div class="modal-body">

         <!-- Modal -->
  <div class="modal fade" role="dialog" id="myModal">
    <div class="vertical-alignment-helper">    
        <div class="modal-dialog vertical-align-center">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><%=lblArvore %></h4>
        </div>
        <div class="modal-body" style="height:350px; overflow:auto; ">



            <table>
				       <tr style="height:30px;"><Td style="width: 80px;"> <label ><%=lblUtil %></label></Td><td><td style="width: 10px;">&nbsp;</td>
				          <td>
				              <label class="radio-inline"><input type="radio" name="optradiotipo" id="checksimc" onchange="setUtil('S')" ><%=lblSim %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
				          </td>
                           <tb>&nbsp;&nbsp;&nbsp;</tb>
                           <td>
				              <label class="radio-inline"><input type="radio" name="optradiotipo" id="checknaoc" onchange="setUtil('N')" ><%=lblNao %></label>
				          </td>
				      
				       </tr> 
</table>


            <label for="comment"><%=lblComentario %>:</label>
           <textarea class="form-control" rows="10" id="comment"></textarea>
          
        </div>
        <div class="modal-footer">
            <button type="button" class="btn btn-primary" data-dismiss="modal"  onclick="salvaComentario();"><%=lblSalvar %></button>
          <button type="button" class="btn btn-default" data-dismiss="modal"><%=lblCancelar %></button>
        </div>
      </div>
      
    </div>
        </div>
  </div>






         <div class="modal fade" role="dialog" id="myModalVisualiza">
    <div class="vertical-alignment-helper">    
        <div class="modal-dialog vertical-align-center">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><%=lblArvore %></h4>
        </div>
        <div class="modal-body" style="height:350px; overflow:auto; ">



            <table>
				       <tr style="height:30px;"> <Td style="width: 80px;"> <label ><%=lblUtil %></label></Td><td><td style="width: 10px;">&nbsp;</td>
				          <td>
				              <label class="radio-inline"><input type="radio" name="optradiotipo" id="checksim" onchange="setUtil('S')" ><%=lblSim %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
				          </td>
                           <tb>&nbsp;&nbsp;&nbsp;</tb>
                           <td>
				              <label class="radio-inline"><input type="radio" name="optradiotipo" id="checknao"  onchange="setUtil('N')" ><%=lblNao %></label>
				          </td>
				      
				       </tr> 
</table>


            <label for="comment"><%=lblComentario %>:</label>
           <textarea class="form-control" rows="10" id="commentVisualiza"></textarea>
          
        </div>
        <div class="modal-footer">
         <button type="button" class="btn btn-default" data-dismiss="modal"><%=lblFechar %></button>
        </div>
      </div>
      
    </div>
        </div>
  </div>
  
      

          <!-- Modal -->
  <div class="modal fade" role="dialog" id="myModalResposta">
    <div class="vertical-alignment-helper">    
        <div class="modal-dialog vertical-align-center">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><%=lblArvore %></h4>
        </div>
        <div class="modal-body" style="height:350px; overflow:auto; ">

          
        </div>
        <div class="modal-footer">
         <button type="button" class="btn btn-default" data-dismiss="modal"><%=lblFechar %></button>
        </div>
      </div>
      
    </div>
        </div>
  </div>
  
    <div class="table-responsive">
      <table class="table"><tr>
          <td>&nbsp;</td>
          <td>              
         <div id="listagem">
          <div class="panel panel-primary">
              <div class="panel-heading"><%=lblLista %></div>
              <legend class="scheduler-border"><%=lblLinha %> / <%=lblProduto %> / <%=lblMenu1 %> / <%=lblMenu2 %>: <span id="nome" style="font-weight: bold;"> </span> </legend>
              <table id="table-pergunta" style="margin-top: 0px"></table>


           </div>

     </div> 
                  </div>  
      </td>
          <td>&nbsp;</td>          
                          </tr></table>   
        
        <div class="modal-footer">
                    <button type="button" class="btn btn-primary" onclick="voltar();"><%=lblVoltar %></button>
                  </div> 


 </div> 
    
    
    <div class="modal fade" role="dialog" id="myModal">
    <div class="vertical-alignment-helper">    
        <div class="modal-dialog vertical-align-center">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><%=lblArvore %></h4>
        </div>
        <div class="modal-body" style="height:350px; overflow:auto; ">
          

        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal"><%=lblVoltar %></button>
        </div>
      </div>
      
    </div>
        </div>
  </div>   
</div>
</body>
</html>
