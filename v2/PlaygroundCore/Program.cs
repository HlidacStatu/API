// See https://aka.ms/new-console-template for more information

System.Net.Http.HttpClient.DefaultProxy = new System.Net.WebProxy("127.0.0.1", 8888);

string apikey = args[0];

var httpCl = new HttpClient();
httpCl.DefaultRequestHeaders.Add("Authorization", apikey);

var apiCl = new HlidacStatu.Api.V2.swaggerClient("https://api.hlidacstatu.cz/", httpCl);
var sml = await apiCl.SmlouvyAsync("28548131");


var ds = HlidacStatu.Api.V2.Dataset.Typed.Dataset<kvalifikovany_dodavatel>.OpenDataset(apikey, "kvalifikovanidodavatele");
var s = ds.Search("*", 1);



Console.WriteLine(s);

public class kvalifikovany_dodavatel
{
    public string ico { get; set; }
    public string obchodni_firma_nazev_dodavatele { get; set; }
    public string mesto { get; set; }
    public string psc { get; set; }
    public string okres { get; set; }
    public string nuts { get; set; }
    public string zeme { get; set; }
    public string evidencni_cislo { get; set; }
    public string dt_nabyti_pm { get; set; }
    public string potvrzeny_clen_skd { get; set; }
    public string pravni_skutecnost { get; set; }
    public string legalid { get; set; }
    public string konvertovan { get; set; }
    public string vypis { get; set; }
    public string id { get; set; }
}