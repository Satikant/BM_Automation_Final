using System;
using NUnit.Framework;


using CFM_PARALLEL.PageObject.API.Ace;

namespace CFM_PARALLEL.Tests.Ace_APITest
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    [Category("Ace_API")]

    public class API_TestClass
    {
        [Test]
        public void AceAPI()
        {
            try
            {
                Api_OutputExcelReading.AceAPImethod("D:\\CFM-RunTimeFiles\\CFM-APIoutput\\ApiOutput.csv", "ApiOutput", 2, 1);
                //throw new Exception();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }
        }
    }
}