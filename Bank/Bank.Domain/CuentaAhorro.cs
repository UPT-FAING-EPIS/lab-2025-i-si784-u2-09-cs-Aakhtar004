namespace Bank.Domain
{
    /// <summary>
    /// Representa una cuenta de ahorro bancaria
    /// </summary>
    public class CuentaAhorro
    {
        /// <summary>
        /// Mensaje de error cuando el monto es menor o igual a cero
        /// </summary>
        public const string ERROR_MONTO_MENOR_IGUAL_A_CERO = "El monto no puede ser menor o igual a 0";
        
        /// <summary>
        /// Mensaje de error cuando la cuenta ya está cancelada
        /// </summary>
        public const string ERROR_CUENTA_CANCELADA = "La cuenta ya está cancelada";

        /// <summary>
        /// Identificador único de la cuenta
        /// </summary>
        public int IdCuenta { get; private set; }
        
        /// <summary>
        /// Número de cuenta
        /// </summary>
        public string NumeroCuenta { get; private set; } = string.Empty;
        
        /// <summary>
        /// Propietario de la cuenta
        /// </summary>
        public virtual Cliente Propietario { get; private set; } = null!;
        
        /// <summary>
        /// Identificador del propietario
        /// </summary>
        public int IdPropietario { get; private set; }
        
        /// <summary>
        /// Tasa de interés de la cuenta
        /// </summary>
        public decimal Tasa { get; private set; }
        
        /// <summary>
        /// Saldo actual de la cuenta
        /// </summary>
        public decimal Saldo { get; private set; }
        
        /// <summary>
        /// Fecha de apertura de la cuenta
        /// </summary>
        public DateTime FechaApertura { get; private set; }
        
        /// <summary>
        /// Estado de la cuenta (true: activa, false: cancelada)
        /// </summary>
        public bool Estado { get; private set; }
        
        /// <summary>
        /// Apertura una nueva cuenta de ahorro
        /// </summary>
        /// <param name="_numeroCuenta">Número de cuenta</param>
        /// <param name="_propietario">Propietario de la cuenta</param>
        /// <param name="_tasa">Tasa de interés</param>
        /// <returns>Nueva cuenta de ahorro</returns>
        public static CuentaAhorro Aperturar(string _numeroCuenta, Cliente _propietario, decimal _tasa)
        {
            return new CuentaAhorro()
            {
                NumeroCuenta = _numeroCuenta,
                Propietario = _propietario,
                IdPropietario = _propietario.IdCliente,
                Tasa = _tasa,
                Saldo = 0,
                Estado = true,
                FechaApertura = DateTime.Now
            };
        }     
        
        /// <summary>
        /// Deposita un monto en la cuenta
        /// </summary>
        /// <param name="monto">Monto a depositar</param>
        /// <exception cref="Exception">Cuando el monto es menor o igual a cero o la cuenta está cancelada</exception>
        public void Depositar(decimal monto)
        {
            if (!Estado)
                throw new Exception(ERROR_CUENTA_CANCELADA);
            if (monto <= 0)
                throw new Exception(ERROR_MONTO_MENOR_IGUAL_A_CERO);
            Saldo += monto;
        }
        
        /// <summary>
        /// Retira un monto de la cuenta
        /// </summary>
        /// <param name="monto">Monto a retirar</param>
        /// <exception cref="Exception">Cuando el monto es menor o igual a cero o la cuenta está cancelada</exception>
        public void Retirar(decimal monto)
        {
            if (!Estado)
                throw new Exception(ERROR_CUENTA_CANCELADA);
            if (monto <= 0)
                throw new Exception(ERROR_MONTO_MENOR_IGUAL_A_CERO);
            Saldo -= monto;
        }
        
        /// <summary>
        /// Cancela la cuenta de ahorro
        /// </summary>
        /// <exception cref="Exception">Cuando la cuenta ya está cancelada</exception>
        public void Cancelar()
        {
            if (!Estado)
                throw new Exception(ERROR_CUENTA_CANCELADA);
            Estado = false;
        }
    }
}