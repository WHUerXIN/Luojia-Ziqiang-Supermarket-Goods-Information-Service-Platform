using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipaySecurityProdAaBbQueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipaySecurityProdAaBbQueryModel : AopObject
    {
        /// <summary>
        /// 金额
        /// </summary>
        [XmlElement("latitude")]
        public string Latitude { get; set; }
    }
}
