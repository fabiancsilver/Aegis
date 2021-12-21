import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';


import { AddressTypeListComponent } from './address-type-list/address-type-list.component';
import { AddressTypeEditComponent } from './address-type-edit/address-type-edit.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MaterialModule } from './material.module';
import { ContactEditComponent } from './contact-edit/contact-edit.component';
import { ContactListComponent } from './contact-list/contact-list.component';
import { AddressEditComponent } from './address-edit/address-edit.component';
import { AddressListComponent } from './address-list/address-list.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AddressTypeListComponent,
    AddressTypeEditComponent,
    ContactListComponent,
    ContactEditComponent,
    AddressEditComponent,
    AddressListComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MaterialModule,
    ReactiveFormsModule,
    FlexLayoutModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'contacts', component: ContactListComponent },
      { path: 'contacts/:id', component: ContactEditComponent },
      { path: 'addresses', component: AddressListComponent },
      { path: 'addresses/:id/:contactID', component: AddressEditComponent },
      { path: 'address-types', component: AddressTypeListComponent },
      { path: 'address-types/:id', component: AddressTypeEditComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
