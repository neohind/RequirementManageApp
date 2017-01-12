using RequireManager.Manager;
using RequireManager.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

            m_curValue = category;
            nodeEntry.Key = category.Id;            
            nodeEntry.Value = category;             
            this.Tag = category;
            category_OnRefreshed(category);
            category.OnRefreshed += category_OnRefreshed;
        }

        void category_OnRefreshed(ModelCategory category)
        {
            if (TreeView != null && TreeView.InvokeRequired)
                TreeView.Invoke(new ModelCategory.OnRefreshedHandler(category_OnRefreshed), category);
            else
            {
                this.Text = category.Code;
                this.ToolTipText = category.DisplayName;
            }
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

        public TreeNodeCategory FindNode(string sPath)
        {
            Queue<string> path = new Queue<string>();
            string[] aryPathTokens = sPath.Split(this.TreeView.PathSeparator.ToCharArray());
            foreach (string sToken in aryPathTokens)
                path.Enqueue(sToken);
            return FindNode(this, path);    
        }


        static TreeNodeCategory FindNode(TreeNodeCategory curNode, Queue<string> path)
        {
            TreeNodeCategory foundNode = curNode;            
            if (path.Count > 0)
            {
                string sPath = path.Dequeue();
                foreach (TreeNode childNode in foundNode.Nodes)
                {
                    if (string.Equals(childNode.Text, sPath))
                    {
                        foundNode = (TreeNodeCategory)childNode;
                        foundNode = FindNode(foundNode, path);
                        break;
                    }
                }                
            }
            return foundNode;
        }


    }
}
