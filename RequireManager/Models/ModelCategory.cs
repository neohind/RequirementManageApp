using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Models
{
    public class ModelCategory : ModelBase
    {
        [DbPropName("ID")]
        public int Id
        {
            get;
            set;
        }

        [DbPropName("PID")]
        public int ParentId
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
        

        [DbPropName("CODE")]
        public string Code
        {
            get;
            set;
        }

        [DbPropName("DISPNM")]
        public string DisplayName
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

        [DbPropName("CREATED")]
        public DateTime CreateDatetime
        {
            get;
            set;
        }

        [DbPropName("UPDATED")]
        public DateTime UpdateDateTime
        {
            get;
            set;
        }

        public string Path
        {
            get
            {
                return GetPath(this);
            }
        }

        private string GetPath(ModelCategory current)
        {
            if(current != null && current.Parent != null)
            {
                ModelCategory parent = current.Parent;
                string sParentCode = GetPath(parent);
                if (string.IsNullOrEmpty(sParentCode))
                    return current.Code;
                else
                    return string.Format("{0}-{1}", sParentCode, current.Code);                
            }
            return string.Empty;
        }

        public ModelCategory Parent
        {
            get;
            set;
        }

        public List<ModelCategory> Childs
        {
            get;
            private set;
        }


        public ModelCategory()
        {
            Childs = new List<ModelCategory>();
        }


    }
}
