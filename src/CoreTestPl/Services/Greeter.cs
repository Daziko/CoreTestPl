using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTestPl.Services
{
    public class Greeter : IGreeter
    {
        private string greed;

        public Greeter(IConfiguration configuration)
        {
            greed = configuration["Greeting"];
        }
        public string GetGreeting()
        {
            return greed;
        }
    }
}
