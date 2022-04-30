using System;
using System.Linq;


namespace AccManager.Data.Model.Validation
{

    public class ValidaModelo<TEntity>
    {

        private TEntity _entity;

        protected void Inicializar(TEntity entity)
        {
            this._entity = entity;
        }

        public bool EhValido(out string errorMessage)
        {
            errorMessage = "";
            bool result = true;
            if (!this._entity.FindPropertyOfType<RequiridoAttribute>(ref errorMessage)) result = false;
            if (!this._entity.FindPropertyOfType<EmailValidoAttribute>(ref errorMessage)) result = false;

            return result;
        }
    }

    public class EmailValidoAttribute : Attribute, IValidaAttribute
    {
        public string TextMessageError { get; set; }

        public bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (!(value is string valueAsString))
            {
                return false;
            }

            // only return true if there is only 1 '@' character
            // and it is neither the first nor the last character
            int index = valueAsString.IndexOf('@');

            return
                index > 0 &&
                index != valueAsString.Length - 1 &&
                index == valueAsString.LastIndexOf('@');
        }
    }

    public class RequiridoAttribute : Attribute, IValidaAttribute
    {

        public string TextMessageError { get; set; }

        public bool IsValid(object? value)
        {
            if (value == null || string.IsNullOrEmpty(value?.ToString()))
            {
                return false;
            }
            else return true;
        }

    }

    public static class ValidaExtencao
    {
        public static bool FindPropertyOfType<TAtributo>(this object entity, ref string props) where TAtributo : class
        {
            string prop = "";
            bool result = true;
            Array.ForEach(entity.GetType().GetProperties(), x =>
            {
                var attribute = x.GetCustomAttributes(false).Where(a => a.GetType() == typeof(TAtributo)).FirstOrDefault();
                if (attribute != null)
                {
                    var value = x.GetValue(entity).ToString();

                    if (!(attribute as IValidaAttribute).IsValid(value))
                    {
                        result = false;

                        var propertys = attribute.GetType().GetProperties();
                        var property = propertys.Where(p => p.Name == NomePropriedade.TextMessageError).FirstOrDefault();
                        var propertyValue = property.GetValue(attribute);

                        prop += $"{propertyValue}\n";
                    }
                }
            });
            props += prop;
            return result;
        }
    }

    public interface IValidaAttribute
    {
        public string TextMessageError { get; set; }

        public bool IsValid(object? value);
    }

    struct NomePropriedade
    {
        public const string TextMessageError = "TextMessageError";
    }
}
