namespace Employee1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee employee1 = new Employee();
            Employee employee2 = new Employee(name: "AAA");
            Employee employee3 = new Employee(name: "BBB", basic: 25000, deptNo: 5);
            Employee o1 = new Employee("Amol", 123465, 10);
            Employee o2 = new Employee("Amol", 123465);
            Employee o3 = new Employee("Amol");
            Employee o4 = new Employee();

            Console.WriteLine("Employee 1 details: " + employee1.ToString());
            Console.WriteLine("Employee 2 details: " + employee2.ToString());
            Console.WriteLine("Employee 3 details: " + employee3.ToString());
        }
    }


    /*Properties
    ----------
    string Name -> no blank names should be allowed
    int EmpNo -> must be greater than 0
    decimal Basic -> must be between some range
    short DeptNo -> must be > 0
     */
    public class Employee {
        private string name;
        public String Name { 
            get { return name; }
            set {
                if (String.IsNullOrEmpty(value))
                    Console.WriteLine("Invalid name");
                else
                    name = value;
            }
        }

        private int empNo;
        public int EmpNo { 
            get { return empNo; }
            private set {
                if (value < 0)
                    Console.WriteLine("Invalid empNo");
                else
                    empNo = value;
            }
        }
        
        private decimal basic;
        public decimal Basic {
            get { return basic; }
            set
            {
                if (value < 10000 || value > 100000)
                    Console.WriteLine("Invalid Basic Salary");
                else
                    basic = value;
            }
        }

        private short deptNo;
        public short DeptNo {
            get { return deptNo; }
            set
            {
                if (value < 0)
                    Console.WriteLine("Invalid Dept Number");
                else
                    deptNo = value;
            }
        }

        private static int empCount = 0;

        public Employee(string name = "Emp1", decimal basic = 10000 ,short deptNo = 20)
        {
            this.EmpNo = ++empCount;
            this.DeptNo = deptNo; 
            this.Basic = basic; 
            this.Name = name;
        }

        public decimal GetNetSalary()
        {
            return this.Basic * (decimal)1.18;
            //return Decimal.Multiply(this.Basic,Convert.ToDecimal(1.18));
        }

        public override string ToString()
        {
            return "Employee name: " + this.Name + " Employee ID: " + this.EmpNo + " Employee Dept: " + this.DeptNo + " Employee Salary: " + this.GetNetSalary();
        }
    }
}