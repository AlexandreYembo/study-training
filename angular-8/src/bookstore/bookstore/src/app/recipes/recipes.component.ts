import { Component, OnInit } from '@angular/core';
import { Recipe } from './recipe.model';
import { RecipeService } from './recipe.service';

@Component({
    selector: 'app-recipes',
    templateUrl: './recipes.component.html',
    providers: [RecipeService]
  })
export class RecipesComponent implements OnInit{
  selectedRecipe: Recipe;

  constructor(private recipeService: RecipeService){}

  ngOnInit(){
    this.recipeService.recipeSelected.subscribe( // this get in the event.emit()
      (recipe: Recipe) => this.selectedRecipe = recipe
    );
  }
}