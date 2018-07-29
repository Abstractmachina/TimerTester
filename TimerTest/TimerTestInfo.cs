using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace TimerTest
{
    public class TimerTestInfo : GH_AssemblyInfo
    {
        public override string Name {
            get
            {
                return "TimerTest";
            }
        }
        public override Bitmap Icon {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id {
            get
            {
                return new Guid("17a37a52-869c-4736-b3c8-89c62e3a7bca");
            }
        }

        public override string AuthorName {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
