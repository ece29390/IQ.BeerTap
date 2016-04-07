using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;
using IQ.Platform.Framework.WebApi.Services.Security;
using IQ.Santos.Ngo.Beertap.ApiServices.Security;
using IQ.Santos.Ngo.Beertap.Model;
using IQ.Santos.Ngo.Beertap.Services;

namespace IQ.Santos.Ngo.Beertap.ApiServices
{
    public class BeerTapApiService : IBeerTapApiService
    {
        private IBeerTapDataService _beerTapDataService;
        private IOfficeDataService _officeDataService;
        readonly IApiUserProvider<BeertapApiUser> _userProvider;

        public BeerTapApiService(
            IApiUserProvider<BeertapApiUser> userProvider
            ,IOfficeDataService officeDataService
            ,IBeerTapDataService beerTapDataService
            )
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;

            _officeDataService = officeDataService;
            _beerTapDataService = beerTapDataService;
        }
        public Task<BeerTap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<string>("OfficeId").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The OfficeId must be supplied in the URI", HttpStatusCode.BadRequest));
            
            var beerTapData = _beerTapDataService.GetTapDataBy(id);
            var beerTap = AutoMapper.Mapper.Map<BeerTap>(beerTapData);
            context.LinkParameters.Set(new LinksParametersSource(officeId, id));
            return Task.FromResult<BeerTap>(beerTap);
        }

        public Task<IEnumerable<BeerTap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<string>("OfficeId").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The OfficeId must be supplied in the URI", HttpStatusCode.BadRequest));
            context.LinkParameters.Set(new LinksParametersSource(officeId, 0));
            var officeData = _officeDataService.GetOfficeBy(officeId);
            var taps = AutoMapper.Mapper.Map<List<BeerTap>>(officeData.Taps);
            var returnTaps = taps.Select(t => t);
            return Task.FromResult<IEnumerable<BeerTap>>(returnTaps);            
        }
    }
}
