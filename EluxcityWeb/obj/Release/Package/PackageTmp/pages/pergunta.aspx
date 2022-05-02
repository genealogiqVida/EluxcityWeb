<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pergunta.aspx.cs" Inherits="EluxcityWeb.pages.pergunta" %>
<%
    string tipoAcesso = "administrador";
    string nome = "";
    string pais = "";
    string idioma = "";
    string tipoArvore = "";
    string username = "";
    HttpCookie cookie = Request.Cookies["tipoAcesso"];
    if (cookie != null)
        tipoAcesso = cookie.Value.ToString();


    tipoAcesso = Request.Params.Get("tipoAcesso");
    if (tipoAcesso.IndexOf(',') != -1)
    {
        tipoAcesso = tipoAcesso.Split(',')[0];
    }

    cookie = Request.Cookies["nome"];
    if (cookie != null)
    {
        nome = cookie.Value.ToString();
        nome = nome.Replace("%20", " ");
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

    cookie = Request.Cookies["pais"];
    if (cookie != null)
    {
        pais = cookie.Value.ToString();
        pais = pais.Replace("%20", " ");
    }

    cookie = Request.Cookies["idioma"];
    if (cookie != null)
    {
        idioma = cookie.Value.ToString();
        idioma = idioma.Replace("%20", " ");
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
    }
    //tipoArvore = Session["tipoArvore"].ToString();
    tipoArvore = tipoArvore.Replace("%20", " ");

    string lblUsuario = "Usuário";
    string lblTitulo = "Cadastro de Perguntas/Respostas";
    string lblLista = "Listagem de Perguntas";
    string lblCancelar = "Cancelar";
    string lblSalvar = "Salvar";
    string lblMenu1 = "Modelo";
    string lblVoltar = "Voltar";
    string lblMenu2 = "Ocorrência";
    string lblCadastro = "Cadastro";
    string lblListagem = "Listagem";
    string lblNova = "Nova Pergunta";

    string lblArvore = "Arvore de Decisão";
    string lblComentario = "Comentário";
    string lblFechar = "Fechar";
    string proxima = "Vai para a próxima pergunta: ";

    
        if (idioma.Equals("en-US"))
        {
            proxima = "Go to the next question: ";
            lblUsuario = "User";
            lblNova = "New Question";
            lblTitulo = "Register of Questions / Answers";
            lblLista = "List of Questions";
            lblCancelar = "Cancel";
            lblSalvar = "Save";
            lblArvore = "Decision tree";
            lblComentario = "Comment";
            lblFechar = "Close";
            lblMenu1 = "Model";
            lblMenu2 = "Ocurrencia";
             lblCadastro = "Register";
             lblListagem = "List";
             lblVoltar = "Back";
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
            lblMenu2 = "Ocurrencia";
            lblCadastro = "Register";
            lblListagem = "Lista";
            lblNova = "Nueva Pregunta";
            lblVoltar = "Retorno";
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
        if (idUser.IndexOf(',') != -1)
        {
            idUser = idUser.Split(',')[0];
        }
        if (user.IndexOf(',') != -1)
        {
            user = user.Split(',')[0];
        }
        urlVolta = "index.aspx?idUser=" + idUser + "&username=" + user;

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
     <% }else if (idioma.Equals("es-ES")){ %>
                 <script src="../includes/arvore/js/bootstrap-table-esp.js" type="text/javascript"></script>
     <% }else{ %>
                <script src="../includes/arvore/js/bootstrap-table.js" type="text/javascript"></script>
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

        var $j = jQuery.noConflict();
        var $l = jQuery.noConflict();
        var codPais = "<%=pais %>";

        var tipo = '0';
        var ordemProxSeSim = 0;
        var ordemProxSeNao = 0;
        var codigoPergunta = 0;
        var codigoOcorrencia = location.search.substring(18);
        codigoOcorrencia = codigoOcorrencia.replace('&codModelo=', ',');
        var aDados = codigoOcorrencia.split(",");
        codigoOcorrencia = aDados[0];
        var codModelo = aDados[1];
        var nomeOcorrencia = "";

        telaAtual = "perguntas";

        $j.ajax({
            type: "POST",
            url: "pergunta.aspx/carregaNomeOcorrencia",
            data: "{codigo:'" + codigoOcorrencia + "',  idioma:'<%=idioma %>'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (jasonResult) {

                var aDados = jasonResult.d;
                nomeOcorrencia = aDados;
               
                document.getElementById('nome').innerHTML = nomeOcorrencia;
                //$j("#nome").text(aDados);


            }
        });

        <% if (idioma.Equals("en-US")){ %>

        
        tinymce.init({
            selector: '#respostaIng',
            theme_advanced_fonts: "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            height: 250,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor textcolor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools"
            ],
            toolbar: "undo redo | styleselect | fontselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        

        <% }else if (idioma.Equals("es-ES")){ %>

        

        tinymce.init({
            selector: '#respostaEsp',
            theme_advanced_fonts: "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            height: 250,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor textcolor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools"
            ],
            toolbar: "undo redo | styleselect | fontselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        <% } else { %>

        <% if (pais.Equals("Brazil")){ %>

        tinymce.init({
            selector: '#respostaPor',
            theme_advanced_fonts: "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            height: 250,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools textcolor"
            ],
            toolbar: "undo redo | styleselect | fontselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        tinymce.init({
            selector: '#respostaIng',
            theme_advanced_fonts: "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            height: 250,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor textcolor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools"
            ],
            toolbar: "undo redo | styleselect | fontselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        tinymce.init({
            selector: '#respostaEsp',
            theme_advanced_fonts: "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            height: 250,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor textcolor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools"
            ],
            toolbar: "undo redo | styleselect | fontselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

        <% } else { %>

        tinymce.init({
            selector: '#respostaPor',
            theme_advanced_fonts: "Arial=arial,helvetica,sans-serif;Courier New=courier new,courier,monospace;AkrutiKndPadmini=Akpdmi-n",
            height: 250,
            menubar: false,
            plugins: [
            "advlist autolink lists link image charmap print preview anchor",
            "searchreplace visualblocks code fullscreen",
            "insertdatetime media table contextmenu paste imagetools textcolor"
            ],
            toolbar: "undo redo | styleselect | fontselect | bold italic | alignleft aligncenter alignright alignjustify forecolor backcolor| bullist numlist outdent indent | link image media | charmap code",
            imagetools_cors_hosts: ['www.tinymce.com', 'codepen.io'],
            content_css: [
              '//fast.fonts.net/cssapi/e6dc9b99-64fe-4292-ad98-6974f93cd2a2.css',
              '//www.tinymce.com/css/codepen.min.css'
            ]
        });

       
       
        <% } 
         } %>

        function carregaDadosTabela(){

        $j.ajax({
            type: "POST",
            url: "pergunta.aspx/carregaPerguntas",
            data: "{limit: " + limit + ", offset: " + paginaAtual + " , usuario:'<%=nome %>',  codPergunta:'0', codigoOcorrencia:'" + codigoOcorrencia + "', codigoPesquisa:'0', codPais:'" + codPais + "' , tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>', codModelo:'" + codModelo + "'}",
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
                        //width: 700,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'resposta_ing',
                        title: 'Answer',
                        //width: 10,
                        align: 'center',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'ordem',
                        title: 'Ordem',
                       // width: 30,
                        align: 'center',
                        valign: 'middle',
                        sortable: true
                    },{
                        field: 'alterar',
                        title: 'Edit',
                      //  width: 20,
                        align: 'center',
                        valign: 'middle'
                    }, {
                        field: 'excluir',
                        title: 'Remove',
                       // width: 20,
                        align: 'center',
                        valign: 'middle'
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
                      //  width: 700,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'resposta_esp',
                        title: 'Respuesta',
                       // width: 10,
                        align: 'center',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'ordem',
                        title: 'Ordem',
                       // width: 30,
                        align: 'center',
                        valign: 'middle',
                        sortable: true
                    },{
                        field: 'alterar',
                        title: 'Editar',
                       // width: 20,
                        align: 'center',
                        valign: 'middle'
                    }, {
                        field: 'excluir',
                        title: 'Eliminar',
                       // width: 20,
                        align: 'center',
                        valign: 'middle'
                    }]
                });
                $j('#table-pergunta').bootstrapTable('hideColumn', 'cod_pergunta');

                <% } else { %>

                <% if (pais.Equals("Brazil")){ %>

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
                       // width: 700,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'resposta_por',
                        title: 'Resposta',
                      //  width: 10,
                        align: 'center',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'ordem',
                        title: 'Ordem',
                       // width: 30,
                        align: 'center',
                        valign: 'middle',
                        sortable: true
                    },{
                        field: 'alterar',
                        title: 'Editar',
                       // width: 20,
                        align: 'center',
                        valign: 'middle'
                    }, {
                        field: 'excluir',
                        title: 'Remover',
                       // width: 20,
                        align: 'center',
                        valign: 'middle'
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
                      //  width: 650,
                        align: 'left',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'resposta_por',
                        title: 'Resposta',
                       // width: 20,
                        align: 'center',
                        valign: 'middle',
                        sortable: true

                    }, {
                        field: 'ordem',
                        title: 'Ordem',
                      //  width: 30,
                        align: 'center',
                        valign: 'middle',
                        sortable: true
                    }, {
                        field: 'alterar',
                        title: 'Editar',
                        //width: 20,
                        align: 'center',
                        valign: 'middle'
                    }, {
                        field: 'excluir',
                        title: 'Remover',
                       // width: 20,
                        align: 'center',
                        valign: 'middle'
                    }]
                });
                $j('#table-pergunta').bootstrapTable('hideColumn', 'cod_pergunta');


                <% } %>



                    

                    <% } %>


                

            }
        });

        }

        $j('document').ready(function () {

            carregaDadosTabela();

            telaAtual = "perguntas";

            $l.ajax({
                type: "POST",
                url: "pergunta.aspx/carregaComboOrdem",
                data: "{codigoOcorrencia:'" + codigoOcorrencia + "', codPais:'" + codPais + "',  tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    try {
                        document.getElementById('ordemProxSeSim').innerHTML = dados;
                        document.getElementById('ordemProxSeNao').innerHTML = dados;
                    } catch (e) { }


                }
            });

        });

        function cancelar() {

            clearChildren(document.getElementById('cadastro'));
            try { tinyMCE.get('respostaPor').setContent(''); } catch (e) { }
            try { tinyMCE.get('respostaEsp').setContent(''); } catch (e) { }
            try { tinyMCE.get('respostaIng').setContent(''); } catch (e) { }

            $j('.nav-tabs a[href="#home"]').tab('show');
        }

        function novaPergunta() {

            clearChildren(document.getElementById('cadastro'));
            try{tinyMCE.get('respostaPor').setContent(''); }catch(e){}
            try{tinyMCE.get('respostaEsp').setContent('');}catch(e){}
            try { tinyMCE.get('respostaIng').setContent(''); } catch (e) { }

            document.getElementById('labelOrdemProxSeSim').style.display = "none";
            document.getElementById('ordemProxSeSim').style.display = "none";
            document.getElementById('labelOrdemProxSeNao').style.display = "none";
            document.getElementById('ordemProxSeNao').style.display = "none";
            document.getElementById('labelOrdem').style.display = "none";
            document.getElementById('ordem').style.display = "none";
            try { document.getElementById('labelRespostaPor').style.display = "none"; } catch (e) { }
            try { tinymce.editors['respostaPor'].hide(); } catch (e) { }
            try { document.getElementById('labelRespostaIng').style.display = "none"; } catch (e) { }
            try { tinymce.editors['respostaIng'].hide(); } catch (e) { }
            try { document.getElementById('labelRespostaEsp').style.display = "none"; } catch (e) { }
            try { tinymce.editors['respostaEsp'].hide(); } catch (e) { }


            $j('.nav-tabs a[href="#profile"]').tab('show');           
            
        }

        function voltar() {
            window.location.href = "ocorrencia.aspx";
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
        
        function salvarDados() {
            var respostaPor = "";
            try { respostaPor = tinyMCE.get('respostaPor').getContent({ format: 'raw' }); } catch (e) { }
            var respostaIng = "";
            try { respostaIng = tinyMCE.get('respostaIng').getContent({ format: 'raw' }); } catch (e) { }

            var respostaEsp = "";
            try { respostaEsp = tinyMCE.get('respostaEsp').getContent({ format: 'raw' }); } catch (e) { }


            if (tipo == '0') {

               

               

                <% if (idioma.Equals("en-US")){ %>
                jAlert('Tell Typeo!', 'Decision tree');
                <% }else if (idioma.Equals("es-ES")){ %>
                jAlert('Dile Tipo!', 'Árbol de decisión');
                <% }else{ %>
                jAlert('Informe o Tipo!', 'Arvore de Decisão');
                            <% } %>


              
            }
            else if (document.getElementById('redacaoPerguntaPor').value == '' && document.getElementById('redacaoPerguntaIng').value == ''
                 && document.getElementById('redacaoPerguntaEsp').value == '') {
               
                 <% if (idioma.Equals("en-US")){ %>
                jAlert('Enter the question!', 'Decision tree');
                <% }else if (idioma.Equals("es-ES")){ %>
                jAlert('Introduzca la pregunta!', 'Árbol de decisión');
                <% }else{ %>
                jAlert('É necessário informar o nome nos 3 idiomas!', 'Arvore de Decisão');
                            <% } %>


            }


           
            
           
            else {

                var redacaoPerguntaPor = "";
                try { redacaoPerguntaPor = document.getElementById('redacaoPerguntaPor').value.trim(); } catch (e) { }
                var redacaoPerguntaIng = "";
                try { redacaoPerguntaIng = document.getElementById('redacaoPerguntaIng').value.trim(); } catch (e) { }
                var redacaoPerguntaEsp = "";
                try { redacaoPerguntaEsp= document.getElementById('redacaoPerguntaEsp').value.trim(); } catch (e) { }

                var ordem = document.getElementById('ordem').value.trim();
               


                codigoPergunta = document.getElementById('codigo').value;

             
                if (tipo == '2') {

                    if (respostaPor == '<p><br data-mce-bogus="1"></p>' || respostaIng == '<p><br data-mce-bogus="1"></p>' || respostaEsp == '<p><br data-mce-bogus="1"></p>') {

                       <% if (idioma.Equals("en-US")){ %>
                       jAlert('Enter the answer!', 'Decision tree');
                       <% }else if (idioma.Equals("es-ES")){ %>
                       jAlert('Introduzca la respuesta!', 'Árbol de decisión');
                       <% }else{ %>
                       jAlert('É necessário informar a resposta nos 3 idiomas!', 'Arvore de Decisão');
                       <% } %>


                 } else {

                     $j.ajax({
                         type: "POST",
                         url: "pergunta.aspx/salvarDados",
                         data: "{codigoPergunta:'" + codigoPergunta + "',codigoOcorrencia:'" + codigoOcorrencia + "',tipo:'" + tipo + "',ordem:'" + ordem + "',ordemProxSeSim:'" + ordemProxSeSim + "',ordemProxSeNao:'" + ordemProxSeNao + "',redacaoPerguntaPor:'" + redacaoPerguntaPor + "',redacaoPerguntaEsp:'" + redacaoPerguntaEsp + "',redacaoPerguntaIng:'" + redacaoPerguntaIng + "',respostaPor:'" + respostaPor + "',respostaEsp:'" + respostaEsp + "',respostaIng:'" + respostaIng + "' , codPais:'" + codPais + "',  tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>' , codModelo:'" + codModelo + "'}",
                         contentType: "application/json; charset=utf-8",
                         dataType: "json",
                         success: function (jasonResult) {



                             if (jasonResult.d == '0') {

                                 <% if (idioma.Equals("en-US")){ %>
                                 jAlert('Successfully recorded record', 'Decision tree', function () {
                                     location.reload();
                                 });
                                 <% }else if (idioma.Equals("es-ES")){ %>
                                 jAlert('Registro grabada con éxito.', 'Árbol de decisión', function () {
                                     location.reload();
                                 });
                                 <% }else{ %>
                                 jAlert('Registro gravado com sucesso.', 'Arvore de Decisão', function () {
                                     location.reload();
                                 });
                                 <% } %>



                             } else if (jasonResult.d == '1') {

                                 <% if (idioma.Equals("en-US")){ %>
                                 jAlert('Already inserted record!', 'Decision tree');
                                 <% }else if (idioma.Equals("es-ES")){ %>
                                 jAlert('Registro ya insertada!', 'Árbol de decisión');
                                 <% }else{ %>
                                 jAlert('Registro já inserido!', 'Arvore de Decisão');
                                 <% } %>


                             } else {


                                 <% if (idioma.Equals("en-US")){ %>
                                 jAlert(jasonResult.d, 'Decision tree');
                                 <% }else if (idioma.Equals("es-ES")){ %>
                                 jAlert(jasonResult.d, 'Árbol de decisión');
                                 <% }else{ %>
                                 jAlert(jasonResult.d, 'Arvore de Decisão');
                                 <% } %>
                             }


                         }
                     });

                 }
                      

                } else {
                    $j.ajax({
                        type: "POST",
                        url: "pergunta.aspx/salvarDados",
                        data: "{codigoPergunta:'" + codigoPergunta + "',codigoOcorrencia:'" + codigoOcorrencia + "',tipo:'" + tipo + "',ordem:'" + ordem + "',ordemProxSeSim:'" + ordemProxSeSim + "',ordemProxSeNao:'" + ordemProxSeNao + "',redacaoPerguntaPor:'" + redacaoPerguntaPor + "',redacaoPerguntaEsp:'" + redacaoPerguntaEsp + "',redacaoPerguntaIng:'" + redacaoPerguntaIng + "',respostaPor:'" + respostaPor + "',respostaEsp:'" + respostaEsp + "',respostaIng:'" + respostaIng + "' , codPais:'" + codPais + "',  tipoArvore:'<%=tipoArvore %>', idioma:'<%=idioma %>', codModelo:'" + codModelo + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (jasonResult) {



                            if (jasonResult.d == '0') {

                                <% if (idioma.Equals("en-US")){ %>
                                jAlert('Successfully recorded record', 'Decision tree', function () {
                                    location.reload();
                                });
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert('Registro grabada con éxito.', 'Árbol de decisión', function () {
                                    location.reload();
                                });
                                <% }else{ %>
                                jAlert('Registro gravado com sucesso.', 'Arvore de Decisão', function () {
                                    location.reload();
                                });
                                <% } %>



                            } else if (jasonResult.d == '1') {

                                <% if (idioma.Equals("en-US")){ %>
                                jAlert('Already inserted record!', 'Decision tree');
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert('Registro ya insertada!', 'Árbol de decisión');
                                <% }else{ %>
                                jAlert('Registro já inserido!', 'Arvore de Decisão');
                                <% } %>


                            } else {


                                <% if (idioma.Equals("en-US")){ %>
                                jAlert(jasonResult.d, 'Decision tree');
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert(jasonResult.d, 'Árbol de decisión');
                                <% }else{ %>
                                jAlert(jasonResult.d, 'Arvore de Decisão');
                                <% } %>
                            }


                        }
                    });
                }


                
            }


        }

        function excluirRegistro(codigo) {

            var mensagem = "";
            var title = "";
            <% if (idioma.Equals("en-US")){ %>
            mensagem = "You really want to delete the record ?";
            title = "Decision tree";
            <% }else if (idioma.Equals("es-ES")){ %>
            mensagem = "Usted realmente desea eliminar el registro ?";
            title = "Árbol de decisión";
            <% }else{ %>
            mensagem = "Deseja realmente excluir o registro ?";
            title = "Arvore de Decisão";
            <% } %>

            jConfirm(mensagem, title, function (r) {

                if (r == true) {

                    $j.ajax({
                        type: "POST",
                        url: "pergunta.aspx/excluirDados",
                        data: "{codigo:'" + codigo + "', codModelo:'" + codModelo + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (jasonResult) {

                            if (jasonResult.d == '0') {

                                <% if (idioma.Equals("en-US")){ %>
                                jAlert('Successfully deleted record.', 'Decision tree', function () {

                                    location.reload();
                                });
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert('Se ha eliminado el registro.', 'Árbol de decisión', function () {

                                    location.reload();
                                });
                                <% }else{ %>
                                jAlert('Registro excluído com sucesso.', 'Arvore de Decisão', function () {

                                    location.reload();
                                });
                                <% } %>


                            } else {


                                <% if (idioma.Equals("en-US")){ %>
                                jAlert("Could not delete the record", 'Decision tree');
                                <% }else if (idioma.Equals("es-ES")){ %>
                                jAlert("No se pudo eliminar el registro", 'Árbol de decisión');
                                <% }else{ %>
                                jAlert('Não foi possível excluir o registro!', 'Arvore de Decisão');
                                <% } %>
                            }


                        }
                    });
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


        function alterarRegistro(codigo) {
           
            document.getElementById('codigo').value = codigo;
            
            $j('.nav-tabs a[href="#profile"]').tab('show');

            $j.ajax({
                type: "POST",
                url: "pergunta.aspx/getPergunta",
                data: "{codigo:'" + codigo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var aDados = jasonResult.d.split("!#!");

                   

                    $j("#tipo").val(aDados[0]);
                    retornaTipo();
                    try { document.getElementById('ordem').value = aDados[1]; } catch (e) { }
                    $j("#ordemProxSeSim").val(aDados[2]);
                    $j("#ordemProxSeNao").val(aDados[3]);

                    if (aDados[4] == "&nbsp;") aDados[4] = "";
                    if (aDados[5] == "&nbsp;") aDados[5] = "";
                    if (aDados[6] == "&nbsp;") aDados[6] = "";
                    if (aDados[7] == "&nbsp;") aDados[7] = "";
                    if (aDados[8] == "&nbsp;") aDados[8] = "";
                    if (aDados[9] == "&nbsp;") aDados[9] = "";
                    try{document.getElementById('redacaoPerguntaPor').value = aDados[4];  }catch(e){}
                    try{document.getElementById('redacaoPerguntaEsp').value = aDados[6];  }catch(e){}
                    try{document.getElementById('redacaoPerguntaIng').value = aDados[5];   }catch(e){}                 
                    try{ tinyMCE.get('respostaPor').setContent(aDados[7],{ format: 'raw' });  }catch(e){}
                    try{ tinyMCE.get('respostaIng').setContent(aDados[8],{ format: 'raw' });  }catch(e){}
                    try { tinyMCE.get('respostaEsp').setContent(aDados[9], { format: 'raw' }); } catch (e) { }

                  
               

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
                try{ document.getElementById('labelRespostaPor').style.display = "none"; }catch(e){}
                try{ tinymce.editors['respostaPor'].hide();}catch(e){}
                try{document.getElementById('labelRespostaIng').style.display = "none";}catch(e){}
                try{tinymce.editors['respostaIng'].hide();}catch(e){}
                try{document.getElementById('labelRespostaEsp').style.display = "none";}catch(e){}
                try { tinymce.editors['respostaEsp'].hide(); } catch (e) { }
            } else if (tipo == '2') {
                document.getElementById('labelOrdemProxSeSim').style.display = "none";
                document.getElementById('ordemProxSeSim').style.display = "none";
                document.getElementById('labelOrdemProxSeNao').style.display = "none";
                document.getElementById('ordemProxSeNao').style.display = "none";
                document.getElementById('labelOrdem').style.display = "";
                document.getElementById('ordem').style.display = "";
               try{ document.getElementById('labelRespostaPor').style.display = "";}catch(e){}
                try{ tinymce.editors['respostaPor'].show();}catch(e){}
                try{ document.getElementById('labelRespostaIng').style.display = "";}catch(e){}
                try{tinymce.editors['respostaIng'].show();}catch(e){}
                try{ document.getElementById('labelRespostaEsp').style.display = "";}catch(e){}
                try { tinymce.editors['respostaEsp'].show(); } catch (e) { }
                ordemProxSeSim = '';
                ordemProxSeNao = '';
            } else if (tipo == '0') {
                document.getElementById('labelOrdemProxSeSim').style.display = "none";
                document.getElementById('ordemProxSeSim').style.display = "none";
                document.getElementById('labelOrdemProxSeNao').style.display = "none";
                document.getElementById('ordemProxSeNao').style.display = "none";
                document.getElementById('labelOrdem').style.display = "none";
                document.getElementById('ordem').style.display = "none";
                try{ document.getElementById('labelRespostaPor').style.display = "none"; }catch(e){}
                try{ tinymce.editors['respostaPor'].hide();}catch(e){}
                try{ document.getElementById('labelRespostaIng').style.display = "none";}catch(e){}
                try{ tinymce.editors['respostaIng'].hide();}catch(e){}
                try{ document.getElementById('labelRespostaEsp').style.display = "none";}catch(e){}
                try { tinymce.editors['respostaEsp'].hide(); } catch (e) { }

            }
        }


        function retornaOrdemProxSeSim() {
            ordemProxSeSim = $j("#ordemProxSeSim option:selected").val();
        }

        function retornaOrdemProxSeNao() {
            ordemProxSeNao = $j("#ordemProxSeNao option:selected").val();
        }


        //Limpa o formulário ao criar uma nova pergunta
        function clearChildren(element) {
            for (var i = 0; i < element.childNodes.length; i++) {
                try{
                var e = element.childNodes[i];
                if (e.tagName) switch (e.tagName.toLowerCase()) {
                    case 'input':
                        switch (e.type) {
                            case "radio":
                            case "checkbox": e.checked = false; break;
                            case "button":
                            case "submit":
                            case "image": break;
                            default: e.value = ''; break;
                        }
                        break;
                    case 'select': e.selectedIndex = 0; break;
                    case 'textarea': e.innerHTML = ''; break;
                    default: clearChildren(e);
                }
            }catch(e){}
            }
        }


    </script>
<body>
    <div class="container-fluid">
    <table border=0 style="width: 100%"><Tr>
          <Td  align="left" style="width: 5%">  <img src="../includes/arvore/imagens/logo.png" class="img-responsive"/></img></Td>
          
              <Td  align="center" style="width: 45%" align="center"><span id="labelCliente">&nbsp;</span></Td>
          
       <td align="right"><span id="labelUsuario"><%=tipoArvore%></span></td>   <td align="right"><span id="labelUsuario">User:</span></td><td><span id="conteudoUsuario">&nbsp;<%=nome %></span></td>  
   
         
  
          
      </Tr></table>
    
    
    
     <br />
       <% if(tipoAcesso.Equals("usuario")){  %>
     <ul>
            <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu">Ocorr&ecirc;ncias</a></li>
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
          <h4 class="modal-title">Arvore de Decisão</h4>
        </div>
        <div class="modal-body" style="height:350px; overflow:auto; ">
          
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
        </div>
  </div>


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
  
  <fieldset class="scheduler-border">
    <legend class="scheduler-border"><%=lblTitulo %>: <span id="nome" style="font-weight: bold;"> </span> </legend>
      
      <div role="tabpanel">

  <!-- Nav tabs -->
  <ul class="nav nav-tabs" role="tablist" id="myTab">
     <li role="presentation" class="active"><a href="#home" aria-controls="home" role="tab" data-toggle="tab"><%=lblListagem %></a></li>
     <li role="presentation"><a href="#profile" aria-controls="profile" role="tab" data-toggle="tab"><%=lblCadastro %></a></li>
  
   </ul>

    <div class="tab-content">
        <div role="tabpanel" class="tab-pane fade in active" id="home">
          
            <div class="table-responsive">
             <div id="listagem" >
          <div class="panel panel-primary">
              <div class="panel-heading"><%=lblLista %></div>
              <table class="table" id="table-pergunta"></table>


           </div>

                  <div class="modal-footer">
                       <button type="button" class="btn btn-default" onclick="voltar();"><%=lblVoltar %></button>
        <button type="button" class="btn btn-primary" onclick="novaPergunta();"><%=lblNova %></button>
      </div>  
</div>
     </div>   

      </div>
  
       <div role="tabpanel" class="tab-pane fade" id="profile"> 

            <div id="cadastro"   >
        <br />
         <input type="hidden" name="codigo" id="codigo" value="0" />
        
                <% if (idioma.Equals("en-US")){ %>
                
               <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Question
         </span><br /><br />
                                     <div class="form-group">
            <label for="tipo" class="control-label">Type:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="tipo" style="width: 150px !important" onchange="retornaTipo()">
                    <option value="0"></option>    
                    <option value="1">True/False</option>
                    <option value="2">Wording</option>                                 
            </select>
       </div>
                                               <div class="form-group">
            <label for="ordem" id="labelOrdem" style="display:none" class="control-label">Order:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="ordem" style="width: 150px !important; display:none"/>
       </div>                                                         
          <div class="form-group">
            <label for="ordemProxSeSim" id="labelOrdemProxSeSim" style="display:none" class="control-label">If so, go to the question:&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeSim" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeSim()">                 
     
              </select>
       </div>
            <div class="form-group">
            <label for="ordemProxSeNao" id="labelOrdemProxSeNao" style="display:none" class="control-label">If not, go to the question:&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeNao" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeNao()">                  
    
              </select>
       </div>
             <input type="hidden" class="form-control" id="redacaoPerguntaPor" style="display: none"/>
                 <input type="hidden" class="form-control" id="redacaoPerguntaEsp" style="display: none"/>
       
        <div class="form-group">
            <label for="redacaoPerguntaIng" class="control-label">Question:&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="redacaoPerguntaIng" style="width: 650px !important" placeholder="Enter the question"/>
         </div>
      
<input type="hidden" id="respostaPor" style="display:none;" ></input>
                <input type="hidden" id="respostaEsp" style="display:none;" ></input>                             
            <div class="form-group">
                        <label for="respostaIng" id="labelRespostaIng" class="control-label" style="display:none">Answer:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>                
            <textarea id="respostaIng" style="display:none" ></textarea>
            </div>   
          

<% } else if (idioma.Equals("es-ES")){ %>


                <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Pregunta
         </span><br /><br />
                                     <div class="form-group">
            <label for="tipo" class="control-label">Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="tipo" style="width: 200px !important" onchange="retornaTipo()">
                    <option value="0"></option>    
                    <option value="1">Verdadero/Falso</option>
                    <option value="2">Redacción</option>                                 
            </select>
       </div>
                                               <div class="form-group">
            <label for="ordem" id="labelOrdem" style="display:none" class="control-label">Orden:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="ordem" style="width: 200px !important; display:none"/>
       </div>                                                         
          <div class="form-group">
            <label for="ordemProxSeSim" id="labelOrdemProxSeSim" style="display:none" class="control-label">Si es verdad, va a la pregunta:&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeSim" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeSim()">                 
     
              </select>
       </div>
            <div class="form-group">
            <label for="ordemProxSeNao" id="labelOrdemProxSeNao" style="display:none" class="control-label">Si es falso, se va a la pregunta:&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeNao" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeNao()">                  
    
              </select>
       </div>
             <input type="hidden" class="form-control" id="redacaoPerguntaPor" style="display: none"/>
                 <input type="hidden" class="form-control" id="redacaoPerguntaIng" style="display: none"/>
       
        <div class="form-group">
            <label for="redacaoPerguntaEsp" class="control-label">Pregunta:&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="redacaoPerguntaEsp" style="width: 650px !important" placeholder="Introduzca la pregunta"/>
         </div>
      
<input type="hidden" id="respostaPor" style="display:none;" ></input>
                <input type="hidden" id="respostaIng" style="display:none;" ></input>                             
            <div class="form-group">
                        <label for="respostaEsp" id="labelRespostaEsp" class="control-label" style="display:none">Respuesta:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>                
            <textarea id="respostaEsp" style="display:none" ></textarea>
            </div>   



                  <% }else { %>

                 
                  <% if (pais.Equals("Brazil")){ %>


                <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Pergunta
         </span><br /><br />
                                     <div class="form-group">
            <label for="tipo" class="control-label">Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="tipo" style="width: 200px !important" onchange="retornaTipo()">
                    <option value="0"></option>    
                    <option value="1">Verdadeiro/Falso</option>
                    <option value="2">Redação</option>                                 
            </select>
       </div>
                                               <div class="form-group">
            <label for="ordem" id="labelOrdem" style="display:none" class="control-label">Ordem:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="ordem" style="width: 200px !important; display:none"/>
       </div>                                                         
          <div class="form-group">
            <label for="ordemProxSeSim" id="labelOrdemProxSeSim" style="display:none" class="control-label">Se for verdadeiro, informe a pergunta:&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeSim" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeSim()">                 
     
              </select>
       </div>
            <div class="form-group">
            <label for="ordemProxSeNao" id="labelOrdemProxSeNao" style="display:none" class="control-label">Se for falso, informe a pergunta:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeNao" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeNao()">                  
    
              </select>
       </div>
       
        <div class="form-group">
            <label for="redacaoPerguntaPor" class="control-label">Pergunta (Port):&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="redacaoPerguntaPor" style="width: 650px !important" placeholder="Informe a pergunta"/>
         </div>

           

                <div class="form-group">
            <label for="redacaoPerguntaEsp" class="control-label">Pergunta (Esp):&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="redacaoPerguntaEsp" style="width: 650px !important" placeholder="Introduzca la pregunta"/>
         </div>

                     <div class="form-group">
            <label for="redacaoPerguntaIng" class="control-label">Pergunta (Ing):&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="redacaoPerguntaIng" style="width: 650px !important" placeholder="Enter the question"/>
         </div>
      
                     
           
                 <div class="form-group">
                        <label for="respostaPor" id="labelRespostaPor"  class="control-label" style="display:none">Resposta (Por):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>                
            <textarea id="respostaPor" style="display:none" ></textarea>
            </div> 

                

                 <div class="form-group">
                        <label for="respostaEsp" id="labelRespostaEsp"  class="control-label" style="display:none">Resposta (Esp):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>                
            <textarea id="respostaEsp" style="display:none" ></textarea>
            </div> 

                 <div class="form-group">
                        <label for="respostaIng" id="labelRespostaIng"  class="control-label" style="display:none">Resposta (Ing):&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>                
            <textarea id="respostaIng" style="display:none" ></textarea>
            </div> 

                  <% }else{ %>


                  <span class="reqfield" tabindex="0">
                <img src="../includes/arvore/imagens/required.gif" alt="Asterisco"/> Pergunta
         </span><br /><br />
                                     <div class="form-group">
            <label for="tipo" class="control-label">Tipo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="tipo" style="width: 200px !important" onchange="retornaTipo()">
                    <option value="0"></option>    
                    <option value="1">Verdadeiro/Falso</option>
                    <option value="2">Redação</option>                                 
            </select>
       </div>
                                               <div class="form-group">
            <label for="ordem" id="labelOrdem" style="display:none" class="control-label">Ordem:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="ordem" style="width: 200px !important; display:none"/>
       </div>                                                         
          <div class="form-group">
            <label for="ordemProxSeSim" id="labelOrdemProxSeSim" style="display:none" class="control-label">Se for verdadeiro, informe a pergunta:&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeSim" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeSim()">                 
     
              </select>
       </div>
            <div class="form-group">
            <label for="ordemProxSeNao" id="labelOrdemProxSeNao" style="display:none" class="control-label">Se for falso, informe a pergunta:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
            <select class="form-control" id="ordemProxSeNao" style="width: 600px !important; display:none" onchange="retornaOrdemProxSeNao()">                  
    
              </select>
       </div>
             <input type="hidden" class="form-control" id="redacaoPerguntaEsp" style="display: none"/>
                 <input type="hidden" class="form-control" id="redacaoPerguntaIng" style="display: none"/>
       
        <div class="form-group">
            <label for="redacaoPerguntaPor" class="control-label">Pergunta:&nbsp;&nbsp;&nbsp;</label>
            <input type="text" class="form-control" id="redacaoPerguntaPor" style="width: 650px !important" placeholder="Informe a pergunta"/>
         </div>
      
<input type="hidden" id="respostaEsp" style="display:none;" ></input>
                <input type="hidden" id="respostaIng" style="display:none;" ></input>                             
            <div class="form-group">
                        <label for="respostaPor" id="labelRespostaPor"  class="control-label" style="display:none">Resposta:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>                
            <textarea id="respostaPor" style="display:none" ></textarea>
            </div> 


                  <% }
                     
               } %>



      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal" onclick="cancelar();"><%=lblCancelar %></button>
        <button type="button" class="btn btn-primary" onclick="salvarDados();"><%=lblSalvar %></button>
      </div>  
          
               
     
   </div> 

       </div>
     </div>

</div>




 
     
      
    
    
         
  </fieldset>

 </div>    
</div>
</body>
</html>
