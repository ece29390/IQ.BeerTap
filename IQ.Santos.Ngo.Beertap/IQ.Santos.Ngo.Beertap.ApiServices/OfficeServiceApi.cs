using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQ.Santos.Ngo.Beertap.ApiServices.Security;
using IQ.Santos.Ngo.Beertap.Model;
using IQ.Santos.Ngo.Beertap.Services;

namespace IQ.Santos.Ngo.Beertap.ApiServices
{
    public class OfficeServiceApi : IOfficeServiceApi
    {
        private IOfficeDataService _officeDataService;
        readonly IApiUserProvider<BeertapApiUser> _userProvider;

        public OfficeServiceApi(IApiUserProvider<BeertapApiUser> userProvider, IOfficeDataService officedataservice)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;

            _officeDataService = officedataservice;
        }
        public Task DeleteAsync(ResourceOrIdentifier<Office, string> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Office> GetAsync(string id, IRequestContext context, CancellationToken cancellation)
        {
            var returnOffice = _officeDataService.GetOfficeBy(id);
            var office = AutoMapper.Mapper.Map<Office>(returnOffice);

            return Task.FromResult<Office>(office);
        }

        public  Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officesData = _officeDataService.GetOffices();
            var returnOffices = officesData.Select(od => AutoMapper.Mapper.Map<Office>(od));
            return Task.FromResult(returnOffices);            
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
