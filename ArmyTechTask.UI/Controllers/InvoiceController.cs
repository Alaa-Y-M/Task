using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArmyTechTask.UI.Models.Invoice;
using ArmyTechTask.Core.Common.Interfaces;
using ReflectionIT.Mvc.Paging;
using ArmyTechTask.Core.Entities;
using ArmyTechTask.UI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArmyTechTask.UI.Controllers;

public class InvoiceController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;

    public InvoiceController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var query = await _unitOfWork.InvoiceDetail.GetAllAsync();
        // ViewBag.customer=_unitOfWork.InvoiceHeader;

        var model = PagingList.Create(query, 6, page);
        return View(model);
    }
    public ActionResult CreateInvoiceDetails()
    {
        ViewBag.list = FillInvoiceHeaderList();
        return View();
    }

    // POST: Invoice/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Obsolete]
    public ActionResult CreateInvoiceDetails(InvoiceDetailsVm model)
    {
        if (ModelState.IsValid)
        {
            var invoiceDetail = mapper.Map<InvoiceDetail>(model);

            _unitOfWork.InvoiceDetail.AddOne(invoiceDetail);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public ActionResult CreateInvoiceHeader()
    {
        ViewBag.listb=FillBranchList();
        ViewBag.listc=FillCashierList();
        return View();
    }

    // POST: Invoice/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Obsolete]
    public ActionResult CreateInvoiceHeader(InvoiceHeaderVm model)
    {
        if (ModelState.IsValid)
        {
            var invoiceHeader = mapper.Map<InvoiceHeader>(model);

            _unitOfWork.InvoiceHeader.AddOne(invoiceHeader);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }
    public ActionResult EditInvoiceDetails(int id)
    {
        ViewBag.list = FillInvoiceHeaderList();
        var detail = _unitOfWork.InvoiceDetail.Find(p => p.Id == id);
        var model = mapper.Map<InvoiceDetailsVm>(detail);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Obsolete]
    public ActionResult EditInvoiceDetails(InvoiceDetailsVm model)
    {
        if (ModelState.IsValid && model != null)
        {
            var detail = mapper.Map<InvoiceDetail>(model);
            _unitOfWork.InvoiceDetail.Update(detail);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    public ActionResult EditInvoiceHeader(int id)
    {
        ViewBag.listb=FillBranchList();
        ViewBag.listc=FillCashierList();
        var detail = _unitOfWork.InvoiceHeader.Find(p => p.Id == id);
        var model = mapper.Map<InvoiceHeaderVm>(detail);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Obsolete]
    public ActionResult EditInvoiceHeader(InvoiceHeaderVm model)
    {
        if (ModelState.IsValid && model != null)
        {
            var detail = mapper.Map<InvoiceHeader>(model);
            _unitOfWork.InvoiceHeader.Update(detail);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }
    // GET: invoice/Delete/5
    public ActionResult Delete(int id)
    {
        var data = _unitOfWork.InvoiceDetail.Find(d => d.Id == id);
        data.InvoiceHeaderId = id;
        var model = mapper.Map<InvoiceDetailsVm>(data);
        return View(model);
    }

    // POST: invoice/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(InvoiceDetailsVm model)
    {
        try
        {
            // TODO: Add delete logic here
            var data = mapper.Map<InvoiceDetail>(model);
            _unitOfWork.InvoiceDetail.Delete(data);
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

    #region lists
    //fill lists
    private IEnumerable<SelectListItem> FillInvoiceHeaderList()
    {
        var headers = _unitOfWork.InvoiceHeader.GetAll().ToList();
        var itemS = new SelectListItem { Text = "--- Please Select One Customer ---", Value = "0", Disabled = true };
        var menueList = new List<SelectListItem>();
        menueList.Insert(0, itemS);
        foreach (var item in headers)
        {
            menueList.Add(new SelectListItem { Text = item.CustomerName, Value = item.Id.ToString() });
        }

        return menueList;
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
    private IEnumerable<SelectListItem> FillCashierList()
    {
        var headers = _unitOfWork.Cashier.GetAll().ToList();
        var itemS = new SelectListItem { Text = "--- Please Select One Cashier ---", Value = "0", Disabled = true };
        var menueList = new List<SelectListItem>();
        menueList.Insert(0, itemS);
        foreach (var item in headers)
        {
            menueList.Add(new SelectListItem { Text = item.CashierName, Value = item.Id.ToString() });
        }

        return menueList;
    }

    //total invoice  header and details remember that

    #endregion

}