using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoadBoM.Web.Models.DTOs.Request;
using RoadBoM.Web.Models.DTOs.Response;
using RoadBoM.Web.Models.Entities;
using RoadBoM.Web.Repository;

namespace RoadBoM.Web.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadController : ApiControllerBase
    {

        private readonly IRoadRepository _roadRepository;

        public RoadController(IRoadRepository roadRepository)
        {
            _roadRepository = roadRepository;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IApiResponse<bool>> Post(CreateRoadRequestDTO requestDTO)
        {
            try
            {

                return await HandleApiOperationAsync(async () =>
                {
                    Road road = new Road();
                    road.Name = requestDTO.Name;
                    road.Location = requestDTO.Location;
                    road.Length = requestDTO.Length;

                    road.Width = requestDTO.Width;
                    road.Row = requestDTO.Row;
                    road.Poles = requestDTO.Poles;
                    road.Type = requestDTO.Type;
                    road.Culvert = requestDTO.Culvert;
                    road.Outfall = requestDTO.Outfall;
                    road.Status = 1;
                    road.CreatedBy = "admin";
                    road.CreatedOn = DateTime.Now;
                    road.UpdatedBy = "admin";
                    road.UpdatededOn = DateTime.Now;
                    Road result = null;
                    try
                    {
                        result = await _roadRepository.AddItem(road);
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
        [Route("GetRoads")]
        public async Task<IApiResponse<List<GetRoadResponseDTO>>> GetRoads()
        {
            try
            {

                return await HandleApiOperationAsync(async () =>
                {
                    List<GetRoadResponseDTO> output = new List<GetRoadResponseDTO>();
                    try
                    {
                        var result = await _roadRepository.GetItems();
                        if (result != null)
                        {
                            if (result.Count() > 0)
                            {
                                foreach (var item in result)
                                {
                                    output.Add(new GetRoadResponseDTO
                                    {
                                        Id = item.Id,
                                        Name = item.Name,
                                        Location = item.Location,
                                        Length = item.Length,
                                        Width = item.Width,
                                        Culvert = item.Culvert,
                                        Outfall = item.Outfall,
                                        Poles = item.Poles,
                                        Row = item.Row,
                                        Status = item.Status,
                                        Type = item.Type,
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

                    return new DefaultApiResponse<List<GetRoadResponseDTO>>
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
