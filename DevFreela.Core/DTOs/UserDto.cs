namespace DevFreela.Core.DTOs;

public record UserDto(Guid Id, string FullName, string Email, bool Active);