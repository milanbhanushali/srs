#pragma checksum "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74df0e561ea2e3e6e76c0bf066ecf352ad7190ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ServiceProvider_ServiceHistory), @"mvc.1.0.view", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
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
#line 5 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74df0e561ea2e3e6e76c0bf066ecf352ad7190ba", @"/Views/ServiceProvider/ServiceHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_ServiceProvider_ServiceHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Helperland.Models.ViewModel.SPServiceHistoryViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "/img/calendar2.png", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "/img/clock.png", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
  
    ViewData["Title"] = "Customer Dashboard";
    Layout = "~/Views/Shared/_LayoutServiceProvider.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--#region Right Side Table-->\r\n<span class=\"d-none\" id=\"userID\"");
            BeginWriteAttribute("value", " value=\"", 283, "\"", 326, 1);
#nullable restore
#line 8 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 291, Context.Session.GetInt32("userID"), 291, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></span>\r\n<span class=\"d-none\" id=\"userEmail\"");
            BeginWriteAttribute("value", " value=\"", 372, "\"", 419, 1);
#nullable restore
#line 9 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 380, Context.Session.GetString("userEmail"), 380, 39, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"></span>

<div class=""col-md-9"">
    <div class=""row p-3"">
        <div class=""col-md-12 table-responsive"">
            <table id=""tbleServiceRequestHistory"" class=""table table-hover"">
                <thead>
                    <tr>
                        <td>Service Id </td>
                        <td>Service Date </td>
                        <td>Customer Details </td>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 23 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                     foreach (var item in Model)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr class=\"custom-pointer\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1009, "\"", 1052, 3);
            WriteAttributeValue("", 1019, "OpenModel(", 1019, 10, true);
#nullable restore
#line 25 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 1029, item.ServiceRequestId, 1029, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1051, ")", 1051, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"modal\" data-bs-target=\"#ServiceDetails\">\r\n                            <td class=\"custom-pointer\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1166, "\"", 1209, 3);
            WriteAttributeValue("", 1176, "OpenModel(", 1176, 10, true);
#nullable restore
#line 26 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 1186, item.ServiceRequestId, 1186, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1208, ")", 1208, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-bs-toggle=\"modal\" data-bs-target=\"#ServiceDetails\"> ");
#nullable restore
#line 26 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                                                                                       Write(item.ServiceRequestId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                            <td");
            BeginWriteAttribute("onclick", " onclick=\"", 1329, "\"", 1372, 3);
            WriteAttributeValue("", 1339, "OpenModel(", 1339, 10, true);
#nullable restore
#line 27 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 1349, item.ServiceRequestId, 1349, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1371, ")", 1371, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"custom-pointer flex\" data-bs-toggle=\"modal\" data-bs-target=\"#ServiceDetails\">\r\n                                <div>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "74df0e561ea2e3e6e76c0bf066ecf352ad7190ba8483", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 28 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("<b> ");
#nullable restore
#line 28 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                                                            Write(item.ServiceDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b> </div>\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "74df0e561ea2e3e6e76c0bf066ecf352ad7190ba10467", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 29 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" 8.:00 - 12:00\r\n                            </td>\r\n                            <td class=\"custom-pointer\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1776, "\"", 1819, 3);
            WriteAttributeValue("", 1786, "OpenModel(", 1786, 10, true);
