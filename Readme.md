<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/GridLookupCustomBinding/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/GridLookupCustomBinding/Controllers/HomeController.vb))
* [IncrementalFilteringController.cs](./CS/GridLookupCustomBinding/Controllers/IncrementalFilteringController.cs) (VB: [IncrementalFilteringController.vb](./VB/GridLookupCustomBinding/Controllers/IncrementalFilteringController.vb))
* [MultiSelectController.cs](./CS/GridLookupCustomBinding/Controllers/MultiSelectController.cs) (VB: [MultiSelectController.vb](./VB/GridLookupCustomBinding/Controllers/MultiSelectController.vb))
* **[CustomBindingModel.cs](./CS/GridLookupCustomBinding/Models/CustomBindingModel.cs) (VB: [CustomBindingModel.vb](./VB/GridLookupCustomBinding/Models/CustomBindingModel.vb))**
* [GridLookupIncrementalFilteringPartial.cshtml](./CS/GridLookupCustomBinding/Views/IncrementalFiltering/GridLookupIncrementalFilteringPartial.cshtml)
* [GridLookupMultiSelectPartial.cshtml](./CS/GridLookupCustomBinding/Views/MultiSelect/GridLookupMultiSelectPartial.cshtml)
<!-- default file list end -->
# How to use GridLookup in Custom Data Binding mode
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t265303/)**
<!-- run online end -->


<p>This example illustrates what functionality is required to use GridLookup in <a href="https://documentation.devexpress.com/#AspNet/CustomDocument14374">Custom Data Binding</a> Mode <br><br>The following delegates are required: </p>
<p><a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewCustomBindingGetDataHandlertopic">GridViewCustomBindingGetDataHandler</a><a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewCustomBindingGetDataRowCountHandlertopic"> <br>GridViewCustomBindingGetDataRowCountHandler</a> <br><a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewCustomBindingGetRowValuesHandlertopic">GridViewCustomBindingGetRowValuesHandler</a> </p>
<p><br>The following <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebMvcGridViewOperationTypeEnumtopic">GridViewOperationTypes</a>  are required<br>Paging<br>Sorting <br>Filtering (for Incremental Filtering)</p>

<br/>


