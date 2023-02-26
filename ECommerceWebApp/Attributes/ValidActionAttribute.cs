using System.ComponentModel.DataAnnotations;
using static ECommerceWebApp.ViewModels.ShoppingItemViewModel;

namespace ECommerceWebApp.Attributes
{
    public class ValidActionAttribute : ValidationAttribute
    {
        private readonly ActionType[] _validActions;

        public ValidActionAttribute(params ActionType[] validActions)
        {
            _validActions = validActions;
        }

        public override bool IsValid(object value)
        {
            return value is ActionType action && _validActions.Contains(action);
        }
    }
}
