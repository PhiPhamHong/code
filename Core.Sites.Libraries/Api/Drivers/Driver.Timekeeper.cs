using Core.Sites.Libraries.Api.Drivers.Entities;

namespace Core.Sites.Libraries.Api.Devices.Drivers
{
    public partial class Driver
    {
        public class Timekeeper : ApiBase
        {
            private const string ApiPower = "api/Power";
            private const string ApiDataflow = "api/Dataflow";
            private const string ApiDatasend = "api/Datasend";
            private const string ApiGetDeviceOnline = "api/GetDeviceOnline";
            private const string ApiGetListDeviceOnline = "api/GetListDeviceOnline";
            private const string ApiRemoveDevice = "api/RemoveDevice";
            private const string ApiRemoveTarget = "api/RemoveTarget";

            public Power.Response ChangePower(Power.Request request) => Call<Power.Request, Power.Response>(ApiPower, request);
            public Data.Flow.Response Dataflow(Data.Flow.Request request) => Call<Data.Flow.Request, Data.Flow.Response>(ApiDataflow, request);
            public Data.Send.Response Datasend(Data.Send.Request request) => Call<Data.Send.Request, Data.Send.Response>(ApiDatasend, request);
            public GetDeviceOnline.Response GetDeviceOnline(GetDeviceOnline.Request request) => Call<GetDeviceOnline.Request, GetDeviceOnline.Response>(ApiGetDeviceOnline, request);
            public GetListDeviceOnline.Response GetListDeviceOnline(GetListDeviceOnline.Request request) => Call<GetListDeviceOnline.Request, GetListDeviceOnline.Response>(ApiGetListDeviceOnline, request);
            public RemoveDevice.Response RemoveDevice(RemoveDevice.Request request) => Call<RemoveDevice.Request, RemoveDevice.Response>(ApiRemoveDevice, request);
            public RemoveTarget.Response RemoveTarget(RemoveTarget.Request request) => Call<RemoveTarget.Request, RemoveTarget.Response>(ApiRemoveTarget, request);
        }
    }
}
