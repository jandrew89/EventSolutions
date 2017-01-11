using Assignment.Repository.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSolutions.Services.Extensions
{
    public static class Extensions
    {
        public static IEnumerable<TSource> DistintBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static IEnumerable<SelectListItem> SelectEmployeesItems(this IEnumerable<Employee> employees, int selectId) =>
            employees.OrderBy(e => e.FullName)
                .Select(e => new SelectListItem
                {
                    Selected = (e.Id == selectId),
                    Text = e.FullName,
                    Value = e.Id.ToString()
                });
    }


}
