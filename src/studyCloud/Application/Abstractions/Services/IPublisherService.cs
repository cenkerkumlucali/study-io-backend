using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Abstractions.Services;

public interface IPublisherService
{
    Task<Publisher> AddAsync(Publisher publisher, IFormFileCollection files);
    Task<Publisher> UpdateAsync(Publisher publisher, IFormFileCollection files);
}