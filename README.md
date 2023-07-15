# Design-Patterns

So what are design patterns, and why should I care? How can they help me in my day to day programming job?

Before delving into the meat about design patterns, I’d like to set out a definition for “abstraction”. I’ll be using this definition: “Conceptual abstractions may be formed by filtering the information content of a concept or an observable phenomenon, selecting only those aspects which are relevant for a particular purpose.”

That is, conceptual abstraction is a process of subtracting away any irrelevant detail, so only what is left are the relevant details. The output of this process can be thought of as a generalization.

If that sounds like a bunch of useless academic gobbledygook, you’re not alone, so let’s go through some examples of creating models via abstraction / generalization:

[Show a couple pictures of cats]

What can we generalize about these pictures? That they are vector art cats? Yes. That they are cats? Yes. That they are assortments of colors? Yes. All of these are valid models we can produce from the process of abstraction.



Now, onto the main show.

What is a design pattern? I like this definition from source making dot com. “In software engineering, a design pattern is a general repeatable solution to a commonly occurring problem in software design. A design pattern isn't a finished design that can be transformed directly into code. It is a description or template for how to solve a problem that can be used in many different situations. “

Or, another way to put it is, a design pattern is a generalization, or template, for solving a common software problem, that can’t be directly represented as code.

Notice the bit about “A design pattern isn't a finished design that can be transformed directly into code.”. This is extremely important. 

A method isn’t a design pattern in C#, even though it solves a general repeatable solution in software design, because it CAN be directly transformed into code, meaning there is a native construct in the language for representing the concept.

The dirty truth is, design patterns are templatized solutions to common problems that you as the programmer have to manually implement, and there is no first class native language construct to assist in. This means, for whatever reason, the ability of the language to create abstractions at this point, is not powerful enough to encapsulate whatever you are trying to abstract into code. 
