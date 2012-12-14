using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    static class ClsEntorno
    {
        public static ClsUsuarios usuarioActual = new ClsUsuarios();

        static string[,] aValoresEntornoBaseDatos;
        public static string[,] AValoresEntornoBaseDatos
        {
            get
            {
                return aValoresEntornoBaseDatos;
            }
            set
            {
                aValoresEntornoBaseDatos = value;
            }
        }

        public static void ActualizarValorEntornoBaseDatos(string psVariable, string psValor)
        {
            int renglones = 0;
            if (aValoresEntornoBaseDatos.Length > 0)
            {
                renglones = aValoresEntornoBaseDatos.Length / (aValoresEntornoBaseDatos.GetUpperBound(1) + 1);
            }
            else
            {
                renglones = 0;
            }
            if (renglones > 0)
            {
                for (int contador = 0; contador < renglones; contador++)
                {
                    if (aValoresEntornoBaseDatos[contador, 0].Trim() == psVariable)
                    {
                        aValoresEntornoBaseDatos[contador, 1] = psValor;
                    }
                }
            }
        }

        public static string ObtenerValorEntornoBaseDatos(string psValor)
        {
            string valor = "";
            int renglones = 0;
            if (aValoresEntornoBaseDatos.Length > 0)
            {
                renglones = aValoresEntornoBaseDatos.Length / (aValoresEntornoBaseDatos.GetUpperBound(1) + 1);
            }
            else
            {
                renglones = 0;
            }
            if (renglones > 0)
            {
                for (int contador = 0; contador < renglones; contador++)
                {
                    if (aValoresEntornoBaseDatos[contador, 0].Trim() == psValor)
                    {
                        valor = aValoresEntornoBaseDatos[contador, 1];
                    }
                }
            }
            return valor;
        }

        public static void ResetVariablesEntorno()
        {
            usuarioActual.IniciarObjeto();
        }

        public static void CargarVariablesEntornoBD()
        {
            ClsVariablesEntorno variablesEntorno = new ClsVariablesEntorno();
            try
            {
                aValoresEntornoBaseDatos = variablesEntorno.ConsultarVariables();
            }
            catch
            {
                throw;
            }
        }


    }
}
