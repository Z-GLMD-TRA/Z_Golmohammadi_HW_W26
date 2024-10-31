// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using DataTransferObject.DTOClasses;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Model.Entities;
using Service.ServiceInterfaces;

namespace App.Web.Areas.Identity.Pages.Account
{
    public class NewTicketModel : PageModel
    {
        private readonly ITicketService _ticketService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<NewTicketModel> _logger;
        private readonly UserManager<User> _userManager;

        public NewTicketModel(ITicketService ticketService, ICategoryService categoryService, ILogger<NewTicketModel> logger, UserManager<User> userManager)
        {
            _ticketService = ticketService;
            _categoryService = categoryService; 
            _logger = logger;
            _userManager = userManager;
        }

        [BindProperty] 
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            public TicketDTO Ticket { get; set; } = new TicketDTO();
            public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>(); 
        }

        [TempData] public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            ViewData["Title"] = "Add New Ticket";
            Input.Categories = await _categoryService.GetAllCategories();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = User.FindFirstValue(ClaimTypes.Name);
                User user = await _userManager.FindByNameAsync(userName) ?? await _userManager.FindByIdAsync(userId);

                // Set creator and editor information
                Input.Ticket.CreatorId = user.Id;
                Input.Ticket.EditorId = user.Id;
                Input.Ticket.CreatedAt = DateTime.UtcNow;
                Input.Ticket.EditedAt = DateTime.UtcNow;

                // Create the ticket
                var result = await _ticketService.CreateTicket(Input.Ticket);
                if (result)
                {
                    _logger.LogInformation("Ticket created successfully.");
                    return RedirectToPage("TicketList"); // Redirect to the ticket list page after successful creation
                }
                else
                {
                    // Log the failure and add a model error
                    _logger.LogWarning("Ticket creation failed.");
                    ModelState.AddModelError(string.Empty, "Unable to create ticket. Please try again.");
                }
            }
            else
            {
                _logger.LogWarning("Model state is invalid.");
            }

            // Reload categories for the dropdown if model state is invalid
            Input.Categories = await _categoryService.GetAllCategories();
            return Page();
        }
    }
}