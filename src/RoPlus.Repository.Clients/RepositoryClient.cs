using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RoPlus.Repository.Clients {
  public class RepositoryClient<T>: IRepository<T> {
    private HttpClient _client;

    public RepositoryClient( string baseAddress ) {
      _client = new HttpClient() {
        BaseAddress = new Uri( $"{baseAddress}api/" )
      };


      _client.DefaultRequestHeaders.Accept.Clear();
      _client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );
    }

    public void Delete( T entry ) {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> Get() {
      return await GetListAsync();
    }

    public async Task<T> Get( int id ) {
      return await GetAsync( id.ToString() );
    }

    public void Post( T entry ) {
      throw new NotImplementedException();
    }

    public void Put( T entry ) {
      throw new NotImplementedException();
    }

    private async Task<T> GetAsync( string appendPath ) {
      T product = default( T );
      HttpResponseMessage response = await _client.GetAsync( appendPath );
      if ( response.IsSuccessStatusCode ) {
        product = await response.Content.ReadAsAsync<T>();
      }
      return product;
    }

    private async Task<IEnumerable<T>> GetListAsync() {
      IEnumerable<T> product = null;
      HttpResponseMessage response = await _client.GetAsync( typeof(T).Name );
      if ( response.IsSuccessStatusCode ) {
        product = await response.Content.ReadAsAsync<IEnumerable<T>>();
      }
      return product;
    }
  }
}
