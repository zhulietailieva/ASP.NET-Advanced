namespace TrailVenturesSystem.Web.ViewModels.Mountain
{
    //no need for validations because we get this model from the db and load it to the form
    public class TripSelectMountainFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
