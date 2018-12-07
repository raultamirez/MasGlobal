using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Model.Model
{
    public class EmployeeContractMonthly: FactoryEmployee
    {
        private readonly decimal monthtlySalary;

        public EmployeeContractMonthly(decimal MonthtlySalary)
        {
            monthtlySalary = MonthtlySalary;
        }


        private string salary;

        public override string Salary
        {
            get { return salary = (monthtlySalary * 12).ToString(); }
        }



        private int id;

        public override int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string name;
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }



        private string contractTypeName;
        public override string ContractTypeName
        {
            get { return contractTypeName; }
            set { contractTypeName = value; }
        }

        private int roleId;
        public override int RoleId
        {
            get { return roleId; }
            set { roleId = value; }
        }

        private string roleName;

        public override string RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }
    }
}
