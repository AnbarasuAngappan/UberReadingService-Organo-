using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberReadingService
{
    class Graph
    {
        public string _societyID { get; set; }
        public string _houseID { get; set; }
        public string _meterID { get; set; }
        public string _ipAddress { get; set; }
        public int _port { get; set; }
        public int _startingAddress { get; set; }
        public int _typeOfReading { get; set; }
    }
}
