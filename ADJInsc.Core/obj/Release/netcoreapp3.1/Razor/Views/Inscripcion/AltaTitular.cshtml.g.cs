#pragma checksum "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "94bbdaad858771f95afd94e498a9a4ce3e221c1e"
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
#line 1 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\_ViewImports.cshtml"
using ADJInsc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\_ViewImports.cshtml"
using ADJInsc.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94bbdaad858771f95afd94e498a9a4ce3e221c1e", @"/Views/Inscripcion/AltaTitular.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7fa21ac82120d6dd37a7ca8bd375a1be0fe7793", @"/Views/_ViewImports.cshtml")]
    public class Views_Inscripcion_AltaTitular : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ADJInsc.Models.ViewModels.UsuarioTitularViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("AjaxLoader"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Enviando ..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:none; width:60px; height:60px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/image/loader.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Inscripcion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GoHome", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Inscripcion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Bandeja", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"    
<p>
    <h2>Sistema de Inscripción / Actualización</h2>
</p>



<div id=""formTitular"">
    <div class=""form-group card border-info"">
        <h3 class=""card-header text-light bg-info""> Titular</h3>
        <p class="" text-light bg-info"">Cargar los datos del Titular</p>
        <div class=""form-row card-body"">
            <div class=""form-group col-md-6"">
                <input type=""text"" class=""form-control"" id=""inputDni"" placeholder=""D.N.I.""");
            BeginWriteAttribute("value", " value=\"", 523, "\"", 547, 1);
#nullable restore
#line 15 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 531, Model.InsNumdoc, 531, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" disabled>\r\n            </div>\r\n            <div class=\"form-group col-md-6\">\r\n                <input type=\"text\" class=\"form-control\" id=\"inputNombre\" placeholder=\" Apellido y Nombre \"");
            BeginWriteAttribute("value", " value=\"", 733, "\"", 757, 1);
#nullable restore
#line 18 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 741, Model.InsNombre, 741, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n            <div class=\"form-group col-md-6\">\r\n                <input type=\"text\" class=\"form-control\" id=\"inputTel\" placeholder=\" Teléfono (388 - )\"");
            BeginWriteAttribute("value", " value=\"", 930, "\"", 953, 1);
#nullable restore
#line 21 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 938, Model.InsTelef, 938, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n\r\n            <div class=\"form-group col-md-6\">\r\n                ");
#nullable restore
#line 25 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
           Write(Html.DropDownListFor(x => Model.InsTipflia, Model.TipoFamiliaList ?? new List<SelectListItem>(), "----Selecciona Estado Civil----", htmlAttributes: new { @class = "form-control", id = "ddTipoFamiliaId" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>

            <div class=""form-inline col-md-6"" style=""width:auto; margin-bottom:10px;"">


                Cuit / Cuil
                <input id=""inputCuitUno"" type=""number"" class=""form-control"" style=""width:16%; margin-left:4px;""> -
                <input type=""text"" class=""form-control"" id=""inputCuitDos"" placeholder=""D.N.I.""");
            BeginWriteAttribute("value", " value=\"", 1602, "\"", 1626, 1);
