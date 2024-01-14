using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace djanak.Tests.Helpers
{
    public class ObjectValidator : IObjectModelValidator  //Slouží k ověřování platnosti objektů ASP.NET Core aplikace
    {
        bool _bypassValidation;
        public ObjectValidator(bool bypassValidation)  //Pomocí tohoto kontruktoru lze nastavit zda se má validace obejít či nikoliv (nastaví se buďto false nebo true)
        {
            _bypassValidation = bypassValidation;
        }

        public void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)  //Tato metoda slouží k provedení validace objektu
        {
            if (_bypassValidation == false)
            {
                var context = new ValidationContext(model, serviceProvider: null, items: null);
                var results = new List<ValidationResult>();

                bool isValid = Validator.TryValidateObject(  //Pokud validace selže, je tato informace předána do isValid
                    model, context, results,
                    validateAllProperties: true
                );

                if (!isValid)  //isValid je zde proto aby mohly být chyby přiřazeny k jednotlivým vlastnostem objektu a následně zobrazeny ve formuláři nebo uživatelském rozhraní
                    results.ForEach((r) =>
                    {
                        foreach (var memberName in r.MemberNames)
                            actionContext.ModelState.AddModelError(memberName, r.ErrorMessage);
                    });
            }
        }
    }
}
