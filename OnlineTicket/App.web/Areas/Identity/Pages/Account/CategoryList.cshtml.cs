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
    public class CategoryModel : PageModel
    {
        private readonly ICategoryService _categoryService;

        private readonly ILogger<CategoryModel> _logger;

        public CategoryModel(ICategoryService categoryService, ILogger<CategoryModel> logger)
        {
            _logger = logger;
            _categoryService = categoryService; 

        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

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

        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _categoryService.GetAllCategories();
            return Page();
        }


        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
