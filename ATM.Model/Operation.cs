using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATM.Model
{
    public class Operation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public OperationTypeEnum Code { get; set; }
        public DateTime Time { get; set; }
        public string Detail { get; set; }
        public int CreditCardId { get; set; }

        public CreditCard CreditCard { get; set; }
    }
}
