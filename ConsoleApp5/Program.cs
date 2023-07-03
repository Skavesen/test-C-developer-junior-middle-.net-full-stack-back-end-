using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    // Абстрактный класс для фигур
    public abstract class Shape
    {
        // Абстрактный метод для вычисления площади
        public abstract double Area();

        // Метод для проверки, является ли фигура прямоугольной
        public virtual bool IsRightAngled()
        {
            return false;
        }
    }

    // Класс для круга
    public class Circle : Shape
    {
        // Поле для радиуса
        private double radius;

        // Конструктор с параметром
        public Circle(double radius)
        {
            this.radius = radius;
        }

        // Переопределение метода для вычисления площади
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
    }

    // Класс для треугольника
    public class Triangle : Shape
    {
        // Поля для сторон
        private double a, b, c;

        // Конструктор с параметрами
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        // Переопределение метода для вычисления площади по формуле Герона
        public override double Area()
        {
            double p = (a + b + c) / 2; // полупериметр
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c)); // формула Герона
        }

        // Переопределение метода для проверки, является ли треугольник прямоугольным по теореме Пифагора
        public override bool IsRightAngled()
        {
            // Сортируем стороны по возрастанию
            var sides = new List<double>() { a, b, c };
            sides.Sort();

            // Проверяем, что квадрат гипотенузы равен сумме квадратов катетов с некоторой погрешностью
            return Math.Abs(sides[2] * sides[2] - (sides[0] * sides[0] + sides[1] * sides[1])) < 1e-6;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем список фигур
            var shapes = new List<Shape>();

            // Добавляем в список круг с радиусом 5 и треугольник со сторонами 3, 4, 5
            shapes.Add(new Circle(5));
            shapes.Add(new Triangle(3, 4, 5));

            // Для каждой фигуры в списке выводим ее площадь и тип
            foreach (var shape in shapes)
            {
                Console.WriteLine($"Площадь фигуры: {shape.Area():F2}");
                Console.WriteLine($"Тип фигуры: {shape.GetType().Name}");
                Console.WriteLine($"Является ли фигура прямоугольной: {shape.IsRightAngled()}");
                Console.WriteLine();
            }
        }
    }
}