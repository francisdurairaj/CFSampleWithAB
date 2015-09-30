using WebApiSample.Controllers;
using WebApiSample.InitializeData;
using WebApiSample.Models;
using Xunit;
namespace CFSampleWithAB.XUnit
{
   
    public class XunitTestCase1
    {       
        [Fact]
        public void CreateAdd()
        {
            string result = "";
            ValuesController obj = new ValuesController();

            CreateAdd objAdd5 = new CreateAdd();
            objAdd5.ID = 5;
            objAdd5.AgeGroup = "45T65";
            objAdd5.AgeGroupRange = "45 To 64 Years";
            objAdd5.Browser = "IE";
            objAdd5.Device = "Android";
            objAdd5.Gender = "M";
            objAdd5.Region = "KS";
            objAdd5.RegionName = "Kansas";
            objAdd5.URL = "Product.html&AgeGroup=" + objAdd5.AgeGroup + "&Gender=" + objAdd5.Gender + "&Region=" + objAdd5.Region + "&Device=" + objAdd5.Device + "&Browser=" + objAdd5.Browser;
            objAdd5.ImageURL = "Images/16_Black.jpeg";

            result = obj.PostURL(objAdd5).ToString();
            Assert.Equal("Error", result);
        }
        [Fact]
        public void CreateAddPass()
        {
            string result = "";
            ValuesController obj = new ValuesController();
            InitData.intialize();
            CreateAdd objAdd5 = new CreateAdd();
            objAdd5.ID = 5;
            objAdd5.AgeGroup = "45T65";
            objAdd5.AgeGroupRange = "45 To 64 Years";
            objAdd5.Browser = "IE";
            objAdd5.Device = "Android";
            objAdd5.Gender = "M";
            objAdd5.Region = "KS";
            objAdd5.RegionName = "Kansas";
            objAdd5.URL = "Product.html&AgeGroup=" + objAdd5.AgeGroup + "&Gender=" + objAdd5.Gender + "&Region=" + objAdd5.Region + "&Device=" + objAdd5.Device + "&Browser=" + objAdd5.Browser;
            objAdd5.ImageURL = "Images/16_Black.jpeg";

            result = obj.PostURL(objAdd5).ToString();
            Assert.Equal("OK", result);
        }
        [Fact]
        public void GetAdd()
        {            
            ValuesController obj = new ValuesController();
            InitData.intialize();
            Assert.NotNull(obj.getUrlNames());
        }
        [Fact]
        public void GetAddFail()
        {           
            ValuesController obj = new ValuesController();

            Assert.Null(obj.getUrlNames());
        }
        public void getProducts()
        {           
            ValuesController obj = new ValuesController();

            Assert.NotNull(obj.GetProducts());
        }
        public void getRegionAds()
        {
            ValuesController obj = new ValuesController();
            InitData.intialize();
            Assert.NotNull(obj.GetProductsDetails(1));
        }


    }
}
