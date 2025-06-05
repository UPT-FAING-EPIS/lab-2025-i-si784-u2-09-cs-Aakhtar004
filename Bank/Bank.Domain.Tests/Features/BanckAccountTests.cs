using Bank.Domain;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Bank.Domain.Tests.Features
{
    [Binding]
    public sealed class CuentaAhorroPruebas
    {
        private readonly ScenarioContext _scenarioContext;
        private CuentaAhorro _cuenta = null!;
        private string _error = string.Empty;
        private bool _es_error { get; set; } = false;
        
        public CuentaAhorroPruebas(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("la nueva cuenta numero (.*)")]
        public void DadoUnaNuevaCuenta(string numeroCuenta)
        {
            try
            {
                var cliente = Cliente.Registrar("Juan Perez");
                _cuenta = CuentaAhorro.Aperturar(numeroCuenta, cliente, 1);
                _es_error = false;
            }
            catch (System.Exception ex)
            {
                _es_error = true; 
                _error = ex.Message;
            }            
        }

        [Given("con saldo (.*)")]
        [When("deposito (.*)")]
        public void CuandoYoDeposito(decimal monto)
        {
            try
            {
                _cuenta.Depositar(monto);
                _es_error = false;
            }
            catch (System.Exception ex)
            {
                _es_error = true; 
                _error = ex.Message;
            }
        }

        [When("retiro (.*)")]
        public void CuandoYoRetiro(decimal monto)
        {
            try
            {
                _cuenta.Retirar(monto);
                _es_error = false;
            }
            catch (System.Exception ex)
            {
                _es_error = true; 
                _error = ex.Message;
            }
        }

        [Given("la cuenta esta cancelada")]
        [When("cancela la cuenta")]
        public void CuandoCancelaLaCuenta()
        {
            try
            {
                _cuenta.Cancelar();
                _es_error = false;
            }
            catch (System.Exception ex)
            {
                _es_error = true; 
                _error = ex.Message;
            }
        }

        [Then("el saldo nuevo deberia ser (.*)")]
        public void EntoncesElResultadoDeberiaSer(decimal resultado)
        {
            Assert.That(_cuenta.Saldo, Is.EqualTo(resultado));
        }        

        [Then("deberia ser error")]
        public void EntoncesDeberiaMostrarseError()
        {
            Assert.That(_es_error, Is.True);
        }

        [Then("la cuenta deberia estar cancelada")]
        public void EntoncesLaCuentaDeberiaEstarCancelada()
        {
            Assert.That(_cuenta.Estado, Is.False);
        }

        [Then("deberia mostrarse el error: (.*)")]
        public void EntoncesDeberiaMostrarseError(string error)
        {
            Assert.That(_error, Is.EqualTo(error));
        }
    }
}