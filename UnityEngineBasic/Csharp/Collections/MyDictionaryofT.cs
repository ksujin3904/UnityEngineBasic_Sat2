using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class MyDictionary<TKey, TValue>
    {
        // 해시테이블의 사이즈 설정
        private const int DEFAULT_SIZE = 100;
        private TValue[] _values = new TValue[DEFAULT_SIZE];

        public TValue this[TKey key]
        {
            get => _values[Hash(key)];
            set => _values[Hash(key)] = value;
        }

        public void Add(TKey key, TValue value)
        {
            _values[Hash(key)]=value;
        }

        public void Remove(TKey key)
        {
            _values[Hash(key)] = default(TValue);
        }

        public bool TryGetVaule(TKey key, out TValue value)
        // out keyword: 함수가 반환될때 추가적으로 값을 더 반환할 때 사용하는 키워드
        {
            bool success = false;
            value = default(TValue);
            // try-catch문: 예외잡기를 시도하는 구문. 예외가 던져질 때 그 예외에 대해서 내가 직접 핸들링 할 때 사용
            try
            {
                value = _values[Hash(key)];
                success = true;
            }
            catch(Exception e) // 인자 e를 받음
            {
                // key값이 유효하지 않을 때
                //throw e;
                Console.WriteLine($"MyDictionary<{typeof(TKey).Name},{typeof(TValue).Name}>: 유효하지 않은 key 값, {e.Message}");
            }
            //finally: 예외를 잡든 안잡든 마지막에 실행할 내용
            //finally(생략)
            //{
            //
            //}
            return success;
        }

        private int Hash(TKey key)
        {
            string tmpString = key.ToString();
            int tmpHash = 0;

            for(int i=0; i< tmpString.Length; i++)
            {
                tmpHash += tmpString[i]; 
                // tmpHash = tmpHash + tmpString[i]
                // 문자열을 배열취급하면 문자를 모두 순회
            }

            tmpHash %= DEFAULT_SIZE; //tmpHash = tmpHash % DEFAULT_SIZE
            return tmpHash;
        }
    }
}
