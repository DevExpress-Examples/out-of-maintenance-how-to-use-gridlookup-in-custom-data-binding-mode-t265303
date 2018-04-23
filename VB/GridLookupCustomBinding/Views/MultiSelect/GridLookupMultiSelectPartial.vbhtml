@Html.DevExpress().GridLookup(Sub(settings)
    settings.Name = "GridLookup"
	settings.GridViewProperties.CallbackRouteValues = New With { .Controller = "MultiSelect",  .Action = "GridLookupMultiSelectPartial"}
	settings.GridViewProperties.CustomBindingRouteValuesCollection.Add(GridViewOperationType.Paging, New With { .Controller = "MultiSelect", .Action = "GridLookupPagingAction"})
	settings.GridViewProperties.CustomBindingRouteValuesCollection.Add(GridViewOperationType.Sorting, New With {.Controller = "MultiSelect",  .Action = "GridLookupSortingAction"})
	settings.GridViewProperties.CustomBindingRouteValuesCollection.Add(GridViewOperationType.Filtering, New With { .Controller = "MultiSelect",  .Action = "GridLookupFilteringAction"})
	settings.CommandColumn.Visible = True
	settings.CommandColumn.ShowSelectCheckbox = True
	settings.KeyFieldName = "OrderID"
	settings.Columns.Add("OrderID")
	settings.Columns.Add("ShipName")
	settings.Columns.Add("ShipCity")
	settings.Columns.Add(Sub(c)
        c.FieldName = "OrderDate"
	c.ColumnType = MVCxGridViewColumnType.DateEdit

       End Sub)
	settings.Properties.SelectionMode = GridLookupSelectionMode.Multiple
	settings.Properties.TextFormatString = "{0} {2}"
	settings.Width = 450
	settings.DataBound = Sub(sender,e)
        Dim gridLookup = CType(sender, MVCxGridLookup)
	    gridLookup.GridView.Width = 400

    End Sub
	settings.GridViewProperties.SettingsPager.PageSize = 10

End Sub).BindToCustomData(Model).GetHtml()