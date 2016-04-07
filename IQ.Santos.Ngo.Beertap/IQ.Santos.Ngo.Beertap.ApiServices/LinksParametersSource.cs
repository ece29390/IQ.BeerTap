namespace IQ.Santos.Ngo.Beertap.ApiServices
{
    /// <summary>
    /// The class is used to pass additional parameters to hypermedia links definitions in resource specifications.
    /// </summary>
    public class LinksParametersSource
    {       
        public LinksParametersSource(
            string officeid
            ,int beertapid
         
            )
        {
            Officeid = officeid;
            BeerTapId = beertapid;
           
        }

        public int BeerTapId { get; private set; }
       
        public string Officeid { get; private set; }
    }
}