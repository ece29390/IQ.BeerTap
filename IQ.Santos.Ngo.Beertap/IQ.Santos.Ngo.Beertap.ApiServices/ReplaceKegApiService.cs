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
using IQ.Santos.Ngo.Beertap.Model.SupportResources;
using IQ.Santos.Ngo.Beertap.Persistence;
using IQ.Santos.Ngo.Beertap.Services;

namespace IQ.Santos.Ngo.Beertap.ApiServices
{
    public class ReplaceKegApiService : IReplaceKegService
    {
        private IBeerTapDataService _beerTapDataService;
        private IKegDataService _kegDataService;
        private IApiUserProvider<BeertapApiUser> _userProvider;

        public ReplaceKegApiService(
            IApiUserProvider<BeertapApiUser> userProvider
             , IBeerTapDataService beerTapDataService
            , IKegDataService kegDataService
            )
        {
            if (userProvider == null)
                throw new ArgumentNullException("userProvider");
            _userProvider = userProvider;

            _beerTapDataService = beerTapDataService;
            _kegDataService = kegDataService;

        }

        public Task<ResourceCreationResult<ReplaceKeg, int>> CreateAsync(ReplaceKeg resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeId = context.UriParameters.GetByName<string>("officeId").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The officeId must be supplied in the URI", HttpStatusCode.BadRequest));
            var tapId = context.UriParameters.GetByName<int>("tapId").EnsureValueIsPresent(() => context.CreateHttpResponseException<BeerTap>("The tapid must be supplied in the URI", HttpStatusCode.BadRequest));

            var tapData = _beerTapDataService.GetTapDataBy(tapId);

            var newKeg = new KegData
            {
                VolumeLeft = resource.NewVolume,
                BeerBrand = resource.NewBeerBrand
            };
            _kegDataService.ReplaceOldKegInTap(tapData,newKeg);

            context.LinkParameters.Set(new LinksParametersSource(officeId, tapId));
            return Task.FromResult(new ResourceCreationResult<ReplaceKeg, int>(resource));


        }
    }
}
