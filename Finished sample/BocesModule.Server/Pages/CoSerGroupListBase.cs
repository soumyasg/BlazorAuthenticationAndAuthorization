using BocesModule.Server.Services;
using BocesModule.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BocesModule.Server.Pages
{
    public class CoSerGroupListBase : ComponentBase
    {
        [CascadingParameter]
        Task<AuthenticationState> authenticationStateTask { get; set; }

        [Inject]
        public ICoSerGroupDataService CoSerGroupDataService { get; set; }

        public List<CoSerGroup> CoSerGroups { get; set; }

        // protected AddEmployeeDialog AddEmployeeDialog { get; set; }

        protected override async Task OnInitializedAsync()
        {
           CoSerGroups = (await CoSerGroupDataService.GetAllCoSerGroups()).ToList();
        }

        protected async Task QuickAddCoSerGroup()
        {

        }
    }
}
