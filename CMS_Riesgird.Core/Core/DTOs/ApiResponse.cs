namespace CMS_Riesgird.Core.Core.DTOs;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public ApiResponse(T data, bool success = true, string message = "")
    {
        Success = success;
        Message = message;
        Data = data;
    }

    public ApiResponse(bool success, string message = "")
    {
        Success = success;
        Message = message;
        Data = default;
    }
}
