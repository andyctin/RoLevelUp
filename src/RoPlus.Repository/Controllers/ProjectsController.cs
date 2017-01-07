using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoPlus.Base.Model;
using RoPlus.Repository.Clients;

namespace RoPlus.Repository.Controllers {
  [Route( "api/[controller]" )]
  public class ProjectsController: Controller, IRepository<Project> {
    private RoPlusDbContext _context;

    public ProjectsController( RoPlusDbContext context ) {
      _context = context;
    }

    // GET api/Projects
    [HttpGet]
    public IEnumerable<Project> Get() {
      return _context.Project.ToList(); ;
    }

    // GET api/Projects/5
    [HttpGet( "{id}" )]
    public Project Get( int id ) {
      return _context.Project.FirstOrDefault( Project =>Project.Id == id );
    }

    public void Post( Project entry ) {
      throw new NotImplementedException();
    }

    public void Put( Project entry ) {
      throw new NotImplementedException();
    }

    public void Delete( Project entry ) {
      throw new NotImplementedException();
    }
  }
}
