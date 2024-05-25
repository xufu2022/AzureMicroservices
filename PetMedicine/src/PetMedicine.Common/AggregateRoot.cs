namespace PetMedicine.Common
{
    public abstract class AggregateRoot
    {
        protected readonly List<IDomainEvent> changes=new();
        public int Version { get; private set; } = -1;

        protected AggregateRoot()
        {
        }

        public IEnumerable<IDomainEvent> GetChanges()
        {
            return changes.AsReadOnly();
        }

        public void ClearChanges()
        {
            changes.Clear();
        }

        protected void ApplyDomainEvent(IDomainEvent domainEvent)
        {
            ChangeStateByUsingDomainEvent(domainEvent);
            ValidateState();
            changes.Add(domainEvent);
        }

        public void Load(IEnumerable<IDomainEvent> history)
        {
            foreach (var e in history)
            {
                ApplyDomainEvent(e);
                Version++;
            }
            ClearChanges();
        }

        protected abstract void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent);
        protected abstract void ValidateState();
    }
}