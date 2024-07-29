using Microsoft.AspNetCore.Mvc;
using RoadBoM.Web.Models.DTOs.Response;
using RoadBoM.Web.Utility;
using System.Reflection.PortableExecutable;

namespace RoadBoM.Web.Controllers
{
    public class SettingController : Controller
    {
        Dictionary<string, string> headers = new Dictionary<string, string>();

        [HttpGet]
        public async Task<IActionResult> BillCategories()
        {
            return View();

        }
       
        [HttpPost]
        public async Task<IActionResult> PostBillCategories()
        {
            var billCategories = new DefaultApiResponse<List<GetBillCategoryResponseDTO>>();
            try
            {
                int totalRecord = 0;
                //int filterRecord = 0;
                var draw = Request.Form["draw"].FirstOrDefault();
                //var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                //var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                //var searchValue = Request.Form["search[value]"].FirstOrDefault();
                //var start = Request.Form["start"].FirstOrDefault();
                //int pageSize = Convert.ToInt32(Request.Form["length"].FirstOrDefault() ?? "0");
                //int skip = Convert.ToInt32(Request.Form["start"].FirstOrDefault() ?? "0");
                //var searchObject = "";
                //var searchFilters = searchObject.SerializeFromJsonObject();

                try
                {
                    //int pageNo = (start == "0" ? 0 : start.ConvertToIntOrDefault(1) / pageSize.ConvertToIntOrDefault(1)) + 1;
                    //var parameters = new PaginationModel
                    //{
                    //    SearchColumn = "Key",
                    //    SearchValue = searchValue,
                    //    PageNo = pageNo,
                    //    PageSize = pageSize,
                    //    SortColumn = sortColumn,
                    //    SortOrder = sortColumnDirection,
                    //    ExtendedFilters = searchFilters
                    //};
                    string Url = "https://localhost:7177/api/Setting/GetBillCategories";
                    var response = await new ApiRequest(Url).MakeHttpClientRequest(null, ApiRequest.Verbs.GET, headers);

                    if (Convert.ToInt16(response.StatusCode) == 200)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(responseString))
                        {
                            //billCategories = System.Text.Json.JsonSerializer.Deserialize<DefaultApiResponse<List<GetBillItemRateResponseDTO>>>(responseString);
                            billCategories = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultApiResponse<List<GetBillCategoryResponseDTO>>>(responseString);

                        }
                    }


                    //if (businessHoursResponse != null && businessHoursResponse.StatusCode.IsSuccess())
                    //{
                    //    businessHours = businessHoursResponse.ResponseData ?? new List<WaBusinessHour>();
                    //    filterRecord = businessHoursResponse.NoOfRecords ?? 0;
                    //    totalRecord = businessHoursResponse.NoOfRecords ?? 0;
                    //}
                    //else
                    //{
                    //    businessHours = new List<WaBusinessHour>();
                    //}
                }
                catch (Exception ex)
                {
                    //_logger.LogError(ex, $"{StatusCodes.Status500InternalServerError}: {ex.Message}");
                    billCategories = new DefaultApiResponse<List<GetBillCategoryResponseDTO>>();
                }

                var jsonData = new
                {
                    draw,
                    recordsTotal = totalRecord,
                    //recordsFiltered = filterRecord,
                    data = billCategories.Object
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

        [HttpGet]
        public async Task<IActionResult> BillItems()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetBillItems()
        {
            var billItems = new DefaultApiResponse<List<GetBillItemResponseDTO>>();
            try
            {
                int totalRecord = 0;
                //int filterRecord = 0;
                var draw = Request.Form["draw"].FirstOrDefault();
                try
                {
                    string Url = "https://localhost:7177/api/Setting/GetBillItems";
                    var response = await new ApiRequest(Url).MakeHttpClientRequest(null, ApiRequest.Verbs.GET, headers);

                    if (Convert.ToInt16(response.StatusCode) == 200)
                    {
                        string responseString = await response.Content.ReadAsStringAsync();
                        if (!string.IsNullOrEmpty(responseString))
                        {
                            billItems = Newtonsoft.Json.JsonConvert.DeserializeObject<DefaultApiResponse<List<GetBillItemResponseDTO>>>(responseString);

                        }
                    }
                }
                catch (Exception ex)
                {
                    billItems = new DefaultApiResponse<List<GetBillItemResponseDTO>>();
                }

                var jsonData = new
                {
                    draw,
                    recordsTotal = totalRecord,
                    data = billItems?.Object
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
    }
}
