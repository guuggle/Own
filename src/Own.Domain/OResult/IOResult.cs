using System.Collections.Generic;
using Own.Domain.OResult;

namespace Own.Domain.OResult
{
    public interface IOResult
    {
        List<OError> Errors { get; }
    }
}

