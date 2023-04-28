using System;
class Program
{
    static void Main(string[] args)
    {
        int[,] tablero = new int[5, 5];// Crear un tablero de juego bidimensional de tamaño 5x5 con todas las celdas con el valor 0

        // Colocar algunos barcos en el tablero asignando el valor 1 a ciertas celdas. Crear una función para generar posiciones aleatorias.
        Random rand = new Random();
        int barcos = 5;
        while (barcos > 0)
        {
            int fila = rand.Next(0, 5);
            int columna = rand.Next(0, 5);
            if (tablero[fila, columna] == 0)
            {
                tablero[fila, columna] = 1;
                barcos--;
            }
        }

        // Mostrar el tablero de juego al usuario sin revelar las posiciones de los barcos. Mostrar un símbolo "~" para las celdas sin descubrir.
        Console.WriteLine("¡Bienvenido al juego de batalla naval!");
        for (int fila = 0; fila < 5; fila++)
        {
            for (int columna = 0; columna < 5; columna++)
            {
                if (tablero[fila, columna] == 2)
                {
                    Console.Write("2 "); // Si la celda ha sido atacada y había un barco, mostrar una "X"
                }
                else if (tablero[fila, columna] == -1)
                {
                    Console.Write("-1 "); // Si la celda ha sido atacada y no había un barco, mostrar una "O"
                }
                else
                {
                    Console.Write("~ "); // Si la celda no ha sido atacada, mostrar una "~"
                }
            }
            Console.WriteLine(); // Agregar una nueva línea después de cada fila
        }

        int intentos = 0;
        int barcosRestantes = 5;
        List<string> coordenadasUtilizadas = new List<string>();

        while (barcosRestantes > 0)
        {
            // Pedir al usuario que ingrese coordenadas (fila y columna) para atacar en el tablero
            int filaAtaque, columnaAtaque;

            while (true)
            {
                Console.Write("Ingrese la fila para atacar (0-4): ");
                filaAtaque = int.Parse(Console.ReadLine());
                if (filaAtaque >= 0 && filaAtaque <= 4)
                {
                    break;
                }
                Console.WriteLine("La fila ingresada no existe. Ingrese nuevamente.");
            }

            while (true)
            {
                Console.Write("Ingrese la columna para atacar (0-4): ");
                columnaAtaque = int.Parse(Console.ReadLine());
                if (columnaAtaque >= 0 && columnaAtaque <= 4)
                {
                    break;
                }
                Console.WriteLine("La columna ingresada no existe. Ingrese nuevamente.");
            }

            // Verificar si las coordenadas ya han sido utilizadas
            string coordenadas = filaAtaque.ToString() + "," + columnaAtaque.ToString();
            if (coordenadasUtilizadas.Contains(coordenadas))
            {
                Console.WriteLine("Las coordenadas que ingresó ya han sido utilizadas. Ingrese otras.");
                continue; // Pedir al usuario que ingrese nuevas coordenadas
            }
            coordenadasUtilizadas.Add(coordenadas);

            // Verificar si el usuario ha golpeado un barco. Si es así, cambiar el valor de la celda a 2 y mostrar un mensaje indicando que ha golpeado un barco. Sino, cambiar el valor a -1 e indicar que ha fallado.
            if (tablero[filaAtaque, columnaAtaque] == 1)
            {
                Console.WriteLine("¡Has golpeado un barco!");
                Console.Beep(800, 500);
                tablero[filaAtaque, columnaAtaque] = 2;
                barcosRestantes--;
            }
            else
            {
                Console.WriteLine("Ha fallado, vuelve a intentarlo");
                Console.Beep(440, 500);
                tablero[filaAtaque, columnaAtaque] = -1;
            }

            // Mostrar el tablero de juego actualizado al usuario
            Console.WriteLine("Tablero actualizado:");
            for (int fila = 0; fila < 5; fila++)
            {
                for (int columna = 0; columna < 5; columna++)
                {
                    if (tablero[fila, columna] == 2)
                    {
                        Console.Write("2 "); // Si la celda ha sido atacada y había un barco, mostrar un "2"
                    }
                    else if (tablero[fila, columna] == -1)
                    {
                        Console.Write("-1 "); // Si la celda ha sido atacada y no había un barco, mostrar un "-1"
                    }
                    else
                    {
                        Console.Write("~ "); // Si la celda no ha sido atacada, mostrar una "~"
                    }
                }
                Console.WriteLine(); // Agregar una nueva línea después de cada fila
            }
            intentos++; // Incrementar el número de intentos después de cada ataque
        }

        // Mostrar un mensaje de felicitaciones y la cantidad de intentos que le tomó al usuario completar el juego.
        Console.WriteLine("¡Felicitaciones, ha ganado la batalla naval en " + intentos + " intentos!");
        Console.Beep(1500, 500); Console.Beep(1500, 500); Console.Beep(1500, 500);
    }
}
