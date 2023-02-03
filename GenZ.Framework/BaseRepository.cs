using Microsoft.EntityFrameworkCore;

namespace GenZ.Framework
{
    //http://www.tugberkugurlu.com/archive/generic-repository-pattern-entity-framework-asp-net-mvc-and-unit-testing-triangle
    public class BaseRepository<context, T> :
    IBaseRepository<T> where T : class where context : DbContext, new()
    {
       
        private context _entities = new context();
        public context Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query;
        }

        public IQueryable<T> FindByFunc(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query;
        }

        public virtual void AddEntity(T entity)
        {
            _entities.Set<T>().Add(entity);
        }

        public virtual void DeleteEntity(T entity)
        {
            _entities.Set<T>().Remove(entity);
        }

        public virtual void EditEntity(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void SaveEntity()
        {
            _entities.SaveChanges();
        }
    }
}
