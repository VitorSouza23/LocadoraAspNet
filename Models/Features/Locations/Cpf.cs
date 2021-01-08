using System;

namespace LocadoraAspNet.Models.Features.Locations
{
    public class Cpf
    {
        protected Cpf() { }
        public Cpf(string value)
        {
            if (IsValid(value))
                Value = value;
            else
                throw new ArgumentException();
        }

        public string Value { get; }

        public static implicit operator Cpf(string value) => new Cpf(value);

        public override string ToString()
        {
            return Value;
        }

        private bool IsValid(string value)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "");

            if (value.Length != 11)
                return false;

            string temporaryCpf = value.Substring(0, 9);
            string digit = GetDigit(multiplier1, temporaryCpf);
            temporaryCpf = temporaryCpf + digit;
            digit = digit + GetDigit(multiplier2, temporaryCpf);

            return value.EndsWith(digit);
        }

        private string GetDigit(int[] multiplier, string temporaryCpf)
        {
            int sum = 0;

            for (int i = 0; i < multiplier.Length; i++)
                sum += int.Parse(temporaryCpf[i].ToString()) * multiplier[i];

            int rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;

            return rest.ToString();
        }
    }

}