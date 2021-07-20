using NetHomeTest.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NetHomeTest.Web
{
    public partial class Default : System.Web.UI.Page
    {
        static String location = HttpContext.Current.Server.MapPath("data.csv");

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            IDataProcessor processor = new CSVDataProcessor(location);
            string search = txtSearch.Text.Trim();
            gridView1.DataSource = processor.Populate(search);
            gridView1.DataBind();
        }

        protected void BtnInsert_Click(object sender, EventArgs e)
        {            
            IDataProcessor processor = new CSVDataProcessor(location);
            processor.Generate(100000);

            LoadData();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {          
            LoadData();
        }

        protected void gridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView1.PageIndex = e.NewPageIndex;
            LoadData();
        }
    }
}