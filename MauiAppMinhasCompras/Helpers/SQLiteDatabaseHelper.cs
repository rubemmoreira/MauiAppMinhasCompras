using MauiAppMinhasCompras.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MauiAppMinhasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        private readonly SQLiteAsyncConnection _conn;

        public SQLiteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produto>().Wait();
        }

        // Inserir um novo produto
        public Task<int> Insert(Produto p)
        {
            return _conn.InsertAsync(p);
        }

        // Atualizar um produto existente
        public Task<int> Update(Produto p)
        {
            return _conn.UpdateAsync(p);
        }

        // Deletar um produto pelo ID
        public Task<int> Delete(int id)
        {
            return _conn.DeleteAsync<Produto>(id);
        }

        // Buscar todos os produtos
        public Task<List<Produto>> GetAll()
        {
            return _conn.Table<Produto>().ToListAsync();
        }

        // Buscar produtos por parte da descrição
        public Task<List<Produto>> Search(string q)
        {
            string sql = "SELECT * FROM Produto WHERE Descricao LIKE ?";
            return _conn.QueryAsync<Produto>(sql, $"%{q}%");
        }
    }
}
