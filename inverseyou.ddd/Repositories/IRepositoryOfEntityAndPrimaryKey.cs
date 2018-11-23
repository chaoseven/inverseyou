using inverseyou.ddd.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace inverseyou.ddd.Repositories
{
    public interface IRepository<TEntity,TPrimaryKey>:IRepository where TEntity:class,IEntity<TPrimaryKey>
    {
    }
}
