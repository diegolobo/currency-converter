using System;

namespace currency_converter.Modules.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public DateTime InsertDate { get; set; }

        public bool Active { get; set; }
    }
}
