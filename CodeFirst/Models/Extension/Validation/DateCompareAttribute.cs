using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirst.Models.Extension.Validation
{
    public sealed class DateCompareAttribute : ValidationAttribute, IClientValidatable
    {
        public string CompareToPropertyName { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var baseDate = value.ToString();
            var compareDateInfo = validationContext.ObjectType.GetProperty(CompareToPropertyName);
            var compareDate = (IComparable)compareDateInfo.GetValue(validationContext.ObjectInstance, null);
            if (string.IsNullOrWhiteSpace(baseDate))
            {
                return null;
            }
            if (baseDate.CompareTo(compareDate.ToString()) <= 0)
            {
                return new ValidationResult(base.ErrorMessage);
            }
            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string errorMessage = this.FormatErrorMessage(metadata.DisplayName);
            ModelClientValidationRule validationRule = new ModelClientValidationRule();
            validationRule.ErrorMessage = errorMessage;
            validationRule.ValidationType = "datecompare";
            validationRule.ValidationParameters.Add("comparetopropertyname", CompareToPropertyName);
            yield return validationRule;
        }
    }
}