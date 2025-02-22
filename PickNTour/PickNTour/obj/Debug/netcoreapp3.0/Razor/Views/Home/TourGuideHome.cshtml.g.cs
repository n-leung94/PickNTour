#pragma checksum "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Home\TourGuideHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53f4417930b95076731b72ccd8c0c0e620b460c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_TourGuideHome), @"mvc.1.0.view", @"/Views/Home/TourGuideHome.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53f4417930b95076731b72ccd8c0c0e620b460c0", @"/Views/Home/TourGuideHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2381805d9d01886713b65787dafbee74a3767085", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_TourGuideHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Home\TourGuideHome.cshtml"
  
    ViewData["Title"] = "TourGuide Home";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""jumbotron"">
    <h1 style=""color:white"">Pick N Tour</h1>
    <p class=""lead"" style=""color:white"">Start promoting your next tour with us !</p>
    <p><a href=""/tours/availabletours"" class=""btn btn-primary btn-lg"">Create Tour &raquo;</a></p>
</div>

<h1 style=""text-align:center;""> User Summary </h1> <hr/><br/>

<div id=""stats"">
    <div class=""card-deck"">
        <div class=""card"" style=""width:400px"">
            <img class=""card-img-top""  src=""/images/inbox.png"">
            <div class=""card-body"">
                <h5 class=""card-title"" style=""text-align:center;"">Unread Messages</h5>  <hr />
                <h1 class=""card-text"" style=""text-align:center;"" id=""msgCount""></h1>
            </div>
            <div class=""card-footer"">
                <div class=""text-center"">
                    <a href='/messages/inbox/' class='btn btn-outline-info' role='button'> View Inbox</a>
                </div>
            </div>
        </div>

        <div class=""card"" style=""width:40");
            WriteLiteral(@"0px"">
            <img class=""card-img-top"" src=""/images/plane.png"">
            <div class=""card-body"">
                <h5 class=""card-title"" style=""text-align:center;"">Upcoming Tours</h5><hr />
                <h1 class=""card-text"" style=""text-align:center;"" id=""upcomingCount""></h1>  
            </div>
            <div class=""card-footer"">
                <div class=""text-center"">
                    <a href='/tours/createdtours/' class='btn btn-outline-info' role='button'> View Own Tours</a>
                </div>
            </div>
        </div>

        <div class=""card"" style=""width:400px"">
            <img class=""card-img-top"" src=""/images/checkbox.png"">
            <div class=""card-body"">
                <h5 class=""card-title"" style=""text-align:center;"">Completed Tours</h5><hr />
                <h1 class=""card-text"" style=""text-align:center;"" id=""completedCount""></h1>  
            </div>
            <div class=""card-footer"">
                <div class=""text-center"">
         ");
            WriteLiteral("           <a href=\'/tours/createdtours/\' class=\'btn btn-outline-info\' role=\'button\'>View Own Tours</a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n    </div>\r\n\r\n\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $.ajax({
                url: '/api/home/gettourguidestats',
                dataType: 'json',
                success: function(data) {
                    $(""#msgCount"").html(data.unreadMessages);
                    $(""#upcomingCount"").html(data.upcomingTours);
                    $(""#completedCount"").html(data.completedTours);
                },
                error: function() {
                    console.log('Error Encountered');
                }
            });



        });



    </script>
");
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
