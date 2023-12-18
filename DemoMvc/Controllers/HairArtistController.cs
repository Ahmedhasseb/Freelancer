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
    public class HairArtistController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HairArtistController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        // GET: HairArtistController
        public async Task<IActionResult> Index()
        {

           
                var HairArtist = await _unitOfWork.HairArtist.GetAll();

                await _unitOfWork.Complete();

                var empmapper = _mapper.Map<IEnumerable<HairArtist>, IEnumerable<HairArtistViewModel>>(HairArtist);
                return View(empmapper);
            
          
        }

        // GET: HairArtistController/Details/5
        public async Task<IActionResult> Details(int? id, string view = "Details")
        {
            
            if (id is null)
            {
                return BadRequest();
            }
            var HairArtist = await _unitOfWork.HairArtist.Get(id.Value);
            await _unitOfWork.Complete();
            if (HairArtist is null)
            {
                return NotFound();
            }
            var empmapper = _mapper.Map<HairArtist, HairArtistViewModel>(HairArtist);

            return View(view, empmapper);

        }

        // GET: HairArtistController/Create
        public IActionResult Create()
        {


            return View();
        }

        // POST: HairArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HairArtistViewModel ClientVM)
        {
            if (ModelState.IsValid)
            {
                if (ClientVM.Image==null)
                {
                    return View(ClientVM);
                }
                ClientVM.ImageName = DocumentSettings.uploadFile(ClientVM.Image, "image");
                var empmapper = _mapper.Map<HairArtistViewModel, HairArtist>(ClientVM);
                await _unitOfWork.HairArtist.Add(empmapper);
                await _unitOfWork.Complete();
                return RedirectToAction(nameof(Index));
            }
            return View(ClientVM);
        }

        // GET: HairArtistController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return await Details(id, "Edit");
        }

        // POST: HairArtistController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, HairArtistViewModel HairArtistVM)
        {
            if (id != HairArtistVM.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    HairArtistVM.ImageName = DocumentSettings.uploadFile(HairArtistVM.Image, "image");
                    var empmaper = _mapper.Map<HairArtistViewModel, HairArtist>(HairArtistVM);
                    _unitOfWork.HairArtist.Update(empmaper);
                    await _unitOfWork.Complete();
                    return RedirectToAction(nameof(Index));
                }
                catch (System.Exception ex)
                {

                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(HairArtistVM);
        }

        // GET: HairArtistController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return await Details(id, "Delete");
        }

        // POST: HairArtistController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, HairArtistViewModel HairArtistVM)
        {
            if (id != HairArtistVM.Id)
            {
                return BadRequest();
            }
            try
            {
                var empmapper = _mapper.Map<HairArtistViewModel, HairArtist>(HairArtistVM);
                _unitOfWork.HairArtist.Delete(empmapper);
                await _unitOfWork.Complete();

                DocumentSettings.DeleteFile(empmapper.ImageName, "image");


                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(HairArtistVM);
        }
    }
}
