using System.Collections.Generic;

namespace PersonagemApp.Services
{
    public class ServiceBase<T>
    {
        private readonly List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }
    }
}
