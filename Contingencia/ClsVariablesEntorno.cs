using System;
using System.Collections.Generic;
using System.Text;

namespace Contingencia
{
    class ClsVariablesEntorno: ClsVariablesEntornoBD
    {
        public string[,] ConsultarVariables()
        {
            string[,] aVariables;
            try
            {
                aVariables = base.ConsultarVariablesBD();
                return aVariables;
            }
            catch
            {
                throw;
            }
        }

    }
}
