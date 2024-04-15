namespace PracticalTask.ClientUI.Api.Models.Responses;

public readonly record struct ApiResponse<TData>(
    TData? Data,
    bool IsFailed = false,
    string? ErrorMessage = null);