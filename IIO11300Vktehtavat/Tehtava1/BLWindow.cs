using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1
{
    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
        public static double CalculateArea(double widht, double height)
        {
            return widht * height;
            //throw new System.NotImplementedException();
        }
        public static double CalculatePerimeter(double widht, double height, double karmi)
        {
            widht = widht + (2*karmi);
            height = height + (2*karmi);
            return 2*(widht+height);
            //throw new System.NotImplementedException();
        }
        public static double CalculatePerimeterArea(double widht, double height, double karmi)
        {
            widht = widht + (2*karmi);
            height = height + (2*karmi);

            double innerWidth = widht - (2 * karmi);
            double innerHeight = height - (2 * karmi);
            double innerResult = innerWidth * innerHeight;

            return ((widht * height) - innerResult);
            //throw new System.NotImplementedException();
        }
    }
}
