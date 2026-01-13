namespace V0_SimpleApi.Model
{
    public class RegisterResponse
    {
        public bool Success { get; }
        public string Message { get; }

        public RegisterResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
