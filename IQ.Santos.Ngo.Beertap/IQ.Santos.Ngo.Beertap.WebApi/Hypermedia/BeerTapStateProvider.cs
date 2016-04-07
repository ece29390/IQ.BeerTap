using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.Hypermedia;
using IQ.Santos.Ngo.Beertap.Model;

namespace IQ.Santos.Ngo.Beertap.WebApi.Hypermedia
{
    public class BeerTapStateProvider: ResourceStateProviderBase<BeerTap, KegLevel>
    {
        public override KegLevel GetFor(BeerTap resource)
        {
            return resource.KegStatus;
        }

        protected override IDictionary<KegLevel, IEnumerable<KegLevel>> GetTransitions()
        {
            return new Dictionary<KegLevel, IEnumerable<KegLevel>>
                {
                    // from --> to
                    {KegLevel.New, new []
                    {
                        KegLevel.GoingDown
                    }},

                    {KegLevel.GoingDown, new []
                    {
                        KegLevel.AlmostEmpty
                    }},

                    {KegLevel.AlmostEmpty, new []
                    {
                        KegLevel.SheIsDry
                    }},
                };
        }

        public override IEnumerable<KegLevel> All
        {
            get { return EnumEx.GetValuesFor<KegLevel>(); }
        }
    }
}