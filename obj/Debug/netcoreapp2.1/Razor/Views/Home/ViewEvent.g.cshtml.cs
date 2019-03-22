#pragma checksum "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67707cdb71874abb832b0b5f7e7bb63bfe3c6fbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ViewEvent), @"mvc.1.0.view", @"/Views/Home/ViewEvent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/ViewEvent.cshtml", typeof(AspNetCore.Views_Home_ViewEvent))]
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
#line 1 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\_ViewImports.cshtml"
using BELTEXAM;

#line default
#line hidden
#line 1 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
using BELTEXAM.Models;

#line default
#line hidden
#line 2 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67707cdb71874abb832b0b5f7e7bb63bfe3c6fbf", @"/Views/Home/ViewEvent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4fa57ac9051b95d912f7fd452e415ef7ee54768", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ViewEvent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Event>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 4 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
  
ViewData["Title"] = "View Event";

#line default
#line hidden
            BeginContext(117, 539, true);
            WriteLiteral(@"
<div class=""container"">
    <nav class=""navbar fixed-top navbar-light bg-light"">
        <div class=""col"">
            <span class=""navbar-brand mb-0 h1"">
                <h1>Dojo Activity Center</h1>
            </span>
        </div>
        <a href=""/home""><button class=""btn btn-primary btn-sm"">Dashboard</button></a>
        <div class=""col-2""><a href=""/logout""><button class=""btn btn-danger btn-sm"">Log off</button></a></div>
    </nav>
    <div class=""row"">
        <div class=""col-10""> <br> <br> <br>
            <h1>");
            EndContext();
            BeginContext(657, 11, false);
#line 20 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
           Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(668, 67, true);
            WriteLiteral("</h1>\r\n        </div>\r\n        <div class=\"col-2\"> <br> <br> <br>\r\n");
            EndContext();
#line 23 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
              
            int? seshUser = Context.Session.GetInt32("ID");
            if(Model.CoordinatorID == (int) seshUser)
            {

#line default
#line hidden
            BeginContext(882, 14, true);
            WriteLiteral("            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 896, "\"", 920, 2);
            WriteAttributeValue("", 903, "/delete/", 903, 8, true);
#line 27 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
WriteAttributeValue("", 911, Model.ID, 911, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(921, 59, true);
            WriteLiteral("><button class=\"btn btn-danger\">Call it off!</button></a>\r\n");
            EndContext();
#line 28 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
            }
            else
            {
            bool going = false;
            foreach(var rsvp in Model.Participants)
            {
            if(rsvp.User.ID == (int)seshUser)
            {
            going = true;
            }
            }
            if(going)
            {

#line default
#line hidden
            BeginContext(1286, 14, true);
            WriteLiteral("            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1300, "\"", 1324, 2);
            WriteAttributeValue("", 1307, "/UnRsvp/", 1307, 8, true);
#line 41 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
WriteAttributeValue("", 1315, Model.ID, 1315, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1325, 58, true);
            WriteLiteral("><button class=\"btn btn-danger\">Leave Event</button></a>\r\n");
            EndContext();
#line 42 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
            }
            else
            {
            if(TempData["Conflict"] == null)
            {

#line default
#line hidden
            BeginContext(1492, 14, true);
            WriteLiteral("            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1506, "\"", 1528, 2);
            WriteAttributeValue("", 1513, "/Rsvp/", 1513, 6, true);
#line 47 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
WriteAttributeValue("", 1519, Model.ID, 1519, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1529, 58, true);
            WriteLiteral("><button class=\"btn btn-success\">Join Event</button></a>\r\n");
            EndContext();
#line 48 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1635, 59, true);
            WriteLiteral("            <div id=\"errors\">You\'re already booked!</div>\r\n");
            EndContext();
#line 52 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
            }
            }
            }
            

#line default
#line hidden
            BeginContext(1754, 120, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-8\"> <br>\r\n            <h5>Event Coordinator: ");
            EndContext();
            BeginContext(1875, 27, false);
#line 60 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
                              Write(Model.Coordinator.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(1902, 63, true);
            WriteLiteral(" </h5>\r\n            <h4>Event Decription:</h5>\r\n            <p>");
            EndContext();
            BeginContext(1966, 17, false);
#line 62 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
          Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(1983, 42, true);
            WriteLiteral("</p>\r\n            <h5>Participants:</h5>\r\n");
            EndContext();
#line 64 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
              
            foreach(var part in Model.Participants)
            {
            if(part.User.ID != (int)seshUser)
            {

#line default
#line hidden
            BeginContext(2171, 15, true);
            WriteLiteral("            <p>");
            EndContext();
            BeginContext(2187, 19, false);
#line 69 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
          Write(part.User.FirstName);

#line default
#line hidden
            EndContext();
            BeginContext(2206, 6, true);
            WriteLiteral("</p>\r\n");
            EndContext();
#line 70 "C:\Users\Aleksandar\Desktop\BELTEXAM\Views\Home\ViewEvent.cshtml"
            }
            }
            

#line default
#line hidden
            BeginContext(2257, 34, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Event> Html { get; private set; }
    }
}
#pragma warning restore 1591
