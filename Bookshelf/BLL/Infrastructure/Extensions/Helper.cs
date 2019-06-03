using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BLL.Infrastructure.Extensions
{
    public static class HelperExtensions
    {
        public static IEnumerable<TSource> OrderByBubble<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, int> criterion)
        {
            TSource[] destSource = source.ToArray();
            int n = destSource.Count();
            for (int k = 0; k < n; k++)
            {
                for (int i = n - 2; i >= 0; i--)
                {
                    if (criterion(destSource[i], destSource[i + 1]) > 0)
                    {
                        TSource tmp = destSource[i];
                        destSource[i] = destSource[i + 1];
                        destSource[i + 1] = tmp;
                    }
                }
            }
            return destSource;
        }
        public static IEnumerable<TSource> OrderByBubble<TSource>(this IEnumerable<TSource> source, string param)
        {
            TSource[] destSource = source.ToArray();
            PropertyInfo propertyInfo = typeof(TSource).GetProperty(param);
            if (propertyInfo != null)
            {
                int n = source.Count();
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        IComparable iElem = (IComparable)propertyInfo.GetValue(destSource[i], null);
                        IComparable jElem = (IComparable)propertyInfo.GetValue(destSource[j], null);
                        if (iElem.CompareTo(jElem) > 0)
                        {
                            TSource tmp = destSource[i];
                            destSource[i] = destSource[j];
                            destSource[j] = tmp;
                        }
                    }
                }
                return destSource;
            }
            else
                throw new Exception("Invalid column name for sort");
        }

        public static IEnumerable<TSource> OrderByShell<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, int> criterion)
        {
            TSource[] destSource = source.ToArray();
            int n = destSource.Count();
            int j;
            for (int step = n / 2; step > 0; step /= 2)
            {
                for (int i = step; i < n; i++)
                {
                    TSource tmp = destSource[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (criterion(tmp, destSource[j - step]) > 0)
                            destSource[j] = destSource[j - step];
                        else
                            break;
                    }
                    destSource[j] = tmp;
                }
            }
            return destSource;
        }

        public static IEnumerable<TSource> OrderByShell<TSource>(this IEnumerable<TSource> source, string param)
        {
            TSource[] destSource = source.ToArray();
            PropertyInfo propertyInfo = typeof(TSource).GetProperty(param);
            if (propertyInfo != null)
            {
                int n = destSource.Count();
                int j;
                for (int step = n / 2; step > 0; step /= 2)
                {
                    for (int i = step; i < n; i++)
                    {
                        TSource tmp = destSource[i];
                        IComparable iElem = (IComparable)propertyInfo.GetValue(tmp, null);
                        for (j = i; j >= step; j -= step)
                        {
                            IComparable jElem = (IComparable)propertyInfo.GetValue(destSource[j - step], null);
                            if (jElem.CompareTo(iElem) > 0)
                                destSource[j] = destSource[j - step];
                            else
                                break;
                        }
                        destSource[j] = tmp;
                    }
                }
                return destSource;
            }
            else
                throw new Exception("Invalid column name for sort");
        }
    }
}
