using System;
using System.Collections.Generic;
using System.Text;

namespace TehranEnergyApiClient.DomainModels.Models
{

    public class TokenResponseModel
    {
        public string TimeStamp { get; set; }
        public int status { get; set; }
        public string SessionKey { get; set; }
        public string message { get; set; }
        public TokenInfoData data { get; set; }
        public object error { get; set; }
    }

    public class TokenInfoData
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public DateTime expireDate { get; set; }
    }


    public class TokenCredential
    {
        public string username { get; set; }
        public string password { get; set; }
    }

}
