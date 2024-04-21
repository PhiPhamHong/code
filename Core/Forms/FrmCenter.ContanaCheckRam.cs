using System;
using System.Diagnostics;
namespace Core.Forms
{
    public partial class FrmCenter
    {
        public class ContanaCheckRam : ContanaProcess
        {
            public override void Do()
            {
                var size = Process.GetCurrentProcess().WorkingSet64 - Process.GetCurrentProcess().PrivateMemorySize64 + GC.GetTotalMemory(false);
                Contana.FrmCenter.Invoke(() => Contana.FrmCenter.slMem.Text = "Mem: " + (((size) / 1024f) / 1024f).ToString("#.##") + " Mb");
            }

            public override bool Run()
            {
                return Contana.FrmCenter.smiContanaCheckRam.Checked;
            }
        }
    }
}