#pragma checksum "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffdafcfde622ef33eb32b340230f00de2ee03dff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Restaurantes_VerRestaurante), @"mvc.1.0.view", @"/Views/Restaurantes/VerRestaurante.cshtml")]
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
#line 1 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\_ViewImports.cshtml"
using LabProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\_ViewImports.cshtml"
using LabProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffdafcfde622ef33eb32b340230f00de2ee03dff", @"/Views/Restaurantes/VerRestaurante.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da0c2a20cf237f40765043e4193852e67d1571cf", @"/Views/_ViewImports.cshtml")]
    public class Views_Restaurantes_VerRestaurante : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LabProject.Models.RestaurantePratosPertence>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Grid_style.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ffdafcfde622ef33eb32b340230f00de2ee03dff4221", async() => {
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
            WriteLiteral("\r\n\r\n\r\n");
            WriteLiteral("\r\n<div class=\"VerGridRectangle\">\r\n    <div class=\"VerRestauranteBanner\"");
            BeginWriteAttribute("style", " style=\'", 1899, "\'", 2019, 3);
            WriteAttributeValue("", 1907, "background-image:url(\"../../Images/Utilizadores/", 1907, 48, true);
#nullable restore
#line 51 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
WriteAttributeValue("", 1955, Html.DisplayFor(model => model.Restaurante.Utilizador.Imagem), 1955, 62, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2017, "\")", 2017, 2, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n    <div class=\"VerRestauranteNome\">");
#nullable restore
#line 52 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
                               Write(Html.DisplayFor(model => model.Restaurante.Utilizador.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n</div>\r\n\r\n<div class=\"VerInformacoes\">\r\n    <div class=\"VerInformacoesDescricao\">\r\n        <p>\r\n            <span class=\"VerSpan\"><i class=\"fas fa-phone-alt\"></i></span>\r\n            ");
#nullable restore
#line 60 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
       Write(Html.DisplayFor(model => model.Restaurante.Telefone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n        <p>\r\n            <span class=\"VerSpan\"><i class=\"far fa-envelope\"></i></span>\r\n            ");
#nullable restore
#line 64 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
       Write(Html.DisplayFor(model => model.Restaurante.Utilizador.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n        <span class=\"VerSpan\" style=\" float: left; margin-top: 5px; margin-left: 20px; margin-right: 10px;\"><i class=\"far fa-clock\"></i></span>\r\n        <p>\r\n            Exceto ");
#nullable restore
#line 68 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
              Write(Html.DisplayFor(model => model.Restaurante.DiaDescanso));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n        <p style=\" margin-top: -20px; margin-left: 50px;\">\r\n            ");
#nullable restore
#line 71 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
       Write(Html.DisplayFor(model => model.Restaurante.HoraAbertura));

#line default
#line hidden
#nullable disable
            WriteLiteral("h - ");
#nullable restore
#line 71 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
                                                                    Write(Html.DisplayFor(model => model.Restaurante.HoraFecho));

#line default
#line hidden
#nullable disable
            WriteLiteral("h\r\n        </p>\r\n        <p><span class=\"VerSpan\"><i class=\"fas fa-map-marker-alt\"></i></span>\r\n            ");
#nullable restore
#line 74 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
       Write(Html.DisplayFor(model => model.Restaurante.Morada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n    </div>\r\n    <div class=\"VerInformacoesMapa\" style=\"background-color:lightgreen\"></div>\r\n\r\n</div>\r\n\r\n\r\n\r\n<div class=\"verGridContainer\">\r\n");
#nullable restore
#line 85 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
     foreach (var item in Model.Pratos)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"VerGridSquare\"");
            BeginWriteAttribute("onClick", " onClick=\"", 3394, "\"", 3455, 3);
            WriteAttributeValue("", 3404, "reply_click(", 3404, 12, true);
#nullable restore
#line 87 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
WriteAttributeValue("", 3416, Html.DisplayFor(modelItem => item.Id), 3416, 38, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3454, ")", 3454, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        <div class=\"VerGridSquareNome\">");
#nullable restore
#line 88 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
                                   Write((item.Nome.Length <= 13) ? item.Nome : item.Nome.Substring(0, 13) + "...");

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n        <div class=\"VerGridSquareCentral\">\r\n            <div class=\"VerGridSquareCentralTexto\">\r\n                <p style=\"margin-top: 15px;\">Tipo: ");
#nullable restore
#line 91 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
                                               Write(item.TipoPrato.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p>Preço: ");
#nullable restore
#line 92 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
                      Write((item.Preco).ToString("#.00") + " €");

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <div class=\"VerGridSquareCentralFoto\"");
            BeginWriteAttribute("style", " style=\'", 3898, "\'", 3960, 3);
            WriteAttributeValue("", 3906, "background-image:url(../../Images/Pratos/", 3906, 41, true);
#nullable restore
#line 94 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
WriteAttributeValue("", 3947, item.Foto, 3947, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3959, ")", 3959, 1, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n        </div>\r\n        <p class=\"VerGridSquareDesc\" >Descrição: ");
#nullable restore
#line 96 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"
                                             Write(item.Descricao);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
            WriteLiteral("\r\n\r\n    </div>\r\n");
#nullable restore
#line 102 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Restaurantes\VerRestaurante.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n\r\n<script>\r\n\r\n    $(\".flex-child.Container\").height($(document).height());\r\n\r\n\r\n\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LabProject.Models.RestaurantePratosPertence> Html { get; private set; }
    }
}
#pragma warning restore 1591
