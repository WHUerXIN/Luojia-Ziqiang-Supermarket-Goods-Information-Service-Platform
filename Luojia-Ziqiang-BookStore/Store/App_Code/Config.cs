using System;
using System.Collections.Generic;
using System.IO;
//using System.Linq;
using System.Web;

/// <summary>
/// 基础配置类
/// </summary>


    public class Config
    {
        //public static string alipay_public_key = @"此处填写支付宝公钥";


        ////这里要配置没有经过的原始私钥

        ////开发者私钥
        //public static string merchant_private_key = @"此处填写开发者私钥";

        ////开发者公钥
        //public static string merchant_public_key = @"此处填写开发者公钥";

        ////应用ID
        //public static string appId = "此处填写应用APPID";

        ////合作伙伴ID：partnerID
        //public static string pid = "此处填写账号PID（partner id）";

        ////支付宝网关
        //public static string serverUrl = "https://openapi.alipay.com/gateway.do";
        //public static string mapiUrl = "https://mapi.alipay.com/gateway.do";
        //public static string monitorUrl = "http://mcloudmonitor.com/gateway.do";

        ////编码，无需修改
        //public static string charset = "utf-8";
        ////签名类型，支持RSA2（推荐！）、RSA
        ////public static string sign_type = "RSA2";
        //public static string sign_type = "RSA2";
        ////版本号，无需修改
        //public static string version = "1.0";




        public static string alipay_public_key = @"MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAucMM4f/cIP3vP5vgA8xnb5rNJ+DbRpzLLFc7cJy+n5TYR3icemqnH2H6weB+LUsGJvw505HFKOOk6kv9wXfZJvedh4uIiLA78G1DnG0WSfq2uVdPM6a0CQRCfhSu79n79cW/hAy3FtItZ8dZBLqehR9xCWd9Uauwiq6VhKx4v5Wi44W2k9Avmx7AuuIA94YkI89cbW2txlu+oA/oES3yY2R8WrYEvwFFRmjee0uXtSsSkv/5GwWYkcK8Aq09d0XjB0MfAF28FqHFfOjtmEI1+kSmcG7QjRLi3V/Sn68cZ34X98fTFznFFZjFbhVCWy06/+N0PnYn/9QC7cLLNKGHCwIDAQAB";

        //这里要配置没有经过的原始私钥

        //开发者私钥
        public static string merchant_private_key = @"MIIEpgIBAAKCAQEAucMM4f/cIP3vP5vgA8xnb5rNJ+DbRpzLLFc7cJy+n5TYR3icemqnH2H6weB+LUsGJvw505HFKOOk6kv9wXfZJvedh4uIiLA78G1DnG0WSfq2uVdPM6a0CQRCfhSu79n79cW/hAy3FtItZ8dZBLqehR9xCWd9Uauwiq6VhKx4v5Wi44W2k9Avmx7AuuIA94YkI89cbW2txlu+oA/oES3yY2R8WrYEvwFFRmjee0uXtSsSkv/5GwWYkcK8Aq09d0XjB0MfAF28FqHFfOjtmEI1+kSmcG7QjRLi3V/Sn68cZ34X98fTFznFFZjFbhVCWy06/+N0PnYn/9QC7cLLNKGHCwIDAQABAoIBAQCdue3QXw0rvjFMky+MShxxeMFFYPkOZcdlaNQBdDWvDhTt6o0CrFgmn2zo/ZJlJtSceYEoEReU9mVqwwc9JGPvYEQTePh/BxR9umi0AzPvsL9Bc86+DofDOCi1IR7AbRgwwK0ylBFJgUAoY+1DxKkgY2f5EjQoCl2mA0LVGhSUpiXzYlUqRluhB7qfe+/uJb3IN9rJkVYv8W2QyHpA484DOCK/pJzI2F0Ms+l9ZoQnL+uNgZ7zti4r+JVcfxNcg185XSATmoA1QRHkOmeyyZcnPeWG7VCoQtrzrnagW07IEGV7LR8nSJ1qBBi9puHQhie8ndkG8XDgnys0aOQ9lD1hAoGBAPgkRJxmbfBGhPqIT3SpM/GNijaz3Kgyp/rQrnWQkabt1OBQf/OfPTjCV3bwXvZmu65ppYUZ9S9LjsWLxmJUQmcIi5tiVlb6Amz+rMmOUz7Xj0MB1vAvrF5vCBFT6TyumG3M02pPOZo2pki2fzOTCoslZXEZ90drA2RHVSSzNeXpAoGBAL+lDsUoNK8zBRi067VqbCnIJCzsN7CxEH66VBnc117QPtyMnGrFqgUKLXnUCR5XJe1Jd/x+w2PYTXGF7M9Jqenjeu/rTjwHxriEp+dJxf5WDftDciBljge1brzgL4ra3KP+8YciMKwKhocywLT5LVTQpihwmrO1KAMGpvONf8jTAoGBALG4eBN0ISVHvJIa8p1hWjyU3PrU0yL8NOckcu7svgTKrf6CaUG5OQXf2vjqq3jal20RaWTs9HgNK5I8y7c9FdnpeuOtCJ1+riIWPPaWovSNOqQJO0IHQvLXnvWaHaBChBWP75NibqUOowXM/0mW9KQ4AnGA4WQbNvCpTkfcuquRAoGBAK9Xm43z3VA3BAC497hCqLgJsF+RuNpnBsqMPIp1LnBHZFxyImLme0qlJzqCL92cqszSHX/dk3P04dZuTF7T7Sxbv41n42q1SrJkXSMWspqjraMo8HCHuk1/SNRy4czPtnQtvFqBg7rE3pUwcHSkTz98r6nsbP7jTrqGCZZo7nOVAoGBAK4F32edCspGP40DBFxnKwgl5QA7xE/CmbCV00AAuavs/vTi6hx1cfrH6hfe+4iAdMtXl9KPBArV3A9qaNknFgNUcuCPdeTIG3j6ojIvl9otPzksjwsuQHavmqZwsaVjX+q6wIUOolO2Vgz+mfgkgA0RC/++CIAEYhVqHe570oyE";

        //开发者公钥
         public static string merchant_public_key;

        //应用ID
        public static string appId = "2021000116662923";


        //合作伙伴ID：partnerID
        public static string pid = "此处填写账号PID（partner id）";


        //支付宝网关
        //public static string serverUrl = "https://openapi.alipay.com/gateway.do";//正式开发的支付宝网关：
        public static string serverUrl = "https://openapi.alipaydev.com/gateway.do"; //沙箱版的支付宝网关：
        public static string mapiUrl = "https://mapi.alipay.com/gateway.do";
        public static string monitorUrl = "http://mcloudmonitor.com/gateway.do";

        //编码，无需修改
        public static string charset = "utf-8";
        //签名类型，支持RSA2（推荐！）、RSA
        //public static string sign_type = "RSA2";
        public static string sign_type = "RSA2";
        //版本号，无需修改
        public static string version = "1.0";


        /// <summary>
        /// 公钥文件类型转换成纯文本类型
        /// </summary>
        /// <returns>过滤后的字符串类型公钥</returns>
        public static string getMerchantPublicKeyStr()
        {
            StreamReader sr = new StreamReader(merchant_public_key);
            string pubkey = sr.ReadToEnd();
            sr.Close();
            if (pubkey != null)
            {
                pubkey = pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("\r", "");
                pubkey = pubkey.Replace("\n", "");
            }
            return pubkey;
        }

        /// <summary>
        /// 私钥文件类型转换成纯文本类型
        /// </summary>
        /// <returns>过滤后的字符串类型私钥</returns>
        public static string getMerchantPriveteKeyStr()
        {
            StreamReader sr = new StreamReader(merchant_private_key);
            string pubkey = sr.ReadToEnd();
            sr.Close();
            if (pubkey != null)
            {
                pubkey = pubkey.Replace("-----BEGIN PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("-----END PUBLIC KEY-----", "");
                pubkey = pubkey.Replace("\r", "");
                pubkey = pubkey.Replace("\n", "");
            }
            return pubkey;
        }

    }


