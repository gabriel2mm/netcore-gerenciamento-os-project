#pragma checksum "C:\Users\gabri\source\repos\GDR\GDR\Views\Fragments\ActionsByUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80a66cb792d9dd9c9557fd99ea3e1204dc552f38"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Fragments_ActionsByUsers), @"mvc.1.0.view", @"/Views/Fragments/ActionsByUsers.cshtml")]
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
#line 1 "C:\Users\gabri\source\repos\GDR\GDR\Views\_ViewImports.cshtml"
using GDR;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\gabri\source\repos\GDR\GDR\Views\_ViewImports.cshtml"
using GDR.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80a66cb792d9dd9c9557fd99ea3e1204dc552f38", @"/Views/Fragments/ActionsByUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8c019d0c725705bb2e7e3f09db2f72ccb8ac556", @"/Views/_ViewImports.cshtml")]
    public class Views_Fragments_ActionsByUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\gabri\source\repos\GDR\GDR\Views\Fragments\ActionsByUsers.cshtml"
 if (User.IsInRole("Usuario"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li class=\"nav-item\">\r\n        <button class=\"btn btn-secondary\">Criar requisição</button>\r\n    </li>\r\n    <li class=\"nav-item\">\r\n        <button class=\"btn btn-secondary\">Criar Solicitação</button>\r\n    </li>\r\n");
#nullable restore
#line 9 "C:\Users\gabri\source\repos\GDR\GDR\Views\Fragments\ActionsByUsers.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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