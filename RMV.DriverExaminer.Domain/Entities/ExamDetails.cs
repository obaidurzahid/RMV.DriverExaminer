using RMV.DriverExaminer.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace RMV.DriverExaminer.Domain.Entities
{
    public class ExamDetails  : AuditableEntity
    {
        [Key]
        public int Id { get; set; }
        public string? DEId {  get; set; }
        public string? DEName { get; set; }
        public string? MasterNumber { get; set;}
        public string? OfficeLocation { get; set;}
        public string? LicenseClass { get; set; }
        public string? ResultStatus { get; set; }
    }
    public class PublicApis
    {
        public string count { get; set; }
        public List<ApiEntries> entries { get; set; }
    }
    public class ApiEntries
    {
        public string count { get; set; }
        public string entries { get; set; }
        public string? API { get; set; }
        public string? Description { get; set; }
        public bool HTTPS { get; set; }
        public string? Cors { get; set; }
        public string? Link { get; set; }
        public string? Category { get; set; }
    }
}
