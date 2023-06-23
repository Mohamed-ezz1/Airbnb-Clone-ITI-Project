using Airbnb.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchBarController : ControllerBase
    {
        private readonly ISearchBarManger searchBarManger;
        public SearchBarController(ISearchBarManger _searchBarManger) {


            searchBarManger = _searchBarManger;
        }

        [HttpGet]
        public ActionResult<List<GetNavbarSearchdto>> GetSearchBarData() {


            return searchBarManger.GetSearchBarData();
        }



    }
}
