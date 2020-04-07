using Entity;

namespace tallerips.Models
{
    public class HospitalizacionInputModel
    {
        public string Identificacion { get; set; }
        public decimal ValorServicio { get; set; }
        public double SalarioTrabajador { get; set; }
    }

    public class HospitalizacionViewModel : HospitalizacionInputModel
    {
        public HospitalizacionViewModel()
        {

        }
        public HospitalizacionViewModel(Hospitalizacion hospitalizacion)
        {
            Identificacion = hospitalizacion.Identificacion;
            ValorServicio = hospitalizacion.ValorServicio;
            SalarioTrabajador = hospitalizacion.SalarioTrabajador;
            ValorCopago = hospitalizacion.ValorCopago;
        }
        public decimal ValorCopago { get; set; }
    }
}