import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ServerErrorComponent } from './core/error-pages/server-error/server-error.component';
import { NotFoundComponent} from './core/error-pages/not-found/not-found.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { AuthGuard } from './core/guards/auth.guard';
import { OrdersComponent } from './orders/orders.component';
import { OrderDetailedComponent } from './orders/order-detailed/order-detailed.component';

const routes: Routes = [
  { path: '', component: HomeComponent, data: {breadcrumb: 'Home'}},


  { path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test Errors'}},


  { path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server Error'}},


  { path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'}},


  { path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), data: {breadcrumb: 'Shop'}},
 //{ path: 'shop/:id', component: ProductDetailsComponent},


  { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), data: {breadcrumb: 'Basket'}},


  { path: 'checkout',
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule), data: {breadcrumb: 'Checkout'}},
  
    // BUKVLANO JE ISTO KAO OVO DOLE ALI JBG

  // { path: 'orders',
  //   canActivate: [AuthGuard],
  //   loadChildren: () => import('./orders/orders.module').then(mod => mod.OrdersModule), data: {breadcrumb: 'Orders'}
  // },
  {
    path: 'orders',
    canActivate: [AuthGuard],
    loadChildren: () => import('./orders/orders.module')
      .then(mod => mod.OrdersModule), data: { breadcrumb: 'Orders' }
  },
  

  { path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule),
   data: {breadcrumb: {skip: true}}},

   
  { path: '**', redirectTo: 'not-found', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


// import { NgModule } from '@angular/core';
// import { Routes, RouterModule } from '@angular/router';
// import { HomeComponent } from './home/home.component';
// import { ServerErrorComponent } from './core/error-pages/server-error/server-error.component';
// import { NotFoundComponent} from './core/error-pages/not-found/not-found.component';
// import { TestErrorComponent } from './core/test-error/test-error.component';
// import { AuthGuard } from './core/guards/auth.guard';

// const routes: Routes = [
//   { path: '', component: HomeComponent, data: { breadcrumb: 'Home' } },
//   { path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test Errors'}},
//   { path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server Error'}},
//   { path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'}},
//   { path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), data: { breadcrumb: 'Shop' } },
//   { path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), data: { breadcrumb: 'Basket' } },
//   {
//     path: 'checkout',
//     canActivate: [AuthGuard],
//     loadChildren: () => import('./checkout/checkout.module')
//       .then(mod => mod.CheckoutModule), data: { breadcrumb: 'Checkout' }
//   },
//   {
//     path: 'orders',
//     canActivate: [AuthGuard],
//     loadChildren: () => import('./orders/orders.module')
//       .then(mod => mod.OrdersModule), data: { breadcrumb: 'Orders' }
//   },
//   {
//     path: 'account',
//     loadChildren: () => import('./account/account.module')
//       .then(mod => mod.AccountModule), data: { breadcrumb: { skip: true } }
//   },
//   { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
// ];

// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })
// export class AppRoutingModule { }
