#pragma checksum "C:\Users\Nick\Documents\GitHub\PickNTour\PickNTour\PickNTour\Views\Admin\ManageUsers.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6430f0dc9024d696acd0ea9f30224c32d44f1e0"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6430f0dc9024d696acd0ea9f30224c32d44f1e0", @"/Views/Admin/ManageUsers.cshtml")]
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

<div>
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


");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>
        $(document).ready(function () {
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
                        data:""dateOfBirth""
                    },
                    {
                        data:""phoneNumber""
                    },
                    {
                        data: ""id"",
                        render: function (data) {
                            return ""<button class='btn-link js-lockout' data-user-id="" + data + "">Lockout</button>""
                        }
                    }

                ]


            });


            $(""#users"").on(""click"", "".js-lockout"", functi");
                WriteLiteral(@"on () {
                var button = $(this);


                bootbox.prompt({
                    title: ""Please select the date the user should be suspended until."",
                    inputType: 'date',
                    callback: function (result) {
                        console.log(result);
                        $.ajax({
                            url: ""/api/admin/lockoutuser/"" + button.attr(""data-user-id"") +""/"" + result +""/"",
                            method: ""PUT"",
                            success: function () {
                                table.row(button.parents(""tr"")).remove().draw();
                            }

                        });
                    }
                });

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
