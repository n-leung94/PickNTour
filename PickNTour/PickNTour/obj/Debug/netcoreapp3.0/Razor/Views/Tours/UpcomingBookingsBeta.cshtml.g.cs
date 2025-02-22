#pragma checksum "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Tours\UpcomingBookingsBeta.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "863cab659bfcf9cd716a7bc95d3742f383dac5e4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tours_UpcomingBookingsBeta), @"mvc.1.0.view", @"/Views/Tours/UpcomingBookingsBeta.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"863cab659bfcf9cd716a7bc95d3742f383dac5e4", @"/Views/Tours/UpcomingBookingsBeta.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2381805d9d01886713b65787dafbee74a3767085", @"/Views/_ViewImports.cshtml")]
    public class Views_Tours_UpcomingBookingsBeta : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Tours\UpcomingBookingsBeta.cshtml"
  
    ViewData["Title"] = "UpcomingToursBeta";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 style=\"text-align:center;\">Upcoming Tours</h1>\r\n<hr />\r\n<br />\r\n\r\n<div id=\"bookings\"></div>\r\n\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            $.ajax({
                url: '/api/bookedtours/getupcomingbookings',
                dataType: 'json',
                success: function (data) {

                    //The element where the tours should be appended
                    var el = $('#bookings');

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
                            '<div class=""card-body"">' +");
                WriteLiteral(@"
                            '<h5 class=""card-title"">' + value.tour.name + '</h5>' +
                            '<p class=""card-text"">' + value.tour.country + '</p>' + '<hr/>' +
                            '<p class=""card-text"">Start Location: ' + value.tour.startLocation + ""</p>"" +
                            '<p class=""card-text"">End Location: ' + value.tour.endLocation + ""</p>"" + '<hr/>' +
                            '<p class=""card-text"">Start Date: ' + moment(value.tour.startDate).format('MMMM Do YYYY, h:mm:ss a') + ""</p>"" +
                            '<p class=""card-text"">End Date: ' + moment(value.tour.endDate).format('MMMM Do YYYY, h:mm:ss a') + ""</p>"" +
                            '<p class=""card-text"">Date Booked: ' + moment(value.dateBooked).format('MMMM Do YYYY, h:mm:ss a') + ""</p>"" + '<hr/>' +
                            '<p class=""card-text"">Price: $' + value.tour.price + ""</p>"" +
                            '<p class=""card-text"">POC: ' + value.tour.user.userName + ""</p>"" +
          ");
                WriteLiteral(@"                  '<p class=""card-text"">Tour Guide Name: ' + value.tour.user.fullName + ""</p>"" +
                            '</div>' +
                            '<div class=""card-footer"">' +
                            ""<a href='/messages/compose/"" + value.tour.user.userName + ""' class='btn btn-outline-primary' style='margin:5px;' role='button'>Message Tour Guide</a>"" +
                            ""<a href='/tours/details/"" + value.tour.id + ""' class='btn btn-outline-info' style='margin:5px;' role='button'>View Details</a>"" +
                            ""<button class='btn btn-outline-danger js-cancel' style='margin:5px;' data-booking-id="" + value.id + "">Cancel Booking</button>"" +
                            '</div>' +
                            '</div>'
                        );

                        itemCount += 1;

                        if (itemCount >= 3) {
                            var tagClose = ""</div> <hr/>""
                            cardBuilder += tagClose;
              ");
                WriteLiteral(@"              itemCount = 0;
                        }

                    });

                    el.append(cardBuilder);
                },
                error: function () {
                    console.log('Error Encountered');
                }
            });


            $(""#bookings"").on(""click"", "".js-cancel"", function () {
                var button = $(this);

                bootbox.confirm(""Are you sure you want to cancel this booking?"", function (result) {
                    if (result) {
                        $.ajax({
                            url: ""/api/tours/"" + button.attr(""data-booking-id""),
                            method: ""DELETE"",
                            success: function (response) {
                                toastr.success(""Successfully cancelled the booking!"");
                                button.parentsUntil('.card-deck').remove();
                            },
                            fail: function () {
                         ");
                WriteLiteral("       toastr.error(\"Error: Something unexpected happened.\");\r\n                            }\r\n\r\n                        });\r\n                    }\r\n\r\n                });\r\n\r\n            });\r\n\r\n\r\n        });\r\n\r\n\r\n\r\n    </script>\r\n");
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
