using System;
class GFG {
  static bool solveSuduko(int[,] grid, int row, int col)
  {
    int rowsOrHeight = grid.GetLength(0);
    int colsOrWidth = grid.GetLength(1);

    if (row == rowsOrHeight - 1 && col == colsOrWidth)
      return true;
 
    if (col == colsOrWidth) {
      row++;
      col = 0;
    }
 
    if (grid[row,col] != 0)
      return solveSuduko(grid, row, col + 1);
 
    for (int num = 1; num < 10; num++) {
      if (isSafe(grid, row, col, num)) {
        grid[row,col] = num;

        if (solveSuduko(grid, row, col + 1))
          return true;
      }
      grid[row,col] = 0;
    }
    return false;
  }
 
  static void print(int[,] grid)
  {
    int rowsOrHeight = grid.GetLength(0);
    int colsOrWidth = grid.GetLength(1);

    for (int i = 0; i < rowsOrHeight; i++) {
      for (int j = 0; j < colsOrWidth; j++)
        Console.Write(grid[i,j] + " ");
      Console.WriteLine();
    }
  }
 
  static bool isSafe(int[,] grid, int row, int col,
                     int num)
  {
    int rowsOrHeight = grid.GetLength(0);
    int colsOrWidth = grid.GetLength(1);

    for (int x = 0; x < colsOrWidth; x++)
      if (grid[row,x] == num)
        return false;
 
    for (int x = 0; x < rowsOrHeight; x++)
      if (grid[x,col] == num)
        return false;
 
    int startRow = row - row % 3, startCol
      = col - col % 3;
    for (int i = 0; i < 3; i++)
      for (int j = 0; j < 3; j++)
        if (grid[i + startRow,j + startCol] == num)
          return false;
 
    return true;
  }
 
  static void Main() {
    int[,] grid = { { 3, 0, 6, 5, 0, 8, 4, 0, 0 },
                   { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
                   { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
                   { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                   { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                   { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
                   { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
                   { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                   { 0, 0, 5, 2, 0, 6, 3, 0, 0 } };
 
 
    if (solveSuduko(grid, 0, 0))
      print(grid);
    else
      Console.WriteLine("No Solution exists");
  }
}
