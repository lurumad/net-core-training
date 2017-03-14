using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace taghelpers.TagHelpers
{
    [HtmlTargetElement("div", Attributes = ProgressValueAttributeName)]
    public class ProgressBarTagHelper : TagHelper
    {
        private const string ProgressValueAttributeName = "bs-progress-value";
        private const string ProgressMinAttributeName = "bs-progress-min";
        private const string ProgressMaxAttributeName = "bs-progress-max";
        private const string ProgressClass = "progress";
        private const string ClassAttribute = "class";

        [HtmlAttributeName(ProgressValueAttributeName)]
        public int ProgressValue { get; set; }

        [HtmlAttributeName(ProgressMinAttributeName)]
        public int ProgressMin { get; set; } = 0;

        [HtmlAttributeName(ProgressMaxAttributeName)]
        public int ProgressMax { get; set; } = 100;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var total = ProgressMax - ProgressMin;
            var percentage = Math.Round((ProgressValue - ProgressMin) / (decimal)total * 100, 0);

            string progressBar =
$@"<div class='progress-bar' role='progressbar' aria-valuenow='{ProgressValue}' aria-valuemin='{ProgressMin}' aria-valuemax='{ProgressMax}' style='width: {percentage}%;'> 
   <span class='sr-only'>{percentage}% Complete</span>
</div>";
            output.Content.AppendHtml(progressBar);
            var classValue = output.Attributes.ContainsName(ClassAttribute) ? $"{output.Attributes[ClassAttribute].Value} {ProgressClass}" : ProgressClass;
            output.Attributes.SetAttribute(ClassAttribute, classValue);
        }
    }
}
