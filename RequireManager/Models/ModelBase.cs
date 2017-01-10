    using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RequireManager.Models
{
    public class ModelBase
    {
        public void WriteData(DataRow row)
        {
            foreach (PropertyInfo info in this.GetType().GetProperties())
            {
                object[] aryAttrs = info.GetCustomAttributes(typeof(DbPropNameAttribute), true);
                foreach (object oAttr in aryAttrs)
                {
                    if (oAttr is DbPropNameAttribute)
                    {
                        DbPropNameAttribute attr = (DbPropNameAttribute)oAttr;
                        string sColumnName = attr.ColumnName;
                        if (row.Table.Columns.Contains(sColumnName))
                        {
                            object value = row[sColumnName];
                            Type valueType = info.PropertyType;
                            try
                            {
                                value = Convert.ChangeType(value, valueType);
                                info.SetValue(this, value, null);
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }


        public void UpdataeData(DataRow row)
        {
            DataColumnCollection columns = row.Table.Columns;
            foreach (PropertyInfo info in this.GetType().GetProperties())
            {
                object[] aryAttrs = info.GetCustomAttributes(typeof(DbPropNameAttribute), true);
                foreach (object oAttr in aryAttrs)
                {
                    if (oAttr is DbPropNameAttribute)
                    {
                        DbPropNameAttribute attr = (DbPropNameAttribute)oAttr;
                        string sCurColumnName = attr.ColumnName;
                        if (columns.Contains(sCurColumnName))
                        {
                            object value = info.GetValue(this, null);
                            try
                            {
                                row[sCurColumnName] = value;
                            }
                            catch
                            {
                            }
                        }
                    }
                }
            }
        }
    }
}
