using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HlidacStatu.Api.V2.Dataset.Api;
using HlidacStatu.Api.V2.Dataset.Model;
using Newtonsoft.Json.Schema.Generation;

namespace HlidacStatu.Api.V2.Dataset.Typed
{

    public enum ItemInsertMode
    {
        skip,
        merge,
        rewrite
    }

    public class Dataset<TData>
        where TData : class
    {
        public string DatasetId { get; set; }
        private string idPropertyName { get; set; } = null;
        private Type myType = typeof(TData);

        public DatasetyApi Api = null;
        protected Dataset(string datasetNameId, DatasetyApi api)
        {
            if (api == null)
                throw new ArgumentNullException("api");
            if (string.IsNullOrEmpty(datasetNameId))
                throw new ArgumentNullException("datasetNameId");
            this.Api = api;
            this.DatasetId = datasetNameId;

            //check Type
            // Get the PropertyInfo object by passing the property name.


            if (myType.GetProperty("id") != null)
                idPropertyName = "id";
            else if (myType.GetProperty("ID") != null)
                idPropertyName = "ID";
            else if (myType.GetProperty("Id") != null)
                idPropertyName = "Id";
            else if (myType.GetProperty("iD") != null)
                idPropertyName = "iD";

            if (idPropertyName == null)
                throw new ArgumentNullException("Class Type", "Class must containt property 'Id' or 'id'");

        }
        public Result<TData> Search(string query, int page, string sort = null, bool desc = false)
        {
            var resObj = this.Api.ApiV2DatasetyDatasetSearch(this.DatasetId, query, page, sort, desc ? "1" : "0");

            var res = new Result<TData>()
            {
                Total = resObj.Total,
                Page = resObj.Page,
                Results = resObj.Results
                    .Select(m => ((Newtonsoft.Json.Linq.JObject)m).ToObject<TData>())
                    .ToArray()
            };

            return res;
        }

        public string AddOrUpdateItem(TData item, ItemInsertMode mode)
        {
            string idValue = myType.GetProperty(idPropertyName).GetValue(item) as string;
            if (idValue == null)
                idValue = myType.GetProperty(idPropertyName).GetValue(item).ToString();
            var res = this.Api.ApiV2DatasetyDatasetItemUpdate(this.DatasetId, idValue, item, mode.ToString());
            return res.Id;
        }

        public string[] AddOrRewriteItems(IEnumerable<TData> items)
        {
            var res = this.Api.ApiV2DatasetyDatasetItemBulkInsert(this.DatasetId, items);
            return res.Select(m => m.Id).ToArray();
        }

        public void UpdateRegistration(Model.Registration registration)
        {
            var res = this.Api.ApiV2DatasetyUpdate(registration);


        }

        /// <summary>
        /// Pokud zaznam neexistuje, vraci exception
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public TData GetItem(string itemId)
        {
            //string idValue = myType.GetProperty(idPropertyName).GetValue(item) as string;
            var res = this.Api.ApiV2DatasetyDatasetItemGet(this.DatasetId, itemId);
            TData obj = ((Newtonsoft.Json.Linq.JObject)res).ToObject<TData>();
            return obj;
        }

        /// <summary>
        /// Pokud zaznam neexistuje, vrati NULL
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public TData GetItemSafe(string itemId)
        {
            //string idValue = myType.GetProperty(idPropertyName).GetValue(item) as string;
            try
            {
                var res = this.Api.ApiV2DatasetyDatasetItemGet(this.DatasetId, itemId);
                TData obj = ((Newtonsoft.Json.Linq.JObject)res).ToObject<TData>();
                return obj;

            }
            catch (Exception e)
            {
                return null;
            }
        }

            public bool ItemExists(string itemId)
        {
            //string idValue = myType.GetProperty(idPropertyName).GetValue(item) as string;
            try
            {
                var res = this.Api.ApiV2DatasetyDatasetItemExists(this.DatasetId, itemId);
                return res;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #region Static 

        public static Dataset<TData> OpenDataset(string apiToken, string datasetNameId, string anotherBaseUrl = null)
        {
            Client.Configuration conf = new Client.Configuration();
            conf.DefaultHeaders.Add("Authorization", apiToken);

            if (!string.IsNullOrEmpty(anotherBaseUrl))
                conf.BasePath = anotherBaseUrl;
            var api = new DatasetyApi(conf);
            var res = api.ApiV2DatasetyDetail(datasetNameId);
            if (res == null)
                return null;
            var dataset = new Dataset<TData>(res.DatasetId, api);

            return dataset;
        }

        public static Dataset<TData> CreateDataset(string apiToken, Registration registration, string anotherBaseUrl = null)
        {

            Client.Configuration conf = new Client.Configuration();
            //conf.AddDefaultHeader("Authorization", apiToken);
            conf.AddApiKey("Authorization", apiToken);

            if (!string.IsNullOrEmpty(anotherBaseUrl))
                conf.BasePath = anotherBaseUrl;

            var api = new DatasetyApi(conf);
            registration.DatasetId = registration.DatasetId;
            var res = api.ApiV2DatasetyCreate(registration);

            var dataset = new Dataset<TData>(res.DatasetId, api);

            return dataset;
        }

        public static Dataset<TData> CreateDataset(string apiToken, string name, string datasetId, string origUrl, string description = "", string sourceCodeUrl = "", bool betaVersion = true, bool allowWriteAccess = false, string[,] orderList = null,
            Model.Template searchResultTemplate = null, Model.Template detailTemplate = null, bool hidden = false)
        {
            var jsonGen = new JSchemaGenerator
            {
                DefaultRequired = Newtonsoft.Json.Required.Default
            };
            var reg = new Model.Registration()
            {
                Name = name,
                DatasetId = datasetId,
                OrigUrl = origUrl,
                Description = description,
                SourcecodeUrl = sourceCodeUrl,
                Betaversion = betaVersion,
                AllowWriteAccess = allowWriteAccess,
                OrderList = orderList,
                SearchResultTemplate = searchResultTemplate,
                DetailTemplate = detailTemplate,
                Hidden = hidden,
                JsonSchema = jsonGen.Generate(typeof(TData)).ToString()
            };

            return CreateDataset(apiToken, reg);

        }
        #endregion
    }
}
