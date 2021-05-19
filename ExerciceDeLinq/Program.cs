using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LINQDataContext;

namespace ExerciceDeLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dc = new DataContext();
            #region Exo1
            int IdOfWillis = dc.Students.ExecuteScalar<Student, int>(s => s.Last_Name == "Willis", s => s.Student_ID);
            Console.WriteLine(IdOfWillis);
            #endregion
            #region Exo2
            //2.1
            /*var students = dc.Students.Select(s => new { s.Last_Name, s.BirthDate, s.Login, s.Year_Result });
            foreach(var s in students)
            {
                Console.WriteLine($"{s.Last_Name} {s.BirthDate} {s.Login} {s.Year_Result}");
            }
            */
            //2.2
            /*var students = dc.Students.Select(s => new { FullName = s.Last_Name + " " + s.First_Name, s.Student_ID, s.BirthDate });
            foreach (var s in students)
            {
                Console.WriteLine($"{s.FullName} {s.Student_ID} {s.BirthDate}");
            }*/

            //2.3
            /*IEnumerable<string> students = dc.Students.Select(s => $"{s.Student_ID}|{s.First_Name}|{s.Last_Name}|{s.Login}|{s.Section_ID}|{s.BirthDate}|{s.Section_ID}|{s.Year_Result}");
            foreach (string s in students)
            {
                Console.WriteLine(s);
            }*/
            #endregion
            #region Exo3
            //3.1
            //var students = dc.Students.Where(s => s.BirthDate.Year < 1955).Select(s => new { s.Last_Name, s.Year_Result, status = s.Year_Result < 12 ? "KO" : "OK" });
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Last_Name} {s.Year_Result} {s.status}");
            //}

            //3.2
            //var students = dc.Students.Where(s => s.BirthDate.Year >= 1955 && s.BirthDate.Year <= 1965).Select(s => new { s.Last_Name, s.Year_Result, category = s.Year_Result < 10 ? "inférieur" : s.Year_Result == 10 ? "neutre" : "supérieur" });
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Last_Name} {s.Year_Result} {s.category}");
            //}

            //3.3
            //var students = dc.Students.Where(s => s.Last_Name.EndsWith("r")).Select(s => new { s.Last_Name, s.Section_ID });
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Last_Name} {s.Section_ID}");
            //}

            //3.4
            //var students = dc.Students.Where(s => s.Year_Result <= 3).Select(s => new { s.Last_Name, s.Year_Result }).OrderByDescending(s => s.Year_Result);
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Last_Name} {s.Year_Result}");
            //}

            //3.5
            //var students = dc.Students.Where(s => s.Section_ID == 1110).Select(s => new { FullName = s.Last_Name + " " + s.First_Name, s.Year_Result }).OrderBy(s => s.FullName);
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.FullName} {s.Year_Result}");
            //}

            //3.6
            //var students = dc.Students.Where(s => s.Section_ID == 1010 || s.Section_ID == 1020).Where(s => s.Year_Result > 18 || s.Year_Result < 12).Select(s => new { s.Last_Name, s.Section_ID, s.Year_Result }).OrderBy(s=>s.Section_ID);
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Last_Name} {s.Section_ID} {s.Year_Result}");
            //}

            //3.7
            //var students = dc.Students.Select(s => new { s.Last_Name, s.Section_ID, result_100 = s.Year_Result * 5 }).Where(s => s.Section_ID.ToString().StartsWith("13") && s.result_100 <= 60).OrderByDescending(s => s.result_100);
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Last_Name} {s.Section_ID} {s.result_100}");
            //}
            #endregion
            #region Exo4
            //4.1
            Console.WriteLine(dc.Students.Average(s=>s.Year_Result));

            //4.2
            //Console.WriteLine(dc.Students.Max(s=>s.Year_Result));

            //4.3
            //Console.WriteLine(dc.Students.Sum(s=>s.Year_Result));

            //4.4
            //Console.WriteLine(dc.Students.Min(s=>s.Year_Result));

            //4.5
            //Console.WriteLine(dc.Students.Count(s => s.Year_Result % 2 != 0));

            #endregion
            #region Exo5
            //5.1
            //var students = dc.Students.GroupBy(s => s.Section_ID).Select(gs => new { section = gs.Key, max = gs.Max(s => s.Year_Result) });
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.section} {s.max}");
            //}

            //5.2
            //var students = dc.Students.Where(s => s.Section_ID.ToString().StartsWith("10")).GroupBy(s => s.Section_ID).Select(gs => new { gs.Key, avg = gs.Average(s => s.Year_Result) });
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Key} {s.avg}");
            //}

            //5.3
            //var students = dc.Students.Where(s => s.BirthDate.Year >= 1970 && s.BirthDate.Year <= 1985).GroupBy(s => s.BirthDate.Month).Select(gs => new { BirthMonth = gs.Key, AVGResult = gs.Average(s => s.Year_Result) });
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.BirthMonth} {s.AVGResult}");
            //}

            //5.4
            //var students = dc.Students.GroupBy(s => s.Section_ID).Where(gs => gs.Count() > 3).Select(gs => new { gs.Key, AVGResult = gs.Average(s => s.Year_Result) });
            //foreach (var s in students)
            //{
            //    Console.WriteLine($"{s.Key} {s.AVGResult}");
            //}

            //5.5
            /*var profs = dc.Courses.Join(dc.Professors, c => c.Professor_ID, p => p.Professor_ID, (c, p) => new { c.Course_Name, p.Professor_Name, p.Section_ID }).Join(dc.Sections, cp => cp.Section_ID, s => s.Section_ID, (cp, s) => new { cp.Course_Name, cp.Professor_Name, s.Section_Name });
            foreach (var cps in profs)
            {
                Console.WriteLine($"{cps.Course_Name} {cps.Section_Name} {cps.Professor_Name}");
            }*/

            //5.6
            //var sections = dc.Sections.Join(dc.Students, sec => sec.Delegate_ID, stu => stu.Student_ID, (sec, stu) => new { sec.Section_ID, sec.Section_Name, stu.Last_Name }).OrderByDescending(s => s.Section_ID);
            //foreach (var s in sections)
            //{
            //    Console.WriteLine($"{s.Section_ID} {s.Section_Name} {s.Last_Name}");
            //}

            //5.7
            //var sections = dc.Sections.GroupJoin(dc.Professors, s => s.Section_ID, p => p.Section_ID, (s, ps) => new { s.Section_ID, s.Section_Name, profs = ps.Select(p => p.Professor_Name) });
            //foreach (var s in sections)
            //{
            //    Console.WriteLine($"{s.Section_ID} {s.Section_Name} :");
            //    if (s.profs.Count() > 0)
            //    {
            //        foreach (string p in s.profs)
            //        {
            //            Console.WriteLine($"\t{p}");
            //        }
            //    }
            //    else {
            //        Console.WriteLine("\tAucun");
            //    }
            //}

            //5.8
            //var sections = dc.Sections.GroupJoin(dc.Professors, s => s.Section_ID, p => p.Section_ID, (s, ps) => new { s.Section_ID, s.Section_Name, profs = ps.Select(p => p.Professor_Name) }).Where(s=>s.profs.Count()>0);
            //foreach (var s in sections)
            //{
            //    Console.WriteLine($"{s.Section_ID} {s.Section_Name} :");
            //    foreach (string p in s.profs)
            //    {
            //        Console.WriteLine($"\t{p}");
            //    }
            //}

            //5.9

            #endregion
            #region Console.ReadLine()
            Console.ReadLine();
            #endregion
        }        
    }

    #region Exo1 Method
    public static class Extensions
    {
        public static TResult ExecuteScalar<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource,bool> condition, Func<TSource, TResult> action)
        {
            TResult result = default;
            foreach (TSource item in source)
            {
                if (condition(item)) result = action(item);
            }
            return result;
        }
    }
    #endregion
    
}
