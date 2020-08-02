#pragma checksum "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Tours\CreatedTours.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7826ddf16f7540db0a8fde1f78ea1748ea9f490"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tours_CreatedTours), @"mvc.1.0.view", @"/Views/Tours/CreatedTours.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7826ddf16f7540db0a8fde1f78ea1748ea9f490", @"/Views/Tours/CreatedTours.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2381805d9d01886713b65787dafbee74a3767085", @"/Views/_ViewImports.cshtml")]
    public class Views_Tours_CreatedTours : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Tours\CreatedTours.cshtml"
  
    ViewData["Title"] = "CreatedTours";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>My Created Tours</h1>

<div>
    <table id=""tours"" class=""table table-bordered table-hover"">
        <thead>
            <tr>
                <th>Tour Name</th>
                <th>Tour Description</th>
                <th>Country</th>
                <th>Start Location</th>
                <th>End Location</th>
                <th>Start Date</th>
                <th>End Date</th>
                <th>Price</th>
                <th>Tour Capacity</th>
                <th>Slots Remaining</th>
                <th>View Participants</th>
                <th>Delete</th>
            </tr>
        </thead>
    </table>

    <div id=""hidden-container"" style=""display:none"">
        <table class=""display"" cellspacing=""0"" width=""100%"">
            <thead>
                <tr>
                    <th>User Name</th>
                    <th>Full Name</th>
                    <th>Send PM</th>
                </tr>
            </thead>


        </table>

    </div>

</div>


");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
            var table = $(""#tours"").DataTable({
                ajax: {
                    url: ""/api/owntours"",
                    dataSrc: """"
                },

                columns: [
                    {
                        data: ""name"",
                        render: function (data, type, tour) {
                            return ""<a href='/tours/edit/"" + tour.id + ""'>"" + tour.name + ""</a>"";
                        }
                    },
                    {
                        data: ""description"",
                        render: function (data) {
                            return ""<button class='btn-link js-viewdesc' data-desc='"" + data + ""'>View Description</button>""
                        }
                    },
                    {
                        data:""country""
                    },
                    {
                        data:""startLocation""
                    },
               ");
                WriteLiteral(@"     {
                        data:""endLocation""
                    },
                    {
                        data:""startDate""
                    },
                    {
                        data:""endDate""
                    },
                    {
                        data:""price""
                    },
                    {
                        data:""tourCapacity""
                    },
                    {
                        data:""tourAvailability""
                    },
                    {
                        data: ""id"",
                        render: function (data) {
                            return ""<button class='btn-link js-viewusers' data-tour-id="" + data + "">View Participants</button>""
                        }
                    },
                    {
                        data: ""id"",
                        render: function (data) {
                            return ""<button class='btn-link js-delete' data-tour-id="" + data + "">");
                WriteLiteral(@"Delete</button>""
                        }
                    }

                ]


            });


            $(""#tours"").on(""click"", "".js-delete"", function () {
                var button = $(this);

                bootbox.confirm(""Are you sure you want to delete this tour?"", function (result) {
                    if (result) {
                        $.ajax({
                            url: ""/api/owntours/"" + button.attr(""data-tour-id""),
                            method: ""DELETE"",
                            success: function () {
                                table.row(button.parents(""tr"")).remove().draw();
                            }

                        });
                    }

                });

            });

            $(""#tours"").on(""click"", "".js-viewdesc"", function () {
                var viewDescBtn = $(this);
                bootbox.alert(viewDescBtn.attr(""data-desc""));

            });


            $(""#tours"").on(""click"", "".js-viewus");
                WriteLiteral(@"ers"", function () {
                var button = $(this);

                var container = $(""#hidden-container"").clone();
                container.find('table').attr('id', 'users');

                var box = bootbox.dialog({
                    show: false,
                    message: container.html(),
                    title: ""Participants"",
                    buttons: {
                        ok: {
                        label: ""Message All"",
                        className: ""btn-primary"",
                        callback: function() {
                            window.location.replace(""/tourgroupmessage/compose/"" + button.attr(""data-tour-id""));
                        }
                        },
                        cancel: {
                        label: ""Close"",
                        className: ""btn-default""
                        }
                    }
                });
      
                box.on(""shown.bs.modal"", function() {
                    $('#u");
                WriteLiteral(@"sers').DataTable({
                        ajax: {
                            url: ""/api/owntours/tourparticipants/"" + button.attr(""data-tour-id""),
                            dataSrc: """"
                         },

                        columns: [
                            {
                                data: ""userName""
                                
                            },
                            {
                                data: ""fullName""
                            },
                            {
                                data: ""userName"",
                                render: function (data) {
                                    return ""<button class='btn-link js-sendpm' data-pm-id="" + data + "">Send PM</button>""
                                }
                            }

                        ]


                    }); 

                });

                $(""#users"").on(""click"", "".js-sendpm"", function () {
                    va");
                WriteLiteral(@"r button = $(this);

                    window.location.replace(""/messages/compose/"" + button.attr(""data-pm-id""));

                });



      
                    box.modal('show'); 
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
