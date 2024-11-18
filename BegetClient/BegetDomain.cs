using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TDV.BegetClient.Models;
using TDV.BegetClient.Models.Domain;

namespace TDV.BegetClient
{
    public class BegetDomain
    {
        private readonly BegetClient _client;

        public BegetDomain(BegetClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<BegetZone>> GetZoneList()
        {
            var resp = await _client.GetAnswer<AnswerWithResult<Dictionary<string, BegetZone>>>("domain/getZoneList");
            return resp.Result.Values.ToList();
        }

        public async Task<CheckDomainToRegisterResponse> CheckDomainToRegister(string domainWithoutZone, int zoneId, int periodYears=1)
        {
            var query = $"input_format=json&input_data={HttpUtility.UrlEncode($"{{\"hostname\": \"{domainWithoutZone}\", \"zone_id\": {zoneId}, \"period\":{periodYears}}}")}";
            var resp = await _client.GetAnswer<AnswerWithResult<CheckDomainToRegisterResponse>>($"domain/checkDomainToRegister?{query}");
            return resp.Result;
        }
    }
}
