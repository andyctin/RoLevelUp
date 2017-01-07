using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RoPlus.Base.Model;
using RoPlus.Repository.Clients;

namespace RoPlus.Repository.Controllers {
  [Route( "api/[controller]" )]
  public class SectionsController: Controller, IRepository<Section> {
    private RoPlusDbContext _context;

    public SectionsController( RoPlusDbContext context ) {
      _context = context;
    }

    // GET api/Sections
    [HttpGet]
    public IEnumerable<Section> Get() {
      return _context.Section.ToList(); ;
    }

    // GET api/Sections/5
    [HttpGet( "{id}" )]
    public Section Get( int id ) {
      return _context.Section.FirstOrDefault( section =>section.Id == id );
    }

    public void Post( Section entry ) {
      throw new NotImplementedException();
    }

    public void Put( Section entry ) {
      throw new NotImplementedException();
    }

    public void Delete( Section entry ) {
      throw new NotImplementedException();
    }
  }
}
