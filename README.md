# Making Your C# Code More Object-oriented

## Rendering Branching Over Boolean Tests Obsolete

### Design

- Make the implicit, explicit. Complexity hidden in implicit details. Example of ifs without else blocks refactoring.
- Guard clauses makes the meaning of the branching logic more obvious. Guards test preconditions.
- Code testing account's state is explicit, explicit condition tests make execution of code complicated
- Start worrying as soon as number of unit tests has started to double with every new feature added
- Good to distribute work through graph of objects, want to verify system under test triggered correct side effect in collaborator. Not always the case, sometimes one object acts as the facade for a small cluster of objects and you only need to test through the interface of that class.
- It's a good sign to see that there are interation tests.
- After refactoring to the State Pattern, the `Account` class is left with one responsibility, to manage its balance. The logic for managing state transitions is handled by separate state classes. Each state also accepts callbacks from `Account` which it will invoke if doing so is a valid operation for that state.

### Advice

- Don't model money as a decimal, introduce a Money class to keep amount and currency together.
- Make a clean-cut branching instruction: Either a guard OR full if-then-else. Avoid incomplete if-then instructions without else.

### State Pattern

- Object of the state class represents one state. Change the object when you want to change the state.

### Consequences of the State Pattern

- Class doesn't have to represent its state explicityly anymore.
- Class doesn't have to manage state transition logic.
- No more branching.
- The runtime type of the state object replaces branching.
- Dynamic dispatch used to choose one implementation or the other.
- Class that uses state becomes simple, it can focus on its primary role.
- Other roles are delegated to concrete state classes.
- Each concrete class is simple.

### Symmetry

Make any ifs without else clauses symmetrical, make the "do nothing" case explicit, make the implicit explicit. Make it explicit that the if and else lead to different blocks of code. Extract the empty block into a new method that does nothing:

```
		// no else block
		if (this.IsFrozen) {  
			this.Unfreeze()
		}
```

```	
		// else block introduced and method that does nothing extracted
		if (this.IsFrozen) {
			this.Unfreeze()
		}
		else {
			this.StayUnfrozen()
		}
```

### Callbacks in Object-oriented Design

Two operations are coupled where a call a call to `OperationA` must be followed by a call to `OperationB`:

```
	OperationA();
	OperationB();
```

The callback principle, pass `OperationB` as an argument to `OperationA` and let `OperationA` call `OperationB` at its end.

```
	OperationA(f) {
		// ...
		f();
	}
```

## Keeping the Focus on Domain Logic with Sequences

- Gap between the semantics of the requirement to find the cheapest painter and the original implementation using looping and branching.
- Problem: Given a sequence of N elements, find the best fitting one.
	- Bad idea: 	Sorting - sort the sequence and pick the first element. Yields `O(NlogN)` where N is the length of the sequence.
							- OrderBy(x => {}).First() invokes the predicate for each element of the sequence
	- Better idea:	Picking - Yields `O(N)` and execution time should be proportional to the length of the sequence.
							- Aggregate() walks the sequence once
- Loops and branching instructions are infrastructure. Don't deal with infrastructure, deal with functional requirements.
	- Pick an available painter with the minimum estimate cost.