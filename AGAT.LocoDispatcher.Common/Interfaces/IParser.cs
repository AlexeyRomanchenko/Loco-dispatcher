using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces
{
    public interface IParser
    {
        void ParseToJson(string jsonString);
    }
}
