using Own.Domain.OResult;

namespace Own.Domain.Errors
{
    public static class Errors
    {
        public static class General
        {
            public static OError NotFound => OError.NotFound();
        }
        public static class User
        {
            public static OError EmailIsTaken => OError.Validation(
                code: "User.EmailIsTaken",
                description: "Email is already in use.");
        }
    }
}