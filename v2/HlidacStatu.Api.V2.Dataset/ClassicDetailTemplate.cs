using System.Collections.Generic;

namespace HlidacStatu.Api.V2.Dataset
{
    public partial class ClassicTemplate
    {
        public class ClassicDetailTemplate : V2.CoreApi.Model.Template
        {
            public List<column> columns { get; set; } = new List<column>();

            public static ClassicDetailTemplate FromColumnList(IEnumerable<column> columns)
            {
                var res = new ClassicDetailTemplate();
                foreach (var col in columns)
                {
                    res.AddColumn(col.header, col.content, col.style);
                }
                return res;
            }

            public ClassicDetailTemplate AddColumn(string columnHeader, string columnTemplateValue, string style = null)
            {
                columns.Add(new column() { header = columnHeader, content = columnTemplateValue, style = style });
                this.Body = GenerateHeader() + "\n" + GenerateBody() + "\n" + GenerateFooter();
                return this;
            }

            private string GenerateHeader()
            {
                return "<!-- scriban {{ date.now }} --> \n {{this.item = model}}";
            }
            private string GenerateBody()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(512);
                sb.AppendLine(@"<table class=""table table-hover""><tbody>");
                foreach (var c in columns)
                {
                    sb.Append($"<tr><td>{c.header}</td><td ");
                    if (!string.IsNullOrEmpty(c.style))
                        sb.Append($"style=\"{c.style}\" ");
                    sb.AppendLine($">{c.content}</td></tr>");
                }
                sb.Append(@"</table>");
                return sb.ToString();
            }

            private string GenerateFooter()
            {
                return "";
            }

        }
    }
}