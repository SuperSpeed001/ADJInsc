#pragma checksum "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6578810c6897100c6129dda17e3e5ca5449eb708"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bandeja__DatosPartial), @"mvc.1.0.view", @"/Views/Bandeja/_DatosPartial.cshtml")]
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
#line 1 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\_ViewImports.cshtml"
using ADJInsc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\_ViewImports.cshtml"
using ADJInsc.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6578810c6897100c6129dda17e3e5ca5449eb708", @"/Views/Bandeja/_DatosPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7fa21ac82120d6dd37a7ca8bd375a1be0fe7793", @"/Views/_ViewImports.cshtml")]
    public class Views_Bandeja__DatosPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ADJInsc.Models.ViewModels.InscViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<link rel=\"stylesheet\" href=\"https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css\" />\r\n");
#nullable restore
#line 4 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3></h3>
<div id=""idFormTablaFamilia"">

    <div class=""form-group card border-info"">

        <h5 class=""card-header text-light bg-info"">Datos del Grupo Familiar</h5>
        <div class=""card-body"">
            <button type=""button"" class=""btn btn-info float-right"" data-toggle=""modal"" data-target=""#modalInicialFamilia"">Agregar integrante al grupo familiar <i class=""fas fa-plus-circle""></i></button>
            <div></div>
            <table id=""tablaFamilia"" class=""table table-striped table-responsive"" cellspacing=""0"" width=""100%"">
                <!--table table-sm table-striped table-hover border-bottom table table-bordered mb-0-->
                <thead>
                    <tr>

                        <th>
                            Nombre y Apellido
                        </th>
                        <th>
                            Número de Documento
                        </th>
                        <th>
                            Nacimiento
                        </");
            WriteLiteral(@"th>
                        <th>
                            Discapacidad ?
                        </th>
                        <th>
                            Parentesco
                        </th>
                        <th>
                            #
                        </th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 40 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                     if (Model.GrupoFamiliar.Count() > 0)
                    {
                        foreach (var item in Model.GrupoFamiliar)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                ");
#nullable restore
#line 45 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                           Write(Html.HiddenFor(modelItem => item.InsfNumdoc, new { id = "idEscondido" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                \r\n                                <td id=\"valorNombre\">\r\n                                    ");
#nullable restore
#line 48 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.InsfNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td id=\"valorDoc\">\r\n                                    ");
#nullable restore
#line 51 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.InsfNumdoc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td id=\"valorFec\">\r\n                                    ");
#nullable restore
#line 54 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FechaNacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n\r\n");
#nullable restore
#line 57 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                                 if (item.InsfDiscapacitado == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        Si\r\n                                    </td>\r\n");
#nullable restore
#line 62 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>\r\n                                        No\r\n                                    </td>\r\n");
#nullable restore
#line 68 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                <td id=\"valorP\">\r\n                                    ");
#nullable restore
#line 72 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                               Write(Html.DisplayFor(modelItem => item.ParentescoDesc, new { id = "idSoloParentesco" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n\r\n                                    <button id=\"btnDelete\" class=\"btn btn-outline-danger\" data-id=\"");
#nullable restore
#line 76 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                                                                                              Write(item.InsfNumdoc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" data data-toggle=""modal"" data-target=""#modalBorrar"">
                                        <i class=""fa fa-trash-o fa-lg""></i>
                                    </button>
                                    <button id=""btnModificar"" class=""btn btn-outline-success"" data-id=""");
#nullable restore
#line 79 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                                                                                                  Write(item.InsfNumdoc);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" data data-toggle=""modal"" data-target=""#modalModificarFamilia"">
                                        <i class=""fas fa-user-edit""></i>
                                    </button>

                                </td>
                            </tr>
");
#nullable restore
#line 85 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
                        }
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                <p>No hay datos para visualizar.</p>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 94 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n");
#nullable restore
#line 108 "D:\Proyectos NET\Temp\ADJInsc.Core\Views\Bandeja\_DatosPartial.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ADJInsc.Models.ViewModels.InscViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
