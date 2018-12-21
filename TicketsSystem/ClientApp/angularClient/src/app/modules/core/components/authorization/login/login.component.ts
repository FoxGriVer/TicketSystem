import { Component, OnInit } from '@angular/core';
import { Router} from '@angular/router';

import { User } from 'src/app/entities/database/user.types';
import { OurToken } from 'src/app/entities/database/token.type';

import { AutheticationService } from 'src/app/services/databaseServices/authetication.service';


@Component({
    selector: 'login-component',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']        
})
export class LoginComponent implements OnInit {

    loginUser: User;

    constructor(private authService: AutheticationService, private router: Router) {
        this.loginUser = new User();
     }

    ngOnInit(): void { }

    tryLogin(){
        let result = this.authService.login(this.loginUser)
                .subscribe(
                    async (data: OurToken) => {                        
                        await sessionStorage.setItem('userToken', data.token);
                        this.router.navigate(['']);
                        this.refresh();
                    },
                    error => {
                        alert("Авторизация не пройдена");
                    }  
                );
        this.loginUser = new User();
    }

    refresh(): void {
        window.location.reload();
    }

}
