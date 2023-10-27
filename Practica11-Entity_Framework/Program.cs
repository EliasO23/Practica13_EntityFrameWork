// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Practica11_Entity_Framework;
using System.ComponentModel;

EstudianteContext contextdb = new EstudianteContext();

Console.WriteLine("          Bienvenido al Registro Estudiantil UNAB          ");
Console.WriteLine("------------------------------------------------------------");
Console.WriteLine(" La nueva actualizacion presenta las opciones de actualizar \n   y eliminar registros, para acceder a ellos ingresa a \n               la opcion: CRUD Estudiantes");

bool comprobar = true;
while (comprobar == true)
{
    Console.WriteLine("\n---------------------------");
    Console.WriteLine("           MEMU            ");
    Console.WriteLine("---------------------------");
    Console.Write("  1. Listar Estudiantes \n  2. CRUD Estudiantes \n  3. Salir\nRespuesta: ");
    int desicion = Convert.ToInt32(Console.ReadLine());

    switch (desicion)
    {
        case 1:
            Console.WriteLine("\nListado de Estudiantes");
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" Id  Nombres                 ");
            Console.WriteLine("-----------------------------");

            foreach (var est in contextdb.Estudiante)
            {
                Console.WriteLine($" {est.Id}   {est.Nombres} {est.Apellidos}  \n     Edad: {est.Edad}    Sexo: {est.Sexo}");
            }

            break;

        case 2:
            Console.WriteLine("\nCRUD Estudiantes");
            Console.WriteLine("-----------------------------");
            Console.Write("  1. Automaticamente(Prueba) \n  2. Ingresar nuevo estudiante  \n  3. Actualizar estudiantes  \n  4. Eliminar estudiante\nRespuesta: ");
            int desicion2 = Convert.ToInt32(Console.ReadLine());

            switch (desicion2)
            {
                case 1:
                    Console.WriteLine("\nAgregar Estudiante Prueba");
                    Console.WriteLine("---------------------------------------");
                    contextdb.Database.EnsureCreated();
                    Estudiante estudiante1 = new Estudiante() { Nombres = "Rosa Maria", Apellidos = "Guardado Peña", Edad = 20, Sexo = "F" };
                    contextdb.Add(estudiante1);
                    contextdb.SaveChanges();

                    Console.WriteLine("\n - ESTUDIANTE INGRESADO CORRECTAMENTE \n");

                    foreach (var est in contextdb.Estudiante)
                    {
                        Console.WriteLine($" {est.Id}  Nombre: {est.Nombres} {est.Apellidos}  \n    Edad: {est.Edad}     Sexo: {est.Sexo}");
                    }

                    break;

                case 2:
                    int bucle = 1;
                    while (bucle == 1)
                    {
                        Console.WriteLine("\nAgregar Estudiante");
                        Console.WriteLine("----------------------------------");

                        try
                        {
                            Console.Write(" - Ingrese los nombres: \n   ");
                            string Nombres = Console.ReadLine();
                            Console.Write(" - Ingrese los apellidos: \n   ");
                            string Apellidos = Console.ReadLine();
                            Console.Write(" - Ingrese la edad: \n   ");
                            int Edad = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine(" - Ingrese el sexo del estudiante");
                            Console.Write("   1. Masculino\n   2. Femenino\nSexo: ");
                            string? desicion3 = Console.ReadLine();
                            string Sexo = "";

                            if (desicion3 == "1" || desicion3.ToLower() == "masculino")
                            {
                                Sexo = Convert.ToString('M');
                            }
                            else if (desicion3 == "2" || desicion3.ToLower() == "femenino")
                            {
                                Sexo = Convert.ToString('F');
                            }
                            else
                            {
                                Console.WriteLine("\n - Opcion Invalida \n   Ingrese los datos nuevamente");
                                bucle = 1;
                                continue;
                            }

                            Estudiante Estudiante = new Estudiante() { Nombres = Nombres, Apellidos = Apellidos, Edad = Edad, Sexo = Sexo };

                            contextdb.Add(Estudiante);
                            contextdb.SaveChanges();

                            Console.WriteLine("\n - ESTUDIANTE INGRESADO CORRECTAMENTE \n");

                            foreach (var est in contextdb.Estudiante)
                            {
                                Console.WriteLine($" {est.Id}  Nombre: {est.Nombres} {est.Apellidos}  \n    Edad: {est.Edad}     Sexo: {est.Sexo}");
                            }

                            Console.Write("\nPulse ENTER para continuar: ");
                            var cont = Console.ReadLine();

                        }
                        catch
                        {
                            Console.WriteLine("Error al agregar estudiante. Asegúrese de que los datos sean válidos.");
                        }

                        Console.WriteLine("\nColoque: ");
                        Console.WriteLine("   1. Agregar otro estudiante  ");
                        Console.WriteLine("   2. Salir                 ");
                        Console.Write("- ¿Que desea hacer? ");
                        bucle = Convert.ToInt32(Console.ReadLine());
                    }
                    break;

                case 3:
                    int bucle1 = 1;
                    while (bucle1 == 1)
                    {
                        Console.WriteLine("\nActualizar Registro-Estudiante");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("Ingrese el Id del estudiante a actualizar");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var estudiante = contextdb.Estudiante.FirstOrDefault(x => x.Id == id);

                        if (estudiante == null)
                        {
                            Console.WriteLine("\nEl estudiante no existe");
                        }
                        else
                        {
                            Console.WriteLine("\nRegistro a actualizar:");
                            Console.WriteLine("\n Id   Nombre  ");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine($"  {estudiante.Id}   {estudiante.Nombres} {estudiante.Apellidos}\n      Edad: {estudiante.Edad}    Sexo: {estudiante.Sexo}  ");

                            Console.WriteLine("\nPara actualizar coloca:       ");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("   1. Nombres   \n   2. Apellidos   \n   3. Edad   \n   4. Sexo");
                            Console.WriteLine("-----------------------------------");
                            Console.Write("- ¿Que desea actualizar? ");
                            
                            try
                            {
                                var Lector = Convert.ToInt32(Console.ReadLine());

                                if (Lector <= 0 || Lector >= 5 )
                                {
                                    Console.WriteLine(" Opcion Invalida");
                                }
                                else
                                {
                                    switch (Lector)
                                    {
                                        case 1:
                                            Console.WriteLine("\nIngrese los nombres del estudiante:");
                                            estudiante.Nombres = Console.ReadLine();
                                            break;
                                        case 2:
                                            Console.WriteLine("\nIngrese los apellidos del estudiante:");
                                            estudiante.Apellidos = Console.ReadLine();
                                            break;
                                        case 3:
                                            Console.WriteLine("\nIngrese la edad del estudiante:");
                                            estudiante.Edad = Convert.ToInt32(Console.ReadLine());
                                            break;
                                        case 4:
                                            Console.WriteLine("\nIngrese el sexo del estudiante:");
                                            Console.Write("   1. Masculino\n   2. Femenino\nSexo: ");
                                            string? desicion3 = Console.ReadLine();

                                            if (desicion3 == "1" || desicion3.ToLower() == "masculino")
                                            {
                                                estudiante.Sexo = Convert.ToString('M');
                                            }
                                            else if (desicion3 == "2" || desicion3.ToLower() == "femenino")
                                            {
                                                estudiante.Sexo = Convert.ToString('F');
                                            }
                                            else
                                            {
                                                Console.WriteLine("\n - Opcion Invalida \n   Ingrese los datos nuevamente");
                                                bucle1 = 1;
                                                continue;
                                            }
                                            break;

                                        default:
                                            Console.WriteLine("\nOpcion Invalida");
                                            continue;
                                    }
                                    contextdb.Update(estudiante);
                                    contextdb.SaveChanges();

                                    Console.WriteLine("\n - ACTUALIZACIÓN CORRECTA");

                                    Console.WriteLine("\nColoque: ");
                                    Console.WriteLine("   1. Continuar actualizando        ");
                                    Console.WriteLine("   2. Salir                         ");
                                    Console.Write("- ¿Que desea hacer? ");
                                    bucle1 = Convert.ToInt32(Console.ReadLine());

                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("\nError al actualizar el estudiante. Asegúrese de que los datos sean correctos.");
                            }
                        }
                    }

                    break;

                case 4:
                    int bucle2 = 1;
                    while (bucle2 == 1)
                    {
                        Console.WriteLine("\nEliminar Registro-Estudiante");
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("Ingrese el Id del estudiante a eliminar");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var estudiante = contextdb.Estudiante.SingleOrDefault(x => x.Id == id);

                        if (estudiante == null)
                        {
                            Console.WriteLine("\nEl estudiante no existe");

                        }
                        else
                        {
                            Console.WriteLine("\nRegistro a eliminar:");
                            Console.WriteLine("\n Id   Nombre  ");
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine($"  {estudiante.Id}   {estudiante.Nombres} {estudiante.Apellidos}\n      Edad: {estudiante.Edad}    Sexo: {estudiante.Sexo}  ");
                            Console.WriteLine("\n¿Desea eliminar este registro permanentemente?");
                            Console.WriteLine("  1. Si    ");
                            Console.WriteLine("  2. No    ");
                            Console.Write("  - Opcion: ");
                            var Lector = Convert.ToInt32(Console.ReadLine());

                            if (Lector == 1)
                            {
                                contextdb.Estudiante.Remove(estudiante);
                                contextdb.SaveChanges();
                                Console.WriteLine("\n Registro borrado satisfactoriamente");

                            }
                            else
                            {
                                Console.WriteLine("\n Inicie nuevamente");

                            }
                            Console.WriteLine("\nColoque: ");
                            Console.WriteLine("   1. Continuar eliminando          ");
                            Console.WriteLine("   2. Salir                         ");
                            Console.Write("- ¿Que desea hacer? ");
                            bucle2 = Convert.ToInt32(Console.ReadLine());

                        }
                    }

                    break;

                default:
                    Console.WriteLine("\n - Opcion Incorrecta");
                    break;
            }
            break;

        case 3:
            Console.WriteLine("\nGracias por visitar nuestro programa \n - Feliz dia");
            comprobar = false;
            break;

        default:
            Console.WriteLine("\n - Opcion Incorrecta");
            break;
    }

}


