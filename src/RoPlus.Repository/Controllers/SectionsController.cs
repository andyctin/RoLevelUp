using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoPlus.Base.Model;
using RoPlus.Repository.Clients;

namespace RoPlus.Repository.Controllers {
  [Route( "api/[controller]" )]
  public class SectionController: Controller, IRepository<Section> {
    private RoPlusDbContext _context;

    public SectionController( RoPlusDbContext context ) {
      _context = context;
    }

    // GET api/Sections
    [HttpGet]
    public async Task<IEnumerable<Section>> Get() {
      return await _context.Section.ToListAsync(); ;
    }

    // GET api/Sections/5
    [HttpGet( "{id}" )]
    public async Task<Section> Get( int id ) {
      return await _context.Section.FirstOrDefaultAsync( section =>section.Id == id );
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
