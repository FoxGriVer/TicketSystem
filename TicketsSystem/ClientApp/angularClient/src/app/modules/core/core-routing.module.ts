import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { CoreComponent } from './components/core/core.component';
import { LoginComponent } from './components/authorization/login/login.component';
import { CreateAccountComponent } from './components/authorization/create-account/create-account.component';
import { PickedEventComponent } from './components/picked-event/picked-event.component';
import { BuyTicketComponent } from './components/buy-ticket/buy-ticket.component';
import { PersonalPageComponent } from './components/personal-page/personal-page.component';
import { BoughtTicketsComponent } from './components/bought-tickets/bought-tickets.component';

const routes: Routes = [
    {
      path: '',
      component: CoreComponent
    },
    {
      path: 'login',
      component: LoginComponent
    },
    {
      path: 'login/doneSuccess',
      component: CoreComponent
    },
    {
      path: 'login/createAccount',
      component: CreateAccountComponent
    },
    {
      path: 'login/createAccount/registerComplite',
      component: CoreComponent
    },
    {
      path: 'event/:id',
      component: PickedEventComponent
    },
    {
      path: 'buyTicket/:id',
      component: BuyTicketComponent
    },
    {
      path: 'personalPage',
      component: PersonalPageComponent
    },
    {
      path:'personalPage/boughtTicketsHistory',
      component: BoughtTicketsComponent
    }

];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
export class CoreRoutingModule {}