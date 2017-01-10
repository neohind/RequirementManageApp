using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace RequireManager.Dac
{
    public class DacFactory
    {
        public static DacFactory Current
        {
            get;
            private set;
        }

        static DacFactory()
        {
            if (Current == null)
                Current = new DacFactory();
        }

        public DacSetting Settings
        {
            get;
            private set;
        }

        public DacCategory Category
        {
            get;
            private set;
        }


        public DacProject Project
        {
            get;
            private set;
        }


        public DacReqmnt Requiremnt
        {
            get;
            private set;
        }


        private DacFactory()
        {             

        }

        public void Init(string sConnectionString)
        {
            Settings = new DacSetting(sConnectionString);
            Category = new DacCategory(sConnectionString);
            Project = new DacProject(sConnectionString);
            Requiremnt = new DacReqmnt(sConnectionString);
        }

        private void Validation()
        {
            Settings.InitValidation();
        }


    }
}
