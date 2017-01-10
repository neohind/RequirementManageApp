using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace RequireManager.Dac
{
    public class DacBase
    {
        protected DbAgent m_agent = null;

        public DacBase(string sConnectionString)
        {
            m_agent = new DbAgent(sConnectionString);
        }


    }
}
