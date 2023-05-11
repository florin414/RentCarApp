using AspNetCoreHero.ToastNotification.Abstractions;
using RentCarApplication.Domain.Entities;

namespace RentCarApplication.Pages.Shared
{
    public class RentCarModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly INotyfService _notyfService;
        private readonly ILogger<RentCarModel> _logger;

        public RentCarModel(IMediator mediator, INotyfService notyfService, ILogger<RentCarModel> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _notyfService = notyfService ?? throw new ArgumentNullException(nameof(notyfService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [BindProperty]
        public IEnumerable<Car> Cars { get; set; }


        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var cars = await _mediator.Send(new GetAllCarRequest());
                Cars = cars;
            }
            catch (Exception ex)
            {
                _logger.LogError("{Error}", ex);
                ModelState.AddModelError(string.Empty, "");
            }
            return Page();
        }

        public void OnPostDetail(int id)
        {
            string url = $"/Shared/CarDetail?id={id}";
            Response.Redirect(url);
        }
    }
}
