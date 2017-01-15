import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'fetchdata',
    template: require('./fetchdata.component.html')
})
export class FetchDataComponent {
    public resultList: ListItems[];
    public activeControllers: SelectOptions[] = [{ name: "Sections" }, { name: "Projects" }]
    public selectedController: SelectOptions = this.activeControllers[0];
    public _http: Http
    constructor(http: Http) {
        this._http = http;
        this.RetriveData();
    }

    UpdateSelectedController(newSelection) {
        this.selectedController = newSelection
        this.RetriveData();
    }

    RetriveData() {
        this._http.get('/api/' + this.selectedController.name + '/get').subscribe(result => {
            this.resultList = result.json();
        });
    }
}
interface SelectOptions {
    name: string;
}

interface ListItems {
    id: number;
    name: string;
    description: string;
    isActive: boolean;
}
