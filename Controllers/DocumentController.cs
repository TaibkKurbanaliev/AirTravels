using AirTravels.Interfaces;
using AirTravels.Models;
using AirTravels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AirTravels.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IPropertyRepository<DocumentType> _documentTypeRepository;

        public DocumentController(IDocumentRepository documentRepository, 
                                  IPropertyRepository<DocumentType> documentTypeRepository)
        {
            _documentRepository = documentRepository;
            _documentTypeRepository = documentTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            var documents = await _documentRepository.GetAll();
            var documentViewModels = documents.Select(async doc => new AllDocumentsViewModel
            {
                Id = doc.Id,
                DocumentType = await _documentTypeRepository.GetById(doc.Type),
                Number = doc.Number,
            }).Select(t => t.Result);
            return View(documentViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            _documentRepository.Delete(await _documentRepository.GetById(id));
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var document = await _documentRepository.GetById(id);
            var editVM = new EditDocumentViewModel
            {
                Id = document.Id,
                Type = (await _documentTypeRepository.GetById(document.Type)).Type,
                TypeId = document.Type,
                Number = document.Number,
                DocumentTypes = await _documentTypeRepository.GetAll()
            };

            return View(editVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditDocumentViewModel editVM)
        {
            var document = await _documentRepository.GetById(editVM.Id);
            document.Type = editVM.TypeId;
            document.Number = editVM.Number;
            
            _documentRepository.Update(document);
            return RedirectToAction("ShowAll");
        }

        [HttpGet]
        public async Task<IActionResult> ShowDocument(int id)
        {
            var document = await _documentRepository.GetById(id);
            var documentVM = new ShowDocumentByPassangerVM
            {
                Id = document.Id,
                Number = document.Number,
                Type = (await _documentTypeRepository.GetById(document.Type)).Type
            };

            return View(documentVM);
        }
    }
}
