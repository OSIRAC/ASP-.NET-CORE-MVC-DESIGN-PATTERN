using AutoMapper;
using EFCORE_VERİALMA.Models;
using EFCORE_VERİALMA.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCORE_VERİALMA.Views.Shared.ViewComponents
{
    public class VisistorViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public VisistorViewComponent(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitors = _context.Visitors.ToList();

            var visitorviewmodel = _mapper.Map<List<VisitorViewModel>>(visitors);

            ViewBag.Visitors = visitorviewmodel;
            return View();
        }


    }
}
