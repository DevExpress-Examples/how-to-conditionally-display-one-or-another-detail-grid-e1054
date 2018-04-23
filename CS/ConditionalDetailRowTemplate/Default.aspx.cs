using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.Serialization;
using DevExpress.Web.ASPxGridView;

namespace ConditionalDetailRowTemplate {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            gridMaster.DataSource = GetMasterRows();
            gridMaster.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e) {

        }
        protected void gridProduct_Load(object sender, EventArgs e) {
            ASPxGridView gridProduct = (ASPxGridView)sender;
            if(!IsGridProductVisible(gridProduct.GetMasterRowKeyValue()))
                return;

            gridProduct.DataSource = GetProducts();
            gridProduct.DataBind();

        }
        protected void gridComponent_Load(object sender, EventArgs e) {
            ASPxGridView gridComponent = (ASPxGridView)sender;
            if(!IsGridComponentVisible(gridComponent.GetMasterRowKeyValue()))
                return;

            gridComponent.DataSource = GetComponents();
            gridComponent.DataBind();
        }
        private DataTable GetMasterRows() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Category");
            table.Rows.Add(1, "Product");
            table.Rows.Add(2, "Component");
            return table;
        }
        private DataTable GetProducts() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Name");
            table.Columns.Add("WebPage");
            table.Rows.Add(1, "ASPxGridView", "http://devexpress.com/ASPxGridView");
            table.Rows.Add(2, "eXpress Persistent Objects", "http://devexpress.com/xpo");
            return table;
        }

        private DataTable GetComponents() {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("ClassName");
            table.Columns.Add("Namespace");
            table.Columns.Add("IsVisual");
            table.Rows.Add(1, "ASPxGridView", "DevExpress.Web.ASPxGridView", true);
            table.Rows.Add(2, "XPCollection", "DevExpress.Xpo", false);
            return table;
        }

        protected bool IsGridProductVisible(object categoryID) {
            object categoryName = gridMaster.GetRowValuesByKeyValue(categoryID, "Category");
            return "Product".Equals(categoryName);
        }
        protected bool IsGridComponentVisible(object categoryID) {
            object categoryName = gridMaster.GetRowValuesByKeyValue(categoryID, "Category");
            return "Component".Equals(categoryName);
        }
        
    }
}
