namespace Abudantia.Helpers
{
    public class OperationResult
    {
        public bool Result { get; set; }
        public string Message { get; set; } = null!;
        public string Error { get; set; } = null!;
        public OperationResult(bool result, string message = "", string error = "")
        {
            Result = result;
            Message = message;
            Error = error;
        }

        public static OperationResult OkResult(string message = "")
            => new OperationResult(true, message, string.Empty);
        public static OperationResult CreateFromThrow(Exception ex)
            => new OperationResult(false, string.Empty, ex.Message);

        public static OperationResult NotFound(string elementNotFound) 
            => new OperationResult(false, string.Empty, $"{elementNotFound} - Не найдено");
        public static OperationResult IsNull()
            => new OperationResult(false, string.Empty, "Объекта не существует");
    }
}
