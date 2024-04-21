using Core.Forms;
namespace Core.Sites.ServerForms.Utilities
{
    public partial class FormCenter : Center<FormCenter.Worker, FormCenter>
    {
        public FormServer Parent { set; get; }

        public abstract partial class Worker : CenterThread<FormCenter>
        {

        }
    }
}