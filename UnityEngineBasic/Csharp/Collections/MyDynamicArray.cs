﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{


    internal class MyDynamicArray
    {
        // const 키워드: 상수 키워드, const 키워드가 붙은 변수는 초기화만 가능하며, 상수처럼 사용 됨.
        private const int DEFAULT_SIZE = 1;
        private object[] _data = new object[DEFAULT_SIZE];
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
            _data = new object[Count];
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
        
        public object this[int index]
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
        public void Add(object item)
        {
            // 배열의 여유 공간이 부족한 경우 -> 더 큰 크기의 배열을 만들고 기존 데이터 복제 후 기존 배열을 삭제
            // (현재 데이터 갯수의 10의 승수 + 1 사이즈 만큼 더 큰 배열을 생성)
            if(_data.Length <= Count)
            {
                object[] tmp = new object[_data.Length + (int)Math.Ceiling(Math.Log10(_data.Length)) + DEFAULT_SIZE];
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
        public bool Contains(object item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i] == item)
                    return true;
            }

            return false;

        }

        public int FindIndex(object item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_data[i] == item)
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
            _data[Count] = default(int);
            return true;
        }

        public bool Remove(object item)
        {
            return RemoveAt(FindIndex(item));
        }

    }
}
