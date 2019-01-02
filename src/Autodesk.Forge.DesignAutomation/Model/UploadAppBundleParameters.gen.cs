/* 
 * Forge Design Automation
 *
 * Generated by [Forge Swagger Codegen](https://git.autodesk.com/forge-ozone/forge-rsdk-codegen)
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Autodesk.Forge.DesignAutomation.Model
{
    /// <summary>
    /// UploadAppBundleParameters
    /// </summary>
    [DataContract]
    public partial class UploadAppBundleParameters 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UploadAppBundleParameters" /> class.
        /// </summary>
        public UploadAppBundleParameters()
        {
        }
        
        /// <summary>
        /// Gets or Sets EndpointURL
        /// </summary>
        [DataMember(Name="endpointURL", EmitDefaultValue=false)]
        public string EndpointURL { get; set; }

        /// <summary>
        /// Gets or Sets FormData
        /// </summary>
        [DataMember(Name="formData", EmitDefaultValue=false)]
        public Dictionary<string, string> FormData { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

}