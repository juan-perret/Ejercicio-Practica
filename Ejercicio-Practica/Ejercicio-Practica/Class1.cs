using System.Collections.Generic;

namespace Ejercicio_Practica
{
    public class Class1
    {
        List<Personas> listaPersonas= new List<Personas>();
        List<Inscripciones> listaInscripciones= new List<Inscripciones>();
        List<Materias> listaMaterias = new List<Materias>();

        public string ListaDePersonasDevuelta(string nombre, string apellido, DateTime fechaIngreso)
        {
            List<Personas> listaFiltrada= listaPersonas.FindAll(x=>x.Nombre==nombre&& x.Apellido==apellido&& x.FechaIngreso==fechaIngreso);
            string personaStr = $"{listaFiltrada[0]} - {listaFiltrada[1]} - {listaFiltrada[2]}";
            
            return personaStr;
        }

        public List<Inscripciones> CantInscriptos(int codPersona, int codMateria)
        {
            List<Inscripciones> listaFinal = new List<Inscripciones>();
            
            foreach (Inscripciones inscripcion in listaInscripciones)
            {
                if (inscripcion.CodigoAlumno==codPersona && inscripcion.CodigoMateria==codMateria)
                {
                    int index = listaInscripciones.FindIndex(x => x.CodigoAlumno == codPersona);
                    listaFinal.Add(listaInscripciones[index]);
                }
                else if (inscripcion.CodigoProfesor == codPersona&& inscripcion.CodigoMateria==codMateria)
                {
                    int index = listaInscripciones.FindIndex(x => x.CodigoAlumno == codPersona);
                    listaFinal.Add(listaInscripciones[index]);
                }
            }
            return listaFinal;
        }
        public string NotasFinales(int codMateria, int codigoAlumno)
        {
            string notaFinal = "";
            int index = listaInscripciones.FindIndex(x => x.CodigoMateria == codMateria && x.CodigoAlumno == codigoAlumno);
            foreach (Inscripciones inscripcion in listaInscripciones)
            {
                if (codMateria==inscripcion.CodigoMateria&& codigoAlumno==inscripcion.CodigoAlumno)
                {
                    notaFinal = inscripcion.NotaFinal.ToString();
                }
                else if(index<0)
                {
                    notaFinal = "ExamenPendiente";
                }
            }
            return notaFinal;
        }
        public bool NotaActualizada(int codAlumno, int codMateria, int codProfesor)
        {
            bool result = false;
            List<Inscripciones> listaFiltrada = listaInscripciones.FindAll(x => x.CodigoMateria == codMateria && x.CodigoAlumno == codAlumno && x.CodigoProfesor == codProfesor);
            foreach (Inscripciones inscripcion in listaFiltrada)
            {
                if (inscripcion.FechaExamen < DateTime.Today && inscripcion.CodigoProfesor == codProfesor)
                {
                    result = true;
                }
                else
                {
                    result=false;
                }

            }
            return result;
        }
        public List<string> MateriasAprobadas(int codAlumno)
        {
            List<string> listaFinal= new List<string>();
            string cadenaString = "";
            List<Inscripciones> listaFiltrada = listaInscripciones.FindAll(x => x.CodigoAlumno == codAlumno);
            foreach (Inscripciones inscripcion in listaFiltrada)
            {
                if (inscripcion.NotaFinal>4 && inscripcion.FechaExamen>DateTime.Today)
                {
                    cadenaString = $"{inscripcion.FechaExamen} | {listaMaterias[inscripcion.CodigoMateria]} | {inscripcion.NotaFinal}";
                    listaFinal.Add(cadenaString);
                }
            }
            return listaFinal;
        }
    }
}