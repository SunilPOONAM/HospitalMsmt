#pragma checksum "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9d3fb58669e2d570ee4470ec4ecb039aa964ff3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Nurses_PatientList), @"mvc.1.0.view", @"/Views/Nurses/PatientList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9d3fb58669e2d570ee4470ec4ecb039aa964ff3", @"/Views/Nurses/PatientList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88caee22214edcd79e48d3dce45ad60c3b27aa44", @"/Views/_ViewImports.cshtml")]
    public class Views_Nurses_PatientList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Hospital.Models.SubAdmin.Patients>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddPrescriptions", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddDocument", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PatientDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
  
    ViewData["Title"] = "PatientList";
    Layout = "~/Views/Shared/_NursesLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n <div class=\"content\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12\">\r\n                        <h4 class=\"page-title page-title_main\">Patients</h4>\r\n                    </div>\r\n");
            WriteLiteral(@"                </div>


                <div class=""row"">
                    <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
                        <div class=""table-responsive"">
                            <table class=""table table-border table-striped custom-table datatable mb-0"">
                                <thead>
                                    <tr>
                                        <th>
                                            <i class=""fa fa-wheelchair"" aria-hidden=""true""></i>   ");
#nullable restore
#line 26 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                                             Write(Html.DisplayNameFor(model => model.PatientName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            <i class=\"fa fa-line-chart\" aria-hidden=\"true\"></i>  ");
#nullable restore
#line 29 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                                            Write(Html.DisplayNameFor(model => model.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            <i class=\"fa fa-envelope-o\" aria-hidden=\"true\"></i>  ");
#nullable restore
#line 32 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                                            Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                            <i class=\"fa fa-phone\" aria-hidden=\"true\"></i>  ");
#nullable restore
#line 35 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                                       Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </th>\r\n                                        <th>\r\n                                           <i class=\"fa fa-toggle-on\" aria-hidden=\"true\"></i> ");
#nullable restore
#line 38 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                                         Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </th>
                                        <th class=""text-center"">
                                            <i class=""fa fa-gavel""></i>  Actions
                                        </th>
                                    </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 46 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9d3fb58669e2d570ee4470ec4ecb039aa964ff38358", async() => {
                WriteLiteral("<i class=\"fa fa-plus-circle m-r-5\" style=\"font-size: 19px; color: forestgreen; float: left;\" title=\"Add Priscription\"></i>");
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
#line 50 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                           \r\n                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9d3fb58669e2d570ee4470ec4ecb039aa964ff310749", async() => {
                WriteLiteral("<i class=\"fa fa-upload m-r-5\" style=\"font-size: 19px; color: deepskyblue; float: left;\" title=\"Upload Document\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 52 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                            ");
#nullable restore
#line 53 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.PatientName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 56 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Age));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 59 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
#nullable restore
#line 62 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n");
#nullable restore
#line 65 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                             if (item.IsActive == "Active")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"custom-badge status-green\">\r\n                                                    ");
#nullable restore
#line 68 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </span>\r\n");
#nullable restore
#line 70 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                            }
                                            else if (item.IsActive == "IsActive")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <span class=\"custom-badge status-red\">\r\n                                                    ");
#nullable restore
#line 74 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                </span>\r\n");
#nullable restore
#line 76 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                            }
                                            else
                                             {

                                             }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </td>\r\n                                        <td class=\"text-center\">\r\n\r\n");
            WriteLiteral("                                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9d3fb58669e2d570ee4470ec4ecb039aa964ff316918", async() => {
                WriteLiteral("<i class=\"fa fa-info-circle m-r-5\" style=\"font-size: 19px; color: lightblue\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 85 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                                                             WriteLiteral(item.PatientID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" \r\n");
            WriteLiteral("\r\n                                        </td>\r\n\r\n                                          \r\n                                    </tr>\r\n");
#nullable restore
#line 92 "D:\Bitbu\hospitalmanagement\Hospital\Views\Nurses\PatientList.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n                        </div>\r\n                        </div>\r\n</div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Hospital.Models.SubAdmin.Patients>> Html { get; private set; }
    }
}
#pragma warning restore 1591
