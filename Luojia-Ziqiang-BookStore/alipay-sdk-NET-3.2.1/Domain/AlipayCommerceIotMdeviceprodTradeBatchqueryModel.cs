using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayCommerceIotMdeviceprodTradeBatchqueryModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayCommerceIotMdeviceprodTradeBatchqueryModel : AopObject
    {
        /// <summary>
        /// 交易流水号
        /// </summary>
        [XmlElement("trade_no")]
        public string TradeNo { get; set; }
    }
}
