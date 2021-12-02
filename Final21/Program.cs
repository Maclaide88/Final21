using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;


namespace conStack
{
    class Program
    {
        static void Main()
        {
            Stack miPila = new Stack();
            int opcion;//opcion del menu 
            do
            {
                Console.Clear();//se limpia consola
                
                opcion = menu();//muestra menu y espera opción
                switch (opcion)
                {
                    case 1:
                        mensaje("Creada");
                        miPila = new Stack();
                        break;

                    case 2:
                        borrar(ref miPila);
                        break;

                    case 3:
                        agregar(ref miPila);
                        break;

                    case 4:
                        Console.WriteLine("Ingrese la patente a borrar: ");
                        string pate = Console.ReadLine();
                        eliminar(ref miPila, pate);
                        break;

                    case 5:
                        imprimir(miPila);
                        break;

                    case 6:
                        ultimo(miPila);
                        break;

                    case 7:
                        primero(miPila);
                        break;

                    case 8:
                        cantidad(miPila);
                        break;

                    case 9:
                        Console.WriteLine("Ingrese la patente a buscar: ");
                        string pate2 = Console.ReadLine();
                        buscar(miPila, pate2);
                        break;

                    case 10:
                        Console.WriteLine("Ingrese la patente a Reemplzar: ");
                        string pate3 = Console.ReadLine();
                        reemplazar(ref miPila, pate3);
                        break;

                    case 0: break; //salir
                    default:
                        mensaje("ERROR: la opción no es valida. Intente de nuevo.");
                        break;
                }
            }
            while (opcion != 0);
            mensaje("El programa a finalizado.");
        }

        /** muestra menu y retorna opción */
        static int menu()
        {
            //Console.Clear();
            Console.WriteLine("\n Stack Menu \n");
            Console.WriteLine("1- Crear Pila");
            Console.WriteLine("2- Borrar Pila");
            Console.WriteLine("3- Agregar Patente");
            Console.WriteLine("4- Borrar Patente");
            Console.WriteLine("5- Listar todas las Patentes");
            Console.WriteLine("6- Listar ultima Patente");
            Console.WriteLine("7- Listar primera Patente");
            Console.WriteLine("8- Cantidad de Patentes");
            Console.WriteLine("9- Buscar Patente");
            Console.WriteLine("10- Reemplzar Patente");
            Console.WriteLine("0- Salir");
            Console.Write("Ingresa tu opción: ");
            try
            {
                int valor = Convert.ToInt32(Console.ReadLine());
                return valor;
            }
            catch
            {
                Console.WriteLine("\nERROR: la opción no es valida. Intente de nuevo.");
                return menu();
                /*int valor2 = Convert.ToInt32(Console.ReadLine());
                return valor2;*/
            }
        }

        /** Elimina todo los elementos de la pila */
        static void borrar(ref Stack pila)
        {
            pila.Clear();
            imprimir(pila);
        }

        /** añade un nuevo elemento a la pila */
        static void agregar(ref Stack pila)
        {
            Console.WriteLine("Ingrese Patente");
            string patente1 = Console.ReadLine();
            if (Program.validarPatente(patente1))
            {
                mensaje("Patente Ingresada con exito");
                pila.Push(patente1);
            }
            else
            {
                mensaje("Formato ingresado erroneo");
            }
        }
        static bool validarPatente(string patente)
        {
            bool r = true;
            
            for (int i = 0; i < patente.Length -1; i++)
            {
                char c = patente[i];
                if (patente.Length != 6)
                    r = false;

                if (i > 2 && c != '0' && c != '1' && c != '2' && c != '3' && c != '4' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9')
                    
                    r = false;
                
                if (i <= 2 && c != 'a' && c != 'b' && c != 'c' && c != 'd' && c != 'e' && c != 'f' && c != 'g' && c != 'h' && c != 'i' && c != 'j' && c != 'k' && c != 'l' && c != 'm' && c != 'n' && c != 'ñ' && c != 'o' && c != 'p' && c != 'q' && c != 'r' && c != 's' && c != 't' && c != 'u' && c != 'v' && c != 'w' && c != 'x' && c != 'y' && c != 'z')
                
                    r = false;
                
            }
            return r;
        }

        /** Elimina elemento de la pila */
        static void eliminar(ref Stack pila,string pate)
        {
            
            if (pila.Count > 0)
            {
                
                string p = (string)pila.Pop();
                if (pila.Count > 0)
                {
                    eliminar(ref pila, pate);
                    
                }
                if (p != pate) 
                {
                    pila.Push(p);
                }
                else
                {
                    mensaje("La patente " + pate + " fue eliminada");
                }
            }
        }


        /** Muestra mensaje del programa al usuario */
        static void mensaje(String texto)
        {
            if (texto.Length > 0)
            {
                Console.WriteLine("\n=======================================================");
                Console.WriteLine(" {0}", texto);
                Console.WriteLine("=======================================================");
                Console.WriteLine("\n    Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        /** Muestra primer elemento */
        static void primero(Stack pila)
        {
            if (pila.Count > 1)
            {
                string p = (string)pila.Pop();
                primero(pila);
                pila.Push(p);
            }
            else
            {
                string p = (string)pila.Pop();
                mensaje("La primer patente es: "+p);
                pila.Push(p);
            }
        }

        /** Muestra ultimo elemento */
        static void ultimo(Stack pila)
        {
            string p = (string)pila.Pop();
            mensaje("La patente ultima es: "+p);
            pila.Push(p);
        }

        /** Muestra cantidad de elementos */
        static void cantidad(Stack pila)
        {
            if (pila.Count > 0)
            {
                int p = pila.Count;
                mensaje("La cantidad de pantentes son: " + p);
            }
            else
            {
                mensaje("La Pila esta vacia");
            }
        }

        /** Buscar elemento de la pila */
        static bool buscarPatente(Stack pila, string patente)
        {
            bool resultado = false;
            if (pila.Count > 0)
            {
                string p = (string)pila.Pop();
                if (patente == p)
                {
                    resultado = true;
                }
                else
                {
                    if (pila.Count > 0)
                    {
                        resultado = buscarPatente(pila, patente);
                    }
                }
                pila.Push(p);
            }
            return resultado;
        }
        static void buscar(Stack pila, string pate2)
        {
            bool resultado = buscarPatente(pila, pate2);
            if (resultado == true)
            {
                mensaje("Se encontro la patente");
            }
            else
            {
                mensaje("No se encontro la patente");
            }
        }

        /** Reemplazar elemento de la pila */
        static void reemplazar(ref Stack pila, string pate3)
        {

            if (pila.Count > 0)
            {

                string p = (string)pila.Pop();
                
                if (pila.Count > 0)
                {
                    reemplazar(ref pila, pate3);
                }
                if (p != pate3)
                {
                    pila.Push(p);
                }
                else
                {
                    Console.WriteLine("Ingrese la patente nueva: ");
                    string pate4 = Console.ReadLine();
                    pila.Push(pate4);
                    imprimir(pila);
                }
                
            }
        }

        /** Imprime pila */
        static void imprimir(Stack pila)
        {
            if (pila.Count > 0)
            {
                Console.WriteLine("");
                int c = pila.Count;
                foreach (string dato in pila)
                {
                    Console.WriteLine("{0}. {1}" ,c , dato);
                    c--;
                }
                Console.WriteLine("\nPresione cualquier tecla para continuar ...");
                Console.ReadKey();
            }
            else
            {
                mensaje("La Pila esta vacia");
            }
        }
    }
}
