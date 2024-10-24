using System.Collections.Generic;

namespace yield {
    public static class ExpSmoothingTask {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha) {
            double prevSmoothedY = 0.0; // ��������� �������� ���������� �����
            bool isFirst = true; // ���� �����������, ��� ������� ������� ������

            foreach (var dataPoint in data) {
                double smoothedY;
                if (isFirst) { // ��������� ���������� �������� ��� ������ �����
                    smoothedY = dataPoint.OriginalY;
                    isFirst = false;
                } else { // ��������� ���������� �������� ��� ��������� ����� ��������� ������� �� ���������
                    smoothedY = alpha * dataPoint.OriginalY + (1 - alpha) * prevSmoothedY;
                }

                prevSmoothedY = smoothedY; // ��������� ��������� �������� ���������� �����
                var smoothedDataPoint = dataPoint.WithExpSmoothedY(smoothedY); // ������� ����� ������
                yield return smoothedDataPoint; // ���������� ������� ���������� �����
            }
        }
    }
}