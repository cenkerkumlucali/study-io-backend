namespace Application.Abstractions.Pipelines.Authorization;

public interface ISecuredRequest
{
    public string[] Roles { get; }
}