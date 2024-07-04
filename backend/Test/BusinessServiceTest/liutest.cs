using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServiceTest
{
    [TestClass]
    public class liutest
    {
        [TestMethod]
        public void TestStr()
        {
            string str1 = "12,23,32,45";
            string str2 = "2,4";
            var result = str1.Contains(str2);
            Console.WriteLine(result);
        }
    }
}
