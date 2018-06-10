import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { inject } from '@angular/core/testing';
import { Restaurante } from '../restaurantes/restaurantes.component';
import { forEach } from '@angular/router/src/utils/collection';
import { Router, NavigationExtras } from "@angular/router";;

@Component({
    selector: 'pratos',
    templateUrl: './pratos.component.html'
})
export class PratosComponent {
    public restaurantes: Restaurante[] | undefined;

    baseUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private router: Router)
    {
        this.baseUrl = _baseUrl;
        http.get(this.baseUrl + '/api/restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
        }, error => console.error(error));

        
        
    }

    removeRow(prato: Prato, pratos: Prato[], index: number) {

        this.http.delete(this.baseUrl + '/api/prato/' + prato.id).subscribe();

        pratos.splice(index, 1);

    }

    alterar(prato: Prato, nome: string) {
        let params: NavigationExtras = {
            queryParams:
                {
                    "isEdit": true,
                    "pratoId": prato.id,
                    "pratoNome": prato.nome,
                    "pratoPreco": prato.preco,
                    "restauranteNome": nome
                }
        };
        this.router.navigate(["/cadastro/prato"], params);
    }

   
}

export interface Prato {
    id: number;
    nome: string;
    preco: number;
    restaurante?: Restaurante;
}