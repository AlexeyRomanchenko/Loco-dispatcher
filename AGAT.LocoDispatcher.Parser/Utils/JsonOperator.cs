using AGAT.LocoDispatcher.Common.Interfaces;
using AGAT.LocoDispatcher.Parser.Models;
using AGAT.LocoDispatcher.Parser.Utils.Factories;
using AGAT.LocoDispatcher.Parser.Utils.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace AGAT.LocoDispatcher.Parser.Utils
{
    public class JsonOperator : IParser
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
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
                logger.Info($"{DateTime.Now} | DESERIALIZED JSON");
                if (jsonArray == null)
                {
                    throw new ArithmeticException($"json couldn't be handled {json?.response}");
                }
                
                try
                {
                    
                    foreach (var jsonEvent in jsonArray)
                    {
                        IEvent locoEvent = _jsonFactory.GetEventFactory(jsonEvent);
                        _jsonFactory.SetEventManagerFactory(locoEvent);
                    }
                    EventManager events = _jsonFactory.GetEvents();
                    foreach (PropertyInfo prop in typeof(EventManager).GetProperties())
                    {
                        IProvider provider = _providerFactory.GetProviderFactory(prop.Name);
                        IEnumerable<IEvent> _event = _providerFactory.GetEventsFactory(prop.Name, events);
                        provider.Create(_event);
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                //foreach (var jsonObject in jsonArray)
                //{
                //    logger.Info($"{DateTime.Now} | foreach statement JSON");
                //    IEvent _event = _jsonFactory.GetEventFactory(jsonObject);
                //    if (_event == null)
                //    {
                //        throw new ArgumentException("event is not valid");
                //    }
                //    IProvider provider = _providerFactory.GetProviderFactory(_event);
                //    if (provider == null)
                //    {
                //        throw new ArgumentException("provider is not valid");
                //    }
                //    provider.Create(_event);
                //}
            }
            catch (Exception)
            {
                throw;
            }
          
        }
    }
}