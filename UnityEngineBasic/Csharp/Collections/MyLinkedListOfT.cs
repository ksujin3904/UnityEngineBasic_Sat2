using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class MyLinkedListNode<T> : IEnumerable<T> // 순회 가능하게
    {
        public T Value;
        public MyLinkedListNode<T> Prev;
        public MyLinkedListNode<T> Next;

        public MyLinkedListNode(T value)
        {
            Value = value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        public struct Enumerator : IEnumerator<T>
        {

            public T Current => _current.Value;
            object IEnumerator.Current => _current.Value;
            private MyLinkedListNode<T> _current;
            private MyLinkedList<T> _outer;

            public Enumerator(MyLinkedList<T> outer)
            {
                _outer = outer;
                _current = null;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_current == _outer.Last)
                    return false;
                if (_current == null)
                    _current = _outer.First;
                else
                    _current = _current.Next;

                return true;
            }

            public void Reset()
            {
                _current = null;
            }
        }
    }


    internal class MyLinkedList<T>
    {
        public MyLinkedListNode<T> First => _first;
        public MyLinkedListNode<T> Last => _last;
        private MyLinkedListNode<T> _first, _last, _tmp;

        #region 삽입 알고리즘

        public void AddFirst(T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            if(_first != null)
            {
                _tmp.Next = _first;
                _first.Prev = _tmp;
            }
            else
            {
                _last = _tmp;
            }

            _first = _tmp;
        }

        public void AddLast(T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            if(_last != null)
            {
                _tmp.Prev = _last;
                _last.Next = _tmp;
            }
            else
            {
                _first = _tmp;
            }

            _last = _tmp;
        }

        public void AddBefor(MyLinkedListNode<T> node, T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            // 넣고자 하는 Node 앞에 다른 노드가 이미 존재한 경우
            if(node != _first)
            {
                node.Prev.Next = _tmp;
                _tmp.Prev = node.Prev;
            }

            node.Prev = _tmp;
            _tmp.Next = node;
        }

        public void AddAfter (MyLinkedListNode<T> node, T value)
        {
            _tmp = new MyLinkedListNode<T>(value);

            if (node != _last)
            {
                node.Next.Prev = _tmp;
                _tmp.Next = node.Next;
            }

            node.Next = _tmp;
            _tmp.Prev = node;
        }
        #endregion

        #region 탐색알고리즘

        public MyLinkedListNode<T> FindFirst(T value)
        {
            _tmp = _first;
            while(_tmp != null)
            {
                if(Comparer<T>.Default.Compare(_tmp.Value, value)==0)
                    return _tmp;

                _tmp = _tmp.Next;

            }
            return null;
        }

        public MyLinkedListNode<T> FindLast(T value)
        {
            _tmp = _last;
            while (_tmp != null)
            {
                if (Comparer<T>.Default.Compare(_tmp.Value, value) == 0)
                    return _tmp;

                _tmp = _tmp.Prev;

            }
            return null;
        }
        #endregion

        #region 삭제알고리즘
        public bool Remove(MyLinkedListNode<T> node)
        {
            if (node == null)
                return false;

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            node = node.Next = node.Prev = null;
            return true;
        }

        public bool Remove(T value)
        {
            return Remove(FindFirst(value));
        }

        #endregion

    }
}
