#pragma checksum "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Admin\ManageUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d9ed852385fa3efc3f5cd2bec7cc159e300f01e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ManageUsers), @"mvc.1.0.view", @"/Views/Admin/ManageUsers.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d9ed852385fa3efc3f5cd2bec7cc159e300f01e", @"/Views/Admin/ManageUsers.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2381805d9d01886713b65787dafbee74a3767085", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_ManageUsers : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Admin\ManageUsers.cshtml"
  
    ViewData["Title"] = "ManagerUsers";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>User Management</h1>
<div id=""tabs"">
    <ul>
        <li><a href=""#user-tab"">Manage Users</a></li>
        <li><a href=""#lockout-tab"">Lockedout Users</a></li>
    </ul>

    <div id=""user-tab"">
        <table id=""users"" class=""table table-bordered table-hover"">
            <thead>
                <tr>
                    <th>User Name</th>
                    <th>Full Name</th>
                    <th>Date Of Birth</th>
                    <th>Phone Number</th>
                    <th>Lockout</th>
                </tr>
            </thead>
        </table>
    </div>

    <div id=""lockout-tab"">
        <table id=""lockoutUsers"" class=""table table-bordered table-hover"">
            <thead>
                <tr>
                    <th>User Name</th>
                    <th>Full Name</th>
                    <th>Phone Number</th>
                    <th>Lockout End</th>
                    <th>Release Lockout</th>
                </tr>
            </thead>
        </table>
");
            WriteLiteral("\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {

            $(""#tabs"").tabs();


            var table = $(""#users"").DataTable({
                ajax: {
                    url: ""/api/admin/getallusers"",
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
                        data: ""dateOfBirth""
                    },
                    {
                        data: ""phoneNumber""
                    },
                    {
                        data: ""id"",
                        render: function (data) {
                            return ""<button class='btn btn-outline-danger js-lockout' data-user-id="" + data + "">Lockout</button>""
                        }
                    }

                ]


            });

            var susp");
                WriteLiteral(@"endedtable = $(""#lockoutUsers"").DataTable({
                ajax: {
                    url: ""/api/admin/getlockedoutusers"",
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
                        data: ""phoneNumber""
                    },
                    {
                        data: ""lockoutEnd""
                    },
                    {
                        data: ""id"",
                        render: function (data) {
                            return ""<button class='btn btn-outline-danger js-release' data-user-id="" + data + "">Release Lockout</button>""
                        }
                    }

                ]


            });




            $(""#users"").on(""click"", "".js-lockout"", function () {
                var button = $(thi");
                WriteLiteral(@"s);


                bootbox.prompt({
                    title: ""Please select the date the user should be suspended until."",
                    inputType: 'date',
                    callback: function (result) {
                        $.ajax({
                            url: ""/api/admin/lockoutuser/"" + button.attr(""data-user-id"") + ""/"" + result + ""/"",
                            method: ""PUT"",
                            success: function () {
                                table.row(button.parents(""tr"")).remove().draw();
                                suspendedtable.ajax.reload();
                            }

                        });
                    }
                });

            });

             $(""#lockoutUsers"").on(""click"", "".js-release"", function () {
                var button = $(this);


                bootbox.confirm({
                    title: ""Release Lockout"",
                    message: ""Are you sure you want to release the lockout of the user?");
                WriteLiteral(@""",
                    buttons: {
                        cancel: {
                            label: '<i class=""fa fa-times""></i> Cancel'
                        },
                        confirm: {
                            label: '<i class=""fa fa-check""></i> Confirm'
                        }
                    },
                    callback: function (result) {
                        if (result) {
                            $.ajax({
                                url: ""/api/admin/releaselockout/"" + button.attr(""data-user-id""),
                                method: ""PUT"",
                                success: function () {
                                    suspendedtable.row(button.parents(""tr"")).remove().draw();
                                    table.ajax.reload();
                                }

                            });


                        }
                    }
                });

            });




        });



    </script>

");
                WriteLiteral("\r\n\r\n");
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
