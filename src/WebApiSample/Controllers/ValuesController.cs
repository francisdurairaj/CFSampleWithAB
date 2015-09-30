using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using WebApiSample.Models;
using System.Linq;
using WebApiSample.InitializeData;

namespace WebApiSample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet]
        [Route("[action]")]
        public List<Product> GetProducts()
        {
            List<Product> lstp = new List<Product>();
            lstp = InitData.lstProducts;
            return lstp;
        }

        [Route("[action]")]
        public string PostURL(CreateAdd value)
        {
              try
            {
                var id = InitData.lstAdds.Count;
                CreateAdd objAdd = new CreateAdd();
                objAdd.AgeGroup = value.AgeGroup;
                objAdd.AgeGroupRange = value.AgeGroupRange;
                objAdd.ImageURL = "";
                objAdd.Browser = value.Browser;
                objAdd.Device = value.Device;
                objAdd.Gender = value.Gender;
                objAdd.Region = value.Region;
                objAdd.AddDesc = value.AddDesc;
                objAdd.URL = value.URL;
                objAdd.RegionName = value.RegionName;
                objAdd.ID = id + 1;
                InitData.lstAdds.Add(objAdd);

                return ("ok").ToUpper();
            }
            catch
            {
                return ("Error").ToUpper();
            }
        }
        [Route("[action]")]
        public List<CreateAdd> getUrlNames()
        {
            return InitData.lstAdds;
        }
        [Route("[action]/{id}")]
        public string IncrementCounter(int id)
        {
            var Product = InitData.lstProducts.Where(kvp => kvp.ID == id).Select(x => x).ToArray();

            if (Product != null && Product.Length == 1)
            {
                Product[0].Views = Product[0].Views + 1;
            }
            return "OK";
        }

        [Route("[action]/{id}")]
        public JsonResult GetProductsDetails(int id)
        {
            var Product = InitData.lstProducts.Where(kvp => kvp.ID == id).Select(x => x).ToArray();
            return Json(Product);
        }

        [Route("[action]/{id}")]
        public string UpdatePurchased(int id)
        {
            var Product = InitData.lstProducts.Where(kvp => kvp.ID == id).Select(x => x).ToArray();

            if (Product != null && Product.Length == 1)
            {
                Product[0].TotalNoOfPurchases = Product[0].TotalNoOfPurchases + 1;
            }
            return "ok";
        }


        [Route("[action]")]
        public JsonResult AddsViewHistory(AddsHistory value)
        {
            AddsHistory objAdd = new AddsHistory();
            objAdd.AgeGroup = value.AgeGroup;
            objAdd.Gender = value.Gender;
            objAdd.Region = value.Region;
            objAdd.Views = value.Views;
            objAdd.ID = value.ID;
            InitData.lstAddsHistory.Add(objAdd);
            return Json("ok");
        }

        [Route("[action]/{id}")]
        public JsonResult getRegionAds(int id)
        {
            //Need to filter by AdID
            RegionMap rm = new RegionMap();
            List<AddsHistory> Ad = InitData.lstAddsHistory.Where(kvp => kvp.ID == id).ToList<AddsHistory>();
            //rm.AdId = InitData.lstAdds[0].AdId;
            rm.region = Ad[0].Region;
            rm.hits = Ad[0].Views;
            return Json(rm);
        }

        [Route("[action]/{id}")]
        public JsonResult getAgeGroup(int id, string Region)
        {
            //Filter by both ADID / Region
            AgeGrouping ag = new AgeGrouping();
            List<AddsHistory> Ad = InitData.lstAddsHistory.Where(kvp => kvp.Region == Region).ToList<AddsHistory>();
            //rm.AdId = InitData.lstAdds[0].AgeGroup;
            ag.Region = Ad[0].Region;
            ag.Under_5_Years = Ad.Where(kvp => kvp.AgeGroup == "Under 5 Years").ToList<AddsHistory>()[0].Views;
            ag._5_to_13Years = Ad.Where(kvp => kvp.AgeGroup == "5 to 13Years").ToList<AddsHistory>()[0].Views;
            ag._14_to_17_Years = Ad.Where(kvp => kvp.AgeGroup == "14 to 17 Years").ToList<AddsHistory>()[0].Views;
            ag._18_to_24_Years = Ad.Where(kvp => kvp.AgeGroup == "_18 to 24 Years").ToList<AddsHistory>()[0].Views;
            ag._25_to_44_Years = Ad.Where(kvp => kvp.AgeGroup == "25 to 44 Years").ToList<AddsHistory>()[0].Views;
            ag._45_to_64_Years = Ad.Where(kvp => kvp.AgeGroup == "45 to 64 Years").ToList<AddsHistory>()[0].Views;
            ag._65_Years_and_Over = Ad.Where(kvp => kvp.AgeGroup == "65 Years and Over").ToList<AddsHistory>()[0].Views;
            return Json(ag);
        }

        [Route("[action]/{id}")]
        public JsonResult getRealTime(string Region)
        {
            Spline rt = new Spline();
            List<AddsHistory> ahl = InitData.lstAddsHistory.Where(kvp => kvp.Region == Region).ToList<AddsHistory>();
            rt.AdsHistoryList = ahl;

            return Json(rt.AdsHistoryList);
        }

    }


}










