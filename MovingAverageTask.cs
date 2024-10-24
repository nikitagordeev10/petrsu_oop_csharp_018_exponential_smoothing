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

// ���������� ������������ ���� System.Collections.Generic, ����� ������������ ����� Queue<T>
//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) { // IEnumerable �����

//            if (windowWidth <= 0) // ����������� ������, ���� ������ ���� ������ ��� ����� ����
//                throw new System.ArgumentOutOfRangeException();

//            var queue = new Queue<double>(); // ������� ������� ��������� �������� Y
//            var sum = 0.0; // ������� ����� ��������� ����
//            var result = 0.0; // �������������� ��������� � ����

//            foreach (var point in data) { // ��� ������ ����� ������ � ��������� ������
//                queue.Enqueue(point.OriginalY); // ��������� �������� Y ������� ����� ������ � ������� ��������� �������� Y

//                if (queue.Count < windowWidth) { // ���� �� �� �������� ����������� ���������� ��������� �������� Y
//                    sum += point.OriginalY; // ��������� �������� ������� ����� ������ � ����� ��������� �������� Y
//                    result = sum / (queue.Count + 1); // ������������ ������� �������� ����� ������� ����� �� ���������� ��������� �������� + 1
//                } else
//                    result += (point.OriginalY - queue.Dequeue()) / windowWidth; // ����� ������������ ������� ��������, ��������� �������� ������� ����� ������ � ��������� ����� ������ � ����

//                var newDataPoint = point.WithAvgSmoothedY(result); // ������� ����� ����� ������ � ���������� ���������
//                yield return newDataPoint; // ���������� ����� ����� ������ � ������� ��������� yield
//            }
//        }
//    }
//}

// ���������� ������������ ���� System.Collections.Generic, ����� ������������ ����� Queue<T>
using System.Collections.Generic;

namespace yield {
    public static class MovingAverageTask {
        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) { // IEnumerable �����

            var queue = new Queue<double>(); // ������� ��������� �������� Y
            var sum = 0.0; // ������� ����� ��������� ����

            foreach (var point in data) { // ���������� ��� ����� ������� ������
                queue.Enqueue(point.OriginalY); // ��������� �������� Y ������� ����� ������ � ������� ��������� �������� Y
                sum += point.OriginalY; // ��������� ����� ��������� ����

                if (queue.Count > windowWidth) // ���� � ������� �������� ������ ��������, ��� ������ ����
                    sum -= queue.Dequeue(); // ������� ������ �������� �� ������� � �������� ��� �� �����

                if (queue.Count >= windowWidth) { // ���� � ������� ��� ������ ���������� ��������
                    yield return point.WithAvgSmoothedY(sum / windowWidth);  // ����� � ���������� ���������
                } else { // ���� � ������� ��� ������������ �������� ��� ���������
                    yield return point.WithAvgSmoothedY(sum / queue.Count); // ����������� �� ������ ������� ������
                }
            }
        }
    }
}

//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {

//            var queue = new Queue<double>(); // ��������� ��������
//            var sum = 0.0; // ������� ����� ��������� ����

//            foreach (var point in data) { // ���������� ��� ����� ������� ������
//                queue.Enqueue(point.OriginalY); // ��������� ������� � �������
//                sum += point.OriginalY; // ��������� ������� �����

//                if (queue.Count > windowWidth) // ���� ������ �� ������ ����
//                    sum -= queue.Dequeue(); // ������� ������ ������� � ������������ �����

//                if (queue.Count >= windowWidth) { // ���� �������� ������� ����
//                    yield return new DataPoint(point.X, sum / windowWidth); // ����� ����� � ���������� ���������
//                } else { // ������ ������� ����
//                    yield return new DataPoint(point.X, sum / queue.Count); // ����������� �� ������ ������� ������
//                }
//            }
//        }
//    }
//}


//// ���������� ������������ ���� System.Collections.Generic, ����� ������������ ����� Queue<T>
//using System.Collections.Generic;

