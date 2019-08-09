# Making Your C# Code More Object-oriented

## Rendering Branching Over Boolean Tests Obsolete

### Design

- Make the implicit, explicit. Complexity hidden in implicit details. Example of ifs without else blocks refactoring.
- Guard clauses makes the meaning of the branching logic more obvious. Guards test preconditions.
- Code testing account's state is explicit, explicit condition tests make execution of code complicated
- Start worrying as soon as number of unit tests has started to double with every new feature added
- Good to distribute work through graph of objects, want to verify system under test triggered correct side effect in collaborator. Not always the case, sometimes one object acts as the facade for a small cluster of objects and you only need to test through the interface of that class.

### Advice

- Don't model money as a decimal, introduce a Money class to keep amount and currency together.
- Make a clean-cut branching instruction: Either a guard OR full if-then-else. Avoid incomplete if-then instructions without else.

### Symmetry

Make any ifs without else clauses symmetrical, make the "do nothing" case explicit, make the implicit explicit. Make it explicit that the if and else lead to different blocks of code. Extract the empty block into a new method that does nothing:

```
		if (this.IsFrozen) {  
			this.Unfreeze()
		} 							// no else block
```

```	
		if (this.IsFrozen) {
			this.Unfreeze()
		}
		else {						// else block introduced
			this.StayUnfrozen()		// method that does nothing extracted
		}
```		