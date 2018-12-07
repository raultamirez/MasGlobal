import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent implements OnInit {

  rows: any;
  employee: any = {};

  columns = [
    { title: 'id' },
    { title: 'Name', key: 'name', isSortable: true },
    { title: 'Contract Type Name', key: 'contractTypeName', isSortable: true },
    { title: 'Role Name', key: 'roleName', isSortable: true },
    { title: 'Role Description', key: 'roleDescription', isSortable: true },
    { title: 'Salary', key: 'salary', isSortable: true }
  ];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {

 
  }


  search() {
    if (this.employee.id) {
      this.employeeService.getEmployee(this.employee.id).subscribe(res => {
        this.rows = res;
        console.log('Employee', this.rows
        );
      });
    }
    else {
      this.employeeService.getEmployees().subscribe(res => {
        this.rows = res;
        console.log('Employee list', this.rows
        );
      });
    }
   
  }
}
