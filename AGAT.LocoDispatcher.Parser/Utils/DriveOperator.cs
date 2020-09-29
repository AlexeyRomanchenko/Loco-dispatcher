using System;
using System.IO;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Parser.Utils
{
    public class DriveOperator
    {
        private JsonOperator _json;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DriveOperator()
        {
            _json = new JsonOperator();
        }
        public string GetJSONFromFile(string pathToFile)
        {
            try
            {
                if (string.IsNullOrEmpty(pathToFile?.Trim()))
                {
                    throw new ArgumentNullException("Path is not valid");
                }
                using (StreamReader reader = new StreamReader(pathToFile))
                {
                    string json = reader.ReadToEnd();
                    return json;
                }
            }
            catch (FileNotFoundException ex)
            {
                
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetFilesFromDirectoryAndParse(string path)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    string[] files = Directory.GetFiles(path);
                    foreach (var filePath in files)
                    {
                        try
                        {
                            FileInfo file = new FileInfo(filePath);
                            string json = GetJSONFromFile(filePath);
                            _json.ParseToJson(json);
                            file.Delete();
                        }
                        catch (Exception ex)
                        {
                            logger.Error($"{DateTime.Now} | ERROR | {ex.Message}");
                            throw ex;
                        }

                    }
                }
                else
                {
                    logger.Error($"{DateTime.Now} | ERROR | directory doesn't exist");
                    throw new ArgumentNullException("directory doesn't exist");
                }
            }
            catch (Exception ex)
            {
                logger.Error($"{DateTime.Now} | ERROR | {ex.Message}");
                throw ex;
            }

        }
    }
}