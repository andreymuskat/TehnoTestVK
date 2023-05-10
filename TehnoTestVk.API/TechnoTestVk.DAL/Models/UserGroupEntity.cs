using System.ComponentModel.DataAnnotations;
using Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TechnoTestVk.DAL.Models
{
    public class UserGroupEntity
    {
        [Key]
        public int Id { get; set; }

        public GroupStatus Code { get; set; }

        public string? Description { get; set; }
    }
}
