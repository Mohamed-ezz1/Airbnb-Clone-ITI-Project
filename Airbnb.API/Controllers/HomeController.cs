using Airbnb.BL;
using Airbnb.DAl;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;

namespace Airbnb.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;
    private readonly IHomeManager _homeManager;
    //public static List<Query> me = new List<Query>();
    public HomeController(ILogger<HomeController> logger, IHomeManager homeManager)
    {
        _logger = logger;
        _homeManager = homeManager;
    }

    #region GetAll Properties

    [HttpGet]
    [Route("Properties")]
    public ActionResult<List<HomePagePropertyDto>> GetAllPropsAsDtos()
    {
        List<HomePagePropertyDto> homeProps = _homeManager.GetAllPropsAsDtos().ToList();
        return homeProps;
    }

    #endregion


    #region GetAll Categories

    [HttpGet]
    [Route("Categories")]
    public ActionResult<List<HomePageCategoryDto>> GetAllCatsAsDtos()
    {
        List<HomePageCategoryDto> homeCategs = _homeManager.GetAllCatsAsDtos().ToList();
        return homeCategs;
    }

    #endregion


    [HttpPost]
    [Route("Properties/filter")]
    public ActionResult<IEnumerable<HomePagePropertyDto>> GetAllPropsAsDtos(Query Search)
    {

        if (Search.CatogreyId == null && Search.CityId == null && Search.CatogreyId == null && Search.NumberOfGuests ==null || Search==null)
        {
         return   RedirectToAction(nameof(GetAllPropsAsDtos));
        }
        else
        {
           var Filter =  _homeManager.FilteredProperties(Search).ToList();
            if (Filter == null|| Filter.Count()==0)
            {
                return NotFound();
            }
            else
            {
                return Filter;
            }

        }

    }



}
