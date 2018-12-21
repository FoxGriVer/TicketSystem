import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';

import { CoreRoutingModule } from './core-routing.module';
import { HttpClientModule } from '@angular/common/http';

import { CoreComponent } from './components/core/core.component';
import { HeaderComponent } from './components/header/header.component';
import { LoginComponent } from './components/authorization/login/login.component';
import { CreateAccountComponent } from './components/authorization/create-account/create-account.component';
import { EventsPanelComponent } from './components/events-panel/events-panel.component';
import { PickedEventComponent } from './components/picked-event/picked-event.component';
import { BuyTicketComponent } from './components/buy-ticket/buy-ticket.component';
import { PersonalPageComponent } from './components/personal-page/personal-page.component';
import { BoughtTicketsComponent } from './components/bought-tickets/bought-tickets.component';

import { UserService } from 'src/app/services/databaseServices/user.service';
import { AutheticationService } from 'src/app/services/databaseServices/authetication.service';
import { EntertainmentEventService } from 'src/app/services/databaseServices/event.service';
import { EventShareService } from 'src/app/services/shareServices/event-share.service';
import { TicketService } from 'src/app/services/databaseServices/ticket.service';

@NgModule({
    declarations: [
        CoreComponent,
        HeaderComponent,
        LoginComponent,
        CreateAccountComponent,
        EventsPanelComponent,
        PickedEventComponent,
        BuyTicketComponent,
        PersonalPageComponent,
        BoughtTicketsComponent
    ],
    imports: [ 
        CommonModule,
        CoreRoutingModule,
        FormsModule,
        HttpClientModule
    ],
    exports: [
        RouterModule,
        HeaderComponent
    ],
    providers: [
        UserService,
        AutheticationService,
        EntertainmentEventService,
        EventShareService,
        TicketService
    ],
})
export class CoreModule {}