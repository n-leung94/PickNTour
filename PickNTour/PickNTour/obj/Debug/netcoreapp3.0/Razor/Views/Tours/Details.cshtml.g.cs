#pragma checksum "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Tours\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b26d67d64097a8962833c3d4117ca3408c37517f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tours_Details), @"mvc.1.0.view", @"/Views/Tours/Details.cshtml")]
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
#line 1 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\_ViewImports.cshtml"
using PickNTour;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\_ViewImports.cshtml"
using PickNTour.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b26d67d64097a8962833c3d4117ca3408c37517f", @"/Views/Tours/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2381805d9d01886713b65787dafbee74a3767085", @"/Views/_ViewImports.cshtml")]
    public class Views_Tours_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Tours\Details.cshtml"
  
    ViewData["Title"] = "Tour Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""jumbotron"">
    <h1 style=""color:white"" id=""tourName""></h1>
    <p class=""lead"" style=""color:white"" id=""tourCountry""></p>
</div>

<h1 style=""text-align:center;""> Tour Details </h1> <hr/><br/>

<div id=""details"">
    <div class=""card-deck"">
        <div class=""card"" style=""width:400px"">
            <img class=""card-img-top"" src=""/images/calendar.png"">
            <div class=""card-body"">
                <h5 class=""card-title"" style=""text-align:center;"">Timing</h5>  <hr />
                <p class=""card-text"" style=""text-align:center;"" id=""startDate"">Start Date: </p>
                <p class=""card-text"" style=""text-align:center;"" id=""endDate"">End Date: </p>
            </div>
        </div>

        <div class=""card"" style=""width:400px"">
            <img class=""card-img-top"" src=""/images/location.png"">
            <div class=""card-body"">
                <h5 class=""card-title"" style=""text-align:center;"">Location</h5><hr />
                <p class=""card-text"" style=""text-align:");
            WriteLiteral(@"center;"" id=""startLocation"">Start Location: </p>
                <p class=""card-text"" style=""text-align:center;"" id=""endLocation"">End Location: </p>
            </div>
        </div>

        <div class=""card"" style=""width:400px"">
            <img class=""card-img-top"" src=""/images/tour-guide.png"">
            <div class=""card-body"">
                <h5 class=""card-title"" style=""text-align:center;"">Tour Guide</h5><hr />
                <p class=""card-text"" style=""text-align:center;"" id=""userName"">UserName :</p>
                <p class=""card-text"" style=""text-align:center;"" id=""fullName"">Full Name :</p>
            </div>
        </div>

        <div class=""card"" style=""width:400px"">
            <img class=""card-img-top"" src=""/images/description.png"">
            <div class=""card-body"">
                <h5 class=""card-title"" style=""text-align:center;"">Description</h5><hr />
                <p class=""card-text"" style=""text-align:center;"" id=""description""></p>
            </div>
        </div");
            WriteLiteral(">\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            var id = ");
#nullable restore
#line 58 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Tours\Details.cshtml"
                Write(ViewData["tourID"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

            $.ajax({
                url: '/api/tours/' + id,
                dataType: 'json',
                success: function (data) {
                    $(""#tourName"").html(data.name);
                    $(""#tourCountry"").html(data.country);
                    $(""#startDate"").html(""<strong>"" + ""Start Date"" + ""</strong> <br/>"" + moment(data.startDate).format('MMMM Do YYYY, h:mm:ss a'));
                    $(""#endDate"").html(""<strong>"" + ""End Date"" + ""</strong> <br/>"" + moment(data.endDate).format('MMMM Do YYYY, h:mm:ss a'));
                    $(""#startLocation"").html(""<strong>"" + ""Start Location"" + ""</strong> <br/>"" + data.startLocation);
                    $(""#endLocation"").html(""<strong>"" + ""End Location"" + ""</strong> <br/>"" + data.endLocation);
                    $(""#userName"").html(""<strong>"" + ""User Name"" + ""</strong> <br/>"" + data.user.userName);
                    $(""#fullName"").html(""<strong>"" + ""Full Name"" + ""</strong> <br/>"" + data.user.fullName);
                    $(");
                WriteLiteral("\"#description\").html(data.description);\r\n                },\r\n                error: function() {\r\n                    console.log(\'Error Encountered\');\r\n                }\r\n            });\r\n\r\n\r\n\r\n        });\r\n\r\n\r\n\r\n    </script>\r\n");
            }
            );
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
