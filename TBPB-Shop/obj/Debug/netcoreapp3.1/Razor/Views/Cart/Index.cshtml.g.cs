#pragma checksum "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d601fbb8dc8ef2aa66015f463a87f8056ff8971"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_Index), @"mvc.1.0.view", @"/Views/Cart/Index.cshtml")]
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
#line 1 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\_ViewImports.cshtml"
using TBPB_Shop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\_ViewImports.cshtml"
using TBPB_Shop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d601fbb8dc8ef2aa66015f463a87f8056ff8971", @"/Views/Cart/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d717aece934a09e6fe171f5d604f7da01e3c6cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TBPB_Shop.ViewModel.CartViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2> \n    <strong>My Cart: </strong>\n</h2>\n\n<p>Products: ");
#nullable restore
#line 10 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
        Write(Model.NoOfProducts);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n<p>Total price: ");
#nullable restore
#line 11 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
           Write(Model.TotalPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n\n");
#nullable restore
#line 13 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
 if (!Model.Products.Any())
{

}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<ul>\n");
#nullable restore
#line 20 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
     foreach (var item in Model.Products)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <li>");
#nullable restore
#line 22 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
   Write(item.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n");
#nullable restore
#line 23 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\n");
#nullable restore
#line 25 "H:\FacultateAn3S2\Project II\Project2\TBPB-Shop\TBPB-Shop\Views\Cart\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TBPB_Shop.ViewModel.CartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591