//namespace yield {
//    public static class MovingAverageTask {
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) { // IEnumerable �����

//            var queue = new Queue<double>(); // ������� ������� ��������� �������� Y
//            var sum = 0.0; // ������� ����� ��������� ����
//            var result = 0.0; // �������������� ��������� � ����

//            foreach (var point in data) { // ��� ������ ����� ������ � ��������� ������
//                queue.Enqueue(point.OriginalY); // ��������� �������� Y ������� ����� ������ � ������� ��������� �������� Y

//                if (queue.Count < windowWidth) { // ���� �� �� �������� ����������� ���������� ��������� �������� Y
//                    sum += point.OriginalY; // ��������� �������� ������� ����� ������ � ����� ��������� �������� Y
//                    result = sum / (queue.Count + 1); // ������������ ������� �������� ����� ������� ����� �� ���������� ��������� �������� + 1
//                } else
//                    result += (point.OriginalY - queue.Dequeue()) / windowWidth; // ����� ������������ ������� ��������, ��������� �������� ������� ����� ������ � ��������� ����� ������ � ����

//                var newDataPoint = point.WithAvgSmoothedY(result); // ������� ����� ����� ������ � ���������� ���������
//                yield return newDataPoint; // ���������� ����� ����� ������ � ������� ��������� yield
//            }
//        }
//    }
//}

//using System.Collections.Generic; // ���������� ������������ ���� System.Collections.Generic, ����� ������������ ����� Queue<T>

//namespace yield {
//    // ������� ����������� ����� MovingAverageTask
//    public static class MovingAverageTask {
//        // ������� ����� MovingAverage, ������� �������� IEnumerable
//        public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth) {
//            // ����������� ����������, ���� �������� ������ ���� ������ ��� ����� ����
//            if (windowWidth <= 0)
//                throw new System.ArgumentOutOfRangeException();
//            // ������� ������� ��������� �������� Y
//            Queue<double> lastYs = new Queue<double>();
//            // �������������� ����� � ��������� � ����
//            double sum = 0;
//            double result = 0;
//            // ��� ������ ����� ������ � ��������� ������
//            foreach (var dataPoint in data) {
//                // ���� �� �� �������� ����������� ���������� ��������� �������� Y
//                if (lastYs.Count < windowWidth) {
//                    // ��������� �������� ������� ����� ������ � ����� ��������� �������� Y
//                    sum += dataPoint.OriginalY;
//                    // ������������ ������� �������� ����� ������� ����� �� ���������� ��������� �������� + 1
//                    result = sum / (lastYs.Count + 1);
//                } else
//                    // ����� ������������ ������� ��������, ��������� �������� ������� ����� ������ � ��������� ����� ������ � ����
//                    result += (dataPoint.OriginalY - lastYs.Dequeue()) / windowWidth;
//                // ������� ����� ����� ������ � ���������� ���������
//                var newDataPoint = dataPoint.WithAvgSmoothedY(result);
//                // ���������� ����� ����� ������ � ������� ��������� yield
//                yield return newDataPoint;
//                // ��������� �������� Y ������� ����� ������ � ������� ��������� �������� Y
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

//            Queue<double> lastYs = new Queue<double>(); // ������� ��� �������� ��������� ��������� ����
//            double sum = 0; // ������� ����� ��������� ����
//            double result = 0; // ������� ����������� ��������

//            foreach (var dataPoint in data) {
//                if (lastYs.Count < windowWidth) // ���� ���������� ��������� � ���� ������ ������� ����
//                {
//                    sum += dataPoint.OriginalY; // ��������� ����� ������� � �����
//                    result = sum / (lastYs.Count + 1); // ��������� ��� �������� ����

//                } else // ���� ���������� ��������� � ���� ����� ������� ����
//                  {
//                    result += (dataPoint.OriginalY - lastYs.Dequeue()) / windowWidth; // ��������� ����������� �������� �� ������ ������ �������� � ����������� ������� �������� ����
//                }

//                var newDataPoint = dataPoint.WithAvgSmoothedY(result); // ������� ����� ����� � ����������� ���������
//                yield return newDataPoint; // ���������� ����� �����
//                lastYs.Enqueue(dataPoint.OriginalY); // ��������� ������� ������� � ������� ��������� ��������� ����
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