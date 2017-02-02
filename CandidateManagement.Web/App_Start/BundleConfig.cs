using System.Web;
using System.Web.Optimization;

namespace CandidateManagement.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/jqwidgets").Include(
                        "~/scripts/jqwidgets/jqx-all.js",
                        "~/scripts/jqwidgets/jqxangular.js",
                        "~/scripts/jqwidgets/jqxdraw.js",
                        "~/scripts/jqwidgets/jqxbargauge.js",
                        "~/scripts/jqwidgets/jqxbulletchart.js",
                        "~/scripts/jqwidgets/jqxbuttongroup.js",
                        "~/scripts/jqwidgets/jqxbuttons.js",
                        "~/scripts/jqwidgets/jqxcalendar.js",
                        "~/scripts/jqwidgets/jqxchart.core.js",
                        "~/scripts/jqwidgets/jqxchart.js",
                        "~/scripts/jqwidgets/jqxchart.annotations.js",
                        "~/scripts/jqwidgets/jqxchart.api.js",
                        
                        "~/scripts/jqwidgets/jqxchart.rangeselector.js",
                        "~/scripts/jqwidgets/jqxchart.waterfall.js",
                        "~/scripts/jqwidgets/jqxcheckbox.js",
                        "~/scripts/jqwidgets/jqxcolorpicker.js",
                        "~/scripts/jqwidgets/jqxcombobox.js",
                        "~/scripts/jqwidgets/jqxcomplexinput.js",
                        "~/scripts/jqwidgets/jqxcore.js",
                        "~/scripts/jqwidgets/jqxdata.export.js",
                        "~/scripts/jqwidgets/jqxdata.js",
                        "~/scripts/jqwidgets/jqxdatatable.js",
                        "~/scripts/jqwidgets/jqxdate.js",
                        "~/scripts/jqwidgets/jqxdatetimeinput.js",
                        "~/scripts/jqwidgets/jqxdocking.js",
                        "~/scripts/jqwidgets/jqxdockinglayout.js",
                        "~/scripts/jqwidgets/jqxdockpanel.js",
                        "~/scripts/jqwidgets/jqxdragdrop.js",
                        
                        "~/scripts/jqwidgets/jqxdropdownbutton.js",
                        "~/scripts/jqwidgets/jqxdropdownlist.js",
                        "~/scripts/jqwidgets/jqxeditor.js",
                        "~/scripts/jqwidgets/jqxexpander.js",
                        "~/scripts/jqwidgets/jqxfileupload.js",
                        "~/scripts/jqwidgets/jqxformattedinput.js",
                        "~/scripts/jqwidgets/jqxgauge.js",
                        "~/scripts/jqwidgets/jqxgrid.js",
                        "~/scripts/jqwidgets/jqxgrid.aggregates.js",
                        "~/scripts/jqwidgets/jqxgrid.columnsreorder.js",
                        "~/scripts/jqwidgets/jqxgrid.columnsresize.js",
                        "~/scripts/jqwidgets/jqxgrid.edit.js",
                        "~/scripts/jqwidgets/jqxgrid.export.js",
                        "~/scripts/jqwidgets/jqxgrid.filter.js",
                        "~/scripts/jqwidgets/jqxgrid.grouping.js",
                        "~/scripts/jqwidgets/jqxgrid.pager.js",
                        "~/scripts/jqwidgets/jqxgrid.selection.js",
                        "~/scripts/jqwidgets/jqxgrid.sort.js",
                        "~/scripts/jqwidgets/jqxgrid.storage.js",
                        "~/scripts/jqwidgets/jqxinput.js",
                        "~/scripts/jqwidgets/jqxkanban.js",
                        "~/scripts/jqwidgets/jqxknob.js",
                        "~/scripts/jqwidgets/jqxknockout.js",
                        "~/scripts/jqwidgets/jqxlayout.js",
                        "~/scripts/jqwidgets/jqxlistbox.js",
                        "~/scripts/jqwidgets/jqxlistmenu.js",
                        "~/scripts/jqwidgets/jqxloader.js",
                        "~/scripts/jqwidgets/jqxmaskedinput.js",
                        "~/scripts/jqwidgets/jqxmenu.js",
                        "~/scripts/jqwidgets/jqxnavbar.js",
                        "~/scripts/jqwidgets/jqxnavigationbar.js",
                        "~/scripts/jqwidgets/jqxnotification.js",
                        "~/scripts/jqwidgets/jqxnumberinput.js",
                        "~/scripts/jqwidgets/jqxpanel.js",
                        "~/scripts/jqwidgets/jqxpasswordinput.js",
                        "~/scripts/jqwidgets/jqxpopover.js",
                        "~/scripts/jqwidgets/jqxprogressbar.js",
                        "~/scripts/jqwidgets/jqxradiobutton.js",
                        "~/scripts/jqwidgets/jqxrangeselector.js",
                        "~/scripts/jqwidgets/jqxrating.js",
                        "~/scripts/jqwidgets/jqxresponse.js",
                        "~/scripts/jqwidgets/jqxresponsivepanel.js",
                        "~/scripts/jqwidgets/jqxribbon.js",
                        "~/scripts/jqwidgets/jqxscheduler.api.js",
                        "~/scripts/jqwidgets/jqxscheduler.js",
                        "~/scripts/jqwidgets/jqxscrollbar.js",
                        "~/scripts/jqwidgets/jqxscrollview.js",
                        "~/scripts/jqwidgets/jqxslider.js",
                        "~/scripts/jqwidgets/jqxsortable.js",
                        "~/scripts/jqwidgets/jqxsplitter.js",
                        "~/scripts/jqwidgets/jqxswitchbutton.js",
                        "~/scripts/jqwidgets/jqxtabs.js",
                        "~/scripts/jqwidgets/jqxtagcloud.js",
                        "~/scripts/jqwidgets/jqxtextarea.js",
                        "~/scripts/jqwidgets/jqxtoolbar.js",
                        "~/scripts/jqwidgets/jqxtooltip.js",
                        "~/scripts/jqwidgets/jqxtouch.js",
                        "~/scripts/jqwidgets/jqxtree.js",
                        "~/scripts/jqwidgets/jqxtreegrid.js",
                        "~/scripts/jqwidgets/jqxtreemap.js",
                        "~/scripts/jqwidgets/jqxvalidator.js",
                        "~/scripts/jqwidgets/jqxwindow.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/jqxstyles").Include(
                        "~/content/jqwidgets/jqx.base.css",
                        "~/content/jqwidgets/jqx.bite.css",
                        "~/content/jqwidgets/jqx.bootstrap.css",
                        "~/content/jqwidgets/jqx.metro.css",
                        "~/content/jqwidgets/jqx.web.css",
                        "~/content/jqwidgets/bootstrap.css",
                        "~/content/jqwidgets/site.css"
                        ));

        }

    }
}
