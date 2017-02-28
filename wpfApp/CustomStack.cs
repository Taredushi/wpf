using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfApp
{
    class CustomStack
    {
        private Stack<string> _stack;

        public CustomStack()
        {
            _stack = new Stack<string>();
        }

        public void Push(string text)
        {
            _stack.Push(text);
        }

        public string Pop()
        {
            return _stack.Pop();
        }

        public string Top()
        {
            return _stack.Peek();
        }

        public bool Empty()
        {
            return !(_stack.Count > 0);
        }
    }
}
