using ContactApi.Data;


namespace ContactRestAPI.Data
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {

        public ContactRepository(ContactDbContext dbContext)
        : base(dbContext)
        {

        }        
    }
}
