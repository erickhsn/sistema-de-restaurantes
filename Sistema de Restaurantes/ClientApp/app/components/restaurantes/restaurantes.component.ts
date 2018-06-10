import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';
import { FormBuilder } from '@angular/forms';
import { NavigationExtras, Router } from '@angular/router';

@Component({
    selector: 'restaurantes',
    templateUrl: './restaurantes.component.html'
})
export class RestaurantesComponent {
    public restaurantes?: Restaurante[];

    baseUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder, private router: Router) {
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

    alterar(restaurante: Restaurante) {
        let params: NavigationExtras = {
            queryParams:
                {
                    "isEdit": true,
                    "restauranteId": restaurante.id,
                    "restauranteNome": restaurante.nome
                }
        };
        this.router.navigate(["/cadastro/restaurante"], params);
    }

}

export interface Restaurante {
    id: number;
    nome: string;
    pratos: object;
}