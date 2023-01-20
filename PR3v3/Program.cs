using Spectre.Console;

namespace PR3v3;
class Program {
    public static void Main(string[] args) {
        // TODO: fix баг длина изменяется при изменении координат точки (x,y) не на одинаковое число
        var line1 = new Line(1, 2, 3, 4);
        var line2 = new Line(3, 4, 1, 2);

        AnsiConsole.Write(new Rule("[blue]Отрезки[/]"));
        AnsiConsole.MarkupLineInterpolated($"[red]Значения первой линии:[/]\n\tX1: {line1.Point1.x}\n\tY1: {line1.Point1.y}\n\tX2: {line1.Point2.x}\n\tY2: {line1.Point2.y}");
        AnsiConsole.MarkupLineInterpolated($"[red]Значения второй линии:[/]\n\tX1: {line2.Point1.x}\n\tY1: {line2.Point1.y}\n\tX2: {line2.Point2.x}\n\tY2: {line2.Point2.y}");

        var length11 = line1.CalcLength();
        var length21 = line2.CalcLength();

        line1.Point1 = (2, 3);
        line2.Point2 = (1, 4);

        AnsiConsole.Write(new Rule("[red]Отрезки[/]"));
        AnsiConsole.MarkupLineInterpolated($"[blue]Значения первой линии:[/]\n\tX1: {line1.Point1.x}\n\tY1: {line1.Point1.y}\n\tX2: {line1.Point2.x}\n\tY2: {line1.Point2.y}");
        AnsiConsole.MarkupLineInterpolated($"[blue]Значения второй линии:[/]\n\tX1: {line2.Point1.x}\n\tY1: {line2.Point1.y}\n\tX2: {line2.Point2.x}\n\tY2: {line2.Point2.y}");

        var length12 = line1.CalcLength();
        var length22 = line2.CalcLength();

        AnsiConsole.Write(new Rule("[blue]Длины[/]"));
        AnsiConsole.MarkupLineInterpolated($"[blue]Длины:[/]\n\t11: {length11}\n\t12: {length12}\n\t21: {length21}\n\t22: {length22}");

        Console.ReadKey();
    }
}