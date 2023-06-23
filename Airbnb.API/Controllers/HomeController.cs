using Airbnb.BL;
using Airbnb.DAl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airbnb.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{

    private readonly ILogger<HomeController> _logger;
    private readonly IHomeManager _homeManager;

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


    #region Get Category By ID

    [HttpPost]
    [Route("id")]

    public ActionResult<postCatogrey> GetCategoryById(int id)
    {
        postCatogrey? cat =_homeManager.GetCategoryById(id);
        return cat;
    }

    #endregion

}
