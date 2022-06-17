using Slt.Ascii;
using Slt.Util;

namespace Slt.Art.Slt;

public class OutlineSlt : AbstractSlt
{
    public OutlineSlt() : base(
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Outline.DrivingCar.txt")
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Outline.TrailerCar.txt")
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Outline.CollectorRoof.txt")
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Outline.FullLengthRoof.txt")
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Outline.Connection.txt")
        )
    )
    {
    }
}
