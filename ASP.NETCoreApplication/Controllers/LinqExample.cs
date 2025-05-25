namespace ASP.NETCoreApplication.Controllers
{
     public enum OrderStetus
    {
        processing = 1,
        Confirmed = 2,
        Dispatched=3,
        Shipped=4,
        Deliverd = 5

    }
    public class LinqExample
    {
       

        public void OrderNotification( OrderStetus status)
        {
            int EnumStatus = 3;
            OrderStetus st = (OrderStetus)EnumStatus;

            Console.WriteLine("Value =", st);
            switch(status)
            {
                
                case OrderStetus.processing: Console.WriteLine("Your Order Is Processing"); break;
                case OrderStetus.Confirmed: Console.WriteLine("Your order Is Confirmed "); break ;
                case OrderStetus.Dispatched:Console.WriteLine("Your order has been dispatched.");break;
                case OrderStetus.Shipped:Console.WriteLine("Your order has been shipped."); break;
                case OrderStetus.Deliverd:Console.WriteLine("Your order has been delivered."); break;
               
            }

        }
        public void FindLinq()
        {

            

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var evennumbers = from num in numbers where num % 2 == 0 select num;
            foreach (var number in evennumbers)
            {
                Console.WriteLine("Even Number:" + number);
            }

        }
        public void TackLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var tacknum = numbers.Take(2);


        }
        public void SkipLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var tacknum = numbers.Skip(2);

        }

        public void FirstLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var FirstNum = numbers.First(N => N > 1);


        }

        public void FirstOrDefaultLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var DefaultNum = numbers.FirstOrDefault(N => N > 1);

        }
        public void SingleLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var SingleNum = numbers.Single(n => n == 2);

        }

        public void SingleOrDefaultLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var SingleOrDefaultNum = numbers.SingleOrDefault(n => n == 2);
        }

        public void AnyLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var AnyNum = numbers.Any(N => N == 30);


        }

        public void AllLinqMethod()
        {
            List<int> numbers = new List<int> { 2, 4, };
            var number = numbers.ToList();

            var AnyNum = numbers.All(N => N % 2 == 0);


        }

        public void CountLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var CountNum = numbers.Count();
            if (CountNum > 0)
            {

            }


        }

        public void SumAverageLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var SumNum = numbers.Sum();
            var AvgNum = numbers.Average();

        }

        public void DistinctLinqMethod()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var number = numbers.ToList();

            var DistinctNum = numbers.Distinct();

        }

        public void UnionIntersectExceptLinqMethod()
        {
           var Set1 = new List<int> { 1, 2, 3, };
            var Set2 = new List<int> {  3,4,5};
            var UnionRes = Set1.Union(Set2);
            var IntersectRes = Set1.Intersect(Set2);
            var exceptRes = Set1.Except(Set2);

        }

        public void InnerLinqMethod()
        {
            var employeeList = new[]
            {
                new {EmpId = 1 , EmpName = "John",DeptId = 101},
                new {EmpId = 2 , EmpName = "Mark",DeptId = 102},
                new {EmpId = 3 , EmpName = "Yogesh",DeptId = 103},
                new {EmpId = 4 , EmpName = "Sakshi",DeptId = 104},
                new {EmpId = 5 , EmpName = "Prakash",DeptId = 105}
            };

            var deptList = new[]
            {
                new { DeptId = 101 , DeptName = "HR"},
                 new { DeptId = 102 , DeptName = "It"},
                  new { DeptId = 103 , DeptName = "Finance"},
                   new { DeptId = 104 , DeptName = "Admin"}
            };

            var innerjoinRes = from emp in employeeList
                               join dept in deptList
                               on emp.DeptId equals dept.DeptId
                               select new
                               {
                                   emp,
                                   dept
                               };

        }

        public void LeftLinqMethod()
        {
            var employeeList = new[]
            {
                new {EmpId = 1 , EmpName = "John",DeptId = 101},
                new {EmpId = 2 , EmpName = "Mark",DeptId = 102},
                new {EmpId = 3 , EmpName = "Yogesh",DeptId = 103},
                new {EmpId = 4 , EmpName = "Sakshi",DeptId = 104},
                new {EmpId = 5 , EmpName = "Prakash",DeptId = 105}
            };

            var deptList = new[]
            {
                new { DeptId = 101 , DeptName = "HR"},
                 new { DeptId = 102 , DeptName = "It"},
                  new { DeptId = 103 , DeptName = "Finance"},
                   new { DeptId = 104 , DeptName = "Admin"}
            };

            var leftResult = from e in employeeList // e range selector and left table
                             join d in deptList // joining conditions 
                             on e.DeptId equals d.DeptId into EmpDeptGroup // store the data in empdeptgroup 
                             from d in EmpDeptGroup.DefaultIfEmpty()
                             select new { e.EmpName, d.DeptName };




        }
        public void RightLinqMethod()
        {

            var employeeList = new[]
           {
                new {EmpId = 1 , EmpName = "John",DeptId = 101},
                new {EmpId = 2 , EmpName = "Mark",DeptId = 102},
                new {EmpId = 3 , EmpName = "Yogesh",DeptId = 102},
                new {EmpId = 4 , EmpName = "Sakshi",DeptId = 104},
                new {EmpId = 5 , EmpName = "Prakash",DeptId = 105}
            };

            var deptList = new[]
            {
                new { DeptId = 101 , DeptName = "HR"},
                 new { DeptId = 102 , DeptName = "It"},
                  new { DeptId = 103 , DeptName = "Finance"},
                   new { DeptId = 104 , DeptName = "Admin"}
            };
            var RightResult = from d in deptList
                              join e in employeeList
                                on d.DeptId equals e.DeptId into EmpDeptGroup // store the data in empdeptgroup 
                              from e in EmpDeptGroup.DefaultIfEmpty()
                              select new 
                              { 
                                 // e.EmpName, d.DeptName
                                 Department = d.DeptName ,
                                 Employee= e?.EmpName?? "No Employee"
                              };


            foreach (var number in RightResult)
            {
                Console.WriteLine("Even Number:" + number);
            }



        }

        public void InnerLinqMethodSyntacx()
        {

            var employeeList = new[]
           {
                new {EmpId = 1 , EmpName = "John",DeptId = 101},
                new {EmpId = 2 , EmpName = "Mark",DeptId = 102},
                new {EmpId = 3 , EmpName = "Yogesh",DeptId = 103},
                new {EmpId = 4 , EmpName = "Sakshi",DeptId = 104},
                new {EmpId = 5 , EmpName = "Prakash",DeptId = 105}
            };

            var deptList = new[]
            {
                new { DeptId = 101 , DeptName = "HR"},
                 new { DeptId = 102 , DeptName = "It"},
                  new { DeptId = 103 , DeptName = "Finance"},
                   new { DeptId = 104 , DeptName = "Admin"}
            };


            var result = employeeList.Join(
                deptList, emp => emp.DeptId,
                dept => dept.DeptId,
                (emp, dept) => new { emp, dept });
        }

        public void GethighestSalary()
        {
             var employeeList = new[]
              {
                new {EmpId = 1 ,  EmpName = "John",DeptId = 101},
                new {EmpId = 2 , EmpName = "Mark",DeptId = 102},
                new {EmpId = 3 , EmpName = "Yogesh",DeptId = 103},
                new {EmpId = 4 , EmpName = "Sakshi",DeptId = 104},
                new {EmpId = 5 , EmpName = "Prakash",DeptId = 105}
            };
        }

        public void GetNThHigherSalary(int n) 
        {
            var employeeList = new[]
            {
                new {EmpId = 1 , Salary = 30000, EmpName = "John",DeptId = 101},
                new {EmpId = 2 , Salary = 40000, EmpName = "Mark",DeptId = 102},
                new {EmpId = 3 , Salary = 40000, EmpName = "Yogesh",DeptId = 103},
                new {EmpId = 4 , Salary = 34000, EmpName = "Sakshi",DeptId = 104},
                new {EmpId = 5 , Salary = 12000,EmpName = "Prakash",DeptId = 105}
            };

            var nthHighestSalary = employeeList. Select(s => s.Salary)
                .Distinct().OrderByDescending(s=> s).Skip(n-1).FirstOrDefault();
           
        }
    }
}