import { AfterViewInit, Component, Input, OnChanges, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTable } from '@angular/material/table';
import { merge } from 'rxjs';
import { startWith, switchMap } from 'rxjs/operators';

import { Address } from '../models/address';
import { AddressService } from '../services/address.service';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css']
})
export class AddressListComponent implements OnChanges {

  
  @Input() contactID: number;

  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  @ViewChild(MatTable, { static: false }) table: MatTable<Address>;



  public dataSource: Address[] = new Array<Address>();

  displayedColumns = [
    'AddressID',
    'Addr1',
    'Addr2',
    'ZipCode',
    'City',
    'State',
    'Country',
    'Command1'
  ];

  constructor(private dataService: AddressService) {

  }
  ngOnChanges(changes: SimpleChanges): void {
    this.getData$(this.contactID)
      .subscribe(
      (result) => this.dataSource = result);
  }


  getData$(contactID: number) {
    return this.dataService.getAllByContact(contactID);
  }
}
