#pragma checksum "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\ExisteInsc.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27e03a8b6f738bd8119d23166730b9176c2b4bd0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Inscripcion_ExisteInsc), @"mvc.1.0.view", @"/Views/Inscripcion/ExisteInsc.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27e03a8b6f738bd8119d23166730b9176c2b4bd0", @"/Views/Inscripcion/ExisteInsc.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7fa21ac82120d6dd37a7ca8bd375a1be0fe7793", @"/Views/_ViewImports.cshtml")]
    public class Views_Inscripcion_ExisteInsc : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ADJInsc.Models.ViewModels.UsuarioTitularViewModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27e03a8b6f738bd8119d23166730b9176c2b4bd03303", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Advertencia</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "27e03a8b6f738bd8119d23166730b9176c2b4bd04368", async() => {
                WriteLiteral(@"


    <div class=""modal fade in"" id=""loginModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""gridSystemModalLabel"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Login</h5>
                </div>
                <div class=""modal-body card"">
                   
                        <p>Usted pertenece a un grupo familiar</p>
                            <div>
                                <div class=""modal-body card"">


                                    <h4>
                                        Usted está inscripto al grupo familiar del titular <strong>");
#nullable restore
#line 27 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\ExisteInsc.cshtml"
                                                                                              Write(Model.InsNombre);

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>  con D.N.I.: <strong>");
#nullable restore
#line 27 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\ExisteInsc.cshtml"
                                                                                                                                             Write(Model.InsNumdoc);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</strong>  <br/>
                                        Debe acercarse al I.V.U.Ju. para actualizar sus datos.
                                    </h4>
                                </div>
                                <div class=""modal-footer"">

                                    <button type=""button"" id=""btnHideModal"" class=""btn btn-outline-info"">
                                        Volver
                                    </button>
                                </div>
                            </div>

                </div>
            </div>
        </div>

    </div>

");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n</html>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 51 "D:\Proyectos NET\ADInsc\ADJInsc.Core\Views\Inscripcion\ExisteInsc.cshtml"
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
        $(function () {
            $(""#loginModal"").modal();
        });

        $(function () {

            $(""#btnLogin"").click(function () {
                $(""#AjaxLoaderLogin"").show(""fast"");
                $(""#loginModal"").modal('show');
            });

            $(""#btnHideModal"").click(function () {
                $(""#loginModal"").modal('hide');
                history.back();
            });
        });


    </script>
");
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
