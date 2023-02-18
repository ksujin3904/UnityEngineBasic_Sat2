int[] arrInt = new int[3];
int[] arrInt2 = { 1, 3, 5, 2 };
float[] arrFloat = new float[4] { 1.0f, 2.1f, 3.4f, 2.2f };

// 인덱서 []
// 인덱스 접근하기 위한 연산자
// 일반적인 배열에서 인덱서는
// 해당 배열의 주소 + 인덱스 * 단위자료형 위치의 주소로부터 단위자료형만큼 데이터에 접근

// arrInt[3] = 3; // 범위를 벗어난 인덱스 접근은 예외처리 됨

int index = 0;
while (index<arrFloat.Length)
{
    Console.WriteLine(arrFloat[index]);
    index++;
}

for (int i = 0; i < arrFloat.Length; i++)
{
    Console.WriteLine(arrFloat[index]);
}