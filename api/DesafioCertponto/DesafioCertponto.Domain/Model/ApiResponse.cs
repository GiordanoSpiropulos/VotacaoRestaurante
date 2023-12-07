﻿namespace DesafioCertponto.Domain.Model
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }

        public ApiResponse(bool success, T data, string errorMessage = null)
        {
            Success = success;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static ApiResponse<T> SuccessResponse(T data)
        {
            return new ApiResponse<T>(true, data);
        }

        public static ApiResponse<T> ErrorResponse(string errorMessage)
        {
            return new ApiResponse<T>(false, default, errorMessage);
        }
    }
}
