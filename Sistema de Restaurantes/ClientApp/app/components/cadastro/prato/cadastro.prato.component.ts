import { Component, Inject, OnInit } from '@angular/core';
import { Http, RequestOptions } from '@angular/http';
import { Restaurante } from '../../restaurantes/restaurantes.component';
import { Prato } from '../../pratos/pratos.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

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
    isEdit: boolean;
    pratoId: string | undefined;
    pratoNome: string | undefined;
    pratoPreco: string | undefined;
    restauranteNome: string | undefined;

    ngOnInit() {
        this.route.queryParams.subscribe(params => {
            this.isEdit = !!params['isEdit'];
            this.pratoId = params['pratoId'];
            this.pratoNome = params['pratoNome'];
            this.pratoPreco = params['pratoPreco'];
            this.restauranteNome = params['restauranteNome'];

        });
       

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

    constructor(private http: Http, @Inject('BASE_URL') _baseUrl: string, private fb: FormBuilder, private route: ActivatedRoute, private router: Router) {
        this.listarRestaurantes();
        this.restauranteId = 1;
        this.isEdit = false;

    }  


    public listarRestaurantes() {
        this.http.get(this.baseUrl + '/api/restaurante').subscribe(result => {
            this.restaurantes = result.json() as Restaurante[];
        }, error => console.error(error));
        return this.restaurantes;
    }

    save() {

        if (this.pratosForm != null) {
            if (!this.isEdit) {
                let body = {
                    nome: this.pratosForm.value.nome,
                    preco: this.pratosForm.value.preco,
                    restauranteId: this.restauranteId
                }

                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: null });

                this.http.post(this.baseUrl + 'api/prato', body, options).subscribe(result => {
                    this.router.navigate(["/pratos"]);
                }, error => console.error(error));
                
                return;
            }
            else
            {
                let body = {
                    id: this.pratoId,
                    nome: this.pratosForm.value.nome,
                    preco: this.pratosForm.value.preco
                }

                let headers = new Headers({ 'Content-Type': 'application/json' });
                let options = new RequestOptions({ headers: null });

                this.http.put(this.baseUrl + 'api/prato/' + this.pratoId, body, options).subscribe(result => {
                    this.router.navigate(["/pratos"]);
                }, error => console.error(error));
                return;
            }
        }
        return;
    }

}
