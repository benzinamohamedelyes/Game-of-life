# Game of life [![Build Status](https://travis-ci.com/benzinamohamedelyes/Game-of-life.svg?branch=main)](https://travis-ci.com/benzinamohamedelyes/Game-of-life)
This Kata is about calculating the next generation of Conway’s game of life, given any starting position. See http://en.wikipedia.org/wiki/Conway%27s_Game_of_Life for background.

You start with a two dimensional grid of cells, where each cell is either alive or dead. In this version of the problem, the grid is finite, and no life can exist off the edges. When calcuating the next generation of the grid, follow these rules:

# Rules
 1. Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
   2. Any live cell with more than three live neighbours dies, as if by overcrowding.
   3. Any live cell with two or three live neighbours lives on to the next generation.
   4. Any dead cell with exactly three live neighbours becomes a live cell.
- the program should accept an arbitrary grid of cells, and will output a similar grid showing the next generation.
 
# Clues
##### Generation 1:
```sh
4 8
........
....*...
...**...
........
```
##### Generation 2:
```sh
4 8
........
...**...
...**...
........
```

# IMPLEMENTATION

## Technical stack
In order to complete this kata, I choose the following stack:
- Language: `C#`
- Framework: `.Net Core`
- Unit test framework: `XUnit`

## Conception

Basically, the program will a .Net Core console application
- Input: The input will consist of an arbitrary number of fields. The first line of each field contains two integers n and m (0 < n,m <= 100) which stands for the number of lines and columns of the field respectively. The next n lines contains exactly m characters and represent the field. Each dead cell is represented by an “.” character (without the quotes) and each alive cell is represented by an “*” character (also without the quotes). 
# RUN

**Build the Project**
```shell
donet build
```

**Launch the program**
```shell
donet run 
```
