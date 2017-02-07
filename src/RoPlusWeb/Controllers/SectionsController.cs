using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoPlus.Base.Models;
using RoPlus.Repository.Clients;
using RoPlusWeb.Constants;

namespace RoPlusWeb.Controllers {
  [Route( "api/[controller]" )]
  public class SectionsController: Controller {
    private RepositoryClient<Section> _repository;

    public SectionsController() {
      _repository = new RepositoryClient<Section>(AppSettings.Instance.RepositoryUrl);
    }

    [HttpGet( "[action]" )]
    public async Task<IEnumerable<Section>> Get() {
      var sections = await _repository.Get();
      return sections;
    }
  }
}
