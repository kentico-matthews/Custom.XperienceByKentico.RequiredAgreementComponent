# Required Agreement Component
The out-of-box checkbox component in **Xperience 13 Form builder** does not allow you to mark checkbox fields as required. This does not account for use cases where the user should not be able to submit a form without agreeing to something. 

The form control in this repository allows you to add a checkbox that can be marked as required, in which case it will cause the form submission to fail validation when left un-checked.

## Adding the code to your solution
If you copy all three of the included files into a folder called **RequiredAgreementComponent** in the root directory of your live site, the component should be usable after a build. 

However, you likely have an existing setup with your own conventions for where to store custom form components and widgets, or don't want this folder cluttering up your root directory. In that case, you can follow these steps to get the form component working in your site. <br/><br/>
1. Copy **RequiredAgreementProperties.cs** to the directory in your live site project where you are storing custom form component properties.
   1. Update the namespace in which this class is defined to match your other custom form component properties <br/><br/>

1. Copy **RequirableCheckBoxComponent.cs** to the directory in your live site project where you are storing custom form components.
   1. Update the namespace in which this class is defined to match your other custom form components
   1. Update the **using** directive for **CustomFormComponent.RequiredAgreementComponent** to reflect this namespace.
   1. If your properties are stored in a separate namespace, add a using directive for it. <br/><br/>

1. Copy **_RequiredAgreement.cshtml** to the directory in your live site project where you are storing custom form component views.
   1. Remove any **@using** directives from the view for libraries that are already included in **_ViewImports.cshtml**, or otherwise included by default.
   1. Update the **@using** directive for **CustomFormComponent.RequiredAgreementComponent** to reflect the namespace where your form component class is stored.
   1. Switch to **RequirableCheckBoxComponent.cs** and update the **RegisterFormComponent** assembly attribute, setting **ViewName** to the path where you saved the view
      * If you stored the view in **~/Views/Shared/FormComponents**, the **ViewName** parameter can be removed from the **RegisterFormComponent** attribute.

## Setup
This form control contains some resource strings that will need to be added to your site. Add resource strings with the following keys in the **Localization** app. Sample values are included, but you can set them to whatever you want.
* `requiredagreementcomponent.name`
   * *Required agreement*
* `requiredagreementcomponent.description`
   * *Provides a checkbox that must be selected in order for the form submission to pass validation. Ideal for mandatory agreements that are necessary in order to process the form submission.*
* `requiredagreementcomponent.error.notchecked`
   * *This value must be selected to submit the form.*
* `requiredagreementcomponent.errormessage.name`
   * *Error message*
* `requiredagreementcomponent.errormessage.tooltip`
  * *A custom error message to display when the checkbox is not selected. Can include localization macros.*

## Usage
When using the required agreement in a form, note that the **Label** property controls the label for the overall field, while the **Text** property creates an inline label for the textbox specifically. The **Text** field allows you to HTML markup. For example, entering `I have read and agree to the <a href="https://www.google.com">Terms and Conditions</a>` into the **Text** property will include a hyperlink to google.com in the inline checkbox label.

A custom error message can be entered in the **Error message** field. If it is left blank, the component will fall back to the default `requiredagreementcomponent.error.notchecked` resource string value.

Both of these properties accept localization macros in the format {$resourcekeyname$}