#pragma checksum "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2431e5dd1e1c22d145728c4cff4bd97c05cad1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_SchedullingOrder), @"mvc.1.0.view", @"/Views/Order/SchedullingOrder.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Order/SchedullingOrder.cshtml", typeof(AspNetCore.Views_Order_SchedullingOrder))]
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
#line 1 "C:\Users\gabri\source\repos\GDR\GDR\Views\_ViewImports.cshtml"
using GDR;

#line default
#line hidden
#line 2 "C:\Users\gabri\source\repos\GDR\GDR\Views\_ViewImports.cshtml"
using GDR.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2431e5dd1e1c22d145728c4cff4bd97c05cad1e", @"/Views/Order/SchedullingOrder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8c019d0c725705bb2e7e3f09db2f72ccb8ac556", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_SchedullingOrder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GDR.Models.ModelsForViews.SchedulingViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
  
    ViewData["Title"] = "Complemento suporte tecnico";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(164, 54, true);
            WriteLiteral("<div class=\"container\">\r\n    <div class=\"jumbotron\">\r\n");
            EndContext();
#line 8 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
         using (Html.BeginForm(method: FormMethod.Post, new { @class = "form" }))
        {
            

#line default
#line hidden
            BeginContext(325, 23, false);
#line 10 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(350, 88, true);
            WriteLiteral("            <h5>Agendamento</h5>\r\n            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(439, 33, false);
#line 13 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
           Write(Html.HiddenFor(model => model.Id));

#line default
#line hidden
            EndContext();
            BeginContext(472, 76, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                ");
            EndContext();
            BeginContext(549, 41, false);
#line 16 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
           Write(Html.LabelFor(model => model.Agendamento));

#line default
#line hidden
            EndContext();
            BeginContext(590, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(609, 76, false);
#line 17 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
           Write(Html.EditorFor(m => m.Agendamento, null, null, new { @class="form-control"}));

#line default
#line hidden
            EndContext();
            BeginContext(685, 160, true);
            WriteLiteral("\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-6\">\r\n                        ");
            EndContext();
            BeginContext(846, 118, false);
#line 22 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
                   Write(Html.ActionLink("voltar", "ViewOrder", "Order", new { id = Model }, new { @class = "btn btn-secondary form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(964, 243, true);
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"col-6\">\r\n                        <button type=\"submit\" class=\"btn btn-success form-control\">Enviar</button>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
            EndContext();
#line 29 "C:\Users\gabri\source\repos\GDR\GDR\Views\Order\SchedullingOrder.cshtml"
        }

#line default
#line hidden
            BeginContext(1218, 20, true);
            WriteLiteral("    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GDR.Models.ModelsForViews.SchedulingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
