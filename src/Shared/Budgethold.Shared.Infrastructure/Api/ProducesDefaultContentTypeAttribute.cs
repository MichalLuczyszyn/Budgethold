namespace Budgethold.Shared.Infrastructure.Api;

using Microsoft.AspNetCore.Mvc;

public class ProducesDefaultContentTypeAttribute : ProducesAttribute
{
    public ProducesDefaultContentTypeAttribute(Type type) : base(type)
    {
    }

    public ProducesDefaultContentTypeAttribute(params string[] additionalContentTypes) : base("application/json", additionalContentTypes)
    {
    }
}
