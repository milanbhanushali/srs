#pragma checksum "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\Home\FAQ.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffbab27b1b724b614038c79f021ca9dcf70bbf04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_FAQ), @"mvc.1.0.view", @"/Views/Home/FAQ.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffbab27b1b724b614038c79f021ca9dcf70bbf04", @"/Views/Home/FAQ.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5f94cf04a7ec23f27ac33992ef127038e0b3154", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_FAQ : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/faq.webp"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-fluid"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/img/separator.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_partialLoginView", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\Home\FAQ.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";
    ViewData["Title"] = "FAQ";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--#region FAQ Main Page Image-->\r\n\r\n<div class=\"faq-main-page-img\">\r\n    <div class=\"container-fluid p-0\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ffbab27b1b724b614038c79f021ca9dcf70bbf045306", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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

<!--#endregion FAQ Main Page Image-->
<!--#region FAQ Main page code-->
<section class=""faq-main-page"">
    <div class=""container"">
        <div class=""row text-center"">
            <div class=""custom-faq-text-heading "">FAQs</div>
        </div>
        <div class=""row"">
            <div class=""col-12 text-center"">
                <span>
                    <span class=""separator-line""></span>
                    <span> ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ffbab27b1b724b614038c79f021ca9dcf70bbf046973", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n                    <span class=\"separator-line\"></span>\r\n                </span>\r\n            </div>\r\n        </div>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ffbab27b1b724b614038c79f021ca9dcf70bbf048231", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
