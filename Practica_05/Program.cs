using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practica_05.model;

namespace Practica_05
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int op;
            do
            {
                Console.WriteLine("\n\n*************************MENU**********************\n" +
                                  "Por favor, selecciona una opción.\n\n" +
                                  "\n1.- Carga de datos iniciales" +
                                  "\n2.- Listado de cursos disponibles" +
                                  "\n3.- Buscar cursos impartidos por un profesor" +
                                  "\n4.- Obtener total horas lectivas de un profesor" +
                                  "\n5.- Listar alumnos por curso" +
                                  "\n6.- Mostrar profesores de un alumno" +
                                  "\n7.- Salir");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        ComprobarDatosIniciales();
                        break;
                    case 2:
                        ListarCursos();
                        break;
                    case 3:
                        CursosPorProfesor();
                        break;
                    case 4:
                        HorasPorProfesor();
                        break;
                    case 5:
                        AlumnosPorCurso();
                        break;
                    case 6:
                        ProfesoresPorAlumno();
                        break;

                }

            } while (op != 7);
            Console.WriteLine("\n\nHasta pronto!!\n");
            Console.ReadLine();

        }

        private static void ComprobarDatosIniciales()
        {
            using (var ctx = new CentroFormacionEntities())
            {
                var datos = ctx.Alumno.Any();

                if (datos == false)
                {
                    CargarDatosIniciales(ctx);
                }
                else
                {
                    Console.WriteLine("\nSe han encontrado datos iniciales." +
                                      "\n¿Deseas repetir la carga?(Si/No)\n");

                    if (Console.ReadLine() == "Si")
                    {
                        CargarDatosIniciales(ctx);
                    }
                }
            }
        }

        private static void CargarDatosIniciales(CentroFormacionEntities ctx)
        {
            //ALUMNOS
            #region ALUMNOS

            var listaAlumnos = new List<Alumno>()
            {
                new Alumno() {Nombre = "Julian Martinez", DNI = "12345678A"},
                new Alumno() {Nombre = "Paco Porras", DNI = "98765678A"},
                new Alumno() {Nombre = "Julio Iglesias", DNI = "12150971D"},
                new Alumno() {Nombre = "Maria de la O", DNI = "12345678L"},
                new Alumno() {Nombre = "Miguel Antón", DNI = "12345678M"},
                new Alumno() {Nombre = "Pepe Sancho", DNI = "00455678Z"},
                new Alumno() {Nombre = "Fernando VII", DNI = "0000001R"}
            };
            try
            {
                ctx.Alumno.AddRange(listaAlumnos);
                //Commit a la BD
                //ctx.SaveChanges();
                Console.WriteLine("\nAlumnos Inicializados.\nContinuar la carga...\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            //PROFESORES
            #region PROFESORES

            var listaProfesores = new List<Profesor>()
            {
                new Profesor() {Nombre = "El Bueno", Edad = 33},
                new Profesor() {Nombre = "El Chungo", Edad = 22},
                new Profesor() {Nombre = "La Listilla", Edad = 57},
                new Profesor() {Nombre = "El Pasota", Edad = 45},
                new Profesor() {Nombre = "El Risas", Edad = 21},
            };
            try
            {
                ctx.Profesor.AddRange(listaProfesores);
                //Commit a la BD
                //ctx.SaveChanges();
                Console.WriteLine("\nProfesores inicializados.\nContinuar la carga...\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            #endregion

            //AULAS
            #region AULAS

            var listaAula = new List<Aula>()
            {
                new Aula() {Nombre = "Norte", Capacidad = 35},
                new Aula() {Nombre = "Sur", Capacidad = 12},
                new Aula() {Nombre = "Este", Capacidad = 80},
                new Aula() {Nombre = "Oeste", Capacidad = 4},
            };
            try
            {
                ctx.Aula.AddRange(listaAula);
                //Commit a la BD
                //ctx.SaveChanges();
                Console.WriteLine("\nAulas inicializadas.\nContinuar la carga...\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            //CURSOS
            #region CURSOS

            var listaCursos = new List<Curso>()
            {
                new Curso()
                {
                    Nombre = "C#",
                    Duracion = 790,
                    Inicio = new DateTime(2015, 09, 01),
                    Fin = new DateTime(2016, 11, 30),
                    Aula = listaAula[1]
                },
                new Curso()
                {
                    Nombre = "Tricotar para adultos",
                    Duracion = 100,
                    Inicio = new DateTime(2015, 09, 01),
                    Fin = new DateTime(2015, 12, 28),
                    idAula = 2
                },
                new Curso()
                {
                    Nombre = "Cocina Molecular",
                    Duracion = 72,
                    Inicio = new DateTime(2015, 09, 01),
                    Fin = new DateTime(2015, 10, 31),
                    idAula = 3
                },
                new Curso()
                {
                    Nombre = "HTML5 y Tu",
                    Duracion = 324,
                    Inicio = new DateTime(2015, 09, 01),
                    Fin = new DateTime(2016, 03, 15),
                    idAula = 4
                },
                new Curso()
                {
                    Nombre = "Control de la frustración",
                    Duracion = 666,
                    Inicio = new DateTime(2015, 09, 01),
                    Fin = new DateTime(2022, 06, 04),
                    idAula = 3
                },
                new Curso()
                {
                    Nombre = "VideoTutoriales para vagos",
                    Duracion = 2,
                    Inicio = new DateTime(2015, 09, 01),
                    Fin = new DateTime(2174, 12, 01),
                    idAula = 2
                },
                new Curso()
                {
                    Nombre = "Sharepoint for the win!",
                    Duracion = 401,
                    Inicio = new DateTime(2015, 09, 01),
                    Fin = new DateTime(2016, 07, 01),
                    idAula = 1
                }
            };
            try
            {
                ctx.Curso.AddRange(listaCursos);
                //Commit a la BD
                //ctx.SaveChanges();
                Console.WriteLine("\nCursos inicializados.\nContinuar la carga...\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion


            //PROFESORCURSO

            #region PROFESORCURSO
            var listaProfesorCursos = new List<ProfesorCurso>()
            {
                new ProfesorCurso() {Profesor = listaProfesores[1], idCurso = listaCursos[1].idCurso, Horas = 190},
                //new ProfesorCurso() {idProfesor = 1, idCurso = 2, Horas = 50},
                //new ProfesorCurso() {idProfesor = 1, idCurso = 7, Horas = 201},
                //new ProfesorCurso() {idProfesor = 2, idCurso = 1, Horas = 600},
                //new ProfesorCurso() {idProfesor = 2, idCurso = 2, Horas = 50},
                //new ProfesorCurso() {idProfesor = 2, idCurso = 3, Horas = 32},
                //new ProfesorCurso() {idProfesor = 3, idCurso = 3, Horas = 40},
                //new ProfesorCurso() {idProfesor = 3, idCurso = 4, Horas = 124},
                //new ProfesorCurso() {idProfesor = 3, idCurso = 5, Horas = 111},
                //new ProfesorCurso() {idProfesor = 3, idCurso = 7, Horas = 200},
                //new ProfesorCurso() {idProfesor = 4, idCurso = 6, Horas = 2},
                //new ProfesorCurso() {idProfesor = 5, idCurso = 4, Horas = 200},
                //new ProfesorCurso() {idProfesor = 5, idCurso = 5, Horas = 222},
                //new ProfesorCurso() {idProfesor = 4, idCurso = 5, Horas = 333},
            };
            try
            {
                ctx.ProfesorCurso.AddRange(listaProfesorCursos);
                //Commit a la BD
                //ctx.SaveChanges();
                Console.WriteLine("\nRelación de Profesores y Cursos inicializada." +
                                  "\nContinuar la carga...\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            //COMMIT A LA BBDD
            try
            {

                ctx.SaveChanges();
                Console.WriteLine("\nCarga de datos correcta.\n");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        private static void ListarCursos()
        {
            throw new NotImplementedException();
        }

        private static void CursosPorProfesor()
        {
            throw new NotImplementedException();
        }

        private static void HorasPorProfesor()
        {
            throw new NotImplementedException();
        }

        private static void AlumnosPorCurso()
        {
            throw new NotImplementedException();
        }

        private static void ProfesoresPorAlumno()
        {
            throw new NotImplementedException();
        }
    }
}
