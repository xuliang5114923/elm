using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ELMAPI
{
    public class ShopService
    {
        public string getShop(long shopId)
        {
            Token oToken = new Token();
            string token = oToken.GetToken();

            JObject jparams = new JObject();
            jparams.Add(new JProperty("shopId", shopId));

            string body = Common.GetBodyData(jparams, "eleme.shop.getShop", token);

            string strResult = Common.CallWebAPI(Config.apiUrl, "POST", "application/json;charset=utf-8", body);

            return strResult;
        }

        public string updateShop(long shopId,Model.ShopProperties shopProperties)
        {
            Token oToken = new Token();
            string token = oToken.GetToken();

            JObject jparams = new JObject();
            jparams.Add(new JProperty("shopId", shopId));
            JObject jproperties = new JObject();

            Type type = shopProperties.GetType();
            System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();

            foreach (System.Reflection.PropertyInfo item in propertyInfos)
            {
                if (item.GetValue(shopProperties, null) != null)
                {
                    jproperties.Add(new JProperty(item.Name, item.GetValue(shopProperties, null)));
                }
            }
            jparams.Add(new JProperty("properties", jproperties));

            string body = Common.GetBodyData(jparams, "eleme.shop.updateShop", token);

            string strResult = Common.CallWebAPI(Config.apiUrl, "POST", "application/json;charset=utf-8", body);

            return strResult;
        }
    }
}
