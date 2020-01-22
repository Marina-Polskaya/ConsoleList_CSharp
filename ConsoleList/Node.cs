using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleList
{
    //Узел списка.
    class Node : ListNodes
    {
        Node next = null;
        int key;
        public Node Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
        public int Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }
        public Node(int key_)
        {
            key = key_;
            next = null;
        }
        public Node(int key_, Node next_)
        {
            key = key_;
            next = next_;
        }
    }
}
