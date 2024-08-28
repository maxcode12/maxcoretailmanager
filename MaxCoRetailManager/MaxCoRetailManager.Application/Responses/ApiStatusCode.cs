namespace MaxCoRetailManager.Application.Responses;

public enum ApiStatusCode
{
    UserNotFound = 1,
    EmailNotVerified = 2,
    InvalidEmailPassword = 3,
    UserAlreadyExist = 4,
    DbError = 5,
    ExpiredToken = 6,
    InternalServer = 7,
    GeneralError = 8,
    IdentityNotCreatingUser = 9,
    ContentNotFound = 10,
    UserNoteActive = 11,
    ConfirmationTokenNotValid = 12,
    EmailAndMobileNotVerified = 13,
    MobileNotVerified = 14,
    UserDisabled = 15,
    UpdateFailed = 16,
    NotAllowed = 17

}
