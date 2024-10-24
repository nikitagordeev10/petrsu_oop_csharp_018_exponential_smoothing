using System.Collections.Generic;

namespace yield {
    public static class ExpSmoothingTask {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha) {
            double prevSmoothedY = 0.0; // последнее значения сглаженной точки
            bool isFirst = true; // Флаг указывающий, что текущий элемент первый

            foreach (var dataPoint in data) {
                double smoothedY;
                if (isFirst) { // Вычисляем сглаженное значение для первой точки
                    smoothedY = dataPoint.OriginalY;
                    isFirst = false;
                } else { // Вычисляем сглаженное значение для остальных точек используя формулу из Википедии
                    smoothedY = alpha * dataPoint.OriginalY + (1 - alpha) * prevSmoothedY;
                }

                prevSmoothedY = smoothedY; // обновляем последнее значения сглаженной точки
                var smoothedDataPoint = dataPoint.WithExpSmoothedY(smoothedY); // Создаем новый объект
                yield return smoothedDataPoint; // Возвращаем текущую сглаженную точку
            }
        }
    }
}