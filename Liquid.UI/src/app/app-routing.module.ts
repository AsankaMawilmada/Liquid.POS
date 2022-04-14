import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '@public/login/login.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  // { path: 'logout', component: LogoutComponent },
  // { path: 'forgot-password', component: ForgotPasswordComponent },
  {
    path: 'dashboard',
    loadChildren: () => import('./private/dashboard/dashboard.module').then(m => m.DashboardModule)
  },
  {
    path: 'customers',
    loadChildren: () => import('./private/customer/customer.module').then(m => m.CustomerModule)
  },
  { path: '', redirectTo: '/login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
