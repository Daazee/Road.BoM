using Microsoft.AspNetCore.Mvc;
using RoadBoM.Web.Models.DTOs.Response;
using RoadBoM.Web.Utility;
using System.Reflection.PortableExecutable;

namespace RoadBoM.Web.Controllers
{
    public class RoadController : Controller
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();
        public IActionResult AllRoads()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostRoads()
        {
            var roads = new DefaultApiResponse<List<GetRoadResponseDTO>>();
            try
            {
                int totalRecord = 0;
                //int filterRecord = 0;
                var draw = Request.Form["draw"].FirstOrDefault();
                try
                {
                    string Url = "https://localhost:7177/api/Road/getroads";
                    var response = await new ApiRequest(Url).MakeHttpClientRequest(null, ApiRequest.Verbs.GET, headers);

                    if (Convert.ToInt16(response.StatusCode) == 200)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(responseString))
                        {
                          roads = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultApiResponse<List<GetRoadResponseDTO>>>(responseString);

                        }
                    }
                }
                catch (Exception ex)
                {
                    roads = new DefaultApiResponse<List<GetRoadResponseDTO>>();
                }

                var jsonData = new
                {
                    draw,
                    recordsTotal = totalRecord,
                    data = roads.Object
                };

                return new JsonResult(jsonData)
                {
                    StatusCode = StatusCodes.Status200OK
                };
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
