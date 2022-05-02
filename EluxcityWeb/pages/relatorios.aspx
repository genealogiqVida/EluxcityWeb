<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relatorios.aspx.cs" Inherits="EluxcityWeb.pages.relatorios" %>

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

    string idio = "por";

    string lblMenu1 = "Modelo";
    string lblMenu2 = "Ocorrência";
    string lblMenu3 = "País";

    if (pais.Equals("Brazil"))
    {
        lblMenu1 = "SubCategoria";
    }
    else
    {
        if (idioma.Equals("en-US"))
        {
         
            lblMenu1 = "Model";
            lblMenu2 = "Ocurrencia";
            lblMenu3 = "Country";
            
        }
        else if (idioma.Equals("es-ES"))
        {
            
            lblMenu1 = "Model";
            lblMenu2 = "Ocurrencia";
            lblMenu3 = "País";
        }
    }

    string tipoMenu1 = "Categoria";
    string tipoMenu2 = "SubCategoria";
    if (tipoArvore.Equals("Arvore Solution Center"))
    {
        tipoMenu1 = "Produto";
        tipoMenu2 = "Modelo";
    }

   // tipoArvore = Session["tipoArvore"].ToString();
    tipoArvore = tipoArvore.Replace("%20", " ");


    string tipoMenu3 = "Ocorrência";
    string tipoMenu4 = "Importação de Dados";
    string tipoMenu5 = "Relatórios de uso do Sistema";
    string lblLabel18 = "Pergunta";


    string tipoMenu0 = "Linha";
     tipoMenu1 = "Categoria";
     tipoMenu2 = "SubCategoria";
     string lblTitulo = "Relatórios de uso do Sistema";
     string lblLabel1 = "Período";
     string lblLabel2 = "Data inicial";
     string lblLabel3 = "Data final";
     string lblLabel4 = "Usuário";
     string lblLabel5 = "Relatório de acesso à árvore de decisão";
     string lblLabel6 = "Relatório de qualidade do uso da árvore de decisão";
     string lblLabel17 = "Relatório de dados";
     string lblLabel7 = "Comentário";
     string informacao = "Selecione um usuário...";
     string lblLabel8 = "Êxito";
     string lblLabel9 = "Data e Hora";
     string lblLabel10 = "Pesquisa";

     string lblLabel11 = "Código";
     string lblLabel12 = "Resposta";
     string lblLabel13 = "Tipo pergunta";
    

    if (idioma.Equals("en-US"))
    {

        lblLabel18 = "Question"; idio = "ing";
        tipoMenu0 = "Line";
        lblTitulo = "System usage reports";
        tipoMenu3 = "Ocurrencia";
        tipoMenu4 = "Data Import";
        tipoMenu5 = "System usage reports";
        lblLabel7 = "Comment";
        tipoMenu1 = "Category";
        tipoMenu2 = "Subcategory";
        informacao = "Select a user...";
        lblLabel10 = "Search";
         lblLabel1 = "Period";
         lblLabel2 = "Initial date";
         lblLabel3 = "Final date";
         lblLabel4 = "User";
         lblLabel5 = "Report access to decision tree";
         lblLabel6 = "Quality report of the use of the decision tree";
         lblLabel17 = "Report of data";

         lblLabel8 = "Success";
         lblLabel9 = "Date and time";

          lblLabel11 = "Code";
          lblLabel12 = "Answer";
          lblLabel13 = "Type question";
    }
    else if (idioma.Equals("es-ES"))
    {
        idio = "esp";
        lblLabel18 = "Pregunta";
        tipoMenu0 = "Línea";
        lblTitulo = "Informes de uso del sistema";
        lblLabel7 = "Comentário";
        tipoMenu3 = "Ocurrencia";
        tipoMenu4 = "Importación de datos";
        tipoMenu5 = "Informes de uso del sistema";
        informacao = "Selecciona un usuario...";
        tipoMenu1 = "Categoría";
        tipoMenu2 = "SubCategoría";
         lblLabel8 = "Éxito";
         lblLabel9 = "Fecha y hora";
         lblLabel1 = "Período";
         lblLabel2 = "Fecha de inicio";
         lblLabel3 = "Fecha de finalización";
         lblLabel4 = "Usuario";
         lblLabel5 = "Informe acceso al árbol de decisión";
         lblLabel6 = "Informe de calidad de la utilización del árbol de decisión";
         lblLabel6 = "Informe de dados";
         lblLabel10 = "Búsqueda";

          lblLabel11 = "Código";
          lblLabel12 = "Respuesta";
          lblLabel13 = "Tipo pregunta";
    }


    if (tipoArvore.Equals("Arvore Solution Center"))
    {
        tipoMenu1 = "Produto";
        tipoMenu2 = "Modelo";

        if (idioma.Equals("en-US"))
        {
            tipoMenu1 = "Product";
            tipoMenu2 = "Model";
        }
        else if (idioma.Equals("es-ES"))
        {
            tipoMenu1 = "Producto";
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
    <script src="../includes/arvore/js/importacao.js" type="text/javascript"></script>
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
    <script src="../includes/arvore/js/fileinput.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/fileinput_locale_pt-BR.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/canvas-to-blob.min.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/ajaxupload.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/chosen.jquery.js" type="text/javascript"></script>

    
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/>
    <link href="../includes/arvore/css/chosen.css" type="text/css" rel="stylesheet" />

   
   
</head>


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
            <li><a href="ocorrenciaUsuario.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu3 %></a></li>
        </ul>    

         <%}else{ %>
              <% if(pais.Equals("Brazil")){  %>
                          <ul>
                               <li><a class="liMenu" href="<%=urlVolta%>"  ><img src="../includes/arvore/imagens/home.png" class="img-responsive" style="cursor: pointer;" /></a></li>
                          <li><a class="liMenu" href="linha.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>"  ><%=tipoMenu0 %></a></li>
                            <li><a href="produto.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu1 %></a></li>
                            <li><a href="modelo.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu2 %></a></li>
                            <li><a href="ocorrencia.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu3 %></a></li>
                            <li><a href="importacao.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu4 %></a></li>
                            <li><a href="relatorios.aspx?idUser=<%=idUser%>&username=<%=user%>&tipoAcesso=<%=tipoAcesso%>&usuario=<%=user%>" class="liMenu"><%=tipoMenu5 %></a></li>
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
   


    <div class="modal-body" >

                  <!-- Modal -->
  <div class="modal fade" role="dialog" id="myModal">
    <div class="vertical-alignment-helper">    
        <div class="modal-dialog vertical-align-center">
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title"><%=lblLabel7 %></h4>
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
  
  <fieldset class="scheduler-border">
    <legend class="scheduler-border"><%=lblTitulo %></legend>

            <div class="form-group">
            <label for="periodo" class="control-label"><%=lblLabel1 %>: </label>
                <p><%=lblLabel2 %>:&nbsp;<input type="text" id="data_inicial" style="width: 100px !important"> <%=lblLabel3 %>:&nbsp;&nbsp;&nbsp;<input type="text" id="data_final" style="width: 100px !important"></p>
        </div>

         <div class="form-group">
            <label for="usuario" class="control-label"><%=lblLabel4 %>:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>            
              <select id="usuario" data-placeholder="<%=informacao %>" style="height: 300px; width: 250px !important" class="chosen-select" onchange="retornaUsuario()" >             </select>
             
         </div>

     

               
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" style="float:left" onclick="carregaRelatorioAcesso();"><%=lblLabel5 %></button>
        <button type="button" class="btn btn-primary" style="float:left" onclick="carregaRelatorioUso();"><%=lblLabel6 %></button>
        <button type="button" class="btn btn-primary" style="float:left" onclick="carregaRelatorioDados();"><%=lblLabel17 %></button>
      </div>
      <div class="table-responsive">
                       <div id="listagemAcesso" style="display:none" >
          <div class="panel panel-primary">
              <div class="panel-heading"></div>
              <table class="table" id="table-pesquisa"></table>


               <div class="modal-footer">
       <!-- <button type="button" class="btn btn-primary" onclick="exportExcelAcesso();">Export Excel</button> -->
<form id="form1" runat="server">
                   <asp:Button id="btnExportToExcel" CssClass="btn btn-primary" runat="server" Text="Export Excel"
                        onclick="btnExportToExcel_Click" />

      </div>

           </div>

     </div>   
          </div>

      <div class="table-responsive">
     <div id="listagemQualidadeDeUso" style="display:none" >
          <div class="panel panel-primary">
              <div class="panel-heading"></div>
              <table class="table" id="table-comentario"></table>


               <div class="modal-footer">
       
                   <asp:Button id="Button2" CssClass="btn btn-primary" runat="server" Text="Export Excel"
                        onclick="btnExportToExcelQualidade_Click" />
                    
      </div>

           </div>

     </div>   
          </div>




            <div class="table-responsive">
                       <div id="listagemDados" style="display:none" >
          <div class="panel panel-primary">
              <div class="panel-heading"></div>
              <table class="table" id="table-pesquisa-dados"></table>


               <div class="modal-footer">

                   <asp:Button id="Button1" CssClass="btn btn-primary" runat="server" Text="Export Excel"
                        onclick="btnExportToExcelDados_Click" /> </form>

      </div>

           </div>

     </div>   
          </div>


          </fieldset> 
        </br>
        </div> 

        </div>
       
</body>

   
    <script>
        var $j = jQuery.noConflict();
        var codigoUsuario = "0";
        var nomeUsuario = "0";
        var dataInicial = "";
        var dataFinal = "";

        $j(function () {
            $j("#data_inicial").datepicker({
                dateFormat: 'dd/mm/yy',
                inline: true
            });
        });

        $j(function () {
            $j("#data_final").datepicker({
                dateFormat: 'dd/mm/yy',
                inline: true
            });

        });


        $j('document').ready(function () {
            
            $j.ajax({
                type: "POST",
                url: "relatorios.aspx/carregaComboUsuario",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    document.getElementById('usuario').innerHTML = dados;

                    $j("#usuario").chosen();


                }
            });


            

        });

        function exportExcelAcesso() {

            $j.ajax({
                type: "POST",
                url: "relatorios.aspx/exportExcelAcesso",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;

                    /*document.getElementById('usuario').innerHTML = dados;

                    $j("#usuario").chosen();*/


                }
            });


        }

        function exportExcelUso() {


        }

        function retornaUsuario() {
            codigoUsuario = $j("#usuario option:selected").val();
        }

        function retornaUsuarioDados() {
            codigoUsuario = $j("#usuario option:selected").val();
        }

        function visualizarComentario(codigo) {


            // esse trecho carrega o comentario do usuario para ser exibida em tela
            $j.ajax({
                type: "POST",
                url: "relatorios.aspx/visualizarComentario",
                data: "{codigo:'" + codigo + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    var dados = jasonResult.d;
                    $j('#myModal .modal-body').html(dados);
                    $j('#myModal').modal('show');
                }

            });


        }

        function carregaRelatorioAcesso() {
            paginaAtual = "1";
            retornaRelatorioDeAcesso();
        }

        function carregaRelatorioUso() {
            paginaAtual = "1";
            retornaRelatorioDeUso();
        }

        function carregaRelatorioDados() {
            paginaAtual = "1";
            retornaRelatorioDados();
        }

        function retornaRelatorioDeAcesso() {
            telaAtual = "relatorioacesso";
            dataInicial = $j("#data_inicial").val();
            dataFinal = $j("#data_final").val();
            


            retornaUsuario();

         
           // alert(codigoUsuario);

            $j.ajax({
                type: "POST",
                url: "relatorios.aspx/retornaRelatorioDeAcesso",
                data: "{limit: " + limit + ", offset: " + paginaAtual + " , codigoUsuario:'" + codigoUsuario + "',dataInicial:'" + dataInicial + "',dataFinal:'" + dataFinal + "', idio:'<%=idioma%>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    $j('#table-pesquisa').bootstrapTable('destroy');
                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);

                    $j('#table-pesquisa').bootstrapTable({
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
                            field: 'nome_usuario',
                            title: '<%=lblLabel4%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'data_e_hora',
                            title: '<%=lblLabel9%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        },  {
                            field: 'nome_linha_<%=idio%>',
                            title: '<%=tipoMenu0%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_produto_<%=idio%>',
                            title: '<%=tipoMenu1%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'nome_modelo_<%=idio%>',
                            title: '<%=tipoMenu2%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'descricao_ocorrencia_<%=idio%>',
                            title: '<%=lblMenu2%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'redacao_pergunta_<%=idio%>',
                            title: '<%=lblLabel18%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: '<%=lblMenu3%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }]
                    });
                    $j('#table-pesquisa').bootstrapTable();

                }
            });
            document.getElementById('listagemQualidadeDeUso').style.display = "none";
            document.getElementById('listagemAcesso').style.display = "";
            document.getElementById('listagemDados').style.display = "none";
        }

        function retornaRelatorioDeUso() {
            telaAtual = "relatoriouso";
            dataInicial = $j("#data_inicial").val();
            dataFinal = $j("#data_final").val();
            retornaUsuario();


            $j.ajax({
                type: "POST",
                url: "relatorios.aspx/retornaRelatorioDeUso",
                data: "{limit: " + limit + ", offset: " + paginaAtual + " ,codigoUsuario:'" + codigoUsuario + "',dataInicial:'" + dataInicial + "',dataFinal:'" + dataFinal + "', idio:'<%=idioma%>'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    $j('#table-comentario').bootstrapTable('destroy');
                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);


                    $j('#table-comentario').bootstrapTable({
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
                            field: 'nome_usuario',
                            title: '<%=lblLabel4%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'foi_util',
                            title: '<%=lblLabel8%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                        field: 'nome_linha_<%=idio%>',
                    title: '<%=tipoMenu0%>',
                    width: 80,
                    align: 'center',
                    valign: 'middle',
                    sortable: true
                }, {
                field: 'nome_produto_<%=idio%>',
                title: '<%=tipoMenu1%>',
                width: 80,
                align: 'center',
                valign: 'middle',
                sortable: true
                }, {
                    field: 'nome_modelo_<%=idio%>',
                    title: '<%=tipoMenu2%>',
                    width: 80,
                    align: 'center',
                    valign: 'middle',
                    sortable: true

                
                  
                }, {
                    field: 'descricao_ocorrencia_<%=idio%>',
                    title: '<%=lblMenu2%>',
                    width: 80,
                    align: 'center',
                    valign: 'middle',
                    sortable: true

                }, {

                    field: 'redacao_pergunta_<%=idio%>',
                    title: '<%=lblLabel18%>',
                    width: 80,
                    align: 'center',
                    valign: 'middle',
                    sortable: true
            
                        }, {
                            field: 'redacao_comentario',
                            title: '<%=lblLabel7%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'data_e_hora',
                            title: '<%=lblLabel9%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: '<%=lblMenu3%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }]
                    });
                    $j('#table-comentario').bootstrapTable();

                }
            });
            document.getElementById('listagemAcesso').style.display = "none";
            document.getElementById('listagemQualidadeDeUso').style.display = "";
            document.getElementById('listagemDados').style.display = "none";
        }



        function retornaRelatorioDados() {
            telaAtual = "relatoriodados";

            dataInicial = $j("#data_inicial").val();
            dataFinal = $j("#data_final").val();

           
            retornaUsuario();


            $j.ajax({
                type: "POST",
                url: "relatorios.aspx/retornaRelatorioDados",
                data: "{limit: " + limit + ", offset: " + paginaAtual + " ,codigoUsuario:'" + codigoUsuario + "',dataInicial:'" + dataInicial + "',dataFinal:'" + dataFinal + "', idio:'<%=idio%>',  tipoArv:'<%=tipoArvore%>' }",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    $j('#table-pesquisa-dados').bootstrapTable('destroy');
                    var dados = jasonResult.d;
                    var total = dados.substring(0, dados.indexOf(","));
                    dados = dados.replace(total + ",", '');

                    var obj = eval(dados);


                    $j('#table-pesquisa-dados').bootstrapTable({
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
                            field: 'linha',
                            title: '<%=tipoMenu0%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'categoria',
                            title: '<%=tipoMenu1%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'subcategoria',
                            title: '<%=tipoMenu2%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'ocorrencia',
                            title: '<%=tipoMenu3%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'codigo',
                            title: '<%=lblLabel11%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true



                        }, {
                            field: 'pergunta',
                            title: '<%=lblLabel18%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {

                            field: 'resposta',
                            title: '<%=lblLabel12%>',
                            width: 80,
                            align: 'left',
                            valign: 'middle',
                            sortable: true

                        }, {
                            field: 'tipo_pergunta',
                            title: '<%=lblLabel13%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'pais',
                            title: '<%=lblMenu3%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'usuario',
                            title: '<%=lblLabel4%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }, {
                            field: 'data_e_hora',
                            title: '<%=lblLabel9%>',
                            width: 80,
                            align: 'center',
                            valign: 'middle',
                            sortable: true
                        }]
                    });
                    $j('#table-pesquisa-dados').bootstrapTable();

                }
            });
            document.getElementById('listagemAcesso').style.display = "none";
            document.getElementById('listagemQualidadeDeUso').style.display = "none";
            document.getElementById('listagemDados').style.display = "";
        }


    </script>

</html>

