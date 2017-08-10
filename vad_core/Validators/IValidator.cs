using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Validators
{
    public interface IValidator
    {
        bool Validate(string toValid);
    }
}
