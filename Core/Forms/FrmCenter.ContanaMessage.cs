using System;
namespace Core.Forms
{
    public partial class FrmCenter
    {
        public class ContanaMessage : ContanaProcess
        {
            private Random random = new Random();
            private int i = 0;
            private int current = 0;

            public override void Do()
            {
                if (i >= Contana.Setting.ClearConsole)
                {
                    Contana.FrmCenter.Invoke(() => Contana.FrmCenter.console.Clear());
                    i = 0;
                }

                var next = random.Next(0, Contana.FrmCenter.contanaMessages.Count);
                if (next == Contana.FrmCenter.contanaMessages.Count || next == current) return;

                var message = Contana.FrmCenter.contanaMessages[next];
                current = next;

                Contana.FrmCenter.Invoke(() => Contana.FrmCenter.ConsoleWrite(message));
                i++;
            }

            public override bool Run()
            {
                return Contana.FrmCenter.smiContanaMessage.Checked;
            }
        }
    }
}