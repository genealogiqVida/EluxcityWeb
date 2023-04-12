<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="EluxcityWeb.pages._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="pt-br">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1">
  
     <script src="../includes/arvore/js/jquery-1.10.2.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery-ui-1.10.4.custom.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/jquery.alerts.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-table.js"  type="text/javascript"></script>
    <script src="../includes/arvore/js/bootstrap-tagsinput.js"  type="text/javascript"></script>
  

    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery-ui-1.10.4.custom.css" /> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/jquery.alerts.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-table.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/bootstrap-tagsinput.css"/> 
    <link rel="stylesheet" type="text/css" href="../includes/arvore/css/estilo.css"/> 

    <script>

        var dominio = "";
        var pais = "";
        var idioma = "<%=idiomaLogin%>";
        var tipoAcesso = "";
        var tipoArvore = '<%=tipoArvore%>';
        var nome = "";
        var url = '<%=url%>';
        var urlVolta = '<%=urlVolta%>';
        var certificate = '<%=certificate%>';
        var userName = '<%=usuario%>';
        var idUser = '<%=idUser%>';
     

        function removerAcentos( newStringComAcento ) {
            var string = newStringComAcento;
            var mapaAcentosHex 	= {
                a: /[\xE0-\xE6]/g,
                A: /[\xC0-\xC6]/g,
                e: /[\xE8-\xEB]/g,
                E: /[\xC8-\xCB]/g,
                i: /[\xEC-\xEF]/g,
                I: /[\xCC-\xCF]/g,
                o: /[\xF2-\xF6]/g,
                O: /[\xD2-\xD6]/g,
                u: /[\xF9-\xFC]/g,
                U: /[\xD9-\xDC]/g,
                c: /\xE7/g,
                C: /\xC7/g,
                n: /\xF1/g,
                N: /\xD1/g
            };

            for ( var letra in mapaAcentosHex ) {
                var expressaoRegular = mapaAcentosHex[letra];
                string = string.replace( expressaoRegular, letra );
            }

            return string;
        }



        function SetCookie(cookieName, cookieValue, nDays) {

            cookieValue = removerAcentos(cookieValue);

            delete_cookie(cookieName);

            var today = new Date();
            var expire = new Date();
            if (nDays == null || nDays == 0) nDays = 1;
            expire.setTime(today.getTime() + 3600000 * 24 * nDays);
            document.cookie = cookieName + "=" + escape(cookieValue)
                            + ";expires=" + expire.toGMTString();
        }

        function delete_cookie(name) {
            document.cookie = name + '=; expires=Thu, 01 Jan 1970 00:00:01 GMT;';
        }


        function getCookie(nome) {
            if (document.cookie.length > 0) {
                c_start = document.cookie.indexOf(nome + "=");
                if (c_start != -1) {
                    c_start = c_start + nome.length + 1;
                    c_end = document.cookie.indexOf(";", c_start);
                    if (c_end == -1)
                        c_end = document.cookie.length; return unescape(document.cookie.substring(c_start, c_end));
                }
            } return null;

        }

        $(document).ready(function () {
            //  alert(userName);

            $.ajax({
                url: url + "/v1/people/username=" + userName + "?SabaCertificate=" + certificate + "&type=internal",
                type: 'get',
                dataType: 'json',
                success: function (data) {
                    var obj = JSON.stringify(data);

                   

                    if (obj.indexOf("Consumer Care") != -1) {
                        dominio = "Consumer Care";
                    }
                    else if (obj.indexOf("Trade Marketing") != -1) {
                        dominio = "Trade Marketing";
                    }
                    else if (obj.indexOf("Service Center") != -1) {
                        dominio = "Service Center";
                    }
                    else if (obj.indexOf("Contact Center") != -1) {
                        dominio = "Service Center";
                    }

                    var pais = "Brazil";

                    if (obj.indexOf("BRA -") != -1) {
                        pais = "Brazil";
                    }
                    else if (obj.indexOf("ARG -") != -1) {
                        pais = "Argentina";
                    }
                    else if (obj.indexOf("CHI -") != -1) {
                        pais = "Chile";
                    }
                    else if (obj.indexOf("EQU -") != -1) {
                        pais = "Equador";
                    }
                    else if (obj.indexOf("COL -") != -1) {
                        pais = "Colombia";
                    }
                    else if (obj.indexOf("MEX -") != -1) {
                        pais = "Mexico";
                    }
                    else if (obj.indexOf("PER -") != -1) {
                        pais = "Peru";
                    }
                    else if (obj.indexOf("UWM -") != -1) {
                        pais = "UWM";
                    }
                    else if (obj.indexOf("PUB -") != -1) {
                        pais = "PUB";
                    }



                    var fname = obj.substring(obj.indexOf('"fname":"') + 9, obj.length);
                    fname = fname.substring(0, fname.indexOf('","'));
                    var lname = obj.substring(obj.indexOf('"lname":"') + 9, obj.length);
                    lname = lname.substring(0, lname.indexOf('","'));
					
					fname = data["fname"];
					lname = data["lname"];
					
                    nome = fname + " " + lname;
					
					

                   
                    var custom6 = obj.substring(obj.indexOf('custom6'), obj.length);
					
					var conteudo = obj.substring(obj.indexOf(',"id":"'), obj.length);
							conteudo = conteudo.replace(',"id":"', '');
							conteudo = conteudo.substring(0, conteudo.indexOf('"}'));
							conteudo = conteudo.replace('"}', '');

                    var idPessoa = custom6.substring(custom6.indexOf('"id":"') + 6, custom6.length - 2);
					
					idPessoa = conteudo;
					
					idPessoa = data["id"];

                    if (obj.indexOf("(Brasil)") != -1) {
                        idioma = "pt-BR";
                    }
                    else if (obj.indexOf("English") != -1) {
                        idioma = "en-US";
                    }
                    else {
                        idioma = "es-ES";
                    }



                    $.ajax({
                        url: url + "/v1/people/" + idPessoa + ":(securityRoles)?SabaCertificate=" + certificate,
                        type: 'get',
                        dataType: 'json',
                        success: function (data) {
                            var obj = JSON.stringify(data);

                            if (obj.indexOf("Super User") != -1) {
                                tipoAcesso = "administrador";
                            } else {
                                tipoAcesso = "usuario";
                            }



                            SetCookie("pais", pais, 1);
                            SetCookie("idioma", idioma, 1);
                            SetCookie("tipoAcesso", tipoAcesso, 1);
                            SetCookie("nome", nome, 1);
                            SetCookie("username", userName, 1);
                            SetCookie("urlVolta", urlVolta, 1);

                            SetCookie("usuario", userName, 1);
                            SetCookie("idUser", idUser, 1);
                            SetCookie("tipoArvore", tipoArvore, 1);

                            if (dominio == 'Consumer Care') {
                                var dados = '<table>' +
                                   '<tr><td><img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="principal.aspx?tipoArvore=Arvore Produtos" >Arvore Produtos</a></td></tr>' +
                                   '<tr><td>  <img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="principal.aspx?tipoArvore=Arvore Backoffice" >Arvore Backoffice</a></td></tr>' +
                                   '<tr><td>    <img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="principal.aspx?tipoArvore=Arvore Solution Center" >Arvore Solution Center</a></td></tr>' +
                                   '<tr><td>    <img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="<%=urlVolta%>" target="_top" >Sair</a></td></tr>' +
                           '</table>';

                        //document.getElementById('arvore').innerHTML = dados;
                    }

                    else if (dominio == 'Trade Marketing') {
                        var dados = '<table>' +
                           '<tr><td><img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="principal.aspx?tipoArvore=Arvore Produtos" >Arvore Produtos</a></td></tr>' +
                           '<tr><td>    <img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="principal.aspx?tipoArvore=Arvore Solution Center" >Arvore Solution Center</a></td></tr>' +
                            '<tr><td>    <img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="<%=urlVolta%>" target="_top" >Sair</a></td></tr>' +

                           '</table>';

                        // document.getElementById('arvore').innerHTML = dados;
                    }

                    else if (dominio == 'Service Center') {
                        var dados = "<font color=red>Sem permissão para acessar.</font>";

                        // document.getElementById('arvore').innerHTML = dados;
                    }

                    carregaPrincipal(tipoAcesso);

                }
            });


                }, error: function (jqXHR, textStatus, errorThrown) {
                    //caso nao achou o internal , busca pelo external



                    $.ajax({
                        url: url + "/v1/people/username=" + userName + "?SabaCertificate=" + certificate + "&type=external",
                        type: 'get',
                        dataType: 'json',
                        success: function (data) {
                            var obj = JSON.stringify(data);
                            if (obj.indexOf("Consumer Care") != -1) {
                                dominio = "Consumer Care";
                            }
                            else if (obj.indexOf("Trade Marketing") != -1) {
                                dominio = "Trade Marketing";
                            }
                            else if (obj.indexOf("Service Center") != -1) {
                                dominio = "Service Center";
                            }
                            else if (obj.indexOf("Contact Center") != -1) {
                                dominio = "Service Center";
                            }


                            var pais = "Brazil";

                            if (obj.indexOf("BRA -") != -1) {
                                pais = "Brazil";
                            }
                            else if (obj.indexOf("ARG -") != -1) {
                                pais = "Argentina";
                            }
                            else if (obj.indexOf("CHI -") != -1) {
                                pais = "Chile";
                            }
                            else if (obj.indexOf("EQU -") != -1) {
                                pais = "Equador";
                            }
                            else if (obj.indexOf("COL -") != -1) {
                                pais = "Colombia";
                            }
                            else if (obj.indexOf("MEX -") != -1) {
                                pais = "Mexico";
                            }
                            else if (obj.indexOf("PER -") != -1) {
                                pais = "Peru";
                            }
                            else if (obj.indexOf("UWM -") != -1) {
                                pais = "UWM";
                            }
                            else if (obj.indexOf("PUB -") != -1) {
                                pais = "PUB";
                            }



                            var fname = obj.substring(obj.indexOf('"fname":"') + 9, obj.length);
                            fname = fname.substring(0, fname.indexOf('","'));
                            var lname = obj.substring(obj.indexOf('"lname":"') + 9, obj.length);
                            lname = lname.substring(0, lname.indexOf('","'));
							
							fname = data["fname"];
					lname = data["lname"];
					
                            nome = fname + " " + lname;



                            var custom6 = obj.substring(obj.indexOf('custom6'), obj.length);
							
							var conteudo = obj.substring(obj.indexOf(',"id":"'), obj.length);
							conteudo = conteudo.replace(',"id":"', '');
							conteudo = conteudo.substring(0, conteudo.indexOf('"}'));
							conteudo = conteudo.replace('"}', '');

                            var idPessoa = custom6.substring(custom6.indexOf('"id":"') + 6, custom6.length - 2);
							
							idPessoa = conteudo;
							
							idPessoa = data["id"];

                            if (obj.indexOf("(Brasil)") != -1) {
                                idioma = "pt-BR";
                            }
                            else if (obj.indexOf("English") != -1) {
                                idioma = "en-US";
                            }
                            else {
                                idioma = "es-ES";
                            }

                            $.ajax({
                                url: url + "/v1/people/" + idPessoa + ":(securityRoles)?SabaCertificate=" + certificate,
                                type: 'get',
                                dataType: 'json',
                                success: function (data) {
                                    var obj = JSON.stringify(data);

                                    if (obj.indexOf("Super User") != -1) {
                                        tipoAcesso = "administrador";
                                    } else {
                                        tipoAcesso = "usuario";
                                    }

                                    SetCookie("pais", pais, 1);
                                    SetCookie("idioma", idioma, 1);
                                    SetCookie("tipoAcesso", tipoAcesso, 1);
                                    SetCookie("nome", nome, 1);
                                    SetCookie("username", userName, 1);
                                    SetCookie("urlVolta", urlVolta, 1);

                                    SetCookie("usuario", userName, 1);
                                    SetCookie("idUser", idUser, 1);

                                    if (dominio == 'Consumer Care') {
                                        var dados = '<table>' +
                                             '<tr><td>    <img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="principal.aspx?tipoArvore=Arvore Solution Center" >Arvore Solution Center</a></td></tr>' +
                                              '<tr><td>    <img src="../includes/arvore/imagens/seta.png" class="img-responsive"/></img></td><Td><a href="<%=urlVolta%>" target="_top" >Sair</a></td></tr>' +

                                           '</table>';

                                        // document.getElementById('arvore').innerHTML = dados;
                                    }



                                    else {
                                        var dados = "<font color=red>Sem permissão para acessar.</font>";

                                        //document.getElementById('arvore').innerHTML = dados;
                                    }

                                    carregaPrincipal(tipoAcesso);

                                }
                            });


                        }, error: function (jqXHR, textStatus, errorThrown) {
                            var dados = "<font color=red>Sem permissão para acessar.</font>";

                            //document.getElementById('arvore').innerHTML = dados;

                        }
                    });


                }
           });

        });


        function carregaPrincipal(tipoAcesso) {

            //if (tipoAcesso == 'usuario') {

            //} else {
            console.log('Tipo arvore: ', tipoArvore);
            document.location = "principal.aspx?tipoArvore=" + tipoArvore + "&idUser=" + idUser + "&usuario=" + userName + "&username=" + userName + "&tipoAcesso=" + tipoAcesso + "&nome=" + nome + "&idioma=" + idioma + "&pais=" + '<%=pais%>' + "&idUser=" + '<%=idUser%>';
            //}

            
        }


    </script>

</head>
<body>

</body>
</html>
