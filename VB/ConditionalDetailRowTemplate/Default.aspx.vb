Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Runtime.Serialization
Imports DevExpress.Web.ASPxGridView

Namespace ConditionalDetailRowTemplate
	Partial Public Class _Default
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			gridMaster.DataSource = GetMasterRows()
			gridMaster.DataBind()
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		End Sub
		Protected Sub gridProduct_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim gridProduct As ASPxGridView = CType(sender, ASPxGridView)
			If (Not IsGridProductVisible(gridProduct.GetMasterRowKeyValue())) Then
				Return
			End If

			gridProduct.DataSource = GetProducts()
			gridProduct.DataBind()

		End Sub
		Protected Sub gridComponent_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim gridComponent As ASPxGridView = CType(sender, ASPxGridView)
			If (Not IsGridComponentVisible(gridComponent.GetMasterRowKeyValue())) Then
				Return
			End If

			gridComponent.DataSource = GetComponents()
			gridComponent.DataBind()
		End Sub
		Private Function GetMasterRows() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("Category")
			table.Rows.Add(1, "Product")
			table.Rows.Add(2, "Component")
			Return table
		End Function
		Private Function GetProducts() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("Name")
			table.Columns.Add("WebPage")
			table.Rows.Add(1, "ASPxGridView", "http://devexpress.com/ASPxGridView")
			table.Rows.Add(2, "eXpress Persistent Objects", "http://devexpress.com/xpo")
			Return table
		End Function

		Private Function GetComponents() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("ClassName")
			table.Columns.Add("Namespace")
			table.Columns.Add("IsVisual")
			table.Rows.Add(1, "ASPxGridView", "DevExpress.Web.ASPxGridView", True)
			table.Rows.Add(2, "XPCollection", "DevExpress.Xpo", False)
			Return table
		End Function

		Protected Function IsGridProductVisible(ByVal categoryID As Object) As Boolean
			Dim categoryName As Object = gridMaster.GetRowValuesByKeyValue(categoryID, "Category")
			Return "Product".Equals(categoryName)
		End Function
		Protected Function IsGridComponentVisible(ByVal categoryID As Object) As Boolean
			Dim categoryName As Object = gridMaster.GetRowValuesByKeyValue(categoryID, "Category")
			Return "Component".Equals(categoryName)
		End Function

	End Class
End Namespace
