using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Platform.Framework.WebApi.Hypermedia.Specs;
using IQ.Platform.Framework.WebApi.Model.Hypermedia;
using IQ.Platform.Framework.WebApi.Rpc;
using IQ.Santos.Ngo.Beertap.Model;

namespace IQ.Santos.Ngo.Beertap.WebApi.Hypermedia
{
    public class OfficeSpec: SingleStateResourceSpec<Office, string>
    {
        public static ResourceUriTemplate Uri = ResourceUriTemplate.Create("Offices({id})");

        public override string EntrypointRelation
        {
            get { return LinkRelations.Office; }
        }

        public override IResourceStateSpec<Office, NullState, string> StateSpec
        {
            get
            {
                
                return new SingleStateSpec<Office, string>
                {
                    Links =
                    {
                        CreateLinkTemplate(LinkRelations.Tap, BeerTapSpec.Uri.Many, c => c.Id)          
                    } 
                    ,Operations =
                    {
                        Get = ServiceOperations.Get
                        ,Post = ServiceOperations.Update
                        ,Delete = ServiceOperations.Delete
                    }
                  
                };
            }
        }
    }
}