/* 
 * Forge Design Automation
 *
 * Generated by [Forge Swagger Codegen](https://git.autodesk.com/design-automation/forge-rsdk-codegen)
 */

using Autodesk.Forge.Core;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using Autodesk.Forge.DesignAutomation.Client;
using Autodesk.Forge.DesignAutomation.Model;

namespace Autodesk.Forge.DesignAutomation.Http
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IHealthApiHttp
    {
        /// <summary>
        ///  Gets the health status by Engine or for all Engines (Inventor, AutoCAD ...).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="engine"></param>
        /// <returns>Task of ApiResponse<string></returns>
        
        System.Threading.Tasks.Task<ApiResponse<string>> HealthStatusAsync (string engine);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class HealthApiHttp : IHealthApiHttp
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthApiHttp"/> class
        /// using ForgeService object
        /// </summary>
        /// <param name="service">An instance of ForgeService</param>
        /// <returns></returns>
        public HealthApiHttp(ForgeService service = null, IOptions<Configuration> configuration = null)
        {
            this.Service = service ?? ForgeService.CreateDefault();

            // set BaseAddress from configuration or default
            this.Service.Client.BaseAddress = configuration?.Value.BaseAddress ?? new Configuration().BaseAddress;
        }

         /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the ForgeService</value>
        public ForgeService Service {get; set;}

        /// <summary>
        ///  Gets the health status by Engine or for all Engines (Inventor, AutoCAD ...).
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown when fails to make API call</exception>
        /// <param name="engine"></param>
        /// <returns>Task of ApiResponse<string></returns>
        
        public async System.Threading.Tasks.Task<ApiResponse<string>> HealthStatusAsync (string engine)
        {
            var localVarPath = "/v3/health/{engine}";

            using (var request = new HttpRequestMessage())
            {
                localVarPath = Marshalling.SetPathVariable(localVarPath, "engine", engine); // path parameter

                // Request URI is now ready
                request.RequestUri = new Uri(localVarPath);

                request.Headers.TryAddWithoutValidation("Accept", "application/json");
                



                // tell the underlying pipeline what scope we'd like to use
                request.Properties.Add(ForgeConfiguration.ScopeKey, "code:all");

                // make the HTTP request
                var localVarResponse = await this.Service.Client.SendAsync(request);

                localVarResponse.EnsureSuccessStatusCode();

                return new ApiResponse<string>(localVarResponse, (string)Marshalling.Deserialize(localVarResponse.Content, typeof(string)));

            } // using
        }
    }
}
