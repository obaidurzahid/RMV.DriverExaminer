
using RMV.DriverExaminer.Domain.Common;

namespace RMV.DriverExaminer.Service.Utilities
{
    public static class CommonLogics
    {
        internal static Response GetAddResponse(int result, string entityName)
        {
            var response = new Response { IsSuccess = result > 0, Message = result > 0 ? entityName + " save sucessfuly" : "Error in save" };
            return response;
        }
        internal static Response GetUpdateResponse(int result, string entityName)
        {
            var response = new Response { IsSuccess = result > 0, Message = result > 0 ? entityName + " updated sucessfuly" : "Error in update" };
            return response;
        }
        internal static Response GetDeleteResponse(int result, string entityName)
        {
            var response = new Response { IsSuccess = result > 0, Message = result > 0 ? entityName + " deleted sucessfuly" : "Error in delete" };
            return response;
        }


    }
}
