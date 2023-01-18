// Отступ для красоты

using PR3v3;

Console.BackgroundColor = ConsoleColor.Green;
Console.Clear();

var line1 = new Line(1,2,3,4);
var line2 = new Line(3,4,1,2);

Console.WriteLine($"Значение первой линии:\n\tX1: {line1.Point1.x}\n\tY1: {line1.Point1.y}\n\tX2: {line1.Point2.x}\n\tY1: {line1.Point2.y}");
Console.WriteLine($"Значение второй линии:\n\tX1: {line2.Point1.x}\n\tY1: {line2.Point1.y}\n\tX2: {line2.Point2.x}\n\tY1: {line2.Point2.y}");

