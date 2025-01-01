
using System.Net;

namespace AuthZero.Shared.Models;

/// <summary>
/// The ApiResponse class is a generic class that is used to return responses from the API
/// </summary>
/// <typeparam name="T">The type of data that is being returned</typeparam>
public class ApiResponse<T>
{
    public int? StatusCode { get; set; }
    public T? Data { get; set; }
    

    /// <summary>
    /// Initializes a new instance of the ApiResponse class with the status code and data provided.
    /// </summary>
    /// <param name="statusCode">The status code of the response</param>
    /// <param name="data">The data to be returned</param>
    public ApiResponse(int? statusCode, T? data)
    {
        StatusCode = statusCode;
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the ApiResponse class with the status code and data provided.
    /// </summary>
    /// <param name="statusCode">The status code of the response. The <see cref="HttpStatusCode"/> enum is used to provide the status code</param>
    /// <param name="data">The data to be returned</param>
    public ApiResponse(HttpStatusCode statusCode, T? data)
    {
        StatusCode = (int)statusCode;
        Data = data;
    }



    /// <summary>
    /// Returns a response with a status code of 200 (OK) and the data provided
    /// </summary>
    /// <param name="data">The data to be returned</param>
    /// <returns></returns>
    public static ApiResponse<T> Success(T data)
    {
        return new ApiResponse<T>(HttpStatusCode.OK, data);
    }

    /// <summary>
    /// Returns a response with a status code of Created (201) and the data provided
    /// </summary>
    /// <param name="data">The data to be returned</param>
    /// <returns></returns>
    public static ApiResponse<T> Created(T data)
    {
        return new ApiResponse<T>(HttpStatusCode.Created, data);
    }


    /// <summary>
    /// This method returns a response with a status code of 204 (No Content) and no data
    /// </summary>
    /// <returns></returns>
    public static ApiResponse<T> NoContent()
    {
        return new ApiResponse<T>(HttpStatusCode.NoContent, default);
    }


}