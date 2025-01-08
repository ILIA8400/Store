using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.BL.DTOs;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.BL.Features.AdminPanel.Requests.Queries;

namespace Store.Presentation.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IMediator mediator;

        public AdminPanelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var request = new GetInfoAdminPanelRequest();
            return View(await mediator.Send(request));
        }


        // User Management
        public async Task<IActionResult> UserManage()
        {
            var request = new GetUsersAndAdminsRequest();
            return View(await mediator.Send(request));
        }


        public async Task<IActionResult> DeleteUser()
        {
            return null;
        }
        
        public async Task<IActionResult> UpdateUser()
        {
            return null;
        }

        public async Task<IActionResult> UserOfTransactions()
        {
            return null;
        }


        // Orders
        public async Task<IActionResult> Orders()
        {
            return View();
        }

        // Products
        public async Task<IActionResult> Products()
        {
            return View();
        }

        #region Admin CRUD
        [HttpPost]
        public async Task<IActionResult> AddAdmin([Bind("PhoneNumber")] UsersInfoDto usersInfoDto)
        {
            var request = new AddAdminRequestCommand() { UsersInfoDto = usersInfoDto };
            await mediator.Send(request);
            return RedirectToAction("UserManage");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAdmin([Bind("PhoneNumber")] UsersInfoDto usersInfoDto)
        {
            var request = new RemoveAdminRequestCommand() { UsersInfoDto = usersInfoDto };
            await mediator.Send(request);
            return RedirectToAction("UserManage");
        } 
        #endregion
    }
}
