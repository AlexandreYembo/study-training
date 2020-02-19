# 5-View Encapsulation
In view encapsulation when you define an style in your html ```<p>``` and you have in your css the style aplied:
```css p {
        color: blue;
}
```
Basically when there are children components, they won't have this style, because Angular create like custom attributes for each element in HTML and for the CSS Selector.

But you can also override this by defining a configuration in the attribute ```@component```:

```ts
    @component{
        ...
        encapsulation: ViewEncapsulation 
    }
```
Where ```ViewEncapsulation``` import from ```"@angular/core"```.

ViewEncapsulation has 3 modes:

1- Emulated: this is default.

2- None: This component does not use view encapsulation, so they will apply the style globally. It does not create custom attribute in HTML.

3- Native: Uses the shadow DOM technology.

##### Important: The shadow DOM technology is not supported for all the browsers.
Shadow DOM refers to the ability of the browser to include a subtree of DOM elements into the rendering of a document, but not into the main document DOM tree.
