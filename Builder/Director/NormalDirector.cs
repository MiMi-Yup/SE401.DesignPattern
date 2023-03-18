using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Builder;

namespace Builder.Director
{
    internal class NormalDirector
    {
        public Builder.Builder Director(Builder.Builder builder)
        {
            builder.BuildFloor()
                .BuildWall()
                .BuildDoor()
                .BuildWindows()
                .BuildRoof();
            return builder;
        }
    }
}
