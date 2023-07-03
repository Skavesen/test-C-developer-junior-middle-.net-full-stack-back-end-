using System;
using NUnit.Framework;
using ConsoleApp5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject1
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void AreaTest()
        {
            var circle = new Circle(5); // создаем круг с радиусом 5
            var expected = 78.54; // ожидаемое значение площади с точностью до двух знаков

            var actual = circle.Area(); // вычисляем фактическое значение площади

            Assert.AreEqual(expected, actual, 0.01); // сравниваем ожидаемое и фактическое значения с погрешностью 0.01
        }

        [Test]
        public void IsRightAngledTest()
        {
            var circle = new Circle(5); // создаем круг с радиусом 5
            var expected = false; // ожидаемое значение для прямоугольности
                        
            var actual = circle.IsRightAngled(); // вычисляем фактическое значение для прямоугольности
                       
            Assert.AreEqual(expected, actual); // сравниваем ожидаемое и фактическое значения
        }
    }
}
