#pragma checksum "C:\Users\carmo\Documents\GitHub\Noesis.WeatherMap\Noesis.WeatherMap\Noesis.WeatherMap.Site\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "713125483c2482b2e1a4b2782a34d5f6019585e1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\carmo\Documents\GitHub\Noesis.WeatherMap\Noesis.WeatherMap\Noesis.WeatherMap.Site\Views\_ViewImports.cshtml"
using Noesis.WeatherMap.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\carmo\Documents\GitHub\Noesis.WeatherMap\Noesis.WeatherMap\Noesis.WeatherMap.Site\Views\_ViewImports.cshtml"
using Noesis.WeatherMap.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"713125483c2482b2e1a4b2782a34d5f6019585e1", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1a13a5eae9e013c9b47c0c514d10f8f75a61deea", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\carmo\Documents\GitHub\Noesis.WeatherMap\Noesis.WeatherMap\Noesis.WeatherMap.Site\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script src=""https://code.jquery.com/jquery-3.6.0.slim.js"" integrity=""sha256-HwWONEZrpuoh951cQD1ov2HUK5zA5DwJ1DNUXaM6FsY="" crossorigin=""anonymous""></script>

<div class=""container"">
    <div class=""row"">
        <div class=""col-6"" style=""text-align:center;margin-top:25%"">

            <select id=""selectElementId"">
                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "713125483c2482b2e1a4b2782a34d5f6019585e13785", async() => {
                WriteLiteral("Choose a profile");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("disabled", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </select>
            <br />
            <br />
            <div class=""form-group"">
                <input type=""submit"" value=""Entrar"" onclick=""login()"" class=""btn btn-primary"" />
            </div>

        </div>

        <div class=""col-6"" style=""text-align:center;margin-top:25%"">

            <input type=""text"" id=""inputName"" />
            <br />
            <br />
            <div class=""form-group"">
                <input type=""submit"" value=""Criar perfil e entrar"" onclick=""createUser()"" class=""btn btn-primary"" />
            </div>

        </div>
    </div>
</div>

<script>

    function createUser() {
        $.ajax({
            method: ""POST"",
            url: ""/Home/AddUser"",
            data: { name: $(""#inputName"").val() },
            success: function (data) {
                console.log(data);
                var result = JSON.parse(data);
                console.log(result);
                window.location = 'https://localhost:44312/Home/Favo");
            WriteLiteral(@"rite?id=' + result.id;
            }
        });
    }

    function login() {
        console.log($('#selectElementId').find("":selected"").val());
        window.location = 'https://localhost:44312/Home/Favorite?id=' + $('#selectElementId').find("":selected"").val();
    }

    $(document).ready(function () {

        $.ajax({
            url: ""/Home/GetUsers"",
            type: ""GET"",
            dataType: ""json"",
            success: function (data) {
                var result = JSON.parse(data);
                console.log(result[0].id);
                var select = document.getElementById('selectElementId');

                for (var i = 0; i <= result.length; i++) {
                    var opt = document.createElement('option');
                    opt.value = result[i].id;
                    opt.innerHTML = result[i].name;
                    select.appendChild(opt);
                }
            }
        });
    });

</script>");
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
