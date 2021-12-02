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

            int opcion;//opcion del menu 
            do
            {
                Console.Clear();//se limpia consola
                Stack miPila = new Stack();
                opcion = menu();//muestra menu y espera opción
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Creada");
                        break;

                    case 2:
                        borrar(ref miPila);
                        break;

                    case 3:
                        agregar(ref miPila);
                        break;
                    case 4:
                        eliminar(ref miPila);
                        break;
                    case 5:
                        imprimir(miPila);
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
            Console.WriteLine("0- Salir");
            Console.Write("Ingresa tu opción: ");
            try
            {
                int valor = Convert.ToInt32(Console.ReadLine());
                return valor;
            }
            catch
            {
                return 0;
            }
        }

        /** Elimina todo los elementos de la pila */
        static void borrar(ref Stack pila)
        {
            pila.Clear();
            imprimir(pila);
        }

        /** añade un nuevo elemento a la pila */
        /*static void agregar(ref Stack pila)
        {
            bool re;
            string patente;
            Console.Write("\n>Ingrese la patente: ");
            patente = Console.ReadLine();
            re = validarPatente(patente);
            if (re == false)
                Console.Write("Patente mal escrita ");
            else
                Console.WriteLine("La patente es: {0}",patente);
                pila.Push(patente);
            
        }*/

        static void agregar(ref Stack pila)
        {
            Console.WriteLine("Ingrese Patente");
            string patente1 = Console.ReadLine();
            if (Program.validarPatente(patente1))
            {
                Console.WriteLine("Patente Ingresada con exito");
                pila.Push(patente1);
            }
            else
            {
                Console.WriteLine("Formato ingresado erroneo");
            }
            if (pila.Count>0)
            {
                Console.WriteLine("Patente Ingresada: {0}", pila.Pop());
            }
        }
        static bool validarPatente(string patente)
        {
            bool r = true;
            
            for (int i = 0; i < patente.Length; i++)
            {
                char c = patente[i];
                if (patente.Length != 6)
                    r = false;

                if (i <= 2 && c != '0' && c != '1' && c != '2' && c != '3' && c != '4' && c != '5' && c != '6' && c != '7' && c != '8' && c != '9')
                    
                    r = false;
                
                if (i > 2 && c != 'a' && c != 'b' && c != 'c' && c != 'd' && c != 'e' && c != 'f' && c != 'g' && c != 'h' && c != 'i' && c != 'j' && c != 'k')
                
                    r = false;
                
            }
            return r;
        }




        /** Elimina elemento de la pila */
        static void eliminar(ref Stack pila)
        {
            if (pila.Count > 0)
            {
                int valor = (int)pila.Pop();
                mensaje("Elemento " + valor + " eliminado");
            }
            else
            {
                imprimir(pila);
            }
        }
        

        /** Muestra mensaje del programa al usuario */
        static void mensaje(String texto)
        {
            if (texto.Length > 0)
            {
                Console.WriteLine("\n    =======================================================");
                Console.WriteLine(" {0}", texto);
                Console.WriteLine(" =======================================================");
                Console.WriteLine("\n    Presione cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }

        /** Imprime pila */
        static void imprimir(Stack pila)
        {
            if (pila.Count > 0)
            {
                Console.WriteLine("");
                foreach (int dato in pila)
                {
                    Console.WriteLine(" | |");
                    if (dato < 10)
                        Console.WriteLine(" | 0{0} |", dato);
                    else
                        Console.WriteLine(" | {0} |", dato);
                    Console.WriteLine(" |______|");
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
