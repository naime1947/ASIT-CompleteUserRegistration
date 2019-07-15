using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASIT_CompleteUserRegistration.DataAccess;
using ASIT_CompleteUserRegistration.Models;

namespace ASIT_CompleteUserRegistration.Repository
{
    public class DivisionRepository
    {
        public IEnumerable<SelectListItem> GetDivisions()
        {
            string sql = "SELECT * FROM DIVISIONS";

            List<SelectListItem> divisions = SqlDataAccess.LoadData<Division>(sql)
                                            .Select(n => new SelectListItem
                                            {Value = n.DivisionId.ToString(),
                                            Text = n.DivisionName.ToString()}).ToList();

            var divisionTrip = new SelectListItem
            {
                Value = null,
                Text = "-- Select Division --"
            };

            divisions.Insert(0,divisionTrip);
            return new SelectList(divisions,"Value","Text");

        }

        public string GetDivision(int divisionId)
        {
            string sql = "select divisionName from divisions where divisionid =" + divisionId;
            var divisions = SqlDataAccess.LoadData<Division>(sql);

            return divisions[0].DivisionName;
        }
    }
}