using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RoPlus.Base.Model;

namespace RoPlus.Repository.Controllers {
  [Route( "api/[controller]" )]
  public class SectionsController: Controller {
    private RoPlusDbContext _context;

    public SectionsController( RoPlusDbContext context ) {
      _context = context;
    }
    // GET api/Sections
    [HttpGet]
    public IEnumerable<Section> Get() {
      return _context.Sections.ToList(); ;
    }

    // GET api/Sections/5
    [HttpGet( "{id}" )]
    public async Task<Section> Get( string id ) {
      return await _context.Sections.FindAsync( new[] { id } );
    }

    // POST api/Sections
    [HttpPost]
    public void Post( [FromBody]string value ) {
    }

    // PUT api/Sections/5
    [HttpPut( "{id}" )]
    public void Put( int id, [FromBody]string value ) {
    }

    // DELETE api/Sections/5
    [HttpDelete( "{id}" )]
    public void Delete( int id ) {
    }
  }
}
