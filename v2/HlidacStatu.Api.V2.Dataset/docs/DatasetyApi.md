# Org.OpenAPITools.Api.DatasetyApi

All URIs are relative to *https://api.hlidacstatu.cz*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ApiV2DatasetyCreate**](DatasetyApi.md#apiv2datasetycreate) | **POST** /api/v2/datasety | Vytvoří nový dataset |
| [**ApiV2DatasetyDatasetItemBulkInsert**](DatasetyApi.md#apiv2datasetydatasetitembulkinsert) | **POST** /api/v2/datasety/{datasetId}/zaznamy | Hromadné vkládání záznamů |
| [**ApiV2DatasetyDatasetItemExists**](DatasetyApi.md#apiv2datasetydatasetitemexists) | **GET** /api/v2/datasety/{datasetId}/zaznamy/{itemId}/existuje | Kontrola, jestli záznam existuje v datasetu |
| [**ApiV2DatasetyDatasetItemGet**](DatasetyApi.md#apiv2datasetydatasetitemget) | **GET** /api/v2/datasety/{datasetId}/zaznamy/{itemId} | Detail konkrétní položky z datasetu |
| [**ApiV2DatasetyDatasetItemUpdate**](DatasetyApi.md#apiv2datasetydatasetitemupdate) | **POST** /api/v2/datasety/{datasetId}/zaznamy/{itemId} | Vloží nebo updatuje záznam v datasetu |
| [**ApiV2DatasetyDatasetSearch**](DatasetyApi.md#apiv2datasetydatasetsearch) | **GET** /api/v2/datasety/{datasetId}/hledat | Vyhledávání v položkách datasetu |
| [**ApiV2DatasetyDelete**](DatasetyApi.md#apiv2datasetydelete) | **DELETE** /api/v2/datasety/{datasetId} | Smazání datasetu |
| [**ApiV2DatasetyDetail**](DatasetyApi.md#apiv2datasetydetail) | **GET** /api/v2/datasety/{datasetId} | Detail konkrétního datasetu |
| [**ApiV2DatasetyGetAll**](DatasetyApi.md#apiv2datasetygetall) | **GET** /api/v2/datasety | Načte seznam datasetů |
| [**ApiV2DatasetyUpdate**](DatasetyApi.md#apiv2datasetyupdate) | **PUT** /api/v2/datasety | Update datasetu. |

<a id="apiv2datasetycreate"></a>
# **ApiV2DatasetyCreate**
> DSCreatedDTO ApiV2DatasetyCreate (Registration data)

Vytvoří nový dataset

Ukázkový požadavek:  https://raw.githubusercontent.com/HlidacStatu/API/master/v2/create_dataset.example.json

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyCreateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var data = new Registration(); // Registration | Objekt typu Registration

            try
            {
                // Vytvoří nový dataset
                DSCreatedDTO result = apiInstance.ApiV2DatasetyCreate(data);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyCreate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyCreateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Vytvoří nový dataset
    ApiResponse<DSCreatedDTO> response = apiInstance.ApiV2DatasetyCreateWithHttpInfo(data);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyCreateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **data** | [**Registration**](Registration.md) | Objekt typu Registration |  |

### Return type

[**DSCreatedDTO**](DSCreatedDTO.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Dataset vytvořen |  -  |
| **400** | Chyba v datech |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetydatasetitembulkinsert"></a>
# **ApiV2DatasetyDatasetItemBulkInsert**
> List&lt;DSItemResponseDTO&gt; ApiV2DatasetyDatasetItemBulkInsert (string datasetId, Object data)

Hromadné vkládání záznamů

Pokud záznamy s daným ID existují, tak budou přepsány.        Ukázkový požadavek:              [       {        \"HsProcessType\": \"person\",        \"Id\": \"2\",        \"jmeno\": \"Ferda\",        \"prijmeni\": \"Mravenec\",        \"narozeni\": \"2018-11-13T20:20:39+00:00\"       },       {        \"HsProcessType\": \"document\",        \"Id\": \"broukpytlik\",        \"jmeno\": \"Brouk\",        \"prijmeni\": \"Pytlík\",        \"narozeni\": \"2017-12-10T00:00:00+00:00\",        \"DocumentUrl\": \"www.hlidacstatu.cz\",        \"DocumentPlainText\": null       }      ]

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyDatasetItemBulkInsertExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var datasetId = "datasetId_example";  // string | Id datasetu, kam chceme záznamy nahrát
            var data = null;  // Object | Pole JSON objektů

            try
            {
                // Hromadné vkládání záznamů
                List<DSItemResponseDTO> result = apiInstance.ApiV2DatasetyDatasetItemBulkInsert(datasetId, data);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemBulkInsert: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyDatasetItemBulkInsertWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Hromadné vkládání záznamů
    ApiResponse<List<DSItemResponseDTO>> response = apiInstance.ApiV2DatasetyDatasetItemBulkInsertWithHttpInfo(datasetId, data);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemBulkInsertWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** | Id datasetu, kam chceme záznamy nahrát |  |
| **data** | **Object** | Pole JSON objektů |  |

### Return type

[**List&lt;DSItemResponseDTO&gt;**](DSItemResponseDTO.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, application/xml, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetydatasetitemexists"></a>
# **ApiV2DatasetyDatasetItemExists**
> bool ApiV2DatasetyDatasetItemExists (string datasetId, string itemId)

Kontrola, jestli záznam existuje v datasetu

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyDatasetItemExistsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var datasetId = "datasetId_example";  // string | Id datasetu
            var itemId = "itemId_example";  // string | Id záznamu

            try
            {
                // Kontrola, jestli záznam existuje v datasetu
                bool result = apiInstance.ApiV2DatasetyDatasetItemExists(datasetId, itemId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemExists: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyDatasetItemExistsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Kontrola, jestli záznam existuje v datasetu
    ApiResponse<bool> response = apiInstance.ApiV2DatasetyDatasetItemExistsWithHttpInfo(datasetId, itemId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemExistsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** | Id datasetu |  |
| **itemId** | **string** | Id záznamu |  |

### Return type

**bool**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetydatasetitemget"></a>
# **ApiV2DatasetyDatasetItemGet**
> Object ApiV2DatasetyDatasetItemGet (string datasetId, string itemId)

Detail konkrétní položky z datasetu

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyDatasetItemGetExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var datasetId = "datasetId_example";  // string | Id datasetu (můžeme ho získat ze seznamu datasetů)
            var itemId = "itemId_example";  // string | Id položky v datasetu, kterou chceme načíst

            try
            {
                // Detail konkrétní položky z datasetu
                Object result = apiInstance.ApiV2DatasetyDatasetItemGet(datasetId, itemId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemGet: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyDatasetItemGetWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Detail konkrétní položky z datasetu
    ApiResponse<Object> response = apiInstance.ApiV2DatasetyDatasetItemGetWithHttpInfo(datasetId, itemId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemGetWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** | Id datasetu (můžeme ho získat ze seznamu datasetů) |  |
| **itemId** | **string** | Id položky v datasetu, kterou chceme načíst |  |

### Return type

**Object**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetydatasetitemupdate"></a>
# **ApiV2DatasetyDatasetItemUpdate**
> DSItemResponseDTO ApiV2DatasetyDatasetItemUpdate (string datasetId, string itemId, Object data, string? mode = null)

Vloží nebo updatuje záznam v datasetu

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyDatasetItemUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var datasetId = "datasetId_example";  // string | Id datasetu
            var itemId = "itemId_example";  // string | Id záznamu
            var data = null;  // Object | Objekt, který se má vložit, nebo updatovat
            var mode = "mode_example";  // string? | \"skip\" (default) - pokud záznam existuje, nic se na něm nezmění.              \"merge\" - snaží se spojit data z obou záznamů.              \"rewrite\" - pokud záznam existuje, je bez milosti přepsán (optional) 

            try
            {
                // Vloží nebo updatuje záznam v datasetu
                DSItemResponseDTO result = apiInstance.ApiV2DatasetyDatasetItemUpdate(datasetId, itemId, data, mode);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemUpdate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyDatasetItemUpdateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Vloží nebo updatuje záznam v datasetu
    ApiResponse<DSItemResponseDTO> response = apiInstance.ApiV2DatasetyDatasetItemUpdateWithHttpInfo(datasetId, itemId, data, mode);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetItemUpdateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** | Id datasetu |  |
| **itemId** | **string** | Id záznamu |  |
| **data** | **Object** | Objekt, který se má vložit, nebo updatovat |  |
| **mode** | **string?** | \&quot;skip\&quot; (default) - pokud záznam existuje, nic se na něm nezmění.              \&quot;merge\&quot; - snaží se spojit data z obou záznamů.              \&quot;rewrite\&quot; - pokud záznam existuje, je bez milosti přepsán | [optional]  |

### Return type

[**DSItemResponseDTO**](DSItemResponseDTO.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, application/xml, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetydatasetsearch"></a>
# **ApiV2DatasetyDatasetSearch**
> SearchResultDTOObject ApiV2DatasetyDatasetSearch (string datasetId, string? dotaz = null, int? strana = null, string? sort = null, string? desc = null)

Vyhledávání v položkách datasetu

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyDatasetSearchExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var datasetId = "datasetId_example";  // string | Id datasetu (můžeme ho získat ze seznamu datasetů)
            var dotaz = "dotaz_example";  // string? | Hledaný výraz (optional) 
            var strana = 56;  // int? | Stránkování (optional) 
            var sort = "sort_example";  // string? | Název pole pro řazení (optional) 
            var desc = "desc_example";  // string? | Řazení: 0 - Vzestupně; 1 - Sestupně (optional) 

            try
            {
                // Vyhledávání v položkách datasetu
                SearchResultDTOObject result = apiInstance.ApiV2DatasetyDatasetSearch(datasetId, dotaz, strana, sort, desc);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetSearch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyDatasetSearchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Vyhledávání v položkách datasetu
    ApiResponse<SearchResultDTOObject> response = apiInstance.ApiV2DatasetyDatasetSearchWithHttpInfo(datasetId, dotaz, strana, sort, desc);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDatasetSearchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** | Id datasetu (můžeme ho získat ze seznamu datasetů) |  |
| **dotaz** | **string?** | Hledaný výraz | [optional]  |
| **strana** | **int?** | Stránkování | [optional]  |
| **sort** | **string?** | Název pole pro řazení | [optional]  |
| **desc** | **string?** | Řazení: 0 - Vzestupně; 1 - Sestupně | [optional]  |

### Return type

[**SearchResultDTOObject**](SearchResultDTOObject.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetydelete"></a>
# **ApiV2DatasetyDelete**
> bool ApiV2DatasetyDelete (string datasetId)

Smazání datasetu

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyDeleteExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var datasetId = "datasetId_example";  // string | Id datasetu (můžeme ho získat ze seznamu datasetů)

            try
            {
                // Smazání datasetu
                bool result = apiInstance.ApiV2DatasetyDelete(datasetId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDelete: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyDeleteWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Smazání datasetu
    ApiResponse<bool> response = apiInstance.ApiV2DatasetyDeleteWithHttpInfo(datasetId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDeleteWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** | Id datasetu (můžeme ho získat ze seznamu datasetů) |  |

### Return type

**bool**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetydetail"></a>
# **ApiV2DatasetyDetail**
> Registration ApiV2DatasetyDetail (string datasetId)

Detail konkrétního datasetu

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyDetailExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var datasetId = "datasetId_example";  // string | Id datasetu (můžeme ho získat ze seznamu datasetů)

            try
            {
                // Detail konkrétního datasetu
                Registration result = apiInstance.ApiV2DatasetyDetail(datasetId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDetail: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyDetailWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Detail konkrétního datasetu
    ApiResponse<Registration> response = apiInstance.ApiV2DatasetyDetailWithHttpInfo(datasetId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyDetailWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **datasetId** | **string** | Id datasetu (můžeme ho získat ze seznamu datasetů) |  |

### Return type

[**Registration**](Registration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json, application/xml, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetygetall"></a>
# **ApiV2DatasetyGetAll**
> SearchResultDTORegistration ApiV2DatasetyGetAll ()

Načte seznam datasetů

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyGetAllExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);

            try
            {
                // Načte seznam datasetů
                SearchResultDTORegistration result = apiInstance.ApiV2DatasetyGetAll();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyGetAll: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyGetAllWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Načte seznam datasetů
    ApiResponse<SearchResultDTORegistration> response = apiInstance.ApiV2DatasetyGetAllWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyGetAllWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**SearchResultDTORegistration**](SearchResultDTORegistration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="apiv2datasetyupdate"></a>
# **ApiV2DatasetyUpdate**
> Registration ApiV2DatasetyUpdate (Registration data)

Update datasetu.

Není možné změnit hodnoty jsonSchema a datasetId. Pokud je potřebuješ změnit,   musíš datovou sadu smazat a zaregistrovat znovu.    Ukázkový požadavek:  https://raw.githubusercontent.com/HlidacStatu/API/master/v2/create_dataset.example.json

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class ApiV2DatasetyUpdateExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://api.hlidacstatu.cz";
            var apiInstance = new DatasetyApi(config);
            var data = new Registration(); // Registration | Objekt typu Registration

            try
            {
                // Update datasetu.
                Registration result = apiInstance.ApiV2DatasetyUpdate(data);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyUpdate: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ApiV2DatasetyUpdateWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Update datasetu.
    ApiResponse<Registration> response = apiInstance.ApiV2DatasetyUpdateWithHttpInfo(data);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling DatasetyApi.ApiV2DatasetyUpdateWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **data** | [**Registration**](Registration.md) | Objekt typu Registration |  |

### Return type

[**Registration**](Registration.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, application/xml, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

