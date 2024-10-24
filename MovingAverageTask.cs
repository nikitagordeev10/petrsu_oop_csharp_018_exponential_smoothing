//using System.Collections.Generic;

//namespace yield;

//public static class MovingAverageTask
//{
//	public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
//	{
//		//Fix me!
//		return data;
//	}
//}

// Используем пространство имен System.Collections.Generic, чтобы использовать класс Queue<T>
//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) { // IEnumerable метод

//            if (windowWidth <= 0) // Выбрасываем ошибку, если размер окна меньше или равен нулю
//                throw new System.ArgumentOutOfRangeException();

//            var queue = new Queue<double>(); // создаем очередь последних значений Y
//            var sum = 0.0; // текущая сумма элементов окна
//            var result = 0.0; // Инициализируем результат в нуль

//            foreach (var point in data) { // Для каждой точки данных в коллекции данных
//                queue.Enqueue(point.OriginalY); // Добавляем значение Y текущей точки данных в очередь последних значений Y

//                if (queue.Count < windowWidth) { // Если мы не получили достаточное количество последних значений Y
//                    sum += point.OriginalY; // Добавляем значение текущей точки данных к сумме последних значений Y
//                    result = sum / (queue.Count + 1); // Рассчитываем среднее значение путем деления суммы на количество последних значений + 1
//                } else
//                    result += (point.OriginalY - queue.Dequeue()) / windowWidth; // Иначе рассчитываем среднее значение, используя значения текущей точки данных и последней точки данных в окне

//                var newDataPoint = point.WithAvgSmoothedY(result); // Создаем новую точку данных с сглаженным значением
//                yield return newDataPoint; // Возвращаем новую точку данных с помощью оператора yield
//            }
//        }
//    }
//}

// Используем пространство имен System.Collections.Generic, чтобы использовать класс Queue<T>
using System.Collections.Generic;

namespace yield {
    public static class MovingAverageTask {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) { // IEnumerable метод

            var queue = new Queue<double>(); // очередь последних значений Y
            var sum = 0.0; // текущая сумма элементов окна

            foreach (var point in data) { // перебираем все точки входных данных
                queue.Enqueue(point.OriginalY); // добавляем значение Y текущей точки данных в очередь последних значений Y
                sum += point.OriginalY; // обновляем сумму элементов окна

                if (queue.Count > windowWidth) // если в очереди хранится больше значений, чем размер окна
                    sum -= queue.Dequeue(); // удаляем первое значение из очереди и вычитаем его из суммы

                if (queue.Count >= windowWidth) { // если в очереди уже нужное количество значений
                    yield return point.WithAvgSmoothedY(sum / windowWidth);  // точка с сглаженным значением
                } else { // если в очереди еще недостаточно значений для обработки
                    yield return point.WithAvgSmoothedY(sum / queue.Count); // сглаживание на основе имеемых данных
                }
            }
        }
    }
}

//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {

//            var queue = new Queue<double>(); // последние элементы
//            var sum = 0.0; // текущая сумма элементов окна

//            foreach (var point in data) { // перебираем все точки входных данных
//                queue.Enqueue(point.OriginalY); // добавляем элемент в очередь
//                sum += point.OriginalY; // обнавляем текущую сумму

//                if (queue.Count > windowWidth) // если прошли ли размер окна
//                    sum -= queue.Dequeue(); // удаляем первый элемент и корректируем сумму

//                if (queue.Count >= windowWidth) { // если достигли размера окна
//                    yield return new DataPoint(point.X, sum / windowWidth); // новая точка с сглаженным значением
//                } else { // меньше размера окна
//                    yield return new DataPoint(point.X, sum / queue.Count); // сглаживание на основе имеемых данных
//                }
//            }
//        }
//    }
//}


//// Используем пространство имен System.Collections.Generic, чтобы использовать класс Queue<T>
//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) { // IEnumerable метод

//            var queue = new Queue<double>(); // создаем очередь последних значений Y
//            var sum = 0.0; // текущая сумма элементов окна
//            var result = 0.0; // Инициализируем результат в нуль

//            foreach (var point in data) { // Для каждой точки данных в коллекции данных
//                queue.Enqueue(point.OriginalY); // Добавляем значение Y текущей точки данных в очередь последних значений Y

//                if (queue.Count < windowWidth) { // Если мы не получили достаточное количество последних значений Y
//                    sum += point.OriginalY; // Добавляем значение текущей точки данных к сумме последних значений Y
//                    result = sum / (queue.Count + 1); // Рассчитываем среднее значение путем деления суммы на количество последних значений + 1
//                } else
//                    result += (point.OriginalY - queue.Dequeue()) / windowWidth; // Иначе рассчитываем среднее значение, используя значения текущей точки данных и последней точки данных в окне

