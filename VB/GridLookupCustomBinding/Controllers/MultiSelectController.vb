Imports Microsoft.VisualBasic
Imports DevExpress.Web.Mvc
Imports Sample.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace GridLookupCustomBinding.Controllers
    Public Class MultiSelectController
        Inherits Controller
        '
        ' GET: /MultiSelect/
        Public Function GridLookupMultiSelect() As ActionResult
            Return View()
        End Function
        Public Function GridLookupMultiSelectPartial() As ActionResult
            Dim viewModel = GridLookupExtension.GetViewModel("GridLookup")
            If viewModel Is Nothing Then
                viewModel = CreateGridLookupViewModel()
            End If
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
            gridLookupModel.ProcessCustomBinding(AddressOf CustomBindingHandlers.GetDataRowCount, AddressOf CustomBindingHandlers.GetData, AddressOf CustomBindingHandlers.GetRowValues)
            Return PartialView("GridLookupMultiSelectPartial", gridLookupModel)
        End Function

        Private Shared Function CreateGridLookupViewModel() As GridLookupViewModel
            Dim viewModel = New GridLookupViewModel()
            viewModel.KeyFieldName = "OrderID"
            viewModel.TextFormatString = "{0} {2}"
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