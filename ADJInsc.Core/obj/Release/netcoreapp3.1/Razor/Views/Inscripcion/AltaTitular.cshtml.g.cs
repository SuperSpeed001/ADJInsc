#pragma checksum "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "63a1d641787d4f704ef5b11443ad6585de1f77c3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inscripcion_AltaTitular), @"mvc.1.0.view", @"/Views/Inscripcion/AltaTitular.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\_ViewImports.cshtml"
using ADJInsc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\_ViewImports.cshtml"
using ADJInsc.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"63a1d641787d4f704ef5b11443ad6585de1f77c3", @"/Views/Inscripcion/AltaTitular.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7fa21ac82120d6dd37a7ca8bd375a1be0fe7793", @"/Views/_ViewImports.cshtml")]
    public class Views_Inscripcion_AltaTitular : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ADJInsc.Models.ViewModels.UsuarioTitularViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Inscripcion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Inscripcion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Bandeja", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<p>
    <h2>Sistema de Inscripción / Actualización</h2>
</p>

<div id=""formTitular"" >
    <div class=""form-group card border-info"">
        <h3 class=""card-header text-light bg-info""> Titular</h3>
        <p class=""card-header text-light bg-info"">Cargar los datos del Titular</p>
        <div class=""form-row card-body"">
            <div class=""form-group col-md-6"">
                <input type=""text"" class=""form-control"" id=""inputDni"" placeholder=""D.N.I.""");
            BeginWriteAttribute("value", " value=\"", 527, "\"", 551, 1);
#nullable restore
#line 13 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 535, Model.InsNumdoc, 535, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n            </div>\r\n            <div class=\"form-group col-md-6\">\r\n                <input type=\"text\" class=\"form-control\" id=\"inputNombre\" placeholder=\" Apellido y Nombre \"");
            BeginWriteAttribute("value", " value=\"", 737, "\"", 761, 1);
#nullable restore
#line 16 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 745, Model.InsNombre, 745, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n\r\n            <div class=\"form-group col-md-6\">\r\n                ");
#nullable restore
#line 20 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
           Write(Html.DropDownListFor(x => Model.InsTipflia, Model.TipoFamiliaList ?? new List<SelectListItem>(), "----Selecciona Estado Civil----", htmlAttributes: new { @class = "form-control", id = "ddTipoFamiliaId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>
           
            <div class=""form-inline col-md-6"" style=""width:auto; margin-bottom:1px;"">
                
                
                    Cuit / Cuil
                    <input id=""inputCuitUno"" type=""number"" class=""form-control"" style=""width:16%; margin-left:4px;""> -
                    <input type=""text"" class=""form-control"" id=""inputCuitDos"" placeholder=""D.N.I.""");
            BeginWriteAttribute("value", " value=\"", 1464, "\"", 1488, 1);
