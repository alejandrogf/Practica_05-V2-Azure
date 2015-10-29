using System;

namespace Practica_05.model
{
    public partial class Alumno
    {
        public override string ToString()
        {
            return String.Format("{0} con DNI {1} ", Nombre, DNI);
            
        }
    }
}
