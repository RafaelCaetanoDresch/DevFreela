namespace DevFreela.Core.DTOs;

public record ProjectDetailDto(Guid Id,
                               string Title,
                               string Description,
                               decimal TotalCost,
                               DateTime? StartedAt,
                               DateTime? FinishedAt,
                               string ClienteFullName,
                               string? FreelancerFullName);

