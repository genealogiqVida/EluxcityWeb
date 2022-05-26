<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="impulse.aspx.cs" Inherits="EluxcityWeb.pages.impulse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    

       <script src="../includes/arvore/js/jquery-1.10.2.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery-ui-1.10.4.custom.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery.alerts.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap.js"  type="text/javascript"></script>
      <script src="../includes/arvore/js/bootstrap-table.js" type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-multiselect.js"></script>
    <script src="../includes/arvore/js/bootstrap-tagsinput.js"  type="text/javascript"></script>

        <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/> 

    <script>
        function enviar() {
            var script = document.getElementById('script').value;
            var $j = jQuery.noConflict();
            $j.ajax({
                type: "POST",
                url: "linha.aspx/rodaScript",
                data: "{script:\"" + script + "\"}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (jasonResult) {

                    alert(jasonResult.d);

                    if (jasonResult.d == 'Executado com sucesso.') {
                        document.getElementById('script').value = "";
                    }


                }
            });


        }

    </script>

</head>

    <body style="overflow: hidden;">
        <br /><br />
         <label class="control-label">Script (insert/ delete/update) :</label>                
            <textarea id="script" name="script" rows="10" cols="70" ></textarea>

         <div class="modal-footer">
       <button type="button" class="btn btn-primary" onclick="enviar();">Enviar</button>
      </div>

 </body>
    </html>
