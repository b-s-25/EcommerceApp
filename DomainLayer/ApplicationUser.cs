using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public bool isActive { get; set; }
        public DateTime createdOn { get; set; }
        public string createdBy { get; set; }
        public DateTime modifiedOn { get; set; }
        public string modifiedBy { get; set; }
        public int roleId { get; set; }
    }
}
