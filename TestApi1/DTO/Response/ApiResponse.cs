using System.Text.Json.Serialization;

namespace TestApi1.DTO.Response
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T? Result { get; set; }

        public ApiResponse(int code, string message, T? result)
        {
            Code = code;
            Message = message;
            Result = result;
        }
    }
}
