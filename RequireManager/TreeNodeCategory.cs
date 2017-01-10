using RequireManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RequireManager
{
    public class TreeNodeCategory : System.Windows.Forms.TreeNode, IDictionaryEnumerator
    {
        private DictionaryEntry nodeEntry;
        private IEnumerator enumerator;
        private ModelCategory m_curValue;

        public TreeNodeCategory()
        {
            enumerator = base.Nodes.GetEnumerator();
        }

        public TreeNodeCategory(ModelCategory category)
            : base()
        {
            this.Text = category.Code;
            nodeEntry.Key = category.Id;
            m_curValue =category;
            nodeEntry.Value = category;
            this.Tag = category;
        }

        public string NodeKey
        {
            get
            {
                return nodeEntry.Key.ToString();
            }

            set
            {
                nodeEntry.Key = value;
            }
        }

        public object NodeValue
        {
            get
            {
                return nodeEntry.Value;
            }

            set
            {
                nodeEntry.Value = value;
            }
        }

        public ModelCategory GetValue()
        {
            return m_curValue;
        }

        public DictionaryEntry Entry
        {
            get
            {
                return nodeEntry;
            }
        }

        public bool MoveNext()
        {
            bool Success;
            Success = enumerator.MoveNext();
            return Success;
        }

        public object Current
        {
            get
            {
                return enumerator.Current;
            }
        }

        public object Key
        {
            get
            {
                return nodeEntry.Key;
            }
        }

        public object Value
        {
            get
            {
                return nodeEntry.Value;
            }
        }

        public void Reset()
        {
            enumerator.Reset();
        }
    }
}
