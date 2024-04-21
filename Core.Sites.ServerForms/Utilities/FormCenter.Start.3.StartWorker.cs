using Core.Forms;
namespace Core.Sites.ServerForms.Utilities
{
    public partial class FormCenter
    {
        [CenterStart(Stt = 3)]
        private void StartWorker()
        {
            AddWorker<Worker.One>();
        }
    }
}