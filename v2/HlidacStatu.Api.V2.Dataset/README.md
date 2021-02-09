# Knihovna Dataset (nástupce knihovny DatasetConnector)

[![NuGet](https://img.shields.io/nuget/dt/HlidacStatu.Api.V2.Dataset.svg)](https://www.nuget.org/packages/HlidacStatu.Api.V2.Dataset)
[![NuGet](https://img.shields.io/nuget/v/HlidacStatu.Api.V2.Dataset.svg)](https://www.nuget.org/packages/HlidacStatu.Api.V2.Dataset)

Knihovna pro .NET Framework napsaná ve .NET Standardu 2.0, .NET Framework 4.7.2 a .NET Framework 4.8  umožňující snadnou práci s datasety Hlídače státu. Dostupná také jako [NuGet balíček](https://www.nuget.org/packages/HlidacStatu.Api.V2.Dataset).

## Použití knihovny


### Příprava datasetu
Pro přípravu datasetu je potřeba:

- znát váš `ApiToken`, který lze získat po přihlášení na stránkách [Hlídače Státu - API pro vývojáře](https://www.hlidacstatu.cz/api/v1/Index)
```csharp 
string apiToken = "Token 0000000a00b000000c00000"; 
```

- je možno si zvolit jedinečný identifikátor datasetu, pokud nebude zvolen, Hlídač státu jej automaticky odvodí z názvu datasetu 
```csharp
string dataSetId = "osoby-kontrolovane-nku";
```

- vytvořit třídu reprezentující jednotlivý záznam (řádek) datasetu, tato třída musí obsahovat vlastnost (property) pojmenovanou `Id`

```csharp
    class DataSetItem
    {
        // musí být
        public string Id { get; set; }

        // další nepovinné vlastnosti 
        public string KontrolovanaOsoba { get; set; }
        public string ICO { get; set; }                
    }
```

- vytvořit instanci dvourozměrného pole `string[,]`, které slouží pro nastavení možností řazení zobrazených záznamů z datasetu 
```csharp
         orderList = new string[,] {
                { "Kontrolovaná osoba", "KontrolovanaOsoba.keyword" },
                { "Ico", "ICO.keyword" },
                { "Okres", "Okres.keyword" },
                { "Kontrolní akce", "KontrolniAkce.keyword"},
            };
```
- vytvořit instanci třídy `ClassicSearchResultTemplate`, která slouží jako šablona pro zobrazení více záznamů z datasetu (tabulkové zobrazení)
```csharp
searchTemplate = new ClassicTemplate.ClassicSearchResultTemplate()
           .AddColumn("Detail", @"<a href=""{{fn_DatasetItemUrl(item.Id)}}"">Detail</a>")
           .AddColumn("Kontrolovaná osoba dle NKÚ", "{{item.KontrolovanaOsoba}}")
           .AddColumn("Kontrolovaná osoba dle obchodního rejstříku", "{{fn_RenderCompanyWithLink(item.ICO)}}")
           .AddColumn("IČ", "{{item.ICO}}")
           .AddColumn("Okres", "{{item.Okres}}");
```
- vytvořit instanci třídy `ClassicDetailTemplate`, která slouží jako šablona pro detailní zobrazení jednoho záznamu z datasetu
```csharp
detailTemplate = new ClassicTemplate.ClassicDetailTemplate()
            .AddColumn("Kontrolovaná osoba dle NKÚ", "{{item.KontrolovanaOsoba}}")
            .AddColumn("Kontrolovaná osoba dle obchodního rejstříku", "{{fn_RenderCompanyWithLink(item.ICO)}}")
            .AddColumn("IČ", "{{item.ICO}}")
            .AddColumn("Okres", "{{item.Okres}}")
            .AddColumn("Kontrolní akce", @"<a href=""{{item.KontrolniAkceHlidacStatuUrl}}"">{{item.KontrolniAkce}}</a>");
```
- vytvořit instanci třídy `Registration`, která slouží pro nastavení parametrů datasetu, není nutno ji vytvářet, pokud se využije přetížení konstruktoru,
  které má podobné možnosti, ale chybí možnost nastavení výchozího řazení zobrazených záznamů z datasetu (vlastnost `DefaultOrderBy`)
  a také je potřeba nastavit vlastnost `JsonSchema`
```csharp
registration = new Registration()
            {
                Name = "Osoby kontrolované NKÚ",
                
                // pokud není vyplněno, Hlídač státu Id automaticky odvodí z názvu datasetu 
                DatasetId = dataSetId, 
                OrigUrl = @"https://data.nku.cz/download/kontrolovane-osoby/kontrolovane_osoby.csv",
                Description = "Osoby kontrolované NKÚ",
                SourcecodeUrl = string.Empty,
                Betaversion = true,
                AllowWriteAccess = false,
                OrderList = orderList,
                SearchResultTemplate = searchTemplate,
                DetailTemplate = detailTemplate,
                Hidden = false,
                DefaultOrderBy = "KontrolovanaOsoba.keyword asc",
                
                // je také nutno nastavit, dataset tuto vlastnost nenastaví automaticky
                JsonSchema = new JSchemaGenerator().Generate(typeof(DataSetItem)).ToString()
            };
``` 


### Založení datasetu na serveru

Založení datasetu na serveru se provede zavoláním statické metody `CreateDataset` třídy [Dataset<T>](v2/HlidacStatu.Api.V2.Dataset/Typed/Dataset.cs) 
a předáním potřebných parametrů z předchozí přípravy datasetu. Generickým parametrem je vaše třída reprezentující jednotlivý záznam vytvořená v prvním kroku.

```csharp
Dataset<DataSetItem> dataSetInstance = Dataset<DataSetItem>.CreateDataset(apiToken, registration);
``` 
Pokud již vytvářený dataset existuje, je vyvolána výjimka `ApiException`. 

### Ověření existence datasetu na serveru

Ověření existence datasetu je možné zachycením výjimky např.
```csharp
        public Dataset<DataSetItem> GetDataSetInstance()
        {
            Dataset<DataSetItem> dataSetInstance;
            try
            {
                dataSetInstance = Dataset<DataSetItem>.OpenDataset(apiToken, dataSetId);
            }
            catch (ApiException)
            {
                Console.WriteLine($"Dataset s požadovaným ID {dataSetId} neexistuje, vytvářím nový");
                dataSetInstance = Dataset<DataSetItem>.CreateDataset(apiToken, registration);
                Console.WriteLine($"Dataset vytvořen, přidělené ID datasetu: {dataSetInstance.DatasetId}");
            }
            return dataSetInstance;
        }
```

### Otevření přístupu k datasetu, který již existuje na serveru

Pro přístup k datasetu potřebujeme instanci datasetu, kterou získáme zavoláním statické metody `OpenDataset` třídy [Dataset<T>](v2/HlidacStatu.Api.V2.Dataset/Typed/Dataset.cs) 
a předáním potřebných parametrů. Generickým parametrem je vaše třída reprezentující jednotlivý záznam z prvního kroku.

```csharp        
Dataset<DataSetItem> dataSetInstance = Dataset<DataSetItem>.OpenDataset(apiToken, dataSetId);
```


### Změna definice datasetu na serveru

Existující dataset lze upravit kromě hodnot `DatasetId` a `JsonSchema` (pro jejich změnu je nutné nejprve dataset smazat a následně vytvořit nový). Úprava datasetu se provede voláním instanční metody `UpdateRegistration`, která jako parametr přijímá registraci datasetu.

```csharp
dataSetInstance.UpdateRegistration(registration);
```

Pokud upravovaný dataset neexistuje, je vyvolána výjimka.


### Přidání jednotlivého záznamu, nebo změna jednotlivého záznamu v datasetu na serveru

Záznam je možno přidat voláním instanční metody `AddOrUpdateItem`, které se jako parametr předá přidávaný záznam 
a nastavení jaká akce se vyvolá, pokud již záznam v datasetu existuje: 

* `skip`  - pokud záznam existuje, nic se na něm nezmění, přidávaný záznam bude přeskočen 
* `merge` - snaží se spojit data z obou záznamů
* `rewrite` - záznam v datasetu bude přepsán 

V případě úspěšného přidání záznamu je vráceno `Id` záznamu, jinak je vyvolána výjimka.
```csharp
var recordId = dataSetInstance.AddOrUpdateItem(dataSetItem, ItemInsertMode.rewrite);
```

### Přidání většího množství záznamů, nebo změna většího množství záznamů v datasetu na serveru

Větší množství záznamů je možno přidat voláním instanční metody `AddOrRewriteItems`, které se jako parametr předají přidávané záznamy. 
Pokud záznam s daným Id již existuje bude přepsán.
V případě úspěšného přidání záznamů jsou vrácena `Id` záznamů, jinak je vyvolána výjimka.

```csharp
var recordId = dataSetInstance.AddOrRewriteItems(dataSetItems);
```

### Ověření přítomnosti záznamu v datasetu na serveru

Ověření se provede voláním instanční metody `ItemExists`, které se jako parametr předá identifikátor záznamu. Vrací `true/false`.

```csharp
bool exists = dataSetInstance.ItemExists(itemId);
```

### Získání záznamu z datasetu na serveru

Získání záznamu z datasetu se provede voláním instanční metody `GetItem`, které se jako parametr předá identifikátor záznamu. 
V případě úspěchu je navrácen požadovaný záznam, jinak je vyvolána výjimka `ApiException`.

```csharp
var item = dataSetInstance.GetItem(itemId);
```

### Bezpečné získání záznamu z datasetu na serveru

Získání záznamu z datasetu se provede voláním instanční metody `GetItemSafe`, které se jako parametr předá identifikátor záznamu. 
V případě úspěchu je navrácen požadovaný záznam, jinak je vráceno `null`.

```csharp
var item = dataSetInstance.GetItemSafe(itemId);
```

### Vyhledávání v datasetu na serveru

V datasetu je možno vyhledávat voláním instanční metody `Search`, které se jako parametr předá vyhledávaná položka, stránka výsledků a volitelné parametry týkající se řazení záznamů . 
V případě úspěchu je navrácen požadovaný záznam, jinak prázdná kolekce;

```csharp
var item = dataSetInstance.Search("Praha",1);
```

