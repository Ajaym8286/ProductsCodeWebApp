using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductsCodeWebApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProductsCodeWebApp.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index(ProductService dr)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconn"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string s1 = "Select * from [dbo].[deltaproducts]";
            SqlCommand sqlcomm = new SqlCommand(s1);
            sqlcomm.Connection = sqlconn;
            sqlconn.Open();
            SqlDataReader sdr = sqlcomm.ExecuteReader();
            List<ProductService> objmodel = new List<ProductService>();
            if (sdr.HasRows)
            {
                while(sdr.Read())
                {
                    var details = new ProductService();
                    details.Product_ID = sdr["Product_ID"].ToString();
                    details.Name = sdr["Name"].ToString();
                    details.Description = sdr["Description"].ToString();
                    objmodel.Add(details);
                }
                dr.ProductsDetails = objmodel;
                sqlconn.Close();

            }
            return View("Index",dr);
        }
    }
}