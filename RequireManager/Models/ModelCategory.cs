using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Models
{
    public class ModelCategory : ModelBase
    {
        public delegate void OnRefreshedHandler(ModelCategory category);
        public event OnRefreshedHandler OnRefreshed;


        private string m_sPath = string.Empty;
        private string m_sFullPath = string.Empty;


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
                if (string.IsNullOrEmpty(m_sPath))
                    m_sPath = GetPath(this, "-");
                return m_sPath;
            }
        }

        public string FullPath
        {
            get
            {
                if (string.IsNullOrEmpty(m_sFullPath))
                    m_sFullPath = GetPath(this, "\\");
                return m_sFullPath;
            }
        }

        private string GetPath(ModelCategory current, string sSpliter)
        {
            if(current != null && current.Parent != null)
            {
                ModelCategory parent = current.Parent;
                string sParentCode = GetPath(parent, sSpliter);
                if (string.IsNullOrEmpty(sParentCode))
                    return current.Code;
                else
                    return string.Format("{0}{1}{2}", sParentCode,sSpliter, current.Code);                
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


        public void Refresh()
        {
            m_sFullPath = string.Empty;
            m_sPath = string.Empty;
            if (OnRefreshed != null)
                OnRefreshed(this);
        }

    }
}
