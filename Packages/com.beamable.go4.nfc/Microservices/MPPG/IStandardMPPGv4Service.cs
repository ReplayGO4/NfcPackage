namespace DynaProx.MPPGv4Service
{
    public interface IStandardMPPGv4Service
    {
        System.Threading.Tasks.Task<DynaProx.MPPGv4Service.ProcessTokenResponse[]> ProcessTokenAsync(DynaProx.MPPGv4Service.ProcessTokenRequest[] ProcessTokenRequests);
        System.Threading.Tasks.Task<DynaProx.MPPGv4Service.ProcessDataResponse[]> ProcessDataAsync(DynaProx.MPPGv4Service.ProcessDataRequest[] ProcessDataRequests);
    }
}