using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleDashboard.Models
{
 
    
    public class NewVehicleDashboard
    {
        public List<CSV_vehicleNew> AllNewInventory { get; set; }
        public List<AllInventory> WebsiteNewInventory { get; set; }
        public List<VehicleData> VehicleData { get; set; }
        public string Location { get; set; }
        public List<PhotosByVin> Photos { get; set; }
    }

    public class CSV_vehicleNew
    {
        public int ncid { get; set; }
        public string Branch { get; set; }
        public string LOC { get; set; }
        public string MALL { get; set; }
        public string automall { get; set; }
        public string automalla { get; set; }
        public string stk_no { get; set; }
        public string year { get; set; }
        public string mk_code { get; set; }
        public string MAKE { get; set; }
        public string CARLINE { get; set; }
        public string mdl_desc { get; set; }
        public string clr_code { get; set; }
        public string clr_desc { get; set; }
        public decimal memo1 { get; set; }
        public string pkg_code { get; set; }
        public int status { get; set; }
        public string model_no { get; set; }
        public string vin { get; set; }
        public string DRdays { get; set; }
        public string days { get; set; }
        public decimal flr_plan { get; set; }
        public decimal coded_cost { get; set; }
        public decimal list_amt { get; set; }
        public string lic_fee { get; set; }
        public decimal invoice { get; set; }
        public decimal msrp { get; set; }
        public decimal lred_tag { get; set; }
        public decimal red_tag { get; set; }
        public decimal int_price { get; set; }
        public string matrix { get; set; }
        public string markuplev { get; set; }
        public decimal markupit { get; set; }
        public decimal markup { get; set; }
        public decimal markup30 { get; set; }
        public decimal markup60 { get; set; }
        public decimal markup90 { get; set; }
        public decimal cramt { get; set; }
        public string crstart { get; set; }
        public string crend { get; set; }
        public string crexp { get; set; }
        public string crprog { get; set; }
        public decimal fdamt { get; set; }
        public decimal fdmamt { get; set; }
        public decimal fdxamt { get; set; }
        public string fdstart { get; set; }
        public string fdexp { get; set; }
        public string fdend { get; set; }
        public string fdprog { get; set; }
        public decimal ipr { get; set; }
        public string addate { get; set; }
        public string moddate { get; set; }
        public string upuser { get; set; }
        public string lastactdt { get; set; }
        public string msrpX { get; set; }
        public string mi { get; set; }
        public string spec_fin { get; set; }
        public string addl_fee { get; set; }
        public string cust_msg1 { get; set; }
        public string cust_msg2 { get; set; }
        public string cust_msg3 { get; set; }
        public string cust_msg4 { get; set; }
        public decimal inv030 { get; set; }
        public decimal inv3160 { get; set; }
        public decimal inv6190 { get; set; }
        public decimal inv91 { get; set; }
        public decimal invtot { get; set; }
        public string spec_fin_st { get; set; }
        public string spec_fin_exp { get; set; }
        public string lowest_rate { get; set; }
        public string lowest_rate24 { get; set; }
        public string lowest_rate36 { get; set; }
        public string lowest_rate48 { get; set; }
        public string lowest_rate60 { get; set; }
        public string lowest_rate72 { get; set; }
        public string lowest_rate84 { get; set; }
        public string lieu_rebate { get; set; }
        public decimal ncincentiveamt { get; set; }
        public string ncincentivestart { get; set; }
        public string ncincentiveend { get; set; }
        public decimal cincentiveamt {get; set;}
	    public string cincentivestart { get; set; }
	    public string cincentiveend { get; set; }
	    public string rimastKEY { get; set; }
        public DateTime lastupdate { get; set; }

        public int Photos { get; set; }
    }
}