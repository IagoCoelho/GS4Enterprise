﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Enterprise2._0.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string? Texto { get; set; }
        public string? Class { get; set; } = "alert alert-success";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            if (!string.IsNullOrEmpty(Texto))
                output.Attributes.SetAttribute("class", Class);
            output.Content.SetContent(Texto);
        }
    }
}
