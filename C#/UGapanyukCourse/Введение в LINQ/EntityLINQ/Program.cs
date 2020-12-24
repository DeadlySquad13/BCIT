using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace EntityLINQ
{
    class Program
    {
        /// <summary>
        /// Очистка данных
        /// </summary>
        static void ClearData()
        {
            LearningModelContainer db = new LearningModelContainer();
            
            //Удаление данных для связи много-ко-многим
            //для каждой записи StudentGroup удаляются все связи с Subject
            foreach (var gr in db.StudentGroupSet.ToList())
            {
                foreach (var gr_subj in gr.Subject.ToList())
                {
                    gr.Subject.Remove(gr_subj);
                }
            }
            db.SaveChanges();

            db.StudentGroupSet.ToList().ForEach(db.StudentGroupSet.DeleteObject);
            db.SaveChanges();

            db.SubjectSet.ToList().ForEach(db.SubjectSet.DeleteObject);
            db.SaveChanges();

            db.SubjectTypeSet.ToList().ForEach(db.SubjectTypeSet.DeleteObject);
            db.SaveChanges();
        }

        /// <summary>
        /// Заполнение данных
        /// </summary>
        static void InitData()
        {
            LearningModelContainer db = new LearningModelContainer();

            //Добавление типов предметов

            SubjectType st_tech = new SubjectType
            {
                TypeName = "технический цикл",
                ParentSubjectType = null
            };
            db.SubjectTypeSet.AddObject(st_tech);

            SubjectType st_hum = new SubjectType
            {
                TypeName = "гуманитарный цикл",
                ParentSubjectType = null
            };

            SubjectType st1 = new SubjectType
            {
                TypeName = "базовые", 
                ParentSubjectType = st_tech
            };

            SubjectType st2 = new SubjectType
            {
                TypeName = "специальные",
                ParentSubjectType = st_tech
            };

            SubjectType st3 = new SubjectType
            {
                TypeName = "исторические",
                ParentSubjectType = st_hum
            };

            SubjectType st3_1 = new SubjectType
            {
                TypeName = "новая история",
                ParentSubjectType = st3
            };

            SubjectType st3_2 = new SubjectType
            {
                TypeName = "новейшая история",
                ParentSubjectType = st3
            };

            db.SubjectTypeSet.AddObject(st_tech);
            db.SubjectTypeSet.AddObject(st_hum);
            db.SubjectTypeSet.AddObject(st1);
            db.SubjectTypeSet.AddObject(st2);
            db.SubjectTypeSet.AddObject(st3);
            db.SubjectTypeSet.AddObject(st3_1);
            db.SubjectTypeSet.AddObject(st3_2);

            //Добавление предметов

            Subject sb1 = new Subject
            {
                 SubjectName = "математика",
                 Value = 100, //часов
                 SubjectType = st1
            };

            Subject sb2 = new Subject
            {
                SubjectName = "физика",
                Value = 80, //часов
                SubjectType = st1
            };

            Subject sb3 = new Subject
            {
                SubjectName = "информатика",
                Value = 120, //часов
                SubjectType = st2
            };

            Subject sb4 = new Subject
            {
                SubjectName = "базы данных",
                Value = 150, //часов
                SubjectType = st2
            };

            Subject sb5 = new Subject
            {
                SubjectName = "сетевые технологии",
                Value = 170, //часов
                SubjectType = st2
            };

            db.SubjectSet.AddObject(sb1);
            db.SubjectSet.AddObject(sb2);
            db.SubjectSet.AddObject(sb3);
            db.SubjectSet.AddObject(sb4);
            db.SubjectSet.AddObject(sb5);

            //Добавление групп

            StudentGroup g1 = new StudentGroup
            {
                GroupName = "ИУ5-11"
            };

            StudentGroup g2 = new StudentGroup
            {
                GroupName = "ИУ5-51"
            };

            StudentGroupSpecial g3 = new StudentGroupSpecial
            {
                GroupName = "ИУ5c-11",
                Flag = true
            };

            db.StudentGroupSet.AddObject(g1);
            db.StudentGroupSet.AddObject(g2);
            db.StudentGroupSet.AddObject(g3);

            //Установка связи много-ко многим

            g1.Subject.Add(sb1);
            g1.Subject.Add(sb2);

            g2.Subject.Add(sb3);
            g2.Subject.Add(sb4);
            g2.Subject.Add(sb5);

            g3.Subject.Add(sb1);
            g3.Subject.Add(sb2);
            g3.Subject.Add(sb4);

            //Сохранение данных в БД
            db.SaveChanges();

        }

        /// <summary>
        /// Примеры запросов
        /// </summary>
        static void Queries()
        {
            //Выдача иерархии типов пердметов
            WriteSubjectTypeTree(-1, 0);
            Console.WriteLine();

            LearningModelContainer db = new LearningModelContainer();

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("Получение всех курсов и групп, которым они читаются");
            var q1 = from s in db.SubjectSet select s;

            foreach (var s in q1)
            {
                Console.WriteLine(s.SubjectName + " (" + s.SubjectType.TypeName + ")");
                foreach (var g in s.StudentGroup)
                {
                    Console.WriteLine("   " + g.GroupName);
                }
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nКоличество часов по всем предметам для каждой группы");
            var q2 = from g in db.StudentGroupSet
                     select new { GroupName = g.GroupName, ValueSum = g.Subject.Sum(x => x.Value), Subject = g.Subject };

            foreach (var g in q2)
            {
                Console.WriteLine(g.GroupName + " (" + g.ValueSum.ToString() + " часов)");
                foreach (var s in g.Subject)
                {
                    Console.WriteLine("   " + s.SubjectName + " (" + s.Value.ToString() + " часов)");
                }
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nПредметы, читаемые группам");
            var q3 = from g in db.StudentGroupSet
                     from s in g.Subject
                     select new { SubjectName = s.SubjectName, Value = s.Value, GroupName = g.GroupName };

            var q31 = from t in q3
                      orderby t.SubjectName, t.GroupName
                      select t;

            foreach (var g in q31)
            {
                Console.WriteLine(g);
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nКоличество часов по предмету для всех групп");
            var q32 = from t in q3
                      group t by t.SubjectName into temp
                      select new { GroupName = temp.Key, SumValue = temp.Sum(x=>x.Value) };

            foreach (var g in q32)
            {
                Console.WriteLine(g);
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nГруппы для которых читаются специальные курсы (с использованием contains)");

            string[] arr = new string[] { "специальные", "другой" };
            
            var qc = from g in db.StudentGroupSet
                     from s in g.Subject
                     where arr.Contains(s.SubjectType.TypeName)
                     select new { GroupName = g.GroupName, SubjectTypeName = s.SubjectType.TypeName };

            foreach (var g in qc)
            {
                Console.WriteLine(g);
            }


            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nТипы курсов, читаемых для группы (с повторяющимися записями)");
            var q4 = from g in db.StudentGroupSet
                     from s in g.Subject
                     select new { GroupName = g.GroupName, SubjectTypeName = s.SubjectType.TypeName };

            foreach (var g in q4)
            {
                Console.WriteLine(g);
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nТипы курсов, читаемых для группы");
            var q41 = from t in q4.Distinct() 
                      select t;                       

            foreach (var g in q41)
            {
                Console.WriteLine(g);
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nГруппы, которым читаются базовые курсы");
            var q42 = from t in q4.Distinct()
                      where t.SubjectTypeName == "базовые"
                      select t;

            foreach (var g in q42)
            {
                Console.WriteLine(g);
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nГруппы, которым читаются базовые курсы (использование any)");
            var q43 = from t in q4.Distinct()
                      group t by t.GroupName into temp
                      where temp.Any(
                        (data) => data.SubjectTypeName == "базовые"
                      )
                      select temp.Key;

            foreach (var g in q43)
            {
                Console.WriteLine(g);
            }

            //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Console.WriteLine("\nГруппы, которым читаются только базовые курсы (использование all)");
            var q44 = from t in q4.Distinct()
                      group t by t.GroupName into temp
                      where temp.All(
                        (data) => data.SubjectTypeName == "базовые"
                      )
                      select temp.Key;

            foreach (var g in q44)
            {
                Console.WriteLine(g);
            }


            Console.WriteLine("\nПолучение сгенерированного SQL");
            var trace = ((ObjectQuery)q44).ToTraceString();
            Console.WriteLine(trace);

        }

        /// <summary>
        /// Кэширование данных с использованием Include
        /// </summary>
        public static void IncludeExample()
        {

            LearningModelContainer db = new LearningModelContainer();

            //Отключение загрузки связанных данных
            db.ContextOptions.LazyLoadingEnabled = false;

            Console.WriteLine("\nБез использования Include");
            var q51 = (from x in db.SubjectSet
                     select x).ToList();

            WriteSubjectList(q51);

            Console.WriteLine("\nС использованием Include");
            var q52 = (from x in db.SubjectSet.Include("SubjectType").Include("StudentGroup")
                       select x).ToList();

            WriteSubjectList(q52);

        }

        /// <summary>
        /// Вывод списка 
        /// </summary>
        /// <param name="list"></param>
        public static void WriteSubjectList(List<Subject> list)
        {
            foreach (var x in list)
            {
                string TypeName = "";
                if (x.SubjectType != null) TypeName = x.SubjectType.TypeName;
                else TypeName = "null";

                Console.WriteLine(x.SubjectName + " (" + TypeName + ")");

                if (x.StudentGroup != null)
                {
                    foreach (var y in x.StudentGroup)
                    {
                        Console.WriteLine("   " + y.GroupName);
                    }
                }
            }

        }

        public static void WriteSubjectTypeTree(int ParentSubjectTypeParam, int LevelParam)
        {
            LearningModelContainer db = new LearningModelContainer();
            var q = from x in db.SubjectTypeSet select x;

            if (ParentSubjectTypeParam == -1)
            {
                //Поиск корневых элементов (ParentSubjectType == null)
                q = q.Where(x => x.SubjectTypeId.HasValue == false);
            }
            else
            {
                //Поиск элементов с заданным элементом верхнего уровня
                q = q.Where(x => x.SubjectTypeId.Value == ParentSubjectTypeParam);
            }

            //Если существуют элементы на данном уровне иерархии
            if (q.Count() > 0)
            {
                //Сортировка
                q = q.OrderBy(x => x.TypeName);

                //Перебор всех значений на заданном уровне иерархии
                foreach (var x in q)
                {
                    //Вывод отступа
                    if (LevelParam > 0)
                    {
                        for (int i = 0; i < LevelParam; i++) Console.Write("  ");
                    }
                    //Вывод значения
                    Console.WriteLine(x.TypeName);

                    //Рекурсивный вызов функции для всех элементов, вложенных в текущий
                    WriteSubjectTypeTree(x.Id, LevelParam + 1);
                }
            }
        }

        static void Main(string[] args)
        {
            /*
            //Заполнение данных в случае пустой БД
            LearningModelContainer db = new LearningModelContainer();
            if (db.SubjectTypeSet.Count() == 0)
            {
                //Инициализация данных для запросов
                InitData();
            }
            */

            ClearData();
            InitData();
            Queries();
            IncludeExample();

            Console.ReadLine();
        }
    }
}
