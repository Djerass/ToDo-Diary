#pragma checksum "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3451180b55fed81b58451b1ccc2a640612605efe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/_ViewImports.cshtml"
using ToDoDiaryWeb;

#line default
#line hidden
#line 2 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/_ViewImports.cshtml"
using ToDoDiaryWeb.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3451180b55fed81b58451b1ccc2a640612605efe", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba33c8137d1ee440c227e870a3f9673a8503d0c1", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ToDo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ChooseDate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
#line 2 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(71, 323, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1c214d41ced4c1da7d8f869d5efdf0b", async() => {
                BeginContext(137, 250, true);
                WriteLiteral("\r\n   <div class=\"form-group\">\r\n   \r\n   \r\n    <input name=\"date\" required=\"\" type=\"text\" class=\"form-control\" placeholder=\"Choose day\" onfocus=\"(this.type=\'date\')\"/>\r\n    \r\n    </div>\r\n    <input  type=\"submit\" class=\"btn btn-primary\" value=\"Show\"/>\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(394, 482, true);
            WriteLiteral(@"
<div class=""dropdown form-group"">
  <a class=""btn btn-secondary dropdown-toggle"" href=""#"" role=""button"" id=""dropdownMenuLink"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
    Выпадающая ссылка
  </a>

  <div class=""dropdown-menu"" aria-labelledby=""dropdownMenuLink"">
    <a class=""dropdown-item"" href=""/Home/ChangeViewtoAll"">Show all</a>
    <a class=""dropdown-item"" href=""/Home/ChangeViewtoFalse"">Show only not finished</a>
    
  </div>
</div>

");
            EndContext();
#line 26 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
 if (Model.Any())
{

#line default
#line hidden
            BeginContext(898, 142, true);
            WriteLiteral("  <table class=\"table\">\r\n<tr>\r\n  \r\n    <th>Description</th>\r\n    <th>DeadLine</th>\r\n    <th>Status</th>\r\n    <th></th>\r\n    <th></th>\r\n</tr>\r\n");
            EndContext();
#line 37 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
 foreach (var item in Model)
{
    

#line default
#line hidden
            BeginContext(1079, 44, true);
            WriteLiteral("        <tr>\r\n            \r\n            <td>");
            EndContext();
            BeginContext(1124, 46, false);
#line 42 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
            EndContext();
            BeginContext(1170, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1194, 39, false);
#line 43 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Date));

#line default
#line hidden
            EndContext();
            BeginContext(1233, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1257, 41, false);
#line 44 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
            EndContext();
            BeginContext(1298, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1322, 63, false);
#line 45 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
           Write(Html.ActionLink("Change Status", "Change", new {Id = @item.Id}));

#line default
#line hidden
            EndContext();
            BeginContext(1385, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1409, 61, false);
#line 46 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
           Write(Html.ActionLink("Delete task", "Delete", new {Id = @item.Id}));

#line default
#line hidden
            EndContext();
            BeginContext(1470, 22, true);
            WriteLiteral("</td>\r\n        </tr>\r\n");
            EndContext();
#line 48 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
    
}

#line default
#line hidden
            BeginContext(1501, 12, true);
            WriteLiteral("</table>  \r\n");
            EndContext();
#line 51 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1525, 35, true);
            WriteLiteral("    <div>Nothing planed yet</div>\r\n");
            EndContext();
#line 55 "/home/azariah/ToDoDiaryWebGit/ToDo-Diary/Views/Home/Index.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ToDo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
