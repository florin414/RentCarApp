using AspNetCoreHero.ToastNotification.Abstractions;

namespace RentCarApplication.Pages.Shared
{
    public class CarDetailModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly INotyfService _notyfService;
        private readonly ILogger<RentCarModel> _logger;

        public CarDetailModel(IMediator mediator, INotyfService notyfService, ILogger<RentCarModel> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _notyfService = notyfService ?? throw new ArgumentNullException(nameof(notyfService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Car Car { get; set; }

        [BindProperty]
        public Rent Rent { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var car = await _mediator.Send(new GetCarByIdRequest { Id = id });
                Car = car;
            }
            catch (Exception ex)
            {
                _logger.LogError("{Error}", ex);
                ModelState.AddModelError(string.Empty, "");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCancelAsync()
        {
            try
            {
                return RedirectToPage("/Shared/RentCar");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Error}", ex);

                ModelState.AddModelError(string.Empty, "");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostCreateRentAsync(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Car = await _mediator.Send(new GetCarByIdRequest { Id = id });
                    Rent.CarId = Car.Id;

                    await _mediator.Send(new CreateRentRequest { Rent = Rent });
                }
                _notyfService.Success("Your rental request to complete successfully");
                return RedirectToPage("/Shared/RentCar");
            }
            catch (Exception ex)
            {
                _logger.LogError("{Error}", ex);
                ModelState.AddModelError(string.Empty, "");
            }
            return Page();
        }

    }
}
