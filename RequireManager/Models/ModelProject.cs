using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Models
{
    public class ModelProject : ModelBase
    {
        [DbPropName("ID")]
        public int ID
        {
            get;
            set;
        }


        [DbPropName("PRJNM")]
        public string ProjectName
        {
            get;
            set;
        }

        [DbPropName("DESCRPT")]
        public string Description
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get;
            set;
        }

        [DbPropName("ENABLED")]
        public string IsEnabledStr
        {
            get
            {
                return IsEnabled ? "Y" : "N";
            }
            set
            {
                IsEnabled = "Y".Equals(value);
            }
        }
    }
}