#nullable restore
#line 33 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 1610, Model.InsNumdoc, 1610, 16, false);

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
        <p class="" text-light bg-info"">Debe crear un usuario con su cuenta de correo electronico, finalizado se le mandará un email para verificar sus datos.</p>
        <div class=""form-row card-body"">
            <div class=""form-group col-md-6"">
                <input type=""email"" class=""form-control"" id=""inputEmail"" placeholder=""Correo""");
            BeginWriteAttribute("value", " value=\"", 2284, "\"", 2307, 1);
#nullable restore
#line 48 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 2292, Model.InsEmail, 2292, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            </div>\r\n            <div class=\"form-group col-md-6\">\r\n                ");
#nullable restore
#line 51 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
           Write(Html.EditorFor(model => model.Usuario, new { htmlAttributes = new { @class = "form-control", @id = "inputRepEmail", placeholder = "Repetir Correo electrónico", onpaste = "return false" } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                <!-- <input type=\"email\" class=\"form-control\" id=\"inputRepEmail\" placeholder=\"Repetir Correo\" value=\"");
#nullable restore
#line 52 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
                                                                                                                Write(Model.Usuario);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">-->\r\n            </div>\r\n            <div class=\"form-group col-md-6\">\r\n                <input type=\"password\" class=\"form-control\" id=\"inputContraseña\" placeholder=\"Contraseña\"");
            BeginWriteAttribute("value", " value=\"", 2896, "\"", 2916, 1);
#nullable restore
#line 55 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
WriteAttributeValue("", 2904, Model.Clave, 2904, 12, false);

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
        <div class=""form-row"">
            <div class=""form-group col-md-6"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "94bbdaad858771f95afd94e498a9a4ce3e221c1e12815", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <input id=\"btnCreate\" type=\"submit\" value=\"Guardar y enviar correo electrónico\" class=\"btn btn-outline-primary\" />\r\n            </div>\r\n            <div class=\"form-group col-md-6\" style=\"float:right;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94bbdaad858771f95afd94e498a9a4ce3e221c1e14349", async() => {
                WriteLiteral("\r\n                    <button class=\"btn btn-outline-danger float-sm-right\" id=\"btnLogin\">Cerrar y volver</button>\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
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

    
</div>



<div id=""modalSuccess"" class=""modal"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Pre Inscripción</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94bbdaad858771f95afd94e498a9a4ce3e221c1e16705", async() => {
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "94bbdaad858771f95afd94e498a9a4ce3e221c1e19315", async() => {
                WriteLiteral(@"
                <div class=""modal-body card"">

                    <div class=""form-group "">
                        <input class=""form-control"" type=""email""
                               placeholder=""Correo"" id=""inputUserName"" name=""inputUserName"" />
                    </div>
                    <div class=""form-group "">
                        <input class=""form-control"" placeholder=""Contraseña""
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
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
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
#line 149 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
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

            var telefono = $(""#inputTel"").val();
            var cont = 0;

            if (!telefono) {
    ");
                WriteLiteral(@"            $(""#inputTel"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputTel"").css(""border-color"", ""green"");
            }

            if (!cuitUno) {
                $(""#inputCuitUno"").css(""border-color"", ""red"");
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
                $(""#inputNombre"").css(""b");
                WriteLiteral(@"order-color"", ""green"");
            }

            if (!usuario) {
                $(""#inputRepEmail"").css(""border-color"", ""red"");
                cont++;
            } else {
                $(""#inputRepEmail"").css(""border-color"", ""green"");
            }

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
   ");
                WriteLiteral(@"         $(""#btnCreate"").click(function (e) {

                var dniId = $(""#inputDni"").val();
                var nombreId = $(""#inputNombre"").val();

                var tipoFamilia = $(""#ddTipoFamiliaId"").val();
                var usuario = $(""#inputRepEmail"").val();
                var emailId = $(""#inputEmail"").val();
                var clave = $(""#inputContraseña"").val();
                var repClave = $(""#inputRepetirContraseña"").val();

                var cuitUno = $(""#inputCuitUno"").val();
                var cuitTres = $(""#inputCuitTres"").val();
                var telefono = $(""#inputTel"").val();

                var cont = validarForm();
                $(""#AjaxLoader"").show(""fast"");

                if (cont == 0) {

                    if (clave === repClave && clave.length == repClave.length && emailId == usuario) {

                        if ( emailId.length > 0 && usuario.length > 0 && clave.length >= 6 
                        && dniId.length > 6 && nombreId.leng");
                WriteLiteral(@"th > 0 && telefono.length > 0
                        ) {
                            $(""#btnCreate"").attr(""disabled"", true);

                            var modeloCarga = {

                                clave: clave,
                                dni: dniId,
                                email: emailId,
                                nombre: nombreId,
                                tipoFamilia: tipoFamilia,
                                usuario: usuario,
                                cuitUno: cuitUno,
                                cuitTres: cuitTres,
                                telefono: telefono
                            };
                            $.ajax({
                             url: '");
#nullable restore
#line 322 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
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

                                 $(""#AjaxLoader"").delay(2000).hide(""slow"");

                                 if (response === 'OK') {
                                    
                                    $(""#modalSuccess"").modal(""show"");
                                } else {
                                    $(""#btnCreate"").attr(""disabled"", false);
                                    e.preventDefault();
                                    bootbox.alert({
                                        size: ""small"",
                                        title: ""I.V.U.J."",
                                        message: response,
                                        callba");
                WriteLiteral(@"ck: function () {
                                            //location.reload(true);
                                        }
                                    });
                                }

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
                                ");
                WriteLiteral(@"    });
                                }

                            }
                        });
                        } else {
                            e.preventDefault();

                        bootbox.alert({
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
                    boot");
                WriteLiteral(@"box.alert({
                        size: ""small"",
                        title: ""I.V.U.J."",
                        message: ""El formulario debe estar completo."",
                        callback: function () { }
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
                    $('#pwdtxt').html");
                WriteLiteral(@"(""Mostrar contraseña"");
                }
            });

        });

        $(function () {
            $('#mostrarRe').click(function () {
                //Comprobamos que la cadena NO esté vacía.
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
                $('#modalSuccess').modal('toggle');");
                WriteLiteral("\r\n                $.ajax({\r\n                    url: \'");
#nullable restore
#line 450 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\AltaTitular.cshtml"
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
