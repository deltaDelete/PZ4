using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR3v3;
public class Line {
    #region Fields

    private (int x, int y) _point1;
    private (int x, int y) _point2;
    private double _length;

    #endregion

    #region Properties

    public (int x, int y) Point1 {
        get => _point1;
        set {
            var newLength = Math.Sqrt(
                Math.Pow(Point2.x - value.x, 2)
                + Math.Pow(Point2.y - value.y, 2)
            );
            if (Math.Abs(newLength - _length) > 0.0001f) {
                _point1 = value;
                _point2 = GetNewPoint(value, _point2);
            }
        }
    }
    public (int x, int y) Point2 {
        get => _point2;
        set {
            var newLength = Math.Sqrt(
                Math.Pow(value.x - Point1.x, 2)
                + Math.Pow(value.y - Point1.y, 2)
            );
            if (Math.Abs(newLength - _length) > 0.0001f) {
                _point1 = GetNewPoint(value, _point1);
                _point2 = value;
            }
        }
    }

    #endregion

    #region Constructors

    public Line((int x, int y) point1, (int x, int y) point2) {
        _point1 = point1;
        _point2 = point2;

        _length = Math.Sqrt(
            Math.Pow(Point2.x - Point1.x, 2)
            + Math.Pow(Point2.y - Point1.y, 2)
        );
    }

    public Line(int x1, int y1, int x2, int y2) : this((x1, y1), (x2, y2)) { }

    #endregion

    #region Private methods

    private (int x, int y) GetNewPoint((int x, int y) newPoint, (int x, int y) secondPoint) {
        
        var fi = Math.Atan(
            (newPoint.y - secondPoint.y) / (newPoint.x - secondPoint.x)
        );

        int x22 = (int)Math.Round(_length * Math.Cos(fi) + newPoint.x, MidpointRounding.AwayFromZero);
        int y22 = (int)Math.Round(_length * Math.Cos(fi) + newPoint.y, MidpointRounding.AwayFromZero);

        return (x22, y22);
    }

    #endregion

    #region Public methods
    
    public double CalcLength() {
        return Math.Sqrt(
            Math.Pow(this._point2.x - this._point1.x, 2)
            + Math.Pow(this._point2.y - this._point1.y, 2)
        );
    }

    #endregion
}
