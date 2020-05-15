using System;
using System.Collections.Generic;
using System.Text;

namespace Trie
{
    // Memory Distribution
    public class Trie2
    {
        public Trie2[] kids = new Trie2[26];
        public bool isWord = false;
        /** Initialize your data structure here. */
        public Trie2()
        {

        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var cur = this;
            foreach (var c in word)
            {
                if (cur.kids[c - 'a'] == null)
                    cur.kids[c - 'a'] = new Trie2();
                cur = cur.kids[c - 'a'];
            }
            cur.isWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var cur = this;
            foreach (var c in word)
            {
                if (cur.kids[c - 'a'] == null)
                    return false;
                cur = cur.kids[c - 'a'];
            }
            return cur.isWord;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var cur = this;
            foreach (var c in prefix)
            {
                if (cur.kids[c - 'a'] == null)
                    return false;
                cur = cur.kids[c - 'a'];
            }
            return true;
        }
    }
}
