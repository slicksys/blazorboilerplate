using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SSDCPortal.Shared.Dto.Db
{
    public class Employee : BaseDto
    {
        [Key]
        public Guid EmployeeGUID { get; set; } //(uniqueidentifier, not null)
        public string EmployeePrefix { get; set; } //(varchar(5), not null)
        public string EmployeeFirstName { get; set; } //(varchar(20), not null)
        public string EmployeeLastName { get; set; } //(varchar(25), not null)
        public string EmployeeGroupName { get; set; } //(varchar(30), not null)
        public string StreetAddress1 { get; set; } //(varchar(45), not null)
        public string StreetAddress2 { get; set; } //(varchar(45), not null)
        public string CityName { get; set; } //(varchar(30), not null)
        public string StateName { get; set; } //(varchar(30), not null)
        public string StateAbbrev { get; set; } //(varchar(2), not null)
        public string ZipCode { get; set; } //(varchar(10), not null)
        [Required] 
        public string HomePhone { get; set; } //(varchar(24), not null)
        public string SecondPhone { get; set; } //(varchar(24), not null)
        [Required] 
        public string EmailAddress { get; set; } //(varchar(255), not null)
        public string MobilePhone { get; set; } //(varchar(24), not null)
        public string Pager { get; set; } //(varchar(50), not null)
        public string EmployeeSuffix { get; set; } //(varchar(20), not null)
        public string DEANumber { get; set; } //(varchar(30), not null)
        public string EmployeeVID { get; set; } //(varchar(5), not null)
        public string PracticeName { get; set; } //(varchar(50), not null)
        public DateTime CreateDateTime { get; set; } //(datetime, not null)
        public string CreateUserName { get; set; } //(varchar(30), not null)
        public string CreateWorkstationName { get; set; } //(varchar(30), not null)
    }

}
