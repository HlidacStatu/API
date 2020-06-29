using System;
using System.Collections.Generic;
using System.Text;

namespace HlidacStatu.Api.V2
{
    public class Dataset<T>
        where T:class
    {
        public string DatasetId { get; set; }

        public CoreApi.DatasetyApi api = null;
        public Dataset(string datasetNameId, string apiToken)
        {
            CoreApi.Client.Configuration conf = new CoreApi.Client.Configuration();
            conf.AddApiKey("Authorization", apiToken);
            api = new V2.CoreApi.DatasetyApi(conf);
        }

        public CoreApi.Model.DSCreatedDTO CreateDataset(V2.CoreApi.Model.Registration registration)
        {
            registration.DatasetId = this.DatasetId;
            return api.ApiV2DatasetyCreate(registration);
        }


    }
}
