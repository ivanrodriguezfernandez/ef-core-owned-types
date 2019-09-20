using System.Collections.Generic;
using ef_core_owned_types.Infrastructure;

namespace ef_core_owned_types.Domain
{
    public class Size : ValueObject
    {

        public Size(int width = 0, int height = 0)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Width;
            yield return Height;
        }
    }
}