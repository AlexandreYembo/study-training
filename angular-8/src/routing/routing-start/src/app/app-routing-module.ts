import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { UserComponent } from "./users/user/user.component";
import { ServersComponent } from "./servers/servers.component";
import { ServerComponent } from "./servers/server/server.component";
import { EditServerComponent } from "./servers/edit-server/edit-server.component";
import { PageNotFoundComponent } from "./page-not-found/page-not-found.component";
import { AuthGuardService } from "./auth-guard.service";
import { CanDeactivateGuard } from "./servers/edit-server/can-deactivate-guard.service";

const appRoutes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'users', component: UserComponent },
    { path: 'users/:id/:name', component: UserComponent },
    { path: 'servers', 
      //canActivate: [AuthGuardService], 
      canActivateChild:[AuthGuardService],
      component: ServersComponent, 
      children:[
        { path: ':id', component: ServerComponent },
        { path: ':id/edit', component: EditServerComponent, canDeactivate: [CanDeactivateGuard] }
      ] 
    },
    { path: '**', component: PageNotFoundComponent }
  ]
  
@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule] //when I use export a defined I want to export this module and what should be accessible to this module which imports this module?
})

export class AppRoutingModule {

}