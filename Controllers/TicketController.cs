using AirTravels.Interfaces;
using AirTravels.Models;
using AirTravels.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace AirTravels.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IPassangerRepository _passangerRepository;
        private readonly IPropertyRepository<City> _cityRepository;
        private readonly IPropertyRepository<Company> _companyRepository;
        private readonly IPropertyRepository<DocumentType> _documentTypeRepository;
        private readonly IDocumentRepository _documentRepository;

        public TicketController(ITicketRepository ticketRepository, IPropertyRepository<City> cityRepository, 
                                IPropertyRepository<Company> companyRepository, IPassangerRepository passangerRepository,
                                IPropertyRepository<DocumentType> documentTypeRepository, IDocumentRepository documentRepository)
        {
            _ticketRepository = ticketRepository;
            _cityRepository = cityRepository;
            _companyRepository = companyRepository;
            _passangerRepository = passangerRepository;
            _documentTypeRepository = documentTypeRepository;
            _documentRepository = documentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new CreateTicketViewModel{ 
                                DeparturePoints = await _cityRepository.GetAll(),
                                Destinations = await _cityRepository.GetAll(),
                                ServiceProviders = await _companyRepository.GetAll(),
                                Passangers = await _passangerRepository.GetAll(),
                                };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateTicketViewModel ticketVM)
        {
            if (ModelState.IsValid)
            {
                var ticket = new Ticket
                {
                    DeparturePoint = ticketVM.DeparturePointId,
                    Destination = ticketVM.DestinationId,
                    OrderNumber = ticketVM.OrderNumber,
                    ServiceProvider = ticketVM.ServiceProviderId,
                    DepartureDate = DateOnly.Parse(ticketVM.DepartureDate),
                    ArrivalDate = DateOnly.Parse(ticketVM.ArrivalDate),
                    ServiceRegistrationDate = DateOnly.Parse(ticketVM.ServiceRegistrationDate),
                    Passanger = ticketVM.PassangerId
                };

                _ticketRepository.Add(ticket);
                return Redirect("~/Home/Index");
            }

            return View(ticketVM);
        }

        [HttpGet] 
        public async Task<IActionResult> Show()
        {
            var tickets = (await _ticketRepository.GetAll()).ToList();
            var ticketVMs = tickets.Select(async viewModel => new TicketViewModel
            {
                Id = viewModel.Id,
                DeparturePoint = await _cityRepository.GetById(viewModel.DeparturePoint),
                Destination = await _cityRepository.GetById(viewModel.Destination),
                OrderNumber = viewModel.OrderNumber.ToString(),
                ServiceProvider = await _companyRepository.GetById(viewModel.ServiceProvider),
                DepartureDate = viewModel.DepartureDate.ToString(),
                ArrivalDate= viewModel.ArrivalDate.ToString(),
                ServiceRegistrationDate = viewModel.ServiceRegistrationDate.ToString(),
                isCompleted = viewModel.IsCompleted,
            }).Select(t => t.Result).ToList();

            for (int i = 0; i < ticketVMs.Count(); i++)
            {
                if (tickets[i].Passanger == null)
                    continue;

                ticketVMs[i].Passanger = await _passangerRepository.GetById(tickets[i].Passanger);

                if (ticketVMs[i].Passanger.Document == null)
                    continue;

                ticketVMs[i].Document = await _documentRepository.GetById(ticketVMs[i].Passanger.Document);
                ticketVMs[i].DocumentType = await _documentTypeRepository.GetById(ticketVMs[i].Document.Type);
            }
            
            return View(ticketVMs.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _ticketRepository.Delete(await _ticketRepository.GetFullInfoByIdAsync(id));
            return RedirectToAction("Show");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketRepository.GetFullInfoByIdAsync(id);
            var ticketVM = new EditTicketViewModel
            {
                Id = id,
                DeparturePoint = (await _cityRepository.GetById(ticket.DeparturePoint)).Name,
                DeparturePointId = ticket.DeparturePoint,
                Destination = (await _cityRepository.GetById(ticket.Destination)).Name,
                DestinationId = ticket.Destination,
                Cities = await _cityRepository.GetAll(),
                Companies = await _companyRepository.GetAll(),
                OrderNumber = ticket.OrderNumber,
                DepartureDate = ticket.DepartureDate.ToString(),
                ArrivalDate = ticket.ArrivalDate.ToString(),
                ServiceRegistrationDate = ticket.ServiceRegistrationDate.ToString(),
                IsCompleted = ticket.IsCompleted,
            };

            return View(ticketVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTicketViewModel ticketVM)
        {
            var ticket = await _ticketRepository.GetFullInfoByIdAsync(ticketVM.Id);
            ticket.DeparturePoint = ticketVM.DeparturePointId;
            ticket.Destination = ticketVM.DestinationId;
            ticket.OrderNumber = ticketVM.OrderNumber;
            ticket.DepartureDate = DateOnly.Parse(ticketVM.DepartureDate) == default ? ticket.DepartureDate : DateOnly.Parse(ticketVM.DepartureDate);
            ticket.ArrivalDate = DateOnly.Parse(ticketVM.ArrivalDate) == default ? ticket.ArrivalDate : DateOnly.Parse(ticketVM.ArrivalDate);
            ticket.ServiceProvider = ticketVM.ServiceProviderId;
            ticket.ServiceRegistrationDate = DateOnly.Parse(ticketVM.ServiceRegistrationDate) == default ? ticket.ServiceRegistrationDate : DateOnly.Parse(ticketVM.ServiceRegistrationDate);
            ticket.IsCompleted = ticketVM.IsCompleted;
            _ticketRepository.Update(ticket);
            return RedirectToAction("Show");
        }

        [HttpGet]
        public async Task<IActionResult> ShowReport(ReportViewModel reportViewModel)
        {
            var tickets = await _ticketRepository.GetAll();
            var startPeriod = DateOnly.Parse(reportViewModel.StartDate);
            var endPeriod = DateOnly.Parse(reportViewModel.EndDate);

            var showReportVM = tickets.Where( ticket => ticket.Passanger == reportViewModel.PassangerId &&
                                            ((ticket.ServiceRegistrationDate >= startPeriod & ticket.ServiceRegistrationDate <= endPeriod) ||
                                              ticket.DepartureDate >= startPeriod & ticket.ServiceRegistrationDate <= endPeriod & ticket.IsCompleted == true)).
                                       Select(async ticket => new ShowReportViewModel
                                              {
                                                  Id = ticket.Id,
                                                  ServiceRegistrationDate = ticket.ServiceRegistrationDate,
                                                  ArrivalDate = ticket.ArrivalDate,
                                                  OrderNumber = ticket.OrderNumber.ToString(),
                                                  DeparturePoint = (await _cityRepository.GetById(ticket.DeparturePoint)).Name,
                                                  Destination = (await _cityRepository.GetById(ticket.Destination)).Name,
                                                  IsCompleted = ticket.IsCompleted
                                              }).Select(t => t.Result);

            return View(showReportVM);
        }

        [HttpGet]
        public async Task<IActionResult> Report()
        {
            var reportVM = new ReportViewModel
            {
                Passangers = await _passangerRepository.GetAll(),
            };

            return View(reportVM);
        }
    }
}
