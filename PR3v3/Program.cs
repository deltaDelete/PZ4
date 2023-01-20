using Spectre.Console;

namespace PR3v3;
public class Program
{
    public static void Main(string[] args)
    {
        var selectedMode = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("[green]В каком режиме вы хотите запустить программу[/]?")
            .AddChoices(new[] { "Интерактивный", "Демонстрационный" }));

        switch (selectedMode)
        {
            case "Интерактивный":
                InteractiveMode();
                break;
            case "Демонстрационный":
                DemoMode();
                break;
        }

        Console.ReadKey();
    }

    public static void InteractiveMode()
    {
        var x1 = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите координату X точки 1:")
            );
        var y1 = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите координату Y точки 1:")
            );
        var x2 = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите координату X точки 2:")
            );
        var y2 = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите координату Y точки 2:")
            );

        var line = new Line(x1, y1, x2, y2);
        AnsiConsole.MarkupLineInterpolated($"[blue]Длина = {line.CalcLength()}[/]");

        AnsiConsole.Write(new Rule("Таблица точек отрезка"));
        var table = new Table();
        table.AddColumn("");
        table.AddColumn("Точка 1");
        table.AddColumn("Точка 2");
        table.AddRow("X", line.Point1.x.ToString(), line.Point2.x.ToString());
        table.AddRow("Y", line.Point1.y.ToString(), line.Point2.y.ToString());
        AnsiConsole.Write(table);

        AnsiConsole.MarkupLineInterpolated($"[blue]Длина = {line.CalcLength()}[/]");

        var pointToChange = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("[green]Какую точку хотите изменить[/]?")
            .AddChoices(new[] {
                "Точка 1",
                "Точка 2",
                "Никакую"
        }));

        var newX = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите новую координату X:")
            );
        var newY = AnsiConsole.Prompt(
            new TextPrompt<double>("Введите координату Y:")
            );

        switch (pointToChange)
        {
            case "Точка 1":
                line.Point1 = (newX, newY);
                break;
            case "Точка 2":
                line.Point2 = (newX, newY);
                break;
            default:
                return;
        }

        AnsiConsole.Write(new Rule("Таблица точек отрезка"));

        var tableChanged = new Table();
        tableChanged.AddColumn("");
        tableChanged.AddColumn("Точка 1");
        tableChanged.AddColumn("Точка 2");
        tableChanged.AddRow("X", line.Point1.x.ToString(), line.Point2.x.ToString());
        tableChanged.AddRow("Y", line.Point1.y.ToString(), line.Point2.y.ToString());

        AnsiConsole.MarkupLineInterpolated($"[blue]Длина = {line.CalcLength()}[/]");

        AnsiConsole.Write(tableChanged);
    }

    static void DemoMode()
    {
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

        var lengthGrid = new Grid();
        lengthGrid.AddColumn();
        lengthGrid.AddColumn();

        lengthGrid.AddRow("", "Длина");
        lengthGrid.AddRow("Отрезок 1", length11.ToString());
        lengthGrid.AddRow("Отрезок 2", length21.ToString());
        lengthGrid.AddRow("Отрезок 1.2", length12.ToString());
        lengthGrid.AddRow("Отрезок 2.2", length22.ToString());
        AnsiConsole.Write(new Panel(lengthGrid) { Border = BoxBorder.Rounded });

    }
}