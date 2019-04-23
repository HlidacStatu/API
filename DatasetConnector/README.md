# Knihovna DatasetConnector

[![NuGet](https://img.shields.io/nuget/dt/HlidacStatu.Api.Dataset.Connector.svg)](https://www.nuget.org/packages/HlidacStatu.Api.Dataset.Connector)
[![NuGet](https://img.shields.io/nuget/v/HlidacStatu.Api.Dataset.Connector.svg)](https://www.nuget.org/packages/HlidacStatu.Api.Dataset.Connector)

Knihovna pro .NET Framework napsaná ve .NET Standardu 1.6 a .NET Framework 4.6.1 umožňující snadnou práci s Datasety Hlídače státu. Dostupná také jako [NuGet balíček](https://www.nuget.org/packages/HlidacStatu.Api.Dataset.Connector).

## Použití knihovny

### Vytvoření instance konektoru

Pro vytvoření instance konektoru je nutné znát Váš `ApiToken`, který lze získat po příhlášení na stránkách [Hlídače Státu - API pro vývojáře](https://www.hlidacstatu.cz/api/v1/Index). 

```
    IDatasetConnector datasetConnector = new DatasetConnector(ApiToken);
```

Jakmile máme instanci vytvořenou, je potřeba definovat vlastní dataset.

### Definice datasetu

Dataset je v knihovně popsaný třídou [Dataset.cs](DatasetConnector/Dataset.cs), která je generická, protože JSON schema se automaticky generuje na základě generického parametru. Generický parametr musí splňovat podmínku, že implementuje rozhranní `IDatasetItem`, který vyžaduje definici parametru `Id`. Jednotlivé parametry odpovídají definici datové sady a jejich popis lze nalézt v [dokumentaci](https://hlidacstatu.docs.apiary.io/#reference/datasety-rozsirene-datove-sady-hlidace-statu/datasety).

Jelikož definice datasetu se v průběhu práce s ním pravděpodobně měnit nebude, je možné ji mít v programu uloženou např. jako statickou proměnnou 

```
		new HlidacStatu.Api.Dataset.Connector.Dataset<Most>(
                "Stav Mostů v ČR", "Stav-Mostu", "http://bms.clevera.cz/Public", "Stav mostů v ČR. V tuto chvíli na dálnicích a silnicích I.třídy, které spravuje ŘSD.", "https://github.com/HlidacStatu/Datasety/tree/master/MostyRSD",
                false, true,
                new string[,] { { "Stav mostů", "Stav" }, { "Poslední kontrola", "PosledniProhlidka" } },
                new ClassicTemplate.ClassicSearchResultTemplate()
                    .AddColumn("Označení", @"<a href=""@(fn_DatasetItemUrl(item.Id))"">@item.Oznaceni</a>")
                    .AddColumn("Jméno", "@item.Jmeno")
                    .AddColumn("Stav mostu", "@item.PopisStavu")
                    .AddColumn("Poslední kontrola", "@fn_FormatDate(item.PosledniProhlidka,\"dd.MM.yyyy\")")
                    .AddColumn("Mapa", "<a target='blank' href='https://mapy.cz/zakladni?q=@(fn_FormatNumber(item.GPS_Lat,\"en\")),@(fn_FormatNumber(item.GPS_Lng,\"en\"))'>na mapě</a>")
                ,
                new ClassicTemplate.ClassicDetailTemplate()
                    .AddColumn("Jméno", "@item.Jmeno")
                    .AddColumn("Místní název", "@item.MistniNazev")
                    .AddColumn("Poslední kontrola", "@fn_FormatDate(item.PosledniProhlidka,\"dd.MM.yyyy\")")
                    .AddColumn("Stav mostu", "@item.PopisStavu")
                    .AddColumn("Spravuje", "@item.SpravaOrganizace, @item.SpravaProvozniUsek, @item.SpravaStredisko")
                    .AddColumn("Souřadnice", "Lat: @(fn_FormatNumber(item.GPS_Lat,\"en\"))<br/>Long: @(fn_FormatNumber(item.GPS_Lng,\"en\"))")
                    .AddColumn("Mapa", "<iframe src=\"https://api.mapy.cz/frame?params=%7B%22x%22%3A@(fn_FormatNumber(item.GPS_Lng,\"en\"))%2C%22y%22%3A@(fn_FormatNumber(item.GPS_Lat,\"en\"))%2C%22base%22%3A%221%22%2C%22layers%22%3A%5B%5D%2C%22zoom%22%3A16%2C%22url%22%3A%22https%3A%2F%2Fmapy.cz%2Fs%2F3auci%22%2C%22mark%22%3A%7B%22x%22%3A%22@(fn_FormatNumber(item.GPS_Lng,\"en\"))%22%2C%22y%22%3A%22@(fn_FormatNumber(item.GPS_Lat,\"en\"))%22%2C%22title%22%3A%22Poloha+mostu%22%7D%2C%22overview%22%3Atrue%7D&amp;width=500&amp;height=333&amp;lang=cs\" width=\"500\" height=\"333\" style=\"border:none\" frameBorder=\"0\"></iframe>")
                );
```

kde `Most` definuje strukturu datasetu (v tomto případě informace o jednom mostu) a proměnné `SearchResultTemplate` a `DetailTemplate` definují šablony použité pro vykreslení seznamu výsledků vyhledávání a detailu položky datasetu. Více informací k definici šablony lze nalézt v popisu API - [HTML Template](https://hlidacstatu.docs.apiary.io/#reference/html-teplate-syntaxe,-funkce).

Pomocná třída a metody v ní `ClassicTemplate` pomohou vygenerovat template pro stránku s výsledky hledání a detail.

Vlastnosti `datasetId` a generované `JsonSchema` se nesmí měnit. Při nutnosti jejich změny je potřeba nejprve starý dataset odstranit a poté vytvořit nový se změněnými hodnotami.


### Ověření existence datasetu

Pro ověření, zda dataset již existuje, slouží metoda `DatasetExists`, která jako parametr přijímá definici datasetu a vrací `true`, pokud je daný dataset již zaregistrován v Hlídači státu, jinak vrací `false`.

```
    var datasetExists = await datasetConnector.DatasetExists(dataset)
```

### Vytvoření nového datasetu

Nový dataset se v Hlídači státu vytvoří (zaregistruje) voláním metody `RegisterDataset`, která jako parametr přijímá definici datasetu a vrací id datasetu v Hlídači státu (`datasetId` není povinná položka a pokud není vyplněna, Hlídač státu ji automaticky odvodí z názvu datasetu, tato hodnota je následně vrácena. Pokud je hodnota `datasetId` vyplněna, je použita při registraci a vrácena).

```
    var datasetId = await datasetConnector.CreateDataset(dataset);
```

Pokud již vytvářený dataset existuje, je vyvolána výjimka `DatasetConnectorException`.

### Změna definice datasetu

Existující dataset lze upravit kromě hodnot `datasetId` a `JsonSchema` (pro jejich změnu je nutné nejprve dataset smazat a následně vytvořit nový). Úprava datasetu se provede voláním metody `UpdateDataset`, která jako parametr přijímá definici datasetu a vrací string `Ok`, pokud se dataset podařilo upravit.

```
    var updateResult = await datasetConnector.UpdateDataset(changedDataset);
```

Pokud upravovaný dataset neexistuje, je vyvolána výjimka `DatasetConnectorException`.

### Smazání datasetu

Definici datasetu, včetně všech nahraných záznamů, lze odstranit voláním metody `DeleteDataset`, která jako parametr přijímá definici datasetu.

```
    await datasetConnector.DeleteDataset(dataset);
```

Pokud upravovaný dataset neexistuje, je vyvolána výjimka `DatasetConnectorException`.

### Přidání (změna) záznamu do datasetu

Záznam se do datasetu přidá voláním metody `AddItemToDataset`, která jako první parametr přijímá definici datasetu a jako druhý parametr přidávaný záznam. V případě, že záznam na základě `Id` v datasetu již existuje, bude nahrazen nově vkládaným záznamem. Návratová hodnota metody je `Id` záznamu.

```
    var result = await datasetConnector.AddItemToDataset(dataset, rizeni)
```
