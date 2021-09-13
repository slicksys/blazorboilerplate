using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace SSDCPortal.Theme.Material.TagHelpers
{
    public class ThemeTagHelperComponent : TagHelperComponent
    {
        public override int Order => 1;
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var path = typeof(Module).Namespace;

            if (string.Equals(context.TagName, "head", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(@$"<meta charset=""utf-8"" />
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
                <title>SSDC Admin - Scheduling</title>
                <meta name=""keywords"" content=""groomer scheduling kennel management vet management"">
                <meta name=""twitter:card"" content=""summary_large_image"">
                <meta name=""twitter:title"" content=""SSDC Groom Scheduler"">
                <meta name=""twitter:description"" content=""Groom and Kennel Scheduling and Management"">
                <meta name=""twitter:image"" content=""images/ssdc.png"">
                <!-- link href=""~/Site.css"" rel=""stylesheet"" /  -->
                <link href=""https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600;700&display=swap"" rel=""stylesheet"">
                <link href=""https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"" rel=""stylesheet"" />
                <link href=""./MudBlazor.min.css"" rel=""stylesheet"" />
                <link href=""./MudBlazorThemeManager.css"" rel=""stylesheet"" />");
                //<link href=""_content/Syncfusion.Blazor.Themes/Material-dark.css"" rel=""stylesheet"" />");
            }
            else if (string.Equals(context.TagName, "body", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(@$"
                <!-- script src=""./MudBlazor.min.js""></script  -->
                <script src=""https://cdn.quilljs.com/1.3.6/quill.js""></script>
                <script src=""_content/Blazored.TextEditor/quill-blot-formatter.min.js""></script>
                <script src=""_content/Blazored.TextEditor/Blazored-BlazorQuill.js""></script>");
            }

            return Task.CompletedTask;
        }
    }
}
