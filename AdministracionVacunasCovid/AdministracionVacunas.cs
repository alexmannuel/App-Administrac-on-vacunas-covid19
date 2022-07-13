using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionVacunasCovid
{
    public class AdministracionVacunas
    {
        List<Vacunas> vacunas = new();
        List<Personas> personas = new();
        public void comienzoDeAplicacion()
        {

            bool menu = false;

            do
            {
                int opciones = 0;


                Console.WriteLine("Aplicación de Administración de Vacunas de Covid19");
                Console.WriteLine("***************************************************");
                Console.WriteLine();
                Console.WriteLine("Menu:");
                Console.WriteLine();
                Console.WriteLine("1.  Cargar datos de Inventario");
                Console.WriteLine("2.  Listar vacunas en Inventario");
                Console.WriteLine("3.  Listar vacunas Administradas");
                Console.WriteLine("4.  Listar en orden alfabetico personas que no han recibido vacuna alguna para un intervalo de edad");
                Console.WriteLine("5.  Listar en orden alfabetico personas que han recibido una sola dosis de vacuna para un intervalo de edad");
                Console.WriteLine("6.  Listar en orden alfabetico personas que han recibido dos dosis de vacuna para un intervalo de edad");
                Console.WriteLine("7.  Administración de Vacunas Covid19");
                Console.WriteLine("8.  Añadir nueva persona al Archivo Personas");
                Console.WriteLine("9.  Añadir nueva vacuna al Archivo Vacunas");
                Console.WriteLine("10. Salir de la Aplicación");
                Console.WriteLine();
                Console.Write("Escriba la opción que desea: ");



                try
                {
                    opciones = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Solo acepta numeros.");
                    Console.WriteLine();
                }




                switch (opciones)
                {
                    case 1:
                        Console.Clear();
                        cargarVacunas(vacunas, personas);
                        menu = false;
                        break;
                    case 2:
                        Console.Clear();
                        vacunasInventario(vacunas);
                        menu = false;
                        break;
                    case 3:
                        Console.Clear();
                        vacunasAdministradas(vacunas);
                        menu = false;
                        break;
                    case 4:
                        Console.Clear();
                        personasSinVacuna(personas);
                        menu = false;
                        break;
                    case 5:
                        Console.Clear();
                        personasConUnaDosis(personas);
                        menu = false;
                        break;
                    case 6:
                        Console.Clear();
                        personasConDosDosis(personas);
                        menu = false;
                        break;
                    case 7:
                        Console.Clear();
                        administrarVacunas(vacunas, personas);
                        menu = false;
                        break;
                    case 8:
                        Console.Clear();
                        anadirPersona(personas);
                        menu = false;
                        break;
                    case 9:
                        Console.Clear();
                        anadirVacuna(vacunas);
                        menu = false;
                        break;
                    case 10:
                        terminarAplicacion();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción incorrecta, vuelva a intentar.");
                        break;


                }
            } while (!menu);
        }
        public int tamanoArchivo()
        {
            int tamano = 0;
            string FileToRead = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Vacunas.txt";
            using (StreamReader ReaderObject = new StreamReader(FileToRead))
            {
                string Line;
                // ReaderObject reads a single line, stores it in Line string variable and then displays it on console
                while ((Line = ReaderObject.ReadLine()) != null)
                {
                    tamano++;
                }
                return tamano;
            }
        }

        public void cargarVacunas(List<Vacunas> vacuna, List<Personas> persona)
        {

            Console.WriteLine("Cargar datos de los archivos");
            Console.WriteLine();
            Console.WriteLine("Archivos disponibles: Archivo Vacuna o Archivo Persona");
            Console.Write("Escribe solo el nombre del archivo: ");
            string nombreArchivo = Console.ReadLine().ToLower();
            bool nombreValido = false;


            //while (nombreArchivo != "vacuna" || nombreArchivo != "persona")
            //{
            //    Console.Clear();
            //    Console.WriteLine("Nombre incorrecto.");

            //    Console.WriteLine("Cargar datos de los archivos");
            //    Console.WriteLine("Escribe su nombre Vacuna o Persona");
            //    nombreArchivo = Console.ReadLine().ToLower();


            //    nombreValido = true;
            //}

            if (nombreArchivo == "vacuna")
            {

                try
                {

                    List<string> lines = new();
                    string filePath = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Vacunas.txt";
                    lines = File.ReadAllLines(filePath).ToList();

                    foreach (var line in lines)
                    {
                        string[] items = line.Split(',');
                        int cantidad = int.Parse(items[1]);
                        int cantidadDisp = int.Parse(items[2]);

                        vacuna.Add(new Vacunas { NombreCompania = items[0], CantidadAdministrada = cantidad, CantidadDisponible = cantidadDisp });
                    }
                    Console.Clear();
                    Console.WriteLine("Datos cargados con exito!!");
                    Console.WriteLine("Ya puedes elegir cualquier otra opción del menu.");
                    Console.WriteLine();

                }
                catch (Exception)
                {

                    Console.WriteLine($"El archivo {nombreArchivo} no fue encontrado.");
                }


            }
            if (nombreArchivo == "persona")
            {


                try
                {
                    List<string> lines = new();
                    string filePath = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Personas.txt";
                    lines = File.ReadAllLines(filePath).ToList();

                    foreach (var line in lines)
                    {
                        string[] items = line.Split(',');

                        persona.Add(new Personas { Id = int.Parse(items[0]), Nombre = items[1], Edad = int.Parse(items[2]), DosisRecibidas = int.Parse(items[3]) });
                    }
                    Console.Clear();
                    Console.WriteLine("Datos cargados con exito!!");
                    Console.WriteLine("Ya puedes elegir cualquier otra opción del menu.");
                    Console.WriteLine();
                }
                catch (Exception)
                {

                    Console.WriteLine($"El archivo {nombreArchivo} no fue encontrado.");
                }

            }


        }

        public void vacunasInventario(List<Vacunas> vacuna)
        {
            if (vacuna.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }
            Console.WriteLine($"Lista de Vacunas disponibles al {DateTime.Now}");
            Console.WriteLine();
            foreach (var item in vacuna)
            {
                Console.WriteLine($" {item.NombreCompania}\n Cantidad de Vacunas disponibles:{item.CantidadDisponible}\n");
            }
        }

        public void vacunasAdministradas(List<Vacunas> vacuna)
        {
            if (vacuna.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }
            Console.WriteLine($"Lista de Vacunas Administradas al {DateTime.Now}");
            Console.WriteLine();
            foreach (var item in vacuna)
            {
                Console.WriteLine($" {item.NombreCompania}\n Cantidad de Vacunas administradas:{item.CantidadAdministrada}\n");
            }
        }

        public void personasSinVacuna(List<Personas> persona)
        {
            if (persona.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }
            List<Personas> listaPersonas = new();
            int i = 1;

            foreach (var item in persona)
            {
                if (item.Edad > 20 && item.Edad < 85 && item.DosisRecibidas == 0)
                {
                    listaPersonas.Add(item);
                }
            }

            listaPersonas.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));
            Console.WriteLine("Listado de personas sin vacuna de 20 a 85 años de edad: ");
            Console.WriteLine();
            foreach (var item in listaPersonas)
            {
                Console.WriteLine($"{i}.Nombre: {item.Nombre}\n  Edad: {item.Edad} ");
                i++;
            }
            Console.WriteLine();
        }

        public void personasConUnaDosis(List<Personas> persona)
        {
            if (persona.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }
            List<Personas> listaPersonas = new();
            int i = 1;
            foreach (var item in persona)
            {
                if (item.Edad > 10 && item.Edad < 80 && item.DosisRecibidas == 1)
                {
                    listaPersonas.Add(item);
                }
            }

            listaPersonas.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));
            Console.WriteLine("Listado de personas con una dosis de vacuna de 10 a 80 años de edad: ");
            Console.WriteLine();
            foreach (var item in listaPersonas)
            {
                Console.WriteLine($"{i}.Nombre: {item.Nombre}\n  Edad: {item.Edad} ");
                i++;
            }
            Console.WriteLine();
        }

        public void personasConDosDosis(List<Personas> persona)
        {
            if (persona.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }
            List<Personas> listaPersonas = new();
            int i = 1;
            foreach (var item in persona)
            {
                if (item.Edad > 10 && item.Edad < 80 && item.DosisRecibidas == 2)
                {
                    listaPersonas.Add(item);
                }
            }

            listaPersonas.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));
            Console.WriteLine("Listado de personas con dos dosis de vacuna de 10 a 80 años de edad: ");
            Console.WriteLine();
            foreach (var item in listaPersonas)
            {
                Console.WriteLine($"{i}.Nombre: {item.Nombre}\n  Edad: {item.Edad} ");
                i++;
            }
            Console.WriteLine();
        }

        public void administrarVacunas(List<Vacunas> vacuna, List<Personas> persona)
        {
            if (persona.Count == 0 || vacuna.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos de (Vacuna y Persona) en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }

            Console.Clear();
            Console.WriteLine("Bienvenida al apartado de Administración de Vacunas de Covid19");

            Console.WriteLine("Debemos localizar su información primero.");
            Console.Write("Cuales es su ID: ");
            int id = int.Parse(Console.ReadLine());

            foreach (var item in persona)
            {
                if (id == item.Id && item.DosisRecibidas < 2)
                {
                    Console.WriteLine($"Hola {item.Nombre}.");
                    Console.WriteLine($"Actualmente tienes {item.DosisRecibidas} vacuna, con {item.Edad} años.");
                    Console.Write("Cuantas dosis de vacuna deseas administrarte: ");
                    int respuesta = int.Parse(Console.ReadLine());

                    if (respuesta == 1 && item.DosisRecibidas < 2)
                    {
                        int i = 1;
                        Console.WriteLine();
                        Console.WriteLine("Cual es el nombre de la vacuna que te pondras: ");
                        foreach (var itemvacuna in vacuna)
                        {
                            Console.WriteLine($"{i}.{itemvacuna.NombreCompania}");
                            i++;
                        }
                        Console.WriteLine();
                        Console.Write("Escribe el numero: ");
                        int nombreVacuna = int.Parse(Console.ReadLine());

                        if (nombreVacuna == 1)
                        {
                            string nombreComp = String.Empty;
                            int count = 0;
                            foreach (var nombre in vacuna)
                            {
                                nombreComp = "Compania: Moderna";
                                if (nombreComp == nombre.NombreCompania)
                                {
                                    nombre.CantidadAdministrada += 1;
                                    nombre.CantidadDisponible -= 1;
                                }

                            }
                            item.DosisRecibidas += 1;

                            string filePath = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Vacunas.txt";
                            string filePath2 = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Personas.txt";
                            string linea = "";
                            using (StreamWriter file = new StreamWriter(filePath, false))
                            {

                                foreach (var itemSav in vacuna)
                                {
                                    linea = $"{itemSav.NombreCompania}, {itemSav.CantidadAdministrada}, {itemSav.CantidadDisponible}";


                                    file.WriteLine(linea);
                                }

                            }

                            using (StreamWriter file = new StreamWriter(filePath2, false))
                            {

                                foreach (var itemSav in persona)
                                {
                                    linea = $"{itemSav.Id}, {itemSav.Nombre}, {itemSav.Edad}, {itemSav.DosisRecibidas}";


                                    file.WriteLine(linea);
                                }

                            }


                            Console.WriteLine();
                            Console.WriteLine($"{item.Nombre} has sido vacunado con exito, ahora tienes {item.DosisRecibidas} dosis.");
                            Console.WriteLine("Actualizando informacion del archivo externo.....");
                            Console.WriteLine(".............");


                            Console.WriteLine(" Ya que hemos finalizado, volveras al menu principal.");
                            Console.WriteLine();
                            comienzoDeAplicacion();
                        }
                        else if (nombreVacuna == 2)
                        {
                            string nombreComp = String.Empty;
                            int count = 0;
                            foreach (var nombre in vacuna)
                            {
                                nombreComp = "Compania: Pfizer";
                                if (nombreComp == nombre.NombreCompania)
                                {
                                    nombre.CantidadAdministrada += 1;
                                    nombre.CantidadDisponible -= 1;
                                }

                            }
                            item.DosisRecibidas += 1;

                            string filePath = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Vacunas.txt";
                            string filePath2 = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Personas.txt";
                            string linea = "";
                            using (StreamWriter file = new StreamWriter(filePath, false))
                            {

                                foreach (var itemSav in vacuna)
                                {
                                    linea = $"{itemSav.NombreCompania}, {itemSav.CantidadAdministrada}, {itemSav.CantidadDisponible}";


                                    file.WriteLine(linea);
                                }

                            }

                            using (StreamWriter file = new StreamWriter(filePath2, false))
                            {

                                foreach (var itemSav in persona)
                                {
                                    linea = $"{itemSav.Id}, {itemSav.Nombre}, {itemSav.Edad}, {itemSav.DosisRecibidas}";


                                    file.WriteLine(linea);
                                }

                            }


                            Console.WriteLine();
                            Console.WriteLine($"{item.Nombre} has sido vacunado con exito, ahora tienes {item.DosisRecibidas} dosis.");
                            Console.WriteLine("Actualizando informacion del archivo externo.....");
                            Console.WriteLine(".............");


                            Console.WriteLine(" Ya que hemos finalizado, volveras al menu principal.");
                            Console.WriteLine();
                            comienzoDeAplicacion();
                        }
                        else if (nombreVacuna == 3)
                        {

                            string nombreComp = String.Empty;
                            int count = 0;
                            foreach (var nombre in vacuna)
                            {
                                nombreComp = "Compania: Pfizer";
                                if (nombreComp == nombre.NombreCompania)
                                {
                                    nombre.CantidadAdministrada += 1;
                                    nombre.CantidadDisponible -= 1;
                                }

                            }
                            item.DosisRecibidas += 1;


                            string filePath = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Vacunas.txt";
                            string filePath2 = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Personas.txt";
                            string linea = "";
                            using (StreamWriter file = new StreamWriter(filePath, false))
                            {

                                foreach (var itemSav in vacuna)
                                {
                                    linea = $"{itemSav.NombreCompania}, {itemSav.CantidadAdministrada}, {itemSav.CantidadDisponible}";


                                    file.WriteLine(linea);
                                }

                            }

                            using (StreamWriter file = new StreamWriter(filePath2, false))
                            {

                                foreach (var itemSav in persona)
                                {
                                    linea = $"{itemSav.Id}, {itemSav.Nombre}, {itemSav.Edad}, {itemSav.DosisRecibidas}";


                                    file.WriteLine(linea);
                                }

                            }


                            Console.WriteLine();
                            Console.WriteLine($"{item.Nombre} has sido vacunado con exito, ahora tienes {item.DosisRecibidas} dosis.");
                            Console.WriteLine("Actualizando informacion del archivo externo.....");
                            Console.WriteLine(".............");


                            Console.WriteLine(" Ya que hemos finalizado, volveras al menu principal.");
                            Console.WriteLine();
                            comienzoDeAplicacion();
                        }


                    }
                    else if (respuesta >= 2)
                    {
                        Console.WriteLine("No se puede color mas de una dosis por dia.");
                        comienzoDeAplicacion();
                    }

                    else
                    {
                        Console.WriteLine("Cantidad no aprobada todavia por el CDC.");
                    }
                }
                if (id == item.Id && item.DosisRecibidas == 2)
                {
                    Console.WriteLine($"Hola {item.Nombre}.");
                    Console.WriteLine($"Actualmente tienes {item.DosisRecibidas} vacuna, con {item.Edad} años.");
                    Console.WriteLine("Ya no puedes ponerte mas dosis.");
                    Console.WriteLine("Regresaras al menu principal.");
                    Console.WriteLine();
                    comienzoDeAplicacion();
                }
                if (id > persona.Count)
                {
                    Console.WriteLine($"ID {id} no fue encontrado, regresaras al menu principal.");
                    Console.WriteLine();
                    comienzoDeAplicacion();

                }
            }
        }

        public void anadirPersona(List<Personas> persona)
        {
            bool terminar = false;
            if (persona.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos de (Vacuna y Persona) en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }
            do
            {
                string filePath = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Personas.txt";
                string linea = "";
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    int edad;

                    Console.WriteLine("Debes llenar los siguientes datos que te pediremos.");
                    Console.WriteLine();
                    Console.WriteLine();
                    try
                    {
                        Console.Write("ID de la persona: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nombre de la persona: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Edad de la persona: ");
                        edad = int.Parse(Console.ReadLine());
                        Console.Write("Dosis de la persona: ");
                        int dosis = int.Parse(Console.ReadLine());

                        foreach (var itemSav in persona)
                        {
                            if (id == itemSav.Id)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Debe entrar un id que no exista.");
                                Console.WriteLine();
                                Console.WriteLine("Volveras al menu principal.");
                                terminar = false;
                                comienzoDeAplicacion();


                            }
                        }

                        if (id == 0 || edad == 0 || dosis == 0)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Debe llenar todos los campos solicitados.");
                            Console.WriteLine("Volviendo al menu...");
                            comienzoDeAplicacion();
                        }
                        Console.WriteLine();
                        Console.WriteLine("Desea añadir a otra persona? (si o no)");
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta == "si")
                        {
                            linea = $"{id}, {nombre}, {edad}, {dosis}";
                            file.WriteLine(linea);
                            Console.WriteLine();
                            Console.WriteLine("Archivo externo actualizado.");
                            terminar = false;
                        }
                        else
                        {
                            linea = $"{id}, {nombre}, {edad}, {dosis}";
                            file.WriteLine(linea);
                            Console.WriteLine();
                            Console.WriteLine("Archivo externo actualizado.");
                            terminar = true;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Debes completar la información.");
                        Console.WriteLine("Volveras al menu principl.");
                        Console.WriteLine();
                        comienzoDeAplicacion();
                    }


                }
            } while (!terminar);

        }

        public void anadirVacuna(List<Vacunas> vacuna)
        {
            bool terminar = false;
            if (vacuna.Count == 0)
            {
                Console.WriteLine("Error, debe primero cargar los datos de (Vacuna y Persona) en la opción 1 del menu.");
                Console.WriteLine();
                comienzoDeAplicacion();

            }
            do
            {
                string filePath = @"C:\Users\alexm\OneDrive\Desktop\C# Practice\AdministracionVacunasCovid\Vacunas.txt";
                string linea = "";
                using (StreamWriter file = new StreamWriter(filePath, true))
                {
                    

                    Console.WriteLine("Debes llenar los siguientes datos que te pediremos.");
                    Console.WriteLine();
                    Console.WriteLine();
                    try
                    {
                        string nombre = "Compañia: ";
                        Console.Write("Nombre de la compañia: ");
                         nombre += Console.ReadLine();
                        Console.Write("Cantidad Admnistrada: ");
                        string cantidadAdm = Console.ReadLine();
                        Console.Write("Cantidad Disponible: ");
                        int cantgidadDisp = int.Parse(Console.ReadLine());


                        foreach (var itemSav in vacuna)
                        {
                            if (nombre == itemSav.NombreCompania)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Debe entrar un nombre que no exista.");
                                Console.WriteLine();
                                Console.WriteLine("Volveras al menu principal.");
                                terminar = false;
                                comienzoDeAplicacion();


                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine("Desea añadir a otra Compañia con la información de su vacuna? (si o no)");
                        string respuesta = Console.ReadLine().ToLower();

                        if (respuesta == "si")
                        {
                            linea = $"{nombre}, {cantidadAdm}, {cantgidadDisp}";
                            file.WriteLine(linea);
                            Console.WriteLine();
                            Console.WriteLine("Archivo externo actualizado.");
                            terminar = false;
                        }
                        else
                        {
                            linea = $"{nombre}, {cantidadAdm}, {cantgidadDisp}";
                            file.WriteLine(linea);
                            Console.WriteLine();
                            Console.WriteLine("Archivo externo actualizado.");
                            terminar = true;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Debes completar la información.");
                        Console.WriteLine("Volveras al menu principl.");
                        Console.WriteLine();
                        comienzoDeAplicacion();
                    }


                }
            } while (!terminar);
        }

        public void terminarAplicacion()
        {
            Console.WriteLine("Gracias por utilizar la Aplicación, hasta luego. ");
            Environment.Exit(0);


        }

    }
}
