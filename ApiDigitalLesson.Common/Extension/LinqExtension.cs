using System.Linq.Expressions;

namespace ApiDigitalLesson.Common.Extension
{
    public static class LinqExtension
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, bool condition, Expression<Func<T, int, bool>> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, int, bool> predicate)
        {
            return condition ? source.Where(predicate) : source;
        }
        
        public static IEnumerable<T> TraverseTree<T>(this T parentNode, Func<T, IEnumerable<T>> childNodesSelector)
        {
            yield return parentNode;

            IEnumerable<T> childNodes = childNodesSelector(parentNode);
            if (childNodes != null)
            {
                foreach (T childNode in
                         childNodes.SelectMany(x => x.TraverseTree(childNodesSelector)))
                {
                    yield return childNode;
                }
            }
        }
    }
}