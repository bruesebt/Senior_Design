using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTheMove.Web.API.Common;

namespace WhatsTheMove.Web.API
{
    public class PlacesAccess : IPlacesAccess
    {
        private readonly IConfiguration _config;

        private string _accessKey;

        public PlacesAccess(IConfiguration config)
        {
            _config = config;
            _accessKey = _config["PlacesKey"];
            ApiHelper.InitializeClient();
        }

        public string AccessKey => _accessKey;
    }
}
