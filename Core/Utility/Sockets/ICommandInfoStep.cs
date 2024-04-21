namespace Core.Utility.Sockets
{
    public interface ICommandInfoStep<TStep>
    {
        TStep GetStep(bool result);
    }
}
