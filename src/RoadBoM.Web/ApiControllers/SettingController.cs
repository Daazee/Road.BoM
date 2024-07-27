using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadBoM.Web.DataAccess;
using RoadBoM.Web.Models.DTOs.Request;
using RoadBoM.Web.Models.DTOs.Response;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ApiControllerBase
    {

        private readonly IBillCategoryRepository _billCategoryRepository;
        private readonly IBillItemRepository _billItemRepository;
        private readonly IBillItemRateRepository _billItemRateRepository;
        public SettingController(IBillCategoryRepository billCategoryRepository,
            IBillItemRepository billItemRepository, IBillItemRateRepository billItemRateRepository)
        {
            _billCategoryRepository = billCategoryRepository;
            _billItemRepository = billItemRepository;
            _billItemRateRepository = billItemRateRepository;
        }

        [HttpPost]
        [Route("AddBillCategory")]
        public async Task<IApiResponse<bool>> AddBillCategory(AddBillCategoryRequestDTO requestDTO)
        {
            try
            {
                return await HandleApiOperationAsync(async () =>
                {
                    BillCategory category = new BillCategory();
                    BillCategory result = null;
                    category.Code = requestDTO.Code;
                    category.Description = requestDTO.Description;
                    category.Order = requestDTO.Order;
                    category.Status = 1;
                    category.CreatedBy = "admin";
                    category.CreatedOn = DateTime.Now;
                    category.UpdatedBy = "admin";
                    category.UpdatededOn = DateTime.Now;

                    try
                    {
                        result = await _billCategoryRepository.AddItem(category);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    bool output = false;
                    if (result != null)
                    {
                        output = true;
                    }
                    return new DefaultApiResponse<bool>
                    {
                        Object = output
                    };
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("AddBillItem")]
        public async Task<IApiResponse<bool>> AddBillItem(AddBillItemRequestDTO requestDTO)
        {
            try
            {
                return await HandleApiOperationAsync(async () =>
                {
                    BillItem billItem = new BillItem();
                    BillItem result = null;
                    billItem.Code = requestDTO.Code;
                    billItem.Description = requestDTO.Description;
                    billItem.Order = requestDTO.Order;
                    billItem.Unit = requestDTO.Unit;
                    billItem.Status = 1;
                    billItem.CreatedBy = "admin";
                    billItem.CreatedOn = DateTime.Now;
                    billItem.UpdatedBy = "admin";
                    billItem.UpdatededOn = DateTime.Now;

                    try
                    {
                        result = await _billItemRepository.AddItem(billItem);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    bool output = false;
                    if (result != null)
                    {
                        output = true;
                    }
                    return new DefaultApiResponse<bool>
                    {
                        Object = output
                    };
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("AddBillItemRate")]
        public async Task<IApiResponse<bool>> AddBillItemRate(AddBillItemRateRequestDTO requestDTO)
        {
            try
            {
                return await HandleApiOperationAsync(async () =>
                {
                    BillItemRate billItemRate = new BillItemRate();
                    BillItemRate result = null;
                    billItemRate.BillItemId = requestDTO.BillItemId;
                    billItemRate.Amount = requestDTO.Amount;
                    billItemRate.RateType = requestDTO.RateType;
                    billItemRate.Status = 1;
                    billItemRate.CreatedBy = "admin";
                    billItemRate.CreatedOn = DateTime.Now;
                    billItemRate.UpdatedBy = "admin";
                    billItemRate.UpdatededOn = DateTime.Now;

                    try
                    {
                        result = await _billItemRateRepository.AddItem(billItemRate);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    bool output = false;
                    if (result != null)
                    {
                        output = true;
                    }
                    return new DefaultApiResponse<bool>
                    {
                        Object = output
                    };
                });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetBillCategories")]
        public async Task<IApiResponse<List<GetBillCategoryResponseDTO>>> GetBillCategories()
        {
            try
            {
                return await HandleApiOperationAsync(async () =>
                {
                    List<GetBillCategoryResponseDTO> output = new List<GetBillCategoryResponseDTO>();
                    try
                    {
                        var result = await _billCategoryRepository.GetItems();
                        if (result != null)
                        {
                            if (result.Count() > 0)
                            {
                                foreach (var item in result)
                                {
                                    output.Add(new GetBillCategoryResponseDTO
                                    {
                                        Id = item.Id,
                                        Code = item.Code,
                                        Description = item.Description,
                                        Order = item.Order,
                                        CreatedBy = item.CreatedBy,
                                        CreatedOn = item.CreatedOn,
                                        UpdatedBy = item.UpdatedBy,
                                        UpdatededOn = item.UpdatededOn
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    return new DefaultApiResponse<List<GetBillCategoryResponseDTO>>
                    {
                        Object = output
                    };
                });
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
