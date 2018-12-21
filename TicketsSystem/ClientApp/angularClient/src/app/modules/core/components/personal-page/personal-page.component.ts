import { Component, OnInit } from '@angular/core';

import { AutheticationService } from 'src/app/services/databaseServices/authetication.service';
import { UserService } from 'src/app/services/databaseServices/user.service';

import { User } from 'src/app/entities/database/user.types';

@Component({
    selector: 'personal-page-component',
    templateUrl: './personal-page.component.html',
    styleUrls: ['./personal-page.component.css']
})
export class PersonalPageComponent implements OnInit {

    authorizedUser: User = new User();

    constructor(private authService: AutheticationService, private userService: UserService) {

     }

    ngOnInit(): void {
        this.loadPersonalInformaition();
     }

    loadPersonalInformaition(){
        this.userService.getPersonalInformation()
            .subscribe(                
                data => {
                    this.authorizedUser = data;
                }               
            );
    }

    updatePersonalInfo(){
        this.userService.updatePersonalInfo(this.authorizedUser)
            .subscribe();
    }

}
