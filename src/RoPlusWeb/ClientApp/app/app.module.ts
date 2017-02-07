import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { UniversalModule } from 'angular2-universal';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { DataDisplayListComponent } from './components/dataDisplay/dataDisplayList.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { CounterComponent } from './components/counter/counter.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CarouselComponent,
        CounterComponent,
        DataDisplayListComponent,
        HomeComponent
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'data-display-table', component: DataDisplayListComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
