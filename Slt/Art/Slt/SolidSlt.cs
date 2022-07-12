using Slt.Art.Etc;
using Slt.Ascii;
using Slt.Cli;
using Slt.Util;

namespace Slt.Art.Slt;

public class SolidSlt : AbstractSlt
{
    public SolidSlt(AnimationConfiguration config) : base(
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.DrivingCar.txt"),
            config.UseColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.DrivingCar.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.TrailerCar.txt"),
            config.UseColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.TrailerCar.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.CollectorRoof.txt"),
            config.UseColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.CollectorRoof.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.FullLengthRoof.txt"),
            config.UseColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.FullLengthRoof.txt") : ""
        ),
        new Figure(
            EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Connection.txt"),
            config.UseColors ? EmbeddedResource.ReadAllText("Slt.Art.Slt.Solid.Colors.Connection.txt") : ""
        ),
        config.ShowSparks ? new Sparks(config.UseColors) : null
    )
    {
    }
}
