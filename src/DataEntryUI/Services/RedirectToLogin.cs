using System;
using Microsoft.AspNetCore.Components;

namespace DataEntryUI.Services
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager? NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            NavigationManager!.NavigateTo($"login?returnUrl={Uri.EscapeDataString(NavigationManager.Uri)}");
        }
    }
}