#pragma checksum "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0531220dad9b4a531f0ac667087e4c96b70004a1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bandeja__Reporte), @"mvc.1.0.view", @"/Views/Bandeja/_Reporte.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0531220dad9b4a531f0ac667087e4c96b70004a1", @"/Views/Bandeja/_Reporte.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7fa21ac82120d6dd37a7ca8bd375a1be0fe7793", @"/Views/_ViewImports.cshtml")]
    public class Views_Bandeja__Reporte : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ADJInsc.Models.ViewModels.InscViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("row g-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2 class=\" text-light bg-info\">\r\n    Formulario de Pre- Inscripción I.V.U.J. 2021\r\n</h2>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0531220dad9b4a531f0ac667087e4c96b70004a13915", async() => {
                WriteLiteral("\r\n    <div class=\"col-md-6\">\r\n        <label for=\"inputEmail4\" class=\"form-label\">Titular</label>\r\n        <input type=\"email\" class=\"form-control\" id=\"inputEmail4\" disabled");
                BeginWriteAttribute("value", " value=\"", 394, "\"", 418, 1);
#nullable restore
#line 14 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
WriteAttributeValue("", 402, Model.InsNombre, 402, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"col-md-4\">\r\n        <label for=\"inputPassword4\" class=\"form-label\">Cuit / Cuil</label>\r\n        <input type=\"text\" class=\"form-control\" id=\"inputPassword4\" disabled");
                BeginWriteAttribute("value", " value=\"", 614, "\"", 637, 1);
#nullable restore
#line 18 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
WriteAttributeValue("", 622, Model.CuitCuil, 622, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"col-12\">\r\n        <label for=\"inputAddress\" class=\"form-label\">Fecha de alta</label>\r\n        <input type=\"text\" class=\"form-control\" id=\"inputAddress\" disabled");
                BeginWriteAttribute("value", " value=\"", 829, "\"", 853, 1);
#nullable restore
#line 22 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
WriteAttributeValue("", 837, Model.InsFecalt, 837, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"col-12\">\r\n        <label for=\"inputAddress2\" class=\"form-label\">Dirección</label>\r\n        <input type=\"text\" class=\"form-control\" id=\"inputAddress2\"");
                BeginWriteAttribute("value", " value=\"", 1034, "\"", 1058, 1);
#nullable restore
#line 26 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
WriteAttributeValue("", 1042, Model.Direccion, 1042, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n        <label for=\"inputCity\" class=\"form-label\">Departamento</label>\r\n        <input type=\"text\" class=\"form-control\" id=\"inputCity\"");
                BeginWriteAttribute("value", " value=\"", 1236, "\"", 1267, 1);
#nullable restore
#line 30 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
WriteAttributeValue("", 1244, Model.DepartamentoDesc, 1244, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    </div>\r\n    <div class=\"col-md-6\">\r\n        <label for=\"inputState\" class=\"form-label\">Localidad</label>\r\n        <input type=\"text\" class=\"form-control\" id=\"inputCity\"");
                BeginWriteAttribute("value", " value=\"", 1443, "\"", 1471, 1);
#nullable restore
#line 34 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
WriteAttributeValue("", 1451, Model.LocalidadDesc, 1451, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
    </div>

    <div class=""form-group"">

        <h5 class="" text-light bg-info"">Datos del Grupo Familiar</h5>
        <div>
      
            <div></div>
            <table id=""tablaFamilia"" class=""table table-striped table-responsive"" cellspacing=""0"" width=""100%"">
                <!--table table-sm table-striped table-hover border-bottom table table-bordered mb-0-->
                <thead>
                    <tr>

                        <th>
                            Nombre y Apellido
                        </th>
                        <th>
                            Documento
                        </th>
                        <th>
                            Nacimiento
                        </th>
                        <th>
                            Discapacidad ?
                        </th>
                        <th>
                            Veterano Mal. ?
                        </th>
                        <th>
                            Minero ");
                WriteLiteral("?\r\n                        </th>\r\n                        <th>\r\n                            Parentesco\r\n                        </th>\r\n                        \r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 73 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                     if (Model.GrupoFamiliar.Count() > 0)
                    {
                        foreach (var item in Model.GrupoFamiliar)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        ");
#nullable restore
#line 78 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                   Write(Html.HiddenFor(modelItem => item.InsfNumdoc, new { id = "idEscondido" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n                        <td id=\"valorNombre\">\r\n                            ");
#nullable restore
#line 81 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                       Write(Html.DisplayFor(modelItem => item.InsfNombre));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td id=\"valorDoc\">\r\n                            ");
#nullable restore
#line 84 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                       Write(Html.DisplayFor(modelItem => item.InsfNumdoc));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td id=\"valorFec\">\r\n                            ");
#nullable restore
#line 87 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FechaNacimiento));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n");
#nullable restore
#line 91 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                             if (item.InsfDiscapacitado == 1)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <p>Si</p>\r\n");
#nullable restore
#line 94 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <p>No</p>\r\n");
#nullable restore
#line 98 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 102 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                             if (item.InsfVeterano == 1)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <p>Si</p>\r\n");
#nullable restore
#line 105 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <p>No</p>\r\n");
#nullable restore
#line 109 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
#nullable restore
#line 113 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                             if (item.InsfMinero == 1)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <p>Si</p>\r\n");
#nullable restore
#line 116 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <p>No</p>\r\n");
#nullable restore
#line 120 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td id=\"valorP\">\r\n                            ");
#nullable restore
#line 124 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParentescoDesc, new { id = "idSoloParentesco" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n\r\n                    </tr>\r\n");
#nullable restore
#line 128 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                        }
                    }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                Sin Datos\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 135 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Bandeja\_Reporte.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                   \r\n                </tbody>\r\n            </table>\r\n\r\n        </div>\r\n\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ADJInsc.Models.ViewModels.InscViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
