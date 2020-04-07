using System.Collections.Generic;
using System.Data.SqlClient;
using Entity;

namespace Datos
{
    public class HospitalizacionRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Hospitalizacion> _hospitalizacion = new List<Hospitalizacion>();
        public HospitalizacionRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Hospitalizacion hospitalizacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Hospitalizacion (Identificacion,ValorServicio,SalarioTrabajador, ValorCopago) 
                                        values (@Identificacion,@ValorServicio,@SalarioTrabajador,@ValorCopago)";
                command.Parameters.AddWithValue("@Identificacion", hospitalizacion.Identificacion);
                command.Parameters.AddWithValue("@ValorServicio", hospitalizacion.ValorServicio);
                command.Parameters.AddWithValue("@SalarioTrabajador", hospitalizacion.SalarioTrabajador);
                command.Parameters.AddWithValue("@ValorCopago", hospitalizacion.ValorCopago);
                var filas = command.ExecuteNonQuery();
            }
        }
        /*public void Eliminar(Persona persona)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from persona where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", persona.Identificacion);
                command.ExecuteNonQuery();
            }
        }*/
        public List<Hospitalizacion> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Hospitalizacion> hospitalizaciones = new List<Hospitalizacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from hospitalizacion ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Hospitalizacion hospitalizacion = DataReaderMapToHospit(dataReader);
                        hospitalizaciones.Add(hospitalizacion);
                    }
                }
            }
            return hospitalizaciones;
        }
        public Hospitalizacion BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from hospitalizacion where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToHospit(dataReader);
            }
        }

        private Hospitalizacion DataReaderMapToHospit(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Hospitalizacion hospitalizacion = new Hospitalizacion();
            hospitalizacion.Identificacion = (string)dataReader["Identificacion"];
            hospitalizacion.ValorServicio = (decimal)dataReader["ValorServicio"];
            hospitalizacion.SalarioTrabajador = (double)dataReader["SalarioTrabajador"];
            return hospitalizacion;
        }
        /*public int Totalizar()
        {
            return _personas.Count();
        }
        public int TotalizarMujeres()
        {
            ConsultarTodos();
            return _personas.Where(p => p.Sexo.Equals("F")).Count();
        }
        public int TotalizarHombres()
        {
            ConsultarTodos();
            return _personas.Where(p => p.Sexo.Equals("M")).Count();
        }*/
    }
}