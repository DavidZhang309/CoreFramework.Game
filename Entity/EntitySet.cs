using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Game.Entity
{
    /// <summary>
    /// Represents the set of entities in the state
    /// </summary>
    public class EntitySet
    {
        private Dictionary<int, IEntity> entities;

        public EntitySet()
        {
            entities = new Dictionary<int, IEntity>();
        }

        public IEntity this[int id]
        {
            get
            {
                return entities[id];
            }
            set
            {
                entities.Add(value.EntityID, value);
            }
        }

        public IEnumerable<IEntity> GetEntities()
        {
            return entities.Values;
        }
    }
}
