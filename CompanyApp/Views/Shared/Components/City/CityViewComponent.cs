
using Microsoft.AspNetCore.Mvc;
using CompanyApp.Data.Entities;

namespace CompanyApp.Views.Shared.Components.City
{
    public class CityViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? CityId)
        {
            var db = new CompanyAppDbContext();

            if (CityId is not null )
            {

                var values = db.Counties.Where(x => x.CityId == CityId).ToList();
                return View(values);
            }
            else
            {
                var values = new List<Data.Entities.County>();

                return View(values);
            }



        }
    }
}
