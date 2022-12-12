using System.ComponentModel.DataAnnotations;

namespace CRMEducacional.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [CPFAttribute]
        public string CPF { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public virtual List<Enrollment>? Enrollments { get; set; }
    }

    public class CPFAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            string cpf = value.ToString();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return new ValidationResult("CPF inválido");
            }
            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
            {
                if (cpf[i] != cpf[0])
                {
                    igual = false;
                }
            }
            if (igual || cpf == "12345678909")
            {
                return new ValidationResult("CPF inválido");
            }
            int[] numeros = new int[11];
            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(cpf[i].ToString());
            }
            int soma = 0;
            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }
            int resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                {
                    return new ValidationResult("CPF inválido");
                }
            }
            else if (numeros[9] != 11 - resultado)
            {
                return new ValidationResult("CPF inválido");
            }
            soma = 0;
            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }
            resultado = soma % 11;
            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                {
                    return new ValidationResult("CPF inválido");
                }
            }
            else
            {
                if (numeros[10] != 11 - resultado)
                {
                    return new ValidationResult("CPF inválido");
                }
            }
            return ValidationResult.Success;
        }
    }

}