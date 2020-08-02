using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.Localization;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class ValidationAdapterProvider : IValidationAttributeAdapterProvider
    {
        public IAttributeAdapter? GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer localizer)
        {
            Type type = attribute.GetType();

            if (type == typeof(RequiredAttribute))
                return new RequiredAdapter((RequiredAttribute)attribute);

            return null;
        }
    }

    public class RequiredAdapter : AttributeAdapterBase<RequiredAttribute>
    {
        public RequiredAdapter(RequiredAttribute attribute)
            : base(attribute, null)
        {
            attribute.ErrorMessage = "TEST";
        }

        public override void AddValidation(ClientModelValidationContext context)
        {
        }
        public override String GetErrorMessage(ModelValidationContextBase context)
        {
            return GetErrorMessage(context.ModelMetadata);
        }
    }
}