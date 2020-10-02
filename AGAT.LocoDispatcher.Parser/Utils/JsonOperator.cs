using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Parser.Utils.Factories;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils
{
    public class JsonOperator : IParser
    {
        private JsonFactory _jsonFactory;
        private ProviderFactory _providerFactory;
        public JsonOperator()
        {
            DataManager dataManager = new DataManager();
            _jsonFactory = new JsonFactory();
            _providerFactory = new ProviderFactory(dataManager);
        }
        public void ParseToJson(string jsonData)
        {
            try
            {
                if (string.IsNullOrEmpty(jsonData?.Trim()))
                {
                    throw new ArgumentNullException("json data is not valid, maybe it is null");
                }

                dynamic json = JsonConvert.DeserializeObject<dynamic>(jsonData);
                dynamic jsonArray = json?.response?.events;
                if (jsonArray == null)
                {
                    throw new ArithmeticException("json couldn't be handled");
                }
                foreach (var jsonObject in jsonArray)
                {
                    IEvent _event = _jsonFactory.GetEventFactory(jsonObject);
                    if (_event == null)
                    {
                        throw new ArgumentException("event is not valid");
                    }
                    IProvider provider = _providerFactory.GetProviderFactory(_event);
                    if (provider == null)
                    {
                        throw new ArgumentException("provider is not valid");
                    }
                    provider.Create(_event);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
    }
}