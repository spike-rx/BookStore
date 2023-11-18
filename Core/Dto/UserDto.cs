namespace BookStore.Core.Dto;

public record NewUserDto(string Username, string Email, string Password);

public record LoginUserDto(string Email, string Password);

public record UpdatedUserDto(string? Username, string? Email, string? Bio, string? Image, string? Password);

public record UserDto(string Username, string Email, string Token, string Bio, string Image);