//                var newDataPoint = point.WithAvgSmoothedY(result); // Создаем новую точку данных с сглаженным значением
//                yield return newDataPoint; // Возвращаем новую точку данных с помощью оператора yield
//            }
//        }
//    }
//}

//using System.Collections.Generic; // Используем пространство имен System.Collections.Generic, чтобы использовать класс Queue<T>

//namespace yield {
//    // Создаем статический класс MovingAverageTask
//    public static class MovingAverageTask {
//        // Создаем метод MovingAverage, который является IEnumerable
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {
//            // Выбрасываем исключение, если заданный размер окна меньше или равен нулю
//            if (windowWidth <= 0)
//                throw new System.ArgumentOutOfRangeException();
//            // Создаем очередь последних значений Y
//            Queue<double> lastYs = new Queue<double>();
//            // Инициализируем сумму и результат в нуль
//            double sum = 0;
//            double result = 0;
//            // Для каждой точки данных в коллекции данных
//            foreach (var dataPoint in data) {
//                // Если мы не получили достаточное количество последних значений Y
//                if (lastYs.Count < windowWidth) {
//                    // Добавляем значение текущей точки данных к сумме последних значений Y
//                    sum += dataPoint.OriginalY;
//                    // Рассчитываем среднее значение путем деления суммы на количество последних значений + 1
//                    result = sum / (lastYs.Count + 1);
//                } else
//                    // Иначе рассчитываем среднее значение, используя значения текущей точки данных и последней точки данных в окне
//                    result += (dataPoint.OriginalY - lastYs.Dequeue()) / windowWidth;
//                // Создаем новую точку данных с сглаженным значением
//                var newDataPoint = dataPoint.WithAvgSmoothedY(result);
//                // Возвращаем новую точку данных с помощью оператора yield
//                yield return newDataPoint;
//                // Добавляем значение Y текущей точки данных в очередь последних значений Y
//                lastYs.Enqueue(dataPoint.OriginalY);
//            }
//        }
//    }
//}


//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {
//            if (windowWidth <= 0)
//                throw new System.ArgumentOutOfRangeException();

//            Queue<double> lastYs = new Queue<double>(); // Очередь для хранения последних элементов окна
//            double sum = 0; // Текущая сумма элементов окна
//            double result = 0; // Текущее усредненное значение

//            foreach (var dataPoint in data) {
//                if (lastYs.Count < windowWidth) // Если количество элементов в окне меньше размера окна
//                {
//                    sum += dataPoint.OriginalY; // Добавляем новый элемент в сумму
//                    result = sum / (lastYs.Count + 1); // Усредняем все элементы окна

//                } else // Если количество элементов в окне равно размеру окна
//                  {
//                    result += (dataPoint.OriginalY - lastYs.Dequeue()) / windowWidth; // Обновляем усредненное значение на основе нового элемента и предыдущего первого элемента окна
//                }

//                var newDataPoint = dataPoint.WithAvgSmoothedY(result); // Создаем новую точку с усредненным значением
//                yield return newDataPoint; // Возвращаем новую точку
//                lastYs.Enqueue(dataPoint.OriginalY); // Добавляем текущий элемент в очередь последних элементов окна
//            }
//        }
//    }
//}

//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {
//            if (windowWidth <= 0)
//                throw new System.ArgumentOutOfRangeException();

//            var queue = new Queue<double>();
//            var sum = 0.0;

//            foreach (var point in data) {
//                queue.Enqueue(point.OriginalY);
//                sum += point.OriginalY;

//                if (queue.Count > windowWidth)
//                    sum -= queue.Dequeue();

//                if (queue.Count >= windowWidth) {
//                    yield return new DataPoint(point.X, sum / windowWidth);
//                } else {
//                    yield return new DataPoint(point.X, sum / queue.Count);
//                }
//            }
//        }
//    }
//}

//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {
//            if (windowWidth <= 0)
//                throw new System.ArgumentOutOfRangeException();

//            var lastWindow = new Queue<double>();
//            var currentWindow = new Queue<double>();
//            var count = 0;
//            var sum = 0.0;

//            foreach (var point in data) {
//                if (count < windowWidth - 1) {
//                    lastWindow.Enqueue(point.OriginalY);
//                    count++;
//                    sum += point.OriginalY;
//                    yield return new DataPoint(point.X, sum / count);
//                } else if (count == windowWidth - 1) {
//                    lastWindow.Enqueue(point.OriginalY);
//                    currentWindow.Enqueue(point.OriginalY);
//                    count++;
//                    sum += point.OriginalY;
//                    yield return new DataPoint(point.X, sum / count);
//                } else {
//                    currentWindow.Enqueue(point.OriginalY);
//                    sum += point.OriginalY;
//                    sum -= lastWindow.Dequeue();
//                    yield return new DataPoint(point.X, sum / windowWidth);
//                }
//            }
//        }
//    }
//}