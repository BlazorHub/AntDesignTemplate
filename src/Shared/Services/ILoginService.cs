using System.Threading.Tasks;

namespace AntDesignTemplate.Shared.Services
{
    public interface ILoginService
    {
        Task SignOut();
    }
}