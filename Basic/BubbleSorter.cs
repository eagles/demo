using System;

namespace Example.ProCSharp.Delegates
{
    // Declare delegate
    delegate bool CompareOp(object lhs, object rhs);

    class BubbleSorter
    {
        static public void Sort(object[] sortArray, CompareOp gtMethod)
        {
            for (int i = 0; i < sortArray.Length; i++)
            {
                for (int j = i + 1; j < sortArray.Length; j++)
                {
                    if (gtMethod(sortArray[j], sortArray[i]))
                    {
                        object temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
                }
            }
        }
    }

    class Employee
    {
        private string name;
        private decimal salary;
    
        public Employee(string name, decimal salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public override string ToString()
        {
            return string.Format(name + ", {0:C}", salary);
        }

        public static bool RhsIsGreater(object lhs, object rhs)
        {
            Employee empLhs = (Employee) lhs;
            Employee empRhs = (Employee) rhs;

            return (empRhs.salary > empLhs.salary);
        }
    }

    class MainEntryPoint
    {
        static void Main()
        {
            Employee[] employees = {
                new Employee("Bugs Bunny", 2000),
                new Employee("Elmer Fudd", 3000),
                new Employee("Eason Wu", 1000),
                new Employee("Jim Paul", 4000),
                new Employee("Gary Deng", 5000),
                new Employee("RoadRunner", 50000),
                new Employee("Foghorn Leghorn", 23000)
            };

            CompareOp employeeCompareOp = new CompareOp(Employee.RhsIsGreater);
            BubbleSorter.Sort(employees, employeeCompareOp);
            
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i].ToString());
            }
    
            Console.ReadKey();
        }
    }
}