#nullable restore
#line 28 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 1472, Model.InsNumdoc, 1472, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" disabled style=""width:40%""> -

                    <input id=""inputCuitTres"" type=""number"" class=""form-control"" style=""width:16%"">
                


            </div>

        </div>
    </div>
    <div class=""form-group card border-info"">
        <h5 class=""card-header text-light bg-info""> Registro de Usuario</h5>
        <p class=""card-header text-light bg-info"">Debe crear un usuario con su cuenta de correo electronico, finalizado se le mandará un email para verificar sus datos.</p>
        <div class=""form-row card-body"">
            <div class=""form-group col-md-6"">
                <input type=""email"" class=""form-control"" id=""inputEmail"" placeholder=""Correo""");
            BeginWriteAttribute("value", " value=\"", 2177, "\"", 2200, 1);
#nullable restore
#line 43 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 2185, Model.InsEmail, 2185, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n            <div class=\"form-group col-md-6\">\r\n                ");
#nullable restore
#line 46 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
           Write(Html.EditorFor(model => model.Usuario, new { htmlAttributes = new { @class = "form-control", @id = "inputRepEmail", placeholder = "Repetir Correo electrónico", onpaste = "return false" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <!-- <input type=\"email\" class=\"form-control\" id=\"inputRepEmail\" placeholder=\"Repetir Correo\" value=\"");
#nullable restore
#line 47 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
                                                                                                                Write(Model.Usuario);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">-->\r\n            </div>\r\n            <div class=\"form-group col-md-6\">\r\n                <input type=\"password\" class=\"form-control\" id=\"inputContraseña\" placeholder=\"Contraseña\"");
            BeginWriteAttribute("value", " value=\"", 2789, "\"", 2809, 1);
#nullable restore
#line 50 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 2797, Model.Clave, 2797, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                <span class=""fa fa-eye-slash icon"" id=""mostrar""> <span id=""pwdtxt"" style=""cursor:pointer;"">Mostrar contraseña</span></span>
            </div>
            <div class=""form-group col-md-6"">
                <input type=""password"" class=""form-control"" id=""inputRepetirContraseña"" placeholder=""Repetir Contraseña"">
                <span class=""fa fa-eye-slash icon"" id=""mostrarRe""> <span id=""pwdtxtRe"" style=""cursor:pointer;"">Mostrar contraseña</span></span>
            </div>
        </div>
    </div>

    <div class=""form-group"">
        <div class=""col-md-offset-2 col-md-10"">
            <input id=""btnCreate""  type=""submit"" value=""Guardar y enviar correo electrónico"" class=""btn btn-primary"" />
        </div>
    </div>
</div>



<div id=""modalSuccess"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Pre Inscripción</h5>");
            WriteLiteral("\n                <button type=\"button\" class=\"close\" data-dismiss=\"modal\" aria-label=\"Close\">\r\n                    <span aria-hidden=\"true\">&times;</span>\r\n                </button>\r\n            </div>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63a1d641787d4f704ef5b11443ad6585de1f77c311215", async() => {
                WriteLiteral(@"


                <div class=""modal-body card"">
                    <p>Se le mandó un correo electrónico para validar los datos, ingrese a su correo.</p>
                </div>
                <div class=""modal-footer"">
                    <button type=""submit"" id=""aceptarSuccess"" class=""btn btn-danger btnModal"">Aceptar</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>


<div class=""modal fade"" id=""loginModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""gridSystemModalLabel"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Login</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "63a1d641787d4f704ef5b11443ad6585de1f77c313825", async() => {
                WriteLiteral(@"
                <div class=""modal-body card"">

                    <div class=""form-group "">
                        <input class=""form-control"" type=""email""
                               placeholder=""Correo"" id=""inputUserName"" name=""inputUserName"" />
                    </div>
                    <div class=""form-group "">
                        <input class=""form-control"" placeholder=""Login Password""
                               type=""password"" id=""inputPassword"" name=""inputPassword"" />
                    </div>

                </div>
                <div class=""modal-footer"">
                    <button id=""loginClic"" type=""submit"" class=""btn btn-primary"">Iniciar</button>
                    <button type=""button"" id=""btnHideModal"" class=""btn btn-outline-info"">
                        Cerrar
                    </button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 132 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <style type=""text/css"">
        .span3 {
            position: relative;
            height: 200px;
            overflow: auto;
        }

        .card-body {
            padding-bottom: 0rem;
        }
    </style>

    <script type=""text/javascript"">


        /*$('#inputRepEmail').keyup(function (e) {
            var code = e.keyCode || e.which;
            var otroEmail = $(""#inputRepEmail"").val();
            var email = $(""#inputEmail"").val();
            if (code === 9) {

                if (otroEmail === email) {
                    $(""#btnCreate"").prop(""disabled"", false);
                } else {
                    e.stopPropagation();
                    $(""#btnCreate"").prop(""disabled"", true);
                    bootbox.alert({
                        size: ""small"",
                        title: ""I.V.U.J."",
                        message: ""Debes ingresar el correo correctamente."",
                        callback: function () { }
                    });
  ");
                WriteLiteral(@"              }

            }
        });*/

        $(function () {
            $(""#btnLogin"").click(function () {
                $(""#AjaxLoaderLogin"").show(""fast"");
                $(""#loginModal"").modal('show');
            });

            $(""#btnHideModal"").click(function () {
                $(""#loginModal"").modal('hide');
            });
        });

        function validarForm() {
            var dniId = $(""#inputDni"").val();
            var nombreId = $(""#inputNombre"").val();

            var tipoFamilia = $(""#ddTipoFamiliaId"").val();

            var usuario = $(""#inputRepEmail"").val();
            var emailId = $(""#inputEmail"").val();
            var clave = $(""#inputContraseña"").val();
            var repClave = $(""#inputRepetirContraseña"").val();

            var cuitUno = $(""#inputCuitUno"").val();
            var cuitTres = $(""#inputCuitTres"").val();

            var cont = 0;

            if (!cuitUno) {
                $(""#inputCuitUno"").css(""border-color"", ");
                WriteLiteral(@"""red"");
                cont++;
            } else {
                $(""#inputCuitUno"").css(""border-color"", ""green"");
            }

            if (!cuitTres) {
                $(""#inputCuitTres"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputCuitTres"").css(""border-color"", ""green"");
            }

            if (!dniId) {
                $(""#inputDni"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputDni"").css(""border-color"", ""green"");
            }

            if (!nombreId) {
                $(""#inputNombre"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputNombre"").css(""border-color"", ""green"");
            }

            if (!usuario) {
                $(""#inputRepEmail"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputRepEmail"").css(""border-color"", ""green"");
            }
");
                WriteLiteral(@"
            if (!clave) {
                $(""#inputContraseña"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputContraseña"").css(""border-color"", ""green"");
            }

            if (!repClave) {
                $(""#inputRepetirContraseña"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputRepetirContraseña"").css(""border-color"", ""green"");
            }

            if (!emailId) {
                $(""#inputEmail"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputEmail"").css(""border-color"", ""green"");
            }
            return cont;
        };

         $(function () {
            $(""#btnCreate"").click(function (e) {

                var dniId = $(""#inputDni"").val();
                var nombreId = $(""#inputNombre"").val();

                var tipoFamilia = $(""#ddTipoFamiliaId"").val();
                var usuario = $(""#inputRepE");
                WriteLiteral(@"mail"").val();
                var emailId = $(""#inputEmail"").val();
                var clave = $(""#inputContraseña"").val();
                var repClave = $(""#inputRepetirContraseña"").val();

                var cuitUno = $(""#inputCuitUno"").val();
                var cuitTres = $(""#inputCuitTres"").val();

                var cont = validarForm();


                if (cont == 0) {

                    if (clave === repClave && clave.length == repClave.length && emailId == usuario) {

                        if ( emailId.length > 0 && usuario.length > 0 && clave.length > 8
                        && dniId.length > 6 && nombreId.length > 0
                        ) {

                            var modeloCarga = {

                                clave: clave,
                                dni: dniId,
                                email: emailId,
                                nombre: nombreId,
                                tipoFamilia: tipoFamilia,
                           ");
                WriteLiteral("     usuario: usuario,\r\n                                cuitUno: cuitUno,\r\n                                cuitTres: cuitTres\r\n                            };\r\n                        $.ajax({\r\n                            url: \'");
#nullable restore
#line 294 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
                             Write(Url.Action("CargarDatos", "Inscripcion"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', //""/Solicitar/CreateAjax"",
                            data: JSON.stringify(modeloCarga),
                            type: ""post"",
                            contentType: ""application/json"",

                            success: function (response) {
                                console.log(response);
                                if (response === 'OK') {
                                    $(""#modalSuccess"").modal(""show"");
                                } else {
                                    e.preventDefault();
                                    bootbox.alert({
                                        size: ""small"",
                                        title: ""I.V.U.J."",
                                        message: response,
                                        callback: function () {
                                            //location.reload(true);
                                        }
                                    });
                              ");
                WriteLiteral(@"  }

                            },
                            error: function (response) {
                                console.log(response);
                                if (response === 'OK') {
                                    $(""#modalSuccess"").modal(""show"");
                                } else {
                                    e.preventDefault();
                                    bootbox.alert({
                                        size: ""small"",
                                        title: ""I.V.U.J."",
                                        message: response,
                                        callback: function () {
                                            //location.reload(true);
                                        }
                                    });
                                }

                            }
                        });
                        } else {
                            e.preventDefault();

             ");
                WriteLiteral(@"           bootbox.alert({
                            size: ""small"",
                            title: ""I.V.U.J."",
                            message: ""Datos ingresados de forma incorrecta"",
                            callback: function () { }
                        });
                        }

                    }

                    else {
                        e.preventDefault();
                        bootbox.alert({
                            size: ""small"",
                            title: ""I.V.U.J."",
                            message: ""El correo o la clave no Coinciden."",
                            callback: function () { }
                        });
                    }

                } else {

                    e.preventDefault();
                    bootbox.alert({
                        size: ""small"",
                        title: ""I.V.U.J."",
                        message: ""El formulario debe estar completo."",
                        callback: f");
                WriteLiteral(@"unction () { }
                    });
                }


            });

         });




        //Funciones para mostrar contraseña

        $(function () {
            $('#mostrar').click(function () {
                //Comprobamos que la cadena NO esté vacía.
                if ($(this).hasClass('fa-eye-slash') && ($(""#inputContraseña"").val() != """")) {
                    $('#inputContraseña').removeAttr('type');
                    $('#mostrar').addClass('fa-eye').removeClass('fa-eye-slash');
                    $('#pwdtxt').html(""Ocultar contraseña"");
                }
                else {
                    $('#inputContraseña').attr('type', 'password');
                    $('#mostrar').addClass('fa-eye-slash').removeClass('fa-eye');
                    $('#pwdtxt').html(""Mostrar contraseña"");
                }
            });

        });

        $(function () {
            $('#mostrarRe').click(function () {
                //Comprobamos que la cadena NO esté ");
                WriteLiteral(@"vacía.
                if ($(this).hasClass('fa-eye-slash') && ($(""#inputRepetirContraseña"").val() != """")) {
                    $('#inputRepetirContraseña').removeAttr('type');
                    $('#mostrarRe').addClass('fa-eye').removeClass('fa-eye-slash');
                    $('#pwdtxtRe').html(""Ocultar contraseña"");
                }
                else {
                    $('#inputRepetirContraseña').attr('type', 'password');
                    $('#mostrarRe').addClass('fa-eye-slash').removeClass('fa-eye');
                    $('#pwdtxtRe').html(""Mostrar contraseña"");
                }
            });

        });

        $(function () {
            $(""#aceptarSuccess"").submit(function (e) {
                e.preventDefault();
                $('#modalSuccess').modal('toggle');
                $.ajax({
                    url: '");
#nullable restore
#line 417 "C:\Viento Norte\ADJ\Inscripcion\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
                     Write(Url.Action("Inscripcion", "Inscripcion"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\'\r\n                });\r\n            });\r\n        });\r\n\r\n    </script>\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ADJInsc.Models.ViewModels.UsuarioTitularViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