#nullable restore
#line 30 "D:\Extra\TatvaSoft\SRS\srs\Helperland\Helperland\Helperland\Views\Home\FAQ.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("view", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <div class=""row my-4"">
            <div class=""offset-3 col-6 justify-content-center text-center"">
                Whether you are Customer or Service provider, We have tried our best to solve all your queries and questions.
            </div>
        </div>
        <div class=""row my-4"">
            <div class=""col-2""></div>
            <div class=""col-8 text-center"">
                <button class=""col-md-5 col-sm-6 btn-custom-color btn-lg"">FOR CUSTOMER</button>
                <button class=""col-md-5 col-sm-6 btn btn-lg custom-customer-service-button custom-btn-service"">
                    FOR SERVICE
                    PROVIDER
                </button>
            </div>
        </div>
        <div class=""row my-4"">
            <div class=""offset-1 col-10"">
                <div class=""accordion"">
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section1"" class=""accordion__input"">
                        <span>
             ");
            WriteLiteral(@"               <label for=""section1"" class=""accordion__label""></label>
                            <span class=""custom-accordion-heading"">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                                Vestibulum nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                            </span>
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id diam tincidunt, fringilla ante vitae,
                                dapibus velit. Vivamus id tortor rhoncus, efficitur quam at, suscipit tortor. Integer fermentum
                                convallis eros vel semper. Ut non imperdiet velit. Praesent eu dui vel lacus porta eleifend eget quis
                                dui. Integer tempus massa in gravida tincidunt. Fusce in libero tristique, euismod nisi vel, luct");
            WriteLiteral(@"us
                                urna. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec et placerat arcu.
                                Suspendisse lacinia tristique massa. Etiam risus justo, scelerisque id arcu eu, sodales tempor eros.
                                Aliquam efficitur pretium urna, sit amet congue risus malesuada rutrum. Donec id massa vel velit
                                ullamcorper accumsan ut eget nisl. Fusce viverra commodo lacus, sit amet facilisis leo luctus dictum.
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section2"" class=""accordion__input"">
                        <span>
                            <label for=""section2"" class=""accordion__label""></label>
                            <span class=""custom-accordion-heading"">
                                Lorem ipsum dolor sit amet, consectetur adipisc");
            WriteLiteral(@"ing elit.
                                Vestibulum nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                            </span>
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed id diam tincidunt, fringilla ante vitae,
                                dapibus velit. Vivamus id tortor rhoncus, efficitur quam at, suscipit tortor. Integer fermentum
                                convallis eros vel semper. Ut non imperdiet velit. Praesent eu dui vel lacus porta eleifend eget quis
                                dui. Integer tempus massa in gravida tincidunt. Fusce in libero tristique, euismod nisi vel, luctus
                                urna. Interdum et malesuada fames ac ante ipsum primis in faucibus. Donec et placerat arcu.
                                Suspendisse lacinia tristique massa. Etiam risus justo, sce");
            WriteLiteral(@"lerisque id arcu eu, sodales tempor eros.
                                Aliquam efficitur pretium urna, sit amet congue risus malesuada rutrum. Donec id massa vel velit
                                ullamcorper accumsan ut eget nisl. Fusce viverra commodo lacus, sit amet facilisis leo luctus dictum.
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section3"" class=""accordion__input"">
                        <label for=""section3"" class=""accordion__label""></label>
                        <span class=""custom-accordion-heading"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
                            nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                        </span>
                        <div class=""accordion__content"">
                            <p>
                             ");
            WriteLiteral(@"   Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam sit reiciendis, ipsam quaerat,
                                aperiam perspiciatis ad ullam architecto impedit natus illo nostrum molestias voluptas earum a
                                voluptatibus fugiat fuga facere!
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section4"" class=""accordion__input"">
                        <label for=""section4"" class=""accordion__label""></label>
                        <span class=""custom-accordion-heading"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
                            nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum");
            WriteLiteral(@" dolor sit amet consectetur adipisicing elit. Numquam sit reiciendis, ipsam quaerat,
                                aperiam perspiciatis ad ullam architecto impedit natus illo nostrum molestias voluptas earum a
                                voluptatibus fugiat fuga facere!
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section5"" class=""accordion__input"">
                        <label for=""section5"" class=""accordion__label""></label>
                        <span class=""custom-accordion-heading"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
                            nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum dolor sit ame");
            WriteLiteral(@"t consectetur adipisicing elit. Numquam sit reiciendis, ipsam quaerat,
                                aperiam perspiciatis ad ullam architecto impedit natus illo nostrum molestias voluptas earum a
                                voluptatibus fugiat fuga facere!
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section6"" class=""accordion__input"">
                        <label for=""section6"" class=""accordion__label""></label>
                        <span class=""custom-accordion-heading"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
                            nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum dolor sit amet consectetur ");
            WriteLiteral(@"adipisicing elit. Numquam sit reiciendis, ipsam quaerat,
                                aperiam perspiciatis ad ullam architecto impedit natus illo nostrum molestias voluptas earum a
                                voluptatibus fugiat fuga facere!
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section7"" class=""accordion__input"">
                        <label for=""section7"" class=""accordion__label""></label>
                        <span class=""custom-accordion-heading"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
                            nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing el");
            WriteLiteral(@"it. Numquam sit reiciendis, ipsam quaerat,
                                aperiam perspiciatis ad ullam architecto impedit natus illo nostrum molestias voluptas earum a
                                voluptatibus fugiat fuga facere!
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section8"" class=""accordion__input"">
                        <label for=""section8"" class=""accordion__label""></label>
                        <span class=""custom-accordion-heading"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
                            nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam si");
            WriteLiteral(@"t reiciendis, ipsam quaerat,
                                aperiam perspiciatis ad ullam architecto impedit natus illo nostrum molestias voluptas earum a
                                voluptatibus fugiat fuga facere!
                            </p>
                        </div>
                    </div>
                    <div>
                        <input type=""radio"" name=""example_accordion"" id=""section9"" class=""accordion__input"">
                        <label for=""section9"" class=""accordion__label""></label>
                        <span class=""custom-accordion-heading"">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum
                            nisl nunc, iaculis mattis tellus ac ut non imperdiet velit?
                        </span>
                        <div class=""accordion__content"">
                            <p>
                                Lorem ipsum dolor sit amet consectetur adipisicing elit. Numquam sit reiciendis, ");
            WriteLiteral(@"ipsam quaerat,
                                aperiam perspiciatis ad ullam architecto impedit natus illo nostrum molestias voluptas earum a
                                voluptatibus fugiat fuga facere!
                            </p>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <br>
    <br>
    <br>
    <br>
</section>
    <!--#endregion FAQ Main page code-->
    <!--#region Get our new letter-->
        <div class=""container mt-4"">
            <section class=""our-news-letter bg-white"">
                <div class=""container text-center"">
                    <h2 class=""custom-get-our-newsletter-heading"">GET OUR NEWSLETTER</h2>
                    <div class=""form-row d-flex justify-content-center align-items-center"">
                        <div class=""form-group"">
                            <label for=""email"" style=""display: none;"">YOUR EMAIL</label>
                            <input type=""t");
            WriteLiteral(@"ext"" placeholder=""YOUR EMAIL"" id=""email"" onkeyup=""EnableDisable(this)"" class=""form-control"">
                        </div>
                        <div class=""btn-wrapper"">
                            <button class=""red-btn"" id=""btnSubmit"" disabled=""disabled"">Submit</button>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    <!--#endregion Get our new letter-->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
