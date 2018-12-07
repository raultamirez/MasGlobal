import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class EmployeeService {

  constructor(private httpClient: HttpClient) { }

  getEmployees() {
    return this.httpClient.get<any>('/api/employee');
  }

  getEmployee(id: number) {
    return this.httpClient.get<any>('/api/employee/' + id);
  }

}
