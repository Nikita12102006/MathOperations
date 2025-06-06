﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Class1
    {
        // подсчет факториала числа
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

        // подсчет степени числа
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

        // метод для вычисления n-го числа Фибоначчи (итеративный, эффективный)
        public static int Fibonacci(int n)
        {
            if (n < 0)
                throw new ArgumentException("n должно быть ≥ 0");

            if (n == 0) return 0;
            if (n == 1) return 1;

            int a = 0, b = 1, result = 0;
            for (int i = 2; i <= n; i++)
            {
                result = a + b;
                a = b;
                b = result;
            }
            return result;
        }

        //Метод для нахождени Дискриминанта
        public static int Discriminant(int a, int b, int c)
        {
            try
            {
                checked
                {
                    int bb = b * b;
                    int ac4 = 4 * a * c; 
                    int discriminant = bb - ac4;
                    return discriminant;
                }
            }
            catch (OverflowException ex)
            {
                throw new OverflowException("Произошло переполнение при вычислении дискриминанта. Введите меньшие коэффициенты.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при вычислении дискриминанта", ex);
            }
        }

        public static double FindNthRoot(double chislo, int stepen, double epsilon = 0.0001)
        {
            if (stepen <= 0)
                throw new ArgumentException("Степень корня должна быть положительной", nameof(stepen));

            if (chislo < 0 && stepen % 2 == 0)
                throw new ArgumentException("Корень чётной степени из отрицательного числа не определён", nameof(chislo));

            if (chislo == 0)
                return 0;

            double priblizhenie = chislo;
            double predydusheePriblizhenie;

            do
            {
                predydusheePriblizhenie = priblizhenie;
                priblizhenie = ((stepen - 1) * priblizhenie + chislo / Math.Pow(priblizhenie, stepen - 1)) / stepen;
            }
            while (Math.Abs(priblizhenie - predydusheePriblizhenie) > epsilon);

            return priblizhenie;
        }
    }
}
