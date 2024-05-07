using System;

public class UserData
{
    private static UserData current;
    public static UserData Current => current;
    public static void New() => current = new UserData();
    public int Counter { get; set; }
    public int Attemps { get; set; } = 0;
    public string UserName { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateFinish { get; set; }
    public int RealSquareWeight { get; set; }
    public int RealTriangleWeight { get; set; }
    public int RealCircleWeight { get; set; }
    public int RealStarWeight { get; set; }
    public int RealPentagonWeight { get; set; }
    public int InputSquareWeight { get; set; }
    public int InputTriangleWeight { get; set; }
    public int InputCircleWeight { get; set; }
    public int InputStarWeight { get; set; }
    public int InputPentagonWeight { get; set; }
}
