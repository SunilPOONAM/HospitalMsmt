#pragma checksum "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "582bde2fc81c49d3d1af82303bdcf9a0339bf9c4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HospitalAdmin_DoctorList), @"mvc.1.0.view", @"/Views/HospitalAdmin/DoctorList.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"582bde2fc81c49d3d1af82303bdcf9a0339bf9c4", @"/Views/HospitalAdmin/DoctorList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"88caee22214edcd79e48d3dce45ad60c3b27aa44", @"/Views/_ViewImports.cshtml")]
    public class Views_HospitalAdmin_DoctorList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Hospital.Models.ApplicationUser>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddDoctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn_doctor btn btn-success btn-rounded float-right"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EditDoctor", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DoctorDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/admin/js/pages/DeleteSweetAlert/All.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
  
    ViewData["Title"] = "DoctorList";
    Layout = "~/Views/Shared/_HospitalAdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    tbody tr:hover {
        background: lavender !important;
    }
</style>

<script src=""https://ajax.googleapis.com/ajax/libs/jquery/2.1.0/jquery.min.js""></script>
<script src=""https://unpkg.com/sweetalert/dist/sweetalert.min.js""></script>

");
#nullable restore
#line 18 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
Write(Html.Raw(TempData["msg"]));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<nav aria-label=""breadcrumb"">
    <ol class=""breadcrumb"">
        <li class=""breadcrumb-item""><a href=""/HospitalAdmin/index"" class=""main_page"">Dashboard</a></li>
        <li class=""breadcrumb-item active"" aria-current=""page"">Doctor List</li>

    </ol>
</nav>
<div class=""content"">
    <div class=""row"">
        <div class=""col-xs-12 col-sm-12 col-md-12 col-lg-12 col-xl-12"">
            <h2 class=""page-title page-title_main"">Doctors</h2>
        </div>
    </div>


    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""table-responsive"">
                <input type=""text"" id=""myInput"" onkeyup=""myFunction()"" placeholder=""Search for names.."" title=""Type in a name"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "582bde2fc81c49d3d1af82303bdcf9a0339bf9c46504", async() => {
                WriteLiteral("<i class=\"fa fa-plus\"></i> Add Doctor");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <br />
                <table class=""table table-border table-striped custom-table datatable mb-0"" id=""myTable"" style="" margin-top: 10px;"">
                    <thead>
                        <tr>
                            <th>
                                <i class=""fa fa-user-md""></i>  Doctor Name
                            </th>
                            <th>
                                <i class=""fa fa-trophy"" aria-hidden=""true""></i>  Specialization
                            </th>
                            <th>
                                <i class=""fa fa-history"" aria-hidden=""true""></i>   Experience
                            </th>
                            <th>
                                <i class=""fa fa-phone"" aria-hidden=""true""></i>    PhoneNumber
                            </th>
                            <th>
                                <i class=""fa fa-envelope-o"" aria-hidden=""true""></i>  Email
                            </th>
     ");
            WriteLiteral(@"                       <th>
                                <i class=""fa fa-medkit"" aria-hidden=""true""></i>    Availiablity
                            </th>
                            <th class=""text-center"">
                                <i class=""fa fa-gavel""></i> Actions
                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 67 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 71 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                               Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 74 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Specialization));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 77 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Experience));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 80 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                               Write(Html.DisplayFor(modelItem => item.PhoneNumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 83 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n");
#nullable restore
#line 86 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                                     if (item.Availiablity == "Available")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"custom-badge status-green\">\r\n                                            ");
#nullable restore
#line 89 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Availiablity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </span>\r\n");
#nullable restore
#line 91 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                                    }
                                    else if (item.Availiablity == "Not Available")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"custom-badge status-red\">\r\n                                            ");
#nullable restore
#line 95 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Availiablity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </span>\r\n");
#nullable restore
#line 97 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                                    }
                                    else if (item.Availiablity == "On Leave")
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"custom-badge status-blue\">\r\n                                            ");
#nullable restore
#line 101 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Availiablity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                        </span>\r\n");
#nullable restore
#line 103 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                                    }
                                    else
                                    {

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td class=\"text-center\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "582bde2fc81c49d3d1af82303bdcf9a0339bf9c414471", async() => {
                WriteLiteral("<i class=\"fa fa-pencil-square-o\" style=\"font-size: 19px\"></i>");
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
#line 111 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
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
            WriteLiteral(" |\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "582bde2fc81c49d3d1af82303bdcf9a0339bf9c416740", async() => {
                WriteLiteral("<i class=\"fa fa-info-circle m-r-5\" style=\"font-size: 19px; color: lightblue\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 112 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
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
            WriteLiteral(" |\r\n");
            WriteLiteral("                                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 5805, "\"", 5845, 3);
            WriteAttributeValue("", 5815, "DeleteDoctorAction(\'", 5815, 20, true);
#nullable restore
#line 115 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
WriteAttributeValue("", 5835, item.Id, 5835, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5843, "\')", 5843, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <i class=\"fa fa-trash-o m-r-5\" style=\"font-size: 19px; color: red\"></i>\r\n                                    </a>\r\n\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 121 "D:\Bitbu\hospitalmanagement\Hospital\Views\HospitalAdmin\DoctorList.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
                <script>
                    function myFunction() {
                        var input, filter, table, tr, td, i, txtValue;
                        input = document.getElementById(""myInput"");
                        filter = input.value.toUpperCase();
                        table = document.getElementById(""myTable"");
                        tr = table.getElementsByTagName(""tr"");
                        for (i = 0; i < tr.length; i++) {
                            td = tr[i].getElementsByTagName(""td"")[0];
                            if (td) {
                                txtValue = td.textContent || td.innerText;
                                if (txtValue.toUpperCase().indexOf(filter) > -1) {
                                    tr[i].style.display = """";
                                } else {
                                    tr[i].style.display = ""none"";
                                }
                          ");
            WriteLiteral("  }\r\n                        }\r\n                    }\r\n                </script>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "582bde2fc81c49d3d1af82303bdcf9a0339bf9c421263", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Hospital.Models.ApplicationUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591