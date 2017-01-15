using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoPlus.Repository.Clients {
  public interface IRepository<T> {

    Task<IEnumerable<T>> Get();
    Task<T> Get( int id );

    void Post( T entry );

    void Put( T entry );

    void Delete( T entry );
  }
}
