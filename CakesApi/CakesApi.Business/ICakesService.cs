using CakesApi.Entities;
using System.Collections.Generic;

namespace CakesApi.Business
{
    public interface ICakesService
    {
        public Cake Create(Cake cake);
        public Cake Get(int id);
        public Cake Get(string name);
        public IEnumerable<Cake> GetAll();
        public void Delete(int id);
    }
}
