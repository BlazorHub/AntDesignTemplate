using System.Threading.Tasks;
using AntDesignTemplate.Shared.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace AntDesignTemplate.Client.Services
{
    public class LoginService : ILoginService
    {
        private readonly NavigationManager _navigation;

        private readonly SignOutSessionStateManager _signOutManager;

        public LoginService(NavigationManager navigation, SignOutSessionStateManager signOutManager)
        {
            _navigation = navigation;
            _signOutManager = signOutManager;
        }

        public async Task SignOut()
        {
            await _signOutManager.SetSignOutState();
            _navigation.NavigateTo("authentication/logout");
        }
    }
}