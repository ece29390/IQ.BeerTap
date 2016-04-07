using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using IQ.Santos.Ngo.Beertap.Model.SupportResources;

namespace IQ.Santos.Ngo.Beertap.ApiServices
{
    public interface INewGlassApiService: ICreateAResourceAsync<NewGlass,int>
    {
    }
}
