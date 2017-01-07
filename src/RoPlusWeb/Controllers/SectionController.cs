using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RoPlusAngularWeb.Controllers {
  [Route( "api/[controller]" )]
  public class SectionController: Controller {
    private static string[] Summaries = new[]
    {
            "New", "Trending"
        };

    [HttpGet( "[action]" )]
    public IEnumerable<string> Sections() {
      return new List<string> { string.Empty };
    }
  }
}
