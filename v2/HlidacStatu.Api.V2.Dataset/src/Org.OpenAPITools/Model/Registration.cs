/*
 * HlidacStatu_ApiV2
 *
 * REST API Hlídače státu
 *
 * The version of the OpenAPI document: v2
 * Contact: podpora@hlidacstatu.cz
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// Registration
    /// </summary>
    [DataContract(Name = "Registration")]
    public partial class Registration : IEquatable<Registration>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Registration" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="datasetId">datasetId.</param>
        /// <param name="origUrl">origUrl.</param>
        /// <param name="sourcecodeUrl">sourcecodeUrl.</param>
        /// <param name="description">description.</param>
        /// <param name="jsonSchema">jsonSchema.</param>
        /// <param name="createdBy">createdBy.</param>
        /// <param name="created">created.</param>
        /// <param name="betaversion">betaversion.</param>
        /// <param name="allowWriteAccess">allowWriteAccess.</param>
        /// <param name="hidden">hidden.</param>
        /// <param name="searchResultTemplate">searchResultTemplate.</param>
        /// <param name="detailTemplate">detailTemplate.</param>
        /// <param name="defaultOrderBy">defaultOrderBy.</param>
        /// <param name="orderList">orderList.</param>
        public Registration(string name = default(string), string datasetId = default(string), string origUrl = default(string), string sourcecodeUrl = default(string), string description = default(string), string jsonSchema = default(string), string createdBy = default(string), DateTime created = default(DateTime), bool betaversion = default(bool), bool allowWriteAccess = default(bool), bool hidden = default(bool), Template searchResultTemplate = default(Template), Template detailTemplate = default(Template), string defaultOrderBy = default(string), string[,] orderList = default(string[,]))
        {
            this.Name = name;
            this.DatasetId = datasetId;
            this.OrigUrl = origUrl;
            this.SourcecodeUrl = sourcecodeUrl;
            this.Description = description;
            this.JsonSchema = jsonSchema;
            this.CreatedBy = createdBy;
            this.Created = created;
            this.Betaversion = betaversion;
            this.AllowWriteAccess = allowWriteAccess;
            this.Hidden = hidden;
            this.SearchResultTemplate = searchResultTemplate;
            this.DetailTemplate = detailTemplate;
            this.DefaultOrderBy = defaultOrderBy;
            this.OrderList = orderList;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; private set; }

        /// <summary>
        /// Returns false as Id should not be serialized given that it's read-only.
        /// </summary>
        /// <returns>false (boolean)</returns>
        public bool ShouldSerializeId()
        {
            return false;
        }
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets DatasetId
        /// </summary>
        [DataMember(Name = "datasetId", EmitDefaultValue = false)]
        public string DatasetId { get; set; }

        /// <summary>
        /// Gets or Sets OrigUrl
        /// </summary>
        [DataMember(Name = "origUrl", EmitDefaultValue = false)]
        public string OrigUrl { get; set; }

        /// <summary>
        /// Gets or Sets SourcecodeUrl
        /// </summary>
        [DataMember(Name = "sourcecodeUrl", EmitDefaultValue = false)]
        public string SourcecodeUrl { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets JsonSchema
        /// </summary>
        [DataMember(Name = "jsonSchema", EmitDefaultValue = false)]
        public string JsonSchema { get; set; }

        /// <summary>
        /// Gets or Sets CreatedBy
        /// </summary>
        [DataMember(Name = "createdBy", EmitDefaultValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or Sets Created
        /// </summary>
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets or Sets Betaversion
        /// </summary>
        [DataMember(Name = "betaversion", EmitDefaultValue = true)]
        public bool Betaversion { get; set; }

        /// <summary>
        /// Gets or Sets AllowWriteAccess
        /// </summary>
        [DataMember(Name = "allowWriteAccess", EmitDefaultValue = true)]
        public bool AllowWriteAccess { get; set; }

        /// <summary>
        /// Gets or Sets Hidden
        /// </summary>
        [DataMember(Name = "hidden", EmitDefaultValue = true)]
        public bool Hidden { get; set; }

        /// <summary>
        /// Gets or Sets SearchResultTemplate
        /// </summary>
        [DataMember(Name = "searchResultTemplate", EmitDefaultValue = false)]
        public Template SearchResultTemplate { get; set; }

        /// <summary>
        /// Gets or Sets DetailTemplate
        /// </summary>
        [DataMember(Name = "detailTemplate", EmitDefaultValue = false)]
        public Template DetailTemplate { get; set; }

        /// <summary>
        /// Gets or Sets DefaultOrderBy
        /// </summary>
        [DataMember(Name = "defaultOrderBy", EmitDefaultValue = false)]
        public string DefaultOrderBy { get; set; }

        /// <summary>
        /// Gets or Sets OrderList
        /// </summary>
        [DataMember(Name = "orderList", EmitDefaultValue = false)]
        public string[,] OrderList { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Registration {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  DatasetId: ").Append(DatasetId).Append("\n");
            sb.Append("  OrigUrl: ").Append(OrigUrl).Append("\n");
            sb.Append("  SourcecodeUrl: ").Append(SourcecodeUrl).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  JsonSchema: ").Append(JsonSchema).Append("\n");
            sb.Append("  CreatedBy: ").Append(CreatedBy).Append("\n");
            sb.Append("  Created: ").Append(Created).Append("\n");
            sb.Append("  Betaversion: ").Append(Betaversion).Append("\n");
            sb.Append("  AllowWriteAccess: ").Append(AllowWriteAccess).Append("\n");
            sb.Append("  Hidden: ").Append(Hidden).Append("\n");
            sb.Append("  SearchResultTemplate: ").Append(SearchResultTemplate).Append("\n");
            sb.Append("  DetailTemplate: ").Append(DetailTemplate).Append("\n");
            sb.Append("  DefaultOrderBy: ").Append(DefaultOrderBy).Append("\n");
            sb.Append("  OrderList: ").Append(OrderList).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Registration);
        }

        /// <summary>
        /// Returns true if Registration instances are equal
        /// </summary>
        /// <param name="input">Instance of Registration to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Registration input)
        {
            if (input == null)
            {
                return false;
            }
            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.DatasetId == input.DatasetId ||
                    (this.DatasetId != null &&
                    this.DatasetId.Equals(input.DatasetId))
                ) && 
                (
                    this.OrigUrl == input.OrigUrl ||
                    (this.OrigUrl != null &&
                    this.OrigUrl.Equals(input.OrigUrl))
                ) && 
                (
                    this.SourcecodeUrl == input.SourcecodeUrl ||
                    (this.SourcecodeUrl != null &&
                    this.SourcecodeUrl.Equals(input.SourcecodeUrl))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.JsonSchema == input.JsonSchema ||
                    (this.JsonSchema != null &&
                    this.JsonSchema.Equals(input.JsonSchema))
                ) && 
                (
                    this.CreatedBy == input.CreatedBy ||
                    (this.CreatedBy != null &&
                    this.CreatedBy.Equals(input.CreatedBy))
                ) && 
                (
                    this.Created == input.Created ||
                    (this.Created != null &&
                    this.Created.Equals(input.Created))
                ) && 
                (
                    this.Betaversion == input.Betaversion ||
                    this.Betaversion.Equals(input.Betaversion)
                ) && 
                (
                    this.AllowWriteAccess == input.AllowWriteAccess ||
                    this.AllowWriteAccess.Equals(input.AllowWriteAccess)
                ) && 
                (
                    this.Hidden == input.Hidden ||
                    this.Hidden.Equals(input.Hidden)
                ) && 
                (
                    this.SearchResultTemplate == input.SearchResultTemplate ||
                    (this.SearchResultTemplate != null &&
                    this.SearchResultTemplate.Equals(input.SearchResultTemplate))
                ) && 
                (
                    this.DetailTemplate == input.DetailTemplate ||
                    (this.DetailTemplate != null &&
                    this.DetailTemplate.Equals(input.DetailTemplate))
                ) && 
                (
                    this.DefaultOrderBy == input.DefaultOrderBy ||
                    (this.DefaultOrderBy != null &&
                    this.DefaultOrderBy.Equals(input.DefaultOrderBy))
                ) && 
                (
                    this.OrderList == input.OrderList ||
                    this.OrderList != null &&
                    input.OrderList != null &&
                    this.OrderList.SequenceEqual(input.OrderList)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Id != null)
                {
                    hashCode = (hashCode * 59) + this.Id.GetHashCode();
                }
                if (this.Name != null)
                {
                    hashCode = (hashCode * 59) + this.Name.GetHashCode();
                }
                if (this.DatasetId != null)
                {
                    hashCode = (hashCode * 59) + this.DatasetId.GetHashCode();
                }
                if (this.OrigUrl != null)
                {
                    hashCode = (hashCode * 59) + this.OrigUrl.GetHashCode();
                }
                if (this.SourcecodeUrl != null)
                {
                    hashCode = (hashCode * 59) + this.SourcecodeUrl.GetHashCode();
                }
                if (this.Description != null)
                {
                    hashCode = (hashCode * 59) + this.Description.GetHashCode();
                }
                if (this.JsonSchema != null)
                {
                    hashCode = (hashCode * 59) + this.JsonSchema.GetHashCode();
                }
                if (this.CreatedBy != null)
                {
                    hashCode = (hashCode * 59) + this.CreatedBy.GetHashCode();
                }
                if (this.Created != null)
                {
                    hashCode = (hashCode * 59) + this.Created.GetHashCode();
                }
                hashCode = (hashCode * 59) + this.Betaversion.GetHashCode();
                hashCode = (hashCode * 59) + this.AllowWriteAccess.GetHashCode();
                hashCode = (hashCode * 59) + this.Hidden.GetHashCode();
                if (this.SearchResultTemplate != null)
                {
                    hashCode = (hashCode * 59) + this.SearchResultTemplate.GetHashCode();
                }
                if (this.DetailTemplate != null)
                {
                    hashCode = (hashCode * 59) + this.DetailTemplate.GetHashCode();
                }
                if (this.DefaultOrderBy != null)
                {
                    hashCode = (hashCode * 59) + this.DefaultOrderBy.GetHashCode();
                }
                if (this.OrderList != null)
                {
                    hashCode = (hashCode * 59) + this.OrderList.GetHashCode();
                }
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}