using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace vad_core.Validators
{
    public class AudioExtensionValidator : IValidator
    {
        public bool Validate(string toValid)
        {
            var supportedTypes = new[] { ".wav", ".mp3" };
            var fileExt = System.IO.Path.GetExtension(toValid);
            if (supportedTypes.Contains(fileExt))
                return true;
            else
                return false;
        }


    }
}
