using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.BL.DTOs;
using Store.BL.Features.AdminPanel.Requests.Commands;
using Store.BL.Features.AdminPanel.Requests.Queries;
using Store.BL.Features.Transaction.Requests.Queries;

namespace Store.Presentation.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IMediator mediator;

        public AdminPanelController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // Panel Page
        public async Task<IActionResult> Index()
        {
            var request = new GetInfoAdminPanelRequest();
            return View(await mediator.Send(request));
        }



        #region Orders Page

        // Orders
        public async Task<IActionResult> Orders()
        {
            var request = new GetOrdersInPanelRequest();
            var result = await mediator.Send(request);
            return View(result);
        }

        #endregion

        #region Products Page

        // Products
        public async Task<IActionResult> Products()
        {
            var request = new GetProductListRequest();
            return View(await mediator.Send(request));
        }


        // Add Product Category Brand
        [HttpPost]
        public async Task<IActionResult> AddProduct([FromForm]ProductInfoDto model, [FromForm]IFormFile ProductImage)
        {
            var request = new AddProductRequestCommand
            {
                FormFile = ProductImage,
                ProductInfoDto = model
            };
            await mediator.Send(request);
            return RedirectToAction("Products");
        }

        // Update
        [HttpPost]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductInfoDto model, [FromForm] IFormFile ProductImage)
        {
            var request = new UpdateProductRequest
            {
                FormFile = ProductImage,
                ProductInfoDto = model
            };
            await mediator.Send(request);
            return RedirectToAction("Products");
        }

        // Delete
        [HttpPost]
        public async Task<IActionResult> DeleteProduct([FromForm] ProductInfoDto model, [FromForm] IFormFile ProductImage)
        {
            var request = new DeleteProductRequestCommand
            {
                ProductInfoDto = new ProductInfoDto { ProductId = model.ProductId },
            };
            await mediator.Send(request);
            return RedirectToAction("Products");
        }

        #endregion

        #region User Page

        // User Management Index
        public async Task<IActionResult> UserManage()
        {
            var request = new GetUsersAndAdminsRequest();
            return View(await mediator.Send(request));
        }

        #region User CRUD
        public async Task<IActionResult> DeleteUser([FromForm] string PhoneNumber)
        {
            var request = new DeleteUserRequestCommand() { PhoneNumber = PhoneNumber };
            await mediator.Send(request);
            return RedirectToAction("UserManage");
        }

        public async Task<IActionResult> UpdateUser([Bind("PhoneNumber", "Balance")] UsersInfoDto usersInfoDto, [FromForm] string oldPhoneNumber)
        {
            var request = new UpdateUserRequestCommand { UsersInfoDto = usersInfoDto, OldPhoneNumber = oldPhoneNumber };
            await mediator.Send(request);
            return RedirectToAction("UserManage");
        }

        public async Task<IActionResult> UserOfTransactions([FromQuery] string phoneNumber)
        {
            var request = new GetAllTransactionsOfUserRequest { PhoneNumber = phoneNumber };
            return View(await mediator.Send(request));
        }
        #endregion

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

        #endregion
    }
}
