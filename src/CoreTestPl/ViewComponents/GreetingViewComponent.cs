using CoreTestPl.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreTestPl.WievModels
{
    public class GreetingViewComponent : ViewComponent
    {
        readonly IGreeter greeder;

        public GreetingViewComponent(IGreeter greeder)
        {
            this.greeder = greeder;
        }
        public Task<IViewComponentResult> InvokeAsync()
        {
            var model = greeder.GetGreeting();
            return Task.FromResult<IViewComponentResult>(View("Default", model));
        }
    }
}
