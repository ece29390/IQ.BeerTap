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
    public class KegApiService : IKegServiceApi
    {
        private IKegDataService _kegDataService;
        readonly IApiUserProvider<BeertapApiUser> _userProvider;

        public KegApiService(IApiUserProvider<BeertapApiUser> userProvider,IKegDataService kegDataService)
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;
            _kegDataService = kegDataService;
        }
        public Task<ResourceCreationResult<Keg, int>> CreateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResourceOrIdentifier<Keg, int> input, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Keg> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<string>("officeId").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The officeid must be supplied in the URI", HttpStatusCode.BadRequest));
            var beerTapId = context.UriParameters.GetByName<int>("beertapid").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The beertapid must be supplied in the URI", HttpStatusCode.BadRequest));
            context.LinkParameters.Set(new LinksParametersSource(officeId,beerTapId));
            var kegData = _kegDataService.GetKegDataBy(id);
            var keg = AutoMapper.Mapper.Map<Keg>(kegData);
            keg.BeerTapId = beerTapId;

            return Task.FromResult<Keg>(keg);
        }

        public Task<IEnumerable<Keg>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<string>("officeId").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The officeid must be supplied in the URI", HttpStatusCode.BadRequest));
            var beerTapId = context.UriParameters.GetByName<int>("beertapid").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The beertapid must be supplied in the URI", HttpStatusCode.BadRequest));
            context.LinkParameters.Set(new LinksParametersSource(officeId, beerTapId));
            var kegsData = _kegDataService.GetKegsBy(officeId, beerTapId);
            var kegs = AutoMapper.Mapper.Map<List<Keg>>(kegsData);
            kegs.ForEach(k=>k.BeerTapId=beerTapId);
            return Task.FromResult(kegs.Select(k => k));

        }
    }
}
