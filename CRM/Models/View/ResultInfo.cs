namespace CRM.Models.View
{
    public class ResultInfo
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; } = string.Empty;

        public dynamic Data { get; set; }

        public static ResultInfo Success<T>(string message, T data = default)
        {
            return new ResultInfo()
            {
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }

        public static ResultInfo Success(string message)
        {
            return new ResultInfo()
            {
                IsSuccess = true,
                Message = message,
            };
        }

        public static ResultInfo Fail<T>(string message, T data = default)
        {
            return new ResultInfo()
            {
                IsSuccess = false,
                Message = message,
                Data = data
            };
        }

        public static ResultInfo Fail(string message)
        {
            return new ResultInfo()
            {
                IsSuccess = false,
                Message = message,
            };
        }
    }
}
