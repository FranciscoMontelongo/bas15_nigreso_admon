using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;

namespace Negocio
{
    public static class Extensions
    {
        public static IEnumerable<T> GetItems<T>(this IEnumerable collection, Func<T, IEnumerable> selector)
        {
            Stack<IEnumerable<T>> stack = new Stack<IEnumerable<T>>();
            stack.Push(collection.OfType<T>());

            while (stack.Count > 0)
            {
                IEnumerable<T> items = stack.Pop();
                foreach (var item in items)
                {
                    yield return item;

                    IEnumerable<T> children = selector(item).OfType<T>();
                    stack.Push(children);
                }
            }
        }

        public static void fillGridView(this GridView gv, DataSet ds){
            gv.DataSource = ds;
            gv.DataBind();
        }

        public static void fillddl(this DropDownList Drop, DataSet ds)
        {
            Drop.Items.Clear();
            Drop.DataSource = ds;
            Drop.DataValueField = ds.Tables[0].Columns[0].ColumnName;
            Drop.DataTextField = ds.Tables[0].Columns[1].ColumnName;            
            Drop.DataBind();

            Drop.Items.Insert(0, new ListItem { Value = "-1", Text = "-- Seleccione --" });
        }
    }
}
