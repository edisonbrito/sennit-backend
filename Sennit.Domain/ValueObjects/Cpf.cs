using FluentValidator;

namespace Sennit.Domain.ValueObjects
{
    public class CPF : Notifiable
    {
        public CPF() { }

        public CPF(string number)
        {
            Number = number;

            if (!Validate(number))
                AddNotification("Cpf", "Cpf inválido");
        }

        public string Number { get; private set; }

        public bool Validate(string number)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            number = number.Trim();
            number = number.Replace(".", "").Replace("-", "");

            if (number.Length != 11)
                return false;

            TempCPF = number.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return number.EndsWith(Digito);
        }
    }
}
