using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            # region [Список]
            // оголошення списку із початковою ініціалізацією
            var list = new List<int>() { 8, 7 }; // [8,7]

            // додавання елемента в кінець списку
            list.Add(5); // [8,7,5]
            list.Add(7); // [8,7,5,7]
  
            // зчитування значень за індексом
            var firstValue = list[0]; //8

            // визначення кількості елеметів
            var count = list.Count; // 4

            // способи перебору елементів у списку
            // 1. 
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
            // 2.
            for (var i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]); // O(1)
            }
            // 3.
            list.ForEach(item => { Console.WriteLine(item); });

            // додавання набоору значень в кінець списку
            var list2 = new List<int>() { 1, 1 };
            var array = new int[] { 0, 0 };
            list.AddRange(list2);
            list.AddRange(array);

            // конвертування/маппінг даних списку
            var convertedList = list.ConvertAll(new Converter<int, string>(IntToString));
            convertedList.ForEach(item => { Console.WriteLine(item); });
            #endregion

            #region[Словник]
            // оголошення словника
            var dictionary = new Dictionary<string, int>();

            // додавання пар <ключ,значення> у словник
            dictionary.Add("a", 2);
            dictionary.Add("b", 2);
            dictionary.Add("c", -1);
            // {"a": 2, "b": 2, "c": -1}

            // додавання пари у словник із попередньою перевіркою на існування ключа
            if (!dictionary.ContainsKey("a"))
            {
                dictionary.Add("a", 2);
            }
            else
            {
                dictionary["a"] = 8;
            }

            // перебір пар <ключ,значення> у словнику
            foreach (KeyValuePair<string, int> pair in dictionary)
            {
                Console.WriteLine("{0}:{1}", pair.Key, pair.Value);
            }

            // зчитування значення за ключем
            var valueA = dictionary["a"];

            // Задача: підрахувати кількість входжень кожного значення у словнику
            var list3 = new List<int>() { 8, 7, 1, 0, 6, 1, 1, 8 };        
            var counter = new Dictionary<int, int>();
            foreach(var value in list3)
            {
                if(!counter.ContainsKey(value))
                {
                    counter.Add(value, 1);
                }
                else
                {
                    counter[value]++;
                }
            }
            // Результат:
            // 8:2
            // 7:1
            // 1:3
            // 0:1
            // 6:1
            #endregion

            #region [Множина]
            // створення множини унікальних значень на основі списку
            // 1-ий спосіб
            var set = new HashSet<int>(list);
            // 2-ий спосіб
            foreach(var value in list)
            {
                set.Add(value);
            }

            // приклад операції обєднання двох множин
            var set2 = new HashSet<int>(list3);
            set.UnionWith(set2);
            foreach (var uniqValue in set)
            {
                Console.WriteLine(uniqValue);
            }
            #endregion

            #region[Стек]
            // оголошення стеку
            var stack = new Stack<int>(); // stack -> []

            // додавання елементів
            stack.Push(3); // stack -> [3]
            stack.Push(-1); // stack -> [3,-1]
            stack.Push(2); // stack -> [3,-1,2]

            // зчитування елементів із видаленням
            var lastStackValue = stack.Pop(); // lastStackValue = 2, stack -> [3,-1]

            // зчитування елементів без видалення
            var checkLastStackValue = stack.Peek(); // checkLastStackValue = 2, stack -> [3,-1, 2]

            // обробка елементів стеку
            while (stack.Count > 0)
            {
                var value = stack.Pop();
                // handle value ...
            }
            #endregion

            #region[Черга]
            // оголошення черги
            var queue = new Queue<int>(); // queue -> []

            // додавання елементів у чергу
            queue.Enqueue(2); // queue -> [2]
            queue.Enqueue(1); // queue -> [2, 1]
            queue.Enqueue(-8); // queue -> [2, 1,-8]

            // зчитування елементів із видаленням
            var firstQueueValue = queue.Dequeue(); // firstQueueValue = 2 queue ->  [1,-8]

            // зчитування елементів без видалення
            var checkFirstQueueValue = queue.Peek(); // checkFirstQueueValue = 2 queue ->  [2,1,-8]

            // обробка елементів черги
            while (queue.Count > 0)
            {
                var value = queue.Dequeue();
                // handle value ...
            }
            #endregion

            Console.ReadKey();
        }

        public static string IntToString(int value)
        {
            return "value - " + value;
        }

        public static bool checkIt(int value)
        {
            return value == 8;
        }
    }
}
