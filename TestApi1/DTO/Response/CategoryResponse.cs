using System.ComponentModel.DataAnnotations;
using TestApi1.Models;

namespace TestApi1.DTO.Response
{
    public class CategoryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


    }
}
