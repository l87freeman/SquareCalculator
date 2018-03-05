using System;
using System.Collections.Generic;
using System.Linq;
using Services.Models;

namespace Services.Extentions
{
    internal static class IEnumerablePointExctentions
    {
        public static List<PointDto> SortByDistance(this List<PointDto> pointToSort)
        {
            List<PointDto> sortedList = new List<PointDto>();
            var tempPoint = GetStartingPoint(pointToSort);
            AddAndRemove(sortedList, pointToSort, tempPoint);
            
            for (int i = 0, j = 0; i < pointToSort.Count + j; i++, j++)
            {
                var tempIndex = ClosestPointIndex(pointToSort, tempPoint);
                tempPoint = pointToSort[tempIndex];
                AddAndRemove(sortedList, pointToSort, tempPoint);
            }
            return sortedList;
        }

        private static void AddAndRemove(List<PointDto> to, List<PointDto> from, PointDto point)
        {
            to.Add(point);
            from.Remove(point);
        }

        private static PointDto GetStartingPoint(List<PointDto> list)
        {
            PointDto minPoint = null;
            foreach (var item in list)
            {
                if (minPoint == null)
                {
                    minPoint = item;
                    continue;
                }

                if (minPoint.X > item.X/* && minPoint.Y > item.Y*/)
                    minPoint = item;
            }
            return minPoint;
        }

        private static int ClosestPointIndex(List<PointDto> points, PointDto startPoint)
        {

            int indxClosestPoint = 0;
            double distance = 0d;
            for (int i = 0; i < points.Count; i++)
            {
                var tempPoint = points[i];
                double distanceTemp = Math.Sqrt(Math.Pow(startPoint.X - tempPoint.X, 2) + Math.Pow(startPoint.Y - tempPoint.Y, 2));
                if (i == 0)
                {
                    indxClosestPoint = i;
                    distance = distanceTemp;
                }
                else
                {
                    if (distanceTemp < distance)
                    {
                        indxClosestPoint = i;
                        distance = distanceTemp;
                    }
                }
            }
            return indxClosestPoint;
        }
    }
}
