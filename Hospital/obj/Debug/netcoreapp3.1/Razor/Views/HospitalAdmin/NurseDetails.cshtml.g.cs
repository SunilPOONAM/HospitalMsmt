#pragma checksum "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba86d427d1a514b4a745f7901f2aaaa657a90bfc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HospitalAdmin_NurseDetails), @"mvc.1.0.view", @"/Views/HospitalAdmin/NurseDetails.cshtml")]
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
#line 1 "D:\Bitbu\hospitalmanagement\Hospital\Views\_ViewImports.cshtml"
using Hospital;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Bitbu\hospitalmanagement\Hospital\Views\_ViewImports.cshtml"
using Hospital.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba86d427d1a514b4a745f7901f2aaaa657a90bfc", @"/Views/HospitalAdmin/NurseDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88caee22214edcd79e48d3dce45ad60c3b27aa44", @"/Views/_ViewImports.cshtml")]
    public class Views_HospitalAdmin_NurseDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hospital.Models.ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditNurse", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "HospitalAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "NurseDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Are you sure want to delete this nurse ?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
  
    ViewData["Title"] = "NurseDetails";
    Layout = "~/Views/Shared/_HospitalAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <style>
        .export-pagination li a:hover {
            background: #086972;
            color: #fff;
        }
    </style>

    <nav aria-label=""breadcrumb"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                <ol class=""breadcrumb"">
                    <li class=""breadcrumb-item""><a href=""/HospitalAdmin/index"" class=""main_page"">Dashboard</a></li>
                    <li class=""breadcrumb-item active"" aria-current=""page"">Nurse Details</li>
                </ol>
            </div>
        </div>
    </nav>
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                <h4 class=""page-title page-title_main"">Nurse Details</h4>
            </div>
        </div>
        <div class=""row"">
            <!-- Widget Item -->
            <div class=""col-md-12"">
                <div class=""widget-area-2 proclinic-box-shadow"">
    ");
            WriteLiteral(@"                <div class=""table-responsive"">
                        <table class=""table table-bordered table-striped"">
                            <tbody>
                                <tr>
                                    <td>
                                        <h4>  ");
#nullable restore
#line 41 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                         Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>  ");
#nullable restore
#line 43 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                     Write(Html.DisplayFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>  ");
#nullable restore
#line 47 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                         Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                                    </td>\r\n                                    <td>   ");
#nullable restore
#line 49 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                      Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>");
#nullable restore
#line 54 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 57 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                   Write(Html.DisplayFor(model => model.Street));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4> ");
#nullable restore
#line 62 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                        Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 65 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                   Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>");
#nullable restore
#line 70 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                       Write(Html.DisplayNameFor(model => model.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 73 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                   Write(Html.DisplayFor(model => model.State));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>");
#nullable restore
#line 78 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                       Write(Html.DisplayNameFor(model => model.ZipCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 81 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                   Write(Html.DisplayFor(model => model.ZipCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>");
#nullable restore
#line 86 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                       Write(Html.DisplayNameFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 89 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                   Write(Html.DisplayFor(model => model.Country));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n                                <tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4> ");
#nullable restore
#line 95 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                        Write(Html.DisplayNameFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                                    </td>\r\n                                    <td>  ");
#nullable restore
#line 97 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                     Write(Html.DisplayFor(model => model.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>   ");
#nullable restore
#line 101 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                          Write(Html.DisplayNameFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>   ");
#nullable restore
#line 103 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                      Write(Html.DisplayFor(model => model.Gender));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4> ");
#nullable restore
#line 107 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                        Write(Html.DisplayNameFor(model => model.BloodGroup));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                                    </td>\r\n                                    <td> ");
#nullable restore
#line 109 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                    Write(Html.DisplayFor(model => model.BloodGroup));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>   ");
#nullable restore
#line 113 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                          Write(Html.DisplayNameFor(model => model.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n                                    </td>\r\n                                    <td>   ");
#nullable restore
#line 115 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                      Write(Html.DisplayFor(model => model.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td>\r\n                                        <h4>  ");
#nullable restore
#line 119 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                         Write(Html.DisplayNameFor(model => model.Availiablity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                                    </td>\r\n                                    <td>  ");
#nullable restore
#line 121 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                     Write(Html.DisplayFor(model => model.Availiablity));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                </tr>\r\n                            </tbody>\r\n                        </table>\r\n\r\n                        <div>\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba86d427d1a514b4a745f7901f2aaaa657a90bfc17292", async() => {
                WriteLiteral("<i class=\"fa fa-pencil m-r-5\"></i> Edit Nurse");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 127 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                                        WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba86d427d1a514b4a745f7901f2aaaa657a90bfc19614", async() => {
                WriteLiteral("<i class=\"fa fa-trash-o m-r-5\"></i> Delete Nurse");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 129 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\NurseDetails.cshtml"
                                                                                                                     WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
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
                </div>
            </div>
        </div>
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                <nav aria-label=""Page navigation example"" style=""padding-left: 39px; z-index: 2;"">
                    <ul class=""pagination export-pagination"">
                        <li class=""page-item"">
                            <a class=""page-link"" href=""#""><span class=""fa fa-download ""></span> csv</a>
                        </li>
                        <li class=""page-item"">
                            <a class=""page-link"" href=""#""><span class=""fa fa-printer""></span> print</a>
                        </li>
                        <li class=""page-item"">
                            <a class=""page-link"" href=""#""><span class=""fa fa-file ""></span> PDF</a>
                        </li>
                        <li class=""page-item"">
                            <a class=""p");
            WriteLiteral("age-link\" href=\"#\"><span class=\"fa fa-align-justify\"></span> Excel</a>\r\n                        </li>\r\n                    </ul>\r\n                </nav>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hospital.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591