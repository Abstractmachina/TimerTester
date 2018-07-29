using System;
using System.Collections.Generic;
using System.Timers;
using Grasshopper.Kernel;
using Rhino.Geometry;

namespace TimerTest
{
    public class timerTestComponent2 : GH_Component
    {

        Timer timer = new Timer();
        double n = 0;
        bool reset, run;
        double counter;

        /// <summary>
        /// Initializes a new instance of the timerTestComponent2 class.
        /// </summary>
        public timerTestComponent2()
          : base("TimerTest2", "TimeT",
              "Test time-based components",
              "User", "Debug")
        {
            timer.Interval = 1000;
            timer.Elapsed += new ElapsedEventHandler(UpdateSolution);
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

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object is used to retrieve from inputs and store in outputs.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            if (!DA.GetData(0, ref run)) return;
            if (!DA.GetData(1, ref reset)) return;
            if (!DA.GetData(2, ref n)) return;

            if (reset) counter = n;

            if (run && !timer.Enabled)
            {
                counter = 0;
                timer.Start();
            }
            else
            {
                timer.Stop();
            }

            DA.SetData(0, counter);

        }

        public void Update()
        {
            // DoSomethingEpic
            counter++;
        }

        public void UpdateSolution(object source, ElapsedEventArgs e)
        {
            Update();
            ExpireSolution(true);
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("ca1944ae-dfe9-423d-9839-64b1e34da374"); }
        }
    }
}