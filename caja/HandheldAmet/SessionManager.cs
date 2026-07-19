namespace CajaAmet
{
    // Almacena la sesión activa del usuario en memoria
    // Se limpia automáticamente al cerrar la aplicación
    public static class SessionManager
    {
        public static string Token { get; set; } = "";
        public static string UserId { get; set; } = "";
        public static string Nombre { get; set; } = "";
        public static string Rol { get; set; } = "";
        public static string Email { get; set; } = "";
    }
}