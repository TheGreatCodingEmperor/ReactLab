using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Models;

namespace Data.Repositories
{
    public class StoreRepository : IRepository<Store, long>
    {
        private readonly ReactLabContext _context;

        public StoreRepository(ReactLabContext context)
        {
            _context = context;
        }

        public long Create(Store entity)
        {
            _context.Stores.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public void Update(Store entity)
        {
            var oriStore = _context.Stores.Single(x => x.Id == entity.Id);
            _context.Entry(oriStore).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            _context.Stores.Remove(_context.Stores.Single(x => x.Id == id));
            _context.SaveChanges();
        }

        public IEnumerable<Store> Find(Expression<Func<Store, bool>> expression)
        {
            return _context.Stores.Where(expression);
        }

        public Store FindById(long id)
        {
            return _context.Stores.SingleOrDefault(x => x.Id == id);
        }
    }
}