using Microsoft.JSInterop;

namespace WebBlazor.Services
{
    public class FirebaseAuthService
    {
        private readonly IJSRuntime _jsRuntime;
        private const string UserIdKey = "agoraUser";
        public event Action OnChangeLogin;

        public FirebaseAuthService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<string> SignInWithEmailPassword(string email, string password)
        {
            var userid = await _jsRuntime.InvokeAsync<string>("firebaseAuth.signInWithEmailPassword", email, password);
            if (userid != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userid);
                OnChangeLogin?.Invoke();
            }
            return userid;
        }

        public async Task<string> createUserWithEmailAndPassword(string email, string password, string displayName)
        {
            var userId = await _jsRuntime.InvokeAsync<string>("firebaseAuth.createUserWithEmailAndPassword", email, password, displayName);
            if (userId != null)
            {
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", UserIdKey, userId);
                OnChangeLogin?.Invoke();
            }
            return userId;
        }

        public async Task SignOut()
        {
            await _jsRuntime.InvokeVoidAsync("firebaseAuth.signOut");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", UserIdKey);
            OnChangeLogin?.Invoke();
        }

        public async Task<string> GetUserId()
        {
            return await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", UserIdKey);
        }

        public async Task<bool> IsUserAuthenticated()
        {
            var userId = await GetUserId();
            return !string.IsNullOrEmpty(userId);
        }
    }
}
