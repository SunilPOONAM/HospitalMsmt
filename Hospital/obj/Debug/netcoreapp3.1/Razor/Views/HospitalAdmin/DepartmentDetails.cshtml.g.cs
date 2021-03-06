#pragma checksum "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a846ea3ca32fc5250c6df77e4590b32116317f7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HospitalAdmin_DepartmentDetails), @"mvc.1.0.view", @"/Views/HospitalAdmin/DepartmentDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a846ea3ca32fc5250c6df77e4590b32116317f7c", @"/Views/HospitalAdmin/DepartmentDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88caee22214edcd79e48d3dce45ad60c3b27aa44", @"/Views/_ViewImports.cshtml")]
    public class Views_HospitalAdmin_DepartmentDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Hospital.Models.SubAdmin.Department>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditDepartment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger mb-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "HospitalAdmin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DepartmentDelete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("return confirm(\'Are you sure want to delete this Department?\')"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_HospitalAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/HospitalAdmin/index"" class=""main_page"">Dashboard</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">Department Details</li>

    </ol>
</nav>
<div class=""container-fluid"">
    <div class=""row"">
        <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
            <h4 class=""page-title page-title_main"">Department Details</h4>
        </div>
    </div>
    <div class=""row"">
        <!-- Widget Item -->
        <div class=""col-md-12"">
            <div class=""widget-area-2 proclinic-box-shadow"">
                <div class=""table-responsive"">
                    <table class=""table table-bordered table-striped"">
                        <tbody>
                            <tr>
                                <td><h4>");
#nullable restore
#line 28 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                   Write(Html.DisplayNameFor(model => model.DepartmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4></td>\r\n                                <td> ");
#nullable restore
#line 29 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                Write(Html.DisplayFor(model => model.DepartmentName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td><h4> ");
#nullable restore
#line 32 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                    Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4></td>\r\n                                <td> ");
#nullable restore
#line 33 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td><h4> ");
#nullable restore
#line 36 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                    Write(Html.DisplayNameFor(model => model.DepartmentStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4></td>\r\n                                <td> ");
#nullable restore
#line 37 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                Write(Html.DisplayFor(model => model.DepartmentStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
                            </tr>
                        </tbody>
                    </table>
                    <nav aria-label=""Page navigation example"">
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
                                <a class=""page-link"" href=""#""><span class=""fa fa-align-justify ""></span> Excel</a>
                            </li>
");
            WriteLiteral("                        </ul>\r\n                    </nav>\r\n                    <div>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a846ea3ca32fc5250c6df77e4590b32116317f7c9722", async() => {
                WriteLiteral("<i class=\"fa fa-pencil m-r-5\"></i>Edit Department");
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
#line 58 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                                         WriteLiteral(Model.DepartmentID);

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
            WriteLiteral("\r\n\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a846ea3ca32fc5250c6df77e4590b32116317f7c12058", async() => {
                WriteLiteral("<i class=\"fa fa-trash-o m-r-5\"></i> Delete Department");
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
#line 60 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DepartmentDetails.cshtml"
                                                                                                                      WriteLiteral(Model.DepartmentID);

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
            WriteLiteral("\r\n\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n            ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Hospital.Models.SubAdmin.Department> Html { get; private set; }
    }
}
#pragma warning restore 1591
