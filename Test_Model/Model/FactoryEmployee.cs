using System;
using System.Collections.Generic;
using System.Text;

namespace Test_Model.Model
{
    public abstract class FactoryEmployee
    {
       public abstract int Id { get; set; }
       public abstract string Name { get; set; }
       public abstract string ContractTypeName { get; set; }
       public abstract int RoleId { get; set; }
       public abstract string RoleName { get; set; }
       public abstract string Salary { get; }
      
    }
}
