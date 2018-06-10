import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { Http, RequestOptions } from '@angular/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'cadastrorestaurante',
    templateUrl: './cadastro.restaurante.component.html'
})
export class CadastroRestauranteComponent implements OnInit {

    public restauranteForm: FormGroup | undefined;

    baseUrl: string = "";

    isEdit: boolean;
    restauranteId: string | undefined;
    restauranteNome: string | undefined;

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
        this.baseUrl = _baseUrl;
        this.isEdit = false;
    }  

    ngOnInit() {
        this.route.queryParams.subscribe(params => {
            this.isEdit = !!params['isEdit'];
            this.restauranteId = params['restauranteId'];
            this.restauranteNome = params['restauranteNome'];
        });

        this.restauranteForm = this.fb.group({
            "nome" : ['', [Validators.required]]
        });
    }

    save() {

        if (this.restauranteForm != null) {

            if (!this.isEdit) {
                let body = { nome: this.restauranteForm.value.nome }
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: null });

                this.http.post(this.baseUrl + 'api/restaurante', body, options).subscribe(result => {
                    this.router.navigate(["/restaurantes"]);
                }, error => console.error(error));

                return;
            }
            else {
                let body = { id: this.restauranteId, nome: this.restauranteForm.value.nome }
                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: null });

                this.http.put(this.baseUrl + 'api/restaurante/' + this.restauranteId, body, options).subscribe(result => {
                    this.router.navigate(["/restaurantes"]);
                }, error => console.error(error));
                return;
            }
        }
        return;
    }
}
