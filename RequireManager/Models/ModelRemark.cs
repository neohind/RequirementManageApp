using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager.Models
{
    public class ModelRemark : ModelBase
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

        [DbPropName("REQID")]
        public int RequirementId
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


        [DbPropName("CONTENTS")]
        public string Contents
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


    }
}
