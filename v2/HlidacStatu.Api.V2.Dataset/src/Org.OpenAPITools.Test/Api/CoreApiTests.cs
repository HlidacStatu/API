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
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;

namespace Org.OpenAPITools.Test.Api
{
    /// <summary>
    ///  Class for testing CoreApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class CoreApiTests : IDisposable
    {
        private CoreApi instance;

        public CoreApiTests()
        {
            instance = new CoreApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of CoreApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' CoreApi
            //Assert.IsType<CoreApi>(instance);
        }

        /// <summary>
        /// Test ApiV2Ping
        /// </summary>
        [Fact]
        public void ApiV2PingTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string text = null;
            //var response = instance.ApiV2Ping(text);
            //Assert.IsType<string>(response);
        }
    }
}
