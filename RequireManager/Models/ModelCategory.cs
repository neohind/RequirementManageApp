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
            get;
            set;
        }


    }
}
