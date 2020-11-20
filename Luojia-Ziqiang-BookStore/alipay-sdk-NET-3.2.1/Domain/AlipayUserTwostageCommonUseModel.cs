using System;
using System.Xml.Serialization;

namespace Aop.Api.Domain
{
    /// <summary>
    /// AlipayUserTwostageCommonUseModel Data Structure.
    /// </summary>
    [Serializable]
    public class AlipayUserTwostageCommonUseModel : AopObject
    {
        /// <summary>
        /// 商户扫描用户的付款码值。
        /// </summary>
        [XmlElement("dynamic_id")]
        public string DynamicId { get; set; }

        /// <summary>
        /// 商家进行二阶段支付的PID信息。
        /// </summary>
        [XmlElement("pay_pid")]
        public string PayPid { get; set; }

        /// <summary>
        /// 业务场景唯一编号，用于标识这笔请求，每次调用请勿使用相同的sence_no，每笔请求的sence_no必须不一样，支付时传递的DYNAMIC_TOKEN_OUT_BIZ_NO必须与调用开放平台传递的sence_no保持一致。
        /// </summary>
        [XmlElement("sence_no")]
        public string SenceNo { get; set; }
    }
}
