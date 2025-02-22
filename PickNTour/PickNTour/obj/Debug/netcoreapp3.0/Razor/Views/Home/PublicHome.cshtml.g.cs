#pragma checksum "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Home\PublicHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9ae1801f62070008692bb381eb26409a958208f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_PublicHome), @"mvc.1.0.view", @"/Views/Home/PublicHome.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ae1801f62070008692bb381eb26409a958208f5", @"/Views/Home/PublicHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2381805d9d01886713b65787dafbee74a3767085", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_PublicHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Home\PublicHome.cshtml"
  
    ViewData["Title"] = "PublicHome";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Home\PublicHome.cshtml"
  
    ViewData["Title"] = "UserHome";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""jumbotron"">
    <h1 style=""color:white"">Pick N Tour</h1>
    <p class=""lead"" style=""color:white"">Start planning your next trip with us !</p>
    <p><a href=""/Identity/Account/Register"" class=""btn btn-primary btn-lg"">Register an Account For Free ! &raquo;</a></p>
</div>

<h1 style=""text-align:center;""> Latest Tours </h1>
<hr />
<br />

<div id=""tours""></div>
<br/>

<div class=""alert alert-info"">
    <h4 style=""text-align:center;""> <strong>Register</strong> now to start booking ! </h4>
</div>

");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $.ajax({
                url: '/api/home/getpublicstats',
                dataType: 'json',
                success: function (data) {
                    console.log(data);

                    //The element where the tours should be appended
                    var el = $('#tours');

                    //Empty the element first
                    el.empty();


                    var itemCount = 0;
                    var cardBuilder = """";

                    $.each(data, function (index, value) {
                        if (itemCount == 0) {
                            var tagOpen = ""<div class='card-deck'>""
                            cardBuilder += tagOpen;
                        }

                        cardBuilder += (

                            '<div class=""card"" style=""width:400px"">' +
                                '<img class=""card-img-top"" src=""/images/travel.jpg"">' +
                           ");
                WriteLiteral(@"     '<div class=""card-body"">' +
                                    '<h5 class=""card-title"">' + value.name + '</h5>' +
                                    '<p class=""card-text"">' + value.country + '</p>' + '<hr/>' +
                                    '<p class=""card-text"">' + value.description + '</p>' + '<hr/>' +
                                    '<p class=""card-text"">Start Date: ' + moment(value.startDate).format('MMMM Do YYYY, h:mm:ss a') + ""</p>"" +
                                    '<p class=""card-text"">End Date: ' + moment(value.endDate).format('MMMM Do YYYY, h:mm:ss a') + ""</p>"" +
                                    '<p class=""card-text"">Price: $' + value.price + ""</p>"" +
                                    '<p class=""card-text"">Slots Remaining: ' + value.tourAvailability + ""</p>"" + '<hr/>' +
                                    '<p class=""card-text"">POC: ' + value.user.userName + ""</p>"" +
                                '</div>' +
                            '</div>'
                   ");
                WriteLiteral(@"     );

                        itemCount += 1;

                        if (itemCount >= 3) {
                            var tagClose = ""</div> <hr/>""
                            cardBuilder += tagClose;
                            itemCount = 0;
                        }

                    });

                    el.append(cardBuilder);
                },
                error: function () {
                    console.log('Error Encountered');
                }
            });



        });



    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
