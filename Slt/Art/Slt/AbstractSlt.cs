using System.Drawing;
using Slt.Ascii;
using Slt.Cli.Consoles;

namespace Slt.Art.Slt;

public abstract class AbstractSlt : IAnimation
{
    private readonly Figure _result;
    private int _frame;

    protected AbstractSlt(
        Figure drivingCar,
        Figure trailerCar,
        Figure collectorRoof,
        Figure fullLengthRoof,
        Figure connection)
    {
        _result = new Figure()
            .AddAt(drivingCar, new Point(0, 3))
            .AddAt(connection, new Point(120, 5))
            .AddAt(trailerCar, new Point(140, 5))
            .AddAt(collectorRoof, new Point(140, 0))
            .AddAt(connection, new Point(234, 5))
            .AddAt(Mirror.Reflect(trailerCar), new Point(254, 5))
            .AddAt(fullLengthRoof, new Point(254, 3))
            .AddAt(connection, new Point(348, 5))
            .AddAt(Mirror.Reflect(drivingCar), new Point(368, 3));
    }

    public string GetFrame(IConsole console)
    {
        return _result.Crop(
            console.GetSize().Width,
            console.GetSize().Height,
            _frame,
            0
        ).Draw();
    }

    public void SetFrame(int frame)
    {
        _frame = frame;
    }

    public void Advance()
    {
        _frame++;
    }

    public bool HasFinished()
    {
        return _frame > _result.Width;
    }

    public override string ToString()
    {
        return _result.Crop(
            _result.Width,
            _result.Height,
            0,
            0
        ).Draw();
    }
}
