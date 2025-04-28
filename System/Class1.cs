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

        public static double CalculatePower(double baseNumber, double exponent)
        {

            // Особый случай: любое число в степени 0 равно 1
            if (exponent == 0)
            {
                return 1;
            }

            // Особый случай: 0 в отрицательной степени - деление на 0
            if (baseNumber == 0 && exponent < 0)
            {
                throw new ArithmeticException("Невозможно возвести 0 в отрицательную степень");
            }

            try
            {
                double result = Math.Pow(baseNumber, exponent);

                // Проверка на переполнение
                if (double.IsInfinity(result))
                {
                    throw new ArithmeticException("Результат слишком большой и вызвал переполнение");
                }

                return result;
            }
            catch (OverflowException ex)
            {
                throw new ArithmeticException("Произошло переполнение при вычислении степени", ex);
            }
        }

        // метод для вычисления логарифма с произвольным основанием
        public static double Log(double x, double b)
        {
            if (x <= 0 || b <= 0 || b == 1)
                throw new ArgumentException("Ошибка: x и b должны быть > 0, а b ≠ 1");

            return Math.Log(x) / Math.Log(b);
        }
    }
}
