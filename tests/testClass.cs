using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CompanyWebApi
{
    public class testClass
    {
        [Fact]
        public void PassingAddTest()
        {
            Assert.Equal(4, Add.AddNums(2, 2));
        }
    }
}