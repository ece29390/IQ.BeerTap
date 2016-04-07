using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using IQ.Santos.Ngo.Beertap.ApiServices;
using IQ.Santos.Ngo.Beertap.Model;
using IQ.Santos.Ngo.Beertap.Model.SupportResources;

namespace IQ.Santos.Ngo.Beertap.WebApi.Hypermedia
{
    public class NewGlassSpec: SingleStateResourceSpec<NewGlass, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/BeerTaps({tapId})/NewGlass");

        // custom self link
        protected override IEnumerable<ResourceLinkTemplate<NewGlass>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.Officeid, x => x.Parameters.BeerTapId);
        }

        public override IResourceStateSpec<NewGlass, NullState, int> StateSpec
        {
            get
            {
                return
                    new SingleStateSpec<NewGlass, int>
                    {
                        Links =
                            {
                                CreateLinkTemplate<LinksParametersSource>(LinkRelations.Tap, BeerTapSpec.Uri, i => i.Parameters.Officeid, i => i.Parameters.BeerTapId),                                
                            },

                        Operations =
                            {
                                InitialPost = ServiceOperations.Create,
                            },
                    };
            }
        }
    }
}