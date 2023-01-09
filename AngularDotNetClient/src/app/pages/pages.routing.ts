import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MoviesComponent } from './movies/movies.component';
import { PagesComponent } from './pages.component';

const routes: Routes = [
    {
        path:'main', 
        component: PagesComponent,
        children: [
            {path:'', component: HomeComponent},
            {path:'movies', component: MoviesComponent}
        ]
    },

]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class PagesRoutingModule {}
