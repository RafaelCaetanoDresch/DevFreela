namespace DevFreela.Core.DTOs;

public record UserDatailsDto(Guid Id, string FullName, string Email, DateTime BirthDate, bool Active);