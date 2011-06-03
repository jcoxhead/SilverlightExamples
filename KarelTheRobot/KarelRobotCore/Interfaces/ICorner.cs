namespace KarelRobotCore.Interfaces
{
    public interface ICorner
    {
        int Avenue { get; }
        int Street { get; }
        int NumerOfBeepers { get; set; }
        bool HasNorthWall { get; set; }
        bool HasEastWall { get; set; }      
        int GetHashCode();
    }
}