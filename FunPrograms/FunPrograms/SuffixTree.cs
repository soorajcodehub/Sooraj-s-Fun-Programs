using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunPrograms
{
    public class SuffixTreeNode
    {
        Dictionary<char, SuffixTreeNode> children;
        SuffixTreeNode suffixLink;

        internal Dictionary<char, SuffixTreeNode> Children
        {
            get { return children; }
            set { children = value; }
        }

        internal SuffixTreeNode SuffixLink
        {
            get { return suffixLink; }
            set { suffixLink = value; }
        }

        internal SuffixTreeNode(SuffixTreeNode suffixLink = null)
        {
            this.children = new Dictionary<char,SuffixTreeNode>();
            this.suffixLink = suffixLink == null ? this : suffixLink;
        }

        internal void AddLink(SuffixTreeNode node, char letterLink)
        {
            this.children.Add(letterLink, node);
        }
    }

    public class SuffixTree
    {
        public SuffixTreeNode ConstructSuffixTreeNode(String input)
        {
            SuffixTreeNode root = new SuffixTreeNode();
            SuffixTreeNode previous = null;
            SuffixTreeNode longest = new SuffixTreeNode();

            root.AddLink(longest, input[0]);
            root.SuffixLink = longest;

            for(int i = 1; i < input.Length; i++)
            {
                SuffixTreeNode current = longest;
                SuffixTreeNode temp = new SuffixTreeNode();

                while(!current.Children.ContainsKey(input[i]))
                {
                    current.AddLink(temp, input[i]);
                    previous = current;
                    current = current.SuffixLink;

                    if (previous != null)
                    {
                        previous.SuffixLink = current;
                    }

                    // at the last end point. 
                    if (current == root)
                    {
                        temp.SuffixLink = root;
                    }
                    else
                    {
                        temp.SuffixLink = current.Children[input[i]];
                    }
                }
            }

            return root;
        }

        public bool isSubstring(String str, SuffixTreeNode root)
        {
            SuffixTreeNode current = root;
            int i = 0;

            while(i < str.Length && current.Children.ContainsKey(str[i]))
            {
                current = current.SuffixLink;
                i++;
            }

            return i == str.Length;
        }
    }
}
