using System;
using System.Collections.Generic;
using System.Text;

namespace inverseyou.ddd.Entities
{
    [Serializable]
    public abstract class Entity:Entity<int>,IEntity
    {
    }

    [Serializable]
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
