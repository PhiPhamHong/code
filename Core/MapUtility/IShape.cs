using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.MapUtility
{
    public interface IShape
    {
        bool IsPointIn(Coordinate point);
    }
}
