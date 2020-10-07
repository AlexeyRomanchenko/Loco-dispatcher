using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Parser.Utils
{
    public class DriveOperator
    {
        private JsonOperator _operator;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public DriveOperator()
        {
            _operator = new JsonOperator();
        }
        public string GetJSONFromFile(string pathToFile)
        {
            try
            {
                if (string.IsNullOrEmpty(pathToFile?.Trim()))
                {
                    throw new ArgumentNullException("Path is not valid");
                }
                using (StreamReader reader = new StreamReader(pathToFile, System.Text.Encoding.Unicode))
                {
                    return reader.ReadToEnd();
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

        public void GetFilesFromDirectoryAndParse(string path, string errorPath)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    string filePath = Directory.GetFiles(path).FirstOrDefault(name => name != "Thumbs.db"); ;
                    if (filePath != null)
                    {
                        try
                        {
                            FileInfo file = new FileInfo(filePath);
                            string jsonData = GetJSONFromFile(filePath);
                            logger.Info($"{DateTime.Now} | GETTING FILE | {filePath} ");
                            _operator.ParseToJson(jsonData);
                            logger.Info($"{DateTime.Now} | AFTER INSERTING FILE | {filePath} ");
                            file.Delete();
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                FileInfo file = new FileInfo(filePath);
                                if (file.Exists)
                                {
                                    file.MoveTo($"{errorPath}{file.Name}");
                                }
                                //file.Delete();

                            }
                            catch (Exception)
                            {
                                throw;
                            }


                            logger.Error($"{DateTime.Now} | ERROR SOURCE {filePath} | {ex.Source}");
                            logger.Error($"{DateTime.Now} | ERROR METHOD | {ex.TargetSite}");
                            logger.Error($"{DateTime.Now} | ERROR | {ex.Message}");
                        }

                    }

                    //}
                }
                else
                {
                    logger.Error($"{DateTime.Now} | ERROR | directory doesn't exist");
                    throw new ArgumentNullException("directory doesn't exist");
                }
            }

            catch (Exception ex)
            {
                logger.Error($"{DateTime.Now} | LAST ERROR SOURCE | {ex.Source}");
                logger.Error($"{DateTime.Now} | LAST ERROR METHOD | {ex.TargetSite}");
                logger.Error($"{DateTime.Now} | LAST ERROR | {ex.Message}");
            }

        }
    }
}