namespace Prueba1Thread;

using System;
using System.Threading;

class Program
{
    static string[] opciones = { "Piedra", "Papel", "Tijeras" };
    static int puntajeJugador1 = 0;
    static int puntajeJugador2 = 0;
    static Random random = new Random();
    static object lockObject = new object();

    static void Main(string[] args)
    {
        Thread jugador1 = new Thread(Jugar);
        Thread jugador2 = new Thread(Jugar);
        Thread jugador3 = new Thread(Jugar);
        Thread jugador4 = new Thread(Jugar);

        jugador1.Start(1);
        jugador2.Start(2);
        jugador1.Join();
        jugador2.Join();
        jugador3.Start(3);
        jugador4.Start(4);
        jugador3.Join();
        jugador4.Join();

        Console.WriteLine("\nResultado Final:");
        Console.WriteLine($"Jugador 1: {puntajeJugador1} puntos");
        Console.WriteLine($"Jugador 2: {puntajeJugador2} puntos");
    }

    static void Jugar(object jugador)
    {
        int idJugador = (int)jugador;

        while (puntajeJugador1 < 2 && puntajeJugador2 < 2)
        {
            //Bloquea el hilo para poder jugar
            lock (lockObject)
            {
                if (puntajeJugador1 >= 2 || puntajeJugador2 >= 2) return;

                string eleccionJugador1 = opciones[random.Next(opciones.Length)];
                string eleccionJugador2 = opciones[random.Next(opciones.Length)];

                Console.WriteLine($"Jugador {idJugador} elige: {eleccionJugador1}");
                Console.WriteLine($"Jugador {idJugador} elige: {eleccionJugador2}");

                int resultado = DeterminarGanador(eleccionJugador1, eleccionJugador2);

                if (resultado == 1)
                {
                    puntajeJugador1++;
                    Console.WriteLine($" Jugador {idJugador} gana esta ronda.");
                }
                else if (resultado == 2)
                {
                    puntajeJugador2++;
                    Console.WriteLine($" Jugador {idJugador} gana esta ronda.");
                }
                else
                {
                    Console.WriteLine("-> Empate en esta ronda.");
                }

                Console.WriteLine($"Puntaje: Jugador {idJugador} - {puntajeJugador1}, Jugador {idJugador} - {puntajeJugador2}\n");
                Thread.Sleep(500); // Pausa para hacer la salida más legible
            }
        }

        if (puntajeJugador1 > puntajeJugador2)
        {
            Console.WriteLine($"\n¡Jugador {idJugador} gana la competición!");
            Console.WriteLine(idJugador);
        }
        else if (puntajeJugador1 < puntajeJugador2)
        {
            Console.WriteLine($"\n¡Jugador {idJugador} gana la competición!");
            Console.WriteLine(idJugador);
        }
        else
        {
            Console.WriteLine("\n¡Es un empate!");
        }
        puntajeJugador1 = 0;
        puntajeJugador2 = 0;
    }

    static int DeterminarGanador(string eleccion1, string eleccion2)
    {
        if (eleccion1 == eleccion2) return 0;
        if ((eleccion1 == "Piedra" && eleccion2 == "Tijeras") ||
            (eleccion1 == "Papel" && eleccion2 == "Piedra") ||
            (eleccion1 == "Tijeras" && eleccion2 == "Papel"))
        {
            return 1;
        }
        return 2;
    }
}
