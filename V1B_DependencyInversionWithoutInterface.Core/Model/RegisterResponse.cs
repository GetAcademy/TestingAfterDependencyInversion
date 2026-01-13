namespace V1B_DependencyInversionWithoutInterface.Core.Model
{
    public class RegisterResponse
    {
        public bool Success { get; }
        public string Message { get; }

        public User UserToBeAdded {get;}

        public RegisterResponse(bool success, string message, User userToBeAdded = null)
        {
            Success = success;
            Message = message;
            UserToBeAdded = userToBeAdded;
        }
    }
}
