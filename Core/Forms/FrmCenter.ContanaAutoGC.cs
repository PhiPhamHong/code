using System;
namespace Core.Forms
{
    public partial class FrmCenter
    {
		public class ContanaAutoGC : ContanaProcess
        {
            int current = 0;
            public override void Do()
            {
                current++;
				if(current == Contana.Setting.GCInterval)
                {
                    GC.Collect();
                    current = 0;
                }                
            }

            public override bool Run()
            {
                return Contana.FrmCenter.smiAutoGc.Checked;
            }
        }
    }
}
