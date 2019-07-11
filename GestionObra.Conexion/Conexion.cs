namespace GestionObra.Conexion
{
    public static class Conexion
    {
        public const string Servidor = @"DESKTOP-HAL8M4B\SQLEXPRESS";
        public const string BaseDatos = "ProyectManagement";
        public const string Usuario = "sa";
        public const string Password = "123456";
        public static string ObtenerCadenaConexionSql => $"Data Source={Servidor}; " +
                                                         $"Initial Catalog={BaseDatos}; " +
                                                         $"User Id={Usuario}; " +
                                                         $"Password={Password};";
        public static string ObtenerCadenaConexionWin => $"Data Source={Servidor}; " +
                                                         $"Initial Catalog={BaseDatos}; " +
                                                         $"Integrated Security = true";
    }
}
