using System;


public class UserData
{
    private static UserData current;
    public static UserData Current => current;
    public static void New() => current = new UserData();
    public int MoveCounter { get; set; }
    public string UserName { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateFinish { get; set; }
    public int[] RealValues { get; set; } = new int[5];
    public int RealSquareWeight() => RealValues[0];
    public int RealTriangleWeight() => RealValues[1];
    public int RealCircleWeight() => RealValues[2];
    public int RealStarWeight() => RealValues[3];
    public int RealPentagonWeight() => RealValues[4];
    public int[] InputValues() => new int[] { InputSquareWeight, InputTriangleWeight, InputCircleWeight, InputStarWeight, InputPentagonWeight };
    public int InputSquareWeight { get; set; }
    public int InputTriangleWeight { get; set; }
    public int InputCircleWeight { get; set; }
    public int InputStarWeight { get; set; }
    public int InputPentagonWeight { get; set; }
    public Values JsonValues { get; set; } 
}
