import { Component, OnInit } from '@angular/core';
import { Recipe } from '../recipe.model';
import { RecipeService } from '../recipe.service';
import { ActivatedRoute, Params, Router } from '@angular/router';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit {
  recipe: Recipe;
  id: number;

  constructor(private recipeServices: RecipeService,
              private currentRoute: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.currentRoute.params.subscribe(
      (params: Params) => {
        this.id = +params['id'];
        this.recipe = this.recipeServices.getRecipe(this.id);
      }
    );
  }

  addToShoppingList(){
    this.recipeServices.addIngredientsToShoppingList(this.recipe.ingredients);
  }

  onEditRecipe(){
    this.router.navigate(['edit'], {relativeTo: this.currentRoute});

    //---> More complex to create this link and it is not necessary at all.
    // It goes one level before.
    //this.router.navigate(['../', this.id, 'edit'], {relativeTo: this.currentRoute});
  }
}
