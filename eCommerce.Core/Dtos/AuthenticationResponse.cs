public record AuthenticationResponse
{
    public Guid UserID { get; init; }
    public string? PersonName { get; init; }
    public string? Email { get; init; }
    public string? Gender { get; init; }
    public string? Token { get; init; }
    public bool Success { get; init; }

    public AuthenticationResponse() { }

    public AuthenticationResponse(Guid userID, string? personName, string? email, string? gender, string? token, bool success)
    {
        UserID = userID;
        PersonName = personName;
        Email = email;
        Gender = gender;
        Token = token;
        Success = success;
    }
}