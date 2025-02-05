﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace SSDCPortal.Theme.Material.TagHelpers
{
    public class AppTagHelperComponent : TagHelperComponent
    {
        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var path = typeof(Module).Namespace;

            if (string.Equals(context.TagName, "app", StringComparison.OrdinalIgnoreCase) && output.Attributes.ContainsName("wasm"))
            {
                output.PostContent.AppendHtml(@$"<div class=""triangle-container"">
                                                     <div class=""triangles""></div>
                                                 </div>
                                                 <div class=""loading-container"">
                                                     <img src=""_content/{path}/images/logo.svg"" alt=""Loading"" title=""Loading SSDCPortal"" /><br />
                                                      Loading SSDCPortal WebAssemblies ...
                                                 </div>");
            }

            return Task.CompletedTask;
        }
    }
}
