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
            List<char> output = new List<char>();

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

            // A2. Searching from left to right, find the first untagged element of the input.
            // (If all elements are tagged, the algorithm terminates.) 
            char START = default(char), CURRENT = default(char);
            bool startWasSet = false, currentWasSet = false;
            while(!taggedEntries.Aggregate(true, (b, b1) => b && b1)) {
                bool done = false;
                while (!done) {
                    for (int i = 0; i < cycleArray.Length; i++) {
                        // A2. Set START equal to it; output a left parenthesis; output the element; and tag it.
                        if (!startWasSet) {
                            if (taggedEntries[i]) {
                                continue;
                            }

                            START = cycleArray[i];
                            output.AddRange(new[] {'(', START});
                            taggedEntries[i] = true;
                            startWasSet = true;
                            continue;
                        }

                        // A3. Set CURRENT equal to the next element of the formula.
                        if (!currentWasSet) {
                            CURRENT = cycleArray[i];
                            currentWasSet = true;
                            continue;
                        }

                        // A4. Proceed to the right until either reaching the end of the formula, or finding an 
                        // element equal to CURRENT; in the latter case, tag it and go back to step A3.
                        if (cycleArray[i] == CURRENT) {
                            taggedEntries[i] = true;
                            currentWasSet = false;
                        }
                    }

                    // A5. If CURRENT != START, output CURRENT and go back to step A4 starting again
                    // at the left of the formula (thereby continuing the development of the cycle
                    // in the output).
                    if (CURRENT != START) {
                        output.Add(CURRENT);
                        startWasSet = true;
                        currentWasSet = true;
                    }
                    else {
                        output.Add(')');
                        startWasSet = false;
                        currentWasSet = false;
                        done = true;
                    }
                }
            }

            return new string(output.ToArray());
        }
    }
}