#pragma checksum "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03d8be800415433a04b08df79c8a6a4851643d96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_BlockCustomer), @"mvc.1.0.view", @"/Views/ServiceProvider/BlockCustomer.cshtml")]
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
#line 1 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\_ViewImports.cshtml"
using Helperland.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03d8be800415433a04b08df79c8a6a4851643d96", @"/Views/ServiceProvider/BlockCustomer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_BlockCustomer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Helperland.Models.ViewModel.BlockCustomerViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/gray-cap.webp"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
  
    ViewData["Title"] = "Block Customer";
    Layout = "~/Views/Shared/_LayoutServiceProvider.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--#region Right Side Table-->\r\n<span class=\"d-none\" id=\"userID\"");
            BeginWriteAttribute("value", " value=\"", 276, "\"", 319, 1);
#nullable restore
#line 8 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
WriteAttributeValue("", 284, Context.Session.GetInt32("userID"), 284, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n<span class=\"d-none\" id=\"userEmail\"");
            BeginWriteAttribute("value", " value=\"", 365, "\"", 412, 1);
#nullable restore
#line 9 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
WriteAttributeValue("", 373, Context.Session.GetString("userEmail"), 373, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n<div class=\"col-md-9\">\r\n    <div class=\"row \">\r\n");
#nullable restore
#line 12 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-md-3 p-2 m-3  border border-dark\">\r\n                <div class=\"mx-auto d-block custom-border-cap\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "03d8be800415433a04b08df79c8a6a4851643d965878", async() => {
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
            WriteLiteral("\r\n                </div>\r\n                <div class=\"text-center mt-3 mb-3\"> <h5>  ");
#nullable restore
#line 18 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                                                     Write(item.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h5></div>\r\n");
#nullable restore
#line 19 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                 if (!item.IsBlock)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"text-center mb-2\">\r\n                        <button class=\"btn btn-danger font-white rounded-pill\"");
            BeginWriteAttribute("value", " value=\"", 1009, "\"", 1029, 1);
#nullable restore
#line 22 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
WriteAttributeValue("", 1017, item.UserId, 1017, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"BlockCustomer(this.value)\"> Block</button>\r\n                    </div>\r\n");
#nullable restore
#line 24 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"text-center mb-2\">\r\n                        <button class=\"btn btn-success font-white rounded-pill\"");
            BeginWriteAttribute("value", " value=\"", 1303, "\"", 1323, 1);
#nullable restore
#line 28 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
WriteAttributeValue("", 1311, item.UserId, 1311, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" onclick=\"UnBlockCustomer(this.value)\"> Unblock</button>\r\n                    </div>\r\n");
#nullable restore
#line 30 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
#nullable restore
#line 32 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>
</div>
<!--#endregion Right Side Table-->
<!--#region Script-->
<script type=""text/javascript"" charset=""utf8"" src=""https://code.jquery.com/jquery-3.5.1.js""></script>
<script src=""https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/js/bootstrap.min.js"" integrity=""sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"" crossorigin=""anonymous""></script>
<script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js""></script>
<script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.11.5/js/dataTables.bootstrap5.min.js""></script>
<script>

    //#region Block Customer
    function BlockCustomer(id)
    {
        $.ajax
        ({
                 type: ""POST"",
                 url: """);
#nullable restore
#line 49 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                  Write(Url.Action("BlockThisCustomer"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                 data: { ""userId"": id },
                 success: function (responce) {
                     if (responce) {
                         location.reload();
                     }
                 },
                 failure: function (response) {
                    alert(""failure because of "" + response);
                 },
                 error: function (response) {
                    alert(""Something went Wrong because of "" + response);
                 }
         });
    }
    //#endregion Block Customer

    //#region Unblock Customer
    function UnBlockCustomer(id)
    {
         $.ajax({
                  type: ""POST"",
                  url: """);
#nullable restore
#line 71 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\BlockCustomer.cshtml"
                   Write(Url.Action("UnblockThisCustomer"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                  data: { ""userId"": id },
                 success: function (responce) {
                     if (responce) {
                         location.reload();
                     }
                 },
             failure: function (response) {
                 alert(""failure because of "" + response);
                 },
             error: function (response) {
                 alert(""Something went Wrong because of "" + response);
                 }
              });
    }
    //#endregion Unblock Customer
</script>
<!--#endregion Script-->   ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Helperland.Models.ViewModel.BlockCustomerViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
