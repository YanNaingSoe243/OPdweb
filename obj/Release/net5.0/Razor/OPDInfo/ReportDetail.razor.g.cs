#pragma checksum "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\OPDInfo\ReportDetail.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "05a40343fc619e6e127918ef20bc4c0fd8472551"
// <auto-generated/>
#pragma warning disable 1591
namespace OPdWebApp.OPDInfo
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using OPdWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using OPdWebApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using OPdWebApp.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using OPdWebApp.OPDInfo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using OPdWebApp.ExprotService;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using OPdWebApp.BarCodeReader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using AutoMapper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Blazored.Toast;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\_Imports.razor"
using Blazored.Toast.Services;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/reportdetail/{Id:int}")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/reportdetail")]
    public partial class ReportDetail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 5 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\OPDInfo\ReportDetail.razor"
 if (ShowConfirm)
{


#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "modal fade show d-block");
            __builder.AddAttribute(2, "b-jqviww5cfj");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "modal-content animate");
            __builder.AddAttribute(5, "b-jqviww5cfj");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "modal-body");
            __builder.AddAttribute(8, "style", "padding:0px;display:flex");
            __builder.AddAttribute(9, "b-jqviww5cfj");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", "row bg-white rounded");
            __builder.AddAttribute(12, "style", "height: 740px; width: 100%;");
            __builder.AddAttribute(13, "b-jqviww5cfj");
            __builder.OpenElement(14, "span");
            __builder.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 16 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\OPDInfo\ReportDetail.razor"
                                    Close

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "class", "close");
            __builder.AddAttribute(17, "title", "Close Modal");
            __builder.AddAttribute(18, "b-jqviww5cfj");
            __builder.AddContent(19, "×");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "                  \r\n                        <div class=\"col-md-2\" style=\"border-right: 1px solid rgba(0, 0, 0, 0.3); height: 740px \" b-jqviww5cfj></div>\r\n                        ");
            __builder.AddMarkupContent(21, @"<div class=""col-md-8 mt-3"" b-jqviww5cfj><div class=""d-flex justify-content-around align-items-center experience"" b-jqviww5cfj><span b-jqviww5cfj>Report Information</span>
                                <button class=""border btn add-experience"" b-jqviww5cfj><i class=""oi oi-magnifying-glass pr-2"" b-jqviww5cfj></i>Search
                                </button></div></div>");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 37 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\OPDInfo\ReportDetail.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "D:\Project\konaymyoag\OPdWebApp\OPdWebApp\OPDInfo\ReportDetail.razor"
       
    protected bool ShowConfirm { get; set; }
    public void Close()
    {
        ShowConfirm = false;
        // StateHasChanged();
    }
    public void Show()
    {
        ShowConfirm = true;
        StateHasChanged();
    }


#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime JS { get; set; }
    }
}
#pragma warning restore 1591
