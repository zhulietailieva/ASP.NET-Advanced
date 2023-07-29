namespace TrailVenturesSystem.Web.Infrastructure.ModelBinders
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Globalization;
    using System.Threading.Tasks;

    //How to create a model binder:
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult valueResult =
                bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult != ValueProviderResult.None && !string.IsNullOrWhiteSpace(valueResult.FirstValue))
            {
                decimal parsedValue = 0m;
                bool binderSucceeded = false;

                try
                {
                    string formDecValue = valueResult.FirstValue;

                    formDecValue = formDecValue.Replace(",", 
                        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    formDecValue = formDecValue.Replace(".",
                        CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

                    //We use Convert when we are not working with the console
                    parsedValue = Convert.ToDecimal(formDecValue);
                    binderSucceeded = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (binderSucceeded)
                {
                    bindingContext.Result = ModelBindingResult.Success(parsedValue);
                }

            }
            return Task.CompletedTask;
        }
    }
}
