using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoPlus.Base.Models;
using RoPlus.Repository.Clients;

namespace RoPlus.Repository.Controllers {
  [Route( "api/[controller]" )]
  public class ProjectController: Controller, IRepository<Project> {
    private RoPlusDbContext _context;

    public ProjectController( RoPlusDbContext context ) {
      _context = context;
    }

    // GET api/Projects
    [HttpGet]
    public async Task<IEnumerable<Project>> Get() {
      return await _context.Project.ToListAsync();
    }

    // GET api/Projects/5
    [HttpGet( "{id}" )]
    public async Task<Project> Get( int id ) {
      return await _context.Project.FirstOrDefaultAsync( Project =>Project.Id == id );
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
