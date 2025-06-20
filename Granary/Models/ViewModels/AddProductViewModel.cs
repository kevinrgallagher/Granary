﻿using Granary.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class AddProductViewModel
{
    public Product Product { get; set; } = new();

    [BindNever]
    [ValidateNever]
    public SelectList Categories { get; set; } = null!;
}