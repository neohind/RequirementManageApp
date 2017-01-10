using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Models
{
    public class ModelReqmnt : ModelBase
    {
        [DbPropName("ID")]
        public int Id
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

        [DbPropName("CATID")]
        public int CategoryId
        {
            get;
            set;
        }
        
        [DbPropName("PATH")]
        public string CategoryPath
        {
            get;
            set;
        }

        [DbPropName("IDX")]
        public int Index
        {
            get;
            set;
        }

        [DbPropName("SRCID")]
        public int SourceId
        {
            get;
            set;
        }

        [DbPropName("ENABLED")]
        public string EnabledStr
        {
            get
            {
                return Enabled ? "Y" : "N";
            }
            set
            {
                Enabled = "Y".Equals(value);
            }

        }

        public bool Enabled
        {
            get;
            set;
        }

        [DbPropName("REQNMT")]
        public string Requirement
        {
            get;
            set;
        }

        [DbPropName("CREATED")]
        public DateTime Created
        {
            get;
            set;
        }

        [DbPropName("UPDATED")]
        public DateTime Updated
        {
            get;
            set;
        }


        public List<ModelRemark> AllRemark
        {
            get;
            set;
        }

        public ModelReqmnt()
        {
            AllRemark = new List<ModelRemark>();
        }
    }
}
