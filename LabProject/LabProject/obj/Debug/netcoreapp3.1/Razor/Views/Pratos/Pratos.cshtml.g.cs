#pragma checksum "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fda5f43a36c26b8639fda178d9fda5601bfd8edd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pratos_Pratos), @"mvc.1.0.view", @"/Views/Pratos/Pratos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fda5f43a36c26b8639fda178d9fda5601bfd8edd", @"/Views/Pratos/Pratos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da0c2a20cf237f40765043e4193852e67d1571cf", @"/Views/_ViewImports.cshtml")]
    public class Views_Pratos_Pratos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LabProject.Models.Prato>>
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "fda5f43a36c26b8639fda178d9fda5601bfd8edd5374", async() => {
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
            WriteLiteral(@"
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.js""></script>

<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/jqueryui/1.11.4/jquery-ui.min.css"">


<script>

    $(document).ready(function () {
        $(""#datepicker"").datepicker({
            dateFormat: 'mm-dd-yy',
            changeMonth: true,
            numberOfMonths: 1,
            buttonImage: 'contact/calendar/calendar.gif',
            buttonImageOnly: true,
            onSelect: function (selectedDate) {
                $(""#SubmitFilter"").click();
            }
        });

       
        $(""#datepicker"").datepicker(""setDate"", '");
#nullable restore
#line 26 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"
                                           Write(ViewData["SearchData"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n    \r\n\r\n\r\n});\r\n\r\n</script>\r\n\r\n<div class=\"SearchContainer\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fda5f43a36c26b8639fda178d9fda5601bfd8edd7654", async() => {
                WriteLiteral("\r\n        <input type=\"text\" name=\"SearchString\"");
                BeginWriteAttribute("value", " value=\"", 1063, "\"", 1097, 1);
#nullable restore
#line 36 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"
WriteAttributeValue("", 1071, ViewData["CurrentFilter"], 1071, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" placeholder=\"Procurar...\">\r\n        <input class=\"SearchBarDate\" type=\"text\" id=\"datepicker\" name=\"SearchData\"");
                BeginWriteAttribute("value", " value=\"", 1209, "\"", 1240, 1);
#nullable restore
#line 37 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"
WriteAttributeValue("", 1217, ViewData["SearchData"], 1217, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n        <button id=\"SubmitFilter\" type=\"submit\"><i class=\"fa fa-search\"></i></button>\r\n    ");
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
            WriteLiteral("\r\n\r\n</div>\r\nr\r\n\r\n\r\n<div class=\"GridContainer\">\r\n\r\n");
#nullable restore
#line 47 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"GridSquare\"");
            BeginWriteAttribute("onClick", " onClick=\"", 1464, "\"", 1525, 3);
            WriteAttributeValue("", 1474, "reply_click(", 1474, 12, true);
#nullable restore
#line 49 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"
WriteAttributeValue("", 1486, Html.DisplayFor(modelItem => item.Id), 1486, 38, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1524, ")", 1524, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n            <div class=\"GridSquareImagem\"");
            BeginWriteAttribute("style", " style=\'", 1570, "\'", 1640, 3);
            WriteAttributeValue("", 1578, "background-image:url(", 1578, 21, true);
#nullable restore
#line 50 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"
WriteAttributeValue("", 1599, Html.DisplayFor(modelItem => item.Foto), 1599, 40, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1639, ")", 1639, 1, true);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n");
            WriteLiteral("\r\n            <div class=\"GridSquareNome\">");
#nullable restore
#line 53 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Nome));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n        </div>\r\n");
#nullable restore
#line 56 "C:\Users\filip\Documents\UTAD\Lab\Prato_do_Dia\Prato_do_Dia\LabProject\LabProject\Views\Pratos\Pratos.cshtml"

    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <script type=""text/javascript"">


        function reply_click(Id) {
            //alert(id);
            //console.log(Id);

            var date = $(""#datepicker"").datepicker(""getDate"");

            var targetUrl = '/Pratos/VerPrato/' + Id.toString() + '/' + $.datepicker.formatDate(""yy-mm-dd"", date);
            location.href = targetUrl;

        };
    </script>





</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LabProject.Models.Prato>> Html { get; private set; }
    }
}
#pragma warning restore 1591
