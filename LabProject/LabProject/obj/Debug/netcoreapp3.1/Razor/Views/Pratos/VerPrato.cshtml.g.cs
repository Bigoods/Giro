#pragma checksum "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4bb19a953622733bb01ca66a9e7491a66346e581"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pratos_VerPrato), @"mvc.1.0.view", @"/Views/Pratos/VerPrato.cshtml")]
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
#line 1 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\_ViewImports.cshtml"
using LabProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\_ViewImports.cshtml"
using LabProject.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4bb19a953622733bb01ca66a9e7491a66346e581", @"/Views/Pratos/VerPrato.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1bc2a40b8065edfd6c86eb75dcc7227492c3940", @"/Views/_ViewImports.cshtml")]
    public class Views_Pratos_VerPrato : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LabProject.Models.Restaurante>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Grid_style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("SearchBar"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Pratos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 2 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
  Prato p = ViewData["PratoEscolhido"] as Prato;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "4bb19a953622733bb01ca66a9e7491a66346e5815273", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n<div class=\"SearchContainer\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4bb19a953622733bb01ca66a9e7491a66346e5816439", async() => {
                WriteLiteral("\r\n        <input type=\"text\" name=\"SearchString\"");
                BeginWriteAttribute("value", " value=\"", 305, "\"", 339, 1);
#nullable restore
#line 11 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
WriteAttributeValue("", 313, ViewData["CurrentFilter"], 313, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("placeholder", " placeholder=\"", 340, "\"", 361, 1);
#nullable restore
#line 11 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
WriteAttributeValue("", 354, p.Nome, 354, 7, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n        <button type=\"submit\"><i class=\"fa fa-search\"></i></button>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n\r\n<div class=\"GridContainer\">\r\n\r\n\r\n\r\n");
#nullable restore
#line 21 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
     foreach (var item in Model)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"GridRectangle\">\r\n            <div class=\"RestauranteBanner\"");
            BeginWriteAttribute("style", " style=\'", 616, "\'", 702, 3);
            WriteAttributeValue("", 624, "background-image:url(", 624, 21, true);
#nullable restore
#line 25 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
WriteAttributeValue("", 645, "../../Images/Utilizadores/" + item.Utilizador.Imagem, 645, 56, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 701, ")", 701, 1, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n            <div class=\"RestauranteNome\">");
#nullable restore
#line 26 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
                                    Write(Html.DisplayFor(modelItem => item.Utilizador.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            <div class=\"RestaurantePratosContainer\">\r\n                <div id=\"PratoEscolhido\" class=\"RestaurantePrato\">\r\n                    <div class=\"PratoEscolhidoDescricao\">\r\n                        <div>");
#nullable restore
#line 30 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
                         Write((p.Nome.Length <= 13) ? p.Nome : p.Nome.Substring(0, 13) + "...");

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                        <div class=\"PratoEscolhidoDescricaoPreco\">\r\n");
#nullable restore
#line 32 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
                             try
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
                            Write((item.RestaurantePratos.ToList().Single(s => s.PratoId == p.Id).Preco).ToString("#.00") + " €");

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
                                                                                                                                 ;
                            }
                            catch (Exception)
                            {

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                    </div>\r\n                    <div class=\"GridRectangleImagem\"");
            BeginWriteAttribute("style", " style=\'", 1616, "\'", 1680, 3);
            WriteAttributeValue("", 1624, "background-image:url(", 1624, 21, true);
#nullable restore
#line 42 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"
WriteAttributeValue("", 1645, "../../Images/Pratos/" + p.Foto, 1645, 34, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1679, ")", 1679, 1, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 47 "D:\Lab 3ºAno\Prato_do_Dia\LabProject\LabProject\Views\Pratos\VerPrato.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LabProject.Models.Restaurante>> Html { get; private set; }
    }
}
#pragma warning restore 1591
