namespace Shared.Errors.Common
{
    public class InvalidPasswordOrLoginError : CommonError
    {
        public override Error Error =>
            Error.NotFound(null, "Invalid password or login");
    }
}
