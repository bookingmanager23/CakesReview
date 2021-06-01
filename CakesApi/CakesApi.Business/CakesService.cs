using CakesApi.Database;
using CakesApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CakesApi.Business
{
    public class CakesService : ICakesService
    {
        private readonly CakesDbContext _cakesDbContext;


        public CakesService(CakesDbContext cakesDbContext)
        {
            _cakesDbContext = cakesDbContext;
        }

        public Cake Create(Cake cake)
        {
            _cakesDbContext.Add(cake);
            _cakesDbContext.SaveChanges();

            return cake;
        }

        public void Delete(int id)
        {
            var cake = _cakesDbContext.Cakes.FirstOrDefault(x => x.Id == id);

            if (cake != null)
            {
                _cakesDbContext.Remove(cake);
                _cakesDbContext.SaveChanges();
            }
        }

        public Cake Get(int id)
        {
            return _cakesDbContext.Cakes.FirstOrDefault(x => x.Id == id);
        }

        public Cake Get(string name)
        {
            return _cakesDbContext.Cakes.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Cake> GetAll()
        {
            return _cakesDbContext.Cakes.ToList();
        }
    }
}
