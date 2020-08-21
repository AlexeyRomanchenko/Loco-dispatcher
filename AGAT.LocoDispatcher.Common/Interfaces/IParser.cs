using System.Threading.Tasks;

namespace AGAT.LocoDispatcher.Common.Interfaces
{
    public interface IParser
    {
        Task ParseToJson(string jsonString);
    }
}
