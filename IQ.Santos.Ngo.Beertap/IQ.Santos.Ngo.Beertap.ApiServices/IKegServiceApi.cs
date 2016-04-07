﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IQ.Platform.Framework.WebApi;
using IQ.Santos.Ngo.Beertap.Model;

namespace IQ.Santos.Ngo.Beertap.ApiServices
{
    public interface IKegServiceApi: IGetAResourceAsync<Keg, int>,
        IGetManyOfAResourceAsync<Keg, int>,
        ICreateAResourceAsync<Keg, int>,
        IDeleteResourceAsync<Keg, int>
    {
    }
}
