using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayOpenMiniInnerbaseinfoQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayOpenMiniInnerbaseinfoQueryModel : AopObject
    {
        /// <summary>
        /// 小程序ID
        /// </summary>
        [XmlElement("mini_app_id")]
        public string MiniAppId { get; set; }
    }
}
