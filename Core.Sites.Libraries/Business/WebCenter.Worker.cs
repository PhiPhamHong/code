using Core.Business.Entities;
using Core.Extensions;
using Core.Forms;
using System;
using System.Linq;

namespace Core.Sites.Libraries.Business
{
    public partial class WebCenter : Center<WebCenter.Worker, WebCenter>
    {
        public bool RunFromWeb { get; set; } = true;

        [CenterStart(Stt = 0)]
        private void StartWorker()
        {
            Company.Inst.GetAllToList().Where(c => !c.IsLock).ForEach(c => AddWorker(c));
        }
        public void AddWorker(Company company)
        {
            var config = CompanyConfig.Inst.GetByCompanyId(company.CompanyId);
            var worker = new Worker.One(company, config);
            worker.RunFromWeb = RunFromWeb;
            AddWorker(worker);
        }
        public abstract partial class Worker : CenterThread<WebCenter> 
        {
            public abstract class SSERPOneSecond : WorkerOneSecond, IConfigCenter
            {
                public int CompanyId { get; set; }
                public CompanyConfig Config { get; set; }
                public abstract class ControlByCompany : Control<SSERPOneSecond>
                {
                    public abstract class Worker<TIWorkerOfCompany> : ControlByCompany where TIWorkerOfCompany : IWorkerOfCompany, new()
                    {
                        TIWorkerOfCompany worker = new TIWorkerOfCompany();
                        sealed public override void Prepare()
                        {
                            worker.Config = Worker as IConfigCenter;
                        }
                        sealed protected override void Work()
                        {
                            worker.Work();
                        }
                    }
                    public abstract class WorkerByDate<TIWorkerOfCompany> : ControlByCompany where TIWorkerOfCompany : IWorkerOfCompanyByDate, new()
                    {
                        public TIWorkerOfCompany worker = new TIWorkerOfCompany();
                        sealed public override void Prepare()
                        {
                            worker.Config = Worker as IConfigCenter;
                        }
                        sealed protected override void Work()
                        {
                            worker.DateNotify = Worker.CurrentDate;
                            worker.Work();
                        }
                    }
                }
            }
            public interface IWorkerOfCompany
            {
                IConfigCenter Config { set; get; }
                void Work();
            }

            public abstract class WorkerOfCompany : IWorkerOfCompany
            {
                public IConfigCenter Config { set; get; }
                public abstract void Work();
            }
            public interface IWorkerOfCompanyByDate : IWorkerOfCompany
            {
                DateTime DateNotify { set; get; }
            }
        }
    }

    public interface IConfigCenter
    {
        CompanyConfig Config { get; }
    }
}