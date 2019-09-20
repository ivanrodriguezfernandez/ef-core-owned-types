using System.Collections.Generic;
using ef_core_owned_types.Infrastructure;

namespace ef_core_owned_types.Domain
{
    public class DashboardItem : ValueObject
    {
        public DashboardItem()
        {

        }
        public DashboardItem(string appViewId, Size size, Position position)
        {
            AppViewId = appViewId;
            Size = size ?? new Size(1, 1);
            Position = position ?? new Position(0, 0);
        }

        public string AppViewId { get; private set; }
        public Size Size { get; private set; }
        public Position Position { get; private set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return AppViewId;
            yield return Position.X;
            yield return Position.Y;
            yield return Size.Width;
            yield return Size.Height;
        }
    }
}