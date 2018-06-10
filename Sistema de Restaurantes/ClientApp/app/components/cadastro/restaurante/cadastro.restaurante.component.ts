import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Http, RequestOptions } from '@angular/http';

@Component({
    selector: 'cadastrorestaurante',
    templateUrl: './cadastro.restaurante.component.html'
})
export class CadastroRestauranteComponent implements OnInit {

    public restauranteForm: FormGroup | undefined;

    baseUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder) {
        this.baseUrl = _baseUrl;
    }  

    ngOnInit() {
        this.restauranteForm = this.fb.group({
            "nome" : ['', [Validators.required]]
        });
    }

    save() {

        if (this.restauranteForm != null) {

            let body = { nome: this.restauranteForm.value.nome }
            let headers = new Headers({ 'Content-Type': 'application/json' });
            let options = new RequestOptions({ headers: null });

            return this.http.post(this.baseUrl + 'api/restaurante', body, options).subscribe();
        }
        return;
    }
}
