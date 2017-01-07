using System.Collections.Generic;

namespace RoPlus.Repository.Clients {
  public interface IRepository<T> {

    IEnumerable<T> Get();
    T Get( int id );

    void Post( T entry );

    void Put( T entry );

    void Delete( T entry );
  }
}
