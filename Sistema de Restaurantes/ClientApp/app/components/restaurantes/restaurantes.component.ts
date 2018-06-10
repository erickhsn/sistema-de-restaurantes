import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';

@Component({
    selector: 'restaurantes',
    templateUrl: './restaurantes.component.html'
})
export class RestaurantesComponent {
    public restaurantes?: Restaurante[];

    baseUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder) {
        this.baseUrl = _baseUrl;
        this.listarRestaurantes();
    }  

    public listarRestaurantes()
    {
        this.http.get(this.baseUrl + '/api/restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
        }, error => console.error(error));
        return this.restaurantes;
    }

    removeRow(restaurante: Restaurante, index: number) {

        this.http.delete(this.baseUrl + '/api/restaurante/' + restaurante.id).subscribe();

        if (this.restaurantes != null)
            this.restaurantes.splice(index, 1);

    }

}

export interface Restaurante {
    id: number;
    nome: string;
    pratos: object;
}