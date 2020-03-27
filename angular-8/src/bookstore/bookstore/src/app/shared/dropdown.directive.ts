import { Directive, HostListener, HostBinding, Input, ElementRef } from '@angular/core';

@Directive({
    selector: '[appDropdown]'
})
export class DropdownDirective{
    constructor(private elRef: ElementRef){ }

    @HostBinding('class.open') isOpen = false;

    //This is won't close if you click ouside, only on Dropdown.
    // @HostListener('click') toggleOpen(eventData: Event){
    //     this.isOpen = !this.isOpen;
    // }

    //Closing the Dropdown From Anywhere
    /**
     * If you want that a dropdown can also be closed by a click anywhere outside 
     * (which also means that a click on one dropdown closes any other one, btw.),
     * Change @HostListener('document:click', ['$event']) toggleOpen(event : Event){
     */
    @HostListener('document:click', ['$event']) toggleOpen(event : Event){
        this.isOpen = this.elRef.nativeElement.contains(event.target) ? !this.isOpen : false;
    }
}