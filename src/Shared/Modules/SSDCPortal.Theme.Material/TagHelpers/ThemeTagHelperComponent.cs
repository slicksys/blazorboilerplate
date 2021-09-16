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
                <link rel=""shortcut icon"" type=""image/x-icon"" href=""_content/{path}/images/favicon.ico"">
                <link rel=""icon"" type=""image/x-icon"" href=""_content/{path}/images/favicon.ico"">
                <link href=""https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"" rel=""stylesheet""/>
                <link href=""_content/{path}/fonts/roboto/roboto.css"" rel=""stylesheet""/>
                <link href=""https://fonts.googleapis.com/css2?family=Ubuntu:wght@300;400;500;700&display=swap"" rel=""stylesheet"">
                <link href=""https://fonts.googleapis.com/css2?family=Montserrat:wght@400;500;600;700&display=swap"" rel=""stylesheet"">
                <link href=""https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"" rel=""stylesheet"" />
                <link href=""_content/MudBlazor/MudBlazor.min.css"" rel=""stylesheet""/>
                <link href=""_content/MudBlazor.ThemeManager/MudBlazorThemeManager.css"" rel=""stylesheet""/>
                <link href=""./MudBlazorThemeManager.css"" rel=""stylesheet""/>
                <link href=""https://cdn.quilljs.com/1.3.6/quill.snow.css"" rel=""stylesheet""/>
                <link href=""https://cdn.quilljs.com/1.3.6/quill.bubble.css"" rel=""stylesheet""/>
                <link href=""_content/Syncfusion.Blazor.Themes/Material-dark.css"" rel=""stylesheet"" />");

            }
            else if (string.Equals(context.TagName, "body", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(@$"
                <!-- script src=""_content/MudBlazor/MudBlazor.min.js""></script  -->
                <script src=""https://cdn.quilljs.com/1.3.6/quill.js""></script>
                <script src=""_content/Blazored.TextEditor/quill-blot-formatter.min.js""></script>
                <script src=""_content/Blazored.TextEditor/Blazored-BlazorQuill.js""></script>");
            }

            return Task.CompletedTask;
        }
    }
}
