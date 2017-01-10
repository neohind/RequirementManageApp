using System;
using System.Collections.Generic;
using System.Text;

namespace RequireManager.Models
{
    public class DbPropNameAttribute : Attribute
    {
        public string ColumnName
            {
            get;
            set;
            }

        public ValueType CurrentType
        {
            get;
            set;
        }

        public object DefaultValue
        {
            get;
            set;
        }

        public DbPropNameAttribute() : base()
        {
        }

        public DbPropNameAttribute(string sColumnName)
            : this()
        {
            this.ColumnName = sColumnName;
        }
    }
}
