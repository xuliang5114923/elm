using System;
using System.Collections.Generic;
using System.Text;

namespace ELMAPI.Model
{
    public class ShopProperties
    {
        public string addressText { get; set; }
        public string geo { get; set; }
        public string agentFee { get; set; }
        public string closeDescription { get; set; }
        public string deliverDescription { get; set; }
        public string deliverGeoJson { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int isBookable { get; set; }
        public string openTime { get; set; }
        public string phone { get; set; }
        public string promotionInfo { get; set; }
        public string logoImageHash { get; set; }
        public int invoice { get; set; }
        public int invoiceMinAmount { get; set; }
        public int noAgentFeeTotal { get; set; }
        public int isOpen { get; set; }
        public double packingFee { get; set; }
        public string openId { get; set; }
    }
}
