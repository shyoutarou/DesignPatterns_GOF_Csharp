using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pattern_UnitOfWork
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nome { get; set; }
        public Cliente(string nome)
        {
            Nome = nome;
        }
    }

    public class Produto
    {
        public string Nome { get; set; }
        public Produto(string nome)
        {
            Nome = nome;
        }
    }

    public class MyContext : DbContext
    {
        public MyContext() : base("MyContextDB")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyContext,
            //Pattern_Repository.Migrations.Configuration>("MyContextDB"));
        }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

    }

    public interface IUnitOfWork
    {
        IRepositorio<Cliente> ClienteRepositorio { get; }
        IRepositorio<Produto> ProdutoRepositorio { get; }

        void Commit();
    }

    public interface IRepositorio<T> where T : class
    {
        IEnumerable<T> GetTudo(Expression<Func<T, bool>> predicate = null);
        T Get(Expression<Func<T, bool>> predicate);
        void Adicionar(T entity);
        void Atualizar(T entity);
        void Deletar(T entity);
        int Contar();
    }

    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private MyContext m_Context = null;
        DbSet<T> m_DbSet;

        public Repositorio(MyContext context)
        {
            m_Context = context;
            m_DbSet = m_Context.Set<T>();
        }

        public IEnumerable<T> GetTudo(Expression<Func<T, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return m_DbSet.Where(predicate);
            }

            return m_DbSet.AsEnumerable();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return m_DbSet.FirstOrDefault(predicate);
        }

        public void Adicionar(T entity)
        {
            m_DbSet.Add(entity);
        }

        public void Atualizar(T entity)
        {
            m_DbSet.Attach(entity);
            ((IObjectContextAdapter)m_Context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }

        public void Deletar(T entity)
        {
            m_DbSet.Remove(entity);
        }

        public int Contar()
        {
            return m_DbSet.Count();
        }
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MyContext _contexto = null;
        private Repositorio<Cliente> clienteRepositorio = null;
        private Repositorio<Produto> produtoRepositorio = null;

        public UnitOfWork()
        {
            _contexto = new MyContext();
        }

        public void Commit()
        {
            _contexto.SaveChanges();
        }

        public IRepositorio<Cliente> ClienteRepositorio
        {
            get
            {
                if (clienteRepositorio == null)
                {
                    clienteRepositorio = new Repositorio<Cliente>(_contexto);
                }
                return clienteRepositorio;
            }
        }

        public IRepositorio<Produto> ProdutoRepositorio
        {
            get
            {
                if (produtoRepositorio == null)
                {
                    produtoRepositorio = new Repositorio<Produto>(_contexto);
                }
                return produtoRepositorio;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var uow = new UnitOfWork();
            List<Cliente> clientes = uow.ClienteRepositorio.GetTudo().ToList();
            List<Produto> produtos = uow.ProdutoRepositorio.GetTudo().ToList();
            uow.ProdutoRepositorio.Deletar(new Produto("Bateria"));
            uow.Commit();
        }
    }
}
