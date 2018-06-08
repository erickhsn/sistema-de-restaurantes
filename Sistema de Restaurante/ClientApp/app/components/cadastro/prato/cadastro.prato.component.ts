import { Component, Inject, OnInit } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { Restaurante } from '../../restaurantes/restaurantes.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: 'cadastro-prato',
    templateUrl: './cadastro.prato.component.html'
})
export class CadastroPratoComponent implements OnInit {
    public restaurantes: Restaurante[] | undefined;
    public pratosForm: FormGroup | undefined;


    baseUrl: string = "";
    restauranteId: Number;
    primeiro: boolean = true;

    ngOnInit() {
        this.pratosForm = this.fb.group({
            "nome": ['', [Validators.required]],
            "preco": ['', [Validators.required]],
            "restauranteId": ['', [Validators.required]]
        });
    }


    onChangeObj(newObj: Number) {
        if (newObj == null) {
            alert("Element can't be null");
            return;
        }
        this.restauranteId = newObj;
    }

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder) {
        this.baseUrl = _baseUrl;
        this.listarRestaurantes();
        this.restauranteId = 1;
    }  


    public listarRestaurantes() {
        this.http.get(this.baseUrl + '/api/restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
        }, error => console.error(error));
        return this.restaurantes;
    }

    save() {

        if (this.pratosForm != null) {

            let body = {
                nome: this.pratosForm.value.nome,
                preco: this.pratosForm.value.preco,
                restauranteId: this.restauranteId
            }

            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: null });

            return this.http.post(this.baseUrl + 'api/prato', body, options).subscribe();
        }
        return;
    }

}
