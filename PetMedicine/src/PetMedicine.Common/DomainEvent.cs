﻿namespace PetMedicine.Common
{
    public class DomainEvent<T>
    {
        private List<Action<T>> Actions { get; } = new ();

        public void Register(Action<T> callback)
        {
            if (Actions.Exists(a => a.Method == callback.Method))
            {
                return;
            }

            Actions.Add(callback);
        }

        public void Publish(T args)
        {
            foreach (Action<T> item in Actions)
            {
                item.Invoke(args);
            }
        }
    }
}