using System;

namespace Puzle1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //HELABORADO POR ALVARO GABRIEL SANCHES VILLARREAL Y JESSIEL ARMANDO DIAZ NORIEGA.
            Busquedas search = new Busquedas();
            search.BusquedaPrimeroAnchura();
            search.BusquedaPrimeroProfundidad();
            search.BusquedaAStar();
        }
    }
}
