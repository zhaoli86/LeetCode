using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeImportance
{
    public class Employee
    {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }
    public class Solution
    {

        public int GetImportance(IList<Employee> employees, int id)
        {
            var map = new Dictionary<int, Employee>();
            foreach (var employee in employees)
            {
                map[employee.id] = employee;
            }
            int result = 0;
            var q = new Queue<Employee>();
            q.Enqueue(map[id]);
            while (q.Any())
            {
                var node = q.Dequeue();
                result += node.importance;
                foreach (var item in node.subordinates)
                {
                    q.Enqueue(map[item]);
                }
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
