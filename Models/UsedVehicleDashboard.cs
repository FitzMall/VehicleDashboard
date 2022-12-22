using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleDashboard.Models
{
    public class UsedVehicleDashboard
    {
        public List<CSV_vehicleUSED> AllUsedInventory { get; set; }
        public List<AllInventory> WebsiteUsedInventory { get; set; }
        public string Location { get; set; }
    }

    public class CSV_vehicleUSED
    {
        public int USEDID { get; set; }
        public string branch { get; set; }
        public string stk { get; set; }
        public string yr { get; set; }
        public string carline { get; set; }
        public string body { get; set; }
        public string vin { get; set; }
        public string vin6 { get; set; }
        public int status { get; set; }
        public string color { get; set; }
        public string intcolor { get; set; }
        public int miles { get; set; }
        public string cyl { get; set; }
        public string slscode { get; set; }
        public string cond { get; set; }
        public DateTime md_exp_dte { get; set; }
        public decimal ainv_amt { get; set; }
        public decimal inv_amt { get; set; }
        public decimal inv_amt30 { get; set; }
        public decimal inv_amt30c { get; set; }
        public decimal inv_amt60 { get; set; }
        public decimal inv_amt60c { get; set; }
        public decimal inv_amt90 { get; set; }
        public decimal inv_amt90c { get; set; }
        public decimal inv_amt91 { get; set; }
        public decimal inv_amt91c { get; set; }
        public string days { get; set; }
        public int daysn { get; set; }
        public decimal list_amt { get; set; }
        public string make { get; set; }
        public string loc { get; set; }
        public string DRloc { get; set; }
        public string trans { get; set; }
        public string tag { get; set; }
        public DateTime rec_date { get; set; }
        public DateTime pur_date { get; set; }
        public DateTime created_date { get; set; }
        public string mall { get; set; }
        public string automall { get; set; }
        public string automalla { get; set; }
        public string access1 { get; set; }
        public string access2 { get; set; }
        public string appraiser { get; set; }
        public decimal init_acv { get; set; }
        public decimal high_ret { get; set; }
        public string nada_edi { get; set; }
        public string edition { get; set; }
        public int daysinv { get; set; }
        public string acc_code { get; set; }
        public string location { get; set; }
        public decimal s_cost { get; set; }
        public DateTime SALE_DATE { get; set; }
        public string MEMO1_CAT { get; set; }
        public string MEMO2_CAT { get; set; }
        public string trns { get; set; }
        public string rad { get; set; }
        public string ps { get; set; }
        public string pb { get; set; }
        public string ac { get; set; }
        public string pw { get; set; }
        public string pl { get; set; }
        public string psu { get; set; }
        public string pse { get; set; }
        public string tlt { get; set; }
        public string crs { get; set; }
        public string ab { get; set; }
        public string rent { get; set; }
        public string ddr { get; set; }
        public string cert { get; set; }
        public string title { get; set; }
        public string lien { get; set; }
        public string scflag { get; set; }
        public decimal loan_amt { get; set; }
        public string rb { get; set; }
        public DateTime csvupdate { get; set; }

    }

    public class AllInventory
    {
        public int V_ID { get; set; }
        public string V_styleid { get; set; }
        public string V_xrefid { get; set; }
        public string V_useoptions { get; set; }
        public string V_stock { get; set; }
        public string V_nu { get; set; }
        public string V_loc { get; set; }
        public string V_mall { get; set; }
        public int V_DeptId { get; set; }
        public string V_State { get; set; }
        public string V_Year { get; set; }
        public string V_MakeCode { get; set; }
        public string V_MakeName { get; set; }
        public string V_DivisionName { get; set; }
        public string V_ModelName { get; set; }
        public string V_StyleCode { get; set; }
        public string V_StyleName { get; set; }
        public string v_MarketClass { get; set; }
        public string V_extcolor { get; set; }
        public string V_genextcolor { get; set; }
        public string V_intcolor { get; set; }
        public int V_Miles { get; set; }
        public int V_daysinv { get; set; }
        public string V_Vin { get; set; }
        public int V_Status { get; set; }
        public decimal V_int_price { get; set; }
        public decimal V_del_price { get; set; }
        public decimal V_inv_price { get; set; }
        public decimal V_msrp_price { get; set; }
        public decimal V_kbb_price { get; set; }
        public string V_kbb_edition { get; set; }
        public int V_nfeats { get; set; }
        public string V_certified { get; set; }
        public string v_clearance_etc { get; set; }
        public string V_oneowner { get; set; }
        public int V_piccount { get; set; }
        public string V_MISC { get; set; }
        public decimal v_cramt { get; set; }
        public decimal v_fdamt { get; set; }
        public decimal v_holdback { get; set; }
        public string v_trans { get; set; }
        public string v_matrix { get; set; }
        public string v_fuel { get; set; }
        public DateTime v_fdstart { get; set; }
        public DateTime v_fdend { get; set; }
        public DateTime v_crstart { get; set; }
        public DateTime v_crend { get; set; }
    }
}