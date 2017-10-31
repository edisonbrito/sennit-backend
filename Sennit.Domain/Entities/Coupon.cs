using FluentValidator;
using Sennit.Shared.Entities;

namespace Sennit.Domain.Entities
{
    public class Coupon : Entity
    {
        protected Coupon() { }

        public Coupon(int? idCustumer, string number, bool isAwarded)
        {
            IdCustomer = idCustumer;
            Number = number;
            IsUsed = false;
            Isawarded = isAwarded;
        }

        public string Number { get; private set; }
        public bool IsUsed { get; private set; }
        public bool Isawarded { get; private set; }
        public int? IdCustomer { get; private set; }  
        
        public string ConfirmeIsIsawarded()
        {
           return Isawarded == true ? "Parabéns seu cumpom é um cumprom premiado.":"Não foi dessa vez, seu cumpom não é premiado.";
        }
        
        public void UpdateCoupon(int idCustomer)
        {
            IdCustomer = idCustomer;
            IsUsed = true;           
        }
    }
}
