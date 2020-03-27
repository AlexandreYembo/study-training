import { Component, EventEmitter, Output } from '@angular/core';

@Component({
    selector: 'app-header',
    templateUrl:'./header.component.html'
})

export class HeaderComponent {
    collapsed = true;
    @Output() selectedEvent = new EventEmitter<string>();
    
    onSelect(navReference: string){
        this.selectedEvent.emit(navReference);
    }
}