using AirTravels.Interfaces;
using AirTravels.Models;
using AirTravels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AirTravels.Controllers
{
    public class PassangerController : Controller
    {
        private readonly IPassangerRepository _passangerRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly IPropertyRepository<DocumentType> _documentTypeRepository;

        public PassangerController(IPassangerRepository passangerRepository, IDocumentRepository documentRepository,
                                   IPropertyRepository<DocumentType> documentTypeRepository)
        {
            _passangerRepository = passangerRepository;
            _documentRepository = documentRepository;
            _documentTypeRepository = documentTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var createPassangerVM = new CreatePassangerViewModel
            {
                DocumentTypes = await _documentTypeRepository.GetAll()
            };

            return View(createPassangerVM);
        }

        [HttpPost]
        public IActionResult Create(CreatePassangerViewModel passangerVM)
        {
            var document = new Document
            {
                Type = passangerVM.Document.Type,
                Number = passangerVM.Document.Number
            };

            _documentRepository.Add(document);

            var passanger = new Passanger
            {
                SecondName = passangerVM.SecondName,
                FirstName = passangerVM.FirstName,
                ThirdName = passangerVM.ThirdName,
                Document = document.Id
            };

            _passangerRepository.Add(passanger);
            return Redirect("~/Home/Index");

        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            var passangers = await _passangerRepository.GetAll();
            var passangersVMs = passangers.Select(async viewModel =>  new AllPassangerViewModel
            {
                Id = viewModel.Id,
                SecondName = viewModel.SecondName,
                FirstName = viewModel.FirstName,
                ThirdName = viewModel.ThirdName,
                Document = viewModel.Document is null ? new Document() : await _documentRepository.GetById(viewModel.Document),
                DocumentType = viewModel.Document is null ? new DocumentType() : await _documentTypeRepository.GetById((await _documentRepository.GetById(viewModel.Document)).Type)
            }).Select(t => t.Result);
            return View(passangersVMs);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _passangerRepository.Delete(await _passangerRepository.GetById(id));
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var passanger = await _passangerRepository.GetById(id);
            var passangerVM = new EditPassangerViewModel
            {
                Id = id,
                SecondName = passanger.SecondName,
                FirstName = passanger.FirstName,
                ThirdName = passanger.ThirdName,
            };

            return View(passangerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPassangerViewModel passangerVM)
        {
            var passanger = await _passangerRepository.GetById(passangerVM.Id);
            passanger.SecondName = passangerVM.SecondName;
            passanger.FirstName = passangerVM.FirstName;
            passanger.ThirdName = passangerVM.ThirdName;

            _passangerRepository.Update(passanger);
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public async Task<IActionResult> ShowPassanger(int id)
        {
            var passanger = await _passangerRepository.GetById(id);

            if (passanger == null)
                return NotFound();

            var passangerVM = new ShowPassangerByTicketVM
            {
                Id = id,
                SecondName = passanger.SecondName,
                FirstName = passanger.FirstName,
                ThirdName = passanger.ThirdName,
                Document = await _documentRepository.GetById(passanger.Document)
            };

            if (passangerVM.Document != null)
                passangerVM.DocumentType = (await _documentTypeRepository.GetById(passangerVM.Document.Type)).Type;

            return View(passangerVM);
        }
    }
}
