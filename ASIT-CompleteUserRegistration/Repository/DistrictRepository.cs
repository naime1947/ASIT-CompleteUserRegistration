using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASIT_CompleteUserRegistration.DataAccess;
using ASIT_CompleteUserRegistration.Models;

namespace ASIT_CompleteUserRegistration.Repository
{
    public class DistrictRepository
    {
        public IEnumerable<SelectListItem> GetDistricts()
        {
            List<SelectListItem> districts = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Value = null,
                    Text = "-- Select Division First --"
                }
            };

            return districts;
        }


        public IEnumerable<SelectListItem> GetDistricts(int divisionId)
        {
            string sql = "SELECT * FROM Districts Where divisionId =" + divisionId;
            List<SelectListItem> districts = SqlDataAccess.LoadData<District>(sql)
                                                    .Select(n => new SelectListItem()
                                                    {
                                                        Value = n.DistrictId.ToString(),
                                                        Text = n.DistrictName
                                                    }).ToList();

            return new SelectList(districts,"Value","Text");
        }

        public string GetDistrictsById(int districtId)
        {
            string sql = "select * from districts where districtId =" + districtId;
            List<District> districts = SqlDataAccess.LoadData<District>(sql);

            return districts[0].DistrictName;
        }
    }
}