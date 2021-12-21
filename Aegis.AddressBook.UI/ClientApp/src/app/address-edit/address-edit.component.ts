import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { EMPTY, of } from 'rxjs';
import { map, switchMap, tap } from 'rxjs/operators';
import { DialogService } from '../core/dialog.service';

import { Address } from '../models/address';
import { AddressService } from '../services/address.service';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css']
})
export class AddressEditComponent implements OnInit {

  public form: FormGroup;
  public errorMessage: string;  

  constructor(private fb: FormBuilder,
    private serviceData: AddressService,
    private dialogService: DialogService,
    private dialog: MatDialog,
    private activatedRoute: ActivatedRoute,
    private route: Router
  ) {

    this.errorMessage = '';
  }


  ngOnInit() {
    this.form = this.fb.group({
      AddressID: [null, [Validators.required]],
      AddressTypeID: [null, [Validators.required]],
      ContactID: [null, [Validators.required]],
      Addr1: [null, [Validators.required, Validators.maxLength(128)]],
      Addr2: [null, [Validators.required, Validators.maxLength(128)]],
      ZipCode: [null, [Validators.required, Validators.maxLength(128)]],      
      City: [null, [Validators.required, Validators.maxLength(128)]],
      State: [null, [Validators.required, Validators.maxLength(128)]],
      Country: [null, [Validators.required, Validators.maxLength(128)]]
    });

    this.activatedRoute.paramMap
      .subscribe(params => {

        this.form.patchValue({          
          ContactID: +params.get('contactID'),          
        });

        if (+params.get('id') > 0) {
          this.getItem(+params.get('id'));
        }
        else {
          this.initialize();
        }
      });

  }

  getItem(itemID: number): void {

    this.serviceData.getItem(itemID)
      .pipe(
        tap((item) => this.displayItem(item)))
      .subscribe(
        null,
        (error) => this.errorMessage = error);
  }

  submit(): void {

    if (this.form.valid) {
      if (this.form.dirty) {

        let newItem: Address = this.form.value;

        if (newItem.AddressID === 0) {
          this.serviceData.insert(newItem)
            .subscribe(
              (item: Address) => {
                this.form.get('AddressID').setValue(item.AddressID);
                this.onSubmitComplete();

              },
              (error: any) => {

                this.errorMessage = <any>
                  error;
              }
            );
        } else {
          this.serviceData.update(newItem.AddressID, newItem)
            .subscribe(
              () => {
                this.onSubmitComplete();
              },
              (error: any) => {
                this.errorMessage = <any>
                  error;
              }
            );
        }
      } else {
        this.errorMessage = 'Please make some changes.';
      }
    } else {
      this.errorMessage = 'Please correct the validation errors.';
    }
  }

  newItem() {
    this.initialize();
  }

  initialize() {
    this.form.patchValue({
      AddressID: 0,
      AddressTypeID: 1,      
      Addr1: null,
      Addr2: null,
      ZipCode: null,
      City: null,
      State: null,
      Country: null
    });
  }

  openDeleteDialog(): void {

    this.dialogService.confirm('Do you really want to delete this Address')
      .pipe(
        switchMap((result) => {
          if (result === true) {
            return this.serviceData.delete(+this.form.get('AddressID').value)
          }
          else {
            return of({});
          }
        }))
      .subscribe(
        () => this.route.navigateByUrl(`/contacts/${this.form.get('ContactID').value}`));
  }

  deleteItem(itemID: number) {

    if (itemID > 0) {
      this.serviceData.delete(itemID)
        .subscribe(
          (item: Address) => {
            this.route.navigateByUrl(`/contacts/${this.form.get('ContactID').value}`)
          },
          (error: any) => {
            this.errorMessage = <any>error;
          }
        );
    }
    else {
      this.errorMessage = 'Error';
    }
  }

  onSubmitComplete(): void {
    this.form.markAsUntouched();
    this.form.markAsPristine();
  }

  displayItem(item: Address): void {
    this.form.patchValue({
      AddressID: item.AddressID,
      AddressTypeID: item.AddressTypeID,      
      Addr1: item.Addr1 ? item.Addr1 : null,
      Addr2: item.Addr2 ? item.Addr2 : null,
      ZipCode: item.ZipCode ? item.ZipCode : null,
      City: item.City ? item.City : null,
      State: item.State ? item.State : null,
      Country: item.Country ? item.Country : null,
    });
  }
}
