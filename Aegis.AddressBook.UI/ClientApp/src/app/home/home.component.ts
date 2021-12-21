import { Component, OnInit, ViewChild } from '@angular/core';

import { MatTable } from '@angular/material/table';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

import { Address } from '../models/address';
import { AddressService } from '../services/address.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
  @ViewChild(MatTable, { static: false }) table: MatTable<Address>;

  public dataSource: Address[] = new Array<Address>();

  displayedColumns = [
    'AddressID',
    'Addr1',
    'Addr2',
    'ZipCode',
    'City',
    'State',
    'Country'
  ];

  constructor(private dataService: AddressService) {

  }
  ngOnInit(): void {
    this.getData$()
    .subscribe(
      (result) => this.dataSource = result);
  }


  getData$() {
    return this.dataService.getLast10();
  }
}
