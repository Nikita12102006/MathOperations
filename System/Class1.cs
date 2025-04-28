using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Class1
    {
        public static double Factorial(double x)
        {
            try
            {
                // Проверка на отрицательные значения
                if (x < 0)
                {
                    // Генерируем исключение, если входное значение отрицательное
                    throw new ArgumentOutOfRangeException(nameof(x), "Значение должно быть неотрицательным.");
                }

                // Базовый случай рекурсии: факториал 0 и 1 равен 1
                if (x == 0 || x == 1)
                {
                    return 1;
                }

                // Рекурсивный случай: факториал числа x равен x умноженное на факториал (x-1)
                return x * Factorial(x - 1);
            }
            catch (StackOverflowException)
            {
                // Обработка переполнения стека (может возникнуть при очень больших x)
                Console.WriteLine("Ошибка: Переполнение стека при вычислении факториала.");
                // Повторно генерируем исключение для обработки выше по стеку вызовов
                throw;
            }
        }

    }
}
