using System.Collections.Generic;
using ef_core_owned_types.Infrastructure;

namespace ef_core_owned_types.Domain
{
    public class Position : ValueObject
    {
        public Position(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return X;
            yield return Y;
        }
    }
}