using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LAB2ED2.Arbol;
using System.IO;
using LAB2ED2.Modelos;

namespace LAB2ED2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public Arbol_BEstrella Arbol = new Arbol_BEstrella(5);
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var contenido = "Para buscar elementos ingrese la extension /BusquedaBebidas e ingresar el valor buscado en Postman \n" + Arbol.Todo();
            return contenido;
        }

        // GET api/values/5
        [Route("BusquedaBebidas")]
        [HttpGet]
        public string Get([FromBody] string nuevo)
        {
            var valorBuscado = Arbol.Busqueda(nuevo);
            string encontrado;
            if (valorBuscado != null)
            {
                encontrado = "-------------\n" + "Nombre: " + valorBuscado.nombre + "\n" + "Sabor: " + valorBuscado.sabor + "\n" + "Volumen: " + valorBuscado.volumen + "\n" + "Precio: " + valorBuscado.precio + "Casa productora: " + valorBuscado.casaProductora + "\n" + "-----------------\n";

            }
            else
            {
                encontrado = "Valor no encontrado";
            }
            return encontrado;
        }

        // POST api/GradoArbol
        [Route("GradoArbol")]
        [HttpPost]
        public void PostGrado([FromBody] int grado)
        {
            Arbol_BEstrella Arbol1 = new Arbol_BEstrella(grado);
            Arbol = Arbol1;
        }

        [Route("Valores")]
        [HttpPost]
        public void PostDatos([FromBody] Soda valor)
        {
            Arbol.Insertar(valor);
        }

        [Route("ArchivoYAarbol")]
        [HttpGet]
        public void GetArchivo()
        {
            var lector = new FileStream("Tabla.txt", FileMode.OpenOrCreate);
            lector.Close();
            var lee = new StreamReader(@"Tabla.txt");
            lee.ReadLine();
            while (!lee.EndOfStream)
            {
                var a = lee.ReadLine();
                Arbol.InsertNodo(a, @"Tabla.txt");
            }
        }
    }
}