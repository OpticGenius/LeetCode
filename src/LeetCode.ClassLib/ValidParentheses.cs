using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*

Given a string containing just the characters '(', ')', '{', '}', '[' and ']', 
determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Note that an empty string is also considered valid.

Example 1:

Input: "()"
Output: true
Example 2:

Input: "()[]{}"
Output: true
Example 3:

Input: "(]"
Output: false
Example 4:

Input: "([)]"
Output: false
Example 5:

Input: "{[]}"
Output: true

 */

namespace LeetCode.ClassLib {
    public class ValidParentheses {
        IDictionary<char, char> map = new Dictionary<char, char> { { '}', '{' },
            { ')', '(' },
            { ']', '[' }
        };

        /// <summary>
        /// Returns whether a string of parentheses is correctly balanced.
        /// Uses stack based approach.
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Boolean indicating if string is balanced</returns>
        public bool IsValid (string s) {
            if (s.Length % 2 != 0) {
                return false;
            } else if (string.IsNullOrEmpty (s)) {
                return true;
            }

            Stack<char> stack = new Stack<char> ();

            foreach (char character in s) {
                if (!map.ContainsKey (character)) {
                    stack.Push (character);
                } else {
                    if (stack.Count == 0) {
                        return false;
                    }

                    char top = stack.Pop ();
                    if (!top.Equals (map[character])) {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }
    }
}