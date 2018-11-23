using inverseyou.ddd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inverseyou.ddd.Repositories
{
    public interface IRepository<TEntity>:IRepository<TEntity,int> where TEntity:class,IEntity<int>
    {
    }
}
