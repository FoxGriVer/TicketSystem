import { Component, OnInit, Input } from '@angular/core';

import { AutheticationService } from 'src/app/services/databaseServices/authetication.service';

@Component({
    selector: 'header-component',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

    userAuthorized: boolean = false;

    constructor(private authService: AutheticationService) { 
        this.checkUserAuthorized();
    }

    ngOnInit(): void {
    }

    logOut(){
        this.authService.logOut();
        this.userAuthorized = false;
    }

    async checkUserAuthorized(){
        let token = await this.authService.checkUserToken();
        if(token == null){
            this.userAuthorized = false;            
        } else {
            this.userAuthorized = true;
        }
    }

    // test(){
    //     let token = this.authService.checkAuthorisation().subscribe(
    //         data => {
    //             this.userAuthorized = true;
    //             console.log("suc")
    //         },
    //         error => {
    //             this.logOut();                
    //             console.log("error")
    //         }
    //     );
    // }
    
}
