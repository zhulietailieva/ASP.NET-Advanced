namespace TrailVenturesSystem.Web.ViewModels.Mountain.Interfaces
{   
    public interface IMountainDetailsModel
    {
        /// <summary>
        /// Contains all the properties that we want to be included in the url
        /// We use this interface as a wrapper to create an extension that returns the url and replaces some of its parts
        /// </summary>
        public string Name { get;  }
    }
}
