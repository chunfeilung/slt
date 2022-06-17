using System.CommandLine;
using Slt.Art.Slt;
using Slt.Ascii;
using Slt.Cli.Consoles;
using IConsole = Slt.Cli.Consoles.IConsole;

namespace Slt.Cli;

public static class SltCommand
{
    public static RootCommand Build()
    {
        var command = new RootCommand(
            "Slt is kind of like sl, but instead of a steam locomotive " +
            "it's an NS Sprinter Light Train (SLT)."
        )
        {
            Name = "slt"
        };

        var lineOption = new Option<bool>(
            "--lines",
            "Output outlines using printable 7-bit ASCII characters"
        );
        lineOption.AddAlias("-l");
        lineOption.SetDefaultValue(true);

        var filledOption = new Option<bool>(
            "--filled",
            "Output filled shapes using printable 7-bit ASCII characters"
        );
        filledOption.AddAlias("-f");

        var colorOption = new Option<bool>(
            "--colored",
            "Output using ANSI colors"
        );
        colorOption.AddAlias("-c");

        var speedOption = new Option<double>(
            "--speed",
            description: "Train speed as ratio of default speed",
            getDefaultValue: () => 1.0
        );
        speedOption.AddAlias("-s");

        var debugOption = new Option<bool>(
            "--debug",
            "Display static output without crops or animations"
        )
        {
            IsHidden = true
        };

        command.AddOption(lineOption);
        command.AddOption(filledOption);
        command.AddOption(colorOption);
        command.AddOption(speedOption);
        command.AddOption(debugOption);

        command.SetHandler(
            (bool useLines, bool useShapes, bool useColors, double speed, bool isDebug) =>
            {
                Handle(useLines, useShapes, useColors, speed, isDebug);
            },
            lineOption, filledOption, colorOption, speedOption, debugOption);

        return command;
    }

    private static void Handle(bool useLines, bool useShapes, bool useColors, double speed, bool isDebug)
    {
        var animation = CreateAnimation(useLines, useShapes, useColors);

        IConsole console = isDebug ? new DebugConsole() : new InteractiveConsole();
        console.Play(animation, speed);
    }

    private static IAnimation CreateAnimation(bool useLines, bool useShapes, bool useColors)
    {
        return useShapes
            ? new SolidSlt(useColors)
            : new OutlineSlt();
    }
}
