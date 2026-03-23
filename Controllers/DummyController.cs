using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MondayFunday.Services.Interfaces;

namespace MondayFunday.Controllers
{
    [Route("api/dummyshit")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly IDummyInterface dummyService;

        public DummyController(IDummyInterface _dummyInterface)
        {
            dummyService = _dummyInterface;
        }

        [HttpGet]
        public string GetDummyData()
        {
            return dummyService.GetData();
        }
    }
}
