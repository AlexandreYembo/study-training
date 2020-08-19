import { Ingredient } from '../shared/ingredient.model';
//import { EventEmitter } from '@angular/core';
import { Subject } from 'rxjs';

export class ShoppingListService{
    // ingredientsChanged = new EventEmitter<Ingredient[]>();
    ingredientsChanged = new Subject<Ingredient[]>();

    private ingredients: Ingredient[] = [
        new Ingredient('Apple', 5),
        new Ingredient('Tomatoes', 10)
      ];

    private ingredientEmit(){
        // this.ingredientsChanged.emit(this.ingredients.slice());
        this.ingredientsChanged.next(this.ingredients.slice());
    }
    getIngredients(){
        return this.ingredients.slice(); // return only a copy of the array.
    }

    addIngredient(ingredient: Ingredient){
        this.ingredients.push(ingredient);
        this.ingredientEmit();
    }
    
    addIngredients(ingredients: Ingredient[]){
        this.ingredients.push(...ingredients);
        this.ingredientEmit();
        // push(...array) -> is a feature in ES6. It is a operator to spread which allows us to basicallu turn an array of elements into 
        //a list of elements.
    }
}