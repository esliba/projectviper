import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LandingComponent } from './landing/landing.component';

const appRoutes: Routes = [
    { path: 'landing', component: LandingComponent },
    { path: '',
      redirectTo: '/landing',
      pathMatch: 'full'
    },
    { path: '**', component: LandingComponent }
  ];

@NgModule({
    declarations: [],
    imports: [
        RouterModule.forRoot(
            appRoutes,
        )],
    exports: [RouterModule],
    providers: [],
    bootstrap: []
})
export class AppRoutingModule { }