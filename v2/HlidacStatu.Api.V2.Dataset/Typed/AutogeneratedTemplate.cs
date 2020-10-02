﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

using static HlidacStatu.Api.V2.Dataset.ClassicTemplate;

namespace HlidacStatu.Api.V2.Dataset.Typed
{
    public  class AutogeneratedTemplate<TData>
    {
        ClassicDetailTemplate detail = new ClassicDetailTemplate();
        ClassicSearchResultTemplate search = new ClassicSearchResultTemplate();

        public AutogeneratedTemplate()
        {
            generate();
        }

        public V2.CoreApi.Model.Template Detail() => detail;
        public V2.CoreApi.Model.Template Search() => search;



        private void generate()
        {
            var jsonGen = new JSchemaGenerator
            {
                DefaultRequired = Newtonsoft.Json.Required.Default
            };
            var schema = jsonGen.Generate(typeof(TData));
            var types = GetPropertyNameTypeFromSchema(schema);

            if (types.Count(kv => kv.Key.ToLower() == "id") == 0)
                throw new ArgumentNullException("Class Type", "Class must containt property 'Id' or 'id'");

            KeyValuePair<string, Type> idType = types.Where(kv => kv.Key.ToLower() == "id").FirstOrDefault();

            search.AddColumn("Detail", "<a href=\"{{ fn_DatasetItemUrl item." + idType.Key + " }}\">Detail</a>");
            int searchAdded = 0;
            foreach (var col in types)
            {
                if (col.Key.ToLower() != "id" )
                {
                    searchAdded++;
                    if (searchAdded < 6)
                    {
                        if (col.Value == typeof(Nullable<DateTime>) || col.Value == typeof(DateTime))
                            search.AddColumn(col.Key, "{{ fn_FormatDate item." + col.Key + " }}");
                        else if (col.Value == typeof(Nullable<Date>) || col.Value == typeof(Date))
                            search.AddColumn(col.Key, "{{ fn_FormatDate item." + col.Key + " }}");
                        else if (col.Value == typeof(string))
                            search.AddColumn(col.Key, "{{ item." + col.Key + " }}");
                        else if (col.Value == typeof(Nullable<decimal>) || col.Value == typeof(decimal))
                            search.AddColumn(col.Key, "{{ fn_FormatNumber item." + col.Key + " }}");
                        else if (col.Value == typeof(Nullable<long>) || col.Value == typeof(long))
                            search.AddColumn(col.Key, "{{ fn_FormatNumber item." + col.Key + " }}");
                        else if (col.Value == typeof(Nullable<bool>) || col.Value == typeof(bool))
                            search.AddColumn(col.Key, "{{ item." + col.Key + " }}");
                    }
                    if (col.Value == typeof(Nullable<DateTime>) || col.Value == typeof(DateTime))
                        detail.AddColumn(col.Key, "{{ fn_FormatDate item." + col.Key + " }}");
                    else if (col.Value == typeof(Nullable<Date>) || col.Value == typeof(Date))
                        detail.AddColumn(col.Key, "{{ fn_FormatDate item." + col.Key + " }}");
                    else if (col.Value == typeof(string))
                        detail.AddColumn(col.Key, "{{ item." + col.Key + " }}");
                    else if (col.Value == typeof(Nullable<decimal>) || col.Value == typeof(decimal))
                        detail.AddColumn(col.Key, "{{ fn_FormatNumber item." + col.Key + " }}");
                    else if (col.Value == typeof(Nullable<long>) || col.Value == typeof(long))
                        detail.AddColumn(col.Key, "{{ fn_FormatNumber item." + col.Key + " }}");
                    else if (col.Value == typeof(Nullable<bool>) || col.Value == typeof(bool))
                        detail.AddColumn(col.Key, "{{ item." + col.Key + " }}");

                }
            }




        }


        public Dictionary<string, Type> GetPropertyNameTypeFromSchema(JSchema sch, string name = null)
        {
            Dictionary<string, Type> names = new Dictionary<string, Type>();
            getPropertyNameTypeFromSchemaInternal(new JSchema[] { sch }, "", name, ref names);
            return names;
        }
        private void getPropertyNameTypeFromSchemaInternal(IEnumerable<JSchema> subschema, string prefix, string name, ref Dictionary<string, Type> names)
        {
            foreach (var ss in subschema)
            {
                foreach (var prop in ss.Properties)
                {
                    if (string.IsNullOrEmpty(name)
                        || (!string.IsNullOrEmpty(name) && prop.Key == name)
                        )
                    {
                        names.Add(prefix + prop.Key, JSchemaType2Type(prop.Value));
                    }
                    if (prop.Value.Items.Count > 0)
                        getPropertyNameTypeFromSchemaInternal(prop.Value.Items, prefix + prop.Key + ".", name, ref names);
                    else if (prop.Value.Properties?.Count > 0)
                    {
                        getPropertyNameTypeFromSchemaInternal(
                            new JSchema[] { prop.Value }
                            , prefix + prop.Key + ".", name, ref names);
                    }
                }
            }

        }
        private Type JSchemaType2Type(JSchema schema)
        {
            if (schema?.Type == null)
                return null;

            JSchemaType s = schema.Type.Value;

            if (IsSet(s, JSchemaType.Null))
            {
                //nullable types
                if (IsSet(s, JSchemaType.String))
                {
                    if (schema.Format == "date-time")
                        return typeof(Nullable<DateTime>);
                    else if (schema.Format == "date")
                        return typeof(Nullable<Date>);
                    else
                        return typeof(string);
                }
                else if (IsSet(s, JSchemaType.Number))
                    return typeof(Nullable<decimal>);
                else if (IsSet(s, JSchemaType.Integer))
                    return typeof(Nullable<long>);
                else if (IsSet(s, JSchemaType.Boolean))
                    return typeof(Nullable<bool>);
                else if (IsSet(s, JSchemaType.Object))
                    return typeof(object);
                else if (IsSet(s, JSchemaType.Array))
                    return typeof(object[]);
                else if (IsSet(s, JSchemaType.None))
                    return null;
                else
                    return null;
            }
            else
            {
                if (IsSet(s, JSchemaType.String))
                {
                    if (schema.Format == "date" || schema.Format == "date-time")
                        return typeof(DateTime);
                    else if (schema.Format == "date")
                        return typeof(Date);
                    else
                        return typeof(string);
                }
                else if (IsSet(s, JSchemaType.Number))
                    return typeof(decimal);
                else if (IsSet(s, JSchemaType.Integer))
                    return typeof(long);
                else if (IsSet(s, JSchemaType.Boolean))
                    return typeof(bool);
                else if (IsSet(s, JSchemaType.Object))
                    return typeof(object);
                else if (IsSet(s, JSchemaType.Array))
                    return typeof(object[]);
                else if (IsSet(s, JSchemaType.None))
                    return null;
                else
                    return null;
            }

        }
        public static bool IsSet<T>(T flags, T flag) where T : struct
        {
            int flagsValue = (int)(object)flags;
            int flagValue = (int)(object)flag;

            return (flagsValue & flagValue) != 0;
        }


    }
}