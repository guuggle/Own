using System;
namespace Own.Application.Common.Interfaces.Services
{
    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}