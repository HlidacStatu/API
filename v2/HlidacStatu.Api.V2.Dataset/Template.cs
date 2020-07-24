using System.Linq;

namespace HlidacStatu.Api.V2.Dataset
{
	public class Template
	{
		public string Body { get; set; } = "";
		public string[] Properties { get; set; } = null;


		public static implicit operator V2.CoreApi.Model.Template(Template t) => new CoreApi.Model.Template(null, t.Body, null, null, t.Properties?.ToList());


	}
}
