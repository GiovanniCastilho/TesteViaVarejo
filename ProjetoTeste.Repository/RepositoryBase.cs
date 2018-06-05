using Dommel;
using ProjetoTeste.Domain.Contracts;
using ProjetoTeste.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace ProjetoTeste.Repository
{
    /// <summary>
    /// Classe responsável pela implementação base (padrão), é dela que iremos herdar todos os nossos repositórios.
    /// Qualquer implementação personalizada nas classes filha, tem de ser sobrescrita com o cláusula override no método.
    /// </summary>
    /// <typeparam name="TEntity">Repositorio que será herdado</typeparam>
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        protected readonly string ConnectionString;

        protected RepositoryBase()
        {
            ConnectionString = ConfigurationManager.AppSettings["Conexao"];
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.GetAll<TEntity>();
            }
        }

        public virtual TEntity GetById(int id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Get<TEntity>(id);
            }
        }

        public virtual void Insert(ref TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var id = db.Insert(entity);

                //entity = GetById(id);
                entity = GetById(Convert.ToInt32(id));
            }
        }

        public virtual bool Update(TEntity entity)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Update(entity);
            }
        }

        public virtual bool Delete(Int32 id)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var entity = GetById(id);

                if (entity == null) throw new Exception("Registro não encontrado");

                return db.Delete(entity);
            }
        }

        public virtual IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                return db.Select(predicate);
            }
        }
    }
}
