namespace Bank.Domain
{
    /// <summary>
    /// Representa un cliente del banco
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Identificador único del cliente
        /// </summary>
        public int IdCliente { get; private set; }
        
        /// <summary>
        /// Nombre completo del cliente
        /// </summary>
        public string NombreCliente { get; private set; } = string.Empty;
        
        /// <summary>
        /// Registra un nuevo cliente
        /// </summary>
        /// <param name="_nombre">Nombre del cliente</param>
        /// <returns>Nuevo cliente registrado</returns>
        public static Cliente Registrar(string _nombre)
        {
            return new Cliente(){
                NombreCliente = _nombre
            };
        }   
    }
}