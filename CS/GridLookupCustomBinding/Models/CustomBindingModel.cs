using System.Collections.Generic;
using System.Linq;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.Data.Linq;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Web.Mvc;
using GridLookupCustomBinding.Models;

namespace Sample.Models
{
    public static class CustomBindingHandlers
    {
        static NorthwindDataClassesDataContext db = new NorthwindDataClassesDataContext();
        static IQueryable<Order> Model { get { return db.Orders; } }

        public static void GetDataRowCount(GridViewCustomBindingGetDataRowCountArgs e)
        {
            e.DataRowCount = Model               
                .Count();
        }
        public static void GetDataRowCountIncrementalFiltering(GridViewCustomBindingGetDataRowCountArgs e)
        {
            e.DataRowCount = Model
                .ApplyFilter(e.FilterExpression)
                .Count();
        }
        public static void GetData(GridViewCustomBindingGetDataArgs e)
        {
            e.Data = Model               
                .ApplySorting(e.State.SortedColumns)
                .Skip(e.StartDataRowIndex)
                .Take(e.DataRowCount);
        }
        public static void GetDataIncrementalFilteng(GridViewCustomBindingGetDataArgs e)
        {
            e.Data = Model
                .ApplyFilter(e.State.AppliedFilterExpression)
                .ApplySorting(e.State.SortedColumns)
                .Skip(e.StartDataRowIndex)
                .Take(e.DataRowCount);
        }
        public static void GetRowValues(GridViewCustomBindingGetRowValuesArgs e)
        {
            if (e.KeyValues.Count() == 0)
                e.RowValues = Model.Where(c => object.Equals(c.OrderID, -1));
            else
            {
                var list = new List<Order>();
                foreach (var item in e.KeyValues)
                {
                    list.Add(Model.Where(c => object.Equals(c.OrderID, item)).FirstOrDefault());
                }
                e.RowValues = list;
            }
        }

     
    }

    public static class GridViewCustomOperationDataHelper
    {
        static ICriteriaToExpressionConverter Converter { get { return new CriteriaToExpressionConverter(); } }

        public static IQueryable Select(this IQueryable query, string fieldName)
        {
            return query.MakeSelect(Converter, new OperandProperty(fieldName));
        }
        public static IQueryable ApplySorting(this IQueryable query, IEnumerable<GridViewColumnState> sortedColumns)
        {
            foreach (GridViewColumnState column in sortedColumns)
                query = ApplySorting(query, column.FieldName, column.SortOrder);
            return query;
        }
        public static IQueryable ApplySorting(this IQueryable query, string fieldName, ColumnSortOrder order)
        {
            return query.MakeOrderBy(Converter, new ServerModeOrderDescriptor(new OperandProperty(fieldName), order == ColumnSortOrder.Descending));
        }
        public static IQueryable ApplyFilter(this IQueryable query, string filterExpression)
        {
            return query.AppendWhere(Converter, CriteriaOperator.Parse(filterExpression));
        }
    }
}