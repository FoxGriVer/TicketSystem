import { Injectable, EventEmitter } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';

import { User } from 'src/app/entities/database/user.types';

@Injectable()
export class AutheticationService {

    private url = "http://localhost:50287/api/account";
    
    userAuthorized: boolean;

    constructor(private http: HttpClient){

    }

    async checkUserToken(){
        let token = await sessionStorage.getItem("userToken");
        return token;
    }    
    
    logOut(){
        sessionStorage.clear();
    }   

    login(user:User){   
        return this.http.post(this.url + "/login", user);
    } 

    checkAuthorisation(){
        return this.http.get(this.url + "/checkAuthorization", {
            headers: new HttpHeaders().set('Authorization',"Bearer " + sessionStorage.getItem("userToken"))
        });
    }

}