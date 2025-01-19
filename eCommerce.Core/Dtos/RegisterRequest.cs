namespace eCommerce.Core.Dtos
{
    public record RegisterRequest(
        string? PersonName,
        string? Email,
        string? Password,
        GenderOption? Gender
        );
}
