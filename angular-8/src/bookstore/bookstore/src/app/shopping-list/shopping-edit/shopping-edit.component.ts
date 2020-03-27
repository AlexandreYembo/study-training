import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { Ingredient } from 'src/app/shared/ingredient.model';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {
  @ViewChild('nameInput', {static: true}) nameInputRef: ElementRef;
  @ViewChild('amountInput', {static: true}) amountInputRef: ElementRef;
  
  @Output() itemAddedEvent = new EventEmitter<Ingredient>();
  
  constructor() { }

  ngOnInit() {
  }

  onAddItem(){
    var name = this.nameInputRef.nativeElement.value;
    var amount = this.amountInputRef.nativeElement.value;

    const newIngredient = new Ingredient(name, amount);
    this.itemAddedEvent.emit(newIngredient);
  }

}