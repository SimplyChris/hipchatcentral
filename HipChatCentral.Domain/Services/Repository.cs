using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using HipChatCentral.Domain.Data.Contexts;
using HipChatCentral.Domain.Interfaces;

namespace HipChatCentral.Domain.Services
{
    public class Repository <T> : IRepository<T> where T:class
    {
        private readonly IHipChatCentralContext _context;
        private readonly DbContext _dbContext;

        public IDbSet<T> DbSet { get { return _dbContext.Set<T>(); } }        

        public Repository (IHipChatCentralContext context)
        {
            _context = context;
            _dbContext = (DbContext)context;
        }

        public void Insert (T model)
        {            
            DbSet.Add(model);
        }

        public IList<T> GetCollection (Expression<Func<T,bool>> predicate)
        {
            return _dbContext.Set<T>().Where(predicate).ToList();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            var collection = GetCollection(predicate);
            if (collection.Count() > 1)
            {
                throw new Exception("More than a single result was returned from query");
            }
            return !collection.Any() ? null : collection[0];
        }

        public void Delete(Expression<Func<T,bool>> predicate )
        {
            IList<T> set = GetCollection(predicate);
            foreach (var item in set)
            {
                _dbContext.Set<T>().Remove(item);
            }            
        }

        public void SaveChanges ()
        {
            _context.SaveChanges();
        }
    }
}