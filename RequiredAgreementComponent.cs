using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Localization;
using Kentico.Forms.Web.Mvc;
using CustomFormComponent.RequiredAgreement;


[assembly:RegisterFormComponent(RequiredAgreementComponent.IDENTIFIER, typeof(RequiredAgreementComponent), "Required agreement", Description = "Provides a checkbox that must be selected in order for the form submission to pass validation. Ideal for mandatory agreements that are necessary in order to process the form submission.", IconClass = "icon-cb-check-preview", ViewName = "~/RequiredAgreementComponent/_RequiredAgreement.cshtml")]

namespace CustomFormComponent.RequiredAgreement
{
    /// <summary>
    /// Represents a checkbox form component that can be marked as required.
    /// </summary>
    public class RequiredAgreementComponent : FormComponent<RequiredAgreementProperties,bool>
    {
        /// <summary>
        /// Represents the <see cref="RequiredAgreementComponent"/> identifier.
        /// </summary>
        public const string IDENTIFIER = "RequiredAgreementComponent";


        /// <summary>
        /// Represents the input value in the resulting HTML.
        /// </summary>
        [BindableProperty]
        public bool Value { get; set; }


        /// <summary>
        /// Gets name of the <see cref="Value"/> property.
        /// </summary>
        public override string LabelForPropertyName => nameof(Value);


        /// <summary>
        /// Gets the <see cref="Value"/>.
        /// </summary>
        public override bool GetValue()
        {
            return Value;
        }


        /// <summary>
        /// Sets the <see cref="Value"/>.
        /// </summary>
        public override void SetValue(bool value)
        {
            Value = value;
        }

        /// <summary>
        /// Performs validation of the requireable check box component.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>A collection that holds failed-validation information.</returns>
        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();

            //if the checkbox is not checked
            if(!Value)
            {
                string errorMessage = string.IsNullOrEmpty(Properties.ErrorMessage) ? "This value must be selected to submit the form." : Properties.ErrorMessage;
                errors.Add(new ValidationResult(errorMessage));
            }

            return errors;
        }
    }
}
