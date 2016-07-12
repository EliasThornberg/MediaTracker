namespace TorrentTracker.Core.Entities.Common
{
    public abstract class Entity
    {
        public int Id { get; private set; }

        public override bool Equals(object obj)
        {
            var otherEntity = obj as Entity;
            if (ReferenceEquals(otherEntity,null))
                return false;

            if (ReferenceEquals(this, otherEntity))
                return true;

            if (GetType() != otherEntity.GetType())
                return false;

            if (Id == 0 || otherEntity.Id == 0)
                return false;

            return Id == otherEntity.Id;

        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a == null && b == null)
                return true;

            if (a == null || b == null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
