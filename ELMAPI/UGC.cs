using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ELMAPI
{
    public class UGC
    {
        #region 获取评论
        /// <summary>
        /// 获取指定店铺的评论
        /// </summary>
        /// <param name="shopId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="offset"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public string getOrderRatesByShopId(string shopId,string startTime,string endTime,int offset,int pageSize)
        {
            Token oToken = new Token();
            string token = oToken.GetToken();

            JObject jparams = new JObject();
            jparams.Add(new JProperty("shopId", shopId));
            jparams.Add(new JProperty("startTime", startTime));
            jparams.Add(new JProperty("endTime", endTime));
            jparams.Add(new JProperty("offset", offset));
            jparams.Add(new JProperty("pageSize", pageSize));

            string body = Common.GetBodyData(jparams, "eleme.ugc.getOrderRatesByShopId", token);

            string strResult = Common.CallWebAPI(Config.apiUrl, "POST", "application/json;charset=utf-8", body);

            return strResult;
         }
        #endregion
    }
}
