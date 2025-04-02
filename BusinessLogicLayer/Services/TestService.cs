using BusinessLogicLayer.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class TestService : ITestService
    {
        public void Run()
        {
            Console.WriteLine("TestService is running");
        }
    }
}
