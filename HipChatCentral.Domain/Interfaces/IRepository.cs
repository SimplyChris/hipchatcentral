using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace HipChatCentral.Domain.Interfaces
{
    public interface  IRepository <T> where T:class
    {
        IDbSet<T> DbSet  { get; }
        void Insert (T model);
        void SaveChanges();
        IList <T> GetCollection(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate); 
        void Delete(Expression<Func<T,bool>> predicate);
    }
}