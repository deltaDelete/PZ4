using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3;
public class BrokenLine : Line {
    public BrokenLine((double x, double y) point1, (double x, double y) point2) : base(point1, point2) {
        
    }

    public double Point3 { get; set; }

    public override void Show() {
        base.Show();
        Console.WriteLine($"Точка 3:{Point3}");
    }
}