#nullable restore
#line 31 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
WriteAttributeValue("", 1796, item.ServiceRequestId, 1796, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1818, ")", 1818, 1, true);
            EndWriteAttribute();
            WriteLiteral(@" data-bs-toggle=""modal"" data-bs-target=""#ServiceDetails"">
                                <div class=""d-flex"">
                                    <div class=""center""><img src=""/img/home.png""></div>
                                    <div>
                                        <span class=""d-block""> ");
#nullable restore
#line 35 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                          Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                        <span class=\"d-block\"> ");
#nullable restore
#line 36 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                          Write(item.AddressLine1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                        <span class=\"d-block\"> ");
#nullable restore
#line 37 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                                                          Write(item.AddressLine2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </span>\r\n                                    </div>\r\n                                </div>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 42 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </tbody>
            </table>
        </div>
    </div>

</div>
<!--#endregion Right Side Table-->
<!--#region Modal  Service Details -->
<div class=""modal fade"" id=""ServiceDetails"" tabindex=""-1"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered "">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"">Service Details</h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close""></button>
            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"" id=""ModelMainDiv"">
                        <div>
                            <span id=""ModelServiceDate"" class=""font-bold h5""></span> 8:00 - 13:00<br />
                            <span class=""font-bold""> Duration </span><span id=""ModelDuration""> </span> Hrs
                        </div>
           ");
            WriteLiteral(@"             <hr />
                        <div>
                            <span class=""font-bold""> Service Id: </span><span id=""ModelServiceRequestId""> </span>.<br />
                            <span class=""font-bold""> Extras </span> <span id=""ModelExtra""></span><br />
                            <span class=""font-bold""> Net Amount: </span> <span id=""ModelTotalCost"" class=""font-blue font-bold""></span> €<br />
                        </div>
                        <hr />
                        <div>
                            <span class=""font-bold"">Customer Name: </span><span id=""ModelCustomerName""> </span><br />
                            <span class=""font-bold""> Service Address :-  </span><span id=""ModelServiceAddress""> </span>.

                        </div>
                        <hr />
                        <div>
                            <span class=""font-bold""> Comments </span> <br /> <span id=""ModelComments""> </span>
                        </div>
                        ");
            WriteLiteral(@"<hr />
                        <span id=""ModalHasPets""></span>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<!--#endregion Modal  Service Details -->
<!--#region Script-->
<script type=""text/javascript"" charset=""utf8"" src=""https://code.jquery.com/jquery-3.5.1.js""></script>
<script src=""https://cdn.jsdelivr.net/npm/bootstrap@3.3.7/dist/js/bootstrap.min.js"" integrity=""sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa"" crossorigin=""anonymous""></script>
<script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.11.5/js/jquery.dataTables.min.js""></script>
<script type=""text/javascript"" charset=""utf8"" src=""https://cdn.datatables.net/1.11.5/js/dataTables.bootstrap5.min.js""></script>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/dataTables.buttons.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js""></scri");
            WriteLiteral(@"pt>
<script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/2.2.2/js/buttons.html5.min.js""></script>
<script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.53/vfs_fonts.js""></script>

<script>

    //#region Data Table
    $(document).ready(function () {
        $.noConflict();
        $('#tbleServiceRequestHistory').dataTable({
            ""bFilter"": false,
            ""bInfo"": true,
            'aoColumnDefs': [{ 'bSortable': false, 'aTargets': [-1] }],
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'excel',
                    text: 'Export',
                    className: 'btn btn-primary'
                }
            ]
        });
    });
    //#endregion Data Table

    //#region Service Details
        function OpenModel(para) {
            $(""#ServiceDetails"").modal('show');
            $(""#ModelServiceRequestId"").text(para);
            $.ajax({
                 type: ""POST"",");
            WriteLiteral("\r\n                 url: \"");
#nullable restore
#line 127 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\ServiceProvider\ServiceHistory.cshtml"
                  Write(Url.Action("GetServiceRequestData"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
                 data: { ""ServiceReqestId"": para },
                 success: function (responce) {
                     var obj = JSON.parse(responce);
                     $(""#ModelDuration"").text(obj.TotalHour);
                     $(""#ModelServiceDate"").text(obj.ServiceDate);
                     $(""#ModelExtra"").text(obj.Extra);
                     $(""#ModelTotalCost"").text(obj.TotalCost);
                     $(""#ModelServiceAddress"").text(obj.Address);
                     $(""#ModelCustomerName"").text(obj.CustomerName);
                     $(""#ModelComments"").text(obj.Comments);
                     if (obj.hasPets) {
                         $(""#ModalHasPets"").text(""✔ I have pets"");
                     }
                     else {
                         $(""#ModalHasPets"").text(""✘ I don't have pets"");
                     }
                 },
                 failure: function (response) {
                        alert(""failure because of "" + response);
                 }");
            WriteLiteral(",\r\n                error: function (response) {\r\n                    alert(\"Something went Wrong because of \" + response);\r\n                 }\r\n\r\n              });\r\n        }\r\n    //#endregion Service Details\r\n\r\n</script>\r\n<!--#endregion Script-->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Helperland.Models.ViewModel.SPServiceHistoryViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
