using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MauiSqliteDemo5834249
{
    public class LocalDBService
    {
        private const string DB_NAME = "demo_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            //Le indica al sistema que crea la tabla de nuestro contexto
            _connection.CreateTableAsync<Cliente>();
        }

        //Metodo para listar los regustros de nuestra tabla
        public async Task<List<Cliente>> GetClientes()
        {
            return await _connection.Table<Cliente>().ToListAsync();
        }

        //Metodo para listar los registros por id
        public async Task<Cliente> GetById(int id)
        {
            return await _connection.Table<Cliente>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //Metodo para agregar registro
        public async Task Create(Cliente clientes)
        {
            await _connection.InsertAsync(clientes);
        }

        //Metodo para actualizar 
        public async Task Update(Cliente clientes)
        {
            await _connection.UpdateAsync(clientes);
        }

        //Metodo para eliminar
        public async Task Delete(Cliente clientes)
        {
            await _connection.DeleteAsync(clientes);
        }

    }
}
