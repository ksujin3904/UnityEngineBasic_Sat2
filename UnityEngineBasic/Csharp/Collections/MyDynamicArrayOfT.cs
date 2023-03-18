using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{


    internal class MyDynamicArray<T> : IEnumerable<T>
    {
        // const 키워드: 상수 키워드, const 키워드가 붙은 변수는 초기화만 가능하며, 상수처럼 사용 됨.
        private const int DEFAULT_SIZE = 1;
        private T[] _data = new T[DEFAULT_SIZE];
        private int _count;

        public int Count
        {
            set
            {
                _count = value;

            }
            get
            {
                return _count; // 값을 가져올 수 있음
            }
        }
      


        public void SetCount(int value)
        {
            Count = value;
            _data = new T[Count];
        }


        public int GetLength()
        {
            return _data.Length;
        }

        public int GetCount()
        {
            return Count;
        }

        public int Capacity
        {
            get
            {
                return _data.Length;
            }
        }
        
        public T this[int index]
        {
            get
            {
                return _data[index];
            }
            set
            {
                _data[index] = value;
            }
        }

        // 삽입 알고리즘
        // 일반적인 경우 O(1)
        public void Add(T item)
        {
            // 배열의 여유 공간이 부족한 경우 -> 더 큰 크기의 배열을 만들고 기존 데이터 복제 후 기존 배열을 삭제
            // (현재 데이터 갯수의 10의 승수 + 1 사이즈 만큼 더 큰 배열을 생성)
            if(_data.Length <= Count)
            {
                T[] tmp = new T[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];
                // 기존 데이터 복제

                for(int i = 0; i < Count; i++)
                {
                    tmp[i] = _data[i];
                }

                // 새 배열로 변경 (기존 배열을 날림)
                _data = tmp;
            }
            _data[Count] = item;
            Count++;
        }

        // 탐색 알고리즘
        // O(N)
        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Comparer<T>.Default.Compare(_data[i],item)==0)
                    return true;
            }

            return false;

        }

        public int FindIndex(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Comparer<T>.Default.Compare(_data[i], item) == 0)
                    return i;
            }

            return -1;
        }

        // 만약 오브젝트타입의 배열을 찾고 싶으면...
        public int FindIndex(Predicate<object> match) //대리자: 파라미터 n개를 받고 bool 값을 반환하는 함수를 등록할 수 있는 함수
        {
            for (int i = 0; i < Count; i++)
            {
                if (match.Invoke(_data[i])) //invoke: 해당 대리자에 등록된 함수(들)를 모두 호출하고 마지막 호출 된 함수가 반환한 bool 값으로 조건 체크
                    return i;
            }

            return -1;
        }


            // 삭제 알고리즘
            // O(N)
            public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Count) //입력 된 index의 크기가 0 이하 count 이상인경우
                return false;

            for (int i = index; i < Count - 1; i++)
            {
                _data[i] = _data[i + 1];
            }
            Count--;
            _data[Count] = default(T);
            return true;
        }

        public bool Remove(T item)
        {
            return RemoveAt(FindIndex(item));
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
            public T Current => _current;
            object IEnumerator.Current => _current;

            private T? _current;
            private int _currentIndex;
            private MyDynamicArray<T> _outer;

            // Inner struct/class 에서 outer class의 멤버에 접근하기 위해서는 참조가 필요하기 때문에 생성자에서 넘겨받음...
            public Enumerator(MyDynamicArray<T> outer)
            {
                _outer = outer;
                _current = default(T);
                _currentIndex = -1;

            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if(_currentIndex + 1 >= _outer.Count) //배열의 크기보다 더 클 경우
                    return false;

                _currentIndex++;
                _current = _outer._data[_currentIndex]; // outer의 private 멤버는 inner 에서 접근 가능...
                // _outer를 통해서 _data에 접근...
                return true;
            }

            public void Reset()
            {
                _current = default(T);
                _currentIndex = -1;
            }
        }
    }
}
