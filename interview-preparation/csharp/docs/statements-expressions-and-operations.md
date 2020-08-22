# Statemens.
Consistis in a single line of code that ends in a semicolon. Or a block that consists a serie of single line.
```cs
    int counter; // Statement

    foreach(int radius in listRadius){ // Foreach statement
        double cicumference = pi * (@ * radius); //Statement
    }

```

#### Types of statements
- Selection statements: ```if, else, switch, case```.

- Iteration statements: ```do, for, foreach, in, while```.

- Jump statements: ```break, continue, default, goto, return, yield```.

- Exception handling statements: ```throw, try-catch, try-finally, try-catch-finally```.

- Checked/unchecked statements: ```++, --, -, +, *, /```;

- For async methods: ```await```.

- ```Fixed``` statement: Prevent garbage collector from relocating a movable variable. Only permited in a unsafe context and it sets a pointer to a managed variable and "pins" the variable during the execution.

- ```Lock``` statement: Limite access to blocks os code to only one thread at a time.