using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using CartelLoyola.Data;
using System.Threading.Tasks;

namespace CartelLoyola.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        void Salvar(TEntity obj);
        void Atualizar(TEntity obj);
        void Deletar(int id);
        TEntity ObterPor(int id);
        IList<TEntity> ObterTodos();
        void ObterLoginUsuario(TEntity obj);
    }

    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        CartelLoyolaContext _dbContext = new CartelLoyolaContext();

        public IList<TEntity> ObterTodos()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity ObterPor(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public void ObterLoginUsuario(TEntity entity)
        {
            _dbContext.Set<TEntity>().Find(entity);
        }

        public void Salvar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Deletar(int id)
        {
            var entity =  _dbContext.Set<TEntity>().Find(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChangesAsync();
        }
    }
}
