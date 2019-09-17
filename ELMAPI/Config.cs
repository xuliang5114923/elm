using System;
using System.Collections.Generic;
using System.Text;

namespace ELMAPI
{
    public class Config
    {
        /// <summary>
        /// 沙箱环境：https://open-api-sandbox.shop.ele.me/authorize
        /// 正式环境：https://open-api.shop.ele.me/authorize
        /// </summary>
        public static string authorizeUrl = "https://open-api-sandbox.shop.ele.me/authorize";
        /// <summary>
        /// 沙箱环境：https://open-api-sandbox.shop.ele.me/token
        /// 正式环境：https://open-api.shop.ele.me/token
        /// </summary>
        public static string tokenUrl = "https://open-api-sandbox.shop.ele.me/token";

        /// <summary>
        /// 沙箱环境:https://open-api-sandbox.shop.ele.me/api/v1/
        /// 正式环境:https://open-api.shop.ele.me/api/v1/
        /// </summary>
        public static string apiUrl = "https://open-api-sandbox.shop.ele.me/api/v1/";

        public static string app_key = "";
        public static string secret = "";
    }
}
