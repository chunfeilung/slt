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

        var sparkOption = new Option<bool>(
            "--sparks",
            "Generate sparks between (non-existing) overhead line and pantograph"
        );

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
        command.AddOption(sparkOption);
        command.AddOption(debugOption);

        command.SetHandler(
            Handle,
            lineOption,
            filledOption,
            colorOption,
            speedOption,
            sparkOption,
            debugOption
        );

        return command;
    }

    private static void Handle(
        bool useLines,
        bool useShapes,
        bool useColors,
        double speed,
        bool showSparks,
        bool isDebug
    )
    {
        var config = new AnimationConfiguration
        {
            UseLines = useLines,
            UseShapes = useShapes,
            UseColors = useColors,
            Speed = speed,
            ShowSparks = showSparks,
            IsDebug = isDebug
        };

        var animation = CreateAnimation(config);

        IConsole console = config.IsDebug ? new DebugConsole() : new InteractiveConsole();
        console.Play(animation, config.Speed);
    }

    private static IAnimation CreateAnimation(AnimationConfiguration config)
    {
        return config.UseShapes
            ? new SolidSlt(config)
            : new OutlineSlt(config);
    }
}
