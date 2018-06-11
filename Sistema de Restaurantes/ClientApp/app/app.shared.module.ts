import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { FilterPipe } from './filter.pipe';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { PratosComponent } from './components/pratos/pratos.component';
import { RestaurantesComponent } from './components/restaurantes/restaurantes.component';
import { CadastroPratoComponent } from './components/cadastro/prato/cadastro.prato.component';
import { CadastroRestauranteComponent } from './components/cadastro/restaurante/cadastro.restaurante.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        PratosComponent,
        RestaurantesComponent,
        CadastroPratoComponent,
        CadastroRestauranteComponent,
        FilterPipe
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'pratos', component: PratosComponent },
            { path: 'restaurantes', component: RestaurantesComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'cadastro/prato', component: CadastroPratoComponent },
            { path: 'cadastro/restaurante', component: CadastroRestauranteComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
