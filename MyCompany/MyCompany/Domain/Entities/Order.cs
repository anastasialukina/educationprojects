using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace MyCompany.Domain.Entities
{
    public class Order : EntityBase
    {
        [Required(ErrorMessage = "Заполните название заказа")]
        [Display(Name = "Название заказа")]
        public override string Title { get; set; }

        [Display(Name = "Описание заказа")]
        public override string Subtitle { get; set; }

        [Display(Name = "Текст выполненного заказа")]
        public override string Text { get; set; }

        [Display(Name = "Статус заказа")]
        public OrderStatus Status { get; set; }

        [ForeignKey(nameof(Executor))]
        public string ExecutorId { get; set; }

        public IdentityUser Executor { get; set; }

        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; }

        public IdentityUser Customer { get; set; }
    }
}