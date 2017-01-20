using System.Collections.Generic;
using System.Linq;
using IR.Quote.Data.Connection;
using SQLiteNetExtensions.Extensions;

namespace IR.Quote.Data.Repositories
{
    public interface IQuoteRepository
    {
        List<Models.Quote> All();
        List<Models.Quote> Active();
        Models.Quote Load(long id);
    }


    public class QuoteRepository : BaseRepository<Models.Quote>, IQuoteRepository
    {
        public QuoteRepository(IDbConnectionFactory db) : base(db)
        {
        }

        public override List<Models.Quote> All()
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                return cxn.GetAllWithChildren<Models.Quote>();
            }
        }

        public List<Models.Quote> Active()
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                return cxn.GetAllWithChildren<Models.Quote>()
                    .Where(c => c.Active == true)
                    .ToList();
            }
        }


        public Models.Quote Load(long id)
        {
            using (var cxn = DbFactory.OpenDbConnection())
            {
                var obj = cxn.Table<Models.Quote>().FirstOrDefault(u => u.Id == id);
                if (obj == null) return null;

                return cxn.GetWithChildren<Models.Quote>(id);
            }
        }
    }
}
