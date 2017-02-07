import { Component, Input } from '@angular/core';
import {Http} from '@angular/http';

@Component({
    selector: 'carousel',
    template: require('./carousel.component.html'),
    styles: [require('./carousel.component.css')]
})

export class CarouselComponent {
    private start = false;
    carouselName = "generic-carousel"
    slides = [];
    @Input() sourceUrl: string = '/api/projects/get';

    constructor(http: Http) {
        http.get(this.sourceUrl)
            .subscribe(res => this.startCarousel(res.json()));
    }

    startCarousel(slides: Object[]) {
        this.slides = slides;
    }

    isActive(slide: string) {
        return slide === this.slides[0];
    }
}
