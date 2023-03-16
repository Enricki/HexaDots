using UnityEngine;

namespace voidHedgeHog.Coordinates
{
    public static class CircleCoordinates
    {
        const float PiInDegrees = 180;

        /// <summary>
        /// Определяет координаты точки исходя из радиуса круга и радианой меры угла
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="pointInRadians"></param>
        /// <returns></returns>\
        public static Vector3 CirclePointPosition(Vector3 zeroCoords, float radius, float radAngle, float offset)
        {
            float degOffset = AngleInRad(offset);
            float x = zeroCoords.x + radius * Mathf.Cos(radAngle / radius  + degOffset);
            float y = zeroCoords.y + radius * Mathf.Sin(radAngle / radius + degOffset);

            return new Vector3(x, y);
        }

        /// <summary>
        /// Конвертирует значение угла из радиан в градусы
        /// </summary>
        /// <param name="radAngle"></param>
        /// <returns></returns>
        public static float AngleInDeg(float radAngle)
        {
            return radAngle * PiInDegrees / Mathf.PI;
        }

        /// <summary>
        /// Конвертирует значение угла из градусов в радианы
        /// </summary>
        /// <param name="degAngle"></param>
        /// <returns></returns>
        public static float AngleInRad(float degAngle)
        {
            return degAngle * Mathf.PI / PiInDegrees;
        }

        /// <summary>
        /// Определяет площадь круга по радиусу
        /// </summary>
        public static float CircleArea(float radius)
        {
            return Mathf.PI * Mathf.Pow(radius, 2);
        }

        /// <summary>
        /// Определяет длинну окружности по радиусу
        /// </summary>
        public static float CirclePerimeter(float radius)
        {
            return 2 * Mathf.PI * radius;
        }
    }
}