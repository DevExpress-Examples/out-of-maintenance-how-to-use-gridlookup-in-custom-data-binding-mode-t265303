using DevExpress.Web.Mvc;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridLookupCustomBinding.Controllers
{
    public class IncrementalFilteringController : Controller
    {
        //
        // GET: /IncrementalFiltering/
      

        
        public ActionResult GridLookupIncrementalFiltering()
        {
            return View();
        }
        
        public ActionResult GridLookupIncrementalFilteringPartial()
        {
            var viewModel = GridLookupExtension.GetViewModel("GridLookup");
            if (viewModel == null)
                viewModel = CreateGridLookupViewModel();
            return GridLookupCustomActionCore(viewModel);
        }

        public ActionResult GridLookupFilteringAction(GridLookupFilteringState filteringState)
        {
            var viewModel = GridLookupExtension.GetViewModel("GridLookup");
            viewModel.ApplyFilteringState(filteringState);
            return GridLookupCustomActionCore(viewModel);
        }
        public ActionResult GridLookupSortingAction(GridLookupColumnState column, bool reset)
        {
            var viewModel = GridLookupExtension.GetViewModel("GridLookup");
            viewModel.SortBy(column, reset);
            return GridLookupCustomActionCore(viewModel);
        }
        public ActionResult GridLookupPagingAction(GridLookupPagerState pager)
        {
            var viewModel = GridLookupExtension.GetViewModel("GridLookup");
            viewModel.Pager.Assign(pager);
            return GridLookupCustomActionCore(viewModel);
        }

        public ActionResult GridLookupCustomActionCore(GridLookupViewModel gridLookupModel)
        {
            gridLookupModel.ProcessCustomBinding(
                CustomBindingHandlers.GetDataRowCountIncrementalFiltering,
                CustomBindingHandlers.GetDataIncrementalFilteng,
                CustomBindingHandlers.GetRowValues
            );
            return PartialView("GridLookupIncrementalFilteringPartial", gridLookupModel);
        }

        static GridLookupViewModel CreateGridLookupViewModel()
        {
            var viewModel = new GridLookupViewModel();
            viewModel.KeyFieldName = "OrderID";
            viewModel.IncrementalFilteringMode = DevExpress.Web.IncrementalFilteringMode.Contains;
            viewModel.TextFormatString = "{0} {1} {2}";
            viewModel.KeyFieldName = "OrderID";
            viewModel.Columns.Add("OrderID");
            viewModel.Columns.Add("ShipName");
            viewModel.Columns.Add("ShipCity");
            viewModel.Columns.Add("OrderDate");
            viewModel.Pager.PageSize = 10;
            return viewModel;
        }
    }
}