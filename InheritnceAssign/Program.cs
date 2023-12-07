using System.Security.Cryptography.X509Certificates;

namespace InheritnceAssign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Manager manager = new Manager(name: "Manager1", basic: 50000, deptNo: 4, designation: "Engineering");
            Console.WriteLine("Manager details: " + manager);

            GeneralManager gm = new GeneralManager(name: "GManager1", basic: 50000, deptNo: 4, designation: "Engineering", perks: "10 Extra Holidays");
            Console.WriteLine("GM details: " + gm);

        }
    }

    public interface IDbFunctions {
        void Select();
        void Update();
        void Delete();

    }

    public abstract class Employee
    {
        private string? name;
        public string? Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    Console.WriteLine("Invalid name");
                else
                    name = value;
            }
        }

        private int empNo;
        public int EmpNo
        {
            get { return empNo; }
            private set
            {
                if (value < 0)
                    Console.WriteLine("Invalid empNo");
                else
                    empNo = value;
            }
        }

        private decimal basic;
        public abstract decimal Basic
        {
            get;
            set;
        }

        private short deptNo;
        public short DeptNo
        {
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

        public Employee(string name = "Emp1"/*, decimal basic = 10000*/, short deptNo = 20)
        {
            this.EmpNo = ++empCount;
            this.DeptNo = deptNo;
            //this.Basic = basic;
            this.Name = name;
        }

        public abstract decimal GetNetSalary();

        public override string ToString()
        {
            return "Employee name: " + this.Name + " Employee ID: " + this.EmpNo + " Employee Dept: " + this.DeptNo + " Employee Salary: " + this.GetNetSalary();
        }
    }

    public class Manager : Employee, IDbFunctions
    {
        private decimal basic;
        public override decimal Basic
        {
            get { return this.basic; }
            set
            {
                if (value < 0)
                    Console.WriteLine("");
                else
                    basic = value;
            }
        }
        public override decimal GetNetSalary()
        {
            return Basic * (decimal)1.50;
        }

        public void Select()
        {
            Console.WriteLine("In Select method for Manager"); 
        }

        public void Update()
        {
            Console.WriteLine("In Update method for Manager");
        }

        public void Delete()
        {
            Console.WriteLine("In Delete method for Manager");
        }

        private string designation;
        public string Designation { 
            get { return this.designation; }
            set {
                if (!string.IsNullOrWhiteSpace(value))
                    this.designation = value;
                else
                    Console.WriteLine("Incorrect designation!!!");
            }
        }
        public Manager(string name = "Emp1", decimal basic = 30000, short deptNo = 20, string designation = "Manager") : base(name, deptNo) {
            this.Basic = basic;
            this.Designation = designation;
        }

        public override string ToString()
        {
            return base.ToString() + "designation: " + this.Designation;
        }
    }

    public class GeneralManager : Manager  
    {
        private string? perks;
        public string? Perks {
            get { return this.perks; }
            set
            {
                this.perks = value;
            }
        }

        public override decimal GetNetSalary()
        {
            return this.Basic * (decimal)1.75;
        }

        public GeneralManager(string name = "Emp1", decimal basic = 30000, short deptNo = 20, string designation = "GeneralManager", string perks = "NoPerks") : base(name, basic, deptNo, designation){ 
            this.Perks = perks;
        }

        public override string ToString()
        {
            return base.ToString() + "perks: " + this.Perks;
        }
    }
}