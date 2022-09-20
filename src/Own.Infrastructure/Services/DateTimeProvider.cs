using System;
using Own.Application.Common.Interfaces.Services;

namespace Own.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now; // TODO: utcNOW?
    }
}