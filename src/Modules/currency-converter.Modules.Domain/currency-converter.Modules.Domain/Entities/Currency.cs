using System;
using System.Collections.Generic;

namespace currency_converter.Modules.Domain.Entities
{
    public class Currency : Entity
    {
        #region Constructors

        public Currency()
        {
            Rates = new List<Rate>();
            Active = true;
        }

        public Currency(string code, string name)
        {
            Code = code;
            Name = name;
            Active = true;
            InsertDate = DateTime.Now;
        }

        #endregion

        #region Constants

        public const int CODE_SIZE = 5;
        public const int NAME_MIN_SIZE = 3;
        public const int NAME_MAX_SIZE = 50;

        #endregion

        #region Properties

        public string Code { get; set; }
        public string Name { get; set; }
        public virtual List<Rate> Rates { get; set; }

        #endregion

        #region Methods

        public Currency DisableCurrency()
        {
            Active = false;

            return this;
        }

        #endregion
    }
}
