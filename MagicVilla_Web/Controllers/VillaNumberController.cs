using AutoMapper;
using Azure;
using MagicVill_VillAPI.Models;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.APIResponses;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Models.VM;
using MagicVilla_Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MagicVilla_Web.Controllers
{
    public class VillaNumberController : Controller
    {
        private readonly IVillaNumberService _villaNumberService;
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;

        public VillaNumberController(IVillaNumberService villaNumberService, IMapper mapper, IVillaService villaService)
        {
            _villaNumberService = villaNumberService;
            _mapper = mapper;
            _villaService = villaService;
        }

        public async Task<IActionResult> IndexVillaNumber()
        {
            List<VillaNumberDTO> list = new();

            var response = await _villaNumberService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        [HttpGet]
        public async Task<IActionResult> CreateVillaNumber()
        {
            VillaNumberCreateVM villaNumberVM = new();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess && response.ErrorMessages.Count == 0)
            {
                villaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
            }
            return View(villaNumberVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVillaNumber(VillaNumberCreateVM model)
        {
            if(ModelState.IsValid)
            {
                var resp = await _villaNumberService.CreateAsync<APIResponse>(model.VillaNumber);
                if (resp != null && resp.IsSuccess)
                {
                    TempData["success"] = "Villa number created succefully";
                    return RedirectToAction("IndexVillaNumber");
                }
                else
                {
                    if (resp.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", resp.ErrorMessages.FirstOrDefault());
                    }
                }
            }
           
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVillaNumber(int VillaNo)
        {
            VillaNumberUpdateVM VillaNumberVM = new();
            var response = await _villaNumberService.GetAsync<APIResponse>(VillaNo);
            if(response != null && response.IsSuccess)
            {
                VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                VillaNumberVM.VillaNumber = _mapper.Map<VillaNumberUpdateDTO>(model);
            }

            response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                    VillaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
                return View(VillaNumberVM);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateVillaNumber(VillaNumberUpdateVM model)
        {
            if (ModelState.IsValid)
            {
                var resp = await _villaNumberService.UpdateAsync<APIResponse>(model.VillaNumber);
                if (resp != null && resp.IsSuccess)
                {
                    TempData["success"] = "Villa number updated succefully";
                    return RedirectToAction("IndexVillaNumber");
                }
                else
                {
                    if (resp.ErrorMessages.Count > 0)
                    {
                        ModelState.AddModelError("ErrorMessages", resp.ErrorMessages.FirstOrDefault());
                    }
                }
            }

            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                model.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                    (Convert.ToString(response.Result)).Select(i => new SelectListItem
                    {
                        Text = i.Name,
                        Value = i.Id.ToString()
                    });
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVillaNumber(int VillaNo)
        {
            VillaNumberDeleteVM VillaNumberVM = new();
            var response = await _villaNumberService.GetAsync<APIResponse>(VillaNo);
            if (response != null && response.IsSuccess)
            {
                VillaNumberDTO model = JsonConvert.DeserializeObject<VillaNumberDTO>(Convert.ToString(response.Result));
                VillaNumberVM.VillaNumber = model;
            }

            response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                VillaNumberVM.VillaList = JsonConvert.DeserializeObject<List<VillaDTO>>
                (Convert.ToString(response.Result)).Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(VillaNumberVM);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVillaNumber(VillaNumberDeleteVM model)
        {
            var response = await _villaNumberService.DeleteAsync<APIResponse>(model.VillaNumber.VillaNo);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(IndexVillaNumber));
            }
            return View(model);
        }
    }
}
