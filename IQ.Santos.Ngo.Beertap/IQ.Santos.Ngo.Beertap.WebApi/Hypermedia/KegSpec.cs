using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using IQ.Santos.Ngo.Beertap.ApiServices;
using IQ.Santos.Ngo.Beertap.Model;

namespace IQ.Santos.Ngo.Beertap.WebApi.Hypermedia
{
    public class KegSpec: SingleStateResourceSpec<Keg, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/BeerTaps({beertapid})/Kegs({id})");

        protected override IEnumerable<ResourceLinkTemplate<Keg>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, c => c.Parameters.Officeid,
                    c => c.Parameters.BeerTapId, c => c.Resource.Id);
        }

        public override IResourceStateSpec<Keg, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<Keg, int>
                    {
                        Links =
                            {
                                CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.Officeid),
                                CreateLinkTemplate<LinksParametersSource>(LinkRelations.Tap, BeerTapSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.BeerTapId),
                                CreateLinkTemplate<LinksParametersSource>(LinkRelations.Keg, KegSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.BeerTapId,x=>x.Resource.Id),
                            },

                        Operations =
                            {
                                Get = ServiceOperations.Get,
                                InitialPost = ServiceOperations.Create,
                                Post = ServiceOperations.Update,
                                Delete = ServiceOperations.Delete,
                            },
                    };
            }
        }
    }
}