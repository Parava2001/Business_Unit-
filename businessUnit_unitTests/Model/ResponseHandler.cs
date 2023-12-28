// this class is used for providing ideas or methods about , ie 1 for handling the exception and other for handling the valid Responses




using businessUnit.Model;
using System;

namespace businessUnit.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception exception)  // method for 'FAILURE'
        {
            ApiResponse response = new ApiResponse();
            response.Code = "1";
            response.Message = "FAILURE";
            response.ResponseData = exception.Message;
            return response;

        }
        public static ApiResponse GetAppResponse(ResponseType type, object? contract) // "type" is what type of response is it and "contract"  is the data to pass to the API 
        {
            ApiResponse response = new ApiResponse { ResponseData = contract };
            switch (type)
            {
                case ResponseType.Success:
                    response.Code = "0";
                    response.Message = "SUCCESS";

                    break;
                case ResponseType.NotFound:
                    response.Code = "2";
                    response.Message = "NOT FOUND";
                    break;
            }
            return response;
        }
    }
}
