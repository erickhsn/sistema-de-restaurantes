import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';
import { Restaurante } from '../restaurantes/restaurantes.component';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
    selector: 'pratos',
    templateUrl: './pratos.component.html'
})
export class PratosComponent {
    public restaurantes: Restaurante[] | undefined;

    baseUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string)
    {
        this.baseUrl = _baseUrl;
        http.get(this.baseUrl + '/api/restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
            console.error(this.restaurantes);
        }, error => console.error(error));

        
        
    }

    removeRow(prato: Prato, pratos: Prato[], index: number) {

        this.http.delete(this.baseUrl + '/api/prato/' + prato.id).subscribe();

        pratos.splice(index, 1);

    }

   
}

interface Prato {
    id: number;
    nome: string;
    preco: number;
    restaurante?: Restaurante;
}