#pragma checksum "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\Shared\_LoadWorkersByDepartment.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fea0410187e3ade01a60be5a313d904ef6e8890d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoadWorkersByDepartment), @"mvc.1.0.view", @"/Views/Shared/_LoadWorkersByDepartment.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_LoadWorkersByDepartment.cshtml", typeof(AspNetCore.Views_Shared__LoadWorkersByDepartment))]
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
#line 1 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\_ViewImports.cshtml"
using HrPayrollSystemFinal;

#line default
#line hidden
#line 2 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\_ViewImports.cshtml"
using HrPayrollSystemFinal.Models;

#line default
#line hidden
#line 3 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\_ViewImports.cshtml"
using HrPayrollSystemFinal.Viewmodels;

#line default
#line hidden
#line 4 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 5 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\_ViewImports.cshtml"
using HrPayrollSystemFinal.Models.Enums;

#line default
#line hidden
#line 6 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\_ViewImports.cshtml"
using HrPayrollSystemFinal.Utilities;

#line default
#line hidden
#line 7 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\_ViewImports.cshtml"
using HrPayrollSystemFinal.ViewComponents;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fea0410187e3ade01a60be5a313d904ef6e8890d", @"/Views/Shared/_LoadWorkersByDepartment.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f7e33ea1fe9a0240e9f3d1f67c2cb0b4b08a0c52", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoadWorkersByDepartment : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CurrentWorkPlace>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(38, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(40, 54, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "573f901b9a3a4ddf9213f01ef124d92d", async() => {
                BeginContext(57, 28, true);
                WriteLiteral("Departament adı daxil edin..");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(94, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 5 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\Shared\_LoadWorkersByDepartment.cshtml"
 foreach (var worker in Model)
{

#line default
#line hidden
            BeginContext(133, 105, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c77adf05e5684e2e8afddfb2896e94f0", async() => {
                BeginContext(161, 18, false);
#line 7 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\Shared\_LoadWorkersByDepartment.cshtml"
                      Write(worker.Worker.Name);

#line default
#line hidden
                EndContext();
                BeginContext(179, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(181, 21, false);
#line 7 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\Shared\_LoadWorkersByDepartment.cshtml"
                                          Write(worker.Worker.Surname);

#line default
#line hidden
                EndContext();
                BeginContext(202, 1, true);
                WriteLiteral(" ");
                EndContext();
                BeginContext(204, 24, false);
#line 7 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\Shared\_LoadWorkersByDepartment.cshtml"
                                                                 Write(worker.Worker.FatherName);

#line default
#line hidden
                EndContext();
                BeginContext(228, 1, true);
                WriteLiteral(" ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 7 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\Shared\_LoadWorkersByDepartment.cshtml"
   WriteLiteral(worker.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(238, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 8 "C:\Users\Murad-PC\Desktop\HrManagementAndPayrollSystem\HrPayrollSystemFinal\HrPayrollSystemFinal\Views\Shared\_LoadWorkersByDepartment.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CurrentWorkPlace>> Html { get; private set; }
    }
}
#pragma warning restore 1591