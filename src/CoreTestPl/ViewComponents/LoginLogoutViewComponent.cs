using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreTestPl.WievModels
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        public Task<IViewComponentResult> InvokeAsync()
        {            
            return Task.FromResult<IViewComponentResult>(View());
        }
    }
}