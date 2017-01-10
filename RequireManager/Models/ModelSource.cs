using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Models
{
    public class ModelSource : ModelBase
    {
        [DbPropName("ID")]
        public int ID
        {
            get;
            set;
        }

        [DbPropName("PRJID")]
        public int ProjectId
        {
            get;
            set;
        }

        [DbPropName("NAME")]
        public string Name
        {
            get;
            set;
        }

        [DbPropName("DESCRIPT")]
        public string Description
        {
            get;
            set;
        }
    }
}
