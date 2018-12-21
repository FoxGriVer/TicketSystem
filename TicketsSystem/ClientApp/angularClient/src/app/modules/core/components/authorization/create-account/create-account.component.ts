import { Component, OnInit } from '@angular/core';

import { User } from 'src/app/entities/database/user.types';

import { AutheticationService } from 'src/app/services/databaseServices/authetication.service';
import { UserService } from 'src/app/services/databaseServices/user.service';



@Component({
    selector: 'create-account-component',
    templateUrl: './create-account.component.html',
    styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {

    createdUser: User;

    constructor(private authService: AutheticationService, private userService: UserService) {
        this.createdUser = new User();
     }

    ngOnInit(): void { }

    createUser(){
        this.createdUser.role = "User";
        this.userService.register(this.createdUser);
        this.createdUser = new User();
    }
}
