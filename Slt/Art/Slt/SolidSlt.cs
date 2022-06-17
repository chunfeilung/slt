using Slt.Ascii;
using Slt.Util;

namespace Slt.Art.Slt;

public class SolidSlt : AbstractSlt
{
    public SolidSlt(bool useColors = false) : base(
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.DrivingCar.txt"),
            useColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.DrivingCar.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.TrailerCar.txt"),
            useColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.TrailerCar.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.CollectorRoof.txt"),
            useColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.CollectorRoof.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.FullLengthRoof.txt"),
            useColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.FullLengthRoof.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Connection.txt"),
            useColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.Connection.txt") : ""
        )
    )
    {
    }
}
