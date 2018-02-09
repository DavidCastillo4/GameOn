using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using slnGameOn.db;
using slnGameOn.Models;

namespace slnGameOn.Controllers
{
	public class GameOnController : Controller
	{
		public ActionResult Browse()
		{
			return View();
		}


		public ActionResult Cart()
		{
			return View();
		}
		public ActionResult OrderHistory()
		{
			return View();
		}
		public ActionResult Account()
		{
			int CustomerId = 4;
			string Qry = "spGetAccountInfo @CustomerId=" + CustomerId.ToString();
			DataSet ds = GetData.ReturnDataSet(Qry);
			DataTable dt = ds.Tables[0], dt2 = ds.Tables[1];
			var oc = new mCustomer(CustomerId);
			oc.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
			oc.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
			oc.Gender = ds.Tables[0].Rows[0]["Gender"].ToString();
			oc.DOB = ds.Tables[0].Rows[0]["DOB"].ToString();
			oc.MaritalStatus = ds.Tables[0].Rows[0]["MaritalStatus"].ToString();
			oc.EmailId = ds.Tables[0].Rows[0]["EmailId"].ToString();
			oc.Email = ds.Tables[0].Rows[0]["Email"].ToString();
			oc.AddressId = ds.Tables[0].Rows[0]["AddressId"].ToString();
			oc.Address = ds.Tables[0].Rows[0]["Address"].ToString();
			oc.CityStateZip = ds.Tables[0].Rows[0]["CityStateZip"].ToString();
			oc.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
			foreach (DataRow r in dt2.Rows)
			{
				oc.Phone.Add(new mPhone { PhoneId = Convert.ToInt32(r["PhoneId"]), TypeId = Convert.ToInt32(r["PhoneTypeId"]), Type = r["PhoneType"].ToString(), Phone = r["Phone"].ToString() });
			}
			ds.Clear();
			return View(oc);			
		}

		[HttpPost]
		public ActionResult Account(string btSubmit)
		{
			string Ctr = "";
			var ModelCust = new mCustomer(6);	
			return View("Account", ModelCust);
		}


		[HttpPost]
		public ActionResult Browse(string btSubmit)
		{
			var ModelCust = new mCustomer(6);			
			return View("Cart", ModelCust);
		}










	}
}