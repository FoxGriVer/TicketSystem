import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';

import { User } from 'src/app/entities/database/user.types';
import { OurToken } from 'src/app/entities/database/token.type';


@Injectable()
export class UserService {
    
    private url = "http://localhost:50287/api/user";

    constructor(private http: HttpClient) {

    }    

    register(user: User){
        this.http.post(this.url + "/createUser", user)
                .subscribe();        
    }

    getPersonalInformation(){
        return this.http.get<User>(this.url + "/getPersonalInformation", {
            headers: new HttpHeaders().set('Authorization',"Bearer " + sessionStorage.getItem("userToken"))
        });
    }

    updatePersonalInfo(personalInfo: User){
        return this.http.put<boolean>(this.url + "/updatePersonalInfo", personalInfo, {
            headers: new HttpHeaders().set('Authorization',"Bearer " + sessionStorage.getItem("userToken"))
        });
    }

}   