import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms'; 
import { Http, RequestOptions } from '@angular/http';
import { inject } from '@angular/core/testing';

@Component({
    selector: 'cadastro-prato',
    templateUrl: './cadastro.prato.component.html'
})
export class CadastroPratoComponent implements OnInit {

    public pratoForm: FormGroup | undefined;
    baseUrl: string = "";

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder) {
        this.baseUrl = _baseUrl;
    }  

    ngOnInit() {
        this.pratoForm = this.fb.group({
            nome: ['', [Validators.required]],
            preco: ['', [Validators.required]]
        });
    }

   /* constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + '/api/restaurante').subscribe(result => {
            this.pratos = result.json() as Prato[];
        }, error => console.error(error));
    }*/

    save() {
        console.log(this.pratoForm);

        let body = JSON.stringify(this.pratoForm);
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers : null });

        return this.http.post(this.baseUrl + '/api/restaurante', body, options).subscribe();
    }


}
