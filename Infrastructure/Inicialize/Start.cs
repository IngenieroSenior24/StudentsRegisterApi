using Infrastructure.Context;
using Infrastructure.Inicialize.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Inicialize
{
    public class Start
    {
        private readonly PersistenceContext _context;
        public Start(PersistenceContext context)
        {
            _context = context;
        }

        public async Task InitializeDatabasesAsync()
        {
            await SubjectSeeder.InitializeAsync(_context);
        }
        
        public void UseDatabase()
        {
            if (ValidateConnection(_context))
            {
                try
                {
                    _context.Database.Migrate();
                    Log.Information("Migraciones aplicadas con éxito.");
                }
                catch (Exception ex)
                {
                    Log.Error($"Error al aplicar migraciones: {ex.Message}");
                }
            }
            else
            {
                Log.Error($"No se pudo establecer conexión con la base de datos.");
            }
        }

        private static bool ValidateConnection(PersistenceContext context)
        {
            try
            {
                context.Database.OpenConnection();
                context.Database.CloseConnection();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}