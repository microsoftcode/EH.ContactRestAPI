using System.Collections.Generic;
using ContactRestAPI.Models;
using ContactApi.Data;

namespace ContactRestAPI.Data
{
    public interface IContactRepository: IGenericRepository<Contact>
    {
      
    }
}
