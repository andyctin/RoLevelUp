using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoPlus.Base.Model;
using RoPlus.Repository.Clients;
using RoPlusWeb.Constants;

namespace RoPlusAngularWeb.Controllers {
  [Route( "api/[controller]" )]
  public class ProjectsController: Controller {
    private RepositoryClient<Project> _repository;

    public ProjectsController() {
      _repository = new RepositoryClient<Project>(AppSettings.Instance.RepositoryUrl);
    }

    [HttpGet( "[action]" )]
    public async Task<IEnumerable<Project>> Get() {
      var projects = await _repository.Get();
      return projects;
    }
  }
}
