using Epam.WCFMentoring.Northwind.NorthwindDbContext;

namespace Epam.WCFMentoring.Northwind.ServicesImpl
{
    public abstract class NorthwindServiceBase
    {
        protected NorthwindContext _dbContext;

        protected NorthwindServiceBase()
        {
            _dbContext = new NorthwindContext();
        }
    }
}
