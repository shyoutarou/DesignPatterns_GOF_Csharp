using System;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;

namespace Pattern_Repository
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

    public interface IClienteRepository
    {
        Cliente GetByID(int clienteID);
        void Save(Cliente cliente);
        void Delete(Cliente cliente);
    }

    public interface IProdutoRepository
    {
        Produto GetByID(int produtoID);
        void Save(Produto produto);
        void Delete(Produto produto);
    }

public class ClienteRepositorio : IClienteRepository
{
    MyContext _contexto = null;

    public ClienteRepositorio(MyContext contexto)
    {
        _contexto = contexto;
    }

    public void Delete(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public Cliente GetByID(int clienteID)
    {
        throw new NotImplementedException();
    }

    public void Save(Cliente cliente)
    {
        throw new NotImplementedException();
    }
}


    public interface IRepository<T>
    {
        T GetById(int id);
        T Load(int id);
        void Save(T entity);
        void Delete(T entity);
    }

    public interface IRepositoryLINQ<T> where T : class
    {
        IQueryable<T> GetAll();
        void InsertOnSubmit(T entity);
        void DeleteOnSubmit(T entity);
        void SubmitChanges();
    }

    public class RepositoryLINQ<T> : IRepositoryLINQ<T> where T : class
    {
        public DataContext Context { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return Context.GetTable<T>();
        }

        public virtual void InsertOnSubmit(T entity)
        {
            GetTable().InsertOnSubmit(entity);
        }

        public virtual void DeleteOnSubmit(T entity)
        {
            GetTable().DeleteOnSubmit(entity);
        }

        public virtual void SubmitChanges()
        {
            Context.SubmitChanges();
        }

        public virtual ITable GetTable()
        {
            return Context.GetTable<T>();
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

    public interface IRepositoryEF<T>
    {
        T GetById(int id);

        T[] GetAll();

        IQueryable<T> Query(Expression<Func<T, bool>> filter);

        void Save(T entity);

        void Delete(T entity);
    }

    public class ClienteRepository : IRepositoryEF<Cliente>, IDisposable
    {
        private MyContext _context;

        public ClienteRepository()
        {
            _context = new MyContext();
        }

        public Cliente GetById(int id)
        {
            return _context.Clientes.
            Where(s => s.ClienteID == id).
            FirstOrDefault();
        }

        public Cliente[] GetAll()
        {
            return _context.Clientes.ToArray();
        }

        public IQueryable<Cliente> Query(Expression<Func<Cliente, bool>> filter)
        {
            return _context.Clientes.Where(filter);
        }

        public void Save(Cliente cliente)
        {
            //código para persistir o registro do cliente para o banco de dados
        }

        public void Delete(Cliente cliente)
        {
            //Código necessário para deletar um cliente
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var repo = new RepositoryLINQ<Produto>();
            repo.Context = new DataContext("ConnectionString");
            var produtos = repo.GetAll();


            var repoEF = new ClienteRepository();
            var clientes = repoEF.GetAll();
        }
    }
}
