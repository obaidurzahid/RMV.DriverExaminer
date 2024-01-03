using RMV.DriverExaminer.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RMV.DriverExaminer.Service.Models
{
    public class ExamDetailsModel 
    {
        
        public int Id { get; set; }
        public string? DEId {  get; set; }
        public string? DEFullName { get; set; }
        public string? MasterNumber { get; set;}
        public string? OfficeLocation { get; set;}
        public string? LicenseClass { get; set; }
        public string? ResultStatus { get; set; }
    }
    public class PublicApisModel
    {
        public string count { get; set; }
        public List<ApiEntriesModel> entries { get; set; }
    }
    public class ApiEntriesModel
    {
        public string? API { get; set; }
        public string? Description { get; set; }
        public bool HTTPS { get; set; }
        public string? Cors { get; set; }
        public string? Link { get; set; }
        public string? Category { get; set; }
    }
}
