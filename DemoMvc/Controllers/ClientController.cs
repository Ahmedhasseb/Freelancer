using AutoMapper;
using BLL.Interfaces;
using DAL.Moduls;
using DemoMvc.Helpers;
using DemoMvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoMvc.Controllers
{
    public class ClientController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: ClientViewModelController
        public async Task<IActionResult> Index()
        {


            var Client = await _unitOfWork.Client.GetAll();

            await _unitOfWork.Complete();

            var empmapper = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(Client);
            return View(empmapper);


        }

        // GET: ClientController/Details/5
        public async Task<IActionResult> Details(int? id, string view = "Details")
        {
           
            if (id is null)
            {
                return BadRequest();
            }
            var Client = await _unitOfWork.Client.Get(id.Value);
            await _unitOfWork.Complete();
            if (Client is null)
            {
                return NotFound();
            }
            var empmapper = _mapper.Map<Client, ClientViewModel>(Client);

            return View(view, empmapper);

        }

        // GET: ClientController/Create
        public IActionResult Create()
        {


            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientViewModel ClientVM)
        {
            if (!ModelState.IsValid)
            {
                ClientVM.ImageName = DocumentSettings.uploadFile(ClientVM.Image, "image");
                var empmapper = _mapper.Map<ClientViewModel, Client>(ClientVM);
                await _unitOfWork.Client.Add(empmapper);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(ClientVM);
        }

        // GET: ClientController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, ClientViewModel ClientVM)
        {
            if (id != ClientVM.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                try
                {
                    ClientVM.ImageName = DocumentSettings.uploadFile(ClientVM.Image, "image");
                    var empmaper = _mapper.Map<ClientViewModel, Client>(ClientVM);
                    _unitOfWork.Client.Update(empmaper);
                    await _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(ClientVM);
        }

        // GET: ClientController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, ClientViewModel ClientVM)
        {
            if (id != ClientVM.Id)
            {
                return BadRequest();
            }
            try
            {
                
                var empmapper = _mapper.Map<ClientViewModel, Client>(ClientVM);
                _unitOfWork.Client.Delete(empmapper);
                await _unitOfWork.Complete();

                DocumentSettings.DeleteFile(empmapper.ImageName,"image");


                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(ClientVM);

        }
    }
}
