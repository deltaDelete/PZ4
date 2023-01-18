// Отступ для красоты

using PR3v3;

// TODO: fix баг длина изменяется при изменение координат точки (x,y) не на одинаковое число
var line1 = new Line(1,2,3,4);
var line2 = new Line(3,4,1,2);

Console.WriteLine($"Значение первой линии:\n\tX1: {line1.Point1.x}\n\tY1: {line1.Point1.y}\n\tX2: {line1.Point2.x}\n\tY2: {line1.Point2.y}");
Console.WriteLine($"Значение второй линии:\n\tX1: {line2.Point1.x}\n\tY1: {line2.Point1.y}\n\tX2: {line2.Point2.x}\n\tY2: {line2.Point2.y}");

var length11 = line1.CalcLength();
var length21 = line2.CalcLength();

line1.Point1 = (2, 3);
line2.Point2 = (1, 4);

Console.WriteLine($"Значение первой линии:\n\tX1: {line1.Point1.x}\n\tY1: {line1.Point1.y}\n\tX2: {line1.Point2.x}\n\tY2: {line1.Point2.y}");
Console.WriteLine($"Значение второй линии:\n\tX1: {line2.Point1.x}\n\tY1: {line2.Point1.y}\n\tX2: {line2.Point2.x}\n\tY2: {line2.Point2.y}");

var length12 = line1.CalcLength();
var length22 = line2.CalcLength();

Console.WriteLine($"Длины:\n\t11: {length11}" +
                  $"\n\t12: {length12}" +
                  $"\n\t21: {length21}" +
                  $"\n\t22: {length22}");

Console.ReadKey();