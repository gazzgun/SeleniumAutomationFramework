using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomationFramework.PageObjects.Model
{
    public class Customer
    {
        public string number { get;set; }
        public string name { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string country_region { get; set; }
        public string phoneNumber { get; set; }
        public string searchName { get; set; }
        public string creaditLimit { get; set; }
        public string salePersonCode { get; set; }
        public string responsibilityCenter { get; set; }
        public string serviceZoneCode { get; set; }
        public string email { get; set; }
        public string homePageURL { get; set; }
        public string icPartnerCode { get; set; }
        public string applicationMethod { get; set; }
        public string partnerType { get; set; }
        public string paymentTerms { get; set; }
        public string paymentMethods { get; set; }
        public string reminderTerms { get; set; }
        public string chargeTermCode { get; set; }
        public string cashFlowPayment { get; set; }
        public string locationCode { get; set; }
        public string shippingMethod { get; set; }
        public string shippingAgent { get; set; }
        public string baseCalendarCode { get; set; }
        public string currencyCode { get; set; }
        public string languageCode { get; set; }

        public void setCustomerDetails(string username)
        {
            using (CsvReader csv =
                   new CsvReader(new StreamReader(@"C:\Users\TechTeam\Desktop\"+ username + ".csv"), true))
            {
                while (csv.ReadNextRecord())
                {
                        number = csv[0];
                        name = csv[1];
                        address = csv[2];
                        address2 = csv[3];
                        postcode = csv[4];
                        city = csv[5];
                        country_region = csv[6];
                        phoneNumber = csv[7];
                        searchName = csv[8];
                        creaditLimit = csv[9];
                        salePersonCode = csv[10];
                        responsibilityCenter = csv[11];
                        serviceZoneCode = csv[12];
                        email = csv[13];
                        homePageURL = csv[14];
                        icPartnerCode = csv[15];
                        applicationMethod = csv[16];
                        partnerType = csv[17];
                        paymentTerms = csv[18];
                        paymentMethods = csv[19];
                        reminderTerms = csv[20];
                        chargeTermCode = csv[21];
                        cashFlowPayment = csv[22];
                        locationCode = csv[23];
                        shippingMethod = csv[24];
                        shippingAgent = csv[25];
                        baseCalendarCode = csv[26];
                        currencyCode = csv[27];
                        languageCode = csv[28];
                }
            }
        }
    }
}
