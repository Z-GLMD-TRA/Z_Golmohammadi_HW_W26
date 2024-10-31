// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable
using System.ComponentModel.DataAnnotations;
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
    public class NewCategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<NewCategoryModel> _logger;

        public NewCategoryModel(ICategoryService categoryService, ILogger<NewCategoryModel> logger,UserManager<User> userManager)
        {
            _logger = logger;
            _categoryService = categoryService; 

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public CategoryDTO NewCategory { get; set; } = new CategoryDTO();

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string ErrorMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await _categoryService.CreateCategory(NewCategory);
                if (result)
                {
                    _logger.LogInformation("Category created successfully.");
                    return RedirectToPage("CategoryList");
                }
                else
                {
                    // Log the failure and add a model error
                    _logger.LogWarning("Category creation failed.");
                    ModelState.AddModelError(string.Empty, "Unable to create category. Please try again.");
                }
            }
            else
            {
                _logger.LogWarning("Model state is invalid.");
            }

            // Return the page with the current model state to show validation errors
            return Page();
        }
    }
}
