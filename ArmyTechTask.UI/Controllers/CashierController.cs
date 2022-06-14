using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArmyTechTask.UI.Models;
using ArmyTechTask.Core.Common.Interfaces;
using ReflectionIT.Mvc.Paging;
using ArmyTechTask.UI.Models.CashierVM;
using AutoMapper;
using ArmyTechTask.Core.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmyTechTask.UI.Controllers;

public class CashierController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public CashierController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var query = await _unitOfWork.Cashier.GetAllAsync();
        var model = PagingList.Create(query, 6, page);
        return View(model);
    }
    // GET: Cashier/Create
    public ActionResult Create()
    {
        ViewBag.list = FillBranchList();
        return View();
    }

    // POST: Cashier/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Obsolete]
    public ActionResult Create(CashierVm model)
    {
        if (ModelState.IsValid)
        {
            var data = mapper.Map<Cashier>(model);
            _unitOfWork.Cashier.AddOne(data);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public ActionResult Edit(int id)
    {
        ViewBag.listb = FillBranchList();
        var cashier = _unitOfWork.Cashier.Find(c => c.Id == id);
        var model = mapper.Map<CashierVm>(cashier);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Obsolete]
    public ActionResult Edit(CashierVm model)
    {
        if (ModelState.IsValid && model != null)
        {
            var cashier = mapper.Map<Cashier>(model);
            _unitOfWork.Cashier.Update(cashier);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    // GET: Cashier/Delete/5
    public ActionResult Delete(int id)
    {
        var cashier = _unitOfWork.Cashier.Find(c => c.Id == id);
        var model = mapper.Map<CashierVm>(cashier);
        return View(model);
    }

    // POST: Cashier/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(CashierVm model)
    {
        try
        {
            // TODO: Add delete logic here
            var data = mapper.Map<Cashier>(model);
            _unitOfWork.Cashier.Delete(data);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private IEnumerable<SelectListItem> FillBranchList()
    {
        var headers = _unitOfWork.Branch.GetAll().ToList();
        var itemS = new SelectListItem { Text = "--- Please Select One Branch ---", Value = "0", Disabled = true };
        var menueList = new List<SelectListItem>();
        menueList.Insert(0, itemS);
        foreach (var item in headers)
        {
            menueList.Add(new SelectListItem { Text = item.BranchName, Value = item.Id.ToString() });
        }

        return menueList;
    }
}
