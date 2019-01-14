# Triangle Classificator
Thid repository houses the sources for Demo Triangle Classificator App. This App has been written for following requirements:

```
Write a program that will determine the type of a triangle. It should take the lengths of the triangle's three
sides as input, and return whether the triangle is equilateral, isosceles or scalene.
```

## Getting the demo sources
The easiest way to get the demo sources is by cloning the demo sources repository with git, using the following instructions.
```
git clone https://github.com/AlexanderKapelyukhovskiy/triangle-classificator.git
```


## Build and run the sample with Docker
You can build and run the demo app in Docker using the following commands. The instructions assume that you are in the root of the repository.
```
docker build -t triangle-classificator .
docker run --rm triangle-classificator 5 4 3

```