using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrammarTest
{
    internal class IteratorDemo
    {
        public IEnumerable<int> GetNumbers(int n)
        {
            for (int i = 0; i < n; i++)
            {
                yield return i;
            }
        }
    }

    public class NumberEnumerable : IEnumerable
    {
        private readonly int _count;
        
        public NumberEnumerable(int count)
        {
            _count = count;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new NumberEnumerator(_count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class NumberEnumerator : IEnumerator<int>
    {
        private readonly int _count;
        private int _current;
        private int _position = -1;

        public NumberEnumerator(int count)
        {
            _count= count;
            _current = -1;
        }

        public int Current => _current;

        object IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
           if( ++_position >= _count)
            {
                return false;
            }
           _current = _position;
            return true;
        }

        public void Reset()
        {
            _position = -1;
            _current = -1;
        }
    }

}
