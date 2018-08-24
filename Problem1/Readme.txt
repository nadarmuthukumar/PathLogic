This project is created in a very simple structure as follows:

Create 3 different projects under one solution.
1. Console Project
2. Common Library for Business Logic
3. Test Project for unit testing

If build fails just check if business logic project is been referred by console and test project. 

Ideally this project should be built using some path finding algorithm like Dijkstra or A*.
I'm writing my own logic here for this requirement.
Since this code is just for evaluation purpose, I'm not putting comments on all the methods.

Point 8 test case will fail because that method will go under infinite loop since we also have a bi directional path in the logic.  

Do call me for further clarification.