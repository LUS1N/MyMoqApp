using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Test
{
    public class AsyncTests
    {


        [Fact]
        public async Task Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public async Task Test2()
        {
            Assert.Equal(1,1);
        }
    }
}
