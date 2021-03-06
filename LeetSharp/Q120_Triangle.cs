using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Given a triangle, find the minimum path sum from top to bottom. 
// Each step you may move to adjacent numbers on the row below.

// For example, given the following triangle

// [
//      [2],
//     [3,4],
//    [6,5,7],
//   [4,1,8,3]
// ]
// The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).

// Note:
// Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.

namespace LeetSharp
{
    [TestClass]
    public class Q120_Triangle
    {
        public int MinimumTotal(int[][] triangle)
        {
            for (int row = triangle.Length - 2; row >= 0; row--)
            {
                for (int col = 0; col <= row; col++)
                {
                    triangle[row][col] +=
                        Math.Min(triangle[row + 1][col], triangle[row + 1][col + 1]);
                }
            }
            return triangle[0][0];
        }

        public int MinimumTotal2(int[][] triangle)
        {
            return MinimumTotalRec(triangle, 0, 0);
        }

        public int MinimumTotalRec(int[][] triangle, int x, int y)
        {
            if (x == triangle.Length - 1)
                return triangle[x][y];

            return triangle[x][y] +
                Math.Min(MinimumTotalRec(triangle, x + 1, y), MinimumTotalRec(triangle, x + 1, y + 1));
        }

        public string SolveQuestion(string input)
        {
            return MinimumTotal(input.ToIntArrayArray()).ToString();
        }

        [TestMethod]
        public void Q120_Small()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
        [TestMethod]
        public void Q120_Large()
        {
            TestHelper.Run(s => SolveQuestion(s));
        }
    }
}
