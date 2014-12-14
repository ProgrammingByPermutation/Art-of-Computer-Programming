using System;
using System.Collections.Generic;
using System.Linq;

namespace Fundamental_Algorithms.Basic_Concepts
{
    public class Permutations
    {
        /// <summary>
        /// Multiplies a permutation in cycle form.
        /// </summary>
        /// <remarks>
        /// Expected form (abc)(de)(fg).
        /// </remarks>
        /// <param name="cycleForm">A series of permutations to multiply in cycle form.</param>
        public static string Multiply(string cycleForm) {
            // Sanity check
            if (string.IsNullOrWhiteSpace(cycleForm)) {
                return null;
            }

            // Convert to a format we can manipulate
            char[] cycleArray = cycleForm.ToCharArray();

            // A1. Tag all left parenthesis, and replace each right parenthesis
            // by a tagged copy of the input symbol that follows its matching
            // left parenthesis 
            bool foundOpenParen = false;
            char afterOpen = default(char);
            bool[] taggedEntries = new bool[cycleArray.Length];
            for (int i = 0; i < cycleArray.Length; i++) {
                char currChar = cycleArray[i];
                if (foundOpenParen) {
                    afterOpen = currChar;
                }

                foundOpenParen = currChar == '(';
                taggedEntries[i] = foundOpenParen;
                if (currChar == ')') {
                    if (afterOpen == default(char)) {
                        throw new FormatException("Cycle is incorrectly formatted! Found " +
                                                  "close parenthesis with no matching open.");
                    }

                    cycleArray[i] = afterOpen;
                    taggedEntries[i] = true;
                }
            }

            // Declare the variables we will use A2 -> A6
            List<char> output = new List<char>();
            char START = default(char), CURRENT = default(char);
            bool doA2 = true, doA3 = true;

            // A2. (If all elements are tagged, the algorithm terminates.) 
            while (!taggedEntries.Aggregate(true, (b, b1) => b && b1)) {
                bool scanningFormula = true;
                while (scanningFormula) {
                    for (int i = 0; i < cycleArray.Length; i++) {
                        // A2. Searching from left to right, find the first untagged element of the input.
                        // Set START equal to it; output a left parenthesis; output the element; and tag it.
                        if (doA2) {
                            if (taggedEntries[i]) {
                                continue;
                            }

                            START = cycleArray[i];
                            output.AddRange(new[] {'(', START});
                            taggedEntries[i] = true;
                            doA2 = false;
                            continue;
                        }

                        // A3. Set CURRENT equal to the next element of the formula.
                        if (doA3) {
                            CURRENT = cycleArray[i];
                            doA3 = false;
                            continue;
                        }

                        // A4. Proceed to the right until either reaching the end of the formula, or finding an 
                        // element equal to CURRENT; in the latter case, tag it and go back to step A3.
                        if (cycleArray[i] == CURRENT) {
                            taggedEntries[i] = true;
                            doA3 = true;
                        }
                    }

                    // A5. If CURRENT != START, output CURRENT and go back to step A4 starting again
                    // at the left of the formula (thereby continuing the development of the cycle
                    // in the output).
                    if (CURRENT != START) {
                        output.Add(CURRENT);
                        doA2 = false;
                        doA3 = false;
                    }
                    else {
                        output.Add(')');
                        doA2 = true;
                        doA3 = true;
                        scanningFormula = false;
                    }
                }
            }

            return new string(output.ToArray());
        }
    }
}