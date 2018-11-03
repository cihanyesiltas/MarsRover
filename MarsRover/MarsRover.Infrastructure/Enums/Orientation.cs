using System.ComponentModel;

namespace MarsRover.Infrastructure.Enums
{
    public enum Orientation
    {
        None = 0,

        [Description("N")]
        North = 1,

        [Description("E")]
        East = 2,

        [Description("S")]
        South = 3,

        [Description("W")]
        West = 4
    }
}
