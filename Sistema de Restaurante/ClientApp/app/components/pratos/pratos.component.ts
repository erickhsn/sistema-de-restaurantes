import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';
import { Restaurante } from '../restaurantes/restaurantes.component';

@Component({
    selector: 'pratos',
    templateUrl: './pratos.component.html'
})
export class PratosComponent {
    public restaurantes: Restaurante[] | undefined;

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string)
    {
        http.get(baseUrl + '/api/restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
            console.error(this.restaurantes);
        }, error => console.error(error));
        
    }
}

interface Prato {
    id: number;
    nome: string;
    preco: number;
    restaurante?: Restaurante;
}