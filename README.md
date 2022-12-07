# SOLID Principles

refer from [www.c-sharpcorner.com](https://www.c-sharpcorner.com/UploadFile/damubetha/solid-principles-in-C-Sharp/)

## Intro to SOLID principles
 
SOLID principles are the design principles that enable us to manage most of the software design problems. Robert C. Martin compiled these principles in the 1990s. These principles provide us with ways to move from tightly coupled code and little encapsulation to the desired results of loosely coupled and encapsulated real needs of a business properly. SOLID is an acronym of the following.

### S: Single Responsibility Principle (SRP) 

"Every software module should have only one reason to change".
* [Bad](SRP_Bad.cs)
* [Good](SRP_Good.cs)

### O: Open closed Principle (OCP)

"A software module/class is open for extension and closed for modification".
* [Bad](OCP_Bad.cs)
* [Good](OCP_Good.cs)

### L: Liskov substitution Principle (LSP)

"you should be able to use any derived class instead of a parent class and have it behave in the same manner without modification"
* [Bad](LSP_Bad.cs)
* [Good](LSP_Good.cs)

### I: Interface Segregation Principle (ISP)

"that clients should not be forced to implement interfaces they don't use. Instead of one fat interface, many small interfaces are preferred based on groups of methods, each one serving one submodule."
* [Bad](ISP_Bad.cs)
* [Good](ISP_Good.cs)

### D: Dependency Inversion Principle (DIP)

"high-level modules/classes should not depend on low-level modules/classes. Both should depend upon abstractions. Secondly, abstractions should not depend upon details. Details should depend upon abstractions."
* [Bad](DIP_Bad.cs)
* [Good](DIP_Good.cs)

## C# vs VB.NET keywords

[see here](https://sites.harding.edu/fmccown/vbnet_csharp_comparison.html)
