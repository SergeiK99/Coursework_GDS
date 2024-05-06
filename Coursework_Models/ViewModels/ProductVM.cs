using Microsoft.AspNetCore.Mvc.Rendering;

namespace Coursework_Models.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> CategorySelectList { get; set; }
        public IEnumerable<SelectListItem> ManufacturerSelectList { get; set; }
    }
}
