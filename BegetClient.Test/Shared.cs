namespace TDV.BegetClient.Test;

internal class Shared
{
    internal static BegetClient GetClient()
    {
        return new BegetClient(EnviromentHelper.GetVariable("user"), EnviromentHelper.GetVariable("passwd"));
    }
}
