using System;
using System.Collections.Generic;
using Datos;
using Entity;

namespace Logica
{
    public class HospitalizacionService
    {
        private readonly ConnectionManager _conexion;
        private readonly HospitalizacionRepository _repositorio;
        public HospitalizacionService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new HospitalizacionRepository(_conexion);
        }
        public GuardarHospitalizacionResponse Guardar(Hospitalizacion hospitalizacion)
        {
            try
            {
                hospitalizacion.CalcularCopago();
                _conexion.Open();
                _repositorio.Guardar(hospitalizacion);
                _conexion.Close();
                return new GuardarHospitalizacionResponse(hospitalizacion);
            }
            catch (Exception e)
            {
                return new GuardarHospitalizacionResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Hospitalizacion> ConsultarTodos()
        {
            _conexion.Open();
            List<Hospitalizacion> hospitalizaciones = _repositorio.ConsultarTodosHospit();
            _conexion.Close();
            return hospitalizaciones;
        }
        /*public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var persona = _repositorio.BuscarPorIdentificacion(identificacion);
                if (persona != null)
                {
                    _repositorio.Eliminar(persona);
                    _conexion.Close();
                    return ($"El registro {persona.Nombre} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }*/
        public Hospitalizacion BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Hospitalizacion hospitalizacion = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return hospitalizacion;
        }
        /*public int Totalizar()
        {
            return _repositorio.Totalizar();
        }
        public int TotalizarMujeres()
        {
            return _repositorio.TotalizarMujeres();
        }
        public int TotalizarHombres()
        {
            return _repositorio.TotalizarHombres();
        }*/
    }

    public class GuardarHospitalizacionResponse 
    {
        public GuardarHospitalizacionResponse(Hospitalizacion hospitalizacion)
        {
            Error = false;
            Hospitalizacion = hospitalizacion;
        }
        public GuardarHospitalizacionResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Hospitalizacion Hospitalizacion { get; set; }
    }
}
