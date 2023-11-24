using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Enterprise2._0.TagHelpers
{
 
    public class BotaoTagHelper : TagHelper
    {
        public string? Texto { get; set; } = "Salvar";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //Definir o nome da tag html
            output.TagName = "button";
            //Definir os atributos da tag html
            output.Attributes.SetAttribute("class", "btn btn-primary");
            //Definir o conteúdo da tag html
            output.Content.SetContent(Texto);
        }
    }
}
