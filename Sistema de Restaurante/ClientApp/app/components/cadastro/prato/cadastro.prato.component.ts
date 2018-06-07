﻿import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Restaurante } from '../../restaurantes/restaurantes.component';
import { FormBuilder } from '@angular/forms';

@Component({
    selector: 'cadastro-prato',
    templateUrl: './cadastro.prato.component.html'
})
export class CadastroPratoComponent {
    public restaurantes: Restaurante[] | undefined;

    baseUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder) {
        this.baseUrl = _baseUrl;
        this.listarRestaurantes();
    }  


    public listarRestaurantes() {
        this.http.get(this.baseUrl + '/api/restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
        }, error => console.error(error));
        return this.restaurantes;
    }

}
