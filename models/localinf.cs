using System;

namespace Softjc.models
{
    public class localinf
    {

        //El siguiente metodo es utilizado para obtener la fecha del sistema
        public DateTime GetDateTime()
        {
            DateTime fecha = DateTime.Now;

            return fecha;
        }
    }
}