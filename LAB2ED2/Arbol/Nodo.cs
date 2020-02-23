using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LAB2ED2.Modelos;

namespace LAB2ED2.Arbol
{
    public class Nodo
    {
        int gradoMaximo;
        public Nodo[] hijos { get; set; }
        public Nodo Padre { get; set; }
        public int indiceHijoDePadre { get; set; }
        public Soda[] Llaves { get; set; }
        public bool esHoja { get; set; }
        public bool estaLleno { get; set; }
        public int tamaño { get; set; }
        public bool esRaiz { get; set; }
        public Nodo(int grado)
        {
            gradoMaximo = grado;
            Llaves = new Soda[grado - 1];
            hijos = new Nodo[grado];

        }
    }
}
