using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace WFront.Common
{
    public static class ExtendControls
    {
        public static void LoadData(this DropDownList Drop, IEnumerable<ListItem> Items, bool ShowSelect = false)
        {
            Drop.Items.Clear();
            Drop.DataValueField = "Value";
            Drop.DataTextField = "Text";
            Drop.DataSource = Items;
            Drop.DataBind();

            if(ShowSelect)
                Drop.Items.Insert(0, new ListItem { Value = "-1", Text = "-- Seleccione --" });
        }

        public static IEnumerable<ListItem> GenerateItems(this DataTable Table, string ValueField, string TextField)
        {
            IEnumerable<ListItem> Result = new List<ListItem>();

            var datos = Table.AsEnumerable();
            Result = datos.Select(p => new ListItem { Value = p[ValueField].ToString(), Text = p[TextField].ToString() });

            return Result;
        }
    }
}