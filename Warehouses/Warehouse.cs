using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouses
{
    internal class Warehouse
    {

        int part102, part215, part410, part525, part711;

        public Warehouse(int part102, int part215, int part410, int part525, int part711)
        {
            this.part102 = part102;
            this.part215 = part215;
            this.part410 = part410;
            this.part525 = part525;
            this.part711 = part711;
        }

        public int GetPart102()
        {
            return part102;
        }

        public void SetPart102(int p1)
        {
            part102 = p1;
        }

        public int GetPart215()
        {
            return part215;
        }

        public void SetPart215(int p2)
        {
            part215 = p2;
        }

        public int GetPart410()
        {
            return part410;
        }

        public void SetPart410(int p3)
        {
            part410 = p3;
        }

        public int GetPart525()
        {
            return part525;
        }

        public void SetPart525(int p4)
        {
            part525 = p4;
        }

        public int GetPart711()
        {
            return part711;
        }

        public void SetPart711(int p5)
        {
            part711 = p5;
        }

        public override string ToString()
        {
            //ToString for testing
            //"Part 102: " + part102 + "\nPart 215: " + part215 + "\nPart 410: " + part410 + "\nPart 525: " + part525 + "\nPart 711: " + part711;
            return part102 + ", " + part215 + ", " + part410 + ", " + part525 + ", " + part711;
        }
        
    }
}
