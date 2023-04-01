using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class SortAlgorithms
    {
        public static int OpCount;

        #region Bubble Sort
        /// <summary>
        /// 바로 뒤의 요소가 현재 요소보다 작으면 스왑
        /// Outer for loop 가 한 번 돌 때마다 가장 큰 수의 위치가 고정
        /// O(N^2)
        /// stable한 함수
        /// stable: 동일한 수가 있을 때 정렬 후 그 위치가 보장
        /// </summary>
        /// <param name="arr"></param>
        public static void BubbleSort(int[] arr)
        {
            OpCount = 0;
            for (int i = 0; i < arr.Length-1; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j+1]); // 메모리 주소에 직접 접근
                    }
                }
            }
        }

        #endregion

        #region Select Sort
        /// <summary>
        /// 선택 정렬
        /// 현재의 바로 뒤부터 끝까지 중에서 가장 작은 수를 찾아서 스왑
        /// Outer for loop가 한번 돌 때마다 가장 작은 수의 위치가 하나씩 고정
        /// O(N^2)
        /// unstable한 함수
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSrot(int[] arr)
        {
            OpCount = 0;
            int minIndex;
            for (int i = 0; i < arr.Length; i++)
            {
                minIndex = i;
                OpCount++;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                        OpCount++;
                    }
                }
                Swap(ref arr[i], ref arr[minIndex]);
            }
        }

        #endregion

        #region Insertion Sort
        /// <summary>
        /// 삽입 정렬
        /// 현재 위치보다 이전 위치들 중 더 큰 값이 있으면 해당 값을 그 다음 인덱스에 덮어쓰고,
        /// 위 과정이 끝나면 마지막으로 찾았떤 큰값 인덱스 위치에 현재 탐색하던 위치의 값(key)를 덮어씀
        /// O(N^2)
        /// Stable 한 함수
        /// </summary>
        /// <param name="arr"></param>
        public static void InsertionSort(int[] arr)
        {
            OpCount = 0;
            int key;
            int j;
            for (int i = 0; i < arr.Length; i++)
            {
                key = arr[i];
                j = i - 1;
                OpCount += 2;
                // key 값보다 큰 값이 있을 경우 해당 값을 바로 뒤에 덮어 씀
                while (j >= 0 && arr[j]>key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                    OpCount += 2;
                }
                arr[j + 1] = key; // 마지막으로 찾은 key값 보다 큰 값의 인덱스에 key 값 대입 
                OpCount += 1;
            }
        }

        #endregion
        
        #region MergeSort
        /// <summary>
        /// 병합 정렬
        /// 요소를 최소단위까지 나눈 후에 차례대로 병합을 하며 정렬 (Divide & Conquer)
        /// O(NlogN)
        /// stable
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        public static void MergeSort(int[]arr, int start, int end)
        {
            while(start < end)
            {
                int mid = end + (start - end) / 2 - 1;
                // (start + end) / 2와 결과값은 같으나 overflow를 방지하기 위해 사용
                //                                  (4byte를 초과하는 연산을 통한 오류)
                MergeSort(arr, start, mid);
                MergeSort(arr, mid + 1, end);

                Merge(arr, start, mid, end);
            }
        }
        
        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] tmp = new int[end - start + 1];
            for (int i = 0; i <= end-start; i++)
                tmp[i] = arr[i+start];

            int part1 = start;
            int part2 = mid + 1;
            int index = start;
            while (part1 <= mid || part2 <= end)
            {
                //part1이 part2 이하라면 part1을 채택
                if (tmp[part1-start] <= tmp[part2] - start)
                {
                    arr[index++] = tmp[part1++ - start]; // index++; part++; 생략을 위한 후위연산
                }
                else
                {
                    arr[index++] = tmp[part2++ - start];
                }
            }

            // 남은 part1을 뒤에 쭉 이어붙여줌
            // 남은 part2는 이미 정복된 상태기 때문에 그대로 쓰면 됨
            for (int i = 0; i <= mid - part1; i++)
            {
                arr[index + i] = tmp[part1 - start + i];
            }
        }

        #endregion

        #region Quick Sort
        /// <summary>
        /// Big-0 로테이션: O(N^2) (Pivot이 끝에 몰리는 최악의 경우)
        /// 평균(NlogN)
        /// 현존하는 정렬알고리즘 중 가장 빠르다.
        /// => 정복할 떄마다 Pivot에 해당하는 인덱스 위치가 고정되어 정복할 때 고려해야하는 경우의 수가 계속 줄어듦.
        /// Pivot의 위치가 평균적으로 끝지점에 몰리지 않기때문에 이분할을 하는 경우처럼 LogN이 된다.
        /// N^2이 되는 경우를 막기 위해서 Pivot 설정하는 특별한 알고리즘을 추가로 적용할 수도 있다.
        /// Unstable
        /// 
        /// => 동일 숫자의 순서가 보장되어야 하면 Merge, 아니라면 Quick 사용
        /// </summary>
        /// <param name="arr"></param>

        public static void QuickSort(int[] arr)
        {
            QuickSort(arr,0,arr.Length-1);
        }

        public static void QuickSort(int[] arr,int start, int end)
        {
            if (start < end)
            {
                int p = Partition(arr,start,end); // pivot의 인덱스
                QuickSort(arr, start, p - 1);
                QuickSort(arr, p+1, end);
            }
        }

        private static int Partition(int[]arr, int start, int end)
        {
            int pivot = arr[end + (start - end) / 2];

            while (true)
            {
                while (arr[start] < pivot) start++;
                while (arr[end] > pivot) end--;

                if(start < end)
                {
                    Swap(ref arr[start], ref arr[end]);
                }
                else
                {
                    return end; //return pivot index
                }
            }
        }


        #endregion

        private static void Swap(ref int a, ref int b)
        {
            // 앞 뒤 변경해주는 함수
            // ref 키워드: 인자로 참조를 받고싶은 경우 사용
            // out 키워드: 함수 반환 시 해당 파라미터 값을 반환하는 경우 사용
            int tmp = a;
            a = b;
            b = tmp;
            OpCount += 3;
        }

    }
}
