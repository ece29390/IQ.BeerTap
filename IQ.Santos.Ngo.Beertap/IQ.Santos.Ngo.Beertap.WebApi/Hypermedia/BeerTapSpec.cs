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
    public class BeerTapSpec: ResourceSpec<BeerTap, KegLevel, int>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({officeId})/BeerTaps({id})");

        protected override IEnumerable<ResourceLinkTemplate<BeerTap>> Links()
        {
            yield return CreateLinkTemplate<LinksParametersSource>(CommonLinkRelations.Self, Uri, x => x.Parameters.Officeid, x => x.Resource.Id);
        }

        protected override IEnumerable<IResourceStateSpec<BeerTap, KegLevel, int>> GetStateSpecs()
        {
            yield return new ResourceStateSpec<BeerTap, KegLevel, int>(KegLevel.New)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.Officeid),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Keg, KegSpec.Uri.Many, x => x.Parameters.Officeid, x => x.Resource.Id),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.NewGlass, NewGlassSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.Id),
                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                }
            };

            yield return new ResourceStateSpec<BeerTap, KegLevel, int>(KegLevel.GoingDown)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.Officeid),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Keg, KegSpec.Uri.Many, x => x.Parameters.Officeid, x => x.Resource.Id),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.NewGlass, NewGlassSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.Id),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.ReplaceKeg, ReplaceKegSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.Id)
                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                }
            };

            yield return new ResourceStateSpec<BeerTap, KegLevel, int>(KegLevel.AlmostEmpty)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.Officeid),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Keg, KegSpec.Uri.Many, x => x.Parameters.Officeid, x => x.Resource.Id),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.NewGlass, NewGlassSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.Id),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.ReplaceKeg, ReplaceKegSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.Id)
                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                }
            };

            yield return new ResourceStateSpec<BeerTap, KegLevel, int>(KegLevel.SheIsDry)
            {
                Links =
                    {
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Office, OfficeSpec.Uri, x => x.Parameters.Officeid),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.Keg, KegSpec.Uri.Many, x => x.Parameters.Officeid, x => x.Resource.Id),
                        CreateLinkTemplate<LinksParametersSource>(LinkRelations.ReplaceKeg, ReplaceKegSpec.Uri, x => x.Parameters.Officeid, x => x.Resource.Id)
                    },

                Operations = new StateSpecOperationsSource<BeerTap, int>()
                {
                    Get = ServiceOperations.Get,
                    //InitialPost = ServiceOperations.Create,
                    //Delete = ServiceOperations.Delete,
                }
            };
        }
    }
}