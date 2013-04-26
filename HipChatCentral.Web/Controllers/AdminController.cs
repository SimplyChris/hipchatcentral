using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Transactions;
using System.Web.Mvc;
using HipChatCentral.Domain.Constants;
using HipChatCentral.Domain.Interfaces;
using HipChatCentral.Domain.Models;
using HipChatCentral.Domain.Models.ViewModels;
using HipChatCentral.Domain.Services;

namespace HipChatCentral.Web.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<GroupAccount> _groupRepository;
        private IRepository<HipChatApiKey> _apiRepository;
        private readonly ICustomLogger<AdminController> _logger;
        //
        // GET: /Admin/

        public AdminController (IRepository<GroupAccount> groupRepository, IRepository<HipChatApiKey> apiRepository, ICustomLogger<AdminController> logger )
        {
            _groupRepository = groupRepository;
            _apiRepository = apiRepository;
            _logger = logger;
            _logger.DebugLog("AdminController Created");
        }

        public ActionResult Index()
        {
            return Details(DebugConstants.MockRegistrationId);
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id)
        {
            var groups = _groupRepository.GetCollection(x => x.RegistrationId == id);
            var groupListViewModel = new GroupAccountsViewModel()
                {
                    GroupAccounts = groups,
                    RegistrationId = id
                };
            return View("Index", groupListViewModel);            
        }

        //
        // GET: /Admin/Create

        public ActionResult Create(Int32 RegistrationId)
        {
            return View("Create", new GroupAccount() {RegistrationId = RegistrationId});
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(GroupAccount groupAccount)
        {
            try
            {                   
                _groupRepository.Insert(groupAccount);
                _groupRepository.SaveChanges();
                return RedirectToAction("Details", new {id = groupAccount.RegistrationId});
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id)
        {
            var group = _groupRepository.GetSingle(x => x.Id == id);            
            var apiKeyListViewModel = CreateApiKeyListViewModel(group);
            return View(apiKeyListViewModel);
        }

        private ApiKeyListViewModel CreateApiKeyListViewModel(GroupAccount group)
        {
            var editApiKeyViewModel = group.ApiKeys.Select(x => Mappers.MapEditApiKeyModel(x)).ToList();
            var apiKeyListViewModel = new ApiKeyListViewModel() {GroupId = group.Id, KeyList = editApiKeyViewModel};
            return apiKeyListViewModel;
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id, int registrationId)
        {
            using (var scope = new TransactionScope())
            {
                var group = _groupRepository.GetSingle(x => x.Id == id);
                var apiKeyListModel = CreateApiKeyListViewModel(group);
                DeleteKeysFromList(apiKeyListModel.KeyList);
                _groupRepository.Delete(x => x.Id == id);
                _groupRepository.SaveChanges();    
                scope.Complete();
            }
            
            return Details(registrationId);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }        

        public ActionResult AddKey (Int32 groupId)
        {
            var group = _groupRepository.GetSingle(x => x.Id == groupId);
            var createKeyViewModel = new CreateApiKeyViewModel {groupAccount = group};            
            return View("AddKey", createKeyViewModel);
        }

        [HttpPost]
        public ActionResult AddKey (CreateApiKeyViewModel viewModel)
        {            
            var group = _groupRepository.GetSingle(x => x.Id == viewModel.groupAccount.Id);
            
            group.ApiKeys.Add (new HipChatApiKey {ApiKey = viewModel.apiKey.ApiKey, Name = viewModel.apiKey.Name});
            _groupRepository.SaveChanges();            
            return RedirectToAction("Edit",  new {id = group.Id});
        }

        [HttpPost]
        public ActionResult DeleteKeys (ApiKeyListViewModel deleteModel)
        {

            if (deleteModel.KeyList == null || !deleteModel.KeyList.Where(x=>x.IsSelected).Any())
            {
                ModelState.AddModelError("", "No items selected to delete");
                var groupId = deleteModel.GroupId;

                var group = _groupRepository.GetSingle(x => x.Id == groupId);
                var keyListModel = CreateApiKeyListViewModel(group);
                return View("Edit", keyListModel);                               
            }

            try
            {
                var deleteList = deleteModel.KeyList.Where(x => x.IsSelected);
                DeleteKeysFromList(deleteList);
            }
            catch (Exception ex)
            {
                _logger.InfoLog("Exception Thrown When Deleting Selected ApiKeys. Message: {0}", ex.Message);
                ModelState.AddModelError("", "An error occured deleting selected keys");
                return RedirectToAction("Edit", new { id = deleteModel.GroupId });                                
            }
            return RedirectToAction("Edit", new {id = deleteModel.GroupId});
        }
        
        private void DeleteKeysFromList (IEnumerable<EditApiKeyViewModel> deleteList )
        {
            foreach (var item in deleteList)
            {
                _apiRepository.Delete(x => x.Id == item.Id);
            }

            _apiRepository.SaveChanges();            
        }
    }
}
