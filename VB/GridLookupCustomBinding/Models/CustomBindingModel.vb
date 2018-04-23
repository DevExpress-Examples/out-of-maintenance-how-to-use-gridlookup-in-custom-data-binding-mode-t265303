Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.Data
Imports DevExpress.Data.Filtering
Imports DevExpress.Data.Linq
Imports DevExpress.Data.Linq.Helpers
Imports DevExpress.Web.Mvc
Imports GridLookupCustomBinding.Models

Namespace Sample.Models
    Public NotInheritable Class CustomBindingHandlers
        Private Shared db As New NorthwindDataClassesDataContext()
        Private Sub New()
        End Sub
        Private Shared ReadOnly Property Model() As IQueryable(Of Order)
            Get
                Return db.Orders
            End Get
        End Property

        Public Shared Sub GetDataRowCount(ByVal e As GridViewCustomBindingGetDataRowCountArgs)
            e.DataRowCount = Model.Count()
        End Sub
        Public Shared Sub GetDataRowCountIncrementalFiltering(ByVal e As GridViewCustomBindingGetDataRowCountArgs)
            e.DataRowCount = Model.ApplyFilter(e.FilterExpression).Count()
        End Sub
        Public Shared Sub GetData(ByVal e As GridViewCustomBindingGetDataArgs)
            e.Data = Model.ApplySorting(e.State.SortedColumns).Skip(e.StartDataRowIndex).Take(e.DataRowCount)
        End Sub
        Public Shared Sub GetDataIncrementalFilteng(ByVal e As GridViewCustomBindingGetDataArgs)
            e.Data = Model.ApplyFilter(e.State.AppliedFilterExpression).ApplySorting(e.State.SortedColumns).Skip(e.StartDataRowIndex).Take(e.DataRowCount)
        End Sub
        Public Shared Sub GetRowValues(ByVal e As GridViewCustomBindingGetRowValuesArgs)
            If e.KeyValues.Count() = 0 Then
                e.RowValues = Model.Where(Function(c) Object.Equals(c.OrderID, -1))
            Else
                Dim list = New List(Of Order)()
                For Each item In e.KeyValues
                    list.Add(Model.Where(Function(c) Object.Equals(c.OrderID, item)).FirstOrDefault())
                Next item
                e.RowValues = list
            End If
        End Sub


    End Class
    Public Module GridViewCustomOperationDataHelper


        Private ReadOnly Property Converter() As ICriteriaToExpressionConverter
            Get
                Return New CriteriaToExpressionConverter()
            End Get
        End Property

        <System.Runtime.CompilerServices.Extension> _
        Public Function [Select](ByVal query As IQueryable, ByVal fieldName As String) As IQueryable
            Return query.MakeSelect(Converter, New OperandProperty(fieldName))
        End Function

        <System.Runtime.CompilerServices.Extension> _
        Public Function ApplySorting(ByVal query As IQueryable, ByVal sortedColumns As IEnumerable(Of GridViewColumnState)) As IQueryable
            Dim orderDescriptors() As ServerModeOrderDescriptor = sortedColumns.Select(Function(c) New ServerModeOrderDescriptor(New OperandProperty(c.FieldName), c.SortOrder = ColumnSortOrder.Descending)).ToArray()
            Return query.MakeOrderBy(Converter, orderDescriptors)
        End Function

        <System.Runtime.CompilerServices.Extension> _
        Public Function ApplyFilter(ByVal query As IQueryable, ByVal groupInfoList As IList(Of GridViewGroupInfo)) As IQueryable
            Dim criteria = GroupOperator.And(groupInfoList.Select(Function(i) New BinaryOperator(i.FieldName, i.KeyValue, BinaryOperatorType.Equal)))
            Return query.ApplyFilter(CriteriaOperator.ToString(criteria))
        End Function
        <System.Runtime.CompilerServices.Extension> _
        Public Function ApplyFilter(ByVal query As IQueryable, ByVal filterExpression As String) As IQueryable
            Return query.AppendWhere(Converter, CriteriaOperator.Parse(filterExpression))
        End Function
    End Module
End Namespace