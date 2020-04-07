using System;

namespace Entity
{
    public class Hospitalizacion
    {
        public string Identificacion { get; set; }
        public decimal ValorServicio { get; set; }
        public double SalarioTrabajador { get; set; }
        public decimal ValorCopago { get; set; }
        public void CalcularCopago() 
        {
            decimal tarifa;
            if (SalarioTrabajador > 2500000)
            {
                tarifa = Convert.ToDecimal(SalarioTrabajador * 0.2);
                ValorCopago=tarifa*ValorServicio; 
            }
            else
            {
                tarifa = Convert.ToDecimal(SalarioTrabajador * 0.1);
                ValorCopago=tarifa*ValorServicio;
            }
        }

    }
}
