using Collections;
using System.Collections;
using System.Collections.Generic;

// 자료구조
// 자료구조에는 공통적으로 구현하는 요소들은
// 1. 탐색, 삽입, 삭제 알고리즘
// 2. 현재자료개수

#region Dynamic Array
MyDynamicArray myDynamicArray = new MyDynamicArray();
myDynamicArray.Add(5);
myDynamicArray.Add(1);
myDynamicArray.Add(2);
myDynamicArray.Add(3);
myDynamicArray.Add(5);
//myDynamicArray[0] = ""; // 5에 대한 데이터를 가지는 Object가 힙 영역에 새로 할당

Console.WriteLine();
for (int i = 0; i < myDynamicArray.Count; i++)
{
    Console.Write($"{myDynamicArray[i]},");
}

myDynamicArray.Remove(5); // int타입을 object 파라미터에 인자로 넘겨주면 object 타입으로 암시적 캐스팅이 일어남
                          // 즉, 정수 5에 대한 데이터를 가지는 Object가 힙 영역에 새로 할당되고 이 새로 할당된 객체가 동적 배열에 있으면 
                          // 지워달라는 함수 호출이 됨
                          // 따라서 기존의 5에 대한 객체를 지우는게 아니라 인자를 넘겨줄 때 생긴 객체를 지우는 함수가 됨

// Remove 하고 싶으면
object int5 = 5;
myDynamicArray.Add(int5);
myDynamicArray.Remove(int5);

myDynamicArray.RemoveAt(myDynamicArray.FindIndex(x => (int)x == 5));


// System.Object타입, C#의 모든 타입의 기반 타입
// 이 타입에 다른 객체를 참조시킬 때, 힙 영역에 System.Object 타입의 객체가 할당 됨
// object(모든 타입은 object타입으로 변환 가능)
// System.Object 객체를 정의할 때 쓰는 키워드 -> 힙 영역에 System.Object 타입의 객체가 할당 됨ㅡ 힙 영역 X

int a = 5;
object obj; // System.Object 타입 참조 변수
obj = a; // a를 System.Object 타입으로 변환한 객체를 힙영역에 할당하고 참조를 반환함(Boxing)
obj = new System.Object(); // < 생략되어 있음
obj = myDynamicArray;
obj = a;
Console.WriteLine();
Console.WriteLine(obj);


 //MyDynamicArray da2 = (MyDynamicArray)obj; // Object 타입을 하위 타입으로 변환 (Unboxing)
                                           // => 단점: 속도 느림 (박싱이 더 느림) , 속도보다 확장성이 중요할 때 사용
#endregion

#region ArrayList: C#에서 기본제공하는 동적 배열 
// C# System.Collection의 동적배열
ArrayList arrayList = new ArrayList();
arrayList.Add(3);
arrayList.Add('d');
arrayList.Add("안녕");
#endregion

#region: Generic DynamicArray

MyDynamicArray<double> doubleArray = new MyDynamicArray<double>();
doubleArray.Add(3.0);
doubleArray.Add(5.0);
doubleArray.Add(2.0);
doubleArray.Add(4.0);
doubleArray.Remove(5.2);

Console.WriteLine();
Console.WriteLine("Start enuemrating Generic MyDynamic Array");
// 자료구조를 읽기 용도로
IEnumerator<double> enumerator = doubleArray.GetEnumerator();
while (enumerator.MoveNext())
{
    Console.Write($"{enumerator.Current},");
}
enumerator.Dispose();
enumerator.Reset();

// foreach문
// foreach (순회할 자료형 현재값변수 in Ienumerable) -> current 반환
Console.WriteLine();
Console.WriteLine("Start enuemrating Generic MyDynamic Array with foreach loop");
foreach (double item in doubleArray)
{
    Console.Write($"{item},");
}

//C# System.Collections.Generic의 동적 배열
List<double> doubleList = new List<double>();
doubleList.Add(2.1);
doubleList.RemoveAt(0);
doubleList.FindIndex(x => x == 3.0);
Console.WriteLine("Start List MyDynamic Array with foreach loop");
foreach (double item in doubleList)
{
    Console.Write($"{item},");
}

#endregion

#region Generic Linkedlist
// 내가 만든 Generic LinkedList
//------------------------------------------------------
MyLinkedList<int> intLinkedList = new MyLinkedList<int>();
intLinkedList.AddLast(2);
intLinkedList.AddLast(3);
intLinkedList.AddFirst(5);
MyLinkedList<int> dummy = intLinkedList.FindLast(5);
intLinkedList.AddAfter(dummy, 6);

foreach (MyLinkedList<int> node in intLinkedList)
{
    Console.WriteLine($"내 연결리스트 순회중...{value}");
}

// C# System.colections.Generic.LinkedList
// ------------------------------------------------------
LinkedList<float> floatLinkedList = new LinkedList<float>();
floatLinkedList.AddFirst(3);
LinkedListNode<float>?dummy2 = floatLinkedList.FindLast(3);
floatLinkedList.AddAfter(dummy2, 5);


#endregion

#region Generic Dictionary
// 내가 만든 Generic Dictionary
// ------------------------------------------------------
MyDictionary<string, int> scores = new MyDictionary<string, int>();
scores.Add("철수", 80);
scores.Add("영희", 70);
scores.Remove("영희");
Console.WriteLine($"철수의 점수는 { scores["철수"]}점 이다.");

// C#에서 제공하는 Dictionary: System.Collections.Generic.Dictionary
// ------------------------------------------------------
Dictionary<string, int> grades = new Dictionary<string, int>();
grades.Add("철수", 'A');
grades.Add("영희", 'C');
grades.Remove("영희");

foreach (string key in grades.Keys)
{
    Console.WriteLine($"학급생{key}");
}

foreach (char value in grades.Values)
{
    Console.WriteLine($"등급표{value}");
}

#endregion

