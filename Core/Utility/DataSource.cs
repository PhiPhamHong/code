using Core.DataBase.ADOProvider;
using System;
using System.Collections.Generic;

namespace Core.Utility
{
    public interface ISource
    {
        string FieldOrder { set; get; }
        string Dir { set; get; }
        int Start { set; get; }
        int Length { set; get; }

        object GetData();
        DataSummary GetDataSummary();
    }

    public abstract class DataSource<TEntity> : ISource
    {
        public List<TEntity> CurrentData { private set; get; }
        public string FieldOrder { set; get; }
        public string Dir { set; get; } = string.Empty;
        public int Start { set; get; }
        public int Length { set; get; } = int.MaxValue;

        public object GetData() 
        {
            if (Length == 0) Length = int.MaxValue;
            BeforeGetEntities?.Invoke();
            CurrentData = GetEntities();
            AfterGetEntities?.Invoke(CurrentData);
            return CurrentData;
        }

        public event Action<List<TEntity>> AfterGetEntities;
        public event Action BeforeGetEntities;

        public abstract DataSummary GetDataSummary();
        public abstract List<TEntity> GetEntities();

        public abstract class Module : DataSource<TEntity>
        {
            sealed public override DataSummary GetDataSummary() => new DataSummary { Total = GetTotal() };
            public abstract int GetTotal();
        }
        public abstract class Report<TSummary> : DataSource<TEntity>
        {
            public class DataSummaryReport : DataSummary
            {
                new public List<TSummary> Summaries { set => base.Summaries = value; get => base.Summaries as List<TSummary>; }
            }
            sealed public override DataSummary GetDataSummary() => GetDataSummaryReport();
            protected abstract DataSummaryReport GetDataSummaryReport();
        }
        public abstract class ReportSummary<TSummary> : Report<TSummary> where TSummary : IReportSummary
        {
            protected override DataSummaryReport GetDataSummaryReport()
            {
                var reportSummary = GetDataSummary();
                var summary = new DataSummaryReport();

                if (reportSummary != null)
                {
                    summary.Total = reportSummary.Total;
                    summary.Summaries = new List<TSummary> { reportSummary };
                }

                return summary;
            }

            new public abstract TSummary GetDataSummary();
        }

        public class ReportSummary { }
    }
    public class DataSummary
    {
        public object Summaries { set; get; }
        public int Total { set; get; }
    }
}