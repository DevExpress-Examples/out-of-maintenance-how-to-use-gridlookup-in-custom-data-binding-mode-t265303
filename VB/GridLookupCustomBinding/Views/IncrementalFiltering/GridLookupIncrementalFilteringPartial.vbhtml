@Html.DevExpress().GridLookup(settings =>
{
    settings.Name = "GridLookup"
    settings.GridViewProperties.CallbackRouteValues = new With { .Controller = "IncrementalFiltering", .Action = "GridLookupIncrementalFilteringPartial" }
    settings.GridViewProperties.CustomBindingRouteValuesCollection.Add(
           GridViewOperationType.Paging,
           new With { .Controller = "IncrementalFiltering", .Action = "GridLookupPagingAction" }
       );
    settings.GridViewProperties.CustomBindingRouteValuesCollection.Add(
        GridViewOperationType.Sorting,
        new With { .Controller = "IncrementalFiltering", .Action = "GridLookupSortingAction" }
    );
    settings.GridViewProperties.CustomBindingRouteValuesCollection.Add(
        GridViewOperationType.Filtering,
        new With { .Controller = "IncrementalFiltering", .Action = "GridLookupFilteringAction" }
    )
    settings.GridViewProperties.Settings.ShowFilterRow = true
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
	settings.Properties.SelectionMode = GridLookupSelectionMode.Single
        settings.Properties.IncrementalFilteringMode = IncrementalFilteringMode.Contains
	settings.Properties.TextFormatString = "{0} {2}"
	settings.Width = 450
	settings.DataBound = Sub(sender,e)
        Dim gridLookup = CType(sender, MVCxGridLookup)
	    gridLookup.GridView.Width = 400

    End Sub
	settings.GridViewProperties.SettingsPager.PageSize = 10
}).BindToCustomData(Model).GetHtml()