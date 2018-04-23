Imports Microsoft.VisualBasic
Imports DevExpress.Web.Mvc
Imports Sample.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace GridLookupCustomBinding.Controllers
	Public Class IncrementalFilteringController
		Inherits Controller
		'
		' GET: /IncrementalFiltering/



		Public Function GridLookupIncrementalFiltering() As ActionResult
			Return View()
		End Function

		Public Function GridLookupIncrementalFilteringPartial() As ActionResult
			Dim viewModel = GridLookupExtension.GetViewModel("GridLookup")
			If viewModel Is Nothing Then
				viewModel = CreateGridLookupViewModel()
			End If
			Return GridLookupCustomActionCore(viewModel)
		End Function

		Public Function GridLookupFilteringAction(ByVal filteringState As GridLookupFilteringState) As ActionResult
			Dim viewModel = GridLookupExtension.GetViewModel("GridLookup")
			viewModel.ApplyFilteringState(filteringState)
			Return GridLookupCustomActionCore(viewModel)
		End Function
		Public Function GridLookupSortingAction(ByVal column As GridLookupColumnState, ByVal reset As Boolean) As ActionResult
			Dim viewModel = GridLookupExtension.GetViewModel("GridLookup")
			viewModel.SortBy(column, reset)
			Return GridLookupCustomActionCore(viewModel)
		End Function
		Public Function GridLookupPagingAction(ByVal pager As GridLookupPagerState) As ActionResult
			Dim viewModel = GridLookupExtension.GetViewModel("GridLookup")
			viewModel.Pager.Assign(pager)
			Return GridLookupCustomActionCore(viewModel)
		End Function

		Public Function GridLookupCustomActionCore(ByVal gridLookupModel As GridLookupViewModel) As ActionResult
            gridLookupModel.ProcessCustomBinding(AddressOf CustomBindingHandlers.GetDataRowCountIncrementalFiltering, AddressOf CustomBindingHandlers.GetDataIncrementalFilteng, AddressOf CustomBindingHandlers.GetRowValues)
			Return PartialView("GridLookupIncrementalFilteringPartial", gridLookupModel)
		End Function

		Private Shared Function CreateGridLookupViewModel() As GridLookupViewModel
			Dim viewModel = New GridLookupViewModel()
			viewModel.KeyFieldName = "OrderID"
			viewModel.IncrementalFilteringMode = DevExpress.Web.IncrementalFilteringMode.Contains
			viewModel.TextFormatString = "{0} {1} {2}"
			viewModel.KeyFieldName = "OrderID"
			viewModel.Columns.Add("OrderID")
			viewModel.Columns.Add("ShipName")
			viewModel.Columns.Add("ShipCity")
			viewModel.Columns.Add("OrderDate")
			viewModel.Pager.PageSize = 10
			Return viewModel
		End Function
	End Class
End Namespace