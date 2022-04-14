import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';

export const routes: Routes = [
    //{
    //  path: '',
      //component: LayoutComponent,
      //children:[
       // { path: 'users', component: PlaceholderComponentComponent, canActivate: [AuthGuard], data: { breadcrumb: 'Users'},
         // children:[
         //   { path: '', component: UserListComponent, canActivate: [AuthGuard] , data: { breadcrumb: 'Users'}},
            { path: 'edit/:id', component: CustomerComponent,
             //canActivate: [AuthGuard] ,
             data: { breadcrumb: 'Edit'}},
            { path: 'new', component: CustomerComponent, 
           // canActivate: [AuthGuard] , 
            data: { breadcrumb: 'New'}},
        //    { path: 'update-password', component: UpdatePasswordComponent, canActivate: [AuthGuard] , data: { breadcrumb: 'Update Password'}},
        //  ]
      // }
     // ]
    //}
  ];
    

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CustomerRoutingModule {
}
