import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';

@Component({
    selector: 'pratos',
    templateUrl: './pratos.component.html'
})
export class PratosComponent {
    public pratos: Prato[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string)
    {
        http.get(baseUrl + '/api/restaurante').subscribe(result => {
            this.pratos = result.json() as Prato[];
        }, error => console.error(error));
    }
}

interface Prato {
    id: number;
    nome: string;
    preco: number;
    restaurante: object;
}