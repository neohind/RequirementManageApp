using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Models
{
    public class ModelReqmnt : ModelBase
    {

        private ModelCategory m_curCategory = null;

        public ModelCategory Category
        {
            get
            {
                return m_curCategory;
            }
            set
            {
                m_curCategory = value;
            }
        }

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
        public int CategoryIdFromDB
        {
            get;
            set;
        }

        public int CategoryId
        {
            get
            {
                if (Category != null)
                    return Category.Id;
                return -1;
            }
        }

        [DbPropName("PATH")]
        public string CategoryPath
        {
            get
            {
                if (Category != null)
                    return Category.Path;
                return string.Empty;
            }
            set
            {   
            }
        }

        [DbPropName("CATNM")]
        public string CategoryName
        {
            get
            {
                if (Category != null)
                    return Category.DisplayName;
                return string.Empty;
            }
            set
            {

            }
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
