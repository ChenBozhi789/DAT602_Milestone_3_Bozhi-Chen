using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAT602_MIlestone_Three
{
    public class Tile
    {
        public int TileID { get; set; }        
        public int TileRow { get; set; }
        public int TileCol { get; set; }
        public bool IsEmptied { get; set; }
        public bool IsOccupied { get; set; }
        public int ItemTypeID { get; set; }
    }
}
