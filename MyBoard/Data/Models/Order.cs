using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBoard.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name ="Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage ="Превышена допустимая длинна 10 символов")]
        public string name { get; set; }
        [Display(Name = "Фамилия")]
        [StringLength(10)]
        [Required(ErrorMessage = "Превышена допустимая длинна 10 символов")]
        public string surname { get; set; }
        [Display(Name = "Ведите адрес")]
        [StringLength(20)]
        [Required(ErrorMessage = "Превышена допустимая длинна 20 символов")]
        public string address { get; set; }
        [Display(Name = "Введите номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Required(ErrorMessage = "Превышена допустимая длинна 10 символов")]
        public string phone { get; set; }
        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(20)]
        [Required(ErrorMessage = "Превышена допустимая длинна 20 символов")]
        public string email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderdetails { get; set; }
    }
}
