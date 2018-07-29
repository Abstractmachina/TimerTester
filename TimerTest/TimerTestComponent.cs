using System;
using System.Collections.Generic;

using Grasshopper.Kernel;
using Rhino.Geometry;
using System.Timers;

// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace TimerTest
{
    public class TimerTestComponent : GH_Component
    {

        Timer timer = new Timer();
        double n = 0;
        bool reset, run;

        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public TimerTestComponent()
          : base("TimerTest", "TimeT",
              "Used to Test time-based components",
              "User", "Debug")
        {
            timer.Interval = 1000;
            timer.Start();
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddBooleanParameter("Run", "RUN", ".", GH_ParamAccess.item);
            pManager.AddBooleanParameter("Reset", "RES", ".", GH_ParamAccess.item);
            pManager.AddNumberParameter("Number", "N", "number to be affected.", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddNumberParameter("Output", "O", "Result of computation.", GH_ParamAccess.item);
        }


        //Schedule a new solution after a specified time interval
        private void ScheduleCallBack(GH_Document doc) { this.ExpireSolution(false); }

        protected override void AfterSolveInstance()
        {
            //if (!this.on) return;
            GH_Document ghDocument = OnPingDocument();
            ghDocument.ScheduleSolution(1000, new GH_Document.GH_ScheduleDelegate(this.ScheduleCallBack));
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetData(0, ref run)) return;
            if (!DA.GetData(1, ref reset)) return;

            if (reset) if (!DA.GetData(2, ref n)) { return; }


            if (run)
            {
                n++;
            }

            DA.SetData(0, n);
        }


        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid {
            get { return new Guid("a3bc0df6-fe61-4942-bba4-7237383802f7"); }
        }
    }

    class Tester
    {
        public Tester() { }

        public static void Main()
        {

            Timer myTimer = new Timer();
            myTimer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            myTimer.Interval = 1000;
            myTimer.Start();

        }

        public static void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {
            Console.Write("\r{0}", DateTime.Now);
        }

    }
}
