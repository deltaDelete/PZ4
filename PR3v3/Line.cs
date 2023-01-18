using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR3v3;
public class Line {
    private (float x, float y) _point1;
    private (float x, float y) _point2;
    private float _length;

    public (float x, float y) Point1 {
        get => _point1;
        set {
            //_point1 = value;
            var newLength = MathF.Sqrt(
                MathF.Pow(Point2.x - Point1.x, 2)
                + MathF.Pow(Point2.y - Point1.y, 2)
            );
            if (newLength != _length) {
                var fi = MathF.Atan(
                    value.y - 
                );
            }
        }
    }
    public (float x, float y) Point2 {
        get => _point2;
        set {
            _point2 = value;
        }
    }

    public Line((float x, float y) point1, (float x, float y) point2) {
        _point1 = point1;
        _point2 = point2;

        _length = MathF.Sqrt(
            MathF.Pow(Point2.x - Point1.x, 2)
            + MathF.Pow(Point2.y - Point1.y, 2)
        );
    }

    public Line(float x1, float y1, float x2, float y2) : this((x1, y1), (x2, y2)) { }
}
