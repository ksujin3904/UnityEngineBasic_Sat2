
int diceValue = 6;

switch (diceValue)
{
	case 1:
		Console.WriteLine("값은 1");
		break;
	case 2:
	case 3:
		Console.WriteLine("값은 2 또는 3");
		break;
	case 4:
		Console.WriteLine("값은 4");
		break;
	case 5:
		Console.WriteLine("값은 5");
		break;
	case 6:
		Console.WriteLine("값은 6");
        break;
	default:
		throw new Exception($"유효하지 않은 값 : {diceValue}");

}

string characterTypeName = "가렌";

switch (characterTypeName)
{
	case "가렌":
		Console.WriteLine("내 검과 심장은 데마시아의 것이다.");
		break;
	case "나서스":
		Console.WriteLine("내 인내심을 시험하려 들지 마시오.");
		break;
	case "다리우스":
		Console.WriteLine("오직 나만이 승리로 이끌 수 있다.");
		break;
	case "바루스":
		Console.WriteLine("죄 지은 자, 고통받을지어다.");
        break;
	case "제드":
		Console.WriteLine("날 부정하지마");
        break;
	default:
		break;
}

CharacterTypes characterType = CharacterTypes.나서스;

switch (characterType)
{
	case CharacterTypes.가렌:
        Console.WriteLine("내 검과 심장은 데마시아의 것이다.");
        break;
	case CharacterTypes.나서스:
        Console.WriteLine("내 인내심을 시험하려 들지 마시오.");
		break;
	case CharacterTypes.다리우스:
        Console.WriteLine("오직 나만이 승리로 이끌 수 있다.");
		        break;
	case CharacterTypes.바루스:
        Console.WriteLine("죄 지은 자, 고통받을지어다.");
		break;
	case CharacterTypes.제드:
        Console.WriteLine("날 부정하지마");
		break;
	default:
		break;
}